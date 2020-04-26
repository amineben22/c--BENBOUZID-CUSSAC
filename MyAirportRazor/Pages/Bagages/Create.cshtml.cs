using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ECE.AA.MyAirport.EF;

namespace MyAirportRazor
{
    public class CreateModelBagage : PageModel
    {
        private readonly ECE.AA.MyAirport.EF.AirportContext _context;

        public CreateModelBagage(ECE.AA.MyAirport.EF.AirportContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ID_VOL"] = BagagesHelper.ListVolInfo(_context);
            return Page();
        }

        [BindProperty]
        public Bagage Bagage { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Bagages.Add(Bagage);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
