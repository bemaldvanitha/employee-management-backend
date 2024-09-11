namespace employee_management_backend.Models.DTOs.EmployeeDTO
{
    public class GetSingleEmployeeResponseDTO
    {
        public string Message { get; set; }

        public int StatusCode { get; set; }

        public EmployeeObj? employee { get; set; }

    }
}
