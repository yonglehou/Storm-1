using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flyingpie.Storm.Cli
{
    public class Options
    {
        [Option('c', "connection-string", Required = true, HelpText = "Database connection information")]
        public string ConnectionString { get; set; }

        [Option('o', "output", Required = true, HelpText = "The file to generate the output to")]
        public string OutputFile { get; set; }

        public string GetUsage()
        {
            return HelpText.AutoBuild(this, (c) => HelpText.DefaultParsingErrorsHandler(this, c));
        }
    }
}
