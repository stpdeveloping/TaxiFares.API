using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace TaxiFares.API.Test.ClassLibrary.AbstractTests
{
    public abstract class TestWithDIAndDbContext<TDbCtx> : 
        TestWithDependencyInjection 
        where TDbCtx : DbContext
    {
        protected async Task<TResult> UseSvcWithDbContextAsync<TSvc, 
            TResult>(Func<TSvc, TDbCtx, Task<TResult>> callback, 
            bool shouldBeDisposed = true)
        {
            (TSvc svc, TDbCtx ctx) =
                GetRequiredScopedDbCtxAndSvc<TSvc>();
            TResult result = await callback(svc, ctx);
            if (shouldBeDisposed)
                SvcScope.Dispose();
            return result;
        }

        protected async Task UseSvcWithDbContextAsync<TSvc>(
            Func<TSvc, TDbCtx, Task> callback, 
            bool shouldBeDisposed = true)
        {
            (TSvc svc, TDbCtx ctx) = 
                GetRequiredScopedDbCtxAndSvc<TSvc>();
            await callback(svc, ctx);
            if (shouldBeDisposed)
                SvcScope.Dispose();
        }

        protected TResult UseSvcWithDbContext<TSvc, TResult>(
            Func<TSvc, TDbCtx, TResult> callback, 
            bool shouldBeDisposed = true)
        {
            (TSvc svc, TDbCtx ctx) =
                GetRequiredScopedDbCtxAndSvc<TSvc>();
            TResult result = callback(svc, ctx);
            if (shouldBeDisposed)
                SvcScope.Dispose();
            return result;
        }

        protected void UseSvcWithDbContext<TSvc>(
            Action<TSvc, TDbCtx> callback, 
            bool shouldBeDisposed = true)
        {
            (TSvc svc, TDbCtx ctx) = 
                GetRequiredScopedDbCtxAndSvc<TSvc>();
            callback(svc, ctx);
            if(shouldBeDisposed) 
                SvcScope.Dispose();
        }

        private (TSvc, TDbCtx) GetRequiredScopedDbCtxAndSvc<TSvc>()
        {
            SvcScope = Host.Services.CreateScope();
            IServiceProvider svcProvider = SvcScope.ServiceProvider;
            var requiredScopedSvc = svcProvider
                .GetRequiredService<TSvc>();
            var dbCtx = svcProvider.GetRequiredService<TDbCtx>();
            return (requiredScopedSvc, dbCtx);
        }
    }
}
