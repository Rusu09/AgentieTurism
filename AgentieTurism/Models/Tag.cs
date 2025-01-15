namespace AgentieTurism.Models
{
    public class Tag
    {
        public int ID { get; set; }
        public string TagName { get; set; }
        public ICollection<VacationTag>? VacationTags { get; set; }
    }
}
