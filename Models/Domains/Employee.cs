using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace employee_management_backend.Models.Domains
{
    public class Employee
    {
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Address { get; set; }

        [ForeignKey("Department")]
        public Guid DepartmentId { get; set; }

        [ForeignKey("GenderType")]
        public Guid GenderTypeId { get; set; }

        [Required]
        public Decimal BasicSalary { get; set; }

        public Department Department { get; set; }

        public GenderType GenderType { get; set; }
    }
}