using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL2.Entities
{
    public class Employee :IdentityUser

    { 
       
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public bool isActive { get; set; }
        //public string Email { get; set; }
       // public string PhoneNumer { get; set; }
        public DateTime DateHire { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public string ImageName { set; get; }

        public virtual Department2 Department { get; set; }
    }
}
