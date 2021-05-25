using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scheduler.Domain.Core.Data;
using Scheduler.Infra.Data.Context;

namespace Scheduler.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppointmentDataContext _context;

        public UnitOfWork(AppointmentDataContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
