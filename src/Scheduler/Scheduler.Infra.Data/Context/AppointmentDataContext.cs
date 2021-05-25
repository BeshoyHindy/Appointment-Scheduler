using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Scheduler.Domain.Core.Data;
using Scheduler.Domain.Core.Mediator;
using Scheduler.Domain.Core.Messaging;
using Scheduler.Domain.Models;
using Scheduler.Infra.Data.Mappings;

namespace Scheduler.Infra.Data.Context
{

    public class AppointmentDataContext : DbContext, IUnitOfWork
    {
        public AppointmentDataContext()
        {
            
        }

        private readonly IMediatorHandler _mediatorHandler;

        public AppointmentDataContext(DbContextOptions options, IMediatorHandler mediatorHandler) : base(options)
        {
            _mediatorHandler = mediatorHandler;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public AppointmentDataContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfiguration(new AppointmentMap());

            base.OnModelCreating(modelBuilder);
        }


        public async Task<bool> Commit()
        {
            await _mediatorHandler.PublishDomainEvents(this).ConfigureAwait(false);
            var success = await SaveChangesAsync() > 0;
            return success;
        }
    }
}
