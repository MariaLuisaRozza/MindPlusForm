using Microsoft.AspNetCore.Mvc;
using MindPlusForm.Contracts.Repository;
using MindPlusForm.DTO;
using MindPlusForm.Entity;
using MindPlusForm.Repository;

namespace MindPlusForm.Controllers
{
    [ApiController]
    [Route("employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _employeeRepository.Get());
        }

        [HttpPost]
        public async Task<IActionResult> Add(EmployeeDTO employee)
        {
            await _employeeRepository.Add(employee);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(EmployeeEntity employee)
        {
            await _employeeRepository.Update(employee);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeRepository.Delete(id);
            return Ok();
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _employeeRepository.GetById(id));
        }

    }
}
