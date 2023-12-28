using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockManagement.Server.ContextModels;
using StockManagement.Server.DTOs;
using StockManagement.Server.Entities;
using StockManagement.Server.Repositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly StockContext _stockContext;
    private readonly IMapper _autoMapper;
    private readonly UserManager<ApplicationUser> _userManager;
    public EmployeeController(IEmployeeRepository employeeRepository, StockContext stockContext, IMapper autoMapper, UserManager<ApplicationUser> userManager)
    {
        _stockContext = stockContext;
        _employeeRepository = employeeRepository;
        _autoMapper = autoMapper;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<List<EmployeeDTO>> GetEmployees()
    {
        var employees = await _employeeRepository.GetEmployeesAsync();
        var employeesDTO = _autoMapper.Map<List<EmployeeDTO>>(employees);
        return employeesDTO;
    }

    [HttpPost]
    public async Task<ActionResult<EmployeeDTO>> AddEmployee([FromBody] EmployeeDTO employee)
    {
        // Create new ApplicationUser
        var user = new ApplicationUser
        {
            UserName = employee.Email,
            Email = employee.Email,
        };

        // Attempt to create the user
        var createUserResult = await _userManager.CreateAsync(user, employee.Password);
        if (!createUserResult.Succeeded)
        {
            return BadRequest(createUserResult.Errors);
        }

        // Save changes to ensure UserId is committed
        await _stockContext.SaveChangesAsync();

        // Check if the role exists
        /*var roleExists = await _userManager.RoleExistsAsync("Admin");
        if (!roleExists)
        {
            // Handle the case where the role doesn't exist
            // This could involve creating the role or returning an error
        }*/

        // Attempt to assign the role
        var addToRoleResult = await _userManager.AddToRoleAsync(user, "Admin");
        if (!addToRoleResult.Succeeded)
        {
            return BadRequest(addToRoleResult.Errors);
        }

        // Map DTO to Employee entity
        var employeeEntity = _autoMapper.Map<Employee>(employee);
        employeeEntity.ApplicationUserId = user.Id;

        // Create employee record
        var createdEmployee = await _employeeRepository.AddEmployeeAsync(employeeEntity);
        var createdEmployeeDTO = _autoMapper.Map<EmployeeDTO>(createdEmployee);

        return Ok(createdEmployeeDTO);
    }

    [HttpDelete("{id}")]
    public async Task DeleteEmployee(int id)
    {
        await _employeeRepository.DeleteEmployeeAsync(id);
        return;
    }

    [HttpGet("{id}")]
    public async Task<EmployeeDTO> GetEmployee(int id)
    {
        var Employee = await _employeeRepository.GetEmployeeAsync(id);
        var EmployeeDTO = _autoMapper.Map<EmployeeDTO>(Employee);
        return EmployeeDTO;
    }

    [HttpPut("{id}")]
    public async Task<EmployeeDTO> UpdateEmployee(int id)
    {
        var Employee = await _employeeRepository.GetEmployeeAsync(id);
        var EmployeeDTO = _autoMapper.Map<EmployeeDTO>(Employee);
        return EmployeeDTO;
    }

    [HttpGet("lastid")]
public async Task<ActionResult<int>> GetLastEmployeeId()
{
    var lastEmployee = await _stockContext.Employees.OrderByDescending(e => e.EmployeeId).FirstOrDefaultAsync();
    if (lastEmployee == null)
    {
        return 0; 
    }
    return lastEmployee.EmployeeId;
}


}
