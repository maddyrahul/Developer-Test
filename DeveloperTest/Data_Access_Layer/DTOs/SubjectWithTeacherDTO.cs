using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.DTOs
{
    public class SubjectWithTeacherDTO
    {
        public string SubjectName { get; set; }
        public string Language { get; set; }
        public string ClassName { get; set; }
        public string TeacherName { get; set; }
    }

}
