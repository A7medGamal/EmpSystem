using EmpSystem.Models;

namespace EmpSystem.BL.Interface
{
    public interface ICityRep
    {
        IQueryable<CityVM> Get();
        CityVM GetById(int id);
    }
}
