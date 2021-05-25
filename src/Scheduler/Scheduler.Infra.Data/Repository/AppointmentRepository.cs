using Scheduler.Domain.Interfaces;
using Scheduler.Domain.Models;
using Scheduler.Infra.Data.Context;

namespace Scheduler.Infra.Data.Repository
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(AppointmentDataContext context) : base(context)
        {
        }
    }
}