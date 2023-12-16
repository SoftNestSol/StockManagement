using StockManagement.Server.Entities;
using StockManagement.Server.ContextModels;
using Microsoft.EntityFrameworkCore;


namespace StockManagement.Server.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly StockContext _context;

        public EmployeeRepository(StockContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
    }
}