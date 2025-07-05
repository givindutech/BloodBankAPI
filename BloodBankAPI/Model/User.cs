using System.ComponentModel.DataAnnotations;

namespace BloodBankAPI.Model
{
    public class User
    {
        [Key]
        public int BloodBankID { get; set; }
        public string? BloodBankName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? ContactNumber { get; set; }
        public string? UserId { get; set; }
        public string? Password { get; set; }
        
    }
}
