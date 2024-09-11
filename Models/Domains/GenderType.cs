using System.ComponentModel.DataAnnotations;

namespace employee_management_backend.Models.Domains
{
    public class GenderType
    {
        public Guid Id { get; set; }

        [Required]
        public string Gender { get; set; }
    }
}