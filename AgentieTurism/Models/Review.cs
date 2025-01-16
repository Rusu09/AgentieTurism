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
        
        [StringLength(1000, MinimumLength = 3, ErrorMessage = "Comment must have at least 3 characters and at most 1000!")]
        public string? Comment { get; set; }
        [Range(1, 10)]
        public int Rating { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Review Date")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
