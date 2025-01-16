using System.ComponentModel.DataAnnotations;

namespace AgentieTurism.Models
{
    public class Tag
    {
        public int ID { get; set; }
        [Display(Name = "Tag Name")]
        public string TagName { get; set; }
        public ICollection<VacationTag>? VacationTags { get; set; }
    }
}
