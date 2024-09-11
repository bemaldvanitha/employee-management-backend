using System.ComponentModel.DataAnnotations;

namespace employee_management_backend.Models.Domains
{
    public class Department
    {
        public Guid Id { get; set; }

        [Required]
        public string DepartmentName { get; set; }
    }
}
