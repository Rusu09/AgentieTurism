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

namespace AgentieTurism.Pages.Locations
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly AgentieTurism.Data.AgentieTurismContext _context;

        public IndexModel(AgentieTurism.Data.AgentieTurismContext context)
        {
            _context = context;
        }

        public IList<Location> Location { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Location = await _context.Location.ToListAsync();
        }
    }
}
