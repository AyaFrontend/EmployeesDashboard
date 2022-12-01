using DAL2.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL2.Context
{
    public class MVCAppDbContext : IdentityDbContext
    {
        public MVCAppDbContext(DbContextOptions<MVCAppDbContext> option):base(option)
        { }

        public DbSet<Department2> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
