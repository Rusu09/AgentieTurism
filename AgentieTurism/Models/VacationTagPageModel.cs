using Microsoft.AspNetCore.Mvc.RazorPages;
using AgentieTurism.Data;

namespace AgentieTurism.Models
{
    public class VacationTagPageModel : PageModel
    {
        public List<AssignedTagData> AssignedTagDataList;
        public void PopulateAssignedTagData(AgentieTurismContext context, Vacation vacation)
        {
            var allTags = context.Tag;
            var vacationTags = new HashSet<int>(
                vacation.VacationTags.Select(t => t.ID));
            AssignedTagDataList = new List<AssignedTagData>();
            foreach (var tag in allTags)
            {
                AssignedTagDataList.Add(new AssignedTagData
                {
                    TagID = tag.ID,
                    TagName = tag.TagName,
                    Assigned = vacationTags.Contains(tag.ID)
                });
            }
        }
        public void UpdateVacationTags(AgentieTurismContext context,
        string[] selectedTags, Vacation vacationToUpdate)
        {
            if (selectedTags == null)
            {
                vacationToUpdate.VacationTags = new List<VacationTag>();
                return;
            }

            var selectedTagsHS = new HashSet<string>(selectedTags);
            var vacationTags = new HashSet<int>
            (vacationToUpdate.VacationTags.Select(t => t.Tag.ID));
            foreach (var tag in context.Tag)
            {
                if (selectedTagsHS.Contains(tag.ID.ToString()))
                {
                    if (!vacationTags.Contains(tag.ID))
                    {
                        vacationToUpdate.VacationTags.Add(
                        new VacationTag
                        {
                            VacationID = vacationToUpdate.ID,
                            TagID = tag.ID
                        });
                    }
                }
                else
                {
                    if (vacationTags.Contains(tag.ID))
                    {
                        VacationTag vacationToRemove= vacationToUpdate.VacationTags.SingleOrDefault(i => i.TagID == tag.ID);
                        context.Remove(vacationToRemove);
                    }
                }
            }
        }
    }
}