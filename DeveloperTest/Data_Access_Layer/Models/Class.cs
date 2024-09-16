using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Models
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }

        [Required]
        public string ClassName { get; set; }

        public ICollection<Student> Students { get; set; }
        public ICollection<TeacherSubjectClass> TeacherSubjectClasses { get; set; }
    }
}
