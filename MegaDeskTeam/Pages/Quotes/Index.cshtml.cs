using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskTeam.Models;
using MegaDeskWebTeam.Pages.Models;

namespace MegaDeskTeam.Pages.Quotes
{
    public class IndexModel : PageModel
    {
        private readonly MegaDeskTeam.Models.MegaDeskTeamContext _context;

        public IndexModel(MegaDeskTeam.Models.MegaDeskTeamContext context)
        {
            _context = context;
        }

        public string DateSort { get; set; }


        public IList<Quote> Quote { get;set; }
        public string SearchString { get; set; }
        public String customerName { get; set; }

        public async Task OnGetAsync(String sortOrder)
        {
            if (!string.IsNullOrEmpty(SearchString))
            {
                customerName = customerName.Where(s => s.customerName.Contains(SearchString));
            }
            Quote = await _context.Quote.ToListAsync();

            }
        }
}
