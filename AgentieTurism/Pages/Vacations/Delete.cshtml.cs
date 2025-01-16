using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AgentieTurism.Data;
using AgentieTurism.Models;

namespace AgentieTurism.Pages.Vacations
{
    public class DeleteModel : PageModel
    {
        private readonly AgentieTurism.Data.AgentieTurismContext _context;

        public DeleteModel(AgentieTurism.Data.AgentieTurismContext context)
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

            var vacation = await _context.Vacation
                .Include(v => v.Location)
                .Include(v => v.VacationTags)
                .ThenInclude(v => v.Tag)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (vacation == null)
            {
                return NotFound();
            }
            else
            {
                Vacation = vacation;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacation = await _context.Vacation.FindAsync(id);
            if (vacation != null)
            {
                Vacation = vacation;
                _context.Vacation.Remove(Vacation);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
