using BLL2.Interfaces;
using DAL2.Context;
using DAL2.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL2.Repositories
{
    public class EmployeeRepository :GenericRepository<Employee> ,IEmployeeRepository
    {
        

        public EmployeeRepository(MVCAppDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Employee>> SearchByName(string value)
        {
            return await _dbContext.Employees.Where(d => d.Name.Contains(value)).ToListAsync();
        }
    }
}
