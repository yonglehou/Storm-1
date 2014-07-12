using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SqlMagic.Model.Database
{
    class MapToAttribute : Attribute
    {
        public string Column { get; set; }

        public MapToAttribute(string column)
        {
            Column = column;
        }
    }
}
