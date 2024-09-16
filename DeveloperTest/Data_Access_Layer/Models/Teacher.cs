using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace Data_Access_Layer.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Sex { get; set; }

        public byte[] Image { get; set; }

        // Many-to-many: Teacher can teach multiple subjects and classes
        public ICollection<TeacherSubjectClass> TeacherSubjectClasses { get; set; }
    }
}
