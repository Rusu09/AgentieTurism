using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AgentieTurism.Data;
using AgentieTurism.Models;
using System.Security.Policy;
using Microsoft.AspNetCore.Authorization;

namespace AgentieTurism.Pages.Vacations
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : VacationTagPageModel
    {
        private readonly AgentieTurism.Data.AgentieTurismContext _context;

        public CreateModel(AgentieTurism.Data.AgentieTurismContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["LocationID"] = new SelectList(_context.Set<Location>(), "ID","FullLocation");

            var vacation = new Vacation();
            vacation.VacationTags = new List<VacationTag>();
            PopulateAssignedTagData(_context, vacation);

            return Page();
        }

        [BindProperty]
        public Vacation Vacation { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedTags)
        {
            var newVacation = new Vacation();
            if (selectedTags != null)
            {
                newVacation.VacationTags = new List<VacationTag>();
                foreach (var tag in selectedTags)
                {
                    var tagToAdd = new VacationTag
                    {
                        TagID = int.Parse(tag)
                    };
                    newVacation.VacationTags.Add(tagToAdd);
                }
            }
            Vacation.VacationTags = newVacation.VacationTags;
            _context.Vacation.Add(Vacation);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
    
}
