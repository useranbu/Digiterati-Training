using Core.ViewModel;
using Digiterati.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digiterati.Core.Abstractions
{
    public interface ISoftLockService
    {
        Task<Softlock?> GetSoftLock(int LockId);
        Task<Softlock?> CreateSoftLock(SoftLockDto softLock);
        Task<Softlock?> UpdateSoftLock(SoftLockDto softLock);
        Task<Softlock?> DeleteSoftLock(int LockId);
    }
}
