using System;
using System.ComponentModel.DataAnnotations;

namespace employee_management_backend.Models.DTOs.EmployeeDTO
{
    public class CreateEmployeeRequestDTO
    {
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Date of birth is required.")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }


        [Required(ErrorMessage = "Address is required.")]
        [StringLength(250, ErrorMessage = "Address cannot be longer than 250 characters.")]
        public string Address { get; set; }


        [Required(ErrorMessage = "Basic salary is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Basic salary must be a positive value.")]
        public decimal BasicSalary { get; set; }


        [Required(ErrorMessage = "Department is required.")]
        [StringLength(100, ErrorMessage = "Department cannot be longer than 100 characters.")]
        public string Department { get; set; }


        [Required(ErrorMessage = "Gender is required.")]
        [StringLength(20, ErrorMessage = "Gender cannot be longer than 20 characters.")]
        public string Gender { get; set; }
    }
}