namespace AgentieTurism.Models
{
    public class Location
    {
        public int ID { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public ICollection<Vacation>? Vacations { get; set; }
}
}
