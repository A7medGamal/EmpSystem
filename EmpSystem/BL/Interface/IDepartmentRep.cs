using EmpSystem.Models;

namespace EmpSystem.BL.Interface
{
    public interface IDepartmentRep
    {
         IQueryable<DepartmentsVM> Get();
        void add(DepartmentsVM departmentsVM);
        DepartmentsVM GetById(int id);
        void Edit(DepartmentsVM departmentsVM);
        void Delete(int id);
    }
}
