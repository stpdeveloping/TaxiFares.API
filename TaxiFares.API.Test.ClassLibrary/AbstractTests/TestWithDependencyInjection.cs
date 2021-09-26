using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiFares.API.Test.ClassLibrary.Extensions;

namespace TaxiFares.API.Test.ClassLibrary.AbstractTests
{
    public abstract class TestWithDependencyInjection
    {
        protected static readonly IHost Host =
            Program.CreateHostBuilder(Config.CommandArgs).Build();
        protected readonly IList<object> Services =
            new List<object>();

        protected IServiceScope SvcScope;

        protected virtual async Task<TResult> UseSvcAsync<TSvc, 
            TResult>(Func<TSvc, Task<TResult>> callback, 
            bool shouldBeDisposed = true)
        {
            var scopedSvc = GetRequiredScopedService<TSvc>();
            TResult result = await callback(scopedSvc);
            DisposeOrCacheServices(shouldBeDisposed, scopedSvc);
            return result;
        }

        protected async Task UseSvcAsync<TSvc>(
            Func<TSvc, Task> callback, bool shouldBeDisposed = true)
        {
            var scopedSvc = GetRequiredScopedService<TSvc>();
            await callback(scopedSvc);
            DisposeOrCacheServices(shouldBeDisposed, scopedSvc);
        }

        protected TResult UseSvc<TSvc, TResult>(
            Func<TSvc, TResult> callback, bool shouldBeDisposed = true)
        {
            var scopedSvc = GetRequiredScopedService<TSvc>();
            TResult result = callback(scopedSvc);
            DisposeOrCacheServices(shouldBeDisposed, scopedSvc);
            return result;
        }

        protected void UseSvc<TSvc>(Action<TSvc> callback, 
            bool shouldBeDisposed = true)
        {
            var scopedSvc = GetRequiredScopedService<TSvc>();
            callback(scopedSvc);
            DisposeOrCacheServices(shouldBeDisposed, scopedSvc);
        }

        protected virtual void DisposeOrCacheServices(
            bool shouldBeDisposed, params object[] services)
        {
            if (shouldBeDisposed)
                SvcScope.Dispose();
            else
                CacheSvcsWhichAreNotAlreadyCached(services);
        }

        private TSvc GetRequiredScopedService<TSvc>()
        {
            var requiredScopedSvc = (TSvc)Services.GetObjWithType(
                typeof(TSvc));
            if (requiredScopedSvc != null)
                return requiredScopedSvc;
            SvcScope = Host.Services.CreateScope();
            requiredScopedSvc = SvcScope.ServiceProvider
                .GetRequiredService<TSvc>();
            return requiredScopedSvc;
        }

        private void CacheSvcsWhichAreNotAlreadyCached(
            IList<object> services)
        {
            foreach (object uncachedSvc in 
                services.Where(svc => IsSvcNotExistInCache(svc)))
                Services.Add(uncachedSvc);          
        }

        private bool IsSvcNotExistInCache(object svc) =>
            Services.GetObjWithType(svc.GetType()) == null;
    }
}
