using BLL2.Interfaces;
using DAL2;
using DAL2.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL2.Repositories
{
    public class DepartmentRepository : GenericRepository<Department2>, IDepartment 
    {
  

        public DepartmentRepository(MVCAppDbContext dbContext):base(dbContext)
        {
          
        }

        public async Task<IEnumerable<Department2>> Search(string value)
        {
            return  await _dbContext.Departments.Where(d => d.Name.Contains(value)).ToListAsync();
        }

    }
}
