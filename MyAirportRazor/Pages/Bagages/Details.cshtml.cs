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
    public class DetailsModelBagage : PageModel
    {
        private readonly ECE.AA.MyAirport.EF.AirportContext _context;

        public DetailsModelBagage(ECE.AA.MyAirport.EF.AirportContext context)
        {
            _context = context;
        }

        public Bagage Bagage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bagage = await _context.Bagages
                .Include(b => b.Vol).FirstOrDefaultAsync(m => m.ID_BAGAGE == id);

            if (Bagage == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
