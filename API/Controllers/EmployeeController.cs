using API.Models;
using API.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpPost]
        public IActionResult Add(EmployeeViewModel employeeViewModel)
        {
            var employ = new Employee(employeeViewModel.Name, employeeViewModel.Age, null);
            _employeeRepository.Add(employ);

            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var employss = _employeeRepository.Get();
            return Ok(employss);
        }
    
    }

}
