using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AgentieTurism.Models
{
    public class User
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z]+[a-z\s]*$", ErrorMessage = "First name must start with a capital letter!")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Last name must have at least 3 characters and at most 30!")]
        public string? FirstName { get; set; }
        [RegularExpression(@"^[A-Z]+[a-z\s]*$", ErrorMessage = "Last name must start with a capital letter!")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Last name must have at least 3 characters and at most 30!")]
        public string? LastName { get; set; }
        public string Email { get; set; }
        [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Phone number must be in one of the following formats: '0722-123-123' / '0722.123.123' / '0722 123 123'")]
        public string? Phone { get; set; }
        [Display(Name = "Full Name")]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public ICollection<Booking>? Bookings { get; set; }
        public ICollection<Review>? Reviews { get; set; }
    }
}
