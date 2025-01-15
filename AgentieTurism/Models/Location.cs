using System.ComponentModel.DataAnnotations;

namespace AgentieTurism.Models
{
    public class Location
    {
        public int ID { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        [Display(Name = "Location")]
        public string? FullLocation
        {
            get
            {
                return City + ", " + Country;
            }
        }
        public ICollection<Vacation>? Vacations { get; set; }
}
}
