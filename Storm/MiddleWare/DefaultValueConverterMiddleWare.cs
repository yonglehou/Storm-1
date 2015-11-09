using Flyingpie.Storm.Executors;
using System;
using System.Linq;

namespace Flyingpie.Storm.MiddleWare
{
    public class DefaultValueConverterMiddleWare : IMiddleWare
    {
        public Func<SqlRequest, T> Execute<T>(Func<SqlRequest, T> next) where T : SqlResponse
        {
            return request =>
            {
                var simpleParameters =
                    request.Parameters.OfType<StoredProcedureSimpleParameter>().ToList();

                foreach (var sp in simpleParameters)
                {
                    sp.Value = sp.Value;
                }

                return next(request);
            };
        }
    }
}