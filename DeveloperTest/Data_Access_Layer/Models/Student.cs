using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;


namespace Data_Access_Layer.Models
{

    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        public byte[] Image { get; set; }

        [Required]
        public int ClassRollNumber { get; set; }

        // Foreign Key for Class
        [ForeignKey("Class")]
        public int ClassId { get; set; }

        public Class Class { get; set; }
    }
}
