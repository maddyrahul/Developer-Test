using Data_Access_Layer.Models;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<TeacherSubjectClass> TeacherSubjectClasses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Many-to-many relationships
            modelBuilder.Entity<TeacherSubjectClass>()
                .HasKey(tsc => new { tsc.TeacherId, tsc.SubjectId, tsc.ClassId });

            modelBuilder.Entity<TeacherSubjectClass>()
                .HasOne(tsc => tsc.Teacher)
                .WithMany(t => t.TeacherSubjectClasses)
                .HasForeignKey(tsc => tsc.TeacherId);

            modelBuilder.Entity<TeacherSubjectClass>()
                .HasOne(tsc => tsc.Subject)
                .WithMany(s => s.TeacherSubjectClasses)
                .HasForeignKey(tsc => tsc.SubjectId);

            modelBuilder.Entity<TeacherSubjectClass>()
                .HasOne(tsc => tsc.Class)
                .WithMany(c => c.TeacherSubjectClasses)
                .HasForeignKey(tsc => tsc.ClassId);

            // Seed data for Class table (Classes 1 to 12)
            modelBuilder.Entity<Class>().HasData(
                new Class { ClassId = 1, ClassName = "Class 1" },
                new Class { ClassId = 2, ClassName = "Class 2" },
                new Class { ClassId = 3, ClassName = "Class 3" },
                new Class { ClassId = 4, ClassName = "Class 4" },
                new Class { ClassId = 5, ClassName = "Class 5" },
                new Class { ClassId = 6, ClassName = "Class 6" },
                new Class { ClassId = 7, ClassName = "Class 7" },
                new Class { ClassId = 8, ClassName = "Class 8" },
                new Class { ClassId = 9, ClassName = "Class 9" },
                new Class { ClassId = 10, ClassName = "Class 10" },
                new Class { ClassId = 11, ClassName = "Class 11" },
                new Class { ClassId = 12, ClassName = "Class 12" }
            );
        }
    }
}
