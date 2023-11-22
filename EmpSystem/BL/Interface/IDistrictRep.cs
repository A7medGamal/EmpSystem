using EmpSystem.Models;

namespace EmpSystem.BL.Interface
{
    public interface IDistrictRep
    {
        IQueryable<DistrictVM> Get();
        DistrictVM GetById(int id);
    }
}
