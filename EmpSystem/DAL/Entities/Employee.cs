using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpSystem.DAL.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)] 
        public string Name { get; set; }
        public float  Salary { get; set; }
        public string  Adress { get; set; }
        public DateTime HireDate { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public int DistrictId { get; set; }
        [ForeignKey("DistrictId")]
        public District District { get; set; }
        [ForeignKey("DepartmentId")]
        public Department  Department { get; set; }


    }
}
