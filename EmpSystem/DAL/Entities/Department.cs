using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EmpSystem.DAL.Entities
{
    [Table("department")]
    public class Department
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [StringLength(50)]
        public string DepatmentName { get; set; }
        [StringLength(20)]
        public int DepartmentCode { get; set; }
        public Collection<Employee> Employee { get; set; }
    }
}
