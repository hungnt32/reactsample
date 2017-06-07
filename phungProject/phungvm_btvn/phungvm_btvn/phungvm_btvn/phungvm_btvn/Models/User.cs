using System.ComponentModel.DataAnnotations;

namespace phungvm_btvn.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please enter Username")]
        public string Account { get; set; }
        public string Fullname { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter Password")]
        public string Password { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter Email")]
        public string Email { get; set; }

        public string Phone { get; set; }

        [Range(1, 100)]
        public int Age { get; set; }

        public virtual Department Department { get; set; }
    }
}