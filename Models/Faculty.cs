using System.ComponentModel.DataAnnotations;

namespace DemoProject.Models
{
    public class Faculty:Base
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; } = string.Empty;


        [Required]
        [MaxLength(50)]
        public string Contact { get; set; } = string.Empty;


    }
}
