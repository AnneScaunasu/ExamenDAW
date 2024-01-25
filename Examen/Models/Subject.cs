using System;
using Examen.Models.Base;

namespace Examen.Models
{
    public class Subject : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<ProfessorSubject> ProfessorSubjects { get; set; }
    }
}
