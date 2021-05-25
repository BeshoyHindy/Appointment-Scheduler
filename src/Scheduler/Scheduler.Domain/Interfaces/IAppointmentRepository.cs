using System.Threading.Tasks;
using Scheduler.Domain.Core.Data;
using Scheduler.Domain.Models;

namespace Scheduler.Domain.Interfaces
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        
    }
}
