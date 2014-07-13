using Flyingpie.Storm.Lib;
using Storm.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flyingpie.Storm.Output
{
    public class Example
    {
        public Example()
        {
            Example1();
        }

        public void Example1()
        {
            var executor = new AdoSqlExecutor();
            var analyse = new Database.Analyse(executor);
            var result = analyse.csp_ZorgverstrekkerBudget_s01<SqlResponse>(1, 1, null, 409);

            //var analyse = new Database.Analyse();
            //analyse.csp_BehandelingZwarteLijst_u01(new Analyse.udtUpdateBehandelingZwarteLijst()
            //{
            //    new Analyse.udtUpdateBehandelingZwarteLijst.udtUpdateBehandelingZwarteLijstItem()
            //    {
            //        BehandelingId = 1
            //    },
            //    new Analyse.udtUpdateBehandelingZwarteLijst.udtUpdateBehandelingZwarteLijstItem()
            //    {
            //        BehandelingId = 2
            //    }
            //}, 1);

            //var executor = new AdoSqlExecutor();
            //var analyse = new Database.Analyse(executor);
            //var response = analyse.csp_BehandelingZwarteLijst_s01<BehandelingZwarteLijstItem>(new DateTime(2013, 1, 1), 409);
        }

        public void ExampleSql()
        {
            /*
            var sqlRequest = new SqlRequest()
            {
                StoredProcedureName = "csp_x_s01",
                Parameters = new List<StoredProcedureParameter>()
                {
                    new StoredProcedureSimpleParameter()
                    {
                        Name = "n",
                        Value = "b"
                    }
                }
            };
             */
        }

        public class BehandelingZwarteLijstItem
        {
            public int Id { get; set; }
            public int ZorgverzekeraarId { get; set; }
            public int ZorgverstrekkerId { get; set; }
        }
    }
}
