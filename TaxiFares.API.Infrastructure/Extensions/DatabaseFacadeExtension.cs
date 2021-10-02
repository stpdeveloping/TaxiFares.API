using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace TaxiFares.API.Infrastructure.Extensions
{
    public static class DatabaseFacadeExtension
    {
        public static void InitSqliteDbInMemory(this DatabaseFacade db)
        {
            db.OpenConnection();
            db.EnsureCreated();
        }
    }
}
