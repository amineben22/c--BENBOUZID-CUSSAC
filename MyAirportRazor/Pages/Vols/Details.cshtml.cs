using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ECE.AA.MyAirport.EF;

namespace MyAirportRazor
{
    public class DetailsModelVol : PageModel
    {
        private readonly ECE.AA.MyAirport.EF.AirportContext _context;

        public DetailsModelVol(ECE.AA.MyAirport.EF.AirportContext context)
        {
            _context = context;
        }

        public Vol Vol { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vol = await _context.Vols.FirstOrDefaultAsync(m => m.ID_VOL == id);

            if (Vol == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
