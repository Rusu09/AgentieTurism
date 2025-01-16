using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AgentieTurism.Data;
using AgentieTurism.Models;

namespace AgentieTurism.Pages.Reviews
{
    public class IndexModel : PageModel
    {
        private readonly AgentieTurism.Data.AgentieTurismContext _context;

        public IndexModel(AgentieTurism.Data.AgentieTurismContext context)
        {
            _context = context;
        }

        public IList<Review> Review { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Review = await _context.Review
                .Include(r => r.User)
                .Include(r => r.Vacation)
                .ThenInclude(r=> r.Location)
                .ToListAsync();
        }
    }
}
