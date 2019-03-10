using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MegaDeskWebTeam.Pages.Models;

namespace MegaDeskTeam.Models
{
    public class MegaDeskTeamContext : DbContext
    {
        public MegaDeskTeamContext (DbContextOptions<MegaDeskTeamContext> options)
            : base(options)
        {
        }

        public DbSet<MegaDeskWebTeam.Pages.Models.Quote> Quote { get; set; }
    }
}
