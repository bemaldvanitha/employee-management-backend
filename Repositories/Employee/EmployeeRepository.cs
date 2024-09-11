using employee_management_backend.Data;
using employee_management_backend.Models.Domains;
using employee_management_backend.Models.DTOs.EmployeeDTO;
using Microsoft.EntityFrameworkCore;

namespace employee_management_backend.Repositories.Employee
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _employeeDbContext;

        public EmployeeRepository(EmployeeDbContext employeeDbContext)
        {
            this._employeeDbContext = employeeDbContext;
        }

        public async Task<EmployeeResponseDTO> CreateEmployee(CreateEmployeeRequestDTO requestDTO)
        {
            try
            {
                var gender = await _employeeDbContext.GenderTypes.FirstOrDefaultAsync(x  => x.Gender == requestDTO.Gender);

                if (gender == null) 
                {
                    gender = new GenderType 
                    { 
                        Gender = requestDTO.Gender 
                    };

                    await _employeeDbContext.GenderTypes.AddAsync(gender);
                    await _employeeDbContext.SaveChangesAsync();
                }

                var department = await _employeeDbContext.Departments.FirstOrDefaultAsync(x => x.DepartmentName == requestDTO.Department);

                if (department == null)
                {
                    department = new Department
                    {
                        DepartmentName = requestDTO.Department
                    };
                    
                    await _employeeDbContext.Departments.AddAsync(department);
                    await _employeeDbContext.SaveChangesAsync();
                }

                var employee = new Models.Domains.Employee
                {
                    Address = requestDTO.Address,
                    BasicSalary = requestDTO.BasicSalary,
                    DateOfBirth = requestDTO.DateOfBirth,
                    FirstName = requestDTO.FirstName,
                    LastName = requestDTO.LastName,
                    DepartmentId = department.Id,
                    GenderTypeId = gender.Id
                };

                await _employeeDbContext.Employees.AddAsync(employee);
                await _employeeDbContext.SaveChangesAsync();
                

                return new EmployeeResponseDTO
                {
                    Message = "New Employee Created",
                    StatusCode = 201
                };
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);

                return new EmployeeResponseDTO
                {
                    Message = "Server Error",
                    StatusCode = 500,
                };
            }
        }

        public async Task<EmployeeResponseDTO> DeleteEmployee(Guid deleteEmployeeId)
        {
            try
            {
                var employee = await _employeeDbContext.Employees.FirstOrDefaultAsync(x => x.Id == deleteEmployeeId);

                if (employee == null)
                {
                    return new EmployeeResponseDTO
                    {
                        Message = "Employee Not Found",
                        StatusCode = 404
                    };
                }

                _employeeDbContext.Employees.Remove(employee);
                await _employeeDbContext.SaveChangesAsync();

                return new EmployeeResponseDTO
                {
                    Message = "Employee Deletion Successfull",
                    StatusCode = 200
                };
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);

                return new EmployeeResponseDTO
                {
                    Message = "Server Error",
                    StatusCode = 500,
                };
            }
        }

        public async Task<GetAllEmployeeResponseDTO> GetAllEmployee(int page, int size)
        {
            try
            {
                int skip = (page - 1) * size;
                var employess = await _employeeDbContext.Employees.Include(x => x.GenderType).Include(x => x.Department).Skip(skip)
                    .Take(size).ToListAsync();

                var itemCount = await _employeeDbContext.Employees.CountAsync();
                var pageCount = (int)Math.Ceiling(itemCount / (double)size);

                List<EmployeeObj> employees = new List<EmployeeObj>();

                foreach (var employee in employess) 
                {
                    EmployeeObj employeeObj = new EmployeeObj
                    {
                        Id = employee.Id,
                        Department = employee.Department.DepartmentName,
                        Address = employee.Address,
                        BasicSalary = employee.BasicSalary,
                        DateOfBirth = employee.DateOfBirth,
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        Gender = employee.GenderType.Gender
                    }; 

                    employees.Add(employeeObj);
                }

                return new GetAllEmployeeResponseDTO
                {
                    Employees = employees,
                    Message = "All Employee Records Fetched",
                    StatusCode = 200,
                    PageCount = pageCount
                };
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new GetAllEmployeeResponseDTO
                {
                    Message = "Server Error",
                    StatusCode = 500,
                };
            }
        }

        public async Task<GetSingleEmployeeResponseDTO> GetSingleEmployee(Guid employeeId)
        {
            try
            {
                var employee = await _employeeDbContext.Employees.Include(x => x.Department).Include(x => x.GenderType)
                    .FirstOrDefaultAsync(x => x.Id == employeeId);

                if (employee == null)
                {
                    return new GetSingleEmployeeResponseDTO
                    {
                        Message = "Employee Not Found",
                        StatusCode = 404
                    };
                }

                var employeeObj = new EmployeeObj
                {
                    Address = employee.Address,
                    BasicSalary = employee.BasicSalary,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Gender = employee.GenderType.Gender,
                    Department = employee.Department.DepartmentName,
                    DateOfBirth = employee.DateOfBirth,
                    Id = employee.Id
                };

                return new GetSingleEmployeeResponseDTO
                {
                    employee = employeeObj,
                    Message = "Employee record fetched",
                    StatusCode = 200
                };
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"{ex.Message}");

                return new GetSingleEmployeeResponseDTO
                {
                    Message = "Server Error",
                    StatusCode = 500,
                };
            }
        }

        public async Task<EmployeeResponseDTO> UpdateEmployee(UpdateEmployeeRequestDTO requestDTO, Guid updateEmployeeId)
        {
            try
            {
                var employee = await _employeeDbContext.Employees.FirstOrDefaultAsync(x => x.Id == updateEmployeeId);

                if (employee == null)
                {
                    return new EmployeeResponseDTO
                    {
                        Message = "Employee Not Found",
                        StatusCode = 404
                    };
                }

                var gender = await _employeeDbContext.GenderTypes.FirstOrDefaultAsync(x => x.Gender == requestDTO.Gender);

                if (gender == null)
                {
                    gender = new GenderType
                    {
                        Gender = requestDTO.Gender
                    };

                    await _employeeDbContext.GenderTypes.AddAsync(gender);
                    await _employeeDbContext.SaveChangesAsync();
                }

                var department = await _employeeDbContext.Departments.FirstOrDefaultAsync(x => x.DepartmentName == requestDTO.Department);

                if (department == null)
                {
                    department = new Department
                    {
                        DepartmentName = requestDTO.Department
                    };

                    await _employeeDbContext.Departments.AddAsync(department);
                    await _employeeDbContext.SaveChangesAsync();
                }

                employee.FirstName = requestDTO.FirstName;
                employee.LastName = requestDTO.LastName;
                employee.DepartmentId = department.Id;
                employee.BasicSalary = requestDTO.BasicSalary;
                employee.DateOfBirth = requestDTO.DateOfBirth;
                employee.GenderTypeId = gender.Id;
                employee.Address = requestDTO.Address;

                await _employeeDbContext.SaveChangesAsync();

                return new EmployeeResponseDTO
                {
                    Message = "Employee Updated Successfully",
                    StatusCode = 200
                };
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);

                return new EmployeeResponseDTO
                {
                    Message = "Server Error",
                    StatusCode = 500,
                };
            }
        }
    }
}
