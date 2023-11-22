using EmpSystem.Models;

namespace EmpSystem.BL.Interface
{
    public interface ICountryRep
    {
        IQueryable<CountryVM> Get();
        CountryVM GetById(int id);
    }
}
