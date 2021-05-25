using Microsoft.Extensions.DependencyInjection;
using Scheduler.Application.Interfaces;
using Scheduler.Domain.Bus;
using Scheduler.Domain.Core.Mediator;
using System;
using FluentValidation.Results;
using MediatR;
using Scheduler.Application.Services;
using Scheduler.Domain.Commands;
using Scheduler.Domain.Core.Data;
using Scheduler.Domain.Events;
using Scheduler.Domain.Interfaces;
using Scheduler.Infra.Data.Context;
using Scheduler.Infra.Data.Repository;
using Microsoft.AspNetCore.Http;
using Scheduler.Infra.Data.UoW;

namespace Scheduler.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<IAppointmentAppService, AppointmentAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<AppointmentAddedEvent>, AppointmentEventHandler>();
            services.AddScoped<INotificationHandler<AppointmentUpdatedEvent>, AppointmentEventHandler>();
            services.AddScoped<INotificationHandler<AppointmentRemovedEvent>, AppointmentEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<AddNewAppointmentCommand, ValidationResult>, AppointmentCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateAppointmentCommand, ValidationResult>, AppointmentCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveAppointmentCommand, ValidationResult>, AppointmentCommandHandler>();

            // Infra - Data
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<AppointmentDataContext>();

        }

    }
}
