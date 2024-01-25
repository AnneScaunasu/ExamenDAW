using System;
using Examen.Models.Base;

namespace Examen.Models
{
	public class Professor
	{
        public string Name { get; set; }
        public Role Role { get; set; }

        public ICollection<ProfessorSubject> ProfessorSubjects { get; set; }
    }
}
