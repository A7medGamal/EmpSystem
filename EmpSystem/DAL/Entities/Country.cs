using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace EmpSystem.DAL.Entities
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string CountryName { get; set; }
         public Collection<City> City { get; set; }
    }
}
