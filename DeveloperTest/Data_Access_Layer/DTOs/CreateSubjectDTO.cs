using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.DTOs
{
    public class CreateSubjectDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Language { get; set; }

        [Required]
        public int ClassId { get; set; }

        [Required]
        public int TeacherId { get; set; }
    }


}
