using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesWebAPI.Models;
using SalesWebAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        //construct dependancy injection for postrepository
        IEmployee employeeRepository;
        SalesContext context;
        public EmployeeController(IEmployee _p)
        {
            employeeRepository = _p;

        }

        #region
        //Get all employee
        [HttpGet]
        [Route("GetEmployee")]
        public async Task<ActionResult<IEnumerable<EmployeeRegistration>>> GetEmployee()
        {


            try
            {

                var employees = await employeeRepository.GetEmployee();

                if (employees == null)
                {
                    return NotFound();
                }
                return Ok(employees);
            }
            catch (Exception)
            {
                return BadRequest();
            }


        }
        #endregion

        #region Add a new employee
        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeRegistration model)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var empId = await employeeRepository.AddEmployee(model);
                    if (empId > 0)
                    {
                        return Ok(empId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region Update Employee
        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeRegistration model)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await employeeRepository.UpdateEmployee(model);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion
    }
}
