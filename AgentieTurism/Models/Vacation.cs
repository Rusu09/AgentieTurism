﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AgentieTurism.Models
{
    public class Vacation
    {
        public int ID { get; set; }
        [Display(Name = "Vacation")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Title must have at least 3 characters and at most 200!")]
        public string Title { get; set; }
        public string? Description { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        [Range(1, 10000)]
        public decimal? Price { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Departure")]
        public DateTime? AvailableFrom { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Return")]
        public DateTime? AvailableTo { get; set; }
        [Display(Name = "Length of Stay")]
        public int? DurationDays
        {
            get
            {
                if (AvailableFrom.HasValue && AvailableTo.HasValue)
                {
                    return (AvailableTo.Value - AvailableFrom.Value).Days;
                }
                return null;
            }
        }

        public int? LocationID { get; set; }
        public Location? Location { get; set; }
        [Display(Name = "Tags")]
        public ICollection<VacationTag>? VacationTags { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
