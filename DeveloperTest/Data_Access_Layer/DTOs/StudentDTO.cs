using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.DTOs
{
    public class StudentDTO
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int ClassRollNumber { get; set; }
        public string ClassName { get; set; }

        // This will be either a URL or base64 string depending on your setup
        public string Image { get; set; }
    }


}
