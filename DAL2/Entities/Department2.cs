using DAL2.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL2
{
    public class Department2 
    {
        public string Id { set; get; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime DateOfCreation { get; set; } = DateTime.Now;

        public virtual ICollection<Employee> Employees { get; set; } =
            new HashSet<Employee>();
    }
}
