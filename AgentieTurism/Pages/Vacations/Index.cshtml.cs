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

        public IList<Vacation> Vacation { get; set; } = default!;
        public VacationData VacationD { get; set; }
        public int VacationID { get; set; }
        public int TagID { get; set; }

        public string TitleSort { get; set; }
        public string PriceSort { get; set; }
        public string LocationSort { get; set; }
        public string DepartureSort { get; set; }
        public string ReturnSort { get; set; }
        public string CurrentFilter { get; set; }
        public async Task OnGetAsync(int? id, int? tagID, string sortOrder, string searchString)
        {
            VacationD = new VacationData();

            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            PriceSort = sortOrder == "price" ? "price_desc" : "price";
            DepartureSort = sortOrder == "departure" ? "departure_desc" : "departure";
            ReturnSort = sortOrder == "return" ? "return_desc" : "return";

            CurrentFilter = searchString;

            VacationD.Vacations = await _context.Vacation
            .Include(v => v.Location)
            .Include(v => v.VacationTags)
            .ThenInclude(v => v.Tag)
            .AsNoTracking()
            .OrderBy(v => v.Title)
            .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                VacationD.Vacations = VacationD.Vacations.Where(s => s.Location.City.Contains(searchString)
                || s.Location.Country.Contains(searchString)
                || s.Title.Contains(searchString));
            }
                switch (sortOrder)
                {
                    case "title_desc":
                        VacationD.Vacations = VacationD.Vacations.OrderByDescending(s => s.Title);
                        break;
                    case "price_desc":
                        VacationD.Vacations = VacationD.Vacations.OrderByDescending(s => s.Price);
                        break;
                    case "price":
                        VacationD.Vacations = VacationD.Vacations.OrderBy(s => s.Price);
                        break;
                    case "departure_desc":
                        VacationD.Vacations = VacationD.Vacations.OrderByDescending(s => s.AvailableFrom);
                        break;
                    case "departure":
                        VacationD.Vacations = VacationD.Vacations.OrderBy(s => s.AvailableFrom);
                        break;
                    case "return_desc":
                        VacationD.Vacations = VacationD.Vacations.OrderByDescending(s => s.AvailableTo);
                        break;
                    case "return":
                        VacationD.Vacations = VacationD.Vacations.OrderBy(s => s.AvailableTo);
                        break;
                    default:
                        VacationD.Vacations = VacationD.Vacations.OrderBy(s => s.Title);
                        break;
                }

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
