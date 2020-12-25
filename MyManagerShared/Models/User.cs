// Class the defines the properties of a User

using System;
using System.ComponentModel.DataAnnotations;

namespace MyManagerShared.Models
{
    public class User
    {
        [Key]
        public int userID { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int BankNumber { get; set; }

        public double BankBalance { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Joining Date")]
        public DateTime? DateJoined { get; set; }
    }
}
