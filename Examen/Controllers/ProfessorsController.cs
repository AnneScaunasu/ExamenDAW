using Examen.Data;
using Examen.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Examen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorsController : ControllerBase
    {
        private readonly ApplicationDbContext _ApplicationDbContext;
        public ProfessorsController(ApplicationDbContext applicationDbContext)
        {
            _ApplicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public IActionResult GetProfessors()
        {
            var professors = _ApplicationDbContext.Professors.ToList();
            return Ok(professors);
        }

        [HttpPost]
        public IActionResult AddProfessor([FromBody] Professor professor)
        {
            _ApplicationDbContext.Professors.Add(professor);
            _ApplicationDbContext.SaveChanges();
            return Ok(professor);
        }

        [HttpPost("{professorId}/assignSubject/{subjectId}")]
        public IActionResult AssignSubjectToProfessor(int professorId, int subjectId)
        {
            var professor = _ApplicationDbContext.Professors.Find(professorId);
            var subject = _ApplicationDbContext.Subjects.Find(subjectId);

            if (professor == null || subject == null)
            {
                return NotFound("Profesorul sau materia nu există.");
            }

            var professorSubject = new ProfessorSubject
            {
                ProfessorId = professorId,
                SubjectId = subjectId
            };

            _ApplicationDbContext.ProfessorSubjects.Add(professorSubject);
            _ApplicationDbContext.SaveChanges();

            return Ok("Materia a fost asignată cu succes profesorului.");
        }
    }
}
