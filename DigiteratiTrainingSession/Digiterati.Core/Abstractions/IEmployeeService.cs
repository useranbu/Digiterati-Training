using Core.ViewModel;
using Digiterati.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digiterati.Core.Abstractions
{
    public interface IEmployeeService
    {
        List<Employees> GetEmployee();
        Task<Employees?> GetAllEmployee(int EmployeeId);
        Task<Employees> CreateEmployee(Employee employee);
        Task<Employees?> UpdateEmployee(Employee employee);
        Task<Employees?> DeleteEmployee(int EmployeeId);
    }
}
