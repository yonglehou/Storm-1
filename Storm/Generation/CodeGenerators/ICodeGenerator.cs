using Flyingpie.Storm.Generation.Model;

namespace Flyingpie.Storm.Generation.CodeGenerators
{
    public interface ICodeGenerator
    {
        string Generate(DatabaseModel model);
    }
}