using employee_management_backend.Models.DTOs.EmployeeDTO;

namespace employee_management_backend.Repositories.Employee
{
    public interface IEmployeeRepository
    {
        public Task<EmployeeResponseDTO> CreateEmployee(CreateEmployeeRequestDTO requestDTO);

        public Task<EmployeeResponseDTO> UpdateEmployee(UpdateEmployeeRequestDTO requestDTO, Guid id);

        public Task<EmployeeResponseDTO> DeleteEmployee(Guid id);

        public Task<GetAllEmployeeResponseDTO> GetAllEmployee(int page, int size);

        public Task<GetSingleEmployeeResponseDTO> GetSingleEmployee(Guid id);
    }
}
