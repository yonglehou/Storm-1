using System.Collections.Generic;

namespace Flyingpie.Storm.Executors
{
    public class SqlResponse
    {
        public virtual void Execute(SqlRequest request, ISqlExecutor executor)
        {
            executor.Query<int>(request);
        }
    }

    public class SqlResponseScalar<T> : SqlResponse
    {
        public T Result { get; set; }

        public override void Execute(SqlRequest request, ISqlExecutor executor)
        {
            Result = executor.QueryScalar<T>(request);
        }
    }

    public class SqlResponseScalar : SqlResponseScalar<int>
    {
    }

    public class SqlResponse<T> : SqlResponse
    {
        public IEnumerable<T> Items { get; set; }

        public override void Execute(SqlRequest request, ISqlExecutor executor)
        {
            Items = executor.Query<T>(request);
        }
    }

    public class SqlResponse<T1, T2> : SqlResponse
    {
        public IEnumerable<T1> Items1 { get; set; }

        public IEnumerable<T2> Items2 { get; set; }

        public override void Execute(SqlRequest request, ISqlExecutor executor)
        {
            var result = executor.Query<T1, T2>(request);

            Items1 = result.Item1;
            Items2 = result.Item2;
        }
    }

    public class SqlResponse<T1, T2, T3> : SqlResponse
    {
        public IEnumerable<T1> Items1 { get; set; }

        public IEnumerable<T2> Items2 { get; set; }

        public IEnumerable<T3> Items3 { get; set; }

        public override void Execute(SqlRequest request, ISqlExecutor executor)
        {
            var result = executor.Query<T1, T2, T3>(request);

            Items1 = result.Item1;
            Items2 = result.Item2;
            Items3 = result.Item3;
        }
    }

    public class SqlResponse<T1, T2, T3, T4> : SqlResponse
    {
        public IEnumerable<T1> Items1 { get; set; }

        public IEnumerable<T2> Items2 { get; set; }

        public IEnumerable<T3> Items3 { get; set; }

        public IEnumerable<T4> Items4 { get; set; }

        public override void Execute(SqlRequest request, ISqlExecutor executor)
        {
            var result = executor.Query<T1, T2, T3, T4>(request);

            Items1 = result.Item1;
            Items2 = result.Item2;
            Items3 = result.Item3;
            Items4 = result.Item4;
        }
    }

    public class SqlResponse<T1, T2, T3, T4, T5> : SqlResponse
    {
        public IEnumerable<T1> Items1 { get; set; }

        public IEnumerable<T2> Items2 { get; set; }

        public IEnumerable<T3> Items3 { get; set; }

        public IEnumerable<T4> Items4 { get; set; }

        public IEnumerable<T5> Items5 { get; set; }

        public override void Execute(SqlRequest request, ISqlExecutor executor)
        {
            var result = executor.Query<T1, T2, T3, T4, T5>(request);

            Items1 = result.Item1;
            Items2 = result.Item2;
            Items3 = result.Item3;
            Items4 = result.Item4;
            Items5 = result.Item5;
        }
    }

    public class SqlResponse<T1, T2, T3, T4, T5, T6> : SqlResponse
    {
        public IEnumerable<T1> Items1 { get; set; }

        public IEnumerable<T2> Items2 { get; set; }

        public IEnumerable<T3> Items3 { get; set; }

        public IEnumerable<T4> Items4 { get; set; }

        public IEnumerable<T5> Items5 { get; set; }

        public IEnumerable<T6> Items6 { get; set; }

        public override void Execute(SqlRequest request, ISqlExecutor executor)
        {
            var result = executor.Query<T1, T2, T3, T4, T5, T6>(request);

            Items1 = result.Item1;
            Items2 = result.Item2;
            Items3 = result.Item3;
            Items4 = result.Item4;
            Items5 = result.Item5;
        }
    }

    public class SqlResponse<T1, T2, T3, T4, T5, T6, T7> : SqlResponse
    {
        public IEnumerable<T1> Items1 { get; set; }

        public IEnumerable<T2> Items2 { get; set; }

        public IEnumerable<T3> Items3 { get; set; }

        public IEnumerable<T4> Items4 { get; set; }

        public IEnumerable<T5> Items5 { get; set; }

        public IEnumerable<T6> Items6 { get; set; }

        public IEnumerable<T7> Items7 { get; set; }

        public override void Execute(SqlRequest request, ISqlExecutor executor)
        {
            var result = executor.Query<T1, T2, T3, T4, T5, T6, T7>(request);

            Items1 = result.Item1;
            Items2 = result.Item2;
            Items3 = result.Item3;
            Items4 = result.Item4;
            Items5 = result.Item5;
            Items6 = result.Item6;
            Items7 = result.Item7;
        }
    }
}