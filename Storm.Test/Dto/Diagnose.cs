using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Storm.Test.Dto
{
    public class Diagnose
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Specialismecode { get; set; }
        public string Omschrijving { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; }
    }
}
