using EmpSystem.BL.Interface;
using EmpSystem.DAL.Database;
using EmpSystem.Models;
using System.Linq;
using EmpSystem.DAL.Entities;
using AutoMapper;

namespace EmpSystem.BL.Repository
{
    public class DepartmentRep : IDepartmentRep
    {
        private DbContainer db;
        private readonly IMapper mapper;

        public DepartmentRep(DbContainer _db ,IMapper _Mapper)
        {
            this.db = _db;
            this.mapper = _Mapper;
        }

        public void add(DepartmentsVM departmentsVM)
        {
            //old mapping without auto maper
            //Department department = new Department();
            //department.DepatmentName = departmentsVM.DepatmentName;
            //department.DepartmentCode = departmentsVM.DepartmentCode;

            //mapping with auto mapper
            var data = mapper.Map<Department>(departmentsVM);
            db.Department.Add(data);
            db.SaveChanges();
            
        }

        public void Delete(int id)
        {
            var Deleted = db.Department.Find(id);
            db.Department.Remove(Deleted);
            db.SaveChanges();
        }

        public void Edit(DepartmentsVM departmentsVM)
        {
            //old mapping without auto maper
            //var OldData = db.Department.Find(departmentsVM.Id);
            //OldData.DepatmentName= departmentsVM.DepatmentName;
            //OldData.DepartmentCode= departmentsVM.DepartmentCode;


            //mapping with auto mapper
            var data = mapper.Map<Department>(departmentsVM);
            db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            db.SaveChanges();
        }

        public IQueryable<DepartmentsVM> Get()
        {
            var data = db.Department.Select(a => new DepartmentsVM { Id = a.Id, DepatmentName = a.DepatmentName,  DepartmentCode = a.DepartmentCode })  ;
            return data ;
        }

        public DepartmentsVM GetById(int id)
        {
            var data = db.Department.Where(a => a.Id == id)
                                    .Select(a => new DepartmentsVM { Id = a.Id, DepatmentName = a.DepatmentName, DepartmentCode = a.DepartmentCode })
                                    .FirstOrDefault();
            return data;

        }
    }
}
