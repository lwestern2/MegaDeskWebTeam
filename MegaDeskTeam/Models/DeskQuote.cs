using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MegaDeskTeam.Models;


namespace MegaDeskWebTeam.Pages.Models
{
    public enum Material
    {
        Oak = 200,
        Laminate = 100,
        Pine = 50,
        Rosewood = 300,
        Veneer = 125
    }

    //public enum RushDays
    //{
    //    None = 0,
    //    3 = 3,
    //    5 = 5,
    //    7 = 7
    //}

    public class DeskQuote
    {
        #region quote description
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

        public static int QuoteTotal { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

        public Material deskMaterial { get; set; }
        #endregion

        #region constants
        private const int PRICE_BASE = 200;
        private const int SIZE_LIMIT = 1000;
        private const int PRICE_PER_DRAWER = 50;
        private const int PRICE_PER_AREA = 1;
        private const int RUSH_ADD = 2000;
        private const int RUSH1 = 3;
        private const int RUSH2 = 5;
        private const int RUSH3 = 7;

        #endregion

        public int TotalCost
        {
            get
            {
                return PRICE_BASE + AreaCost() + DrawerCost + (int)deskMaterial + RushCost;
            }
        }

        public int AreaCalc
        {
            get
            {
                return Width * Depth;
            }
        }

        public int AreaCost()
        {
           if (AreaCalc > SIZE_LIMIT)
            {
                return (AreaCalc - SIZE_LIMIT) * PRICE_PER_AREA;
            }
            else
            {
                return 0;
            }
        }

        private int DrawerCost
        {
            get
            {
                return Drawers * PRICE_PER_DRAWER;
            }
        }

        private int RushCost
        {
           get
            {
                switch (RushDays)
                {
                    case 3:
                        if (AreaCalc < 1000)
                            return 60;
                        else if (AreaCalc >= 1000 && AreaCalc <= 2000)
                            return 80;
                        else if (AreaCalc > 2000)
                            return 70;
                        break;

                    case 5:
                        if (AreaCalc < 1000)
                            return 40;
                        else if (AreaCalc >= 1000 && AreaCalc <= 2000)
                            return 60;
                        else if (AreaCalc > 2000)
                            return 50;
                        break;

                    case 7:
                        if (AreaCalc < 1000)
                            return 30;
                        else if (AreaCalc >= 1000 && AreaCalc <= 2000)
                            return 35;
                        else if (AreaCalc > 2000)
                            return 40;
                        break;

                    case 0:
                        return 0;

                    default:
                        break;
                }
                return 0;
            }
        }
    }
}
