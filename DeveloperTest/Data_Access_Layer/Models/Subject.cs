
using System.ComponentModel.DataAnnotations;


namespace Data_Access_Layer.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Language { get; set; }

        // Many-to-many: Subject taught by teachers in multiple classes
        public ICollection<TeacherSubjectClass> TeacherSubjectClasses { get; set; }
    }
}
