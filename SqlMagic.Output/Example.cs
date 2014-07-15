using Flyingpie.Storm.Dapper;
using Flyingpie.Storm.Executors;
using System.Collections.Generic;

namespace Flyingpie.Storm.Output
{
    public class ZorgverstrekkerBudget
    {
        public int? Id { get; set; }

        public int ZorgverzekeraarId { get; set; }

        public int ZorgverstrekkerId { get; set; }

        public string ZVSAGBCode { get; set; }

        public string ZVSNaam { get; set; }
    }

    public class BehandelingZwarteLijstItem
    {
        public int Id { get; set; }

        public int ZorgverzekeraarId { get; set; }

        public int ZorgverstrekkerId { get; set; }
    }

    public class Example
    {
        public Example()
        {
            Example1();
        }

        public void Example1()
        {
            var executor = new DapperSqlExecutor("server=DBCS_PRD_SQLSRV;database=DBCServices5;integrated security=true;");
            var analyse = new Database.Analyse(executor);
            //var result = analyse.csp_ZorgverstrekkerBudget_s01<SqlResponse<ZorgverstrekkerBudget>>(1, 1, null, 409);
            //var result = analyse.csp_Periode_s01<SqlResponse<dynamic>>(new DateTime(2000, 1, 1), 409);

            var lijst = new List<Database.UserDefinedTypes.Analyse.udtUpdateBehandelingZwarteLijst>()
            {
                new Database.UserDefinedTypes.Analyse.udtUpdateBehandelingZwarteLijst()
                {
                    BehandelingId = 1,
                    PeriodeId = 1,
                    UitsluitingId = 1,
                    ZorgverstrekkerId = 21
                },
                new Database.UserDefinedTypes.Analyse.udtUpdateBehandelingZwarteLijst()
                {
                    BehandelingId = 2,
                    PeriodeId = 2,
                    UitsluitingId = 2,
                    ZorgverstrekkerId = 32
                },
                new Database.UserDefinedTypes.Analyse.udtUpdateBehandelingZwarteLijst()
                {
                    BehandelingId = 3,
                    PeriodeId = 3,
                    UitsluitingId = 1,
                    ZorgverstrekkerId = 39
                }
            };

            using (var transaction = executor.BeginTransaction())
            {
                int? zvzId = 409;
                analyse.csp_BehandelingZwarteLijst_u01<SqlResponse>(lijst, ref zvzId);
                transaction.Commit();
            }
        }
    }
}