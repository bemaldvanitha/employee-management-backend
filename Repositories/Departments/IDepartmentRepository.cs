using employee_management_backend.Models.DTOs.DepartmentDTO;

namespace employee_management_backend.Repositories.Departments
{
    public interface IDepartmentRepository
    {
        public Task<GetAllDepartmentsDTO> GetAllDepartmentsAsync();
    }
}
