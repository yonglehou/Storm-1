using System;
using System.IO;

namespace Flyingpie.Storm.Host
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Generate or execute? (g/E)");
            var action = Console.ReadLine();

            if (action.ToUpper() == "G")
            {
                Generate();
            }
            else
            {
                new Example();
            }
        }

        private static void Generate()
        {
            var output = @"C:\Users\marcovdo\Source\Repos\Storm\Storm.Host\Database.Generated.cs";
            var generator = Generator.FromConnectionString("Data Source=DBCS_PRD_SQLSRV;Initial catalog=DBCServices5;Integrated Security=true;");
            var code = generator.Generate();

            File.WriteAllText(output, code);
        }
    }
}