using DAL2.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL2.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public  Task<IEnumerable<T>> GetAll();
        public  Task<int> Update(T department);
        public  Task<int> Add(T department);
        public  Task<int> Delete(T department);
        public  Task<T> Get(int? id);
    
     
    }
}
