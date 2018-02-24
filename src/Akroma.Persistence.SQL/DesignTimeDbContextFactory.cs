using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Akroma.Persistence.SQL
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AkromaContext>
    {
        public AkromaContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AkromaContext>();
            builder.UseSqlServer(Environment.GetEnvironmentVariable("AkromaConnectionString") ?? "", b => b.MigrationsAssembly("Akroma.Persistence.SQL"));
            var context = new AkromaContext(builder.Options);
            return context;
        }
    }
}
