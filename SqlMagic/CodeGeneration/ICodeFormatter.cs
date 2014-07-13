using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flyingpie.Storm.CodeGeneration
{
    public interface ICodeFormatter
    {
        string Format(string input);
    }
}
