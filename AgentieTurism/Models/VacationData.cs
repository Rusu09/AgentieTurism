namespace AgentieTurism.Models
{
    public class VacationData
    {
        public IEnumerable<Vacation> Vacations { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public IEnumerable<VacationTag> VacationTags { get; set; }
    }
}
