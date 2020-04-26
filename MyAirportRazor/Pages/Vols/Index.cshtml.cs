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
    public class IndexModelVol : PageModel
    {
        private readonly ECE.AA.MyAirport.EF.AirportContext _context;

        public IndexModelVol(ECE.AA.MyAirport.EF.AirportContext context)
        {
            _context = context;
        }

        public IList<Vol> Vol { get;set; }

        public async Task OnGetAsync()
        {
            Vol = await _context.Vols.ToListAsync();
        }
    }
}
