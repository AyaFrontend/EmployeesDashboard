using AutoMapper;
using DAL2.Entities;
using EmployeesDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesDashboard.Mapper
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeViewModel, Employee>().ReverseMap();
            CreateMap<RegistrationViewModel, Employee>().ReverseMap();
            CreateMap<LoginViewModel, Employee>().ReverseMap();
        }
    }
}
