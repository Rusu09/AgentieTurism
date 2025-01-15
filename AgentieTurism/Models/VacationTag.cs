namespace AgentieTurism.Models
{
    public class VacationTag
    {
        public int ID { get; set; }
        public int VacationID { get; set; }
        public Vacation? Vacation { get; set; }
        public int TagID { get; set; }
        public Tag? Tag { get; set; }
    }
}
