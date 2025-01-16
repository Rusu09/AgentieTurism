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

namespace AgentieTurism.Pages.Reviews
{
    public class EditModel : PageModel
    {
        private readonly AgentieTurism.Data.AgentieTurismContext _context;

        public EditModel(AgentieTurism.Data.AgentieTurismContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Review Review { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review =  await _context.Review.FirstOrDefaultAsync(m => m.ID == id);
            if (review == null)
            {
                return NotFound();
            }
            Review = review;
           ViewData["UserID"] = new SelectList(_context.User, "ID", "ID");
           ViewData["VacationID"] = new SelectList(_context.Vacation, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Review).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(Review.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ReviewExists(int id)
        {
            return _context.Review.Any(e => e.ID == id);
        }
    }
}
