using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Flyingpie.Storm;
using Flyingpie.Storm.Executors;

namespace Database
{
    #region User Defined Types

    namespace UserDefinedTypes
    {
        namespace Dbo
        {
            [GeneratedCode("Flyingpie.Storm", "1.0.0.0")]
            public partial class UdtIds
            {
                public int? Id { get; set; }
            }

            [GeneratedCode("Flyingpie.Storm", "1.0.0.0")]
            public partial class UdtZorgverstrekkerAanleverConfiguratieItem
            {
                public int? ZorgverstrekkerId { get; set; }
                public int? AanleverVerzoekConfiguratieId { get; set; }
                public string Frequentie { get; set; }
                public string EmailAdres { get; set; }
                public DateTime? CreateDate { get; set; }
                public int? CreateUser { get; set; }
            }

            [GeneratedCode("Flyingpie.Storm", "1.0.0.0")]
            public partial class UdtStatusAanleverPerioden
            {
                public int? AanleveringId { get; set; }
                public DateTime? EinddatumInclusiefAfwijkingen { get; set; }
                public DateTime? Aanleverdatum { get; set; }
                public bool? IsHeraanleveringToegestaan { get; set; }
                public bool? IsOnlineInvoerToegestaan { get; set; }
                public int? AanleverVerzoekId { get; set; }
                public int? AanleverVerzoekConfiguratieId { get; set; }
                public int? AanleverFrequentieId { get; set; }
                public int? AanleverPeriodeId { get; set; }
                public int? StatusId { get; set; }
                public int? StatusIdZonderOverride { get; set; }
                public bool? StatusIsOveridden { get; set; }
                public int? ZorgverstrekkerId { get; set; }
            }

            [GeneratedCode("Flyingpie.Storm", "1.0.0.0")]
            public partial class UdtAanleveringWaardenTable
            {
                public int? AanleverInputId { get; set; }
                public string Waarde { get; set; }
                public string Naam { get; set; }
                public string MimeType { get; set; }
                public byte[] BestandsData { get; set; }
            }
        }
    }

    #endregion

    #region Interfaces

    [GeneratedCode("Flyingpie.Storm", "1.0.0.0")]
    public interface IDbo
    {
        T CspAanleverFrequentieS01<T>(int? zorgverzekeraarId, int? jaar, int? zorgsoortId, int? aanleverVerzoekId) where T : SqlResponse;
        T CspAanleverFrequentieS02<T>(int? zorgverstrekkerId, int? zorgsoortId, int? jaar, int? aanleverVerzoekId) where T : SqlResponse;
        T CspAanleveringD01<T>(int? zorgsoortId, int? jaar, int? aanleverVerzoekId, int? aanleverPeriodeId, int? zorgverstrekkerId, int? zorgverzekeraarId) where T : SqlResponse;
        T CspAanleveringI01<T>(int? aanleverVerzoekConfiguratieId, int? aanleverPeriodeId, int? zorgverstrekkerId, int? statusId, int? createUser) where T : SqlResponse;
        T CspAanleveringI02<T>(int? aanleverVerzoekConfiguratieId, int? aanleverPeriodeId, int? zorgverstrekkerId, DateTime? aangeleverdOp, IEnumerable<Database.UserDefinedTypes.Dbo.UdtAanleveringWaardenTable> aanleveringWaarden, int? createUser) where T : SqlResponse;
        T CspAanleveringS01<T>(int? zorgsoortId, int? jaar, int? aanleverVerzoekId, int? aanleverPeriodeId, int? zorgverstrekkerId, int? aanleveringId, int? aanleverVerzoekConfiguratieId, DateTime? minAanleverdatum, DateTime? maxAanleverdatum, bool? includeAanleverWaarden, bool? includeBestandsData) where T : SqlResponse;
        T CspAanleveringU01<T>(int? aanleveringId) where T : SqlResponse;
        T CspAanleveringU02<T>(int? aanleveringId, DateTime? aanleverDatum, IEnumerable<Database.UserDefinedTypes.Dbo.UdtAanleveringWaardenTable> heraanleveringWaarden, IEnumerable<Database.UserDefinedTypes.Dbo.UdtIds> ongewijzigdeInputIds, int? createUser, ref bool? verplichteWaardeOntbreekt) where T : SqlResponse;
        T CspAanleveringAktieLogI01<T>(int? gebruikerId, int? aktieId, int? aanleveringId, DateTime? datum) where T : SqlResponse;
        T CspAanleveringAktieLogS01<T>(int? aanleveringId) where T : SqlResponse;
        T CspAanleveringWaardeS01<T>(int? aanleveringId, int? zorgverzekeraarId, int? zorgverstrekkerId, int? aanleverInputId) where T : SqlResponse;
        T CspAanleverVerzoekS01<T>(int? jaar, int? zorgsoortId, int? zorgverzekeraarId) where T : SqlResponse;
        T CspAanleverVerzoekS02<T>(int? zorgverstrekkerId, int? zorgsoortId, int? jaar) where T : SqlResponse;
        T CspAanleverVerzoekS03<T>(IEnumerable<Database.UserDefinedTypes.Dbo.UdtIds> aanleverVerzoekConfiguratieIds) where T : SqlResponse;
        T CspAanleverVerzoekS04<T>(int? zorgverzekeraarId, int? zorgsoortId, int? jaar, int? aanleverVerzoekId) where T : SqlResponse;
        T CspAanleverVerzoekConfiguratieS01<T>(int? aanleverVerzoekConfiguratieId, int? zorgsoortId, int? jaar, int? zorgverzekeraarId, int? aanleverVerzoekId) where T : SqlResponse;
        T CspAanleververzoekConfiguratieJarenS01<T>(int? zorgsoortId, int? zorgverzekeraarId) where T : SqlResponse;
        T CspAanleververzoekConfiguratieZorgsoortenS01<T>(int? zorgverzekeraarId) where T : SqlResponse;
        T CspAanleververzoekFrequentieS01<T>(int? jaar, int? zorgsoortId, int? zorgverzekeraarId) where T : SqlResponse;
        T CspAanleverVerzoekStatusS01<T>(int? zorgverzekeraarId, int? zorgverstrekkerId, int? zorgsoortId, int? jaar, int? aanleverVerzoekId, int? aanleverFrequentieId, DateTime? peildatum, int? aanleverVerzoekConfiguratieId) where T : SqlResponse;
        T CspAanleverVerzoekStatusS02<T>(int? zorgverzekeraarId, int? zorgverstrekkerId, int? zorgsoortId, int? jaar, int? aanleverVerzoekId, DateTime? peildatum, int? aanleverVerzoekConfiguratieId) where T : SqlResponse;
        T CspAanleverVerzoekStatusS03<T>(int? zorgverzekeraarId, int? zorgverstrekkerId, int? aanleververzoekId, int? zorgsoortId, int? jaar, DateTime? peilDatum, bool? includeBestandsData) where T : SqlResponse;
        T CspAanvullendeInformatieS01<T>(int? aanleverVerzoekConfiguratieId) where T : SqlResponse;
        T CspZorgverstrekkerAanleverConfiguratieI01<T>(IEnumerable<Database.UserDefinedTypes.Dbo.UdtZorgverstrekkerAanleverConfiguratieItem> zorgverstrekkerAanleverConfiguratieItems) where T : SqlResponse;
        T CspZorgverstrekkerAanleverConfiguratieS01<T>(int? jaar, int? zorgsoort, int? zorgverzekeraarId) where T : SqlResponse;
        T CspZorgverstrekkerAanleverConfiguratieS02<T>(int? zorgverstrekkerId) where T : SqlResponse;
        T CspZorgverstrekkerAanleverConfiguratieS03<T>(int? zorgsoortId, int? zorgverstrekkerId) where T : SqlResponse;
        T CspZorgverzekeraarInformatieS01<T>(IEnumerable<Database.UserDefinedTypes.Dbo.UdtIds> zorgverzekeraarIds) where T : SqlResponse;
        T CspPeriodeDatumsS01<T>() where T : SqlResponse;
        T TestDataMarker<T>() where T : SqlResponse;
    }

    #endregion

    #region Classes

    [GeneratedCode("Flyingpie.Storm", "1.0.0.0")]
    public partial class Dbo : IDbo
    {
        private IQueryChain _queryChain;
        public Dbo(IQueryChain queryChain)
        {
            _queryChain = queryChain;
        }

        public virtual T CspAanleverFrequentieS01<T>(int? zorgverzekeraarId, int? jaar, int? zorgsoortId, int? aanleverVerzoekId) where T : SqlResponse
        {
            var request = new SqlRequest("dbo", "csp_AanleverFrequentie_s01");
            request.Parameters.Add(new StoredProcedureSimpleParameter("@AanleverVerzoekId", "int", ParameterDirection.Input, aanleverVerzoekId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@Jaar", "int", ParameterDirection.Input, jaar));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgsoortId", "int", ParameterDirection.Input, zorgsoortId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", "int", ParameterDirection.Input, zorgverzekeraarId));
            var result = _queryChain.Execute<T>(request);
            return result;
        }

        public virtual T CspAanleverFrequentieS02<T>(int? zorgverstrekkerId, int? zorgsoortId, int? jaar, int? aanleverVerzoekId) where T : SqlResponse
        {
            var request = new SqlRequest("dbo", "csp_AanleverFrequentie_s02");
            request.Parameters.Add(new StoredProcedureSimpleParameter("@AanleverVerzoekId", "int", ParameterDirection.Input, aanleverVerzoekId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@Jaar", "int", ParameterDirection.Input, jaar));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgsoortId", "int", ParameterDirection.Input, zorgsoortId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerId", "int", ParameterDirection.Input, zorgverstrekkerId));
            var result = _queryChain.Execute<T>(request);
            return result;
        }

        public virtual T CspAanleveringD01<T>(int? zorgsoortId, int? jaar, int? aanleverVerzoekId, int? aanleverPeriodeId, int? zorgverstrekkerId, int? zorgverzekeraarId) where T : SqlResponse
        {
            var request = new SqlRequest("dbo", "csp_Aanlevering_d01");
            request.Parameters.Add(new StoredProcedureSimpleParameter("@AanleverPeriodeId", "int", ParameterDirection.Input, aanleverPeriodeId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@AanleverVerzoekId", "int", ParameterDirection.Input, aanleverVerzoekId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@Jaar", "int", ParameterDirection.Input, jaar));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgsoortId", "int", ParameterDirection.Input, zorgsoortId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerId", "int", ParameterDirection.Input, zorgverstrekkerId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", "int", ParameterDirection.Input, zorgverzekeraarId));
            var result = _queryChain.Execute<T>(request);
            return result;
        }

        public virtual T CspAanleveringI01<T>(int? aanleverVerzoekConfiguratieId, int? aanleverPeriodeId, int? zorgverstrekkerId, int? statusId, int? createUser) where T : SqlResponse
        {
            var request = new SqlRequest("dbo", "csp_Aanlevering_i01");
            request.Parameters.Add(new StoredProcedureSimpleParameter("@AanleverPeriodeId", "int", ParameterDirection.Input, aanleverPeriodeId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@AanleverVerzoekConfiguratieId", "int", ParameterDirection.Input, aanleverVerzoekConfiguratieId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@CreateUser", "int", ParameterDirection.Input, createUser));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@StatusId", "int", ParameterDirection.Input, statusId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerId", "int", ParameterDirection.Input, zorgverstrekkerId));
            var result = _queryChain.Execute<T>(request);
            return result;
        }

        public virtual T CspAanleveringI02<T>(int? aanleverVerzoekConfiguratieId, int? aanleverPeriodeId, int? zorgverstrekkerId, DateTime? aangeleverdOp, IEnumerable<Database.UserDefinedTypes.Dbo.UdtAanleveringWaardenTable> aanleveringWaarden, int? createUser) where T : SqlResponse
        {
            var request = new SqlRequest("dbo", "csp_Aanlevering_i02");
            request.Parameters.Add(new StoredProcedureSimpleParameter("@AangeleverdOp", "datetime", ParameterDirection.Input, aangeleverdOp));
            request.Parameters.Add(new StoredProcedureTableTypeParameter("@AanleveringWaarden", "table type", ParameterDirection.Input, "dbo", "udtAanleveringWaardenTable", aanleveringWaarden));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@AanleverPeriodeId", "int", ParameterDirection.Input, aanleverPeriodeId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@AanleverVerzoekConfiguratieId", "int", ParameterDirection.Input, aanleverVerzoekConfiguratieId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@CreateUser", "int", ParameterDirection.Input, createUser));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerId", "int", ParameterDirection.Input, zorgverstrekkerId));
            var result = _queryChain.Execute<T>(request);
            return result;
        }

        public virtual T CspAanleveringS01<T>(int? zorgsoortId, int? jaar, int? aanleverVerzoekId, int? aanleverPeriodeId, int? zorgverstrekkerId, int? aanleveringId, int? aanleverVerzoekConfiguratieId, DateTime? minAanleverdatum, DateTime? maxAanleverdatum, bool? includeAanleverWaarden, bool? includeBestandsData) where T : SqlResponse
        {
            var request = new SqlRequest("dbo", "csp_Aanlevering_s01");
            request.Parameters.Add(new StoredProcedureSimpleParameter("@AanleveringId", "int", ParameterDirection.Input, aanleveringId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@AanleverPeriodeId", "int", ParameterDirection.Input, aanleverPeriodeId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@AanleverVerzoekConfiguratieId", "int", ParameterDirection.Input, aanleverVerzoekConfiguratieId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@AanleverVerzoekId", "int", ParameterDirection.Input, aanleverVerzoekId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@IncludeAanleverWaarden", "bit", ParameterDirection.Input, includeAanleverWaarden));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@IncludeBestandsData", "bit", ParameterDirection.Input, includeBestandsData));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@Jaar", "int", ParameterDirection.Input, jaar));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@MaxAanleverdatum", "datetime2", ParameterDirection.Input, maxAanleverdatum));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@MinAanleverdatum", "datetime2", ParameterDirection.Input, minAanleverdatum));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgsoortId", "int", ParameterDirection.Input, zorgsoortId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerId", "int", ParameterDirection.Input, zorgverstrekkerId));
            var result = _queryChain.Execute<T>(request);
            return result;
        }

        public virtual T CspAanleveringU01<T>(int? aanleveringId) where T : SqlResponse
        {
            var request = new SqlRequest("dbo", "csp_Aanlevering_u01");
            request.Parameters.Add(new StoredProcedureSimpleParameter("@AanleveringId", "int", ParameterDirection.Input, aanleveringId));
            var result = _queryChain.Execute<T>(request);
            return result;
        }

        public virtual T CspAanleveringU02<T>(int? aanleveringId, DateTime? aanleverDatum, IEnumerable<Database.UserDefinedTypes.Dbo.UdtAanleveringWaardenTable> heraanleveringWaarden, IEnumerable<Database.UserDefinedTypes.Dbo.UdtIds> ongewijzigdeInputIds, int? createUser, ref bool? verplichteWaardeOntbreekt) where T : SqlResponse
        {
            var request = new SqlRequest("dbo", "csp_Aanlevering_u02");
            request.Parameters.Add(new StoredProcedureSimpleParameter("@AanleverDatum", "datetime", ParameterDirection.Input, aanleverDatum));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@AanleveringId", "int", ParameterDirection.Input, aanleveringId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@CreateUser", "int", ParameterDirection.Input, createUser));
            request.Parameters.Add(new StoredProcedureTableTypeParameter("@HeraanleveringWaarden", "table type", ParameterDirection.Input, "dbo", "udtAanleveringWaardenTable", heraanleveringWaarden));
            request.Parameters.Add(new StoredProcedureTableTypeParameter("@OngewijzigdeInputIds", "table type", ParameterDirection.Input, "dbo", "udtIds", ongewijzigdeInputIds));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@VerplichteWaardeOntbreekt", "bit", ParameterDirection.InputOutput, verplichteWaardeOntbreekt));
            var result = _queryChain.Execute<T>(request);
            verplichteWaardeOntbreekt = (bool?)request.GetParameterValue("@VerplichteWaardeOntbreekt");
            return result;
        }

        public virtual T CspAanleveringAktieLogI01<T>(int? gebruikerId, int? aktieId, int? aanleveringId, DateTime? datum) where T : SqlResponse
        {
            var request = new SqlRequest("dbo", "csp_AanleveringAktieLog_i01");
            request.Parameters.Add(new StoredProcedureSimpleParameter("@AanleveringId", "int", ParameterDirection.Input, aanleveringId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@AktieId", "int", ParameterDirection.Input, aktieId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@Datum", "datetime2", ParameterDirection.Input, datum));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@GebruikerId", "int", ParameterDirection.Input, gebruikerId));
            var result = _queryChain.Execute<T>(request);
            return result;
        }

        public virtual T CspAanleveringAktieLogS01<T>(int? aanleveringId) where T : SqlResponse
        {
            var request = new SqlRequest("dbo", "csp_AanleveringAktieLog_s01");
            request.Parameters.Add(new StoredProcedureSimpleParameter("@AanleveringId", "int", ParameterDirection.Input, aanleveringId));
            var result = _queryChain.Execute<T>(request);
            return result;
        }

        public virtual T CspAanleveringWaardeS01<T>(int? aanleveringId, int? zorgverzekeraarId, int? zorgverstrekkerId, int? aanleverInputId) where T : SqlResponse
        {
            var request = new SqlRequest("dbo", "csp_AanleveringWaarde_s01");
            request.Parameters.Add(new StoredProcedureSimpleParameter("@AanleveringId", "int", ParameterDirection.Input, aanleveringId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@AanleverInputId", "int", ParameterDirection.Input, aanleverInputId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerId", "int", ParameterDirection.Input, zorgverstrekkerId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", "int", ParameterDirection.Input, zorgverzekeraarId));
            var result = _queryChain.Execute<T>(request);
            return result;
        }

        public virtual T CspAanleverVerzoekS01<T>(int? jaar, int? zorgsoortId, int? zorgverzekeraarId) where T : SqlResponse
        {
            var request = new SqlRequest("dbo", "csp_AanleverVerzoek_s01");
            request.Parameters.Add(new StoredProcedureSimpleParameter("@Jaar", "int", ParameterDirection.Input, jaar));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgsoortId", "int", ParameterDirection.Input, zorgsoortId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", "int", ParameterDirection.Input, zorgverzekeraarId));
            var result = _queryChain.Execute<T>(request);
            return result;
        }

        public virtual T CspAanleverVerzoekS02<T>(int? zorgverstrekkerId, int? zorgsoortId, int? jaar) where T : SqlResponse
        {
            var request = new SqlRequest("dbo", "csp_AanleverVerzoek_s02");
            request.Parameters.Add(new StoredProcedureSimpleParameter("@Jaar", "int", ParameterDirection.Input, jaar));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgsoortId", "int", ParameterDirection.Input, zorgsoortId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerId", "int", ParameterDirection.Input, zorgverstrekkerId));
            var result = _queryChain.Execute<T>(request);
            return result;
        }

        public virtual T CspAanleverVerzoekS03<T>(IEnumerable<Database.UserDefinedTypes.Dbo.UdtIds> aanleverVerzoekConfiguratieIds) where T : SqlResponse
        {
            var request = new SqlRequest("dbo", "csp_AanleverVerzoek_s03");
            request.Parameters.Add(new StoredProcedureTableTypeParameter("@AanleverVerzoekConfiguratieIds", "table type", ParameterDirection.Input, "dbo", "udtIds", aanleverVerzoekConfiguratieIds));
            var result = _queryChain.Execute<T>(request);
            return result;
        }

        public virtual T CspAanleverVerzoekS04<T>(int? zorgverzekeraarId, int? zorgsoortId, int? jaar, int? aanleverVerzoekId) where T : SqlResponse
        {
            var request = new SqlRequest("dbo", "csp_AanleverVerzoek_s04");
            request.Parameters.Add(new StoredProcedureSimpleParameter("@AanleverVerzoekId", "int", ParameterDirection.Input, aanleverVerzoekId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@Jaar", "int", ParameterDirection.Input, jaar));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgsoortId", "int", ParameterDirection.Input, zorgsoortId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", "int", ParameterDirection.Input, zorgverzekeraarId));
            var result = _queryChain.Execute<T>(request);
            return result;
        }

        public virtual T CspAanleverVerzoekConfiguratieS01<T>(int? aanleverVerzoekConfiguratieId, int? zorgsoortId, int? jaar, int? zorgverzekeraarId, int? aanleverVerzoekId) where T : SqlResponse
        {
            var request = new SqlRequest("dbo", "csp_AanleverVerzoekConfiguratie_s01");
            request.Parameters.Add(new StoredProcedureSimpleParameter("@AanleverVerzoekConfiguratieId", "int", ParameterDirection.Input, aanleverVerzoekConfiguratieId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@AanleverVerzoekId", "int", ParameterDirection.Input, aanleverVerzoekId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@Jaar", "int", ParameterDirection.Input, jaar));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgsoortId", "int", ParameterDirection.Input, zorgsoortId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", "int", ParameterDirection.Input, zorgverzekeraarId));
            var result = _queryChain.Execute<T>(request);
            return result;
        }

        public virtual T CspAanleververzoekConfiguratieJarenS01<T>(int? zorgsoortId, int? zorgverzekeraarId) where T : SqlResponse
        {
            var request = new SqlRequest("dbo", "csp_AanleververzoekConfiguratieJaren_s01");
            request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgsoortId", "int", ParameterDirection.Input, zorgsoortId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", "int", ParameterDirection.Input, zorgverzekeraarId));
            var result = _queryChain.Execute<T>(request);
            return result;
        }

        public virtual T CspAanleververzoekConfiguratieZorgsoortenS01<T>(int? zorgverzekeraarId) where T : SqlResponse
        {
            var request = new SqlRequest("dbo", "csp_AanleververzoekConfiguratieZorgsoorten_s01");
            request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", "int", ParameterDirection.Input, zorgverzekeraarId));
            var result = _queryChain.Execute<T>(request);
            return result;
        }

        public virtual T CspAanleververzoekFrequentieS01<T>(int? jaar, int? zorgsoortId, int? zorgverzekeraarId) where T : SqlResponse
        {
            var request = new SqlRequest("dbo", "csp_AanleververzoekFrequentie_s01");
            request.Parameters.Add(new StoredProcedureSimpleParameter("@Jaar", "int", ParameterDirection.Input, jaar));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgsoortId", "int", ParameterDirection.Input, zorgsoortId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", "int", ParameterDirection.Input, zorgverzekeraarId));
            var result = _queryChain.Execute<T>(request);
            return result;
        }

        public virtual T CspAanleverVerzoekStatusS01<T>(int? zorgverzekeraarId, int? zorgverstrekkerId, int? zorgsoortId, int? jaar, int? aanleverVerzoekId, int? aanleverFrequentieId, DateTime? peildatum, int? aanleverVerzoekConfiguratieId) where T : SqlResponse
        {
            var request = new SqlRequest("dbo", "csp_AanleverVerzoekStatus_s01");
            request.Parameters.Add(new StoredProcedureSimpleParameter("@AanleverFrequentieId", "int", ParameterDirection.Input, aanleverFrequentieId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@AanleverVerzoekConfiguratieId", "int", ParameterDirection.Input, aanleverVerzoekConfiguratieId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@AanleverVerzoekId", "int", ParameterDirection.Input, aanleverVerzoekId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@Jaar", "int", ParameterDirection.Input, jaar));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@Peildatum", "datetime2", ParameterDirection.Input, peildatum));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgsoortId", "int", ParameterDirection.Input, zorgsoortId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerId", "int", ParameterDirection.Input, zorgverstrekkerId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", "int", ParameterDirection.Input, zorgverzekeraarId));
            var result = _queryChain.Execute<T>(request);
            return result;
        }

        public virtual T CspAanleverVerzoekStatusS02<T>(int? zorgverzekeraarId, int? zorgverstrekkerId, int? zorgsoortId, int? jaar, int? aanleverVerzoekId, DateTime? peildatum, int? aanleverVerzoekConfiguratieId) where T : SqlResponse
        {
            var request = new SqlRequest("dbo", "csp_AanleverVerzoekStatus_s02");
            request.Parameters.Add(new StoredProcedureSimpleParameter("@AanleverVerzoekConfiguratieId", "int", ParameterDirection.Input, aanleverVerzoekConfiguratieId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@AanleverVerzoekId", "int", ParameterDirection.Input, aanleverVerzoekId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@Jaar", "int", ParameterDirection.Input, jaar));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@Peildatum", "datetime2", ParameterDirection.Input, peildatum));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgsoortId", "int", ParameterDirection.Input, zorgsoortId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerId", "int", ParameterDirection.Input, zorgverstrekkerId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", "int", ParameterDirection.Input, zorgverzekeraarId));
            var result = _queryChain.Execute<T>(request);
            return result;
        }

        public virtual T CspAanleverVerzoekStatusS03<T>(int? zorgverzekeraarId, int? zorgverstrekkerId, int? aanleververzoekId, int? zorgsoortId, int? jaar, DateTime? peilDatum, bool? includeBestandsData) where T : SqlResponse
        {
            var request = new SqlRequest("dbo", "csp_AanleverVerzoekStatus_s03");
            request.Parameters.Add(new StoredProcedureSimpleParameter("@AanleververzoekId", "int", ParameterDirection.Input, aanleververzoekId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@IncludeBestandsData", "bit", ParameterDirection.Input, includeBestandsData));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@Jaar", "int", ParameterDirection.Input, jaar));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@PeilDatum", "datetime2", ParameterDirection.Input, peilDatum));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgsoortId", "int", ParameterDirection.Input, zorgsoortId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerId", "int", ParameterDirection.Input, zorgverstrekkerId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", "int", ParameterDirection.Input, zorgverzekeraarId));
            var result = _queryChain.Execute<T>(request);
            return result;
        }

        public virtual T CspAanvullendeInformatieS01<T>(int? aanleverVerzoekConfiguratieId) where T : SqlResponse
        {
            var request = new SqlRequest("dbo", "csp_AanvullendeInformatie_s01");
            request.Parameters.Add(new StoredProcedureSimpleParameter("@AanleverVerzoekConfiguratieId", "int", ParameterDirection.Input, aanleverVerzoekConfiguratieId));
            var result = _queryChain.Execute<T>(request);
            return result;
        }

        public virtual T CspZorgverstrekkerAanleverConfiguratieI01<T>(IEnumerable<Database.UserDefinedTypes.Dbo.UdtZorgverstrekkerAanleverConfiguratieItem> zorgverstrekkerAanleverConfiguratieItems) where T : SqlResponse
        {
            var request = new SqlRequest("dbo", "csp_ZorgverstrekkerAanleverConfiguratie_i01");
            request.Parameters.Add(new StoredProcedureTableTypeParameter("@ZorgverstrekkerAanleverConfiguratieItems", "table type", ParameterDirection.Input, "dbo", "udtZorgverstrekkerAanleverConfiguratieItem", zorgverstrekkerAanleverConfiguratieItems));
            var result = _queryChain.Execute<T>(request);
            return result;
        }

        public virtual T CspZorgverstrekkerAanleverConfiguratieS01<T>(int? jaar, int? zorgsoort, int? zorgverzekeraarId) where T : SqlResponse
        {
            var request = new SqlRequest("dbo", "csp_ZorgverstrekkerAanleverConfiguratie_s01");
            request.Parameters.Add(new StoredProcedureSimpleParameter("@Jaar", "int", ParameterDirection.Input, jaar));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@Zorgsoort", "int", ParameterDirection.Input, zorgsoort));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", "int", ParameterDirection.Input, zorgverzekeraarId));
            var result = _queryChain.Execute<T>(request);
            return result;
        }

        public virtual T CspZorgverstrekkerAanleverConfiguratieS02<T>(int? zorgverstrekkerId) where T : SqlResponse
        {
            var request = new SqlRequest("dbo", "csp_ZorgverstrekkerAanleverConfiguratie_s02");
            request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerId", "int", ParameterDirection.Input, zorgverstrekkerId));
            var result = _queryChain.Execute<T>(request);
            return result;
        }

        public virtual T CspZorgverstrekkerAanleverConfiguratieS03<T>(int? zorgsoortId, int? zorgverstrekkerId) where T : SqlResponse
        {
            var request = new SqlRequest("dbo", "csp_ZorgverstrekkerAanleverConfiguratie_s03");
            request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgsoortId", "int", ParameterDirection.Input, zorgsoortId));
            request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerId", "int", ParameterDirection.Input, zorgverstrekkerId));
            var result = _queryChain.Execute<T>(request);
            return result;
        }

        public virtual T CspZorgverzekeraarInformatieS01<T>(IEnumerable<Database.UserDefinedTypes.Dbo.UdtIds> zorgverzekeraarIds) where T : SqlResponse
        {
            var request = new SqlRequest("dbo", "csp_ZorgverzekeraarInformatie_s01");
            request.Parameters.Add(new StoredProcedureTableTypeParameter("@ZorgverzekeraarIds", "table type", ParameterDirection.Input, "dbo", "udtIds", zorgverzekeraarIds));
            var result = _queryChain.Execute<T>(request);
            return result;
        }

        public virtual T CspPeriodeDatumsS01<T>() where T : SqlResponse
        {
            var request = new SqlRequest("dbo", "csp_PeriodeDatums_s01");
            var result = _queryChain.Execute<T>(request);
            return result;
        }

        public virtual T TestDataMarker<T>() where T : SqlResponse
        {
            var request = new SqlRequest("dbo", "TestDataMarker");
            var result = _queryChain.Execute<T>(request);
            return result;
        }
    }

    #endregion
}
