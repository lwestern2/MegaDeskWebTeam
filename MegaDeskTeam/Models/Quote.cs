using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MegaDeskTeam.Models;

namespace MegaDeskWebTeam.Pages.Models
{
    public class Quote
    {
        public int ID { get; set; }

        [Display(Name = "Customer Name")]
        [Required]
        public String customerName { get; set; }

        [Range(24.00, 96.00)]
        [Required]
        public int Width { get; set; }

        [Range(12.00, 48.00)]
        [Required]
        public int Depth { get; set; }

        [Required]
        public String Material { get; set; }

        [Range(0, 7)]
        [Required]
        public int Drawers { get; set; }

        [Display(Name = "Rush Days")]
        [Required]
        public int RushDays { get; set; }

        public int QuoteTotal { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        //public string dateAdded = DateTime.Now.ToString();
    }
}
