using DAL2.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL2.Interfaces
{
    public interface IUnitOfWork<T> where T: class
    {
        public IDepartment DepartmentRepository { get; set; }
        public IEmployeeRepository EmployeeRepository { get; set; }
        public IGenericRepository<T> GenericRepository { get; set; }
   
        
    
    }
}
