using System;
using System.Collections.Generic;
using Flyingpie.Storm.Lib;

namespace Database
{
	#region User Defined Types

	namespace UserDefinedTypes
	{
		namespace Afspraak
		{
			public class udtPrestatieInfoTable
			{
				public int? PrestatieId { get; set; }
				public int? VolumeComponent1 { get; set; }
				public int? VolumeComponent2 { get; set; }
				public int? VolumeComponent3 { get; set; }
				public bool? Ingesloten { get; set; }
			}

			public class udt_GGZPrijslijstTable
			{
				public int? AantalRegNHC { get; set; }
				public int? AantalVerblijf { get; set; }
				public int? AantalAmbulant { get; set; }
				public int? AantalBasisGGZ { get; set; }
				public int? AantalDeelprestaties { get; set; }
				public int? AantalMetBev2 { get; set; }
				public int? AantalMetBev3 { get; set; }
				public int? AantalMetPMU { get; set; }
				public int? PrestatieID { get; set; }
				public decimal? TariefPMU { get; set; }
				public decimal? Tarief { get; set; }
				public decimal? TariefBev2 { get; set; }
				public decimal? TariefBev3 { get; set; }
				public decimal? TariefExclNHC { get; set; }
				public decimal? TariefNHC { get; set; }
				public char? DeclaratieCode { get; set; }
			}

			public class udtInstantiePeriodeTable
			{
				public DateTime BeginDatum { get; set; }
				public DateTime EindDatum { get; set; }
				public int? InstantieID { get; set; }
			}

			public class udtOnderhandenWerkComponentenTable
			{
				public int? ZorgverzekeraarId { get; set; }
				public object Percentage { get; set; }
			}
		}

		namespace Analyse
		{
			public class udtUpdateBehandelingZwarteLijst
			{
				public int? ZorgverstrekkerId { get; set; }
				public int? PeriodeId { get; set; }
				public int? BehandelingId { get; set; }
				public int? UitsluitingId { get; set; }
			}

			public class udtZorgverstrekkerBudget
			{
				public int? CategorieId { get; set; }
				public int? ZorgSoortId { get; set; }
				public int? OmzetAfspraakSoortId { get; set; }
				public int? ZorgverzekeraarId { get; set; }
				public int? ZorgverstrekkerId { get; set; }
				public int? PeriodeId { get; set; }
				public int? RegioId { get; set; }
				public decimal? BudgetTotaal { get; set; }
				public decimal? ExternContractTotaal { get; set; }
				public decimal? OmzetPlafond { get; set; }
				public decimal? MandaatTotaal { get; set; }
				public decimal? OmzetAfspraak { get; set; }
				public decimal? PrijsAfspraak { get; set; }
				public bool? OnderhandenWerk { get; set; }
				public bool? NietInAutoModelcontract { get; set; }
				public bool? Contracteerbaar { get; set; }
				public string Inkoper { get; set; }
				public string OnderhandenWerkMailadres { get; set; }
				public string Contractnummer { get; set; }
				public string IPZReferentie { get; set; }
				public string PrijsAfspraakOmschrijving { get; set; }
			}
		}

		namespace DataStaging
		{
		}

		namespace Dbc
		{
		}

		namespace Help
		{
		}

		namespace Logs
		{
		}

		namespace Organisatie
		{
		}

		namespace Overig
		{
			public class udtDateTimeTable
			{
				public DateTime value { get; set; }
			}

			public class udtIntTable
			{
				public int? value { get; set; }
			}

			public class udtPeriodeTable
			{
				public DateTime StartDatum { get; set; }
				public DateTime EindDatum { get; set; }
			}

			public class udtVarCharTable
			{
				public string value { get; set; }
			}
		}

		namespace Rapportage
		{
		}

		namespace Tarief
		{
			public class udtTariefPrijslijst
			{
				public int? Volume { get; set; }
				public decimal? Prijs { get; set; }
				public string DeclaratieCode { get; set; }
				public string ZorgproductCode { get; set; }
			}
		}

		namespace Vergelijking
		{
		}
	}

	#endregion

	#region Interfaces

	public interface IAfspraak
	{
		T csp_PassantenTarief_d01<T>(int? CON_ID) where T : SqlResponse;
		T csp_Contract_s10<T>(int? AfspraakID, int? InstantieID) where T : SqlResponse;
		T csp_Onderhandeling_u15<T>(int? p_AfspraakId, int? p_InstantieId, string p_UserName) where T : SqlResponse;
		T csp_PassantenTarief_i02<T>(DateTime p_BeginDatum, DateTime p_EindDatum, int? p_identity, string p_Omschrijving, int? p_SubVersie, string p_username, int? p_Versie, int? p_ZVS_ID) where T : SqlResponse;
		T csp_Contract_s11<T>(int? CON_ID) where T : SqlResponse;
		T csp_Onderhandeling_u16<T>(int? p_AfspraakId, int? p_InstantieId, string p_UserName) where T : SqlResponse;
		T csp_PassantenTarief_s01<T>(bool? ActiveOnly, int? AfspraakStijl, int? InstantieID, DateTime MaximumBegindatum, char? segment) where T : SqlResponse;
		T csp_Contract_s12<T>(int? AfspraakID, char? p_Segment, int? p_ZorgverstrekkerID, int? p_ZorgverzekeraarID) where T : SqlResponse;
		T csp_OnderhandelingGroep_u02<T>(int? OnderhandelingAfspraakID) where T : SqlResponse;
		T csp_PrestatieComponentModel_d01<T>(int? p_MDL_ID) where T : SqlResponse;
		T csp_Contract_s13<T>(int? AfspraakID, int? AfspraakIDSjabloon, bool? Match) where T : SqlResponse;
		T csp_OnderhandelingGroepsIndelingGroep_s01<T>(int? AfspraakID, int? GroepsIndelingID, int? VergelijkingID) where T : SqlResponse;
		T csp_PrestatieComponentModel_s01<T>(int? MDL_ID) where T : SqlResponse;
		T csp_Contract_s14<T>(int? AfspraakID) where T : SqlResponse;
		T csp_OnderhandelingGroepsIndelingGroep_s04<T>(int? AfspraakID, int? GroepsIndelingID, int? VergelijkingID) where T : SqlResponse;
		T csp_PrestatieComponentModel_s02<T>(int? MDL_ID) where T : SqlResponse;
		T csp_Contract_s15<T>(int? AnalyseRegioId, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodeList, int? GroepId, int? InstantieId, int? InstantieSoort, DateTime PeilDatum, int? ProvincieId, int? RegioId, string Segment, bool? ToonPassantenTarieven, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> ZorgProductList, int? ZorgverstrekkerId, int? ZorgverzekeraarId) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_s05_incl_vergelijken<T>(int? AfspraakID, bool? AlleenIngesloten, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodes, string DeelVanOmschrijving, bool? ForceerTariefVergelijking, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> GroepFilter, int? GroepFilterType, bool? InclHonorariumComponenten, bool? NegeerPrestatieFilter, int? VergelijkingID, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> ZorgproductCodes) where T : SqlResponse;
		T csp_PrestatieComponentModel_u01<T>(int? AfspraakID, int? p_MDLDBC_Aantal, decimal? p_MDLDBC_Specialisten, decimal? p_MDLDBC_Ziekenhuis, string p_username, int? PrestatieID) where T : SqlResponse;
		T csp_Contract_s16<T>(int? ZorgverstrekkerID, int? ZorgverzekeraarID) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_s07_incl_vergelijken<T>(int? AfspraakID, bool? AlleenIngesloten, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodes, string DeelVanOmschrijving, bool? ForceerTariefVergelijking, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> GroepFilter, int? GroepFilterType, bool? NegeerPrestatieFilter, int? VergelijkingID, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> ZorgproductCodes) where T : SqlResponse;
		T csp_PrestatieComponentPassantenTarief_i01<T>(int? l_DBC_ID, int? p_CON_ID, decimal? p_CONDBC_Specialisten, decimal? p_CONDBC_Ziekenhuis, DateTime p_DatumIngang, char? p_DeclaratieCode, decimal? p_PoortSpecialismePrijs, string p_prestatieCode, string p_SPC_Code, string p_username) where T : SqlResponse;
		T csp_Contract_s17<T>(bool? ActiveOnly, int? AfspraakID, bool? InclChildContracten, int? InstantieID, int? ZorgsoortID) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_u03<T>(int? AfspraakID, char? DeclaratieCode, IEnumerable<Database.UserDefinedTypes.Afspraak.udtPrestatieInfoTable> Prestaties, decimal? PrijsHon0303, decimal? PrijsHon0307, decimal? PrijsHon0313, decimal? PrijsHon0316, decimal? PrijsHon0318, decimal? PrijsHon0320, decimal? PrijsHon0322, decimal? PrijsHon0330, decimal? PrijsHon0361, decimal? PrijsHon0362, decimal? PrijsHon0363, decimal? PrijsHon0386, decimal? PrijsHon0387, decimal? PrijsHon0388, decimal? PrijsHon0389, decimal? PrijsHonNietOndh, decimal? PrijsHonOverig, decimal? PrijsZKH) where T : SqlResponse;
		T csp_PrestatieComponentPassantenTarief_i02<T>(int? p_CON_ID, int? p_CONDBC_Aantal, decimal? p_CONDBC_Specialisten, decimal? p_CONDBC_Ziekenhuis, int? p_DBC_ID, char? p_status, string p_username) where T : SqlResponse;
		T csp_Contract_s18<T>(int? AfspraakID) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_u04<T>(int? AfspraakID, int? AfwBasis, object AfwHon0303, object AfwHon0307, object AfwHon0313, object AfwHon0316, object AfwHon0318, object AfwHon0320, object AfwHon0322, object AfwHon0330, object AfwHon0361, object AfwHon0362, object AfwHon0363, object AfwHon0386, object AfwHon0387, object AfwHon0388, object AfwHon0389, object AfwHonNietOndh, object AfwHonOndh, object AfwHonOverig, object AfwZKH, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodes, int? GroepId, bool? OnderhandelingGewijzigd) where T : SqlResponse;
		T csp_PrestatieFilter_s01<T>(bool? InclSpeerpunt, int? InstantieID, DateTime PeriodeEind, DateTime PeriodeStart, string Segment) where T : SqlResponse;
		T csp_Contract_s19<T>(int? AfspraakID) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_u10<T>(int? AfspraakID, object Afw, int? AfwBasis, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodes, bool? OnderhandelingGewijzigd) where T : SqlResponse;
		T csp_PrestatiesOpGrijzeEnZwarteLijst_d01<T>(int? AfspraakId) where T : SqlResponse;
		T csp_Contract_s20<T>(int? AnalyseRegioId, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodeList, int? GroepId, int? InstantieId, int? InstantieSoort, DateTime PeilDatum, int? ProvincieId, int? RegioId, string Segment, bool? ToonPassantenTarieven, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> ZorgProductList, int? ZorgverstrekkerId, int? ZorgverzekeraarId) where T : SqlResponse;
		T csp_PassantenTarief_i01<T>(DateTime p_BeginDatum, DateTime p_EindDatum, int? p_identity, string p_Omschrijving, int? p_SubVersie, string p_username, int? p_Versie, char? p_ZVS_AGBCode) where T : SqlResponse;
		T csp_PrestatiesOpGrijzeEnZwarteLijst_i01<T>(int? AfspraakId) where T : SqlResponse;
		T csp_Contract_s21<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_MarktTariefHonorarium_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_PrestatiesOpGrijzeEnZwarteLijst_s01<T>(int? AfspraakId) where T : SqlResponse;
		T csp_Contract_u03<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_MarktTariefKosten_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_PrestatiesOpGrijzeEnZwarteLijst_s02<T>(int? AfspraakId, DateTime Peildatum) where T : SqlResponse;
		T csp_Contract_u04<T>(int? afspraakId) where T : SqlResponse;
		T csp_Validatie_MaxTariefHonorarium_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_RegelResultaat_s01<T>(int? AfspraakID) where T : SqlResponse;
		T csp_ContractAfspraak_u01<T>(int? AfspraakID, int? ContactPersoonZVSID, int? ContactPersoonZVZID) where T : SqlResponse;
		T csp_Validatie_MaxTariefKosten_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_RegelResultaat_u01<T>(int? AfspraakID, int? InstantieRegelID, string ResultaatToelichting, int? UitgevoerdDoorID) where T : SqlResponse;
		T csp_ContractAfspraakBijlagen_s01<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_MaxTariefTotaal_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_RegelResultaat_u02<T>(int? AfspraakID, int? InstantieRegelID, int? UitgevoerdDoorID) where T : SqlResponse;
		T csp_ContractControleBestaandContract_s01<T>(DateTime BeginDatum, bool? BestaandContract, string Segment, int? ZorgSoort, int? ZVS_ID, int? ZVZ_ID) where T : SqlResponse;
		T csp_Validatie_MaxTariefTotaalIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Sjabloon_i01<T>(string Code, string Omschrijving, int? SjabloonAfspraakID, string Username) where T : SqlResponse;
		T csp_ContractControleBestaandContract_s02<T>(int? AfspraakID, DateTime BeginDatum, bool? BestaandContract, DateTime EindDatum, string Segment) where T : SqlResponse;
		T csp_Validatie_MaxTariefTotaalIntegraal_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Sjabloon_s01<T>(string segment, int? ZorgSoort) where T : SqlResponse;
		T csp_ContractControleBestaandContract_s03<T>(int? AfspraakID, bool? BestaandContract) where T : SqlResponse;
		T csp_Validatie_MinTariefHonorarium_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Sjabloon_s02<T>(int? AfspraakID, int? SjabloonAfspraakID) where T : SqlResponse;
		T csp_ContractControleBestaandContractImportTool_s02<T>(char? AGB, char? AGBSoort, DateTime BeginDatum, bool? BestaandContract, DateTime EindDatum, char? UZOVI) where T : SqlResponse;
		T csp_Validatie_MinTariefKosten_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Sjabloon_s03<T>(int? SjabloonAfspraakID) where T : SqlResponse;
		T csp_ContractExport_s01<T>(int? AfspraakID, bool? AlleTarieven, char? ExportInhoud) where T : SqlResponse;
		T csp_Validatie_TariefSoortInfoIntegraal_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Sjabloon_s04<T>(int? AfspraakIDSjabloonNieuw, int? AfspraakIDSjabloonVorig, bool? Identiek) where T : SqlResponse;
		T csp_ContractGroep_s01<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Contract_i05<T>(int? p_AfspraakID, int? p_AfspraakIDContract, bool? p_AutomatischGeaccordeerd, string p_UserName) where T : SqlResponse;
		T csp_Sjabloon_s05<T>(int? InstantieId, int? ZorgSoort) where T : SqlResponse;
		T csp_ContractGroepsUitzondering_s01<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Onderhandeling_i07<T>(int? p_AfspraakID_From, string p_bevestigingsTekst, int? p_InstantieAanZet, int? p_InstantieId, int? p_NewId, Guid p_NewVersieID, string p_Username, string p_VoorgesteldDoor) where T : SqlResponse;
		T csp_SpeerpuntAfspraak_s01<T>(DateTime periodeEind, DateTime periodeStart, string Segment, int? ZorgverstrekkerID, int? ZorgverzekeraarID) where T : SqlResponse;
		T csp_ContractPrijslijst_i09<T>(int? AfspraakID, IEnumerable<Database.UserDefinedTypes.Afspraak.udt_GGZPrijslijstTable> PrestatiePrijslijst) where T : SqlResponse;
		T csp_Onderhandeling_i08<T>(int? p_AfspraakID_From, string p_bevestigingsTekst, int? p_InstantieAanZet, int? p_InstantieId, int? p_newId, Guid p_NewVersieID, string p_Username) where T : SqlResponse;
		T csp_Validatie_1416Gelijk_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_ContractPrijslijst_s02<T>(int? AfspraakID, int? InstantieID, bool? VerrijkSjabloon) where T : SqlResponse;
		T csp_Onderhandeling_u09<T>(int? p_AfspraakID, bool? p_BijwerkenPrijslijst) where T : SqlResponse;
		T csp_Validatie_1416GelijkIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_ContractPrijslijst_s03<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_1416Gelijk_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_1416GelijkIntegraal_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_ContractPrijslijst_s04<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_1517Gelijk_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_1517Gelijk_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_ContractPrijslijst_s05<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_ABSegmentZorgproductenPoorter_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_1517GelijkIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_ContractPrijslijst_s06<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_Correcte17CodesAgisAchmea_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_1517GelijkIntegraal_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_ContractPrijslijstHonOndhComp_s02<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_Geen16Codes_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_ABSegmentZorgproductenPoorter_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_CreateModelContractFromOnderhandeling<T>(int? p_AfspraakID, int? p_InstantieType, int? p_ModelAfspraakID, string p_ModelCode, string p_ModelOmschrijving) where T : SqlResponse;
		T csp_Validatie_GeenOnverzekerdeZorg_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_CompleetheidInkoopAgisAchmea_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_GGZContractPrestatie_s01<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_MaxTariefHonorarium_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_Correcte17CodesAgisAchmea_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_GGZOnderhandelingPrestatie_i01<T>(int? AfspraakID, IEnumerable<Database.UserDefinedTypes.Afspraak.udt_GGZPrijslijstTable> PrestatiePrijslijst) where T : SqlResponse;
		T csp_Validatie_MaxTariefKosten_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_Correcte17CodesAgisAchmeaComplement_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_GGZOnderhandelingPrestatie_s01<T>(int? AfspraakID, bool? AlleenIngesloten, int? PrestatieTypeID) where T : SqlResponse;
		T csp_Validatie_MaxTariefTotaal_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_Geen16Codes_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_HonorariumComponent_s01<T>(int? AfspraakID, int? PrestatieID) where T : SqlResponse;
		T csp_Validatie_MinTariefHonorarium_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_Geen16CodesIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_HonorariumComponent_s03<T>(int? AfspraakID, int? InstantieID, int? PrestatieID) where T : SqlResponse;
		T csp_Validatie_MinTariefKosten_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_Geen16CodesIntegraal_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_HonorariumComponentPassantenTarief_i01<T>(int? AfspraakID, decimal? Kosten, int? PrestatieID, string SpecialismeCode, string Username) where T : SqlResponse;
		T csp_Validatie_OvernemenPrijzen16Pendant_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_GeenOnverzekerdeZorg_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_ImportContract8Data_u01<T>(int? p_AfspraakID, Guid p_StagingImportPrijslijstBatchToken) where T : SqlResponse;
		T csp_Validatie_OvernemenPrijzen17Pendant_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_GeenOnverzekerdeZorgIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_ImportContractData_u01<T>(int? p_AfspraakID, Guid p_StagingImportPrijslijstBatchToken) where T : SqlResponse;
		T csp_Validatie_TotaalHogerDanPassanten_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_GeenOnverzekerdeZorgIntegraal_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_ImportModelData_u01<T>(int? AfspraakID, Guid StagingImportPrijslijstBatchToken) where T : SqlResponse;
		T csp_Validatie_ZwarteLijstBlokkerend_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_GGZMutatieTarieven_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_ImportPassantenTarieven_u01<T>(int? RecordsInserted, int? RecordsUpdated, int? TogImportBatchLogID) where T : SqlResponse;
		T csp_Validatie_ZwarteLijstBlokkerendIntegraal_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_GGZSjabloonMaxTarieven_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_ImportVolumeSpecificatie_u01<T>(int? p_AfspraakID, int? p_SpecificatieGebaseerdOpJaar, Guid p_StagingImportVolumeSpecificatieBatchToken, string p_ToegevoegdDoor) where T : SqlResponse;
		T csp_Validatie_ZwarteLijstWaarschuwend_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_GrijzeLijst_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_InstantieRegel_s01<T>(int? AfspraakID, int? InstantieRegelID, bool? OnlyOutdated) where T : SqlResponse;
		T csp_Validatie_ZwarteLijstWaarschuwendIntegraal_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_HonorariumToeslagZBC_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_IsOnderhandelenToegestaanInPeriode<T>(DateTime p_PeriodeEind, DateTime p_PeriodeStart, int? p_ZorgverstrekkerID, int? p_ZorgverzekeraarID) where T : SqlResponse;
		T csp_Validatie_ModelContractAanwezig_Check<T>(int? AfspraakID, int? ModelAfspraakID, string ModelContractCode, string ModelContractCodePrefix, int? OnderhandelingAfspraakID) where T : SqlResponse;
		T csp_Model_d01<T>(int? p_MDL_ID) where T : SqlResponse;
		T csp_ImportOnderhandelingData_u01<T>(int? p_AfspraakID, bool? p_ImportPrices, bool? p_ImportVolumes, Guid p_StagingImportPrijslijstBatchToken) where T : SqlResponse;
		T csp_Validatie_NegatieveTarieven_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Model_i01<T>(int? p_identity, string p_MDL_Code, string p_MDL_Omschrijving, string p_username, int? p_ZorgverstrekkerID, int? p_ZorgverzekeraarID) where T : SqlResponse;
		T csp_Onderhandeling_i06<T>(int? AfspraakIDBlacklist, int? AfspraakIDSjabloon, int? AfspraakIDSpeerpunt, bool? AutomatischGestart, int? CPN_ZVS_ID, int? CPN_ZVZ_ID, DateTime EindDatum, int? INITIATOR, bool? IsPseudoOnderhandeling, int? NewAfspraakID, int? OnderhandelingUitgangspositieID, string SegmentCode, DateTime StartDatum, string USERNAME, int? ZVS_ID, int? ZVZ_ID) where T : SqlResponse;
		T csp_Validatie_NegatieveTarievenIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Model_s01<T>(int? AfspraakStijl, DateTime BeginDatum, DateTime EindDatum, int? InstantieID, string Segment) where T : SqlResponse;
		T csp_Onderhandeling_u08<T>(int? p_AfspraakId, string p_PrestatieFilterCode) where T : SqlResponse;
		T csp_Validatie_NulTariefHonorariumdeel_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Model_s02<T>(int? MDL_ID) where T : SqlResponse;
		T csp_Validatie_NulTariefKostendeel_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Model_u01<T>(string p_MDL_Code, int? p_MDL_ID, string p_MDL_Omschrijving, string p_username) where T : SqlResponse;
		T csp_Validatie_OnderhandelingBinnenSjabloon_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_ModelContractExport_s01<T>(int? AfspraakID, bool? AlleTarieven, char? ExportInhoud) where T : SqlResponse;
		T csp_Validatie_OntbrekenVolumina_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_ModelContractExport_s02<T>(int? AfspraakID, bool? AlleTarieven) where T : SqlResponse;
		T csp_Validatie_OvernemenPrijzen16Pendant_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_OnderhandelGeschiedenis_i01<T>(int? AfspraakID, DateTime AktieDatum, int? AktieID, int? GebruikerID, int? InstantieAanZet, string Opmerking, bool? VerbergOpmerkingVoorAnderePartij) where T : SqlResponse;
		T csp_Validatie_OvernemenPrijzen16PendantIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_OnderhandelGeschiedenis_s01<T>(int? AfspraakID, int? InstantieID) where T : SqlResponse;
		T csp_Validatie_OvernemenPrijzen16PendantIntegraal_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Onderhandeling_d01<T>(int? CON_ID) where T : SqlResponse;
		T csp_Validatie_OvernemenPrijzen17Pendant_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Onderhandeling_s00<T>(int? CON_ID) where T : SqlResponse;
		T csp_Validatie_OvernemenPrijzen17PendantIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Onderhandeling_s04<T>(int? CON_ORIG_ID, int? INITIATOR) where T : SqlResponse;
		T csp_Validatie_OvernemenPrijzen17PendantIntegraal_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Onderhandeling_s05<T>(int? CON_ID) where T : SqlResponse;
		T csp_Validatie_PrestatieBinnenGrijzeLijst_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Onderhandeling_s06<T>(int? InstantieTypeID, int? ZorgverstrekkerID, int? ZorgverzekeraarID) where T : SqlResponse;
		T csp_Validatie_PrestatieBinnenGrijzeLijst_Solve<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Onderhandeling_s07<T>(int? AfspraakStijl, int? InstantieTypeID, DateTime MaximaleToegestaneBegindatum, string SegmentCode, int? ZorgverstrekkerID, int? ZorgverzekeraarID) where T : SqlResponse;
		T csp_Validatie_PrestatieBinnenGrijzeLijstIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Onderhandeling_s08<T>(DateTime BeginDatum, int? CheckInstantieTypeId, DateTime EindDatum, bool? IncConcepten, int? OnderhandelingenInPeriode, string Segment, int? ZorgverstrekkerID, int? ZorgverzekeraarID) where T : SqlResponse;
		T csp_Validatie_PrestatieBinnenGrijzeLijstIntegraal_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Onderhandeling_s09<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_PrestatiesVallenBinnenSjabloonRegel_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Onderhandeling_s10<T>(DateTime BeginDatum, DateTime EindDatum, int? HuidigInstantieTypeId, bool? IncConcepten, int? OnderhandelingenInPeriode, int? ZorgSoortID, int? ZorgverstrekkerID, int? ZorgverzekeraarID) where T : SqlResponse;
		T csp_Validatie_TariefSoortInfo_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Onderhandeling_s11<T>(int? InstantieID, int? InstantieType, string SegmentCode, int? ZorgSoort) where T : SqlResponse;
		T csp_Validatie_TariefSoortInfo_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Onderhandeling_s12<T>(int? AfspraakId, int? InstantieTypeID) where T : SqlResponse;
		T csp_Validatie_TariefSoortInfoIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Onderhandeling_s13<T>(int? InstantieTypeID, int? ZorgverstrekkerID, int? ZorgverzekeraarID) where T : SqlResponse;
		T csp_Validatie_TotaalHogerDanPassanten_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Onderhandeling_u01<T>(DateTime BeginDatum, int? CON_ID, int? ContactPersoonZVSID, int? ContactPersoonZVZID, DateTime EindDatum, bool? HasUpdates, string Omschrijving, string RefZVS, string RefZVZ, string UpdateUser) where T : SqlResponse;
		T csp_Validatie_TotaalHogerDanPassantenIntegraal_Check<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Onderhandeling_u06<T>(int? CON_ID, int? ContactPersoonZVSID, int? ContactPersoonZVZID) where T : SqlResponse;
		T csp_Validatie_TotaalHogerDanPassantenIntegraal_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Onderhandeling_u07<T>(int? p_AfspraakId, DateTime p_BeginDatum, DateTime p_EindDatum, string p_ReferentieZVS, string p_ReferentieZVZ, int? p_TargetAfspraakIDModel, string p_TariefWijzigingTypeCode) where T : SqlResponse;
		T csp_Validatie_VoluminaMoet0ZijnBijCodes16Of17_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Onderhandeling_u10<T>(int? p_AfspraakId, int? p_InstantieTypeID, string p_OnderhandelingOpmerking, string p_Username) where T : SqlResponse;
		T csp_Validatie_VoluminaMoet0ZijnBijCodes16Of17_Solve<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Onderhandeling_u14<T>(int? p_AfspraakId, int? p_OnderhandelingAfspraakID_HuidigeVersie, int? p_onderhandelingAfspraakID_VorigeVersie, string p_UserName) where T : SqlResponse;
		T csp_Validatie_VoluminaMoet0ZijnBijCodes16Of17Integraal_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_OnderhandelingAfspraakBijlage_d01<T>(int? ID) where T : SqlResponse;
		T csp_Validatie_VoluminaMoet0ZijnBijCodes16Of17Integraal_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_OnderhandelingAfspraakBijlage_i01<T>(int? CON_ID, Guid ExtID, string FileName, int? ID, string ToegevoegdDoor, int? Type_ID) where T : SqlResponse;
		T csp_Validatie_ZwarteLijstBlokkerend_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_OnderhandelingAfspraakBijlage_s01<T>(int? CON_ID) where T : SqlResponse;
		T csp_Validatie_ZwarteLijstBlokkerendIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_OnderhandelingExport_s01<T>(int? AfspraakID, bool? AllePrestaties, bool? AlleTarieven, char? ExportInhoud) where T : SqlResponse;
		T csp_Validatie_ZwarteLijstWaarschuwend_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_OnderhandelingFlowgegevens_s01<T>(int? AfspraakId, int? InstantieTypeID) where T : SqlResponse;
		T csp_Validatie_ZwarteLijstWaarschuwendIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_OnderhandelingGroep_s01<T>(int? p_AfspraakID) where T : SqlResponse;
		T csp_VolumeSpecificatie_s01<T>(int? AfspraakID) where T : SqlResponse;
		T csp_OnderhandelingGroep_s02<T>(int? p_OnderhandelingGroepID) where T : SqlResponse;
		T csp_VolumeSpecificatie_s02<T>(int? AfspraakID) where T : SqlResponse;
		T csp_OnderhandelingGroep_u01<T>(object p_AfwijkingConsult, object p_AfwijkingHonOndh, object p_AfwijkingKlinisch, object p_AfwijkingNietKlinisch, object p_AfwijkingZKH, int? p_OnderhandelingGroepID) where T : SqlResponse;
		T csp_VolumeSpecificatie_s03<T>(int? AfspraakID) where T : SqlResponse;
		T csp_OnderhandelingGroep_u03<T>(int? p_OnderhandelingGroepID, bool? p_SelectBack) where T : SqlResponse;
		T csp_VolumeSpecificatie_s04<T>(int? AfspraakID) where T : SqlResponse;
		T csp_OnderhandelingGroep_u04<T>(int? p_OnderhandelingAfspraakID) where T : SqlResponse;
		T csp_VolumeSpecificatie_s05<T>(int? AfspraakID) where T : SqlResponse;
		T csp_OnderhandelingGroepsIndeling_s01<T>(int? AfspraakID, int? InstantieID) where T : SqlResponse;
		T csp_OnderhandelingGroepsIndelingGroep_s02<T>(int? AfspraakID, int? GroepsIndelingID, int? HoofdGroepID) where T : SqlResponse;
		T csp_OnderhandelingGroepsIndelingGroep_s03<T>(int? AfspraakID, int? GroepsIndelingID) where T : SqlResponse;
		T csp_OnderhandelingGroepsUitzondering_d01<T>(char? DeclaratieCode, bool? IsVerwijderd, int? OnderhandelingAfspraakID) where T : SqlResponse;
		T csp_OnderhandelingGroepsUitzonderingHonOndhComp_d01<T>(int? OnderhandelingGroepsuitzonderingID) where T : SqlResponse;
		T csp_OnderhandelingGroepsUitzonderingHonOndhComp_i01<T>(int? OnderhandelingGroepsuitzonderingID, decimal? Prijs, char? SpecialismeCode) where T : SqlResponse;
		T csp_OnderhandelingOpmerking_s01<T>(int? AfspraakID, int? InstantieTypeID) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_d01<T>(int? AfspraakID, bool? OnderhandelingGewijzigd, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> PrestatieIds) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_d02<T>(int? AfspraakID, bool? OnderhandelingGewijzigd, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> PrestatieIds) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_s01<T>(bool? p_FilterAlleenUitzonderingen, char? p_FilterBehandelingCode, string p_FilterDeclaratieCodes, char? p_FilterDiagnoseCode, char? p_FilterZorgTypeCode, char? p_FilterZorgVraagCode, int? p_OnderhandelingGroepID, int? p_PageNr, int? p_PageSize, char? p_SorteringKolom, string p_SorteringVolgorde) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_s02<T>(int? p_AfspraakID, char? p_DeclaratieCode) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_s03<T>(int? p_OnderhandelingGroepID) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_s04<T>(int? p_AfspraakID, char? p_DeclaratieCode) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_s05<T>(int? AfspraakID, bool? AlleenIngesloten, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodes, string DeelVanOmschrijving, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> GroepFilter, int? GroepFilterType, bool? NegeerPrestatieFilter, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> ZorgproductCodes) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_s06<T>(int? AfspraakID, bool? AlleenIngesloten, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodes, string DeelVanOmschrijving, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> GroepFilter, int? GroepFilterType) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_s07<T>(int? AfspraakID, bool? AlleenIngesloten, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodes, string DeelVanOmschrijving, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> GroepFilter, int? GroepFilterType, bool? NegeerPrestatieFilter, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> ZorgproductCodes) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_u01<T>(char? p_DeclaratieCode, bool? p_ForceerGroepsuitzondering, bool? p_Ingesloten, int? p_OnderhandelingAfspraakID, int? p_OnderhandelingGroepsUitzonderingID, decimal? p_PrijsHonOndh, decimal? p_PrijsZKH, char? p_TariefWijzigingTypeCode) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_u02<T>(int? p_OnderhandelingAfspraakID, int? p_PrestatieID, bool? p_Uitgesloten, int? p_Volume) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_u05<T>(int? AfspraakID, bool? OnderhandelingGewijzigd) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_u06<T>(int? AfspraakID, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodes, bool? OnderhandelingGewijzigd) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_u07<T>(int? AfspraakID, object AfwVolume, bool? OnderhandelingGewijzigd, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> PrestatieIds) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_u08<T>(int? AfspraakID, char? DeclaratieCode, bool? Ingesloten, decimal? Tarief, int? VolumeComponent1, int? VolumeComponent2, int? VolumeComponent3) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_u09<T>(int? AfspraakID, char? DeclaratieCode, IEnumerable<Database.UserDefinedTypes.Afspraak.udtPrestatieInfoTable> Prestaties, decimal? Prijs) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_u11<T>(int? AfspraakID, object AfwVolume, bool? OnderhandelingGewijzigd, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> PrestatieIds) where T : SqlResponse;
		T csp_OnderhandelingPrestatieTariefSoort_s01<T>(int? AfspraakID, char? DeclaratieCode) where T : SqlResponse;
		T csp_OnderhandelingPrestatieTariefSoort_s02<T>(int? AfspraakID, char? DeclaratieCode) where T : SqlResponse;
		T csp_OnderhandelingPrestatieToelichting_d01<T>(int? AfspraakID, char? DeclaratieCode) where T : SqlResponse;
		T csp_OnderhandelingPrestatieToelichting_s01<T>(int? AfspraakID, char? DeclaratieCode, string Toelichting) where T : SqlResponse;
		T csp_OnderhandelingPrestatieToelichting_u01<T>(int? AfspraakID, char? DeclaratieCode, string Toelichting) where T : SqlResponse;
		T csp_OnderhandelingPrijslijst_s01<T>(int? AfspraakId, int? CON_ID, bool? IsOnlyAfspraken) where T : SqlResponse;
		T csp_OnderhandelingPrijslijst_s02<T>(int? AfspraakID) where T : SqlResponse;
		T csp_OnderhandelingPrijslijst_s03<T>(int? AfspraakID) where T : SqlResponse;
		T csp_OnderhandelingPrijslijst_u01<T>(int? AfspraakID, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodes, bool? OnderhandelingGewijzigd, int? p_OnderhandelingGroepID, bool? p_SelectBack) where T : SqlResponse;
		T csp_Afspraak_s01<T>(int? InstantieID, int? ZVS_ID) where T : SqlResponse;
		T csp_OnderhandelingPrijslijstHonOndhComp_s02<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Afspraak_s02<T>(int? AfspraakID) where T : SqlResponse;
		T csp_OnderhandelingStatusovergangCheck_s01<T>(int? p_AfspraakID, int? p_InstantieID, int? p_NewStatus) where T : SqlResponse;
		T csp_Afspraak_s05<T>(int? AfspraakID, int? InstantieID, int? PrestatieID) where T : SqlResponse;
		T csp_contract_i07<T>(int? p_AfspraakID, int? p_AfspraakIDContract, bool? p_AutomatischGeaccordeerd, int? p_ContractAfspraakID, string p_UserName) where T : SqlResponse;
		T csp_OnderhandelingUitgangspositie_i01<T>(int? AfspraakIDBlacklist, int? AfspraakIDContract, int? AfspraakIDModel, int? AfspraakIDSjabloon, int? AfspraakIDSpeerpunt, int? AfspraakIDVolumeContract, int? AfspraakIDVolumeModel, int? NewUitgangspositieID, string SegmentCode, bool? TotaalprijsGelijk, string Username) where T : SqlResponse;
		T csp_Afspraak_s06<T>(int? InstantieID, int? PrestatieID) where T : SqlResponse;
		T csp_contract_i08<T>(int? p_AfspraakID, int? p_AfspraakIDContract, bool? p_AutomatischGeaccordeerd, string p_UserName) where T : SqlResponse;
		T csp_OnderhandelingUitgangspositie_i02<T>(int? AfspraakIDBlacklist, int? AfspraakIDContract, int? AfspraakIDModel, int? AfspraakIDSjabloon, int? AfspraakIDSpeerpunt, int? AfspraakIDVolumeContract, int? AfspraakIDVolumeModel, int? NewUitgangspositieID, bool? TotaalprijsGelijk, string Username) where T : SqlResponse;
		T csp_Afspraak_s07<T>(DateTime BeginDatum, DateTime Einddatum, int? InstantieID, char? PoortSpecialismeCode, char? PrestatieCode) where T : SqlResponse;
		T csp_Contract_i10<T>(int? p_AfspraakID, int? p_AfspraakIDContract, bool? p_AutomatischGeaccordeerd, string p_UserName) where T : SqlResponse;
		T csp_OnderhandelingUitgangspositie_i03<T>(int? AfspraakIDSjabloon, int? NieuweUitgangspositieID, string Username) where T : SqlResponse;
		T csp_Afspraak_u01<T>(int? AfspraakID) where T : SqlResponse;
		T csp_ImportOnderhandeling8Data_u01<T>(int? p_AfspraakID, char? p_ImportInhoud, bool? p_ImportPrices, bool? p_ImportVolumes, Guid p_StagingImportPrijslijstBatchToken) where T : SqlResponse;
		T csp_OnderhandelingUitgangspositie_i04<T>(int? AfspraakIDBlacklist, int? AfspraakIDContract, int? AfspraakIDModel, int? AfspraakIDSjabloon, int? AfspraakIDSpeerpunt, int? AfspraakIDVolumeContract, int? AfspraakIDVolumeModel, int? NewUitgangspositieID, string Username) where T : SqlResponse;
		T csp_Afspraak_u02<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Model_iu01<T>(int? l_identity, string p_MDL_Code, string p_MDL_Omschrijving, string p_username, char? p_ZVS_AGBCode, char? p_ZVZ_UZOVI) where T : SqlResponse;
		T csp_OnderhandelingUitgangspositie_s01<T>(int? AfspraakID, int? InstantieID) where T : SqlResponse;
		T csp_Afspraak_u03<T>(int? AfspraakID, DateTime BeginDatum, DateTime EindDatum, string Username) where T : SqlResponse;
		T csp_Onderhandeling_d04<T>(int? p_AfspraakID, int? p_InstantieId) where T : SqlResponse;
		T csp_OnderhandelingVolumeSpecificatieGewenst_s01<T>(int? AfspraakId, bool? VolumeSpecificatieGewenst) where T : SqlResponse;
		T csp_Afspraak_u04<T>(int? AfspraakID, int? InstantieID, string Username, Guid VersieID, Guid VersieIDNieuw) where T : SqlResponse;
		T csp_Onderhandeling_d05<T>(int? p_AfspraakID, string p_bevestigingsTekst, int? p_InstantieId, string p_UserName) where T : SqlResponse;
		T csp_OnderhandelPeriode_s01<T>(int? p_ZorgverstrekkerID, int? p_ZorgverzekeraarID) where T : SqlResponse;
		T csp_Afspraak_u05<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Onderhandeling_i09<T>(int? AfspraakIDBlacklist, int? AfspraakIDSjabloon, int? AfspraakIDSpeerpunt, bool? AutomatischGestart, int? CPN_ZVS_ID, int? CPN_ZVZ_ID, DateTime EindDatum, int? INITIATOR, bool? IsPseudoOnderhandeling, int? NewAfspraakID, int? OnderhandelingUitgangspositieID, string SegmentCode, DateTime StartDatum, int? TariefType, string USERNAME, int? ZVS_ID, int? ZVZ_ID) where T : SqlResponse;
		T csp_OnderhandelPeriode_s02<T>(int? p_PeriodeID, int? p_ZorgverzekeraarID) where T : SqlResponse;
		T csp_BlacklistAfspraak_s01<T>(DateTime periodeEind, DateTime periodeStart, string Segment, int? ZorgverstrekkerID, int? ZorgverzekeraarID) where T : SqlResponse;
		T csp_Onderhandeling_i10<T>(string AangemaaktDoor, int? AfspraakIDSjabloon, DateTime EindDatum, int? InitierendeInstantieTypeID, int? NieuweAfspraakID, int? OnderhandelingUitgangspositieID, DateTime StartDatum, int? ZorgverstrekkerID, int? ZorgverzekeraarID) where T : SqlResponse;
		T csp_OnderhandelPeriode_save01<T>(bool? p_OnderhandelenToegestaan, int? p_PeriodeID, int? p_ZorgverstrekkerID, int? p_ZorgverzekeraarID) where T : SqlResponse;
		T csp_Contract_d01<T>(int? p_CON_ID) where T : SqlResponse;
		T csp_Onderhandeling_i11<T>(int? p_AfspraakID_From, string p_bevestigingsTekst, int? p_InstantieAanZet, int? p_NewId, Guid p_NewVersieID, int? p_OnderhandelingAfspraakID, string p_UserName, string p_VoorgesteldDoor, int? p_ZorgSoort) where T : SqlResponse;
		T csp_OnderhandenWerk_d01<T>(DateTime PeriodeEind, DateTime PeriodeStart, int? ZVSID, int? ZVZID) where T : SqlResponse;
		T csp_Contract_d02<T>(int? AfspraakId, int? InstantieId, string Username) where T : SqlResponse;
		T csp_Onderhandeling_i12<T>(int? p_AfspraakID_From, int? p_AfspraakIDVorigeVersie, string p_bevestigingsTekst, int? p_InstantieAanZet, int? p_newId, Guid p_NewVersieID, int? p_OnderhandelingAfspraakID, string p_UserName) where T : SqlResponse;
		T csp_OnderhandenWerk_s01<T>(int? InvulKwartaal, string Segment, int? SjabloonJaar, int? ZVSID, int? ZVZID) where T : SqlResponse;
		T csp_Contract_d03<T>(int? AfspraakId, int? InstantieId, string Username) where T : SqlResponse;
		T csp_onderhandeling_i13<T>(int? p_AfspraakID_From, string p_bevestigingsTekst, int? p_InstantieAanZet, int? p_InstantieId, int? p_NewId, Guid p_NewVersieID, string p_Username, string p_VoorgesteldDoor) where T : SqlResponse;
		T csp_OnderhandenWerk_s02<T>(IEnumerable<Database.UserDefinedTypes.Overig.udtPeriodeTable> Perioden, int? ZVSID, int? ZVZID) where T : SqlResponse;
		T csp_Contract_d04<T>(int? AfspraakId, int? InstantieId, string Username) where T : SqlResponse;
		T csp_Onderhandeling_i14<T>(int? p_AfspraakID_From, string p_bevestigingsTekst, int? p_InstantieAanZet, int? p_InstantieId, int? p_newId, Guid p_NewVersieID, string p_Username) where T : SqlResponse;
		T csp_OnderhandenWerk_s03<T>(DateTime PeriodeEind, DateTime PeriodeStart, int? ZVSID, int? ZVZID) where T : SqlResponse;
		T csp_Contract_i04<T>(int? p_identity, int? p_SjabloonAfspraakID, int? p_SubVersie, int? p_Versie) where T : SqlResponse;
		T csp_Onderhandeling_i15<T>(int? p_AfspraakID_From, string p_bevestigingsTekst, int? p_InstantieAanZet, int? p_InstantieId, int? p_NewId, Guid p_NewVersieID, string p_Username, string p_VoorgesteldDoor) where T : SqlResponse;
		T csp_OnderhandenWerk_s04<T>(DateTime PeriodeEind, DateTime PeriodeStart, bool? VoorgaandJaar, int? ZVSID, int? ZVZID) where T : SqlResponse;
		T csp_Contract_i06<T>(int? AfspraakID, char? AGBCode, DateTime BeginDatum, string CreateUser, DateTime EindDatum, int? InstantieSubType, string Omschrijving, string Segment, int? SjabloonAfspraakID, char? UZOVI) where T : SqlResponse;
		T csp_Onderhandeling_i16<T>(int? p_AfspraakID_From, string p_bevestigingsTekst, int? p_InstantieAanZet, int? p_InstantieId, int? p_newId, Guid p_NewVersieID, string p_Username) where T : SqlResponse;
		T csp_OnderhandenWerk_s05<T>(DateTime PeriodeEind, DateTime PeriodeStart, int? ZVZID) where T : SqlResponse;
		T csp_Contract_i09<T>(int? AfspraakID, char? AGBCode, DateTime BeginDatum, int? ContractAfspraakID, string CreateUser, DateTime EindDatum, int? InstantieSubType, string Omschrijving, int? SjabloonAfspraakID, char? UZOVI) where T : SqlResponse;
		T csp_Onderhandeling_u04<T>(int? p_AfspraakId, string p_bevestigingsTekst, string p_GewijzigdDoor, int? p_InstantieAanZet, int? p_InstantieId, int? p_NewStatus, string p_UserName) where T : SqlResponse;
		T csp_onderhandenwerk_s06<T>(DateTime peilDatum, int? ZVZ_uzovi) where T : SqlResponse;
		T csp_Contract_i11<T>(int? AfspraakID, char? AGBCode, DateTime BeginDatum, string CreateUser, DateTime EindDatum, string Omschrijving, IEnumerable<Database.UserDefinedTypes.Tarief.udtTariefPrijslijst> Prijslijst, string Segment, int? SjabloonAfspraakID, char? UZOVI) where T : SqlResponse;
		T csp_Onderhandeling_u05<T>(int? p_AfspraakId, int? p_InstantieId, string p_UserName) where T : SqlResponse;
		T csp_OnderhandenWerk_u01<T>(bool? AkkoordVerklaard, IEnumerable<Database.UserDefinedTypes.Afspraak.udtOnderhandenWerkComponentenTable> ComponentenHuidigJaar, IEnumerable<Database.UserDefinedTypes.Afspraak.udtOnderhandenWerkComponentenTable> ComponentenVoorgaandJaar, decimal? KostprijsHuidigJaar, decimal? KostprijsVoorgaandJaar, string OpgegevenDoor, DateTime PeriodeEind, DateTime PeriodeStart, int? ZVSID, int? ZVZID) where T : SqlResponse;
		T csp_Contract_s06<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Onderhandeling_u11<T>(int? p_AfspraakId, string p_bevestigingsTekst, string p_GewijzigdDoor, int? p_NewAkkoordStatus, string p_UserName) where T : SqlResponse;
		T csp_OnderhandenWerkSjabloon2010_s01<T>(int? InvulKwartaal, string Segment, int? SjabloonJaar, int? ZVSID, int? ZVZID) where T : SqlResponse;
		T csp_Contract_s07<T>(bool? ActiveOnly, int? AfspraakID, int? AfspraakStijl, bool? InclChildContracten, bool? InclPassantenTarieven, int? InstantieID, DateTime MaximumBegindatum, string Segment) where T : SqlResponse;
		T csp_Onderhandeling_u12<T>(int? AfspraakId, string BevestigingsTekst, string GewijzigdDoor, int? NieuweOnderhandelingStatus, int? p_InstantieAanZet, string UserName) where T : SqlResponse;
		T csp_OnderhandenWerkSjabloon2010_u01<T>(string Gebruiker, Guid ImportIdentifier, int? InvulKwartaal, string Segment, int? SjabloonJaar, string SjabloonVersie, int? ZVSID, int? ZVZID) where T : SqlResponse;
		T csp_Contract_s08<T>(int? jaartal, char? uzovi, DateTime wijzigingenVanaf) where T : SqlResponse;
		T csp_Onderhandeling_u13<T>(int? AfspraakId, string BevestigingsTekst, string GewijzigdDoor, int? NieuweOnderhandelingStatus, string UserName) where T : SqlResponse;
	}

	public interface IAnalyse
	{
		T csp_BehandelingZwarteLijst_s01<T>(DateTime Peildatum, int? ZorgverzekeraarId) where T : SqlResponse;
		T csp_BehandelingZwarteLijst_u01<T>(IEnumerable<Database.UserDefinedTypes.Analyse.udtUpdateBehandelingZwarteLijst> UpdateList, int? ZorgverzekeraarId) where T : SqlResponse;
		T csp_Periode_s01<T>(DateTime DatumVanaf, bool? p_SortDescending, int? ZorgverzekeraarId) where T : SqlResponse;
		T csp_Stamgegeven_s01<T>(DateTime BeginDatum, DateTime EindDatum, string GroepSleutel, int? ZorgverzekeraarId) where T : SqlResponse;
		T csp_ZorgverstrekkerBudget_d01<T>(int? PeriodeId, int? ZorgSoortId, int? ZorgverstrekkerId, int? ZorgverzekeraarId) where T : SqlResponse;
		T csp_ZorgverstrekkerBudget_s01<T>(int? PeriodeId, int? ZorgSoortId, int? ZorgverstrekkerId, int? ZorgverzekeraarId) where T : SqlResponse;
		T csp_ZorgverstrekkerBudget_s02<T>(bool? AlleenGecontracteerd, int? CategorieId, bool? InclContracten, bool? InclOnderhandelingen, string Inkoper, int? PeriodeId, int? RegioId, int? ZorgverstrekkerId, int? ZorgverzekeraarId) where T : SqlResponse;
		T csp_ZorgverstrekkerBudget_s03<T>(bool? AlleenGecontracteerd, int? CategorieId, bool? InclContracten, bool? InclOnderhandelingen, string Inkoper, int? PeriodeId, int? RegioId, int? ZorgverstrekkerId, int? ZorgverzekeraarId) where T : SqlResponse;
		T csp_ZorgverstrekkerBudget_s04<T>(int? ZorgverstrekkerId, int? ZorgverzekeraarId) where T : SqlResponse;
		T csp_ZorgverstrekkerBudget_s05<T>(DateTime BeginDatum, DateTime EindDatum, int? PeriodeId, int? ZorgSoortId, int? ZorgverstrekkerId, int? ZorgverzekeraarId) where T : SqlResponse;
		T csp_ZorgverstrekkerBudget_s06<T>(bool? AlleenGecontracteerd, int? CategorieId, bool? InclContracten, bool? InclOnderhandelingen, string Inkoper, int? PeriodeId, int? RegioId, int? ZorgverstrekkerId, int? ZorgverzekeraarId) where T : SqlResponse;
		T csp_ZorgverstrekkerBudget_u01<T>(decimal? BudgetTotaal, int? CategorieId, bool? Contracteerbaar, string Contractnummer, decimal? ExternContractTotaal, string Inkoper, string IPZReferentie, decimal? MandaatTotaal, bool? NietInAutoModelcontract, decimal? OmzetAfspraak, int? OmzetAfspraakSoortId, decimal? OmzetPlafond, bool? OnderhandenWerk, string OnderhandenWerkMailadres, int? PeriodeId, decimal? PrijsAfspraak, string PrijsAfspraakOmschrijving, int? RegioId, int? ZorgSoortId, int? ZorgverstrekkerId, int? ZorgverzekeraarId) where T : SqlResponse;
		T csp_ZorgverstrekkerBudgetBulk_u01<T>(IEnumerable<Database.UserDefinedTypes.Analyse.udtZorgverstrekkerBudget> BudgetRegels) where T : SqlResponse;
		T csp_ZorgverstrekkersScore_s01<T>(int? AfspraakIDModel, bool? AlleenSpeerpuntPrestaties, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> Categorien, bool? GeenSpeerpuntPrestaties, bool? InclContracten, bool? InclOnderhandelingen, int? RapportagePeriodeID, int? ZorgverzekeraarID) where T : SqlResponse;
	}

	public interface IDataStaging
	{
		T csp_SpreadTogRecords<T>(int? TogImportBatchLogID) where T : SqlResponse;
		T csp_TogRecordType36_d01<T>(int? TogImportBatchLogID) where T : SqlResponse;
		T csp_TogRecordType36_i01<T>(char? AanduidingPrestatiecodelijst, char? DatumEindeTarief, char? DatumIngangTarief, char? DbcDeclaratieCode, char? DbcDeclarerendSpecialisme, char? DbcPoortspecialisme, int? Identity, char? IndicatieDebetCredit, char? IndicatieSoortZorg, char? Kenmerk, char? KenmerkRecord, char? Mutatiecode, char? SoortTarief, char? Tarief, char? ToelichtingMutatie, char? TypeTarief) where T : SqlResponse;
		T csp_TogRecordType36_u01<T>(int? TogImportBatchLogID) where T : SqlResponse;
		T csp_TogRecordType38_d01<T>(int? TogImportBatchLogID) where T : SqlResponse;
		T csp_TogRecordType38_u01<T>(int? TogImportBatchLogID) where T : SqlResponse;
	}

	public interface IDbc
	{
		T csp_Behandeling_s01<T>() where T : SqlResponse;
		T csp_BehandelingStamdata_s01<T>(DateTime Peildatum) where T : SqlResponse;
		T csp_Diagnose_s01<T>() where T : SqlResponse;
		T csp_Groepsindeling_s01<T>(string GroepNaam, int? GroepsIndelingId) where T : SqlResponse;
		T csp_Periode_d01<T>(int? p_PeriodeID) where T : SqlResponse;
		T csp_Periode_i01<T>(string p_Omschrijving, DateTime p_PeriodEnd, DateTime p_PeriodStart) where T : SqlResponse;
		T csp_Periode_s01<T>(DateTime DatumVanaf, bool? p_SortDescending, int? ZorgverzekeraarId) where T : SqlResponse;
		T csp_Periode_u01<T>(string p_Omschrijving, int? p_PeriodeID, DateTime p_PeriodEnd, DateTime p_PeriodStart) where T : SqlResponse;
		T csp_Prestatie_s03<T>(char? AGBCode, string BEH_CODE, char? DBC_DeclaratieCode, char? DBCSEGMENTCODE, string DIA_CODE, int? InstantieID, DateTime PeilDatumTotEnMet, DateTime PeilDatumVanaf, string SPC_CODE, char? UZOVICode, char? ZTY_CODE, char? ZVR_CODE) where T : SqlResponse;
		T csp_Prestatie_s04<T>(string DBCCode, int? InstantieID) where T : SqlResponse;
		T csp_Prestatie_s05<T>(int? PrestatieID) where T : SqlResponse;
		T csp_Prestatie_s06<T>(string Omschrijving) where T : SqlResponse;
		T csp_PrestatieCode_s01<T>(int? PrestatieID) where T : SqlResponse;
		T csp_PrestatieCode_s02<T>() where T : SqlResponse;
		T csp_PrestatieCode_s03<T>(char? PrestatieCode) where T : SqlResponse;
		T csp_PrestatieCode_s06<T>(char? segmentCode) where T : SqlResponse;
		T csp_PrestatieCode_s07<T>(char? PoortSpecialismeCode, char? PrestatieCode) where T : SqlResponse;
		T csp_Specialisme_s01<T>(bool? AlleenHonCompSpecialismes) where T : SqlResponse;
		T csp_Specialisme_s03<T>() where T : SqlResponse;
		T csp_TariefWijzigingType_s01<T>() where T : SqlResponse;
		T csp_ZorgType_s01<T>() where T : SqlResponse;
		T csp_ZorgVraag_s01<T>() where T : SqlResponse;
	}

	public interface IHelp
	{
		T csp_HelpLink_s01<T>(DateTime DatumActief, string LinkCode, string Username) where T : SqlResponse;
	}

	public interface ILogs
	{
		T csp_log4netentries_s01<T>(string p_Application, DateTime p_DateEnd, DateTime p_DateStart, string p_Identity, bool? p_isTechnical, string p_Level) where T : SqlResponse;
		T csp_OnderhandelingStatusLog_i01<T>(string ActieReden, int? AfspraakId, string BevestigingsTekst, string GewijzigdDoor) where T : SqlResponse;
		T csp_OnderhandelingStatusLog_s01<T>(int? AfspraakId) where T : SqlResponse;
		T csp_OnderhandelingStatusLog_s02<T>(int? AfspraakId) where T : SqlResponse;
		T csp_OnderhandelingStatusLog_s03<T>(int? EersteOnderhandelingId) where T : SqlResponse;
	}

	public interface IOrganisatie
	{
		T csp_Gebruiker_s07<T>(string CommonName, DateTime totDatum, DateTime vanDatum, int? ZorgSoort) where T : SqlResponse;
		T csp_Gebruiker_s08<T>(string CommonName, DateTime totDatum, DateTime vanDatum, int? zorgSoort) where T : SqlResponse;
		T csp_Gebruiker_s09<T>(char? VecozoCertificaatNummer) where T : SqlResponse;
		T csp_Gebruiker_s11<T>(bool? InclusiefNietGeaccepteerd, int? InstantieID) where T : SqlResponse;
		T csp_Gebruiker_s13<T>() where T : SqlResponse;
		T csp_Gebruiker_s14<T>(int? InstantieID, bool? ToonVoorgesteldeKoppelingen) where T : SqlResponse;
		T csp_Gebruiker_u02<T>(string Achternaam, string Email, int? GebruikerID, bool? InActief, string Tussenvoegsel, string UpdateUser, string Voorletters) where T : SqlResponse;
		T csp_GebruikerContactPersoon_s01<T>(bool? IncludeDBCSUsers, int? InstantieID, int? ZorgsoortID) where T : SqlResponse;
		T csp_GebruikerInstantie_d01<T>(string GebruikerIds, int? InstantieID) where T : SqlResponse;
		T csp_GebruikerInstantie_d02<T>(int? GebruikerId, int? InstantieID, int? RemainingInstantieCount) where T : SqlResponse;
		T csp_GebruikerInstantie_i01<T>(string CreateUser, int? GebruikerID, int? InstantieID, int? KoppelingVoorgesteldDoor) where T : SqlResponse;
		T csp_GebruikerInstantie_s01<T>(int? InstantieID) where T : SqlResponse;
		T csp_GebruikerInstantie_s02<T>() where T : SqlResponse;
		T csp_GebruikerInstantie_u01<T>(int? GebruikerId, int? InstantieID, int? KoppelingGeaccepteerdDoor) where T : SqlResponse;
		T csp_GebruikerRol_d00<T>(int? GebruikerID, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> ZorgSoortIds) where T : SqlResponse;
		T csp_GebruikerRol_s01<T>() where T : SqlResponse;
		T csp_GebruikerRol_u01<T>(string CreateUser, int? GebruikerID, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> teOntnemenRolIDs, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> toeTeKennenRolIDs, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> ZorgSoortIds) where T : SqlResponse;
		T csp_Instantie_s01<T>(int? InstantieTypeID) where T : SqlResponse;
		T csp_Instantie_s02<T>(int? InstantieID) where T : SqlResponse;
		T csp_Instanties_s01<T>(int? InstantieID) where T : SqlResponse;
		T csp_InstantieType_s00<T>() where T : SqlResponse;
		T csp_Provincie_s01<T>() where T : SqlResponse;
		T csp_Regio_s01<T>() where T : SqlResponse;
		T csp_Rol_s01<T>() where T : SqlResponse;
		T csp_Rol_s02<T>(int? GebruikerID) where T : SqlResponse;
		T csp_Rol_s03<T>() where T : SqlResponse;
		T csp_Settings_i01<T>(int? InstantieID, string SettingName, string SettingValue, int? ZorgSoortID) where T : SqlResponse;
		T csp_Settings_s01<T>(int? InstantieID, string SettingName, int? ZorgSoortID) where T : SqlResponse;
		T csp_Taak_s01<T>(int? GebruikerID) where T : SqlResponse;
		T csp_Zorgverstrekker_s01<T>(char? p_AGB, char? p_AGBSoort, int? p_CTGCategorie, int? p_CTGNummer) where T : SqlResponse;
		T csp_Zorgverstrekker_s06<T>(DateTime totDatum, DateTime vanDatum, int? zorgSoort) where T : SqlResponse;
		T csp_Zorgverstrekker_s11<T>(int? ZorgverstrekkerID) where T : SqlResponse;
		T csp_Zorgverstrekker_s13<T>(char? p_AGBParent) where T : SqlResponse;
		T csp_Zorgverstrekker_u01<T>(string Adres, char? AGB, char? AGBSoort, int? CTGCategorie, int? CTGNummer, string Email, int? ID, bool? Inactief, bool? IsHoofdLocatie, string Naam, string Plaats, string Postcode, string Telefoonnummer, string UpdateUser, string Website) where T : SqlResponse;
		T csp_Zorgverzekeraar_s02<T>(string UZOVI) where T : SqlResponse;
		T csp_Zorgverzekeraar_s10<T>(DateTime totDatum, DateTime vanDatum, int? zorgSoort) where T : SqlResponse;
		T csp_Zorgverzekeraar_u01<T>(int? ID, string Naam, string UpdateUser, char? UZOVI, string Website) where T : SqlResponse;
		T csp_AGBSoort_s01<T>() where T : SqlResponse;
		T csp_Gebruiker_i01<T>(string Achternaam, string CommonName, string CreateUser, string Email, string Tussenvoegsel, string Voorletters) where T : SqlResponse;
		T csp_Gebruiker_s01<T>(string CommonName, int? GebruikerID, bool? InclusiefNietGeaccepteerd) where T : SqlResponse;
		T csp_Gebruiker_s03<T>(string CommonName) where T : SqlResponse;
		T csp_Gebruiker_s04<T>() where T : SqlResponse;
		T csp_Gebruiker_s05<T>(string CommonName, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> ZorgSoorten) where T : SqlResponse;
	}

	public interface IOverig
	{
		T csp_Automodellen_i01<T>(DateTime datumMax, DateTime datumMin, char? uzovi) where T : SqlResponse;
		T csp_Automodellen_i02<T>(DateTime datumMax, DateTime datumMin, char? uzovi) where T : SqlResponse;
		T csp_BijlageType_s01<T>() where T : SqlResponse;
		T csp_DisclaimerGetoond_i01<T>(int? AfspraakID, bool? Toegevoegd, string Username) where T : SqlResponse;
		T csp_DisclaimerGetoond_s01<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Export_d01<T>(int? ExportID) where T : SqlResponse;
		T csp_Export_i01<T>(string AGB, char? AGBSoort, bool? AlleenWijzigingen, DateTime BereikTot, DateTime BereikVan, string CategorieIds, string ExportIndicator, int? exportType, int? fileType, int? HistorischJaartal, int? identity, bool? InclActueleContracten, bool? InclNietSpeerpunten, bool? InclSpeerpunten, bool? InclVervallenContracten, string Inhoud, bool? isNOW, decimal? PrijsZKHMin, string referentie, DateTime wijzigingenVanaf, string ZorgproductCode, int? ZVZ_ID) where T : SqlResponse;
		T csp_Export_i02<T>(int? exportType, int? fileType, int? HistorischJaartal, int? identity, string referentie, int? ZVZ_ID) where T : SqlResponse;
		T csp_Export_i03<T>(int? exportType, int? fileType, int? identity, string referentie, int? ZVZ_ID) where T : SqlResponse;
		T csp_Export_s01<T>(int? ZVZ_ID) where T : SqlResponse;
		T csp_Export_s02<T>(int? ExportID) where T : SqlResponse;
		T csp_Export_s03<T>(char? UZOVI) where T : SqlResponse;
		T csp_Export_u01<T>(int? exportStatus, string fileName, int? ID) where T : SqlResponse;
		T csp_Export_u02<T>(string FileType, int? ID, int? ZVZ_ID) where T : SqlResponse;
		T csp_ExportFileType_s01<T>() where T : SqlResponse;
		T csp_ExportPeriode_s01<T>(bool? alleenWijzigingen, DateTime datumMax, DateTime datumMin, bool? inclActueleContracten, bool? inclVervallenContracten, IEnumerable<Database.UserDefinedTypes.Afspraak.udtInstantiePeriodeTable> nietTeExporterenZorgverstrekkers, decimal? prijsZKHMin, char? uzovi, DateTime wijzigingenVanaf) where T : SqlResponse;
		T csp_ExportPeriode_u01<T>(bool? alleenWijzigingen, DateTime datumMax, DateTime datumMin, bool? inclActueleContracten, bool? inclVervallenContracten, IEnumerable<Database.UserDefinedTypes.Afspraak.udtInstantiePeriodeTable> nietTeExporterenZorgverstrekkers, decimal? prijsZKHMin, char? uzovi, DateTime wijzigingenVanaf) where T : SqlResponse;
		T csp_ExportType_s01<T>() where T : SqlResponse;
		T csp_RecordType34_s01<T>(bool? alleenWijzigingen, DateTime datumMax, DateTime datumMin, bool? inclActueleContracten, bool? inclVervallenContracten, IEnumerable<Database.UserDefinedTypes.Afspraak.udtInstantiePeriodeTable> nietTeExporterenZorgverstrekkers, decimal? prijsZKHMin, char? uzovi, DateTime wijzigingenVanaf) where T : SqlResponse;
		T csp_RecordType45_s01<T>(int? jaartal, char? uzovi, DateTime wijzigingenVanaf) where T : SqlResponse;
		T csp_RecordType45_s03<T>(int? jaartalMax, int? jaartalMin, char? uzovi, DateTime wijzigingenVanaf) where T : SqlResponse;
		T csp_RecordTypeAchmeaTIM_s01<T>(char? AgbSoort, DateTime DatumTot, DateTime DatumVanaf, char? Uzovi) where T : SqlResponse;
		T csp_RecordTypeAchmeaTIMIntegraal_s01<T>(char? AgbSoort, DateTime DatumTot, DateTime DatumVanaf, char? Uzovi) where T : SqlResponse;
		T csp_RecordTypeCZ_s01<T>(int? CON_ID, DateTime wijzigingenVanaf) where T : SqlResponse;
		T csp_RecordTypeCZ_S02<T>(bool? alleenWijzigingen, DateTime datumMax, DateTime datumMin, bool? inclActueleContracten, bool? inclVervallenContracten, IEnumerable<Database.UserDefinedTypes.Afspraak.udtInstantiePeriodeTable> nietTeExporterenZorgverstrekkers, decimal? prijsZKHMin, char? uzovi, DateTime wijzigingenVanaf) where T : SqlResponse;
		T csp_RecordTypeCZ_S03<T>(bool? alleenWijzigingen, DateTime datumMax, DateTime datumMin, bool? inclActueleContracten, bool? inclVervallenContracten, IEnumerable<Database.UserDefinedTypes.Afspraak.udtInstantiePeriodeTable> nietTeExporterenZorgverstrekkers, decimal? prijsZKHMin, char? uzovi, DateTime wijzigingenVanaf) where T : SqlResponse;
		T csp_RecordTypeCZ_S04<T>(bool? alleenWijzigingen, DateTime datumMax, DateTime datumMin, bool? inclActueleContracten, bool? inclVervallenContracten, IEnumerable<Database.UserDefinedTypes.Afspraak.udtInstantiePeriodeTable> nietTeExporterenZorgverstrekkers, decimal? prijsZKHMin, char? uzovi, DateTime wijzigingenVanaf) where T : SqlResponse;
		T csp_RecordTypeCZ_S05<T>(bool? alleenWijzigingen, DateTime datumMax, DateTime datumMin, bool? inclActueleContracten, bool? inclVervallenContracten, IEnumerable<Database.UserDefinedTypes.Afspraak.udtInstantiePeriodeTable> nietTeExporterenZorgverstrekkers, decimal? prijsZKHMin, char? uzovi, DateTime wijzigingenVanaf) where T : SqlResponse;
		T csp_RecordTypeDatadump_s01<T>(char? agbSoort, DateTime datumMax, DateTime datumMin, bool? inclContracten, bool? inclOnderhandelingen, char? uzovi, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> zvsCategorieen) where T : SqlResponse;
		T csp_RecordTypeDatadump_s02<T>(char? agb, char? agbSoort, bool? inclContracten, bool? inclNietSpeerpunten, bool? inclOnderhandelingen, bool? inclSpeerpunten, DateTime peildatum, char? uzovi, string zorgproductCode, int? zvsCategorie) where T : SqlResponse;
		T csp_RecordTypeMenzisCsv_s01<T>(int? CON_ID, DateTime wijzigingenVanaf) where T : SqlResponse;
		T csp_RecordTypeMZ_S01<T>(DateTime datumMax, DateTime datumMin, char? uzovi, DateTime wijzigingenVanaf) where T : SqlResponse;
		T csp_RecordTypeMZ_s02<T>(DateTime datumMax, DateTime datumMin, char? uzovi, DateTime wijzigingenVanaf) where T : SqlResponse;
		T csp_SchemaChangeLog_s01<T>() where T : SqlResponse;
		T csp_TogImportBatchLog_i01<T>(DateTime ImportDatum, bool? IsIncrementeel, int? TogImportBatchLogID, int? TogProductieNummer, int? VersienummerBestand) where T : SqlResponse;
		T csp_TogImportBatchLog_s01<T>() where T : SqlResponse;
		T csp_TogImportBatchLog_u01<T>(int? AantalRecordsAangepast, int? AantalRecordsToegevoegd, int? AantalRecordsVerwijderd, string Melding, int? Status, string StatusInfo, int? TogImportBatchLogID) where T : SqlResponse;
		T csp_TogImportLog_i01<T>(DateTime Datum, int? Identity, int? ImportGeschiedenisID, string Omschrijving, int? TogRecordType) where T : SqlResponse;
	}

	public interface IRapportage
	{
		T csp_ModelAfspraak_s01<T>(int? Zorgverzekeraar) where T : SqlResponse;
		T csp_OverzichtContracten_s01<T>(int? InstantieID) where T : SqlResponse;
		T csp_OverzichtOnderhandelingen_s01<T>(int? InstantieID) where T : SqlResponse;
		T csp_Prijsvergelijking_s01<T>(char? agb, bool? inclNietSpeerpunten, bool? inclSpeerpunten, int? rapportageJaar, bool? rapportageNotFound, int? referentieJaar, bool? referentieNotFound, int? zorgverzekeraarId) where T : SqlResponse;
		T csp_ScoreSpeerpunten_s01<T>(int? CategorieId, int? Inhoud, int? ModelAfspraak, int? Niveau, int? Periode, int? RegioId, int? Speerpunt, int? Zorgverzekeraar) where T : SqlResponse;
		T csp_SjabloonPeriode_s01<T>(int? Zorgverzekeraar) where T : SqlResponse;
		T csp_SpeerpuntPeriode_s01<T>(int? Zorgverzekeraar) where T : SqlResponse;
		T csp_Voortgang_s01<T>(int? InstantieID, DateTime peildatum_1, DateTime peildatum_2) where T : SqlResponse;
	}

	public interface ITarief
	{
		T csp_ContractExport_s01<T>(int? AfspraakID, bool? AlleTarieven, char? ExportInhoud) where T : SqlResponse;
		T csp_CreateModelContractFromOnderhandeling<T>(int? p_AfspraakID, int? p_InstantieType, int? p_ModelAfspraakID, string p_ModelCode, string p_ModelOmschrijving) where T : SqlResponse;
		T csp_OnderhandelingExport_s01<T>(int? AfspraakID, bool? AllePrestaties, bool? AlleTarieven, char? ExportInhoud) where T : SqlResponse;
		T csp_OnderhandelingPrijslijst_i01<T>(int? AfspraakId, bool? ImportPrices, bool? ImportVolumes, IEnumerable<Database.UserDefinedTypes.Tarief.udtTariefPrijslijst> Prijslijst) where T : SqlResponse;
		T csp_OnderhandelingPrijslijst_s01<T>(int? AfspraakId, int? CON_ID, bool? IsOnlyAfspraken) where T : SqlResponse;
		T csp_OnderhandelingPrijslijst_u01<T>(int? AfspraakID, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodes, bool? OnderhandelingGewijzigd, int? p_OnderhandelingGroepID, bool? p_SelectBack) where T : SqlResponse;
	}

	public interface IVergelijking
	{
		T csp_NeemPrijzenOver_u01<T>(int? p_VergelijkingsBronID) where T : SqlResponse;
		T csp_ApplyDetailFilter_u01<T>(int? p_OnderhandelingGroepId, int? p_VergelijkingID) where T : SqlResponse;
		T csp_ApplyDetailFilter_u02a<T>(int? p_OnderhandelingGroepId, int? p_VergelijkingID) where T : SqlResponse;
		T csp_ApplyDetailFilter_u02b<T>(char? p_DeclaratieCode, int? p_OnderhandelingGroepId, int? p_VergelijkingID) where T : SqlResponse;
		T csp_ApplyDetailFilter_u03<T>(char? p_BehandelingCode, char? p_DiagnoseCode, int? p_OnderhandelingGroepId, int? p_VergelijkingID, char? p_ZorgTypeCode, char? p_ZorgVraagCode) where T : SqlResponse;
		T csp_BerekenKosten_i01<T>(int? p_VergelijkingID) where T : SqlResponse;
		T csp_BerekenKosten_i02<T>(int? p_VergelijkingsBronID) where T : SqlResponse;
		T csp_CreateVergelijking_i01<T>(int? p_AfspraakID, int? p_AfspraakIDVolumeSjabloon, int? p_VergelijkingID, int? p_VergelijkingType) where T : SqlResponse;
		T csp_CreateVergelijkingsBron_i01<T>(int? p_VergelijkingID, int? p_VergelijkingsBronID, int? p_VolumeAfspraakID) where T : SqlResponse;
		T csp_CreateVergelijkingsBron_i02<T>(int? p_AfspraakID, int? p_VergelijkingID, int? p_VergelijkingsBronID, int? p_VolumeAfspraakID) where T : SqlResponse;
		T csp_CreateVergelijkingsPrestatieSet_i01<T>(int? p_VergelijkingID) where T : SqlResponse;
		T csp_CreateVergelijkingsPrestatieSet_i02<T>(int? p_VergelijkingID) where T : SqlResponse;
		T csp_GetAfspraakData_s<T>(int? p_AfspraakID, int? p_OnderhandelingAfspraakID, int? p_VergelijkingID) where T : SqlResponse;
		T csp_GetBronKosten_s<T>(int? p_VergelijkingsBronID) where T : SqlResponse;
		T csp_GetDetailKosten_s<T>(int? p_OnderhandelingGroepId, int? p_PageNumber, int? p_PageSize, int? p_SortColumn, bool? p_SortOrder, int? p_VergelijkingsBronID) where T : SqlResponse;
		T csp_GetDetailKosten_s02<T>(int? p_OnderhandelingGroepId, int? p_VergelijkingsBronID) where T : SqlResponse;
		T csp_GetKosten_s<T>(int? p_VergelijkingID) where T : SqlResponse;
		T csp_GetSelectionCount_s<T>(int? p_OnderhandelingGroepId, int? p_VergelijkingID) where T : SqlResponse;
		T csp_GetVergelijkingExport_s01<T>(int? vergelijkingsBronID) where T : SqlResponse;
		T csp_GetVergelijkingExport_s02<T>(int? vergelijkingsBronID) where T : SqlResponse;
		T csp_HerBerekenKosten_u01<T>(int? p_VergelijkingID) where T : SqlResponse;
		T csp_NeemPrijzenOver8_u01<T>(int? AfspraakID, bool? AlleenLagereTarieven, int? BronIndex, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> FilterPrestatieIDs, bool? FilterPrestaties, int? VergelijkingID) where T : SqlResponse;
		T csp_NeemPrijzenOver8Integraal_u01<T>(int? AfspraakID, bool? AlleenLagereTarieven, int? BronIndex, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> FilterPrestatieIDs, bool? FilterPrestaties, int? VergelijkingID) where T : SqlResponse;
		T csp_ReCreateVergelijkingsPrestatieSet_u<T>(int? TariefType, int? VergelijkingID) where T : SqlResponse;
		T csp_VergelijkingsBronPrijslijst_u01<T>(int? p_VergelijkingID) where T : SqlResponse;
		T csp_VergelijkingsBronPrijslijst_u02<T>(int? p_VergelijkingID) where T : SqlResponse;
	}

	#endregion

	#region Classes

	public class Afspraak
	{
		private ISqlExecutor _executor;
		public Afspraak(ISqlExecutor executor)
		{
			_executor = executor;
		}

		public T csp_PassantenTarief_d01<T>(int? CON_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_PassantenTarief_d01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CON_ID", CON_ID));
			return (T)_executor.Execute(request);
		}

		public T csp_Contract_s10<T>(int? AfspraakID, int? InstantieID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_s10");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", InstantieID));
			return (T)_executor.Execute(request);
		}

		public T csp_Onderhandeling_u15<T>(int? p_AfspraakId, int? p_InstantieId, string p_UserName) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_u15");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakId", p_AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieId", p_InstantieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_UserName", p_UserName));
			return (T)_executor.Execute(request);
		}

		public T csp_PassantenTarief_i02<T>(DateTime p_BeginDatum, DateTime p_EindDatum, int? p_identity, string p_Omschrijving, int? p_SubVersie, string p_username, int? p_Versie, int? p_ZVS_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_PassantenTarief_i02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_BeginDatum", p_BeginDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_EindDatum", p_EindDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_identity", p_identity));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Omschrijving", p_Omschrijving));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_SubVersie", p_SubVersie));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_username", p_username));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Versie", p_Versie));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ZVS_ID", p_ZVS_ID));
			return (T)_executor.Execute(request);
		}

		public T csp_Contract_s11<T>(int? CON_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_s11");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CON_ID", CON_ID));
			return (T)_executor.Execute(request);
		}

		public T csp_Onderhandeling_u16<T>(int? p_AfspraakId, int? p_InstantieId, string p_UserName) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_u16");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakId", p_AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieId", p_InstantieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_UserName", p_UserName));
			return (T)_executor.Execute(request);
		}

		public T csp_PassantenTarief_s01<T>(bool? ActiveOnly, int? AfspraakStijl, int? InstantieID, DateTime MaximumBegindatum, char? segment) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_PassantenTarief_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ActiveOnly", ActiveOnly));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakStijl", AfspraakStijl));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@MaximumBegindatum", MaximumBegindatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@segment", segment));
			return (T)_executor.Execute(request);
		}

		public T csp_Contract_s12<T>(int? AfspraakID, char? p_Segment, int? p_ZorgverstrekkerID, int? p_ZorgverzekeraarID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_s12");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Segment", p_Segment));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ZorgverstrekkerID", p_ZorgverstrekkerID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ZorgverzekeraarID", p_ZorgverzekeraarID));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingGroep_u02<T>(int? OnderhandelingAfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingGroep_u02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandelingAfspraakID", OnderhandelingAfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_PrestatieComponentModel_d01<T>(int? p_MDL_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_PrestatieComponentModel_d01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_MDL_ID", p_MDL_ID));
			return (T)_executor.Execute(request);
		}

		public T csp_Contract_s13<T>(int? AfspraakID, int? AfspraakIDSjabloon, bool? Match) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_s13");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDSjabloon", AfspraakIDSjabloon));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Match", Match));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingGroepsIndelingGroep_s01<T>(int? AfspraakID, int? GroepsIndelingID, int? VergelijkingID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingGroepsIndelingGroep_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GroepsIndelingID", GroepsIndelingID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@VergelijkingID", VergelijkingID));
			return (T)_executor.Execute(request);
		}

		public T csp_PrestatieComponentModel_s01<T>(int? MDL_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_PrestatieComponentModel_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@MDL_ID", MDL_ID));
			return (T)_executor.Execute(request);
		}

		public T csp_Contract_s14<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_s14");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingGroepsIndelingGroep_s04<T>(int? AfspraakID, int? GroepsIndelingID, int? VergelijkingID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingGroepsIndelingGroep_s04");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GroepsIndelingID", GroepsIndelingID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@VergelijkingID", VergelijkingID));
			return (T)_executor.Execute(request);
		}

		public T csp_PrestatieComponentModel_s02<T>(int? MDL_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_PrestatieComponentModel_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@MDL_ID", MDL_ID));
			return (T)_executor.Execute(request);
		}

		public T csp_Contract_s15<T>(int? AnalyseRegioId, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodeList, int? GroepId, int? InstantieId, int? InstantieSoort, DateTime PeilDatum, int? ProvincieId, int? RegioId, string Segment, bool? ToonPassantenTarieven, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> ZorgProductList, int? ZorgverstrekkerId, int? ZorgverzekeraarId) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_s15");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AnalyseRegioId", AnalyseRegioId));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@DeclaratieCodeList", DeclaratieCodeList));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GroepId", GroepId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieId", InstantieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieSoort", InstantieSoort));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeilDatum", PeilDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ProvincieId", ProvincieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@RegioId", RegioId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Segment", Segment));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ToonPassantenTarieven", ToonPassantenTarieven));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@ZorgProductList", ZorgProductList));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerId", ZorgverstrekkerId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", ZorgverzekeraarId));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingPrestatie_s05_incl_vergelijken<T>(int? AfspraakID, bool? AlleenIngesloten, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodes, string DeelVanOmschrijving, bool? ForceerTariefVergelijking, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> GroepFilter, int? GroepFilterType, bool? InclHonorariumComponenten, bool? NegeerPrestatieFilter, int? VergelijkingID, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> ZorgproductCodes) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_s05_incl_vergelijken");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AlleenIngesloten", AlleenIngesloten));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@DeclaratieCodes", DeclaratieCodes));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DeelVanOmschrijving", DeelVanOmschrijving));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ForceerTariefVergelijking", ForceerTariefVergelijking));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@GroepFilter", GroepFilter));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GroepFilterType", GroepFilterType));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InclHonorariumComponenten", InclHonorariumComponenten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@NegeerPrestatieFilter", NegeerPrestatieFilter));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@VergelijkingID", VergelijkingID));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@ZorgproductCodes", ZorgproductCodes));
			return (T)_executor.Execute(request);
		}

		public T csp_PrestatieComponentModel_u01<T>(int? AfspraakID, int? p_MDLDBC_Aantal, decimal? p_MDLDBC_Specialisten, decimal? p_MDLDBC_Ziekenhuis, string p_username, int? PrestatieID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_PrestatieComponentModel_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_MDLDBC_Aantal", p_MDLDBC_Aantal));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_MDLDBC_Specialisten", p_MDLDBC_Specialisten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_MDLDBC_Ziekenhuis", p_MDLDBC_Ziekenhuis));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_username", p_username));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrestatieID", PrestatieID));
			return (T)_executor.Execute(request);
		}

		public T csp_Contract_s16<T>(int? ZorgverstrekkerID, int? ZorgverzekeraarID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_s16");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerID", ZorgverstrekkerID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarID", ZorgverzekeraarID));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingPrestatie_s07_incl_vergelijken<T>(int? AfspraakID, bool? AlleenIngesloten, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodes, string DeelVanOmschrijving, bool? ForceerTariefVergelijking, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> GroepFilter, int? GroepFilterType, bool? NegeerPrestatieFilter, int? VergelijkingID, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> ZorgproductCodes) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_s07_incl_vergelijken");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AlleenIngesloten", AlleenIngesloten));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@DeclaratieCodes", DeclaratieCodes));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DeelVanOmschrijving", DeelVanOmschrijving));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ForceerTariefVergelijking", ForceerTariefVergelijking));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@GroepFilter", GroepFilter));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GroepFilterType", GroepFilterType));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@NegeerPrestatieFilter", NegeerPrestatieFilter));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@VergelijkingID", VergelijkingID));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@ZorgproductCodes", ZorgproductCodes));
			return (T)_executor.Execute(request);
		}

		public T csp_PrestatieComponentPassantenTarief_i01<T>(int? l_DBC_ID, int? p_CON_ID, decimal? p_CONDBC_Specialisten, decimal? p_CONDBC_Ziekenhuis, DateTime p_DatumIngang, char? p_DeclaratieCode, decimal? p_PoortSpecialismePrijs, string p_prestatieCode, string p_SPC_Code, string p_username) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_PrestatieComponentPassantenTarief_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@l_DBC_ID", l_DBC_ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_CON_ID", p_CON_ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_CONDBC_Specialisten", p_CONDBC_Specialisten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_CONDBC_Ziekenhuis", p_CONDBC_Ziekenhuis));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_DatumIngang", p_DatumIngang));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_DeclaratieCode", p_DeclaratieCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_PoortSpecialismePrijs", p_PoortSpecialismePrijs));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_prestatieCode", p_prestatieCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_SPC_Code", p_SPC_Code));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_username", p_username));
			return (T)_executor.Execute(request);
		}

		public T csp_Contract_s17<T>(bool? ActiveOnly, int? AfspraakID, bool? InclChildContracten, int? InstantieID, int? ZorgsoortID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_s17");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ActiveOnly", ActiveOnly));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InclChildContracten", InclChildContracten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgsoortID", ZorgsoortID));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingPrestatie_u03<T>(int? AfspraakID, char? DeclaratieCode, IEnumerable<Database.UserDefinedTypes.Afspraak.udtPrestatieInfoTable> Prestaties, decimal? PrijsHon0303, decimal? PrijsHon0307, decimal? PrijsHon0313, decimal? PrijsHon0316, decimal? PrijsHon0318, decimal? PrijsHon0320, decimal? PrijsHon0322, decimal? PrijsHon0330, decimal? PrijsHon0361, decimal? PrijsHon0362, decimal? PrijsHon0363, decimal? PrijsHon0386, decimal? PrijsHon0387, decimal? PrijsHon0388, decimal? PrijsHon0389, decimal? PrijsHonNietOndh, decimal? PrijsHonOverig, decimal? PrijsZKH) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_u03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DeclaratieCode", DeclaratieCode));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@Prestaties", Prestaties));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsHon0303", PrijsHon0303));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsHon0307", PrijsHon0307));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsHon0313", PrijsHon0313));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsHon0316", PrijsHon0316));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsHon0318", PrijsHon0318));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsHon0320", PrijsHon0320));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsHon0322", PrijsHon0322));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsHon0330", PrijsHon0330));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsHon0361", PrijsHon0361));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsHon0362", PrijsHon0362));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsHon0363", PrijsHon0363));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsHon0386", PrijsHon0386));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsHon0387", PrijsHon0387));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsHon0388", PrijsHon0388));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsHon0389", PrijsHon0389));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsHonNietOndh", PrijsHonNietOndh));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsHonOverig", PrijsHonOverig));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsZKH", PrijsZKH));
			return (T)_executor.Execute(request);
		}

		public T csp_PrestatieComponentPassantenTarief_i02<T>(int? p_CON_ID, int? p_CONDBC_Aantal, decimal? p_CONDBC_Specialisten, decimal? p_CONDBC_Ziekenhuis, int? p_DBC_ID, char? p_status, string p_username) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_PrestatieComponentPassantenTarief_i02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_CON_ID", p_CON_ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_CONDBC_Aantal", p_CONDBC_Aantal));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_CONDBC_Specialisten", p_CONDBC_Specialisten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_CONDBC_Ziekenhuis", p_CONDBC_Ziekenhuis));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_DBC_ID", p_DBC_ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_status", p_status));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_username", p_username));
			return (T)_executor.Execute(request);
		}

		public T csp_Contract_s18<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_s18");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingPrestatie_u04<T>(int? AfspraakID, int? AfwBasis, object AfwHon0303, object AfwHon0307, object AfwHon0313, object AfwHon0316, object AfwHon0318, object AfwHon0320, object AfwHon0322, object AfwHon0330, object AfwHon0361, object AfwHon0362, object AfwHon0363, object AfwHon0386, object AfwHon0387, object AfwHon0388, object AfwHon0389, object AfwHonNietOndh, object AfwHonOndh, object AfwHonOverig, object AfwZKH, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodes, int? GroepId, bool? OnderhandelingGewijzigd) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_u04");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwBasis", AfwBasis));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwHon0303", AfwHon0303));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwHon0307", AfwHon0307));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwHon0313", AfwHon0313));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwHon0316", AfwHon0316));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwHon0318", AfwHon0318));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwHon0320", AfwHon0320));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwHon0322", AfwHon0322));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwHon0330", AfwHon0330));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwHon0361", AfwHon0361));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwHon0362", AfwHon0362));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwHon0363", AfwHon0363));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwHon0386", AfwHon0386));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwHon0387", AfwHon0387));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwHon0388", AfwHon0388));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwHon0389", AfwHon0389));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwHonNietOndh", AfwHonNietOndh));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwHonOndh", AfwHonOndh));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwHonOverig", AfwHonOverig));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwZKH", AfwZKH));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@DeclaratieCodes", DeclaratieCodes));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GroepId", GroepId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandelingGewijzigd", OnderhandelingGewijzigd));
			return (T)_executor.Execute(request);
		}

		public T csp_PrestatieFilter_s01<T>(bool? InclSpeerpunt, int? InstantieID, DateTime PeriodeEind, DateTime PeriodeStart, string Segment) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_PrestatieFilter_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InclSpeerpunt", InclSpeerpunt));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeriodeEind", PeriodeEind));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeriodeStart", PeriodeStart));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Segment", Segment));
			return (T)_executor.Execute(request);
		}

		public T csp_Contract_s19<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_s19");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingPrestatie_u10<T>(int? AfspraakID, object Afw, int? AfwBasis, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodes, bool? OnderhandelingGewijzigd) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_u10");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Afw", Afw));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwBasis", AfwBasis));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@DeclaratieCodes", DeclaratieCodes));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandelingGewijzigd", OnderhandelingGewijzigd));
			return (T)_executor.Execute(request);
		}

		public T csp_PrestatiesOpGrijzeEnZwarteLijst_d01<T>(int? AfspraakId) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_PrestatiesOpGrijzeEnZwarteLijst_d01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakId", AfspraakId));
			return (T)_executor.Execute(request);
		}

		public T csp_Contract_s20<T>(int? AnalyseRegioId, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodeList, int? GroepId, int? InstantieId, int? InstantieSoort, DateTime PeilDatum, int? ProvincieId, int? RegioId, string Segment, bool? ToonPassantenTarieven, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> ZorgProductList, int? ZorgverstrekkerId, int? ZorgverzekeraarId) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_s20");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AnalyseRegioId", AnalyseRegioId));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@DeclaratieCodeList", DeclaratieCodeList));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GroepId", GroepId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieId", InstantieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieSoort", InstantieSoort));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeilDatum", PeilDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ProvincieId", ProvincieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@RegioId", RegioId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Segment", Segment));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ToonPassantenTarieven", ToonPassantenTarieven));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@ZorgProductList", ZorgProductList));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerId", ZorgverstrekkerId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", ZorgverzekeraarId));
			return (T)_executor.Execute(request);
		}

		public T csp_PassantenTarief_i01<T>(DateTime p_BeginDatum, DateTime p_EindDatum, int? p_identity, string p_Omschrijving, int? p_SubVersie, string p_username, int? p_Versie, char? p_ZVS_AGBCode) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_PassantenTarief_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_BeginDatum", p_BeginDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_EindDatum", p_EindDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_identity", p_identity));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Omschrijving", p_Omschrijving));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_SubVersie", p_SubVersie));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_username", p_username));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Versie", p_Versie));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ZVS_AGBCode", p_ZVS_AGBCode));
			return (T)_executor.Execute(request);
		}

		public T csp_PrestatiesOpGrijzeEnZwarteLijst_i01<T>(int? AfspraakId) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_PrestatiesOpGrijzeEnZwarteLijst_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakId", AfspraakId));
			return (T)_executor.Execute(request);
		}

		public T csp_Contract_s21<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_s21");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_MarktTariefHonorarium_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_MarktTariefHonorarium_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_PrestatiesOpGrijzeEnZwarteLijst_s01<T>(int? AfspraakId) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_PrestatiesOpGrijzeEnZwarteLijst_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakId", AfspraakId));
			return (T)_executor.Execute(request);
		}

		public T csp_Contract_u03<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_u03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_MarktTariefKosten_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_MarktTariefKosten_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_PrestatiesOpGrijzeEnZwarteLijst_s02<T>(int? AfspraakId, DateTime Peildatum) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_PrestatiesOpGrijzeEnZwarteLijst_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakId", AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Peildatum", Peildatum));
			return (T)_executor.Execute(request);
		}

		public T csp_Contract_u04<T>(int? afspraakId) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_u04");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@afspraakId", afspraakId));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_MaxTariefHonorarium_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_MaxTariefHonorarium_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_RegelResultaat_s01<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_RegelResultaat_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_ContractAfspraak_u01<T>(int? AfspraakID, int? ContactPersoonZVSID, int? ContactPersoonZVZID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ContractAfspraak_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ContactPersoonZVSID", ContactPersoonZVSID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ContactPersoonZVZID", ContactPersoonZVZID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_MaxTariefKosten_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_MaxTariefKosten_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_RegelResultaat_u01<T>(int? AfspraakID, int? InstantieRegelID, string ResultaatToelichting, int? UitgevoerdDoorID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_RegelResultaat_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieRegelID", InstantieRegelID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ResultaatToelichting", ResultaatToelichting));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@UitgevoerdDoorID", UitgevoerdDoorID));
			return (T)_executor.Execute(request);
		}

		public T csp_ContractAfspraakBijlagen_s01<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ContractAfspraakBijlagen_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_MaxTariefTotaal_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_MaxTariefTotaal_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_RegelResultaat_u02<T>(int? AfspraakID, int? InstantieRegelID, int? UitgevoerdDoorID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_RegelResultaat_u02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieRegelID", InstantieRegelID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@UitgevoerdDoorID", UitgevoerdDoorID));
			return (T)_executor.Execute(request);
		}

		public T csp_ContractControleBestaandContract_s01<T>(DateTime BeginDatum, bool? BestaandContract, string Segment, int? ZorgSoort, int? ZVS_ID, int? ZVZ_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ContractControleBestaandContract_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BeginDatum", BeginDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BestaandContract", BestaandContract));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Segment", Segment));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgSoort", ZorgSoort));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVS_ID", ZVS_ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVZ_ID", ZVZ_ID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_MaxTariefTotaalIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_MaxTariefTotaalIntegraal_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Sjabloon_i01<T>(string Code, string Omschrijving, int? SjabloonAfspraakID, string Username) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Sjabloon_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Code", Code));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Omschrijving", Omschrijving));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SjabloonAfspraakID", SjabloonAfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Username", Username));
			return (T)_executor.Execute(request);
		}

		public T csp_ContractControleBestaandContract_s02<T>(int? AfspraakID, DateTime BeginDatum, bool? BestaandContract, DateTime EindDatum, string Segment) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ContractControleBestaandContract_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BeginDatum", BeginDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BestaandContract", BestaandContract));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@EindDatum", EindDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Segment", Segment));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_MaxTariefTotaalIntegraal_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_MaxTariefTotaalIntegraal_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Sjabloon_s01<T>(string segment, int? ZorgSoort) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Sjabloon_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@segment", segment));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgSoort", ZorgSoort));
			return (T)_executor.Execute(request);
		}

		public T csp_ContractControleBestaandContract_s03<T>(int? AfspraakID, bool? BestaandContract) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ContractControleBestaandContract_s03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BestaandContract", BestaandContract));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_MinTariefHonorarium_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_MinTariefHonorarium_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Sjabloon_s02<T>(int? AfspraakID, int? SjabloonAfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Sjabloon_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SjabloonAfspraakID", SjabloonAfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_ContractControleBestaandContractImportTool_s02<T>(char? AGB, char? AGBSoort, DateTime BeginDatum, bool? BestaandContract, DateTime EindDatum, char? UZOVI) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ContractControleBestaandContractImportTool_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AGB", AGB));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AGBSoort", AGBSoort));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BeginDatum", BeginDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BestaandContract", BestaandContract));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@EindDatum", EindDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@UZOVI", UZOVI));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_MinTariefKosten_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_MinTariefKosten_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Sjabloon_s03<T>(int? SjabloonAfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Sjabloon_s03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SjabloonAfspraakID", SjabloonAfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_ContractExport_s01<T>(int? AfspraakID, bool? AlleTarieven, char? ExportInhoud) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ContractExport_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AlleTarieven", AlleTarieven));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ExportInhoud", ExportInhoud));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_TariefSoortInfoIntegraal_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_TariefSoortInfoIntegraal_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Sjabloon_s04<T>(int? AfspraakIDSjabloonNieuw, int? AfspraakIDSjabloonVorig, bool? Identiek) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Sjabloon_s04");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDSjabloonNieuw", AfspraakIDSjabloonNieuw));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDSjabloonVorig", AfspraakIDSjabloonVorig));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Identiek", Identiek));
			return (T)_executor.Execute(request);
		}

		public T csp_ContractGroep_s01<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ContractGroep_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Contract_i05<T>(int? p_AfspraakID, int? p_AfspraakIDContract, bool? p_AutomatischGeaccordeerd, string p_UserName) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_i05");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", p_AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakIDContract", p_AfspraakIDContract));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AutomatischGeaccordeerd", p_AutomatischGeaccordeerd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_UserName", p_UserName));
			return (T)_executor.Execute(request);
		}

		public T csp_Sjabloon_s05<T>(int? InstantieId, int? ZorgSoort) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Sjabloon_s05");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieId", InstantieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgSoort", ZorgSoort));
			return (T)_executor.Execute(request);
		}

		public T csp_ContractGroepsUitzondering_s01<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ContractGroepsUitzondering_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Onderhandeling_i07<T>(int? p_AfspraakID_From, string p_bevestigingsTekst, int? p_InstantieAanZet, int? p_InstantieId, int? p_NewId, Guid p_NewVersieID, string p_Username, string p_VoorgesteldDoor) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_i07");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID_From", p_AfspraakID_From));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_bevestigingsTekst", p_bevestigingsTekst));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieAanZet", p_InstantieAanZet));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieId", p_InstantieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_NewId", p_NewId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_NewVersieID", p_NewVersieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Username", p_Username));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VoorgesteldDoor", p_VoorgesteldDoor));
			return (T)_executor.Execute(request);
		}

		public T csp_SpeerpuntAfspraak_s01<T>(DateTime periodeEind, DateTime periodeStart, string Segment, int? ZorgverstrekkerID, int? ZorgverzekeraarID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_SpeerpuntAfspraak_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@periodeEind", periodeEind));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@periodeStart", periodeStart));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Segment", Segment));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerID", ZorgverstrekkerID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarID", ZorgverzekeraarID));
			return (T)_executor.Execute(request);
		}

		public T csp_ContractPrijslijst_i09<T>(int? AfspraakID, IEnumerable<Database.UserDefinedTypes.Afspraak.udt_GGZPrijslijstTable> PrestatiePrijslijst) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ContractPrijslijst_i09");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@PrestatiePrijslijst", PrestatiePrijslijst));
			return (T)_executor.Execute(request);
		}

		public T csp_Onderhandeling_i08<T>(int? p_AfspraakID_From, string p_bevestigingsTekst, int? p_InstantieAanZet, int? p_InstantieId, int? p_newId, Guid p_NewVersieID, string p_Username) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_i08");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID_From", p_AfspraakID_From));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_bevestigingsTekst", p_bevestigingsTekst));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieAanZet", p_InstantieAanZet));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieId", p_InstantieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_newId", p_newId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_NewVersieID", p_NewVersieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Username", p_Username));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_1416Gelijk_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_1416Gelijk_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_ContractPrijslijst_s02<T>(int? AfspraakID, int? InstantieID, bool? VerrijkSjabloon) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ContractPrijslijst_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@VerrijkSjabloon", VerrijkSjabloon));
			return (T)_executor.Execute(request);
		}

		public T csp_Onderhandeling_u09<T>(int? p_AfspraakID, bool? p_BijwerkenPrijslijst) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_u09");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", p_AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_BijwerkenPrijslijst", p_BijwerkenPrijslijst));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_1416GelijkIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_1416GelijkIntegraal_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_ContractPrijslijst_s03<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ContractPrijslijst_s03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_1416Gelijk_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_1416Gelijk_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_1416GelijkIntegraal_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_1416GelijkIntegraal_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_ContractPrijslijst_s04<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ContractPrijslijst_s04");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_1517Gelijk_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_1517Gelijk_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_1517Gelijk_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_1517Gelijk_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_ContractPrijslijst_s05<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ContractPrijslijst_s05");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_ABSegmentZorgproductenPoorter_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_ABSegmentZorgproductenPoorter_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_1517GelijkIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_1517GelijkIntegraal_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_ContractPrijslijst_s06<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ContractPrijslijst_s06");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_Correcte17CodesAgisAchmea_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_Correcte17CodesAgisAchmea_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_1517GelijkIntegraal_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_1517GelijkIntegraal_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_ContractPrijslijstHonOndhComp_s02<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ContractPrijslijstHonOndhComp_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_Geen16Codes_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_Geen16Codes_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_ABSegmentZorgproductenPoorter_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_ABSegmentZorgproductenPoorter_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_CreateModelContractFromOnderhandeling<T>(int? p_AfspraakID, int? p_InstantieType, int? p_ModelAfspraakID, string p_ModelCode, string p_ModelOmschrijving) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_CreateModelContractFromOnderhandeling");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", p_AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieType", p_InstantieType));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ModelAfspraakID", p_ModelAfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ModelCode", p_ModelCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ModelOmschrijving", p_ModelOmschrijving));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_GeenOnverzekerdeZorg_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_GeenOnverzekerdeZorg_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_CompleetheidInkoopAgisAchmea_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_CompleetheidInkoopAgisAchmea_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_GGZContractPrestatie_s01<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_GGZContractPrestatie_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_MaxTariefHonorarium_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_MaxTariefHonorarium_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_Correcte17CodesAgisAchmea_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_Correcte17CodesAgisAchmea_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_GGZOnderhandelingPrestatie_i01<T>(int? AfspraakID, IEnumerable<Database.UserDefinedTypes.Afspraak.udt_GGZPrijslijstTable> PrestatiePrijslijst) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_GGZOnderhandelingPrestatie_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@PrestatiePrijslijst", PrestatiePrijslijst));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_MaxTariefKosten_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_MaxTariefKosten_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_Correcte17CodesAgisAchmeaComplement_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_Correcte17CodesAgisAchmeaComplement_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_GGZOnderhandelingPrestatie_s01<T>(int? AfspraakID, bool? AlleenIngesloten, int? PrestatieTypeID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_GGZOnderhandelingPrestatie_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AlleenIngesloten", AlleenIngesloten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrestatieTypeID", PrestatieTypeID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_MaxTariefTotaal_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_MaxTariefTotaal_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_Geen16Codes_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_Geen16Codes_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_HonorariumComponent_s01<T>(int? AfspraakID, int? PrestatieID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_HonorariumComponent_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrestatieID", PrestatieID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_MinTariefHonorarium_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_MinTariefHonorarium_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_Geen16CodesIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_Geen16CodesIntegraal_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_HonorariumComponent_s03<T>(int? AfspraakID, int? InstantieID, int? PrestatieID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_HonorariumComponent_s03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrestatieID", PrestatieID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_MinTariefKosten_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_MinTariefKosten_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_Geen16CodesIntegraal_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_Geen16CodesIntegraal_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_HonorariumComponentPassantenTarief_i01<T>(int? AfspraakID, decimal? Kosten, int? PrestatieID, string SpecialismeCode, string Username) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_HonorariumComponentPassantenTarief_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Kosten", Kosten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrestatieID", PrestatieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SpecialismeCode", SpecialismeCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Username", Username));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_OvernemenPrijzen16Pendant_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_OvernemenPrijzen16Pendant_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_GeenOnverzekerdeZorg_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_GeenOnverzekerdeZorg_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_ImportContract8Data_u01<T>(int? p_AfspraakID, Guid p_StagingImportPrijslijstBatchToken) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ImportContract8Data_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", p_AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_StagingImportPrijslijstBatchToken", p_StagingImportPrijslijstBatchToken));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_OvernemenPrijzen17Pendant_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_OvernemenPrijzen17Pendant_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_GeenOnverzekerdeZorgIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_GeenOnverzekerdeZorgIntegraal_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_ImportContractData_u01<T>(int? p_AfspraakID, Guid p_StagingImportPrijslijstBatchToken) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ImportContractData_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", p_AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_StagingImportPrijslijstBatchToken", p_StagingImportPrijslijstBatchToken));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_TotaalHogerDanPassanten_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_TotaalHogerDanPassanten_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_GeenOnverzekerdeZorgIntegraal_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_GeenOnverzekerdeZorgIntegraal_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_ImportModelData_u01<T>(int? AfspraakID, Guid StagingImportPrijslijstBatchToken) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ImportModelData_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@StagingImportPrijslijstBatchToken", StagingImportPrijslijstBatchToken));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_ZwarteLijstBlokkerend_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_ZwarteLijstBlokkerend_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_GGZMutatieTarieven_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_GGZMutatieTarieven_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_ImportPassantenTarieven_u01<T>(int? RecordsInserted, int? RecordsUpdated, int? TogImportBatchLogID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ImportPassantenTarieven_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@RecordsInserted", RecordsInserted));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@RecordsUpdated", RecordsUpdated));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@TogImportBatchLogID", TogImportBatchLogID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_ZwarteLijstBlokkerendIntegraal_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_ZwarteLijstBlokkerendIntegraal_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_GGZSjabloonMaxTarieven_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_GGZSjabloonMaxTarieven_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_ImportVolumeSpecificatie_u01<T>(int? p_AfspraakID, int? p_SpecificatieGebaseerdOpJaar, Guid p_StagingImportVolumeSpecificatieBatchToken, string p_ToegevoegdDoor) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ImportVolumeSpecificatie_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", p_AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_SpecificatieGebaseerdOpJaar", p_SpecificatieGebaseerdOpJaar));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_StagingImportVolumeSpecificatieBatchToken", p_StagingImportVolumeSpecificatieBatchToken));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ToegevoegdDoor", p_ToegevoegdDoor));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_ZwarteLijstWaarschuwend_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_ZwarteLijstWaarschuwend_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_GrijzeLijst_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_GrijzeLijst_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_InstantieRegel_s01<T>(int? AfspraakID, int? InstantieRegelID, bool? OnlyOutdated) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_InstantieRegel_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieRegelID", InstantieRegelID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnlyOutdated", OnlyOutdated));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_ZwarteLijstWaarschuwendIntegraal_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_ZwarteLijstWaarschuwendIntegraal_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_HonorariumToeslagZBC_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_HonorariumToeslagZBC_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_IsOnderhandelenToegestaanInPeriode<T>(DateTime p_PeriodeEind, DateTime p_PeriodeStart, int? p_ZorgverstrekkerID, int? p_ZorgverzekeraarID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_IsOnderhandelenToegestaanInPeriode");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_PeriodeEind", p_PeriodeEind));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_PeriodeStart", p_PeriodeStart));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ZorgverstrekkerID", p_ZorgverstrekkerID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ZorgverzekeraarID", p_ZorgverzekeraarID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_ModelContractAanwezig_Check<T>(int? AfspraakID, int? ModelAfspraakID, string ModelContractCode, string ModelContractCodePrefix, int? OnderhandelingAfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_ModelContractAanwezig_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ModelAfspraakID", ModelAfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ModelContractCode", ModelContractCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ModelContractCodePrefix", ModelContractCodePrefix));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandelingAfspraakID", OnderhandelingAfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Model_d01<T>(int? p_MDL_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Model_d01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_MDL_ID", p_MDL_ID));
			return (T)_executor.Execute(request);
		}

		public T csp_ImportOnderhandelingData_u01<T>(int? p_AfspraakID, bool? p_ImportPrices, bool? p_ImportVolumes, Guid p_StagingImportPrijslijstBatchToken) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ImportOnderhandelingData_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", p_AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ImportPrices", p_ImportPrices));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ImportVolumes", p_ImportVolumes));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_StagingImportPrijslijstBatchToken", p_StagingImportPrijslijstBatchToken));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_NegatieveTarieven_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_NegatieveTarieven_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Model_i01<T>(int? p_identity, string p_MDL_Code, string p_MDL_Omschrijving, string p_username, int? p_ZorgverstrekkerID, int? p_ZorgverzekeraarID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Model_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_identity", p_identity));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_MDL_Code", p_MDL_Code));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_MDL_Omschrijving", p_MDL_Omschrijving));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_username", p_username));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ZorgverstrekkerID", p_ZorgverstrekkerID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ZorgverzekeraarID", p_ZorgverzekeraarID));
			return (T)_executor.Execute(request);
		}

		public T csp_Onderhandeling_i06<T>(int? AfspraakIDBlacklist, int? AfspraakIDSjabloon, int? AfspraakIDSpeerpunt, bool? AutomatischGestart, int? CPN_ZVS_ID, int? CPN_ZVZ_ID, DateTime EindDatum, int? INITIATOR, bool? IsPseudoOnderhandeling, int? NewAfspraakID, int? OnderhandelingUitgangspositieID, string SegmentCode, DateTime StartDatum, string USERNAME, int? ZVS_ID, int? ZVZ_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_i06");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDBlacklist", AfspraakIDBlacklist));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDSjabloon", AfspraakIDSjabloon));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDSpeerpunt", AfspraakIDSpeerpunt));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AutomatischGestart", AutomatischGestart));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CPN_ZVS_ID", CPN_ZVS_ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CPN_ZVZ_ID", CPN_ZVZ_ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@EindDatum", EindDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@INITIATOR", INITIATOR));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@IsPseudoOnderhandeling", IsPseudoOnderhandeling));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@NewAfspraakID", NewAfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandelingUitgangspositieID", OnderhandelingUitgangspositieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SegmentCode", SegmentCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@StartDatum", StartDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@USERNAME", USERNAME));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVS_ID", ZVS_ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVZ_ID", ZVZ_ID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_NegatieveTarievenIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_NegatieveTarievenIntegraal_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Model_s01<T>(int? AfspraakStijl, DateTime BeginDatum, DateTime EindDatum, int? InstantieID, string Segment) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Model_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakStijl", AfspraakStijl));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BeginDatum", BeginDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@EindDatum", EindDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Segment", Segment));
			return (T)_executor.Execute(request);
		}

		public T csp_Onderhandeling_u08<T>(int? p_AfspraakId, string p_PrestatieFilterCode) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_u08");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakId", p_AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_PrestatieFilterCode", p_PrestatieFilterCode));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_NulTariefHonorariumdeel_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_NulTariefHonorariumdeel_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Model_s02<T>(int? MDL_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Model_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@MDL_ID", MDL_ID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_NulTariefKostendeel_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_NulTariefKostendeel_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Model_u01<T>(string p_MDL_Code, int? p_MDL_ID, string p_MDL_Omschrijving, string p_username) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Model_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_MDL_Code", p_MDL_Code));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_MDL_ID", p_MDL_ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_MDL_Omschrijving", p_MDL_Omschrijving));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_username", p_username));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_OnderhandelingBinnenSjabloon_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_OnderhandelingBinnenSjabloon_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_ModelContractExport_s01<T>(int? AfspraakID, bool? AlleTarieven, char? ExportInhoud) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ModelContractExport_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AlleTarieven", AlleTarieven));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ExportInhoud", ExportInhoud));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_OntbrekenVolumina_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_OntbrekenVolumina_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_ModelContractExport_s02<T>(int? AfspraakID, bool? AlleTarieven) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ModelContractExport_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AlleTarieven", AlleTarieven));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_OvernemenPrijzen16Pendant_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_OvernemenPrijzen16Pendant_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelGeschiedenis_i01<T>(int? AfspraakID, DateTime AktieDatum, int? AktieID, int? GebruikerID, int? InstantieAanZet, string Opmerking, bool? VerbergOpmerkingVoorAnderePartij) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelGeschiedenis_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AktieDatum", AktieDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AktieID", AktieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GebruikerID", GebruikerID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieAanZet", InstantieAanZet));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Opmerking", Opmerking));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@VerbergOpmerkingVoorAnderePartij", VerbergOpmerkingVoorAnderePartij));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_OvernemenPrijzen16PendantIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_OvernemenPrijzen16PendantIntegraal_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelGeschiedenis_s01<T>(int? AfspraakID, int? InstantieID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelGeschiedenis_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", InstantieID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_OvernemenPrijzen16PendantIntegraal_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_OvernemenPrijzen16PendantIntegraal_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Onderhandeling_d01<T>(int? CON_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_d01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CON_ID", CON_ID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_OvernemenPrijzen17Pendant_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_OvernemenPrijzen17Pendant_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Onderhandeling_s00<T>(int? CON_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_s00");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CON_ID", CON_ID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_OvernemenPrijzen17PendantIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_OvernemenPrijzen17PendantIntegraal_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Onderhandeling_s04<T>(int? CON_ORIG_ID, int? INITIATOR) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_s04");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CON_ORIG_ID", CON_ORIG_ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@INITIATOR", INITIATOR));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_OvernemenPrijzen17PendantIntegraal_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_OvernemenPrijzen17PendantIntegraal_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Onderhandeling_s05<T>(int? CON_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_s05");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CON_ID", CON_ID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_PrestatieBinnenGrijzeLijst_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_PrestatieBinnenGrijzeLijst_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Onderhandeling_s06<T>(int? InstantieTypeID, int? ZorgverstrekkerID, int? ZorgverzekeraarID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_s06");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieTypeID", InstantieTypeID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerID", ZorgverstrekkerID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarID", ZorgverzekeraarID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_PrestatieBinnenGrijzeLijst_Solve<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_PrestatieBinnenGrijzeLijst_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Onderhandeling_s07<T>(int? AfspraakStijl, int? InstantieTypeID, DateTime MaximaleToegestaneBegindatum, string SegmentCode, int? ZorgverstrekkerID, int? ZorgverzekeraarID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_s07");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakStijl", AfspraakStijl));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieTypeID", InstantieTypeID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@MaximaleToegestaneBegindatum", MaximaleToegestaneBegindatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SegmentCode", SegmentCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerID", ZorgverstrekkerID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarID", ZorgverzekeraarID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_PrestatieBinnenGrijzeLijstIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_PrestatieBinnenGrijzeLijstIntegraal_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Onderhandeling_s08<T>(DateTime BeginDatum, int? CheckInstantieTypeId, DateTime EindDatum, bool? IncConcepten, int? OnderhandelingenInPeriode, string Segment, int? ZorgverstrekkerID, int? ZorgverzekeraarID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_s08");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BeginDatum", BeginDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CheckInstantieTypeId", CheckInstantieTypeId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@EindDatum", EindDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@IncConcepten", IncConcepten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandelingenInPeriode", OnderhandelingenInPeriode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Segment", Segment));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerID", ZorgverstrekkerID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarID", ZorgverzekeraarID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_PrestatieBinnenGrijzeLijstIntegraal_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_PrestatieBinnenGrijzeLijstIntegraal_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Onderhandeling_s09<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_s09");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_PrestatiesVallenBinnenSjabloonRegel_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_PrestatiesVallenBinnenSjabloonRegel_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Onderhandeling_s10<T>(DateTime BeginDatum, DateTime EindDatum, int? HuidigInstantieTypeId, bool? IncConcepten, int? OnderhandelingenInPeriode, int? ZorgSoortID, int? ZorgverstrekkerID, int? ZorgverzekeraarID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_s10");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BeginDatum", BeginDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@EindDatum", EindDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@HuidigInstantieTypeId", HuidigInstantieTypeId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@IncConcepten", IncConcepten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandelingenInPeriode", OnderhandelingenInPeriode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgSoortID", ZorgSoortID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerID", ZorgverstrekkerID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarID", ZorgverzekeraarID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_TariefSoortInfo_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_TariefSoortInfo_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Onderhandeling_s11<T>(int? InstantieID, int? InstantieType, string SegmentCode, int? ZorgSoort) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_s11");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieType", InstantieType));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SegmentCode", SegmentCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgSoort", ZorgSoort));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_TariefSoortInfo_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_TariefSoortInfo_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Onderhandeling_s12<T>(int? AfspraakId, int? InstantieTypeID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_s12");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakId", AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieTypeID", InstantieTypeID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_TariefSoortInfoIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_TariefSoortInfoIntegraal_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Onderhandeling_s13<T>(int? InstantieTypeID, int? ZorgverstrekkerID, int? ZorgverzekeraarID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_s13");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieTypeID", InstantieTypeID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerID", ZorgverstrekkerID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarID", ZorgverzekeraarID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_TotaalHogerDanPassanten_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_TotaalHogerDanPassanten_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Onderhandeling_u01<T>(DateTime BeginDatum, int? CON_ID, int? ContactPersoonZVSID, int? ContactPersoonZVZID, DateTime EindDatum, bool? HasUpdates, string Omschrijving, string RefZVS, string RefZVZ, string UpdateUser) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BeginDatum", BeginDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CON_ID", CON_ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ContactPersoonZVSID", ContactPersoonZVSID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ContactPersoonZVZID", ContactPersoonZVZID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@EindDatum", EindDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@HasUpdates", HasUpdates));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Omschrijving", Omschrijving));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@RefZVS", RefZVS));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@RefZVZ", RefZVZ));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@UpdateUser", UpdateUser));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_TotaalHogerDanPassantenIntegraal_Check<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_TotaalHogerDanPassantenIntegraal_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Onderhandeling_u06<T>(int? CON_ID, int? ContactPersoonZVSID, int? ContactPersoonZVZID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_u06");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CON_ID", CON_ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ContactPersoonZVSID", ContactPersoonZVSID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ContactPersoonZVZID", ContactPersoonZVZID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_TotaalHogerDanPassantenIntegraal_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_TotaalHogerDanPassantenIntegraal_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Onderhandeling_u07<T>(int? p_AfspraakId, DateTime p_BeginDatum, DateTime p_EindDatum, string p_ReferentieZVS, string p_ReferentieZVZ, int? p_TargetAfspraakIDModel, string p_TariefWijzigingTypeCode) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_u07");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakId", p_AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_BeginDatum", p_BeginDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_EindDatum", p_EindDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ReferentieZVS", p_ReferentieZVS));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ReferentieZVZ", p_ReferentieZVZ));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_TargetAfspraakIDModel", p_TargetAfspraakIDModel));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_TariefWijzigingTypeCode", p_TariefWijzigingTypeCode));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_VoluminaMoet0ZijnBijCodes16Of17_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_VoluminaMoet0ZijnBijCodes16Of17_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Onderhandeling_u10<T>(int? p_AfspraakId, int? p_InstantieTypeID, string p_OnderhandelingOpmerking, string p_Username) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_u10");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakId", p_AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieTypeID", p_InstantieTypeID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingOpmerking", p_OnderhandelingOpmerking));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Username", p_Username));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_VoluminaMoet0ZijnBijCodes16Of17_Solve<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_VoluminaMoet0ZijnBijCodes16Of17_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Onderhandeling_u14<T>(int? p_AfspraakId, int? p_OnderhandelingAfspraakID_HuidigeVersie, int? p_onderhandelingAfspraakID_VorigeVersie, string p_UserName) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_u14");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakId", p_AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingAfspraakID_HuidigeVersie", p_OnderhandelingAfspraakID_HuidigeVersie));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_onderhandelingAfspraakID_VorigeVersie", p_onderhandelingAfspraakID_VorigeVersie));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_UserName", p_UserName));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_VoluminaMoet0ZijnBijCodes16Of17Integraal_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_VoluminaMoet0ZijnBijCodes16Of17Integraal_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingAfspraakBijlage_d01<T>(int? ID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingAfspraakBijlage_d01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ID", ID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_VoluminaMoet0ZijnBijCodes16Of17Integraal_Solve<T>(bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_VoluminaMoet0ZijnBijCodes16Of17Integraal_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingAfspraakBijlage_i01<T>(int? CON_ID, Guid ExtID, string FileName, int? ID, string ToegevoegdDoor, int? Type_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingAfspraakBijlage_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CON_ID", CON_ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ExtID", ExtID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@FileName", FileName));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ID", ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ToegevoegdDoor", ToegevoegdDoor));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Type_ID", Type_ID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_ZwarteLijstBlokkerend_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_ZwarteLijstBlokkerend_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingAfspraakBijlage_s01<T>(int? CON_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingAfspraakBijlage_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CON_ID", CON_ID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_ZwarteLijstBlokkerendIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_ZwarteLijstBlokkerendIntegraal_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingExport_s01<T>(int? AfspraakID, bool? AllePrestaties, bool? AlleTarieven, char? ExportInhoud) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingExport_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AllePrestaties", AllePrestaties));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AlleTarieven", AlleTarieven));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ExportInhoud", ExportInhoud));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_ZwarteLijstWaarschuwend_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_ZwarteLijstWaarschuwend_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingFlowgegevens_s01<T>(int? AfspraakId, int? InstantieTypeID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingFlowgegevens_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakId", AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieTypeID", InstantieTypeID));
			return (T)_executor.Execute(request);
		}

		public T csp_Validatie_ZwarteLijstWaarschuwendIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_ZwarteLijstWaarschuwendIntegraal_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingGroep_s01<T>(int? p_AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingGroep_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", p_AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_VolumeSpecificatie_s01<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_VolumeSpecificatie_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingGroep_s02<T>(int? p_OnderhandelingGroepID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingGroep_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingGroepID", p_OnderhandelingGroepID));
			return (T)_executor.Execute(request);
		}

		public T csp_VolumeSpecificatie_s02<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_VolumeSpecificatie_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingGroep_u01<T>(object p_AfwijkingConsult, object p_AfwijkingHonOndh, object p_AfwijkingKlinisch, object p_AfwijkingNietKlinisch, object p_AfwijkingZKH, int? p_OnderhandelingGroepID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingGroep_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfwijkingConsult", p_AfwijkingConsult));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfwijkingHonOndh", p_AfwijkingHonOndh));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfwijkingKlinisch", p_AfwijkingKlinisch));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfwijkingNietKlinisch", p_AfwijkingNietKlinisch));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfwijkingZKH", p_AfwijkingZKH));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingGroepID", p_OnderhandelingGroepID));
			return (T)_executor.Execute(request);
		}

		public T csp_VolumeSpecificatie_s03<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_VolumeSpecificatie_s03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingGroep_u03<T>(int? p_OnderhandelingGroepID, bool? p_SelectBack) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingGroep_u03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingGroepID", p_OnderhandelingGroepID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_SelectBack", p_SelectBack));
			return (T)_executor.Execute(request);
		}

		public T csp_VolumeSpecificatie_s04<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_VolumeSpecificatie_s04");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingGroep_u04<T>(int? p_OnderhandelingAfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingGroep_u04");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingAfspraakID", p_OnderhandelingAfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_VolumeSpecificatie_s05<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_VolumeSpecificatie_s05");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingGroepsIndeling_s01<T>(int? AfspraakID, int? InstantieID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingGroepsIndeling_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", InstantieID));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingGroepsIndelingGroep_s02<T>(int? AfspraakID, int? GroepsIndelingID, int? HoofdGroepID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingGroepsIndelingGroep_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GroepsIndelingID", GroepsIndelingID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@HoofdGroepID", HoofdGroepID));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingGroepsIndelingGroep_s03<T>(int? AfspraakID, int? GroepsIndelingID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingGroepsIndelingGroep_s03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GroepsIndelingID", GroepsIndelingID));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingGroepsUitzondering_d01<T>(char? DeclaratieCode, bool? IsVerwijderd, int? OnderhandelingAfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingGroepsUitzondering_d01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DeclaratieCode", DeclaratieCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@IsVerwijderd", IsVerwijderd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandelingAfspraakID", OnderhandelingAfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingGroepsUitzonderingHonOndhComp_d01<T>(int? OnderhandelingGroepsuitzonderingID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingGroepsUitzonderingHonOndhComp_d01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandelingGroepsuitzonderingID", OnderhandelingGroepsuitzonderingID));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingGroepsUitzonderingHonOndhComp_i01<T>(int? OnderhandelingGroepsuitzonderingID, decimal? Prijs, char? SpecialismeCode) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingGroepsUitzonderingHonOndhComp_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandelingGroepsuitzonderingID", OnderhandelingGroepsuitzonderingID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Prijs", Prijs));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SpecialismeCode", SpecialismeCode));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingOpmerking_s01<T>(int? AfspraakID, int? InstantieTypeID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingOpmerking_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieTypeID", InstantieTypeID));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingPrestatie_d01<T>(int? AfspraakID, bool? OnderhandelingGewijzigd, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> PrestatieIds) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_d01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandelingGewijzigd", OnderhandelingGewijzigd));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@PrestatieIds", PrestatieIds));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingPrestatie_d02<T>(int? AfspraakID, bool? OnderhandelingGewijzigd, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> PrestatieIds) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_d02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandelingGewijzigd", OnderhandelingGewijzigd));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@PrestatieIds", PrestatieIds));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingPrestatie_s01<T>(bool? p_FilterAlleenUitzonderingen, char? p_FilterBehandelingCode, string p_FilterDeclaratieCodes, char? p_FilterDiagnoseCode, char? p_FilterZorgTypeCode, char? p_FilterZorgVraagCode, int? p_OnderhandelingGroepID, int? p_PageNr, int? p_PageSize, char? p_SorteringKolom, string p_SorteringVolgorde) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_FilterAlleenUitzonderingen", p_FilterAlleenUitzonderingen));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_FilterBehandelingCode", p_FilterBehandelingCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_FilterDeclaratieCodes", p_FilterDeclaratieCodes));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_FilterDiagnoseCode", p_FilterDiagnoseCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_FilterZorgTypeCode", p_FilterZorgTypeCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_FilterZorgVraagCode", p_FilterZorgVraagCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingGroepID", p_OnderhandelingGroepID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_PageNr", p_PageNr));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_PageSize", p_PageSize));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_SorteringKolom", p_SorteringKolom));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_SorteringVolgorde", p_SorteringVolgorde));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingPrestatie_s02<T>(int? p_AfspraakID, char? p_DeclaratieCode) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", p_AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_DeclaratieCode", p_DeclaratieCode));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingPrestatie_s03<T>(int? p_OnderhandelingGroepID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_s03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingGroepID", p_OnderhandelingGroepID));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingPrestatie_s04<T>(int? p_AfspraakID, char? p_DeclaratieCode) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_s04");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", p_AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_DeclaratieCode", p_DeclaratieCode));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingPrestatie_s05<T>(int? AfspraakID, bool? AlleenIngesloten, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodes, string DeelVanOmschrijving, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> GroepFilter, int? GroepFilterType, bool? NegeerPrestatieFilter, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> ZorgproductCodes) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_s05");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AlleenIngesloten", AlleenIngesloten));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@DeclaratieCodes", DeclaratieCodes));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DeelVanOmschrijving", DeelVanOmschrijving));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@GroepFilter", GroepFilter));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GroepFilterType", GroepFilterType));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@NegeerPrestatieFilter", NegeerPrestatieFilter));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@ZorgproductCodes", ZorgproductCodes));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingPrestatie_s06<T>(int? AfspraakID, bool? AlleenIngesloten, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodes, string DeelVanOmschrijving, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> GroepFilter, int? GroepFilterType) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_s06");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AlleenIngesloten", AlleenIngesloten));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@DeclaratieCodes", DeclaratieCodes));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DeelVanOmschrijving", DeelVanOmschrijving));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@GroepFilter", GroepFilter));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GroepFilterType", GroepFilterType));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingPrestatie_s07<T>(int? AfspraakID, bool? AlleenIngesloten, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodes, string DeelVanOmschrijving, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> GroepFilter, int? GroepFilterType, bool? NegeerPrestatieFilter, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> ZorgproductCodes) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_s07");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AlleenIngesloten", AlleenIngesloten));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@DeclaratieCodes", DeclaratieCodes));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DeelVanOmschrijving", DeelVanOmschrijving));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@GroepFilter", GroepFilter));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GroepFilterType", GroepFilterType));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@NegeerPrestatieFilter", NegeerPrestatieFilter));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@ZorgproductCodes", ZorgproductCodes));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingPrestatie_u01<T>(char? p_DeclaratieCode, bool? p_ForceerGroepsuitzondering, bool? p_Ingesloten, int? p_OnderhandelingAfspraakID, int? p_OnderhandelingGroepsUitzonderingID, decimal? p_PrijsHonOndh, decimal? p_PrijsZKH, char? p_TariefWijzigingTypeCode) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_DeclaratieCode", p_DeclaratieCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ForceerGroepsuitzondering", p_ForceerGroepsuitzondering));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Ingesloten", p_Ingesloten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingAfspraakID", p_OnderhandelingAfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingGroepsUitzonderingID", p_OnderhandelingGroepsUitzonderingID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_PrijsHonOndh", p_PrijsHonOndh));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_PrijsZKH", p_PrijsZKH));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_TariefWijzigingTypeCode", p_TariefWijzigingTypeCode));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingPrestatie_u02<T>(int? p_OnderhandelingAfspraakID, int? p_PrestatieID, bool? p_Uitgesloten, int? p_Volume) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_u02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingAfspraakID", p_OnderhandelingAfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_PrestatieID", p_PrestatieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Uitgesloten", p_Uitgesloten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Volume", p_Volume));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingPrestatie_u05<T>(int? AfspraakID, bool? OnderhandelingGewijzigd) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_u05");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandelingGewijzigd", OnderhandelingGewijzigd));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingPrestatie_u06<T>(int? AfspraakID, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodes, bool? OnderhandelingGewijzigd) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_u06");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@DeclaratieCodes", DeclaratieCodes));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandelingGewijzigd", OnderhandelingGewijzigd));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingPrestatie_u07<T>(int? AfspraakID, object AfwVolume, bool? OnderhandelingGewijzigd, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> PrestatieIds) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_u07");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwVolume", AfwVolume));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandelingGewijzigd", OnderhandelingGewijzigd));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@PrestatieIds", PrestatieIds));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingPrestatie_u08<T>(int? AfspraakID, char? DeclaratieCode, bool? Ingesloten, decimal? Tarief, int? VolumeComponent1, int? VolumeComponent2, int? VolumeComponent3) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_u08");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DeclaratieCode", DeclaratieCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Ingesloten", Ingesloten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Tarief", Tarief));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@VolumeComponent1", VolumeComponent1));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@VolumeComponent2", VolumeComponent2));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@VolumeComponent3", VolumeComponent3));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingPrestatie_u09<T>(int? AfspraakID, char? DeclaratieCode, IEnumerable<Database.UserDefinedTypes.Afspraak.udtPrestatieInfoTable> Prestaties, decimal? Prijs) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_u09");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DeclaratieCode", DeclaratieCode));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@Prestaties", Prestaties));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Prijs", Prijs));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingPrestatie_u11<T>(int? AfspraakID, object AfwVolume, bool? OnderhandelingGewijzigd, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> PrestatieIds) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_u11");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwVolume", AfwVolume));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandelingGewijzigd", OnderhandelingGewijzigd));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@PrestatieIds", PrestatieIds));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingPrestatieTariefSoort_s01<T>(int? AfspraakID, char? DeclaratieCode) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatieTariefSoort_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DeclaratieCode", DeclaratieCode));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingPrestatieTariefSoort_s02<T>(int? AfspraakID, char? DeclaratieCode) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatieTariefSoort_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DeclaratieCode", DeclaratieCode));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingPrestatieToelichting_d01<T>(int? AfspraakID, char? DeclaratieCode) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatieToelichting_d01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DeclaratieCode", DeclaratieCode));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingPrestatieToelichting_s01<T>(int? AfspraakID, char? DeclaratieCode, string Toelichting) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatieToelichting_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DeclaratieCode", DeclaratieCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Toelichting", Toelichting));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingPrestatieToelichting_u01<T>(int? AfspraakID, char? DeclaratieCode, string Toelichting) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatieToelichting_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DeclaratieCode", DeclaratieCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Toelichting", Toelichting));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingPrijslijst_s01<T>(int? AfspraakId, int? CON_ID, bool? IsOnlyAfspraken) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrijslijst_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakId", AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CON_ID", CON_ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@IsOnlyAfspraken", IsOnlyAfspraken));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingPrijslijst_s02<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrijslijst_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingPrijslijst_s03<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrijslijst_s03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingPrijslijst_u01<T>(int? AfspraakID, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodes, bool? OnderhandelingGewijzigd, int? p_OnderhandelingGroepID, bool? p_SelectBack) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrijslijst_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@DeclaratieCodes", DeclaratieCodes));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandelingGewijzigd", OnderhandelingGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingGroepID", p_OnderhandelingGroepID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_SelectBack", p_SelectBack));
			return (T)_executor.Execute(request);
		}

		public T csp_Afspraak_s01<T>(int? InstantieID, int? ZVS_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Afspraak_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVS_ID", ZVS_ID));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingPrijslijstHonOndhComp_s02<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrijslijstHonOndhComp_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Afspraak_s02<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Afspraak_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingStatusovergangCheck_s01<T>(int? p_AfspraakID, int? p_InstantieID, int? p_NewStatus) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingStatusovergangCheck_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", p_AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieID", p_InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_NewStatus", p_NewStatus));
			return (T)_executor.Execute(request);
		}

		public T csp_Afspraak_s05<T>(int? AfspraakID, int? InstantieID, int? PrestatieID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Afspraak_s05");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrestatieID", PrestatieID));
			return (T)_executor.Execute(request);
		}

		public T csp_contract_i07<T>(int? p_AfspraakID, int? p_AfspraakIDContract, bool? p_AutomatischGeaccordeerd, int? p_ContractAfspraakID, string p_UserName) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_contract_i07");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", p_AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakIDContract", p_AfspraakIDContract));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AutomatischGeaccordeerd", p_AutomatischGeaccordeerd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ContractAfspraakID", p_ContractAfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_UserName", p_UserName));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingUitgangspositie_i01<T>(int? AfspraakIDBlacklist, int? AfspraakIDContract, int? AfspraakIDModel, int? AfspraakIDSjabloon, int? AfspraakIDSpeerpunt, int? AfspraakIDVolumeContract, int? AfspraakIDVolumeModel, int? NewUitgangspositieID, string SegmentCode, bool? TotaalprijsGelijk, string Username) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingUitgangspositie_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDBlacklist", AfspraakIDBlacklist));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDContract", AfspraakIDContract));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDModel", AfspraakIDModel));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDSjabloon", AfspraakIDSjabloon));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDSpeerpunt", AfspraakIDSpeerpunt));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDVolumeContract", AfspraakIDVolumeContract));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDVolumeModel", AfspraakIDVolumeModel));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@NewUitgangspositieID", NewUitgangspositieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SegmentCode", SegmentCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@TotaalprijsGelijk", TotaalprijsGelijk));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Username", Username));
			return (T)_executor.Execute(request);
		}

		public T csp_Afspraak_s06<T>(int? InstantieID, int? PrestatieID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Afspraak_s06");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrestatieID", PrestatieID));
			return (T)_executor.Execute(request);
		}

		public T csp_contract_i08<T>(int? p_AfspraakID, int? p_AfspraakIDContract, bool? p_AutomatischGeaccordeerd, string p_UserName) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_contract_i08");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", p_AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakIDContract", p_AfspraakIDContract));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AutomatischGeaccordeerd", p_AutomatischGeaccordeerd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_UserName", p_UserName));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingUitgangspositie_i02<T>(int? AfspraakIDBlacklist, int? AfspraakIDContract, int? AfspraakIDModel, int? AfspraakIDSjabloon, int? AfspraakIDSpeerpunt, int? AfspraakIDVolumeContract, int? AfspraakIDVolumeModel, int? NewUitgangspositieID, bool? TotaalprijsGelijk, string Username) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingUitgangspositie_i02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDBlacklist", AfspraakIDBlacklist));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDContract", AfspraakIDContract));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDModel", AfspraakIDModel));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDSjabloon", AfspraakIDSjabloon));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDSpeerpunt", AfspraakIDSpeerpunt));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDVolumeContract", AfspraakIDVolumeContract));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDVolumeModel", AfspraakIDVolumeModel));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@NewUitgangspositieID", NewUitgangspositieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@TotaalprijsGelijk", TotaalprijsGelijk));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Username", Username));
			return (T)_executor.Execute(request);
		}

		public T csp_Afspraak_s07<T>(DateTime BeginDatum, DateTime Einddatum, int? InstantieID, char? PoortSpecialismeCode, char? PrestatieCode) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Afspraak_s07");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BeginDatum", BeginDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Einddatum", Einddatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PoortSpecialismeCode", PoortSpecialismeCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrestatieCode", PrestatieCode));
			return (T)_executor.Execute(request);
		}

		public T csp_Contract_i10<T>(int? p_AfspraakID, int? p_AfspraakIDContract, bool? p_AutomatischGeaccordeerd, string p_UserName) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_i10");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", p_AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakIDContract", p_AfspraakIDContract));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AutomatischGeaccordeerd", p_AutomatischGeaccordeerd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_UserName", p_UserName));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingUitgangspositie_i03<T>(int? AfspraakIDSjabloon, int? NieuweUitgangspositieID, string Username) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingUitgangspositie_i03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDSjabloon", AfspraakIDSjabloon));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@NieuweUitgangspositieID", NieuweUitgangspositieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Username", Username));
			return (T)_executor.Execute(request);
		}

		public T csp_Afspraak_u01<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Afspraak_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_ImportOnderhandeling8Data_u01<T>(int? p_AfspraakID, char? p_ImportInhoud, bool? p_ImportPrices, bool? p_ImportVolumes, Guid p_StagingImportPrijslijstBatchToken) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ImportOnderhandeling8Data_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", p_AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ImportInhoud", p_ImportInhoud));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ImportPrices", p_ImportPrices));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ImportVolumes", p_ImportVolumes));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_StagingImportPrijslijstBatchToken", p_StagingImportPrijslijstBatchToken));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingUitgangspositie_i04<T>(int? AfspraakIDBlacklist, int? AfspraakIDContract, int? AfspraakIDModel, int? AfspraakIDSjabloon, int? AfspraakIDSpeerpunt, int? AfspraakIDVolumeContract, int? AfspraakIDVolumeModel, int? NewUitgangspositieID, string Username) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingUitgangspositie_i04");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDBlacklist", AfspraakIDBlacklist));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDContract", AfspraakIDContract));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDModel", AfspraakIDModel));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDSjabloon", AfspraakIDSjabloon));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDSpeerpunt", AfspraakIDSpeerpunt));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDVolumeContract", AfspraakIDVolumeContract));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDVolumeModel", AfspraakIDVolumeModel));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@NewUitgangspositieID", NewUitgangspositieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Username", Username));
			return (T)_executor.Execute(request);
		}

		public T csp_Afspraak_u02<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Afspraak_u02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Model_iu01<T>(int? l_identity, string p_MDL_Code, string p_MDL_Omschrijving, string p_username, char? p_ZVS_AGBCode, char? p_ZVZ_UZOVI) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Model_iu01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@l_identity", l_identity));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_MDL_Code", p_MDL_Code));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_MDL_Omschrijving", p_MDL_Omschrijving));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_username", p_username));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ZVS_AGBCode", p_ZVS_AGBCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ZVZ_UZOVI", p_ZVZ_UZOVI));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingUitgangspositie_s01<T>(int? AfspraakID, int? InstantieID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingUitgangspositie_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", InstantieID));
			return (T)_executor.Execute(request);
		}

		public T csp_Afspraak_u03<T>(int? AfspraakID, DateTime BeginDatum, DateTime EindDatum, string Username) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Afspraak_u03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BeginDatum", BeginDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@EindDatum", EindDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Username", Username));
			return (T)_executor.Execute(request);
		}

		public T csp_Onderhandeling_d04<T>(int? p_AfspraakID, int? p_InstantieId) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_d04");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", p_AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieId", p_InstantieId));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingVolumeSpecificatieGewenst_s01<T>(int? AfspraakId, bool? VolumeSpecificatieGewenst) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingVolumeSpecificatieGewenst_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakId", AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@VolumeSpecificatieGewenst", VolumeSpecificatieGewenst));
			return (T)_executor.Execute(request);
		}

		public T csp_Afspraak_u04<T>(int? AfspraakID, int? InstantieID, string Username, Guid VersieID, Guid VersieIDNieuw) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Afspraak_u04");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Username", Username));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@VersieID", VersieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@VersieIDNieuw", VersieIDNieuw));
			return (T)_executor.Execute(request);
		}

		public T csp_Onderhandeling_d05<T>(int? p_AfspraakID, string p_bevestigingsTekst, int? p_InstantieId, string p_UserName) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_d05");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", p_AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_bevestigingsTekst", p_bevestigingsTekst));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieId", p_InstantieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_UserName", p_UserName));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelPeriode_s01<T>(int? p_ZorgverstrekkerID, int? p_ZorgverzekeraarID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelPeriode_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ZorgverstrekkerID", p_ZorgverstrekkerID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ZorgverzekeraarID", p_ZorgverzekeraarID));
			return (T)_executor.Execute(request);
		}

		public T csp_Afspraak_u05<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Afspraak_u05");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Onderhandeling_i09<T>(int? AfspraakIDBlacklist, int? AfspraakIDSjabloon, int? AfspraakIDSpeerpunt, bool? AutomatischGestart, int? CPN_ZVS_ID, int? CPN_ZVZ_ID, DateTime EindDatum, int? INITIATOR, bool? IsPseudoOnderhandeling, int? NewAfspraakID, int? OnderhandelingUitgangspositieID, string SegmentCode, DateTime StartDatum, int? TariefType, string USERNAME, int? ZVS_ID, int? ZVZ_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_i09");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDBlacklist", AfspraakIDBlacklist));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDSjabloon", AfspraakIDSjabloon));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDSpeerpunt", AfspraakIDSpeerpunt));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AutomatischGestart", AutomatischGestart));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CPN_ZVS_ID", CPN_ZVS_ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CPN_ZVZ_ID", CPN_ZVZ_ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@EindDatum", EindDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@INITIATOR", INITIATOR));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@IsPseudoOnderhandeling", IsPseudoOnderhandeling));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@NewAfspraakID", NewAfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandelingUitgangspositieID", OnderhandelingUitgangspositieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SegmentCode", SegmentCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@StartDatum", StartDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@TariefType", TariefType));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@USERNAME", USERNAME));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVS_ID", ZVS_ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVZ_ID", ZVZ_ID));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelPeriode_s02<T>(int? p_PeriodeID, int? p_ZorgverzekeraarID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelPeriode_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_PeriodeID", p_PeriodeID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ZorgverzekeraarID", p_ZorgverzekeraarID));
			return (T)_executor.Execute(request);
		}

		public T csp_BlacklistAfspraak_s01<T>(DateTime periodeEind, DateTime periodeStart, string Segment, int? ZorgverstrekkerID, int? ZorgverzekeraarID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_BlacklistAfspraak_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@periodeEind", periodeEind));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@periodeStart", periodeStart));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Segment", Segment));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerID", ZorgverstrekkerID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarID", ZorgverzekeraarID));
			return (T)_executor.Execute(request);
		}

		public T csp_Onderhandeling_i10<T>(string AangemaaktDoor, int? AfspraakIDSjabloon, DateTime EindDatum, int? InitierendeInstantieTypeID, int? NieuweAfspraakID, int? OnderhandelingUitgangspositieID, DateTime StartDatum, int? ZorgverstrekkerID, int? ZorgverzekeraarID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_i10");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AangemaaktDoor", AangemaaktDoor));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDSjabloon", AfspraakIDSjabloon));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@EindDatum", EindDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InitierendeInstantieTypeID", InitierendeInstantieTypeID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@NieuweAfspraakID", NieuweAfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandelingUitgangspositieID", OnderhandelingUitgangspositieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@StartDatum", StartDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerID", ZorgverstrekkerID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarID", ZorgverzekeraarID));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelPeriode_save01<T>(bool? p_OnderhandelenToegestaan, int? p_PeriodeID, int? p_ZorgverstrekkerID, int? p_ZorgverzekeraarID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelPeriode_save01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelenToegestaan", p_OnderhandelenToegestaan));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_PeriodeID", p_PeriodeID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ZorgverstrekkerID", p_ZorgverstrekkerID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ZorgverzekeraarID", p_ZorgverzekeraarID));
			return (T)_executor.Execute(request);
		}

		public T csp_Contract_d01<T>(int? p_CON_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_d01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_CON_ID", p_CON_ID));
			return (T)_executor.Execute(request);
		}

		public T csp_Onderhandeling_i11<T>(int? p_AfspraakID_From, string p_bevestigingsTekst, int? p_InstantieAanZet, int? p_NewId, Guid p_NewVersieID, int? p_OnderhandelingAfspraakID, string p_UserName, string p_VoorgesteldDoor, int? p_ZorgSoort) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_i11");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID_From", p_AfspraakID_From));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_bevestigingsTekst", p_bevestigingsTekst));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieAanZet", p_InstantieAanZet));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_NewId", p_NewId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_NewVersieID", p_NewVersieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingAfspraakID", p_OnderhandelingAfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_UserName", p_UserName));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VoorgesteldDoor", p_VoorgesteldDoor));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ZorgSoort", p_ZorgSoort));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandenWerk_d01<T>(DateTime PeriodeEind, DateTime PeriodeStart, int? ZVSID, int? ZVZID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandenWerk_d01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeriodeEind", PeriodeEind));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeriodeStart", PeriodeStart));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVSID", ZVSID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVZID", ZVZID));
			return (T)_executor.Execute(request);
		}

		public T csp_Contract_d02<T>(int? AfspraakId, int? InstantieId, string Username) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_d02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakId", AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieId", InstantieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Username", Username));
			return (T)_executor.Execute(request);
		}

		public T csp_Onderhandeling_i12<T>(int? p_AfspraakID_From, int? p_AfspraakIDVorigeVersie, string p_bevestigingsTekst, int? p_InstantieAanZet, int? p_newId, Guid p_NewVersieID, int? p_OnderhandelingAfspraakID, string p_UserName) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_i12");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID_From", p_AfspraakID_From));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakIDVorigeVersie", p_AfspraakIDVorigeVersie));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_bevestigingsTekst", p_bevestigingsTekst));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieAanZet", p_InstantieAanZet));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_newId", p_newId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_NewVersieID", p_NewVersieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingAfspraakID", p_OnderhandelingAfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_UserName", p_UserName));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandenWerk_s01<T>(int? InvulKwartaal, string Segment, int? SjabloonJaar, int? ZVSID, int? ZVZID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandenWerk_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InvulKwartaal", InvulKwartaal));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Segment", Segment));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SjabloonJaar", SjabloonJaar));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVSID", ZVSID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVZID", ZVZID));
			return (T)_executor.Execute(request);
		}

		public T csp_Contract_d03<T>(int? AfspraakId, int? InstantieId, string Username) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_d03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakId", AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieId", InstantieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Username", Username));
			return (T)_executor.Execute(request);
		}

		public T csp_onderhandeling_i13<T>(int? p_AfspraakID_From, string p_bevestigingsTekst, int? p_InstantieAanZet, int? p_InstantieId, int? p_NewId, Guid p_NewVersieID, string p_Username, string p_VoorgesteldDoor) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_onderhandeling_i13");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID_From", p_AfspraakID_From));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_bevestigingsTekst", p_bevestigingsTekst));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieAanZet", p_InstantieAanZet));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieId", p_InstantieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_NewId", p_NewId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_NewVersieID", p_NewVersieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Username", p_Username));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VoorgesteldDoor", p_VoorgesteldDoor));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandenWerk_s02<T>(IEnumerable<Database.UserDefinedTypes.Overig.udtPeriodeTable> Perioden, int? ZVSID, int? ZVZID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandenWerk_s02");
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@Perioden", Perioden));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVSID", ZVSID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVZID", ZVZID));
			return (T)_executor.Execute(request);
		}

		public T csp_Contract_d04<T>(int? AfspraakId, int? InstantieId, string Username) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_d04");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakId", AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieId", InstantieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Username", Username));
			return (T)_executor.Execute(request);
		}

		public T csp_Onderhandeling_i14<T>(int? p_AfspraakID_From, string p_bevestigingsTekst, int? p_InstantieAanZet, int? p_InstantieId, int? p_newId, Guid p_NewVersieID, string p_Username) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_i14");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID_From", p_AfspraakID_From));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_bevestigingsTekst", p_bevestigingsTekst));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieAanZet", p_InstantieAanZet));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieId", p_InstantieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_newId", p_newId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_NewVersieID", p_NewVersieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Username", p_Username));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandenWerk_s03<T>(DateTime PeriodeEind, DateTime PeriodeStart, int? ZVSID, int? ZVZID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandenWerk_s03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeriodeEind", PeriodeEind));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeriodeStart", PeriodeStart));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVSID", ZVSID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVZID", ZVZID));
			return (T)_executor.Execute(request);
		}

		public T csp_Contract_i04<T>(int? p_identity, int? p_SjabloonAfspraakID, int? p_SubVersie, int? p_Versie) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_i04");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_identity", p_identity));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_SjabloonAfspraakID", p_SjabloonAfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_SubVersie", p_SubVersie));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Versie", p_Versie));
			return (T)_executor.Execute(request);
		}

		public T csp_Onderhandeling_i15<T>(int? p_AfspraakID_From, string p_bevestigingsTekst, int? p_InstantieAanZet, int? p_InstantieId, int? p_NewId, Guid p_NewVersieID, string p_Username, string p_VoorgesteldDoor) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_i15");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID_From", p_AfspraakID_From));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_bevestigingsTekst", p_bevestigingsTekst));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieAanZet", p_InstantieAanZet));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieId", p_InstantieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_NewId", p_NewId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_NewVersieID", p_NewVersieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Username", p_Username));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VoorgesteldDoor", p_VoorgesteldDoor));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandenWerk_s04<T>(DateTime PeriodeEind, DateTime PeriodeStart, bool? VoorgaandJaar, int? ZVSID, int? ZVZID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandenWerk_s04");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeriodeEind", PeriodeEind));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeriodeStart", PeriodeStart));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@VoorgaandJaar", VoorgaandJaar));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVSID", ZVSID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVZID", ZVZID));
			return (T)_executor.Execute(request);
		}

		public T csp_Contract_i06<T>(int? AfspraakID, char? AGBCode, DateTime BeginDatum, string CreateUser, DateTime EindDatum, int? InstantieSubType, string Omschrijving, string Segment, int? SjabloonAfspraakID, char? UZOVI) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_i06");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AGBCode", AGBCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BeginDatum", BeginDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CreateUser", CreateUser));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@EindDatum", EindDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieSubType", InstantieSubType));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Omschrijving", Omschrijving));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Segment", Segment));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SjabloonAfspraakID", SjabloonAfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@UZOVI", UZOVI));
			return (T)_executor.Execute(request);
		}

		public T csp_Onderhandeling_i16<T>(int? p_AfspraakID_From, string p_bevestigingsTekst, int? p_InstantieAanZet, int? p_InstantieId, int? p_newId, Guid p_NewVersieID, string p_Username) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_i16");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID_From", p_AfspraakID_From));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_bevestigingsTekst", p_bevestigingsTekst));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieAanZet", p_InstantieAanZet));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieId", p_InstantieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_newId", p_newId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_NewVersieID", p_NewVersieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Username", p_Username));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandenWerk_s05<T>(DateTime PeriodeEind, DateTime PeriodeStart, int? ZVZID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandenWerk_s05");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeriodeEind", PeriodeEind));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeriodeStart", PeriodeStart));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVZID", ZVZID));
			return (T)_executor.Execute(request);
		}

		public T csp_Contract_i09<T>(int? AfspraakID, char? AGBCode, DateTime BeginDatum, int? ContractAfspraakID, string CreateUser, DateTime EindDatum, int? InstantieSubType, string Omschrijving, int? SjabloonAfspraakID, char? UZOVI) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_i09");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AGBCode", AGBCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BeginDatum", BeginDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ContractAfspraakID", ContractAfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CreateUser", CreateUser));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@EindDatum", EindDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieSubType", InstantieSubType));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Omschrijving", Omschrijving));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SjabloonAfspraakID", SjabloonAfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@UZOVI", UZOVI));
			return (T)_executor.Execute(request);
		}

		public T csp_Onderhandeling_u04<T>(int? p_AfspraakId, string p_bevestigingsTekst, string p_GewijzigdDoor, int? p_InstantieAanZet, int? p_InstantieId, int? p_NewStatus, string p_UserName) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_u04");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakId", p_AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_bevestigingsTekst", p_bevestigingsTekst));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_GewijzigdDoor", p_GewijzigdDoor));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieAanZet", p_InstantieAanZet));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieId", p_InstantieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_NewStatus", p_NewStatus));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_UserName", p_UserName));
			return (T)_executor.Execute(request);
		}

		public T csp_onderhandenwerk_s06<T>(DateTime peilDatum, int? ZVZ_uzovi) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_onderhandenwerk_s06");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@peilDatum", peilDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVZ_uzovi", ZVZ_uzovi));
			return (T)_executor.Execute(request);
		}

		public T csp_Contract_i11<T>(int? AfspraakID, char? AGBCode, DateTime BeginDatum, string CreateUser, DateTime EindDatum, string Omschrijving, IEnumerable<Database.UserDefinedTypes.Tarief.udtTariefPrijslijst> Prijslijst, string Segment, int? SjabloonAfspraakID, char? UZOVI) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_i11");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AGBCode", AGBCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BeginDatum", BeginDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CreateUser", CreateUser));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@EindDatum", EindDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Omschrijving", Omschrijving));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@Prijslijst", Prijslijst));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Segment", Segment));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SjabloonAfspraakID", SjabloonAfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@UZOVI", UZOVI));
			return (T)_executor.Execute(request);
		}

		public T csp_Onderhandeling_u05<T>(int? p_AfspraakId, int? p_InstantieId, string p_UserName) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_u05");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakId", p_AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieId", p_InstantieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_UserName", p_UserName));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandenWerk_u01<T>(bool? AkkoordVerklaard, IEnumerable<Database.UserDefinedTypes.Afspraak.udtOnderhandenWerkComponentenTable> ComponentenHuidigJaar, IEnumerable<Database.UserDefinedTypes.Afspraak.udtOnderhandenWerkComponentenTable> ComponentenVoorgaandJaar, decimal? KostprijsHuidigJaar, decimal? KostprijsVoorgaandJaar, string OpgegevenDoor, DateTime PeriodeEind, DateTime PeriodeStart, int? ZVSID, int? ZVZID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandenWerk_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AkkoordVerklaard", AkkoordVerklaard));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@ComponentenHuidigJaar", ComponentenHuidigJaar));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@ComponentenVoorgaandJaar", ComponentenVoorgaandJaar));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@KostprijsHuidigJaar", KostprijsHuidigJaar));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@KostprijsVoorgaandJaar", KostprijsVoorgaandJaar));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OpgegevenDoor", OpgegevenDoor));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeriodeEind", PeriodeEind));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeriodeStart", PeriodeStart));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVSID", ZVSID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVZID", ZVZID));
			return (T)_executor.Execute(request);
		}

		public T csp_Contract_s06<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_s06");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Onderhandeling_u11<T>(int? p_AfspraakId, string p_bevestigingsTekst, string p_GewijzigdDoor, int? p_NewAkkoordStatus, string p_UserName) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_u11");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakId", p_AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_bevestigingsTekst", p_bevestigingsTekst));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_GewijzigdDoor", p_GewijzigdDoor));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_NewAkkoordStatus", p_NewAkkoordStatus));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_UserName", p_UserName));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandenWerkSjabloon2010_s01<T>(int? InvulKwartaal, string Segment, int? SjabloonJaar, int? ZVSID, int? ZVZID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandenWerkSjabloon2010_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InvulKwartaal", InvulKwartaal));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Segment", Segment));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SjabloonJaar", SjabloonJaar));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVSID", ZVSID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVZID", ZVZID));
			return (T)_executor.Execute(request);
		}

		public T csp_Contract_s07<T>(bool? ActiveOnly, int? AfspraakID, int? AfspraakStijl, bool? InclChildContracten, bool? InclPassantenTarieven, int? InstantieID, DateTime MaximumBegindatum, string Segment) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_s07");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ActiveOnly", ActiveOnly));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakStijl", AfspraakStijl));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InclChildContracten", InclChildContracten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InclPassantenTarieven", InclPassantenTarieven));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@MaximumBegindatum", MaximumBegindatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Segment", Segment));
			return (T)_executor.Execute(request);
		}

		public T csp_Onderhandeling_u12<T>(int? AfspraakId, string BevestigingsTekst, string GewijzigdDoor, int? NieuweOnderhandelingStatus, int? p_InstantieAanZet, string UserName) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_u12");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakId", AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BevestigingsTekst", BevestigingsTekst));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GewijzigdDoor", GewijzigdDoor));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@NieuweOnderhandelingStatus", NieuweOnderhandelingStatus));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieAanZet", p_InstantieAanZet));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@UserName", UserName));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandenWerkSjabloon2010_u01<T>(string Gebruiker, Guid ImportIdentifier, int? InvulKwartaal, string Segment, int? SjabloonJaar, string SjabloonVersie, int? ZVSID, int? ZVZID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandenWerkSjabloon2010_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Gebruiker", Gebruiker));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ImportIdentifier", ImportIdentifier));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InvulKwartaal", InvulKwartaal));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Segment", Segment));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SjabloonJaar", SjabloonJaar));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SjabloonVersie", SjabloonVersie));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVSID", ZVSID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVZID", ZVZID));
			return (T)_executor.Execute(request);
		}

		public T csp_Contract_s08<T>(int? jaartal, char? uzovi, DateTime wijzigingenVanaf) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_s08");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@jaartal", jaartal));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@uzovi", uzovi));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@wijzigingenVanaf", wijzigingenVanaf));
			return (T)_executor.Execute(request);
		}

		public T csp_Onderhandeling_u13<T>(int? AfspraakId, string BevestigingsTekst, string GewijzigdDoor, int? NieuweOnderhandelingStatus, string UserName) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_u13");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakId", AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BevestigingsTekst", BevestigingsTekst));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GewijzigdDoor", GewijzigdDoor));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@NieuweOnderhandelingStatus", NieuweOnderhandelingStatus));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@UserName", UserName));
			return (T)_executor.Execute(request);
		}
	}

	public class Analyse
	{
		private ISqlExecutor _executor;
		public Analyse(ISqlExecutor executor)
		{
			_executor = executor;
		}

		public T csp_BehandelingZwarteLijst_s01<T>(DateTime Peildatum, int? ZorgverzekeraarId) where T : SqlResponse
		{
			var request = new SqlRequest("Analyse", "csp_BehandelingZwarteLijst_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Peildatum", Peildatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", ZorgverzekeraarId));
			return (T)_executor.Execute(request);
		}

		public T csp_BehandelingZwarteLijst_u01<T>(IEnumerable<Database.UserDefinedTypes.Analyse.udtUpdateBehandelingZwarteLijst> UpdateList, int? ZorgverzekeraarId) where T : SqlResponse
		{
			var request = new SqlRequest("Analyse", "csp_BehandelingZwarteLijst_u01");
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@UpdateList", UpdateList));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", ZorgverzekeraarId));
			return (T)_executor.Execute(request);
		}

		public T csp_Periode_s01<T>(DateTime DatumVanaf, bool? p_SortDescending, int? ZorgverzekeraarId) where T : SqlResponse
		{
			var request = new SqlRequest("Analyse", "csp_Periode_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DatumVanaf", DatumVanaf));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_SortDescending", p_SortDescending));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", ZorgverzekeraarId));
			return (T)_executor.Execute(request);
		}

		public T csp_Stamgegeven_s01<T>(DateTime BeginDatum, DateTime EindDatum, string GroepSleutel, int? ZorgverzekeraarId) where T : SqlResponse
		{
			var request = new SqlRequest("Analyse", "csp_Stamgegeven_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BeginDatum", BeginDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@EindDatum", EindDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GroepSleutel", GroepSleutel));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", ZorgverzekeraarId));
			return (T)_executor.Execute(request);
		}

		public T csp_ZorgverstrekkerBudget_d01<T>(int? PeriodeId, int? ZorgSoortId, int? ZorgverstrekkerId, int? ZorgverzekeraarId) where T : SqlResponse
		{
			var request = new SqlRequest("Analyse", "csp_ZorgverstrekkerBudget_d01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeriodeId", PeriodeId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgSoortId", ZorgSoortId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerId", ZorgverstrekkerId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", ZorgverzekeraarId));
			return (T)_executor.Execute(request);
		}

		public T csp_ZorgverstrekkerBudget_s01<T>(int? PeriodeId, int? ZorgSoortId, int? ZorgverstrekkerId, int? ZorgverzekeraarId) where T : SqlResponse
		{
			var request = new SqlRequest("Analyse", "csp_ZorgverstrekkerBudget_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeriodeId", PeriodeId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgSoortId", ZorgSoortId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerId", ZorgverstrekkerId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", ZorgverzekeraarId));
			return (T)_executor.Execute(request);
		}

		public T csp_ZorgverstrekkerBudget_s02<T>(bool? AlleenGecontracteerd, int? CategorieId, bool? InclContracten, bool? InclOnderhandelingen, string Inkoper, int? PeriodeId, int? RegioId, int? ZorgverstrekkerId, int? ZorgverzekeraarId) where T : SqlResponse
		{
			var request = new SqlRequest("Analyse", "csp_ZorgverstrekkerBudget_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AlleenGecontracteerd", AlleenGecontracteerd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CategorieId", CategorieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InclContracten", InclContracten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InclOnderhandelingen", InclOnderhandelingen));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Inkoper", Inkoper));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeriodeId", PeriodeId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@RegioId", RegioId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerId", ZorgverstrekkerId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", ZorgverzekeraarId));
			return (T)_executor.Execute(request);
		}

		public T csp_ZorgverstrekkerBudget_s03<T>(bool? AlleenGecontracteerd, int? CategorieId, bool? InclContracten, bool? InclOnderhandelingen, string Inkoper, int? PeriodeId, int? RegioId, int? ZorgverstrekkerId, int? ZorgverzekeraarId) where T : SqlResponse
		{
			var request = new SqlRequest("Analyse", "csp_ZorgverstrekkerBudget_s03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AlleenGecontracteerd", AlleenGecontracteerd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CategorieId", CategorieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InclContracten", InclContracten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InclOnderhandelingen", InclOnderhandelingen));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Inkoper", Inkoper));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeriodeId", PeriodeId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@RegioId", RegioId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerId", ZorgverstrekkerId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", ZorgverzekeraarId));
			return (T)_executor.Execute(request);
		}

		public T csp_ZorgverstrekkerBudget_s04<T>(int? ZorgverstrekkerId, int? ZorgverzekeraarId) where T : SqlResponse
		{
			var request = new SqlRequest("Analyse", "csp_ZorgverstrekkerBudget_s04");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerId", ZorgverstrekkerId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", ZorgverzekeraarId));
			return (T)_executor.Execute(request);
		}

		public T csp_ZorgverstrekkerBudget_s05<T>(DateTime BeginDatum, DateTime EindDatum, int? PeriodeId, int? ZorgSoortId, int? ZorgverstrekkerId, int? ZorgverzekeraarId) where T : SqlResponse
		{
			var request = new SqlRequest("Analyse", "csp_ZorgverstrekkerBudget_s05");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BeginDatum", BeginDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@EindDatum", EindDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeriodeId", PeriodeId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgSoortId", ZorgSoortId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerId", ZorgverstrekkerId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", ZorgverzekeraarId));
			return (T)_executor.Execute(request);
		}

		public T csp_ZorgverstrekkerBudget_s06<T>(bool? AlleenGecontracteerd, int? CategorieId, bool? InclContracten, bool? InclOnderhandelingen, string Inkoper, int? PeriodeId, int? RegioId, int? ZorgverstrekkerId, int? ZorgverzekeraarId) where T : SqlResponse
		{
			var request = new SqlRequest("Analyse", "csp_ZorgverstrekkerBudget_s06");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AlleenGecontracteerd", AlleenGecontracteerd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CategorieId", CategorieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InclContracten", InclContracten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InclOnderhandelingen", InclOnderhandelingen));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Inkoper", Inkoper));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeriodeId", PeriodeId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@RegioId", RegioId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerId", ZorgverstrekkerId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", ZorgverzekeraarId));
			return (T)_executor.Execute(request);
		}

		public T csp_ZorgverstrekkerBudget_u01<T>(decimal? BudgetTotaal, int? CategorieId, bool? Contracteerbaar, string Contractnummer, decimal? ExternContractTotaal, string Inkoper, string IPZReferentie, decimal? MandaatTotaal, bool? NietInAutoModelcontract, decimal? OmzetAfspraak, int? OmzetAfspraakSoortId, decimal? OmzetPlafond, bool? OnderhandenWerk, string OnderhandenWerkMailadres, int? PeriodeId, decimal? PrijsAfspraak, string PrijsAfspraakOmschrijving, int? RegioId, int? ZorgSoortId, int? ZorgverstrekkerId, int? ZorgverzekeraarId) where T : SqlResponse
		{
			var request = new SqlRequest("Analyse", "csp_ZorgverstrekkerBudget_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BudgetTotaal", BudgetTotaal));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CategorieId", CategorieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Contracteerbaar", Contracteerbaar));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Contractnummer", Contractnummer));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ExternContractTotaal", ExternContractTotaal));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Inkoper", Inkoper));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@IPZReferentie", IPZReferentie));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@MandaatTotaal", MandaatTotaal));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@NietInAutoModelcontract", NietInAutoModelcontract));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OmzetAfspraak", OmzetAfspraak));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OmzetAfspraakSoortId", OmzetAfspraakSoortId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OmzetPlafond", OmzetPlafond));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandenWerk", OnderhandenWerk));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandenWerkMailadres", OnderhandenWerkMailadres));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeriodeId", PeriodeId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsAfspraak", PrijsAfspraak));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsAfspraakOmschrijving", PrijsAfspraakOmschrijving));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@RegioId", RegioId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgSoortId", ZorgSoortId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerId", ZorgverstrekkerId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", ZorgverzekeraarId));
			return (T)_executor.Execute(request);
		}

		public T csp_ZorgverstrekkerBudgetBulk_u01<T>(IEnumerable<Database.UserDefinedTypes.Analyse.udtZorgverstrekkerBudget> BudgetRegels) where T : SqlResponse
		{
			var request = new SqlRequest("Analyse", "csp_ZorgverstrekkerBudgetBulk_u01");
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@BudgetRegels", BudgetRegels));
			return (T)_executor.Execute(request);
		}

		public T csp_ZorgverstrekkersScore_s01<T>(int? AfspraakIDModel, bool? AlleenSpeerpuntPrestaties, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> Categorien, bool? GeenSpeerpuntPrestaties, bool? InclContracten, bool? InclOnderhandelingen, int? RapportagePeriodeID, int? ZorgverzekeraarID) where T : SqlResponse
		{
			var request = new SqlRequest("Analyse", "csp_ZorgverstrekkersScore_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDModel", AfspraakIDModel));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AlleenSpeerpuntPrestaties", AlleenSpeerpuntPrestaties));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@Categorien", Categorien));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GeenSpeerpuntPrestaties", GeenSpeerpuntPrestaties));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InclContracten", InclContracten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InclOnderhandelingen", InclOnderhandelingen));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@RapportagePeriodeID", RapportagePeriodeID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarID", ZorgverzekeraarID));
			return (T)_executor.Execute(request);
		}
	}

	public class DataStaging
	{
		private ISqlExecutor _executor;
		public DataStaging(ISqlExecutor executor)
		{
			_executor = executor;
		}

		public T csp_SpreadTogRecords<T>(int? TogImportBatchLogID) where T : SqlResponse
		{
			var request = new SqlRequest("DataStaging", "csp_SpreadTogRecords");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@TogImportBatchLogID", TogImportBatchLogID));
			return (T)_executor.Execute(request);
		}

		public T csp_TogRecordType36_d01<T>(int? TogImportBatchLogID) where T : SqlResponse
		{
			var request = new SqlRequest("DataStaging", "csp_TogRecordType36_d01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@TogImportBatchLogID", TogImportBatchLogID));
			return (T)_executor.Execute(request);
		}

		public T csp_TogRecordType36_i01<T>(char? AanduidingPrestatiecodelijst, char? DatumEindeTarief, char? DatumIngangTarief, char? DbcDeclaratieCode, char? DbcDeclarerendSpecialisme, char? DbcPoortspecialisme, int? Identity, char? IndicatieDebetCredit, char? IndicatieSoortZorg, char? Kenmerk, char? KenmerkRecord, char? Mutatiecode, char? SoortTarief, char? Tarief, char? ToelichtingMutatie, char? TypeTarief) where T : SqlResponse
		{
			var request = new SqlRequest("DataStaging", "csp_TogRecordType36_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AanduidingPrestatiecodelijst", AanduidingPrestatiecodelijst));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DatumEindeTarief", DatumEindeTarief));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DatumIngangTarief", DatumIngangTarief));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DbcDeclaratieCode", DbcDeclaratieCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DbcDeclarerendSpecialisme", DbcDeclarerendSpecialisme));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DbcPoortspecialisme", DbcPoortspecialisme));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Identity", Identity));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@IndicatieDebetCredit", IndicatieDebetCredit));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@IndicatieSoortZorg", IndicatieSoortZorg));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Kenmerk", Kenmerk));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@KenmerkRecord", KenmerkRecord));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Mutatiecode", Mutatiecode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SoortTarief", SoortTarief));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Tarief", Tarief));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ToelichtingMutatie", ToelichtingMutatie));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@TypeTarief", TypeTarief));
			return (T)_executor.Execute(request);
		}

		public T csp_TogRecordType36_u01<T>(int? TogImportBatchLogID) where T : SqlResponse
		{
			var request = new SqlRequest("DataStaging", "csp_TogRecordType36_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@TogImportBatchLogID", TogImportBatchLogID));
			return (T)_executor.Execute(request);
		}

		public T csp_TogRecordType38_d01<T>(int? TogImportBatchLogID) where T : SqlResponse
		{
			var request = new SqlRequest("DataStaging", "csp_TogRecordType38_d01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@TogImportBatchLogID", TogImportBatchLogID));
			return (T)_executor.Execute(request);
		}

		public T csp_TogRecordType38_u01<T>(int? TogImportBatchLogID) where T : SqlResponse
		{
			var request = new SqlRequest("DataStaging", "csp_TogRecordType38_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@TogImportBatchLogID", TogImportBatchLogID));
			return (T)_executor.Execute(request);
		}
	}

	public class Dbc
	{
		private ISqlExecutor _executor;
		public Dbc(ISqlExecutor executor)
		{
			_executor = executor;
		}

		public T csp_Behandeling_s01<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_Behandeling_s01");
			return (T)_executor.Execute(request);
		}

		public T csp_BehandelingStamdata_s01<T>(DateTime Peildatum) where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_BehandelingStamdata_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Peildatum", Peildatum));
			return (T)_executor.Execute(request);
		}

		public T csp_Diagnose_s01<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_Diagnose_s01");
			return (T)_executor.Execute(request);
		}

		public T csp_Groepsindeling_s01<T>(string GroepNaam, int? GroepsIndelingId) where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_Groepsindeling_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GroepNaam", GroepNaam));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GroepsIndelingId", GroepsIndelingId));
			return (T)_executor.Execute(request);
		}

		public T csp_Periode_d01<T>(int? p_PeriodeID) where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_Periode_d01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_PeriodeID", p_PeriodeID));
			return (T)_executor.Execute(request);
		}

		public T csp_Periode_i01<T>(string p_Omschrijving, DateTime p_PeriodEnd, DateTime p_PeriodStart) where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_Periode_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Omschrijving", p_Omschrijving));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_PeriodEnd", p_PeriodEnd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_PeriodStart", p_PeriodStart));
			return (T)_executor.Execute(request);
		}

		public T csp_Periode_s01<T>(DateTime DatumVanaf, bool? p_SortDescending, int? ZorgverzekeraarId) where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_Periode_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DatumVanaf", DatumVanaf));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_SortDescending", p_SortDescending));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", ZorgverzekeraarId));
			return (T)_executor.Execute(request);
		}

		public T csp_Periode_u01<T>(string p_Omschrijving, int? p_PeriodeID, DateTime p_PeriodEnd, DateTime p_PeriodStart) where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_Periode_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Omschrijving", p_Omschrijving));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_PeriodeID", p_PeriodeID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_PeriodEnd", p_PeriodEnd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_PeriodStart", p_PeriodStart));
			return (T)_executor.Execute(request);
		}

		public T csp_Prestatie_s03<T>(char? AGBCode, string BEH_CODE, char? DBC_DeclaratieCode, char? DBCSEGMENTCODE, string DIA_CODE, int? InstantieID, DateTime PeilDatumTotEnMet, DateTime PeilDatumVanaf, string SPC_CODE, char? UZOVICode, char? ZTY_CODE, char? ZVR_CODE) where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_Prestatie_s03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AGBCode", AGBCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BEH_CODE", BEH_CODE));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DBC_DeclaratieCode", DBC_DeclaratieCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DBCSEGMENTCODE", DBCSEGMENTCODE));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DIA_CODE", DIA_CODE));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeilDatumTotEnMet", PeilDatumTotEnMet));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeilDatumVanaf", PeilDatumVanaf));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SPC_CODE", SPC_CODE));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@UZOVICode", UZOVICode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZTY_CODE", ZTY_CODE));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVR_CODE", ZVR_CODE));
			return (T)_executor.Execute(request);
		}

		public T csp_Prestatie_s04<T>(string DBCCode, int? InstantieID) where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_Prestatie_s04");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DBCCode", DBCCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", InstantieID));
			return (T)_executor.Execute(request);
		}

		public T csp_Prestatie_s05<T>(int? PrestatieID) where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_Prestatie_s05");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrestatieID", PrestatieID));
			return (T)_executor.Execute(request);
		}

		public T csp_Prestatie_s06<T>(string Omschrijving) where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_Prestatie_s06");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Omschrijving", Omschrijving));
			return (T)_executor.Execute(request);
		}

		public T csp_PrestatieCode_s01<T>(int? PrestatieID) where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_PrestatieCode_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrestatieID", PrestatieID));
			return (T)_executor.Execute(request);
		}

		public T csp_PrestatieCode_s02<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_PrestatieCode_s02");
			return (T)_executor.Execute(request);
		}

		public T csp_PrestatieCode_s03<T>(char? PrestatieCode) where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_PrestatieCode_s03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrestatieCode", PrestatieCode));
			return (T)_executor.Execute(request);
		}

		public T csp_PrestatieCode_s06<T>(char? segmentCode) where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_PrestatieCode_s06");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@segmentCode", segmentCode));
			return (T)_executor.Execute(request);
		}

		public T csp_PrestatieCode_s07<T>(char? PoortSpecialismeCode, char? PrestatieCode) where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_PrestatieCode_s07");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PoortSpecialismeCode", PoortSpecialismeCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrestatieCode", PrestatieCode));
			return (T)_executor.Execute(request);
		}

		public T csp_Specialisme_s01<T>(bool? AlleenHonCompSpecialismes) where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_Specialisme_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AlleenHonCompSpecialismes", AlleenHonCompSpecialismes));
			return (T)_executor.Execute(request);
		}

		public T csp_Specialisme_s03<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_Specialisme_s03");
			return (T)_executor.Execute(request);
		}

		public T csp_TariefWijzigingType_s01<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_TariefWijzigingType_s01");
			return (T)_executor.Execute(request);
		}

		public T csp_ZorgType_s01<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_ZorgType_s01");
			return (T)_executor.Execute(request);
		}

		public T csp_ZorgVraag_s01<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_ZorgVraag_s01");
			return (T)_executor.Execute(request);
		}
	}

	public class Help
	{
		private ISqlExecutor _executor;
		public Help(ISqlExecutor executor)
		{
			_executor = executor;
		}

		public T csp_HelpLink_s01<T>(DateTime DatumActief, string LinkCode, string Username) where T : SqlResponse
		{
			var request = new SqlRequest("Help", "csp_HelpLink_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DatumActief", DatumActief));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@LinkCode", LinkCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Username", Username));
			return (T)_executor.Execute(request);
		}
	}

	public class Logs
	{
		private ISqlExecutor _executor;
		public Logs(ISqlExecutor executor)
		{
			_executor = executor;
		}

		public T csp_log4netentries_s01<T>(string p_Application, DateTime p_DateEnd, DateTime p_DateStart, string p_Identity, bool? p_isTechnical, string p_Level) where T : SqlResponse
		{
			var request = new SqlRequest("Logs", "csp_log4netentries_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Application", p_Application));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_DateEnd", p_DateEnd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_DateStart", p_DateStart));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Identity", p_Identity));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_isTechnical", p_isTechnical));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Level", p_Level));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingStatusLog_i01<T>(string ActieReden, int? AfspraakId, string BevestigingsTekst, string GewijzigdDoor) where T : SqlResponse
		{
			var request = new SqlRequest("Logs", "csp_OnderhandelingStatusLog_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ActieReden", ActieReden));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakId", AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BevestigingsTekst", BevestigingsTekst));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GewijzigdDoor", GewijzigdDoor));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingStatusLog_s01<T>(int? AfspraakId) where T : SqlResponse
		{
			var request = new SqlRequest("Logs", "csp_OnderhandelingStatusLog_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakId", AfspraakId));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingStatusLog_s02<T>(int? AfspraakId) where T : SqlResponse
		{
			var request = new SqlRequest("Logs", "csp_OnderhandelingStatusLog_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakId", AfspraakId));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingStatusLog_s03<T>(int? EersteOnderhandelingId) where T : SqlResponse
		{
			var request = new SqlRequest("Logs", "csp_OnderhandelingStatusLog_s03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@EersteOnderhandelingId", EersteOnderhandelingId));
			return (T)_executor.Execute(request);
		}
	}

	public class Organisatie
	{
		private ISqlExecutor _executor;
		public Organisatie(ISqlExecutor executor)
		{
			_executor = executor;
		}

		public T csp_Gebruiker_s07<T>(string CommonName, DateTime totDatum, DateTime vanDatum, int? ZorgSoort) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Gebruiker_s07");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CommonName", CommonName));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@totDatum", totDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@vanDatum", vanDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgSoort", ZorgSoort));
			return (T)_executor.Execute(request);
		}

		public T csp_Gebruiker_s08<T>(string CommonName, DateTime totDatum, DateTime vanDatum, int? zorgSoort) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Gebruiker_s08");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CommonName", CommonName));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@totDatum", totDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@vanDatum", vanDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@zorgSoort", zorgSoort));
			return (T)_executor.Execute(request);
		}

		public T csp_Gebruiker_s09<T>(char? VecozoCertificaatNummer) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Gebruiker_s09");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@VecozoCertificaatNummer", VecozoCertificaatNummer));
			return (T)_executor.Execute(request);
		}

		public T csp_Gebruiker_s11<T>(bool? InclusiefNietGeaccepteerd, int? InstantieID) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Gebruiker_s11");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InclusiefNietGeaccepteerd", InclusiefNietGeaccepteerd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", InstantieID));
			return (T)_executor.Execute(request);
		}

		public T csp_Gebruiker_s13<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Gebruiker_s13");
			return (T)_executor.Execute(request);
		}

		public T csp_Gebruiker_s14<T>(int? InstantieID, bool? ToonVoorgesteldeKoppelingen) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Gebruiker_s14");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ToonVoorgesteldeKoppelingen", ToonVoorgesteldeKoppelingen));
			return (T)_executor.Execute(request);
		}

		public T csp_Gebruiker_u02<T>(string Achternaam, string Email, int? GebruikerID, bool? InActief, string Tussenvoegsel, string UpdateUser, string Voorletters) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Gebruiker_u02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Achternaam", Achternaam));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Email", Email));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GebruikerID", GebruikerID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InActief", InActief));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Tussenvoegsel", Tussenvoegsel));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@UpdateUser", UpdateUser));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Voorletters", Voorletters));
			return (T)_executor.Execute(request);
		}

		public T csp_GebruikerContactPersoon_s01<T>(bool? IncludeDBCSUsers, int? InstantieID, int? ZorgsoortID) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_GebruikerContactPersoon_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@IncludeDBCSUsers", IncludeDBCSUsers));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgsoortID", ZorgsoortID));
			return (T)_executor.Execute(request);
		}

		public T csp_GebruikerInstantie_d01<T>(string GebruikerIds, int? InstantieID) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_GebruikerInstantie_d01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GebruikerIds", GebruikerIds));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", InstantieID));
			return (T)_executor.Execute(request);
		}

		public T csp_GebruikerInstantie_d02<T>(int? GebruikerId, int? InstantieID, int? RemainingInstantieCount) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_GebruikerInstantie_d02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GebruikerId", GebruikerId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@RemainingInstantieCount", RemainingInstantieCount));
			return (T)_executor.Execute(request);
		}

		public T csp_GebruikerInstantie_i01<T>(string CreateUser, int? GebruikerID, int? InstantieID, int? KoppelingVoorgesteldDoor) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_GebruikerInstantie_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CreateUser", CreateUser));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GebruikerID", GebruikerID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@KoppelingVoorgesteldDoor", KoppelingVoorgesteldDoor));
			return (T)_executor.Execute(request);
		}

		public T csp_GebruikerInstantie_s01<T>(int? InstantieID) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_GebruikerInstantie_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", InstantieID));
			return (T)_executor.Execute(request);
		}

		public T csp_GebruikerInstantie_s02<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_GebruikerInstantie_s02");
			return (T)_executor.Execute(request);
		}

		public T csp_GebruikerInstantie_u01<T>(int? GebruikerId, int? InstantieID, int? KoppelingGeaccepteerdDoor) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_GebruikerInstantie_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GebruikerId", GebruikerId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@KoppelingGeaccepteerdDoor", KoppelingGeaccepteerdDoor));
			return (T)_executor.Execute(request);
		}

		public T csp_GebruikerRol_d00<T>(int? GebruikerID, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> ZorgSoortIds) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_GebruikerRol_d00");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GebruikerID", GebruikerID));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@ZorgSoortIds", ZorgSoortIds));
			return (T)_executor.Execute(request);
		}

		public T csp_GebruikerRol_s01<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_GebruikerRol_s01");
			return (T)_executor.Execute(request);
		}

		public T csp_GebruikerRol_u01<T>(string CreateUser, int? GebruikerID, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> teOntnemenRolIDs, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> toeTeKennenRolIDs, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> ZorgSoortIds) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_GebruikerRol_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CreateUser", CreateUser));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GebruikerID", GebruikerID));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@teOntnemenRolIDs", teOntnemenRolIDs));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@toeTeKennenRolIDs", toeTeKennenRolIDs));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@ZorgSoortIds", ZorgSoortIds));
			return (T)_executor.Execute(request);
		}

		public T csp_Instantie_s01<T>(int? InstantieTypeID) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Instantie_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieTypeID", InstantieTypeID));
			return (T)_executor.Execute(request);
		}

		public T csp_Instantie_s02<T>(int? InstantieID) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Instantie_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", InstantieID));
			return (T)_executor.Execute(request);
		}

		public T csp_Instanties_s01<T>(int? InstantieID) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Instanties_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", InstantieID));
			return (T)_executor.Execute(request);
		}

		public T csp_InstantieType_s00<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_InstantieType_s00");
			return (T)_executor.Execute(request);
		}

		public T csp_Provincie_s01<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Provincie_s01");
			return (T)_executor.Execute(request);
		}

		public T csp_Regio_s01<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Regio_s01");
			return (T)_executor.Execute(request);
		}

		public T csp_Rol_s01<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Rol_s01");
			return (T)_executor.Execute(request);
		}

		public T csp_Rol_s02<T>(int? GebruikerID) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Rol_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GebruikerID", GebruikerID));
			return (T)_executor.Execute(request);
		}

		public T csp_Rol_s03<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Rol_s03");
			return (T)_executor.Execute(request);
		}

		public T csp_Settings_i01<T>(int? InstantieID, string SettingName, string SettingValue, int? ZorgSoortID) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Settings_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SettingName", SettingName));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SettingValue", SettingValue));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgSoortID", ZorgSoortID));
			return (T)_executor.Execute(request);
		}

		public T csp_Settings_s01<T>(int? InstantieID, string SettingName, int? ZorgSoortID) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Settings_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SettingName", SettingName));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgSoortID", ZorgSoortID));
			return (T)_executor.Execute(request);
		}

		public T csp_Taak_s01<T>(int? GebruikerID) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Taak_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GebruikerID", GebruikerID));
			return (T)_executor.Execute(request);
		}

		public T csp_Zorgverstrekker_s01<T>(char? p_AGB, char? p_AGBSoort, int? p_CTGCategorie, int? p_CTGNummer) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Zorgverstrekker_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AGB", p_AGB));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AGBSoort", p_AGBSoort));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_CTGCategorie", p_CTGCategorie));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_CTGNummer", p_CTGNummer));
			return (T)_executor.Execute(request);
		}

		public T csp_Zorgverstrekker_s06<T>(DateTime totDatum, DateTime vanDatum, int? zorgSoort) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Zorgverstrekker_s06");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@totDatum", totDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@vanDatum", vanDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@zorgSoort", zorgSoort));
			return (T)_executor.Execute(request);
		}

		public T csp_Zorgverstrekker_s11<T>(int? ZorgverstrekkerID) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Zorgverstrekker_s11");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerID", ZorgverstrekkerID));
			return (T)_executor.Execute(request);
		}

		public T csp_Zorgverstrekker_s13<T>(char? p_AGBParent) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Zorgverstrekker_s13");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AGBParent", p_AGBParent));
			return (T)_executor.Execute(request);
		}

		public T csp_Zorgverstrekker_u01<T>(string Adres, char? AGB, char? AGBSoort, int? CTGCategorie, int? CTGNummer, string Email, int? ID, bool? Inactief, bool? IsHoofdLocatie, string Naam, string Plaats, string Postcode, string Telefoonnummer, string UpdateUser, string Website) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Zorgverstrekker_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Adres", Adres));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AGB", AGB));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AGBSoort", AGBSoort));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CTGCategorie", CTGCategorie));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CTGNummer", CTGNummer));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Email", Email));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ID", ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Inactief", Inactief));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@IsHoofdLocatie", IsHoofdLocatie));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Naam", Naam));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Plaats", Plaats));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Postcode", Postcode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Telefoonnummer", Telefoonnummer));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@UpdateUser", UpdateUser));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Website", Website));
			return (T)_executor.Execute(request);
		}

		public T csp_Zorgverzekeraar_s02<T>(string UZOVI) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Zorgverzekeraar_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@UZOVI", UZOVI));
			return (T)_executor.Execute(request);
		}

		public T csp_Zorgverzekeraar_s10<T>(DateTime totDatum, DateTime vanDatum, int? zorgSoort) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Zorgverzekeraar_s10");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@totDatum", totDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@vanDatum", vanDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@zorgSoort", zorgSoort));
			return (T)_executor.Execute(request);
		}

		public T csp_Zorgverzekeraar_u01<T>(int? ID, string Naam, string UpdateUser, char? UZOVI, string Website) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Zorgverzekeraar_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ID", ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Naam", Naam));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@UpdateUser", UpdateUser));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@UZOVI", UZOVI));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Website", Website));
			return (T)_executor.Execute(request);
		}

		public T csp_AGBSoort_s01<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_AGBSoort_s01");
			return (T)_executor.Execute(request);
		}

		public T csp_Gebruiker_i01<T>(string Achternaam, string CommonName, string CreateUser, string Email, string Tussenvoegsel, string Voorletters) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Gebruiker_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Achternaam", Achternaam));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CommonName", CommonName));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CreateUser", CreateUser));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Email", Email));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Tussenvoegsel", Tussenvoegsel));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Voorletters", Voorletters));
			return (T)_executor.Execute(request);
		}

		public T csp_Gebruiker_s01<T>(string CommonName, int? GebruikerID, bool? InclusiefNietGeaccepteerd) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Gebruiker_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CommonName", CommonName));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GebruikerID", GebruikerID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InclusiefNietGeaccepteerd", InclusiefNietGeaccepteerd));
			return (T)_executor.Execute(request);
		}

		public T csp_Gebruiker_s03<T>(string CommonName) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Gebruiker_s03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CommonName", CommonName));
			return (T)_executor.Execute(request);
		}

		public T csp_Gebruiker_s04<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Gebruiker_s04");
			return (T)_executor.Execute(request);
		}

		public T csp_Gebruiker_s05<T>(string CommonName, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> ZorgSoorten) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Gebruiker_s05");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CommonName", CommonName));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@ZorgSoorten", ZorgSoorten));
			return (T)_executor.Execute(request);
		}
	}

	public class Overig
	{
		private ISqlExecutor _executor;
		public Overig(ISqlExecutor executor)
		{
			_executor = executor;
		}

		public T csp_Automodellen_i01<T>(DateTime datumMax, DateTime datumMin, char? uzovi) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_Automodellen_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMax", datumMax));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMin", datumMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@uzovi", uzovi));
			return (T)_executor.Execute(request);
		}

		public T csp_Automodellen_i02<T>(DateTime datumMax, DateTime datumMin, char? uzovi) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_Automodellen_i02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMax", datumMax));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMin", datumMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@uzovi", uzovi));
			return (T)_executor.Execute(request);
		}

		public T csp_BijlageType_s01<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_BijlageType_s01");
			return (T)_executor.Execute(request);
		}

		public T csp_DisclaimerGetoond_i01<T>(int? AfspraakID, bool? Toegevoegd, string Username) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_DisclaimerGetoond_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Toegevoegd", Toegevoegd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Username", Username));
			return (T)_executor.Execute(request);
		}

		public T csp_DisclaimerGetoond_s01<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_DisclaimerGetoond_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_Export_d01<T>(int? ExportID) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_Export_d01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ExportID", ExportID));
			return (T)_executor.Execute(request);
		}

		public T csp_Export_i01<T>(string AGB, char? AGBSoort, bool? AlleenWijzigingen, DateTime BereikTot, DateTime BereikVan, string CategorieIds, string ExportIndicator, int? exportType, int? fileType, int? HistorischJaartal, int? identity, bool? InclActueleContracten, bool? InclNietSpeerpunten, bool? InclSpeerpunten, bool? InclVervallenContracten, string Inhoud, bool? isNOW, decimal? PrijsZKHMin, string referentie, DateTime wijzigingenVanaf, string ZorgproductCode, int? ZVZ_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_Export_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AGB", AGB));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AGBSoort", AGBSoort));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AlleenWijzigingen", AlleenWijzigingen));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BereikTot", BereikTot));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BereikVan", BereikVan));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CategorieIds", CategorieIds));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ExportIndicator", ExportIndicator));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@exportType", exportType));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@fileType", fileType));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@HistorischJaartal", HistorischJaartal));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@identity", identity));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InclActueleContracten", InclActueleContracten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InclNietSpeerpunten", InclNietSpeerpunten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InclSpeerpunten", InclSpeerpunten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InclVervallenContracten", InclVervallenContracten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Inhoud", Inhoud));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@isNOW", isNOW));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsZKHMin", PrijsZKHMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@referentie", referentie));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@wijzigingenVanaf", wijzigingenVanaf));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgproductCode", ZorgproductCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVZ_ID", ZVZ_ID));
			return (T)_executor.Execute(request);
		}

		public T csp_Export_i02<T>(int? exportType, int? fileType, int? HistorischJaartal, int? identity, string referentie, int? ZVZ_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_Export_i02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@exportType", exportType));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@fileType", fileType));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@HistorischJaartal", HistorischJaartal));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@identity", identity));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@referentie", referentie));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVZ_ID", ZVZ_ID));
			return (T)_executor.Execute(request);
		}

		public T csp_Export_i03<T>(int? exportType, int? fileType, int? identity, string referentie, int? ZVZ_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_Export_i03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@exportType", exportType));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@fileType", fileType));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@identity", identity));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@referentie", referentie));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVZ_ID", ZVZ_ID));
			return (T)_executor.Execute(request);
		}

		public T csp_Export_s01<T>(int? ZVZ_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_Export_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVZ_ID", ZVZ_ID));
			return (T)_executor.Execute(request);
		}

		public T csp_Export_s02<T>(int? ExportID) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_Export_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ExportID", ExportID));
			return (T)_executor.Execute(request);
		}

		public T csp_Export_s03<T>(char? UZOVI) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_Export_s03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@UZOVI", UZOVI));
			return (T)_executor.Execute(request);
		}

		public T csp_Export_u01<T>(int? exportStatus, string fileName, int? ID) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_Export_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@exportStatus", exportStatus));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@fileName", fileName));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ID", ID));
			return (T)_executor.Execute(request);
		}

		public T csp_Export_u02<T>(string FileType, int? ID, int? ZVZ_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_Export_u02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@FileType", FileType));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ID", ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVZ_ID", ZVZ_ID));
			return (T)_executor.Execute(request);
		}

		public T csp_ExportFileType_s01<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_ExportFileType_s01");
			return (T)_executor.Execute(request);
		}

		public T csp_ExportPeriode_s01<T>(bool? alleenWijzigingen, DateTime datumMax, DateTime datumMin, bool? inclActueleContracten, bool? inclVervallenContracten, IEnumerable<Database.UserDefinedTypes.Afspraak.udtInstantiePeriodeTable> nietTeExporterenZorgverstrekkers, decimal? prijsZKHMin, char? uzovi, DateTime wijzigingenVanaf) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_ExportPeriode_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@alleenWijzigingen", alleenWijzigingen));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMax", datumMax));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMin", datumMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclActueleContracten", inclActueleContracten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclVervallenContracten", inclVervallenContracten));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@nietTeExporterenZorgverstrekkers", nietTeExporterenZorgverstrekkers));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@prijsZKHMin", prijsZKHMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@uzovi", uzovi));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@wijzigingenVanaf", wijzigingenVanaf));
			return (T)_executor.Execute(request);
		}

		public T csp_ExportPeriode_u01<T>(bool? alleenWijzigingen, DateTime datumMax, DateTime datumMin, bool? inclActueleContracten, bool? inclVervallenContracten, IEnumerable<Database.UserDefinedTypes.Afspraak.udtInstantiePeriodeTable> nietTeExporterenZorgverstrekkers, decimal? prijsZKHMin, char? uzovi, DateTime wijzigingenVanaf) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_ExportPeriode_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@alleenWijzigingen", alleenWijzigingen));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMax", datumMax));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMin", datumMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclActueleContracten", inclActueleContracten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclVervallenContracten", inclVervallenContracten));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@nietTeExporterenZorgverstrekkers", nietTeExporterenZorgverstrekkers));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@prijsZKHMin", prijsZKHMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@uzovi", uzovi));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@wijzigingenVanaf", wijzigingenVanaf));
			return (T)_executor.Execute(request);
		}

		public T csp_ExportType_s01<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_ExportType_s01");
			return (T)_executor.Execute(request);
		}

		public T csp_RecordType34_s01<T>(bool? alleenWijzigingen, DateTime datumMax, DateTime datumMin, bool? inclActueleContracten, bool? inclVervallenContracten, IEnumerable<Database.UserDefinedTypes.Afspraak.udtInstantiePeriodeTable> nietTeExporterenZorgverstrekkers, decimal? prijsZKHMin, char? uzovi, DateTime wijzigingenVanaf) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_RecordType34_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@alleenWijzigingen", alleenWijzigingen));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMax", datumMax));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMin", datumMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclActueleContracten", inclActueleContracten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclVervallenContracten", inclVervallenContracten));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@nietTeExporterenZorgverstrekkers", nietTeExporterenZorgverstrekkers));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@prijsZKHMin", prijsZKHMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@uzovi", uzovi));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@wijzigingenVanaf", wijzigingenVanaf));
			return (T)_executor.Execute(request);
		}

		public T csp_RecordType45_s01<T>(int? jaartal, char? uzovi, DateTime wijzigingenVanaf) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_RecordType45_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@jaartal", jaartal));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@uzovi", uzovi));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@wijzigingenVanaf", wijzigingenVanaf));
			return (T)_executor.Execute(request);
		}

		public T csp_RecordType45_s03<T>(int? jaartalMax, int? jaartalMin, char? uzovi, DateTime wijzigingenVanaf) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_RecordType45_s03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@jaartalMax", jaartalMax));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@jaartalMin", jaartalMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@uzovi", uzovi));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@wijzigingenVanaf", wijzigingenVanaf));
			return (T)_executor.Execute(request);
		}

		public T csp_RecordTypeAchmeaTIM_s01<T>(char? AgbSoort, DateTime DatumTot, DateTime DatumVanaf, char? Uzovi) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_RecordTypeAchmeaTIM_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AgbSoort", AgbSoort));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DatumTot", DatumTot));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DatumVanaf", DatumVanaf));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Uzovi", Uzovi));
			return (T)_executor.Execute(request);
		}

		public T csp_RecordTypeAchmeaTIMIntegraal_s01<T>(char? AgbSoort, DateTime DatumTot, DateTime DatumVanaf, char? Uzovi) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_RecordTypeAchmeaTIMIntegraal_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AgbSoort", AgbSoort));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DatumTot", DatumTot));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DatumVanaf", DatumVanaf));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Uzovi", Uzovi));
			return (T)_executor.Execute(request);
		}

		public T csp_RecordTypeCZ_s01<T>(int? CON_ID, DateTime wijzigingenVanaf) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_RecordTypeCZ_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CON_ID", CON_ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@wijzigingenVanaf", wijzigingenVanaf));
			return (T)_executor.Execute(request);
		}

		public T csp_RecordTypeCZ_S02<T>(bool? alleenWijzigingen, DateTime datumMax, DateTime datumMin, bool? inclActueleContracten, bool? inclVervallenContracten, IEnumerable<Database.UserDefinedTypes.Afspraak.udtInstantiePeriodeTable> nietTeExporterenZorgverstrekkers, decimal? prijsZKHMin, char? uzovi, DateTime wijzigingenVanaf) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_RecordTypeCZ_S02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@alleenWijzigingen", alleenWijzigingen));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMax", datumMax));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMin", datumMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclActueleContracten", inclActueleContracten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclVervallenContracten", inclVervallenContracten));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@nietTeExporterenZorgverstrekkers", nietTeExporterenZorgverstrekkers));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@prijsZKHMin", prijsZKHMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@uzovi", uzovi));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@wijzigingenVanaf", wijzigingenVanaf));
			return (T)_executor.Execute(request);
		}

		public T csp_RecordTypeCZ_S03<T>(bool? alleenWijzigingen, DateTime datumMax, DateTime datumMin, bool? inclActueleContracten, bool? inclVervallenContracten, IEnumerable<Database.UserDefinedTypes.Afspraak.udtInstantiePeriodeTable> nietTeExporterenZorgverstrekkers, decimal? prijsZKHMin, char? uzovi, DateTime wijzigingenVanaf) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_RecordTypeCZ_S03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@alleenWijzigingen", alleenWijzigingen));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMax", datumMax));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMin", datumMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclActueleContracten", inclActueleContracten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclVervallenContracten", inclVervallenContracten));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@nietTeExporterenZorgverstrekkers", nietTeExporterenZorgverstrekkers));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@prijsZKHMin", prijsZKHMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@uzovi", uzovi));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@wijzigingenVanaf", wijzigingenVanaf));
			return (T)_executor.Execute(request);
		}

		public T csp_RecordTypeCZ_S04<T>(bool? alleenWijzigingen, DateTime datumMax, DateTime datumMin, bool? inclActueleContracten, bool? inclVervallenContracten, IEnumerable<Database.UserDefinedTypes.Afspraak.udtInstantiePeriodeTable> nietTeExporterenZorgverstrekkers, decimal? prijsZKHMin, char? uzovi, DateTime wijzigingenVanaf) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_RecordTypeCZ_S04");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@alleenWijzigingen", alleenWijzigingen));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMax", datumMax));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMin", datumMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclActueleContracten", inclActueleContracten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclVervallenContracten", inclVervallenContracten));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@nietTeExporterenZorgverstrekkers", nietTeExporterenZorgverstrekkers));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@prijsZKHMin", prijsZKHMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@uzovi", uzovi));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@wijzigingenVanaf", wijzigingenVanaf));
			return (T)_executor.Execute(request);
		}

		public T csp_RecordTypeCZ_S05<T>(bool? alleenWijzigingen, DateTime datumMax, DateTime datumMin, bool? inclActueleContracten, bool? inclVervallenContracten, IEnumerable<Database.UserDefinedTypes.Afspraak.udtInstantiePeriodeTable> nietTeExporterenZorgverstrekkers, decimal? prijsZKHMin, char? uzovi, DateTime wijzigingenVanaf) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_RecordTypeCZ_S05");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@alleenWijzigingen", alleenWijzigingen));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMax", datumMax));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMin", datumMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclActueleContracten", inclActueleContracten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclVervallenContracten", inclVervallenContracten));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@nietTeExporterenZorgverstrekkers", nietTeExporterenZorgverstrekkers));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@prijsZKHMin", prijsZKHMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@uzovi", uzovi));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@wijzigingenVanaf", wijzigingenVanaf));
			return (T)_executor.Execute(request);
		}

		public T csp_RecordTypeDatadump_s01<T>(char? agbSoort, DateTime datumMax, DateTime datumMin, bool? inclContracten, bool? inclOnderhandelingen, char? uzovi, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> zvsCategorieen) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_RecordTypeDatadump_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@agbSoort", agbSoort));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMax", datumMax));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMin", datumMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclContracten", inclContracten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclOnderhandelingen", inclOnderhandelingen));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@uzovi", uzovi));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@zvsCategorieen", zvsCategorieen));
			return (T)_executor.Execute(request);
		}

		public T csp_RecordTypeDatadump_s02<T>(char? agb, char? agbSoort, bool? inclContracten, bool? inclNietSpeerpunten, bool? inclOnderhandelingen, bool? inclSpeerpunten, DateTime peildatum, char? uzovi, string zorgproductCode, int? zvsCategorie) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_RecordTypeDatadump_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@agb", agb));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@agbSoort", agbSoort));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclContracten", inclContracten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclNietSpeerpunten", inclNietSpeerpunten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclOnderhandelingen", inclOnderhandelingen));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclSpeerpunten", inclSpeerpunten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@peildatum", peildatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@uzovi", uzovi));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@zorgproductCode", zorgproductCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@zvsCategorie", zvsCategorie));
			return (T)_executor.Execute(request);
		}

		public T csp_RecordTypeMenzisCsv_s01<T>(int? CON_ID, DateTime wijzigingenVanaf) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_RecordTypeMenzisCsv_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CON_ID", CON_ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@wijzigingenVanaf", wijzigingenVanaf));
			return (T)_executor.Execute(request);
		}

		public T csp_RecordTypeMZ_S01<T>(DateTime datumMax, DateTime datumMin, char? uzovi, DateTime wijzigingenVanaf) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_RecordTypeMZ_S01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMax", datumMax));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMin", datumMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@uzovi", uzovi));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@wijzigingenVanaf", wijzigingenVanaf));
			return (T)_executor.Execute(request);
		}

		public T csp_RecordTypeMZ_s02<T>(DateTime datumMax, DateTime datumMin, char? uzovi, DateTime wijzigingenVanaf) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_RecordTypeMZ_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMax", datumMax));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMin", datumMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@uzovi", uzovi));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@wijzigingenVanaf", wijzigingenVanaf));
			return (T)_executor.Execute(request);
		}

		public T csp_SchemaChangeLog_s01<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_SchemaChangeLog_s01");
			return (T)_executor.Execute(request);
		}

		public T csp_TogImportBatchLog_i01<T>(DateTime ImportDatum, bool? IsIncrementeel, int? TogImportBatchLogID, int? TogProductieNummer, int? VersienummerBestand) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_TogImportBatchLog_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ImportDatum", ImportDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@IsIncrementeel", IsIncrementeel));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@TogImportBatchLogID", TogImportBatchLogID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@TogProductieNummer", TogProductieNummer));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@VersienummerBestand", VersienummerBestand));
			return (T)_executor.Execute(request);
		}

		public T csp_TogImportBatchLog_s01<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_TogImportBatchLog_s01");
			return (T)_executor.Execute(request);
		}

		public T csp_TogImportBatchLog_u01<T>(int? AantalRecordsAangepast, int? AantalRecordsToegevoegd, int? AantalRecordsVerwijderd, string Melding, int? Status, string StatusInfo, int? TogImportBatchLogID) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_TogImportBatchLog_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AantalRecordsAangepast", AantalRecordsAangepast));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AantalRecordsToegevoegd", AantalRecordsToegevoegd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AantalRecordsVerwijderd", AantalRecordsVerwijderd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Melding", Melding));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Status", Status));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@StatusInfo", StatusInfo));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@TogImportBatchLogID", TogImportBatchLogID));
			return (T)_executor.Execute(request);
		}

		public T csp_TogImportLog_i01<T>(DateTime Datum, int? Identity, int? ImportGeschiedenisID, string Omschrijving, int? TogRecordType) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_TogImportLog_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Datum", Datum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Identity", Identity));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ImportGeschiedenisID", ImportGeschiedenisID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Omschrijving", Omschrijving));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@TogRecordType", TogRecordType));
			return (T)_executor.Execute(request);
		}
	}

	public class Rapportage
	{
		private ISqlExecutor _executor;
		public Rapportage(ISqlExecutor executor)
		{
			_executor = executor;
		}

		public T csp_ModelAfspraak_s01<T>(int? Zorgverzekeraar) where T : SqlResponse
		{
			var request = new SqlRequest("Rapportage", "csp_ModelAfspraak_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Zorgverzekeraar", Zorgverzekeraar));
			return (T)_executor.Execute(request);
		}

		public T csp_OverzichtContracten_s01<T>(int? InstantieID) where T : SqlResponse
		{
			var request = new SqlRequest("Rapportage", "csp_OverzichtContracten_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", InstantieID));
			return (T)_executor.Execute(request);
		}

		public T csp_OverzichtOnderhandelingen_s01<T>(int? InstantieID) where T : SqlResponse
		{
			var request = new SqlRequest("Rapportage", "csp_OverzichtOnderhandelingen_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", InstantieID));
			return (T)_executor.Execute(request);
		}

		public T csp_Prijsvergelijking_s01<T>(char? agb, bool? inclNietSpeerpunten, bool? inclSpeerpunten, int? rapportageJaar, bool? rapportageNotFound, int? referentieJaar, bool? referentieNotFound, int? zorgverzekeraarId) where T : SqlResponse
		{
			var request = new SqlRequest("Rapportage", "csp_Prijsvergelijking_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@agb", agb));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclNietSpeerpunten", inclNietSpeerpunten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclSpeerpunten", inclSpeerpunten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@rapportageJaar", rapportageJaar));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@rapportageNotFound", rapportageNotFound));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@referentieJaar", referentieJaar));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@referentieNotFound", referentieNotFound));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@zorgverzekeraarId", zorgverzekeraarId));
			return (T)_executor.Execute(request);
		}

		public T csp_ScoreSpeerpunten_s01<T>(int? CategorieId, int? Inhoud, int? ModelAfspraak, int? Niveau, int? Periode, int? RegioId, int? Speerpunt, int? Zorgverzekeraar) where T : SqlResponse
		{
			var request = new SqlRequest("Rapportage", "csp_ScoreSpeerpunten_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CategorieId", CategorieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Inhoud", Inhoud));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ModelAfspraak", ModelAfspraak));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Niveau", Niveau));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Periode", Periode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@RegioId", RegioId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Speerpunt", Speerpunt));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Zorgverzekeraar", Zorgverzekeraar));
			return (T)_executor.Execute(request);
		}

		public T csp_SjabloonPeriode_s01<T>(int? Zorgverzekeraar) where T : SqlResponse
		{
			var request = new SqlRequest("Rapportage", "csp_SjabloonPeriode_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Zorgverzekeraar", Zorgverzekeraar));
			return (T)_executor.Execute(request);
		}

		public T csp_SpeerpuntPeriode_s01<T>(int? Zorgverzekeraar) where T : SqlResponse
		{
			var request = new SqlRequest("Rapportage", "csp_SpeerpuntPeriode_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Zorgverzekeraar", Zorgverzekeraar));
			return (T)_executor.Execute(request);
		}

		public T csp_Voortgang_s01<T>(int? InstantieID, DateTime peildatum_1, DateTime peildatum_2) where T : SqlResponse
		{
			var request = new SqlRequest("Rapportage", "csp_Voortgang_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@peildatum_1", peildatum_1));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@peildatum_2", peildatum_2));
			return (T)_executor.Execute(request);
		}
	}

	public class Tarief
	{
		private ISqlExecutor _executor;
		public Tarief(ISqlExecutor executor)
		{
			_executor = executor;
		}

		public T csp_ContractExport_s01<T>(int? AfspraakID, bool? AlleTarieven, char? ExportInhoud) where T : SqlResponse
		{
			var request = new SqlRequest("Tarief", "csp_ContractExport_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AlleTarieven", AlleTarieven));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ExportInhoud", ExportInhoud));
			return (T)_executor.Execute(request);
		}

		public T csp_CreateModelContractFromOnderhandeling<T>(int? p_AfspraakID, int? p_InstantieType, int? p_ModelAfspraakID, string p_ModelCode, string p_ModelOmschrijving) where T : SqlResponse
		{
			var request = new SqlRequest("Tarief", "csp_CreateModelContractFromOnderhandeling");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", p_AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieType", p_InstantieType));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ModelAfspraakID", p_ModelAfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ModelCode", p_ModelCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ModelOmschrijving", p_ModelOmschrijving));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingExport_s01<T>(int? AfspraakID, bool? AllePrestaties, bool? AlleTarieven, char? ExportInhoud) where T : SqlResponse
		{
			var request = new SqlRequest("Tarief", "csp_OnderhandelingExport_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AllePrestaties", AllePrestaties));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AlleTarieven", AlleTarieven));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ExportInhoud", ExportInhoud));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingPrijslijst_i01<T>(int? AfspraakId, bool? ImportPrices, bool? ImportVolumes, IEnumerable<Database.UserDefinedTypes.Tarief.udtTariefPrijslijst> Prijslijst) where T : SqlResponse
		{
			var request = new SqlRequest("Tarief", "csp_OnderhandelingPrijslijst_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakId", AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ImportPrices", ImportPrices));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ImportVolumes", ImportVolumes));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@Prijslijst", Prijslijst));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingPrijslijst_s01<T>(int? AfspraakId, int? CON_ID, bool? IsOnlyAfspraken) where T : SqlResponse
		{
			var request = new SqlRequest("Tarief", "csp_OnderhandelingPrijslijst_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakId", AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CON_ID", CON_ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@IsOnlyAfspraken", IsOnlyAfspraken));
			return (T)_executor.Execute(request);
		}

		public T csp_OnderhandelingPrijslijst_u01<T>(int? AfspraakID, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodes, bool? OnderhandelingGewijzigd, int? p_OnderhandelingGroepID, bool? p_SelectBack) where T : SqlResponse
		{
			var request = new SqlRequest("Tarief", "csp_OnderhandelingPrijslijst_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@DeclaratieCodes", DeclaratieCodes));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandelingGewijzigd", OnderhandelingGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingGroepID", p_OnderhandelingGroepID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_SelectBack", p_SelectBack));
			return (T)_executor.Execute(request);
		}
	}

	public class Vergelijking
	{
		private ISqlExecutor _executor;
		public Vergelijking(ISqlExecutor executor)
		{
			_executor = executor;
		}

		public T csp_NeemPrijzenOver_u01<T>(int? p_VergelijkingsBronID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_NeemPrijzenOver_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingsBronID", p_VergelijkingsBronID));
			return (T)_executor.Execute(request);
		}

		public T csp_ApplyDetailFilter_u01<T>(int? p_OnderhandelingGroepId, int? p_VergelijkingID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_ApplyDetailFilter_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingGroepId", p_OnderhandelingGroepId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingID", p_VergelijkingID));
			return (T)_executor.Execute(request);
		}

		public T csp_ApplyDetailFilter_u02a<T>(int? p_OnderhandelingGroepId, int? p_VergelijkingID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_ApplyDetailFilter_u02a");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingGroepId", p_OnderhandelingGroepId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingID", p_VergelijkingID));
			return (T)_executor.Execute(request);
		}

		public T csp_ApplyDetailFilter_u02b<T>(char? p_DeclaratieCode, int? p_OnderhandelingGroepId, int? p_VergelijkingID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_ApplyDetailFilter_u02b");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_DeclaratieCode", p_DeclaratieCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingGroepId", p_OnderhandelingGroepId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingID", p_VergelijkingID));
			return (T)_executor.Execute(request);
		}

		public T csp_ApplyDetailFilter_u03<T>(char? p_BehandelingCode, char? p_DiagnoseCode, int? p_OnderhandelingGroepId, int? p_VergelijkingID, char? p_ZorgTypeCode, char? p_ZorgVraagCode) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_ApplyDetailFilter_u03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_BehandelingCode", p_BehandelingCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_DiagnoseCode", p_DiagnoseCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingGroepId", p_OnderhandelingGroepId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingID", p_VergelijkingID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ZorgTypeCode", p_ZorgTypeCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ZorgVraagCode", p_ZorgVraagCode));
			return (T)_executor.Execute(request);
		}

		public T csp_BerekenKosten_i01<T>(int? p_VergelijkingID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_BerekenKosten_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingID", p_VergelijkingID));
			return (T)_executor.Execute(request);
		}

		public T csp_BerekenKosten_i02<T>(int? p_VergelijkingsBronID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_BerekenKosten_i02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingsBronID", p_VergelijkingsBronID));
			return (T)_executor.Execute(request);
		}

		public T csp_CreateVergelijking_i01<T>(int? p_AfspraakID, int? p_AfspraakIDVolumeSjabloon, int? p_VergelijkingID, int? p_VergelijkingType) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_CreateVergelijking_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", p_AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakIDVolumeSjabloon", p_AfspraakIDVolumeSjabloon));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingID", p_VergelijkingID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingType", p_VergelijkingType));
			return (T)_executor.Execute(request);
		}

		public T csp_CreateVergelijkingsBron_i01<T>(int? p_VergelijkingID, int? p_VergelijkingsBronID, int? p_VolumeAfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_CreateVergelijkingsBron_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingID", p_VergelijkingID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingsBronID", p_VergelijkingsBronID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VolumeAfspraakID", p_VolumeAfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_CreateVergelijkingsBron_i02<T>(int? p_AfspraakID, int? p_VergelijkingID, int? p_VergelijkingsBronID, int? p_VolumeAfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_CreateVergelijkingsBron_i02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", p_AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingID", p_VergelijkingID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingsBronID", p_VergelijkingsBronID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VolumeAfspraakID", p_VolumeAfspraakID));
			return (T)_executor.Execute(request);
		}

		public T csp_CreateVergelijkingsPrestatieSet_i01<T>(int? p_VergelijkingID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_CreateVergelijkingsPrestatieSet_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingID", p_VergelijkingID));
			return (T)_executor.Execute(request);
		}

		public T csp_CreateVergelijkingsPrestatieSet_i02<T>(int? p_VergelijkingID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_CreateVergelijkingsPrestatieSet_i02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingID", p_VergelijkingID));
			return (T)_executor.Execute(request);
		}

		public T csp_GetAfspraakData_s<T>(int? p_AfspraakID, int? p_OnderhandelingAfspraakID, int? p_VergelijkingID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_GetAfspraakData_s");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", p_AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingAfspraakID", p_OnderhandelingAfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingID", p_VergelijkingID));
			return (T)_executor.Execute(request);
		}

		public T csp_GetBronKosten_s<T>(int? p_VergelijkingsBronID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_GetBronKosten_s");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingsBronID", p_VergelijkingsBronID));
			return (T)_executor.Execute(request);
		}

		public T csp_GetDetailKosten_s<T>(int? p_OnderhandelingGroepId, int? p_PageNumber, int? p_PageSize, int? p_SortColumn, bool? p_SortOrder, int? p_VergelijkingsBronID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_GetDetailKosten_s");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingGroepId", p_OnderhandelingGroepId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_PageNumber", p_PageNumber));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_PageSize", p_PageSize));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_SortColumn", p_SortColumn));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_SortOrder", p_SortOrder));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingsBronID", p_VergelijkingsBronID));
			return (T)_executor.Execute(request);
		}

		public T csp_GetDetailKosten_s02<T>(int? p_OnderhandelingGroepId, int? p_VergelijkingsBronID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_GetDetailKosten_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingGroepId", p_OnderhandelingGroepId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingsBronID", p_VergelijkingsBronID));
			return (T)_executor.Execute(request);
		}

		public T csp_GetKosten_s<T>(int? p_VergelijkingID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_GetKosten_s");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingID", p_VergelijkingID));
			return (T)_executor.Execute(request);
		}

		public T csp_GetSelectionCount_s<T>(int? p_OnderhandelingGroepId, int? p_VergelijkingID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_GetSelectionCount_s");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingGroepId", p_OnderhandelingGroepId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingID", p_VergelijkingID));
			return (T)_executor.Execute(request);
		}

		public T csp_GetVergelijkingExport_s01<T>(int? vergelijkingsBronID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_GetVergelijkingExport_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@vergelijkingsBronID", vergelijkingsBronID));
			return (T)_executor.Execute(request);
		}

		public T csp_GetVergelijkingExport_s02<T>(int? vergelijkingsBronID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_GetVergelijkingExport_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@vergelijkingsBronID", vergelijkingsBronID));
			return (T)_executor.Execute(request);
		}

		public T csp_HerBerekenKosten_u01<T>(int? p_VergelijkingID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_HerBerekenKosten_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingID", p_VergelijkingID));
			return (T)_executor.Execute(request);
		}

		public T csp_NeemPrijzenOver8_u01<T>(int? AfspraakID, bool? AlleenLagereTarieven, int? BronIndex, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> FilterPrestatieIDs, bool? FilterPrestaties, int? VergelijkingID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_NeemPrijzenOver8_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AlleenLagereTarieven", AlleenLagereTarieven));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BronIndex", BronIndex));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@FilterPrestatieIDs", FilterPrestatieIDs));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@FilterPrestaties", FilterPrestaties));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@VergelijkingID", VergelijkingID));
			return (T)_executor.Execute(request);
		}

		public T csp_NeemPrijzenOver8Integraal_u01<T>(int? AfspraakID, bool? AlleenLagereTarieven, int? BronIndex, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> FilterPrestatieIDs, bool? FilterPrestaties, int? VergelijkingID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_NeemPrijzenOver8Integraal_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AlleenLagereTarieven", AlleenLagereTarieven));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BronIndex", BronIndex));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@FilterPrestatieIDs", FilterPrestatieIDs));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@FilterPrestaties", FilterPrestaties));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@VergelijkingID", VergelijkingID));
			return (T)_executor.Execute(request);
		}

		public T csp_ReCreateVergelijkingsPrestatieSet_u<T>(int? TariefType, int? VergelijkingID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_ReCreateVergelijkingsPrestatieSet_u");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@TariefType", TariefType));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@VergelijkingID", VergelijkingID));
			return (T)_executor.Execute(request);
		}

		public T csp_VergelijkingsBronPrijslijst_u01<T>(int? p_VergelijkingID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_VergelijkingsBronPrijslijst_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingID", p_VergelijkingID));
			return (T)_executor.Execute(request);
		}

		public T csp_VergelijkingsBronPrijslijst_u02<T>(int? p_VergelijkingID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_VergelijkingsBronPrijslijst_u02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingID", p_VergelijkingID));
			return (T)_executor.Execute(request);
		}
	}

	#endregion
}
