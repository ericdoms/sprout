using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SproutSolution.Core.Model;
using SproutSolution.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SproutSolution.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IEnumerable<Employee>> Get()
        {
            try
            {
                return await _employeeService.GetEmployees();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<Employee> GetEmployeeById(Guid id)
        {
            try
            {
                return await _employeeService.GetEmployeeById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        // GET api/<EmployeeController>/GetSalary
        [HttpPost("GetSalary")]
        public async Task<Decimal> GetSalary([FromBody] Employee employee)
        {
            try
            {
                return await _employeeService.GetSalary(employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public void Post([FromBody] Employee employee)
        {
            try
            {
                _employeeService.CreateEmployee(employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
