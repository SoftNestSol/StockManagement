using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockManagement.Server.ContextModels;
using StockManagement.Server.DTOs;
using StockManagement.Server.Entities;
using StockManagement.Server.Repositories;

[ApiController]
[Route("api/[controller]")] // Changed route
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly StockContext _stockContext;
    private readonly IMapper _autoMapper;
    public EmployeeController(IEmployeeRepository employeeRepository, StockContext stockContext, IMapper autoMapper)
    {
        _stockContext = stockContext;
        _employeeRepository = employeeRepository;
        _autoMapper = autoMapper;
    }

    [HttpGet]
    public async Task<List<EmployeeDTO>> GetEmployees() 
    {
        var employees = await _employeeRepository.GetEmployeesAsync();
        var employeesDTO= _autoMapper.Map<List<EmployeeDTO>>(employees);
           
        return employeesDTO;
    }
}
