
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AB.AC.MyAirport.EF
{
    public class Bagage
    {
        [Key]
        public int ID_BAGAGE { get; set; }
        [ForeignKey("Vol")]
        public int? ID_VOL { get; set; }
        public Vol? Vol { get; set; }
        public string? CODE_IATA { get; set; } = null!;
        public DateTime DATE_CREATION { get; set; }
        public char? CLASSE { get; set; }
        public byte? PRIORITAIRE { get; set; }
        public char? STA { get; set; }
        public string? SSUR { get; set; }
        public string? DESTINATION { get; set; }
        public string? ESCALE { get; set; }

        public Bagage() { }

    }
}
