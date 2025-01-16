using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AgentieTurism.Data;
using AgentieTurism.Models;
using Microsoft.AspNetCore.Authorization;

namespace AgentieTurism.Pages.Tags
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly AgentieTurism.Data.AgentieTurismContext _context;

        public DeleteModel(AgentieTurism.Data.AgentieTurismContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tag Tag { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = await _context.Tag.FirstOrDefaultAsync(m => m.ID == id);

            if (tag == null)
            {
                return NotFound();
            }
            else
            {
                Tag = tag;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = await _context.Tag.FindAsync(id);
            if (tag != null)
            {
                Tag = tag;
                _context.Tag.Remove(Tag);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
