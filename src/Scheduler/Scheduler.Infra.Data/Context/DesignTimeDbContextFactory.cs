using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Scheduler.Domain.Core.Mediator;

namespace Scheduler.Infra.Data.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppointmentDataContext>
    {
        public AppointmentDataContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<AppointmentDataContext>();
            builder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            return new AppointmentDataContext(builder.Options);
        }
    }
}