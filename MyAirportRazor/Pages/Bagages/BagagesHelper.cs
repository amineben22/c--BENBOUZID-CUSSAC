using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAirportRazor
{
    public static class BagagesHelper
    {
        public static SelectList ListVolInfo(ECE.AA.MyAirport.EF.AirportContext context)
        {
            var vols = context.Vols
                .Select(v => new
                {
                    v.ID_VOL,
                    Description = $"{v.CIE} {v.LIG} : {v.DHC}"
                }).ToList();
            return new SelectList(vols, "ID_VOL", "Description");
        }
    }
}
