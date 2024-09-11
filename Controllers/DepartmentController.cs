using employee_management_backend.Repositories.Departments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace employee_management_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartments() 
        {
            try
            {
                var allDepartments = await _departmentRepository.GetAllDepartmentsAsync();

                if (allDepartments.StatusCode == 500) 
                {
                    return StatusCode(500, allDepartments);
                }

                return Ok(allDepartments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred. Please try again later.");
            }
        }
    }
}
