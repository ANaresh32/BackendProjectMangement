using FinanceManagement.DATA.Models;
using FinanceManagement.DATA.Repositories;
using FinanceManagement.DOMAIN.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManagement.DOMAIN.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly FinanceDbContext _context;

        public EmployeeRepository(FinanceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.Include(e => e.Projects).ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(string empId)
        {
            return await _context.Employees.Include(e => e.Projects).FirstOrDefaultAsync(e => e.EmployeeId == empId);
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }
    }
}
