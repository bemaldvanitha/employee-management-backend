using System;
using System.ComponentModel.DataAnnotations;

namespace employee_management_backend.Models.DTOs.EmployeeDTO
{
    public class UpdateEmployeeRequestDTO
    {
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }


        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string LastName { get; set; }


        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }


        [StringLength(250, ErrorMessage = "Address cannot be longer than 250 characters.")]
        public string Address { get; set; }


        [Range(0, double.MaxValue, ErrorMessage = "Basic salary must be a positive value.")]
        public decimal BasicSalary { get; set; }


        [StringLength(100, ErrorMessage = "Department cannot be longer than 100 characters.")]
        public string Department { get; set; }


        [StringLength(20, ErrorMessage = "Gender cannot be longer than 20 characters.")]
        public string Gender { get; set; }
    }
}
