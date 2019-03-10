using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDeskTeam.Models;
using MegaDeskWebTeam.Pages.Models;

namespace MegaDeskTeam.Pages.Quotes
{
    public class CreateModel : PageModel
    {
        private readonly MegaDeskTeam.Models.MegaDeskTeamContext _context;

        public CreateModel(MegaDeskTeam.Models.MegaDeskTeamContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]


        public Quote Quote { get; set; }

             
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Quote.Add(Quote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}