namespace employee_management_backend.Models.DTOs.EmployeeDTO
{
    public class GetAllEmployeeResponseDTO
    {
        public string Message { get; set; }

        public int StatusCode { get; set; }

        public List<EmployeeObj>? Employees { get; set; }

        public int? PageCount { get; set; }
    }

    public class EmployeeObj
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public string Department { get; set; }

        public Decimal BasicSalary { get; set; }

        public string Gender { get; set; }
    }
}
