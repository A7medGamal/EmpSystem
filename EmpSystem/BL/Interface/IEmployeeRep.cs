using EmpSystem.Models;
namespace EmpSystem.BL.Interface
{
    public interface IEmployeeRep
    {
        IQueryable<EmployeeVM> Get();
        void add(EmployeeVM employeeVM);
        EmployeeVM GetById(int id);
        void Edit(EmployeeVM employeeVM);
        void Delete(int id);
    }
}
