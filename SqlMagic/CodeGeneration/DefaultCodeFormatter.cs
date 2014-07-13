using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flyingpie.Storm.CodeGeneration
{
    public class DefaultCodeFormatter : ICodeFormatter
    {
        public string Format(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var result = new StringBuilder();

            var indent = 0;
            var lastLine = "";
            for (int i = 0; i < lines.Length; i++)
            {
                //var lastLine = i > 0 ? lines[i - 1] : "";
                var line = lines[i];
                var nextLine = i < lines.Length - 1 ? lines[i + 1] : "";

                // Tabs
                var cInd = line.Count(c => c == '{') - line.Count(c => c == '}');
                if (cInd < 0)
                {
                    indent += cInd;
                }
                
                line = line.Trim();
                var tabs = "";
                for (int ind = 0; ind < indent; ind++)
                {
                    tabs += "\t";
                }

                line = tabs + line;

                if (cInd >= 0)
                {
                    indent += cInd;
                }
                // /Tabs

                if (string.IsNullOrWhiteSpace(line)) { continue; }

                // Empty lines
                if (lastLine.Contains("}") && line.Contains("interface"))
                {
                    result.AppendLine();
                }

                if (lastLine.Contains("}") && line.Contains("class"))
                {
                    result.AppendLine();
                }

                if (lastLine.Contains("}") && line.Contains("(") && line.Contains(")"))
                {
                    result.AppendLine();
                }

                if (lastLine.Contains("}") && line.Contains("namespace"))
                {
                    result.AppendLine();
                }

                if (lastLine.Contains("}") && line.Contains("#endregion"))
                {
                    result.AppendLine();
                }

                if (lastLine.Contains("#endregion") && line.Contains("#region"))
                {
                    result.AppendLine();
                }
                // /Empty lines

                if (lastLine.Contains("using") && line.Contains("namespace"))
                {
                    result.AppendLine();
                }

                result.AppendLine(line);

                if (line.Contains("#region"))
                {
                    result.AppendLine();
                }

                lastLine = line;
            }

            return result.ToString();
        }
    }
}
