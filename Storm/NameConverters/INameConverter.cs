using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flyingpie.Storm.NameConverters
{
    public interface INameConverter
    {
        string ConvertSchemaToInterface(string name);
        
        string ConvertSchemaToClass(string name);

        string ConvertStoredProcedureToMethod(string name);

        string ConvertParameter(string name);

        string ConvertColumnToProperty(string name);

        string ConvertUserDefinedTypeToClass(string name);
    }
}
