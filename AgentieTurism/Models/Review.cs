using System.ComponentModel.DataAnnotations;

namespace AgentieTurism.Models
{
    public class Review
    {
        public int ID { get; set; }
        public int? VacationID { get; set; }
        public Vacation? Vacation { get; set; }
        public int? UserID { get; set; }
        public User? User { get; set; }
        public string? Comment { get; set; }
        public int Rating { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
