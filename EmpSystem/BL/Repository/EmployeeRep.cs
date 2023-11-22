using EmpSystem.BL.Interface;
using EmpSystem.DAL.Database;
using EmpSystem.Models;
using System.Linq;
using EmpSystem.DAL.Entities;
using AutoMapper;

namespace EmpSystem.BL.Repository
{
    public class EmployeeRep : IEmployeeRep
    {
        private DbContainer db;
        private readonly IMapper mapper;

        public EmployeeRep(DbContainer _db, IMapper _Mapper)
        {
            this.db = _db;
            this.mapper = _Mapper;
        }

        public void add(EmployeeVM employeeVM)
        {
            //old mapping without auto maper
            //Department department = new Department();
            //department.DepatmentName = departmentsVM.DepatmentName;
            //department.DepartmentCode = departmentsVM.DepartmentCode;

            //mapping with auto mapper
            var data = mapper.Map<Employee>(employeeVM);
            db.Employee.Add(data);
            db.SaveChanges();

        }

        public void Delete(int id)
        {
            var Deleted = db.Employee.Find(id);
            db.Employee.Remove(Deleted);
            db.SaveChanges();
        }

        public void Edit(EmployeeVM employeeVM)
        {
            //old mapping without auto maper
            //var OldData = db.Department.Find(departmentsVM.Id);
            //OldData.DepatmentName= departmentsVM.DepatmentName;
            //OldData.DepartmentCode= departmentsVM.DepartmentCode;


            //mapping with auto mapper
            var data = mapper.Map<Employee>(employeeVM);
            db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            db.SaveChanges();
        }

        public IQueryable<EmployeeVM> Get()
        {
            var data = db.Employee.Select(a => new EmployeeVM { Id = a.Id, Name = a.Name, Salary = a.Salary,Email=a.Email,HireDate=a.HireDate ,Adress=a.Adress ,DepartmentId=a.Department.DepatmentName ,DistrictId=a.District.DistrictName});
            return data;
        }

        public EmployeeVM GetById(int id)
        {
            var data = db.Employee.Where(a => a.Id == id)
                                    .Select(a => new EmployeeVM { Id = a.Id, Name = a.Name, Salary = a.Salary, Email = a.Email, HireDate = a.HireDate, Adress = a.Adress, DepartmentId = a.Department.DepatmentName , DistrictId = a.District.DistrictName })
                                    .FirstOrDefault();
            return data;

        }
    }
}
