using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Storm.Test.Dto
{
    public class BehandelingZwarteLijst
    {
        public int Id { get; set; }
        public int ZorgverzekeraarId { get; set; }
        public int ZorgverstrekkerId { get; set; }
        public int PeriodeId { get; set; }
        public int BehandelingId { get; set; }
        public int UitsluitingId { get; set; }
    }
}
