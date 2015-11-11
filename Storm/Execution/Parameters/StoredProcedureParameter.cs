using System.Data;

namespace Flyingpie.Storm.Execution.Parameters
{
    public abstract class StoredProcedureParameter
    {
        public string Name { get; set; }

        public string TypeName { get; set; }

        public ParameterDirection Mode { get; set; }

        public string DirectionString { get; set; }

        public abstract object GetValueAsObject();
    }
}