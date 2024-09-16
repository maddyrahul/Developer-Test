using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.DTOs
{
    public class ClassWithStudentsDTO
    {
        public string ClassName { get; set; }
        public List<StudentDTO> Students { get; set; }
    }

}
