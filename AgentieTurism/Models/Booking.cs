using System.ComponentModel.DataAnnotations;

namespace AgentieTurism.Models
{
    public class Booking
    {
        public int ID { get; set; }
        public int? VacationID { get; set; }
        public Vacation? Vacation { get; set; }

        public int UserID { get; set; }
        public User? User { get; set; }

        [DataType(DataType.Date)]
        public DateTime BookingDate { get; set; } = DateTime.Now;
        [Range(1, 12)]
        public int NrOfPeople { get; set; }
        
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Status must have at least 3 characters and at most 30!")]
        public string Status { get; set; } = "Pending";
    }
}
