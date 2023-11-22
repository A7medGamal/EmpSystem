using AutoMapper;
using EmpSystem.BL.Interface;
using EmpSystem.DAL.Database;
using EmpSystem.Models;

namespace EmpSystem.BL.Repository
{
    public class CountryRep:ICountryRep
    {
        private DbContainer db;
        

        public CountryRep(DbContainer _db)
        {
            this.db = _db;
           
        }
        public IQueryable<CountryVM> Get()
        {
            var data = db.Country.Select(a => new CountryVM { Id = a.Id, CountryName = a.CountryName });
            return data;
        }

        public CountryVM GetById(int id)
        {
            var data = db.Country.Where(a => a.Id == id)
                                    .Select(a => new CountryVM { Id = a.Id, CountryName = a.CountryName })
                                    .FirstOrDefault();
            return data;

        }
    }
}
