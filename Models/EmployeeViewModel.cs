using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesDashboard.Models
{
    public class EmployeeViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public bool isActive { get; set; }
        public string Email { get; set; }
        public string PhoneNumer { get; set; }
        public DateTime DateHire { get; set; }
        public string ImageName { set; get; }
        public IFormFile Image { set; get; }
    }
}
