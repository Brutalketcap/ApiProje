using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EployeeTaskController : ControllerBase
    {
        private readonly ApiContext _context;

        [HttpGet]
        public IActionResult EployeeTaskList()
        {
            var values = _context.EmployeeTasks.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateEployeeTask(EmployeeTask employeeTask)
        {
            var value = _context.EmployeeTasks.Add(employeeTask);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteEployeeTask(int id)
        {
            var vaule = _context.EmployeeTasks.Find(id);
            _context.EmployeeTasks.Remove(vaule);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı");
        }

        [HttpPut]
        public IActionResult EployeeTaskUpdate(EmployeeTask employeeTask)
        {
            _context.EmployeeTasks.Update(employeeTask);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi Başarılı");
        }
    }
}
