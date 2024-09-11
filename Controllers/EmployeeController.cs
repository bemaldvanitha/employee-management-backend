using employee_management_backend.Models.DTOs.EmployeeDTO;
using employee_management_backend.Repositories.Employee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace employee_management_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees([FromQuery] int page = 1, [FromQuery] int size = 10)
        {
            try
            {
                GetAllEmployeeResponseDTO getAllEmployeeResponse = await _employeeRepository.GetAllEmployee(page, size);

                if(getAllEmployeeResponse.StatusCode == 500)
                {
                    return StatusCode(500, getAllEmployeeResponse);
                }

                return Ok(getAllEmployeeResponse);
            }catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred. Please try again later.");
            };
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeRequestDTO requestDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                EmployeeResponseDTO employeeResponse = await _employeeRepository.CreateEmployee(requestDTO);

                if (employeeResponse.StatusCode == 500) 
                {
                    return StatusCode(500, employeeResponse);
                }

                return Ok(employeeResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred. Please try again later.");
            }
        }

        [HttpPatch]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateEmployeeRecord([FromBody] UpdateEmployeeRequestDTO requestDTO, [FromRoute] string id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                EmployeeResponseDTO employeeResponse = await _employeeRepository.UpdateEmployee(requestDTO, Guid.Parse(id));

                if (employeeResponse.StatusCode == 500) 
                {
                    return StatusCode(500, employeeResponse);
                }

                if (employeeResponse.StatusCode == 404)
                {
                    return NotFound(employeeResponse);
                }

                return Ok(employeeResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred. Please try again later.");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] string id)
        {
            try
            {
                EmployeeResponseDTO employeeResponse = await _employeeRepository.DeleteEmployee(Guid.Parse(id));

                if (employeeResponse.StatusCode == 500)
                {
                    return StatusCode(500, employeeResponse);
                }

                if (employeeResponse.StatusCode == 404)
                {
                    return NotFound(employeeResponse);
                }

                return Ok(employeeResponse);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred. Please try again later.");
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetSingleemployee([FromRoute] string id)
        {
            try
            {
                GetSingleEmployeeResponseDTO getSingleEmployeeResponse = await _employeeRepository.GetSingleEmployee(Guid.Parse(id));

                if(getSingleEmployeeResponse.StatusCode == 500)
                {
                    return StatusCode(500, getSingleEmployeeResponse);
                }

                if(getSingleEmployeeResponse.StatusCode == 404)
                {
                    return NotFound(getSingleEmployeeResponse);
                }

                return Ok(getSingleEmployeeResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred. Please try again later.");
            }
        }
    }
}
