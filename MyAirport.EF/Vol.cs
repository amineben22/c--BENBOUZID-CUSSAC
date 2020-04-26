using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AB.AC.MyAirport.EF
{
    public class Vol
    {
        [Key]
        public int ID_VOL { get; set; }
        public string CIE { get; set; }
        public string LIG { get; set; }
        public DateTime? DHC { get; set; }
        public string? PKG { get; set; }
        public string? IMM { get; set; }
        public int? PAX { get; set; }
        public string? DES { get; set; }
        public ICollection<Bagage>? Bagages { get; set; }

        public Vol () { }
    }
}
