using DAL2.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL2.Interfaces
{
    public interface IEmployeeRepository
    {
        public Task<IEnumerable<Employee>> SearchByName(string value);
    }
}
