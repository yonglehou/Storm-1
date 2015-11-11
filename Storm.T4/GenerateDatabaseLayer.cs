using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Flyingpie.Storm;
using Flyingpie.Storm.Execution;
using Flyingpie.Storm.Execution.Parameters;

namespace Database
{
	#region User Defined Types

	namespace UserDefinedTypes
	{
		namespace Data
		{
			[GeneratedCode("Flyingpie.Storm", "1.0.0.0")]
			public partial class UdtCommonNames
			{
				public string CommonName { get; set; }
			}

			[GeneratedCode("Flyingpie.Storm", "1.0.0.0")]
			public partial class UdtIds
			{
				public int? Id { get; set; }
			}
		}
	}

	#endregion

	#region Interfaces

	[GeneratedCode("Flyingpie.Storm", "1.0.0.0")]
	public interface IData
	{
		ISqlRequest CspGebruikerRolI01(int? gebruikerId, int? rolId, DateTime? startdatum, DateTime? einddatum);
		ISqlRequest CspGebruikerInstantieI01(int? gebruikerId, int? instantieId, DateTime? startdatum, DateTime? einddatum, string koppelingVoorgesteldDoor, DateTime? koppelingVoorgesteldOp, string koppelingGeaccepteerdDoor, DateTime? koppelingGeaccepteerdOp, string createUser);
		ISqlRequest CspGebruikerS02(IEnumerable<Database.UserDefinedTypes.Data.UdtIds> gebruikerIds);
		ISqlRequest CspZorgSoortS02(int? instantieId, int? applicatieId);
		ISqlRequest CspGebruikerRolS01(int? gebruikerId, string commonName, int? applicatieId, DateTime? peilDatum);
		ISqlRequest CspGebruikerS01(int? gebruikerId, string commonName, DateTime? peilDatum);
		ISqlRequest CspZorgSoortS01(int? instantieId);
		ISqlRequest CspGebruikerS03(IEnumerable<Database.UserDefinedTypes.Data.UdtCommonNames> commonNames);
		ISqlRequest CspZorgSoortS03(int? instantieId);
		ISqlRequest CspInstantieGetByNaam(string naam, int? instantieTypeId);
		ISqlRequest CspIsGeldigeAgbCode(string agbCode);
		ISqlRequest CspGebruikerI01(int? gebruikerId, string commonName, DateTime? startdatum, DateTime? einddatum, string achterNaam, string tussenvoegsel, string voorNaam, string email);
		ISqlRequest CspInstantieI01(int? instantieId, int? instantieTypeId, int? instantieSubTypeId, string uzovi, string agbsoort, string agbnummer, DateTime? startdatum, DateTime? einddatum, string naam, string adres, string postcode, string plaats, string landcode, string telefoonNummer, string email, string website, int? ctgcode, int? ctgnummer, int? nzacode, int? kvkNummer, bool? openbareInschrijving);
		ISqlRequest CspInstantieS05(int? gebruikerId, IEnumerable<Database.UserDefinedTypes.Data.UdtIds> zorgSoortIds);
		ISqlRequest CspInstantieS03(IEnumerable<Database.UserDefinedTypes.Data.UdtIds> instantieIds);
		ISqlRequest CspInstantieS02(int? gebruikerId, DateTime? peilDatum);
		ISqlRequest CspInstantieS01(int? zorgSoortId, int? peilJaar, int? instantieSoortId, int? instantieTypeId, int? instantieSubTypeId, string agbSoort);
		ISqlRequest CspGebruikerIdsS01();
		ISqlRequest CspInstantieS10(int? instantieSoortId, int? zorgSoortId, int? zorgsoortJaar, bool? inclusiefOpenbareInschrijvingen);
		ISqlRequest CspInstantieS09(int? instantieSoortId, int? zorgSoortId, int? zorgsoortJaar, DateTime? instantiePeilDatum, bool? inclusiefOpenbareInschrijvingen);
		ISqlRequest CspBeheercertificatenKoppelenI01();
		ISqlRequest CspInstantieRelatieS01(int? instantieId, DateTime? peilDatum);
		ISqlRequest CspInstantieS08(int? instantieId, int? instantieId2, string instantieRelatieType, DateTime? peilDatum);
		ISqlRequest CspInstantieS07(int? zorgverzekeraarId, int? zorgverstrekkerId, DateTime? begindatumPeriode, DateTime? einddatumPeriode, int? zorgSoortId, bool? inclusiefOpenbareInschrijvingen);
		ISqlRequest CspInstantieS06(string uzovi, string agb, int? zorgsoortId, int? instantieSubTypeId);
		ISqlRequest CspInstantieS04(int? gebruikerId, IEnumerable<Database.UserDefinedTypes.Data.UdtIds> zorgSoortIds, bool? ignoreZorgSoortFilterForOpenbareInschrijvingInstanties, string instantieCodeFilter, string instantieNaamFilter);
		ISqlRequest CspInstantieGebruikerS01(int? applicatieId, int? zorgsoortId, IEnumerable<Database.UserDefinedTypes.Data.UdtIds> instantieIds, string rolOmschrijving, string excludeRolOmschrijving, DateTime? peilDatum);
		ISqlRequest CspGebruikerTaakS01(int? gebruikerId, string commonName, int? applicatieId, DateTime? peilDatum);
		ISqlRequest CspMultipleResults(int? id, string name);
		ISqlRequest CspWithOutputParameter(OutputParameter<int?> id);
		ISqlRequest CspWithMultipleResultSets(int? id);
	}

	#endregion

	#region Classes

	[GeneratedCode("Flyingpie.Storm", "1.0.0.0")]
	public partial class Data : IData
	{
		private IQueryChain _queryChain;
		public Data(IQueryChain queryChain)
		{
			_queryChain = queryChain;
		}

		public virtual ISqlRequest CspGebruikerRolI01(int? gebruikerId, int? rolId, DateTime? startdatum, DateTime? einddatum)
		{
			var request = new SqlRequest(_queryChain, "data", "csp_GebruikerRol_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Einddatum", "datetime", ParameterDirection.Input, einddatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GebruikerID", "int", ParameterDirection.Input, gebruikerId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@RolID", "int", ParameterDirection.Input, rolId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Startdatum", "datetime", ParameterDirection.Input, startdatum));
			return request;
		}

		public virtual ISqlRequest CspGebruikerInstantieI01(int? gebruikerId, int? instantieId, DateTime? startdatum, DateTime? einddatum, string koppelingVoorgesteldDoor, DateTime? koppelingVoorgesteldOp, string koppelingGeaccepteerdDoor, DateTime? koppelingGeaccepteerdOp, string createUser)
		{
			var request = new SqlRequest(_queryChain, "data", "csp_GebruikerInstantie_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CreateUser", "varchar", ParameterDirection.Input, createUser));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Einddatum", "datetime", ParameterDirection.Input, einddatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GebruikerID", "int", ParameterDirection.Input, gebruikerId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", "int", ParameterDirection.Input, instantieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@KoppelingGeaccepteerdDoor", "varchar", ParameterDirection.Input, koppelingGeaccepteerdDoor));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@KoppelingGeaccepteerdOp", "datetime", ParameterDirection.Input, koppelingGeaccepteerdOp));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@KoppelingVoorgesteldDoor", "varchar", ParameterDirection.Input, koppelingVoorgesteldDoor));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@KoppelingVoorgesteldOp", "datetime", ParameterDirection.Input, koppelingVoorgesteldOp));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Startdatum", "datetime", ParameterDirection.Input, startdatum));
			return request;
		}

		public virtual ISqlRequest CspGebruikerS02(IEnumerable<Database.UserDefinedTypes.Data.UdtIds> gebruikerIds)
		{
			var request = new SqlRequest(_queryChain, "data", "csp_Gebruiker_s02");
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@GebruikerIDs", "table type", ParameterDirection.Input, "data", "udtIds", gebruikerIds));
			return request;
		}

		public virtual ISqlRequest CspZorgSoortS02(int? instantieId, int? applicatieId)
		{
			var request = new SqlRequest(_queryChain, "data", "csp_ZorgSoort_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ApplicatieID", "int", ParameterDirection.Input, applicatieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", "int", ParameterDirection.Input, instantieId));
			return request;
		}

		public virtual ISqlRequest CspGebruikerRolS01(int? gebruikerId, string commonName, int? applicatieId, DateTime? peilDatum)
		{
			var request = new SqlRequest(_queryChain, "data", "csp_GebruikerRol_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ApplicatieID", "int", ParameterDirection.Input, applicatieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CommonName", "varchar", ParameterDirection.Input, commonName));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GebruikerID", "int", ParameterDirection.Input, gebruikerId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeilDatum", "datetime", ParameterDirection.Input, peilDatum));
			return request;
		}

		public virtual ISqlRequest CspGebruikerS01(int? gebruikerId, string commonName, DateTime? peilDatum)
		{
			var request = new SqlRequest(_queryChain, "data", "csp_Gebruiker_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CommonName", "varchar", ParameterDirection.Input, commonName));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GebruikerID", "int", ParameterDirection.Input, gebruikerId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeilDatum", "datetime", ParameterDirection.Input, peilDatum));
			return request;
		}

		public virtual ISqlRequest CspZorgSoortS01(int? instantieId)
		{
			var request = new SqlRequest(_queryChain, "data", "csp_ZorgSoort_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", "int", ParameterDirection.Input, instantieId));
			return request;
		}

		public virtual ISqlRequest CspGebruikerS03(IEnumerable<Database.UserDefinedTypes.Data.UdtCommonNames> commonNames)
		{
			var request = new SqlRequest(_queryChain, "data", "csp_Gebruiker_s03");
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@CommonNames", "table type", ParameterDirection.Input, "data", "udtCommonNames", commonNames));
			return request;
		}

		public virtual ISqlRequest CspZorgSoortS03(int? instantieId)
		{
			var request = new SqlRequest(_queryChain, "data", "csp_ZorgSoort_s03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", "int", ParameterDirection.Input, instantieId));
			return request;
		}

		public virtual ISqlRequest CspInstantieGetByNaam(string naam, int? instantieTypeId)
		{
			var request = new SqlRequest(_queryChain, "data", "csp_Instantie_GetByNaam");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieTypeID", "int", ParameterDirection.Input, instantieTypeId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Naam", "nvarchar", ParameterDirection.Input, naam));
			return request;
		}

		public virtual ISqlRequest CspIsGeldigeAgbCode(string agbCode)
		{
			var request = new SqlRequest(_queryChain, "data", "csp_IsGeldigeAgbCode");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AgbCode", "nvarchar", ParameterDirection.Input, agbCode));
			return request;
		}

		public virtual ISqlRequest CspGebruikerI01(int? gebruikerId, string commonName, DateTime? startdatum, DateTime? einddatum, string achterNaam, string tussenvoegsel, string voorNaam, string email)
		{
			var request = new SqlRequest(_queryChain, "data", "csp_Gebruiker_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AchterNaam", "varchar", ParameterDirection.Input, achterNaam));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CommonName", "varchar", ParameterDirection.Input, commonName));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Einddatum", "datetime", ParameterDirection.Input, einddatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Email", "varchar", ParameterDirection.Input, email));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GebruikerID", "int", ParameterDirection.Input, gebruikerId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Startdatum", "datetime", ParameterDirection.Input, startdatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Tussenvoegsel", "varchar", ParameterDirection.Input, tussenvoegsel));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@VoorNaam", "varchar", ParameterDirection.Input, voorNaam));
			return request;
		}

		public virtual ISqlRequest CspInstantieI01(int? instantieId, int? instantieTypeId, int? instantieSubTypeId, string uzovi, string agbsoort, string agbnummer, DateTime? startdatum, DateTime? einddatum, string naam, string adres, string postcode, string plaats, string landcode, string telefoonNummer, string email, string website, int? ctgcode, int? ctgnummer, int? nzacode, int? kvkNummer, bool? openbareInschrijving)
		{
			var request = new SqlRequest(_queryChain, "data", "csp_Instantie_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Adres", "nvarchar", ParameterDirection.Input, adres));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AGBNummer", "char", ParameterDirection.Input, agbnummer));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AGBSoort", "char", ParameterDirection.Input, agbsoort));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CTGCode", "int", ParameterDirection.Input, ctgcode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CTGNummer", "int", ParameterDirection.Input, ctgnummer));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Einddatum", "datetime", ParameterDirection.Input, einddatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Email", "varchar", ParameterDirection.Input, email));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", "int", ParameterDirection.Input, instantieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieSubTypeID", "int", ParameterDirection.Input, instantieSubTypeId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieTypeID", "int", ParameterDirection.Input, instantieTypeId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@KvkNummer", "int", ParameterDirection.Input, kvkNummer));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Landcode", "char", ParameterDirection.Input, landcode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Naam", "nvarchar", ParameterDirection.Input, naam));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@NZACode", "int", ParameterDirection.Input, nzacode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OpenbareInschrijving", "bit", ParameterDirection.Input, openbareInschrijving));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Plaats", "nvarchar", ParameterDirection.Input, plaats));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Postcode", "varchar", ParameterDirection.Input, postcode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Startdatum", "datetime", ParameterDirection.Input, startdatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@TelefoonNummer", "varchar", ParameterDirection.Input, telefoonNummer));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@UZOVI", "char", ParameterDirection.Input, uzovi));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Website", "varchar", ParameterDirection.Input, website));
			return request;
		}

		public virtual ISqlRequest CspInstantieS05(int? gebruikerId, IEnumerable<Database.UserDefinedTypes.Data.UdtIds> zorgSoortIds)
		{
			var request = new SqlRequest(_queryChain, "data", "csp_Instantie_s05");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GebruikerID", "int", ParameterDirection.Input, gebruikerId));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@ZorgSoortIDs", "table type", ParameterDirection.Input, "data", "udtIds", zorgSoortIds));
			return request;
		}

		public virtual ISqlRequest CspInstantieS03(IEnumerable<Database.UserDefinedTypes.Data.UdtIds> instantieIds)
		{
			var request = new SqlRequest(_queryChain, "data", "csp_Instantie_s03");
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@InstantieIDs", "table type", ParameterDirection.Input, "data", "udtIds", instantieIds));
			return request;
		}

		public virtual ISqlRequest CspInstantieS02(int? gebruikerId, DateTime? peilDatum)
		{
			var request = new SqlRequest(_queryChain, "data", "csp_Instantie_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GebruikerID", "int", ParameterDirection.Input, gebruikerId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeilDatum", "datetime", ParameterDirection.Input, peilDatum));
			return request;
		}

		public virtual ISqlRequest CspInstantieS01(int? zorgSoortId, int? peilJaar, int? instantieSoortId, int? instantieTypeId, int? instantieSubTypeId, string agbSoort)
		{
			var request = new SqlRequest(_queryChain, "data", "csp_Instantie_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AgbSoort", "char", ParameterDirection.Input, agbSoort));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieSoortID", "int", ParameterDirection.Input, instantieSoortId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieSubTypeID", "int", ParameterDirection.Input, instantieSubTypeId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieTypeID", "int", ParameterDirection.Input, instantieTypeId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeilJaar", "int", ParameterDirection.Input, peilJaar));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgSoortID", "int", ParameterDirection.Input, zorgSoortId));
			return request;
		}

		public virtual ISqlRequest CspGebruikerIdsS01()
		{
			var request = new SqlRequest(_queryChain, "data", "csp_GebruikerIds_s01");
			return request;
		}

		public virtual ISqlRequest CspInstantieS10(int? instantieSoortId, int? zorgSoortId, int? zorgsoortJaar, bool? inclusiefOpenbareInschrijvingen)
		{
			var request = new SqlRequest(_queryChain, "data", "csp_Instantie_s10");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InclusiefOpenbareInschrijvingen", "bit", ParameterDirection.Input, inclusiefOpenbareInschrijvingen));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieSoortID", "int", ParameterDirection.Input, instantieSoortId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgSoortID", "int", ParameterDirection.Input, zorgSoortId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgsoortJaar", "int", ParameterDirection.Input, zorgsoortJaar));
			return request;
		}

		public virtual ISqlRequest CspInstantieS09(int? instantieSoortId, int? zorgSoortId, int? zorgsoortJaar, DateTime? instantiePeilDatum, bool? inclusiefOpenbareInschrijvingen)
		{
			var request = new SqlRequest(_queryChain, "data", "csp_Instantie_s09");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InclusiefOpenbareInschrijvingen", "bit", ParameterDirection.Input, inclusiefOpenbareInschrijvingen));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantiePeilDatum", "datetime", ParameterDirection.Input, instantiePeilDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieSoortID", "int", ParameterDirection.Input, instantieSoortId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgSoortID", "int", ParameterDirection.Input, zorgSoortId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgsoortJaar", "int", ParameterDirection.Input, zorgsoortJaar));
			return request;
		}

		public virtual ISqlRequest CspBeheercertificatenKoppelenI01()
		{
			var request = new SqlRequest(_queryChain, "data", "csp_BeheercertificatenKoppelen_i01");
			return request;
		}

		public virtual ISqlRequest CspInstantieRelatieS01(int? instantieId, DateTime? peilDatum)
		{
			var request = new SqlRequest(_queryChain, "data", "csp_InstantieRelatie_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", "int", ParameterDirection.Input, instantieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeilDatum", "datetime", ParameterDirection.Input, peilDatum));
			return request;
		}

		public virtual ISqlRequest CspInstantieS08(int? instantieId, int? instantieId2, string instantieRelatieType, DateTime? peilDatum)
		{
			var request = new SqlRequest(_queryChain, "data", "csp_Instantie_s08");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", "int", ParameterDirection.Input, instantieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID2", "int", ParameterDirection.Input, instantieId2));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieRelatieType", "varchar", ParameterDirection.Input, instantieRelatieType));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeilDatum", "datetime", ParameterDirection.Input, peilDatum));
			return request;
		}

		public virtual ISqlRequest CspInstantieS07(int? zorgverzekeraarId, int? zorgverstrekkerId, DateTime? begindatumPeriode, DateTime? einddatumPeriode, int? zorgSoortId, bool? inclusiefOpenbareInschrijvingen)
		{
			var request = new SqlRequest(_queryChain, "data", "csp_Instantie_s07");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BegindatumPeriode", "date", ParameterDirection.Input, begindatumPeriode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@EinddatumPeriode", "date", ParameterDirection.Input, einddatumPeriode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InclusiefOpenbareInschrijvingen", "bit", ParameterDirection.Input, inclusiefOpenbareInschrijvingen));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgSoortID", "int", ParameterDirection.Input, zorgSoortId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerId", "int", ParameterDirection.Input, zorgverstrekkerId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", "int", ParameterDirection.Input, zorgverzekeraarId));
			return request;
		}

		public virtual ISqlRequest CspInstantieS06(string uzovi, string agb, int? zorgsoortId, int? instantieSubTypeId)
		{
			var request = new SqlRequest(_queryChain, "data", "csp_Instantie_s06");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@agb", "char", ParameterDirection.Input, agb));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@instantieSubTypeId", "int", ParameterDirection.Input, instantieSubTypeId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@uzovi", "char", ParameterDirection.Input, uzovi));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@zorgsoortId", "int", ParameterDirection.Input, zorgsoortId));
			return request;
		}

		public virtual ISqlRequest CspInstantieS04(int? gebruikerId, IEnumerable<Database.UserDefinedTypes.Data.UdtIds> zorgSoortIds, bool? ignoreZorgSoortFilterForOpenbareInschrijvingInstanties, string instantieCodeFilter, string instantieNaamFilter)
		{
			var request = new SqlRequest(_queryChain, "data", "csp_Instantie_s04");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GebruikerID", "int", ParameterDirection.Input, gebruikerId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@IgnoreZorgSoortFilterForOpenbareInschrijvingInstanties", "bit", ParameterDirection.Input, ignoreZorgSoortFilterForOpenbareInschrijvingInstanties));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieCodeFilter", "varchar", ParameterDirection.Input, instantieCodeFilter));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieNaamFilter", "varchar", ParameterDirection.Input, instantieNaamFilter));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@ZorgSoortIDs", "table type", ParameterDirection.Input, "data", "udtIds", zorgSoortIds));
			return request;
		}

		public virtual ISqlRequest CspInstantieGebruikerS01(int? applicatieId, int? zorgsoortId, IEnumerable<Database.UserDefinedTypes.Data.UdtIds> instantieIds, string rolOmschrijving, string excludeRolOmschrijving, DateTime? peilDatum)
		{
			var request = new SqlRequest(_queryChain, "data", "csp_InstantieGebruiker_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ApplicatieID", "int", ParameterDirection.Input, applicatieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ExcludeRolOmschrijving", "varchar", ParameterDirection.Input, excludeRolOmschrijving));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@InstantieIDs", "table type", ParameterDirection.Input, "data", "udtIds", instantieIds));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeilDatum", "datetime", ParameterDirection.Input, peilDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@RolOmschrijving", "varchar", ParameterDirection.Input, rolOmschrijving));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgsoortID", "int", ParameterDirection.Input, zorgsoortId));
			return request;
		}

		public virtual ISqlRequest CspGebruikerTaakS01(int? gebruikerId, string commonName, int? applicatieId, DateTime? peilDatum)
		{
			var request = new SqlRequest(_queryChain, "data", "csp_GebruikerTaak_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ApplicatieID", "int", ParameterDirection.Input, applicatieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CommonName", "varchar", ParameterDirection.Input, commonName));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GebruikerID", "int", ParameterDirection.Input, gebruikerId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeilDatum", "datetime", ParameterDirection.Input, peilDatum));
			return request;
		}

		public virtual ISqlRequest CspMultipleResults(int? id, string name)
		{
			var request = new SqlRequest(_queryChain, "data", "csp_MultipleResults");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Id", "int", ParameterDirection.Input, id));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Name", "nvarchar", ParameterDirection.Input, name));
			return request;
		}

		public virtual ISqlRequest CspWithOutputParameter(OutputParameter<int?> id)
		{
			var request = new SqlRequest(_queryChain, "data", "csp_WithOutputParameter");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Id", "int", ParameterDirection.InputOutput, id));
			return request;
		}

		public virtual ISqlRequest CspWithMultipleResultSets(int? id)
		{
			var request = new SqlRequest(_queryChain, "data", "csp_WithMultipleResultSets");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Id", "int", ParameterDirection.Input, id));
			return request;
		}
	}

	#endregion
}
