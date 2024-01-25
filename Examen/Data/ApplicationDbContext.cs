using Examen.Models;
using Microsoft.EntityFrameworkCore;

namespace Examen.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<ProfessorSubject> ProfessorSubjects { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<ProfessorSubject>()
            .HasKey(ps => new { ps.ProfessorId, ps.SubjectId });

            modelBuilder.Entity<ProfessorSubject>()
                .HasOne(ps => ps.Professor)
                .WithMany(p => p.ProfessorSubjects)
                .HasForeignKey(ps => ps.ProfessorId);

            modelBuilder.Entity<ProfessorSubject>()
                .HasOne(ps => ps.Subject)
                .WithMany(s => s.ProfessorSubjects)
                .HasForeignKey(ps => ps.SubjectId);
        }
    }
}
