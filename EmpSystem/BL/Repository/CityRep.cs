using EmpSystem.BL.Interface;
using EmpSystem.DAL.Database;
using EmpSystem.Models;

namespace EmpSystem.BL.Repository
{
    public class CityRep:ICityRep
    {
        private DbContainer db;


        public CityRep(DbContainer _db)
        {
            this.db = _db;

        }
        public IQueryable<CityVM> Get()
        {
            var data = db.City.Select(a => new CityVM { Id = a.Id, CityName = a.CityName, CountryId=a.CountryId });
            return data;
        }

        public CityVM GetById(int id)
        {
            var data = db.City.Where(a => a.Id == id)
                                    .Select(a => new CityVM { Id = a.Id, CityName = a.CityName, CountryId = a.CountryId })
                                    .FirstOrDefault();
            return data;

        }



    }
}
