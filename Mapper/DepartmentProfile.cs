using AutoMapper;
using DAL2;
using EmployeesDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesDashboard.Mapper
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department2, DepartmentViewModel>().ReverseMap();
        }
    }
}
