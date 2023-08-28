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
        public IActionResult Add([FromForm] EmployeeViewModel employeeViewModel)
        {
            var filePath = Path.Combine("Storage", employeeViewModel.Photo.FileName);
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            employeeViewModel.Photo.CopyTo(fileStream);

            var employ = new Employee(employeeViewModel.Name, employeeViewModel.Age, filePath);
            _employeeRepository.Add(employ);

            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var employss = _employeeRepository.Get();
            return Ok(employss);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult FindById(int id)
        {
            var employee = _employeeRepository.FindById(id);
            return Ok(employee);
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _employeeRepository.Delete(id);
            return Ok();
        }



        [HttpPost]
        [Route("{id}/dowload")]
        public IActionResult DowloadPhoto(int id)
        {
            var employee = _employeeRepository.FindById(id);
            var dataBytes = System.IO.File.ReadAllBytes(employee.photo);

            return File(dataBytes, "image/png");
        }
    
    }

}
