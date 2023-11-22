using System.ComponentModel.DataAnnotations;

namespace EmpSystem.Models
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="enter Name")]
        [MaxLength(50,ErrorMessage ="Max Length 50 char")]
        [MinLength(3,ErrorMessage = "Min Length 3 char ")]
        public string Name { get; set; }
        [Required(ErrorMessage = "enter Salary")]
        [Range(3000,10000,ErrorMessage ="Salary from 3K to 10k")]
        public float Salary { get; set; }
        public string Adress { get; set; }
        public DateTime HireDate { get; set; }
        public string Email { get; set; }
        public string DepartmentId { get; set; }
        public string DistrictId { get; set; }
    }
}
