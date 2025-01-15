using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AgentieTurism.Data;
using AgentieTurism.Models;
using System.Net;

namespace AgentieTurism.Pages.Vacations
{
    public class IndexModel : PageModel
    {
        private readonly AgentieTurism.Data.AgentieTurismContext _context;

        public IndexModel(AgentieTurism.Data.AgentieTurismContext context)
        {
            _context = context;
        }

        public IList<Vacation> Vacation { get;set; } = default!;
        public VacationData VacationD { get; set; }
        public int VacationID { get; set; }
        public int TagID { get; set; }

        public async Task OnGetAsync(int? id, int? tagID)
        {
            VacationD = new VacationData();
            VacationD.Vacations = await _context.Vacation
            .Include(v => v.Location)
            .Include(v => v.VacationTags)
            .ThenInclude(v => v.Tag)
            .AsNoTracking()
            .OrderBy(v => v.Title)
            .ToListAsync();

            if (id != null)
            {
                VacationID = id.Value;
                Vacation vacation = VacationD.Vacations
                .Where(i => i.ID == id.Value).Single();
                VacationD.Tags = vacation.VacationTags.Select(s => s.Tag);
            }
        }
    }
}
