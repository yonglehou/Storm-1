using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Flyingpie.Storm.Converters;

namespace Flyingpie.Storm
{
    public class GeneratorConfiguration
    {
        public static GeneratorConfiguration Instance { get; private set; }

        static GeneratorConfiguration()
        {
            Instance = new GeneratorConfiguration();
        }

        private GeneratorConfiguration()
        {
            // Defaults
            LibraryName = "Flyingpie.Storm";
            LibraryVersion = GetType().Assembly.GetName().Version.ToString();

            RootNamespace = "Database";

            NameConverter = new DefaultNameConverter();
            TypeConverter = new DefaultTypeConverter();
            ValueConverter = new DefaultValueConverter();
        }

        public string LibraryName { get; set; }

        public string LibraryVersion { get; set; }

        public string RootNamespace { get; set; }

        public INameConverter NameConverter { get; set; }

        public ITypeConverter TypeConverter { get; set; }

        public IValueConverter ValueConverter { get; set; }
    }
}
