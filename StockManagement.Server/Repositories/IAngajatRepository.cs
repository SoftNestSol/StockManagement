using StockManagement.Server.Entities;
using System.Collections.Generic;

namespace StockManagement.Server.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeAsync(int id);
        Task<Employee> AddEmployeeAsync(Employee employee);
        Task<Employee> UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int id);
    }
}