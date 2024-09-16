using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Data_Access_Layer.DTOs
{
    public class CreateStudentDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public int ClassRollNumber { get; set; }

        public IFormFile Image { get; set; }

        [Required]
        public int ClassId { get; set; }
    }

}
