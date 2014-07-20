using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Flyingpie.Storm.Cli
{
    class Program
    {
        public static void Main(string[] args)
        {
            var options = new Options();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                Generate(options);
            }
            else
            {
                Console.WriteLine("Usage: stormcli.exe [options]");

                Console.WriteLine(options.GetUsage());
            }
        }

        private static void Generate(Options options)
        {
            try
            {
                var generator = Generator.FromConnectionString(options.ConnectionString);
                var code = generator.Generate();
                File.WriteAllText(options.OutputFile, code);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to generate code: " + e.Message);
            }
        }
    }
}
