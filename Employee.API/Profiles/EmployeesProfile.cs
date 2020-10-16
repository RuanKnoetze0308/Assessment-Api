using AutoMapper;
using Employee.API.Dtos;
using Employee.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.API.Profiles
{
    public class EmployeesProfile : Profile
    {
        public EmployeesProfile()
        {
            CreateMap<Staff, StaffReadDto>();
            CreateMap<StaffCreateDto, Staff>();
            CreateMap<StaffUpdateDto, Staff>();
            CreateMap<Staff, StaffUpdateDto>();
        }
    }
}
