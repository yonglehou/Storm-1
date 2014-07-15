using System;

namespace Flyingpie.Storm.Model
{
    internal class MapToAttribute : Attribute
    {
        public string Column { get; set; }

        public MapToAttribute(string column)
        {
            Column = column;
        }
    }
}