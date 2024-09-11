using employee_management_backend.Data;
using employee_management_backend.Models.DTOs.DepartmentDTO;
using employee_management_backend.Models.DTOs.EmployeeDTO;
using Microsoft.EntityFrameworkCore;

namespace employee_management_backend.Repositories.Departments
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmployeeDbContext _employeeDbContext;

        public DepartmentRepository(EmployeeDbContext employeeDbContext)
        {
            this._employeeDbContext = employeeDbContext;
        }

        public async Task<GetAllDepartmentsDTO> GetAllDepartmentsAsync()
        {
            try
            {
                var allDepartments = await _employeeDbContext.Departments.Select(d => d.DepartmentName).ToListAsync();

                return new GetAllDepartmentsDTO 
                {
                    Departments = allDepartments,
                    Message = "All Departments Fetched",
                    StatusCode = 200
                };
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new GetAllDepartmentsDTO
                {
                    Message = "Server Error",
                    StatusCode = 500,
                };
            }
        }
    }
}
