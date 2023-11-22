using System.ComponentModel.DataAnnotations;

namespace EmpSystem.Models
{
    public class DepartmentsVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Department Name")]
        [MinLength(3, ErrorMessage = "Min Len 3")]
        [MaxLength(10, ErrorMessage = "Max Len 10")]
        public string DepatmentName { get; set; }
        [Required(ErrorMessage = "Enter Department Code")]
        public int DepartmentCode { get; set; }
    }
}
