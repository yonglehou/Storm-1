namespace Flyingpie.Storm.Generation.Converters
{
    public interface INameConverter
    {
        string ConvertSchemaToInterface(string name);

        string ConvertSchemaToClass(string name);

        string ConvertSchemaToNamespace(string name);

        string ConvertStoredProcedureToMethod(string name);

        string ConvertParameter(string name);

        string ConvertColumnToProperty(string name);

        string ConvertUserDefinedTypeToClass(string name);
    }
}