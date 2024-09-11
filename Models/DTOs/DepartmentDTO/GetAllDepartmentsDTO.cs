namespace employee_management_backend.Models.DTOs.DepartmentDTO
{
    public class GetAllDepartmentsDTO
    {
        public string Message { get; set; }

        public int StatusCode { get; set; }

        public List<String>? Departments { get; set; }
    }
}
