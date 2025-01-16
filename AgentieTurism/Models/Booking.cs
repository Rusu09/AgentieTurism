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
        public int NrOfPeople { get; set; }

        public string Status { get; set; } = "Pending";
    }
}
