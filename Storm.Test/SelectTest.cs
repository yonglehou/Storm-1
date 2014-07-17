using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Flyingpie.Storm.Executors;
using Flyingpie.Storm.Dapper;
using Database;
using Storm.Test.Dto;
using System.Collections.Generic;
using System.Diagnostics;

namespace Storm.Test
{
    [TestClass]
    public class SelectTest
    {
        private ISqlExecutor _executor;

        private IAfspraak _afspraak;
        private IAnalyse _analyse;
        private IDbc _dbc;

        [TestInitialize]
        public void Initialize()
        {
            _executor = DapperSqlExecutor.FromConnectionStringName("DbcServices5");

            _afspraak = new Afspraak(_executor);
            _analyse = new Analyse(_executor);
            _dbc = new Dbc(_executor);
        }

        [TestMethod]
        public void SelectStatic()
        {
            var result = _analyse.csp_ZorgverstrekkerBudget_s01<SqlResponse<ZorgverstrekkerBudget>>(1, 1, null, 409);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Items);
            Assert.AreEqual(1445, result.Items.Count());

            var r = result.Items.Single(r1 => r1.Id == 888);

            Assert.AreEqual(888, r.Id);
            Assert.AreEqual(409, r.ZorgverzekeraarId);
            Assert.AreEqual(719, r.ZorgverstrekkerId);
            Assert.AreEqual("22227233", r.ZVSAGBCode);
            Assert.AreEqual("Ooglift", r.ZVSNaam);
            Assert.AreEqual(1, r.PeriodeId);
            Assert.AreEqual(new DateTime(2012, 1, 1), r.PeriodeBeginDatum);
            Assert.AreEqual(new DateTime(2012, 12, 31), r.PeriodeEindDatum);
            Assert.AreEqual(37, r.RegioId);
            Assert.AreEqual("Utrecht", r.RegioNaam);
            Assert.AreEqual(12, r.CategorieId);
            Assert.AreEqual("Ems", r.CategorieNaam);
            Assert.AreEqual("", r.Inkoper);
            Assert.AreEqual(4401.0M, r.BudgetTotaal);
            Assert.AreEqual(0.0M, r.ExternContractTotaal);
            Assert.AreEqual(false, r.OnderhandenWerk);
            Assert.AreEqual("", r.OnderhandenWerkMailadres);
            Assert.AreEqual(false, r.NietInAutoModelcontract);
            Assert.AreEqual(true, r.Contracteerbaar);
            Assert.AreEqual(1, r.ZorgSoortId);
            Assert.AreEqual("I", r.IPZReferentie);
            Assert.AreEqual(0.0M, r.OmzetPlafond);
        }

        [TestMethod]
        public void SelectDynamic()
        {
            var result = _analyse.csp_Periode_s01<SqlResponse<dynamic>>(new DateTime(2000, 1, 1), 409);

            var p2012 = result.Items.Single(p => p.Id == 1);
            Assert.AreEqual(409, p2012.ZorgverzekeraarId);
            Assert.AreEqual("2012", p2012.Naam);
            Assert.AreEqual(new DateTime(2012, 1, 1), p2012.BeginDatum);
            Assert.AreEqual(new DateTime(2012, 12, 31), p2012.EindDatum);

            var p2013 = result.Items.Single(p => p.Id == 2);
            Assert.AreEqual(409, p2013.ZorgverzekeraarId);
            Assert.AreEqual("2013", p2013.Naam);
            Assert.AreEqual(new DateTime(2013, 1, 1), p2013.BeginDatum);
            Assert.AreEqual(new DateTime(2013, 12, 31), p2013.EindDatum);

            var p2014 = result.Items.Single(p => p.Id == 3);
            Assert.AreEqual(409, p2014.ZorgverzekeraarId);
            Assert.AreEqual("2014", p2014.Naam);
            Assert.AreEqual(new DateTime(2014, 1, 1), p2014.BeginDatum);
            Assert.AreEqual(new DateTime(2014, 12, 31), p2014.EindDatum);

            var p2015 = result.Items.Single(p => p.Id == 4);
            Assert.AreEqual(409, p2015.ZorgverzekeraarId);
            Assert.AreEqual("2015", p2015.Naam);
            Assert.AreEqual(new DateTime(2015, 1, 1), p2015.BeginDatum);
            Assert.AreEqual(new DateTime(2015, 12, 31), p2015.EindDatum);
        }

        [TestMethod]
        public void Update()
        {
            var analyse = new Database.Analyse(_executor);

            var zvzId = 409;

            var resetList = GetResetList();

            analyse.csp_BehandelingZwarteLijst_u01<SqlResponse>(resetList, zvzId);

            var before1 = analyse.csp_BehandelingZwarteLijst_s01<SqlResponse<BehandelingZwarteLijst>>(new DateTime(2012, 1, 1), zvzId);
            var before2 = analyse.csp_BehandelingZwarteLijst_s01<SqlResponse<BehandelingZwarteLijst>>(new DateTime(2013, 1, 1), zvzId);
            var before3 = analyse.csp_BehandelingZwarteLijst_s01<SqlResponse<BehandelingZwarteLijst>>(new DateTime(2014, 1, 1), zvzId);

            Assert.AreEqual(0, before1.Items.Count());
            Assert.AreEqual(0, before2.Items.Count());
            Assert.AreEqual(0, before3.Items.Count());

            var updateList = GetUpdateList();

            analyse.csp_BehandelingZwarteLijst_u01<SqlResponse>(updateList, 409);

            var after1 = analyse.csp_BehandelingZwarteLijst_s01<SqlResponse<BehandelingZwarteLijst>>(new DateTime(2012, 1, 1), zvzId);
            var after2 = analyse.csp_BehandelingZwarteLijst_s01<SqlResponse<BehandelingZwarteLijst>>(new DateTime(2013, 1, 1), zvzId);
            var after3 = analyse.csp_BehandelingZwarteLijst_s01<SqlResponse<BehandelingZwarteLijst>>(new DateTime(2014, 1, 1), zvzId);

            Assert.AreEqual(1, after1.Items.Count());
            var after1Item = after1.Items.Single();
            Assert.AreEqual(zvzId, after1Item.ZorgverzekeraarId);
            Assert.AreEqual(21, after1Item.ZorgverstrekkerId);
            Assert.AreEqual(1, after1Item.PeriodeId);
            Assert.AreEqual(1, after1Item.BehandelingId);
            Assert.AreEqual(1, after1Item.UitsluitingId);

            Assert.AreEqual(1, after2.Items.Count());
            var after2Item = after2.Items.Single();
            Assert.AreEqual(zvzId, after2Item.ZorgverzekeraarId);
            Assert.AreEqual(32, after2Item.ZorgverstrekkerId);
            Assert.AreEqual(2, after2Item.PeriodeId);
            Assert.AreEqual(2, after2Item.BehandelingId);
            Assert.AreEqual(2, after2Item.UitsluitingId);

            Assert.AreEqual(1, after3.Items.Count());
            var after3Item = after3.Items.Single();
            Assert.AreEqual(zvzId, after3Item.ZorgverzekeraarId);
            Assert.AreEqual(39, after3Item.ZorgverstrekkerId);
            Assert.AreEqual(3, after3Item.PeriodeId);
            Assert.AreEqual(3, after3Item.BehandelingId);
            Assert.AreEqual(1, after3Item.UitsluitingId);
        }

        [TestMethod]
        public void TransactionRollback()
        {
            var analyse = new Database.Analyse(_executor);

            var zvzId = 409;

            // Reset
            var resetList = GetResetList();
            analyse.csp_BehandelingZwarteLijst_u01<SqlResponse>(resetList, zvzId);
            var before1 = analyse.csp_BehandelingZwarteLijst_s01<SqlResponse<BehandelingZwarteLijst>>(new DateTime(2012, 1, 1), zvzId);
            Assert.AreEqual(0, before1.Items.Count());

            using (var transaction = _executor.BeginTransaction())
            {
                // Update
                var updateList = GetUpdateList();
                analyse.csp_BehandelingZwarteLijst_u01<SqlResponse>(updateList, 409);
                var after1 = analyse.csp_BehandelingZwarteLijst_s01<SqlResponse<BehandelingZwarteLijst>>(new DateTime(2012, 1, 1), zvzId);
                Assert.AreEqual(1, after1.Items.Count());

                // Rollback
                transaction.Rollback();
            }

            // Should not have changed
            var after2 = analyse.csp_BehandelingZwarteLijst_s01<SqlResponse<BehandelingZwarteLijst>>(new DateTime(2012, 1, 1), zvzId);
            Assert.AreEqual(0, after2.Items.Count());
        }

        [TestMethod]
        public void TransactionCommit()
        {
            var analyse = new Database.Analyse(_executor);

            var zvzId = 409;

            // Reset
            var resetList = GetResetList();
            analyse.csp_BehandelingZwarteLijst_u01<SqlResponse>(resetList, zvzId);
            var before1 = analyse.csp_BehandelingZwarteLijst_s01<SqlResponse<BehandelingZwarteLijst>>(new DateTime(2012, 1, 1), zvzId);
            Assert.AreEqual(0, before1.Items.Count());

            using (var transaction = _executor.BeginTransaction())
            {
                // Update
                var updateList = GetUpdateList();
                analyse.csp_BehandelingZwarteLijst_u01<SqlResponse>(updateList, 409);
                var after1 = analyse.csp_BehandelingZwarteLijst_s01<SqlResponse<BehandelingZwarteLijst>>(new DateTime(2012, 1, 1), zvzId);
                Assert.AreEqual(1, after1.Items.Count());

                // Commit
                transaction.Commit();
            }

            // Changes should persist
            var after2 = analyse.csp_BehandelingZwarteLijst_s01<SqlResponse<BehandelingZwarteLijst>>(new DateTime(2012, 1, 1), zvzId);
            Assert.AreEqual(1, after2.Items.Count());
        }

        [TestMethod]
        public void OutputParameters()
        {
            string toelichting = "";

            var result = _afspraak.csp_OnderhandelingPrestatieToelichting_s01<SqlResponse>(139491, "15B902", ref toelichting);

            Assert.AreEqual("In bijl. 0 is bij productieraming 2012 toegelicht dat in DBCS het hoogste aantal is ingevuld. Bij een DC met meerdere ZPCodes is het aantal gelijkelijk verdeeld.",
                toelichting);
        }

        [TestMethod]
        public void MultipleResultSets()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var result = _dbc.csp_BehandelingStamdata_s01<SqlResponse<Behandeling, Diagnose, Prestatie>>(new DateTime(2014, 1, 1));

            stopwatch.Stop();

            Assert.AreEqual(59, result.Items1.Count());
            Assert.AreEqual(57, result.Items2.Count());
            Assert.AreEqual(222660, result.Items3.Count());
        }

        #region Test Data

        private List<Database.UserDefinedTypes.Analyse.udtUpdateBehandelingZwarteLijst> GetResetList()
        {
            return new List<Database.UserDefinedTypes.Analyse.udtUpdateBehandelingZwarteLijst>()
            {
                new Database.UserDefinedTypes.Analyse.udtUpdateBehandelingZwarteLijst()
                {
                    BehandelingId = 1,
                    PeriodeId = 1,
                    UitsluitingId = 3,
                    ZorgverstrekkerId = 21
                },
                new Database.UserDefinedTypes.Analyse.udtUpdateBehandelingZwarteLijst()
                {
                    BehandelingId = 2,
                    PeriodeId = 2,
                    UitsluitingId = 3,
                    ZorgverstrekkerId = 32
                },
                new Database.UserDefinedTypes.Analyse.udtUpdateBehandelingZwarteLijst()
                {
                    BehandelingId = 3,
                    PeriodeId = 3,
                    UitsluitingId = 3,
                    ZorgverstrekkerId = 39
                }
            };
        }

        private List<Database.UserDefinedTypes.Analyse.udtUpdateBehandelingZwarteLijst> GetUpdateList()
        {
            return new List<Database.UserDefinedTypes.Analyse.udtUpdateBehandelingZwarteLijst>()
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
        }

        #endregion

        #region Storm

        [TestMethod]
        public void Select()
        {
            var executor = DapperSqlExecutor.FromConnectionStringName("TestDatabase");
            var orm = new Orm(executor);

            var result = orm.GetSmallTable<SqlResponse<SmallTableRow>>(null, null);

            Assert.AreEqual(10, result.Items.Count());

            Assert.IsTrue(result.Items.Any(i => i.Name == "Audi" && i.Description == "The steering wheel is an option"));
            Assert.IsTrue(result.Items.Any(i => i.Name == "Volvo" && i.Description == "The search for perfection ends here"));
        }

        #endregion
    }
}
