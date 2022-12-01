using BLL2.Interfaces;
using DAL2.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL2.Repositories
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        public IDepartment DepartmentRepository { get ; set ; }
        public IEmployeeRepository EmployeeRepository { get; set; }
        public IGenericRepository<T> GenericRepository { get; set; }
   

        public UnitOfWork(IDepartment departmentRepo , IEmployeeRepository employeeRepo,
            IGenericRepository<T> genericRepository)
        {
            DepartmentRepository = departmentRepo;
            EmployeeRepository = employeeRepo;
            GenericRepository = genericRepository;
        }
    
    }
}
