<<<<<<< HEAD
﻿using FinanceManagement.DATA.Models;
using FinanceManagement.DATA.Repositories;
using FinanceManagement.DOMAIN.Repository;
=======
﻿using FinanceManagement.CORE.Entities;
using FinanceManagement.SERVICES.Interface;
>>>>>>> origin/Roles,Projects,Roles,TimeSheetControllersAdded
using Microsoft.AspNetCore.Mvc;

namespace FinanceManagement.API.Controllers
{
<<<<<<< HEAD
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Employee>> Get()
        {
            return await _employeeRepository.GetAllEmployeesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Get(string id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return employee;
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> Post([FromBody] Employee employee)
        {
            await _employeeRepository.AddEmployeeAsync(employee);
            return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            await _employeeRepository.UpdateEmployeeAsync(employee);
=======
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees() =>
        Ok(await _employeeService.GetAllEmployeesAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(Guid id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        [HttpGet("{id}/team")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetTeamMembers(Guid id) =>
            Ok(await _employeeService.GetTeamMembersAsync(id));

        [HttpGet("{id}/projects")]
        public async Task<ActionResult<IEnumerable<EmployeeProject>>> GetEmployeeProjects(Guid id) =>
            Ok(await _employeeService.GetEmployeeProjectsAsync(id));

        [HttpPost]
        public async Task<ActionResult> PostEmployee(Employee employee)
        {
            await _employeeService.AddEmployeeAsync(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(Guid id, Employee employee)
        {
            if (id != employee.Id) return BadRequest();
            await _employeeService.UpdateEmployeeAsync(employee);
>>>>>>> origin/Roles,Projects,Roles,TimeSheetControllersAdded
            return NoContent();
        }

        [HttpDelete("{id}")]
<<<<<<< HEAD
        public async Task<IActionResult> Delete(string id)
        {
            /* await _employeeRepository.DeleteEmployeeAsync(id);
             return NoContent();*/
            if (!int.TryParse(id, out int employeeId))
            {
                return BadRequest("Invalid employee ID format. Employee ID must be an integer.");
            }

            try
            {
                await _employeeRepository.DeleteEmployeeAsync(employeeId);
                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
=======
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return NoContent();
>>>>>>> origin/Roles,Projects,Roles,TimeSheetControllersAdded
        }
    }
}
