using Flyingpie.Storm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flyingpie.Storm.CodeGenerators
{
    public interface ICodeGenerator
    {
        string Generate(DatabaseModel model);
    }
}
