using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Storm.Test.Dto
{
    public class Prestatie
    {
        public int PrestatieID { get; set; }
        public int PrestatieCodeID { get; set; }
        public string ZorgproductCode { get; set; }
        public string DeclaratieCode { get; set; }
        public string SegmentCode { get; set; }
        public DateTime DatumIngang { get; set; }
        public DateTime DatumEind { get; set; }
    }
}
