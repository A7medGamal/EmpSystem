using EmpSystem.BL.Interface;
using EmpSystem.DAL.Database;
using EmpSystem.Models;

namespace EmpSystem.BL.Repository
{
    public class DistrictRep:IDistrictRep
    {
        private DbContainer db;


        public DistrictRep(DbContainer _db)
        {
            this.db = _db;

        }
        public IQueryable<DistrictVM> Get()
        {
            var data = db.District.Select(a => new DistrictVM { Id = a.Id, DistrictName = a.DistrictName,CityId = a.CityId });
            return data;
        }

        public DistrictVM GetById(int id)
        {
            var data = db.District.Where(a => a.Id == id)
                                    .Select(a => new DistrictVM { Id = a.Id, DistrictName = a.DistrictName, CityId = a.CityId })
                                    .FirstOrDefault();
            return data;

        }

       
    }
}
