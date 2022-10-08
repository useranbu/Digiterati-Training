using Core.ViewModel;
using Digiterati.Core.Abstractions;
using Digiterati.Data;
using Digiterati.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Digiterati.Service.Services
{
    public class SoftLockService : ISoftLockService
    {
        private readonly EmployeeDbContext _dbContext;

        public SoftLockService(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Softlock?> GetSoftLock(int LockId)
        {
            var result = await _dbContext.SoftLocks.FirstOrDefaultAsync(s => s.LockId == LockId);
            return result ?? null;
        }

        public async Task<Softlock?> CreateSoftLock(SoftLockDto softLock)
        {
            var result = new Softlock();
            if (softLock != null)
            {
                result.EmployeeId = softLock.Employee_id;
                result.Status = softLock.Status;
                result.Manager = softLock.Manager;
                result.ManagerStatus = softLock.ManagerStatus;
                result.RequestDate = softLock.ReqDate;
                result.LastUpdated = softLock.Lastupdated;
                result.RequestMessage = softLock.ReqMessage;
                result.WfmRemark = softLock.WfmRemark;
                result.MgrStatusComment = softLock.MgrStatusComment;
                result.LastUpdated = softLock.Lastupdated;
                await _dbContext.SoftLocks.AddAsync(result);
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return result;
        }

        public async Task<Softlock?> UpdateSoftLock(SoftLockDto softLock)
        {
            var result = await _dbContext.SoftLocks.FirstOrDefaultAsync(s => s.LockId == softLock.LockId);
            if (result != null)
            {
                result.LockId = softLock.LockId;
                result.EmployeeId = softLock.Employee_id;
                result.Status = softLock.Status;
                result.Manager = softLock.Manager;
                result.ManagerStatus = softLock.ManagerStatus;
                result.RequestDate = softLock.ReqDate;
                result.LastUpdated = softLock.Lastupdated;
                result.RequestMessage = softLock.ReqMessage;
                result.WfmRemark = softLock.WfmRemark;
                result.MgrStatusComment = softLock.MgrStatusComment;
                result.LastUpdated = softLock.Lastupdated;
                _dbContext.SoftLocks.Update(result);
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return new Softlock();
        }

        public async Task<Softlock?> DeleteSoftLock(int LockId)
        {
            var result = await _dbContext.SoftLocks.FirstOrDefaultAsync(s => s.LockId == LockId);
            if (result != null)
            {
                _dbContext.SoftLocks.Remove(result);
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return new Softlock();
        }
    }
}
