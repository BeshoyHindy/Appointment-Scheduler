using System.Threading.Tasks;

namespace Scheduler.Domain.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}