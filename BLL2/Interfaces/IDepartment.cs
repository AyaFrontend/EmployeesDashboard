using DAL2;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL2.Interfaces
{
    public interface IDepartment
    {

        public Task<IEnumerable<Department2>> Search(string value);
    }
}
