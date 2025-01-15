using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgentieTurism.Data;
using AgentieTurism.Models;

namespace AgentieTurism.Pages.Vacations
{
    public class EditModel : VacationTagPageModel
    {
        private readonly AgentieTurism.Data.AgentieTurismContext _context;

        public EditModel(AgentieTurism.Data.AgentieTurismContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vacation Vacation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacation =  await _context.Vacation
                .Include(v => v.Location)
                .Include(v => v.VacationTags).ThenInclude(v => v.Tag)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (vacation == null)
            {
                return NotFound();
            }

            PopulateAssignedTagData(_context, vacation);

            Vacation = vacation;
            ViewData["LocationID"] = new SelectList(_context.Set<Location>(), "ID", "FullLocation");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedTags)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacationToUpdate = await _context.Vacation
            .Include(i => i.Location)
            .Include(i => i.VacationTags)
            .ThenInclude(i => i.Tag)
            .FirstOrDefaultAsync(s => s.ID == id);

            if (vacationToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Vacation>(
            vacationToUpdate,
            "Vacation",
            i => i.Title, i => i.Description, i => i.Price, i => i.AvailableFrom, i => i.AvailableTo, i => i.LocationID))
            {
                UpdateVacationTags(_context, selectedTags, vacationToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateVacationTags(_context, selectedTags, vacationToUpdate);
            PopulateAssignedTagData(_context, vacationToUpdate);
            return Page();
        }

    }
}
