using System;
using System.Threading.Tasks;
using Adsology.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Adsology.Test
{
    public class AdsologyDbContextTest
    {
        private readonly string _connectionString;
        public AdsologyDbContextTest()
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets<AdsologyDbContextTest>()
                .AddEnvironmentVariables()
                .Build();

            _connectionString = configuration.GetConnectionString("AdsologyDatabase");
        }

        [Fact]
        public async Task LoadAllOrderStatusesList()
        {
            var options = new DbContextOptionsBuilder<AdsologyDbContext>()
                .UseSqlServer(_connectionString)
                .Options;

            var dbContext = new AdsologyDbContext(options);
            var statuses = await dbContext.OrderStatuses.ToListAsync();
            Assert.NotEmpty(statuses);
            Assert.Contains(statuses, s => s.Id == 1);
            Assert.Contains(statuses, s => s.Id == 2);
            Assert.Contains(statuses, s => s.Id == 3);
        }
    }
}
