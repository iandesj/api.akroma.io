using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Akroma.Persistence.SQL;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace Akroma.Import.Tests
{
    public class ImportServiceTests
    {
        public ImportServiceTests(ITestOutputHelper console)
        {
            Trace.Listeners.Add(new TestTraceListener(console));
        }

        [Fact(Skip = "used for migration")]
        public async Task MigrateDatabase()
        {
            var builder = new DbContextOptionsBuilder<AkromaContext>();
            var connection = Environment.GetEnvironmentVariable("AkromaConnectionString") ?? "";
            if (string.IsNullOrEmpty(connection))
            {
                throw new Exception("unable to get connection string from env var");
            }
            
            builder.UseSqlServer(connection);
            var akromaContext = new AkromaContext(builder.Options);
            await akromaContext.Database.EnsureDeletedAsync();
            await akromaContext.Database.MigrateAsync();
            //var service = new ImportService(akromaContext);
            //await service.Execute();
        }
    }
}
