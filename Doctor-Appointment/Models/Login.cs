using System.ComponentModel.DataAnnotations;

namespace Doctor_Appointment.Models
{
    public class Login
    {
        [Key] // Birincil anahtar olduğunu belirtin
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; } // Şifreyi hash'li olarak saklamanız önerilir.
    }
}
