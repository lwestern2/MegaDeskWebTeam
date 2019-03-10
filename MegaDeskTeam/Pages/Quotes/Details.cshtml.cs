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
    public class DetailsModel : PageModel
    {
        private readonly MegaDeskTeam.Models.MegaDeskTeamContext _context;

        public DetailsModel(MegaDeskTeam.Models.MegaDeskTeamContext context)
        {
            _context = context;
        }

        public Quote Quote { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Quote = await _context.Quote.FirstOrDefaultAsync(m => m.ID == id);

            if (Quote == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
