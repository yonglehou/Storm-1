using Flyingpie.Storm.Generation.Converters;

namespace Flyingpie.Storm.Generation
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
        }

        public string LibraryName { get; set; }

        public string LibraryVersion { get; set; }

        public string RootNamespace { get; set; }

        public INameConverter NameConverter { get; set; }

        public ITypeConverter TypeConverter { get; set; }
    }
}