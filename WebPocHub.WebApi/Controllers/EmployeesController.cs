using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebPocHub.dal;
using WebPocHub.Models;

namespace WebPocHub.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ICommonRepository<Employee> _employeeRepository;
        public EmployeesController(ICommonRepository<Employee> repository)
        {
            _employeeRepository = repository;
        }
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _employeeRepository.GetAll();
        }
        [HttpGet("{id:int}")]
        public Employee GetDetails(int id)
        {
            return _employeeRepository.GetDetails(id);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult Create(Employee employee)
        {
            _employeeRepository.Insert(employee);

            var result = _employeeRepository.SaveChanges();

            if (result > 0)
            {
                //actionfiame The name of the action to use for generating the URL URL

                //routevalues The route data to use for generating the //value The content value to format in the entity body

                return CreatedAtAction("GetDetails", new { id = employee.EmployeeId }, employee);

            }
            return BadRequest();

        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult Update(Employee employee)
        {
            _employeeRepository.Update(employee);
            var result = _employeeRepository.SaveChanges(); if (result > 0)
            {
                return NoContent();
            }
            return BadRequest();

        }
        [HttpDelete("{id}")]

        [ProducesResponseType(StatusCodes.Status204NoContent)]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Employee> Delete(int id)
        {
            var employee = _employeeRepository.GetDetails(id);

            if (employee == null)

            {
                return NotFound();
            }
           else
            {
                _employeeRepository.Delete(employee);
                _employeeRepository.SaveChanges();
                return NoContent();
            }
        }
    }
}
