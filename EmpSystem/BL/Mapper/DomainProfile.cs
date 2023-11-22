using AutoMapper;
using EmpSystem.DAL.Entities;
using EmpSystem.Models;

namespace EmpSystem.BL.Mapper
{
    public class DomainProfile :Profile
    {
        public DomainProfile()
        {
            CreateMap<Department, DepartmentsVM>().ReverseMap();
           // CreateMap<DepartmentsVM, Department>();
            CreateMap<Employee, EmployeeVM>().ReverseMap() ;
           // CreateMap<EmployeeVM, Employee>();
           
        }
    }
}
