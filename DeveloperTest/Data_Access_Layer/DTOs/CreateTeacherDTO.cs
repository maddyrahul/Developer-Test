using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace Data_Access_Layer.DTOs
{
    public class CreateTeacherDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Sex { get; set; }

        public IFormFile Image { get; set; }
    }

}
