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
    public class DetailsModel : PageModel
    {
        private readonly AgentieTurism.Data.AgentieTurismContext _context;

        public DetailsModel(AgentieTurism.Data.AgentieTurismContext context)
        {
            _context = context;
        }

        public Vacation Vacation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacation = await _context.Vacation.FirstOrDefaultAsync(m => m.ID == id);
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
    }
}
