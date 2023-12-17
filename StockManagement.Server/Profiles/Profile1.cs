using AutoMapper;
using StockManagement.Server.DTOs;
using StockManagement.Server.Entities;

namespace StockManagement.Server.Profiles

{
    public class Profile1:Profile
    {
        public Profile1()
        {
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EmployeeDTO,Employee>();
        }
    }
}
