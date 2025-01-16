using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AgentieTurism.Data;
using AgentieTurism.Models;
using Microsoft.EntityFrameworkCore;

namespace AgentieTurism.Pages.Reviews
{
    public class CreateModel : PageModel
    {
        private readonly AgentieTurism.Data.AgentieTurismContext _context;

        public CreateModel(AgentieTurism.Data.AgentieTurismContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var vacationList = _context.Vacation
                                .Include(v => v.Location)
                                .Select(x => new
                                {
                                    x.ID,
                                    vacationInfo = x.Title + " - " + x.Location.FullLocation + " - " + x.AvailableFrom + "-" + x.AvailableTo
                                });

            ViewData["UserID"] = new SelectList(_context.User, "ID", "FullName");
            ViewData["VacationID"] = new SelectList(vacationList, "ID", "vacationInfo");
            return Page();
        }

        [BindProperty]
        public Review Review { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Review.Add(Review);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
