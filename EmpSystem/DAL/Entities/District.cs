using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpSystem.DAL.Entities
{
    public class District
    {
        [Key]
        public int Id { get; set; }
        public string DistrictName { get; set; }
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }
        public Collection<Employee> Employees { get; set; }
    }
}
