using Examen.Data;
using Examen.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Examen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ApplicationDbContext _ApplicationDbContext;
        public SubjectsController(ApplicationDbContext applicationDbContext) {
            _ApplicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public IActionResult GetSubjects()
        {
            var subjects = _ApplicationDbContext.Subjects.ToList();
            return Ok(subjects);
        }

        [HttpPost]
        public IActionResult AddSubject([FromBody] Subject subject)
        {
            _ApplicationDbContext.Subjects.Add(subject);
            _ApplicationDbContext.SaveChanges();
            return Ok(subject);
        }
    }
}
