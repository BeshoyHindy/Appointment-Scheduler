

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation.Results;
using Scheduler.Application.ViewModels;

namespace Scheduler.Application.Interfaces
{
    public interface IAppointmentAppService : IDisposable
    {
        Task<ValidationResult> Add(AppointmentViewModel viewModel);
        Task<ValidationResult> Update(AppointmentViewModel viewModel);
        Task<ValidationResult> Delete(Guid id);
        Task<IEnumerable<AppointmentViewModel>> GetAll();
        Task<AppointmentViewModel> GetById(Guid id);
    }
}
