using System;
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
		namespace Afspraak
		{
			public class udt_GGZPrijslijstTable
			{
				public int? PrestatieID { get; set; }
				public int? AantalVerblijf { get; set; }
				public decimal? Tarief { get; set; }
				public decimal? TariefBev2 { get; set; }
				public decimal? TariefBev3 { get; set; }
				public decimal? TariefExclNHC { get; set; }
				public decimal? TariefNHC { get; set; }
				public decimal? TariefPMU { get; set; }
				public string DeclaratieCode { get; set; }
				public int? AantalAmbulant { get; set; }
				public int? AantalBasisGGZ { get; set; }
				public int? AantalDeelprestaties { get; set; }
				public int? AantalMetBev2 { get; set; }
				public int? AantalMetBev3 { get; set; }
				public int? AantalMetPMU { get; set; }
				public int? AantalRegNHC { get; set; }
			}

			public class udtInstantiePeriodeTable
			{
				public int? InstantieID { get; set; }
				public DateTime BeginDatum { get; set; }
				public DateTime EindDatum { get; set; }
			}

			public class udtOnderhandenWerkComponentenTable
			{
				public int? ZorgverzekeraarId { get; set; }
				public object Percentage { get; set; }
			}

			public class udtPrestatieInfoTable
			{
				public int? PrestatieId { get; set; }
				public bool? Ingesloten { get; set; }
				public int? VolumeComponent1 { get; set; }
				public int? VolumeComponent2 { get; set; }
				public int? VolumeComponent3 { get; set; }
			}
		}

		namespace Analyse
		{
			public class udtZorgverstrekkerBudget
			{
				public int? ZorgverzekeraarId { get; set; }
				public string OnderhandenWerkMailadres { get; set; }
				public bool? NietInAutoModelcontract { get; set; }
				public int? ZorgSoortId { get; set; }
				public bool? Contracteerbaar { get; set; }
				public string Contractnummer { get; set; }
				public string IPZReferentie { get; set; }
				public decimal? OmzetPlafond { get; set; }
				public decimal? MandaatTotaal { get; set; }
				public decimal? OmzetAfspraak { get; set; }
				public decimal? PrijsAfspraak { get; set; }
				public int? ZorgverstrekkerId { get; set; }
				public string PrijsAfspraakOmschrijving { get; set; }
				public int? OmzetAfspraakSoortId { get; set; }
				public int? PeriodeId { get; set; }
				public int? RegioId { get; set; }
				public int? CategorieId { get; set; }
				public string Inkoper { get; set; }
				public decimal? BudgetTotaal { get; set; }
				public decimal? ExternContractTotaal { get; set; }
				public bool? OnderhandenWerk { get; set; }
			}

			public class udtUpdateBehandelingZwarteLijst
			{
				public int? ZorgverstrekkerId { get; set; }
				public int? PeriodeId { get; set; }
				public int? BehandelingId { get; set; }
				public int? UitsluitingId { get; set; }
			}
		}

		namespace DataStaging
		{
		}

		namespace Dbc
		{
		}

		namespace dbo
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

			public class udtPeriodeTable
			{
				public DateTime StartDatum { get; set; }
				public DateTime EindDatum { get; set; }
			}

			public class udtIntTable
			{
				public int? value { get; set; }
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
				public string DeclaratieCode { get; set; }
				public string ZorgproductCode { get; set; }
				public int? Volume { get; set; }
				public decimal? Prijs { get; set; }
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
		T csp_ImportOnderhandelingData_u01<T>(int? p_AfspraakID, bool? p_ImportPrices, bool? p_ImportVolumes, Guid p_StagingImportPrijslijstBatchToken) where T : SqlResponse;
		T csp_Onderhandeling_u16<T>(int? p_AfspraakId, int? p_InstantieId, string p_UserName) where T : SqlResponse;
		T csp_IsOnderhandelenToegestaanInPeriode<T>(DateTime p_PeriodeEind, DateTime p_PeriodeStart, int? p_ZorgverstrekkerID, int? p_ZorgverzekeraarID) where T : SqlResponse;
		T csp_OnderhandelingGroepsIndelingGroep_s04<T>(int? AfspraakID, int? GroepsIndelingID, int? VergelijkingID) where T : SqlResponse;
		T csp_OnderhandelingVolumeSpecificatieGewenst_s01<T>(int? AfspraakId, ref bool? VolumeSpecificatieGewenst) where T : SqlResponse;
		T csp_Onderhandeling_d04<T>(int? p_AfspraakID, int? p_InstantieId) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_s07<T>(int? AfspraakID, bool? AlleenIngesloten, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodes, string DeelVanOmschrijving, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> GroepFilter, int? GroepFilterType, bool? NegeerPrestatieFilter, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> ZorgproductCodes) where T : SqlResponse;
		T csp_Onderhandeling_d05<T>(int? p_AfspraakID, string p_bevestigingsTekst, int? p_InstantieId, string p_UserName) where T : SqlResponse;
		T csp_Onderhandeling_i08<T>(int? p_AfspraakID_From, string p_bevestigingsTekst, ref int? p_InstantieAanZet, int? p_InstantieId, ref int? p_newId, ref Guid p_NewVersieID, string p_Username) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_s07_incl_vergelijken<T>(int? AfspraakID, bool? AlleenIngesloten, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodes, string DeelVanOmschrijving, bool? ForceerTariefVergelijking, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> GroepFilter, int? GroepFilterType, bool? NegeerPrestatieFilter, int? VergelijkingID, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> ZorgproductCodes) where T : SqlResponse;
		T csp_Onderhandeling_i06<T>(int? AfspraakIDBlacklist, int? AfspraakIDSjabloon, int? AfspraakIDSpeerpunt, bool? AutomatischGestart, int? CPN_ZVS_ID, int? CPN_ZVZ_ID, DateTime EindDatum, int? INITIATOR, bool? IsPseudoOnderhandeling, ref int? NewAfspraakID, int? OnderhandelingUitgangspositieID, string SegmentCode, DateTime StartDatum, string USERNAME, int? ZVS_ID, int? ZVZ_ID) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_u09<T>(int? AfspraakID, string DeclaratieCode, IEnumerable<Database.UserDefinedTypes.Afspraak.udtPrestatieInfoTable> Prestaties, decimal? Prijs) where T : SqlResponse;
		T csp_Onderhandeling_i07<T>(int? p_AfspraakID_From, string p_bevestigingsTekst, ref int? p_InstantieAanZet, int? p_InstantieId, ref int? p_NewId, ref Guid p_NewVersieID, string p_Username, string p_VoorgesteldDoor) where T : SqlResponse;
		T csp_OnderhandelingPrestatieTariefSoort_s02<T>(int? AfspraakID, string DeclaratieCode) where T : SqlResponse;
		T csp_Onderhandeling_u04<T>(int? p_AfspraakId, string p_bevestigingsTekst, string p_GewijzigdDoor, ref int? p_InstantieAanZet, int? p_InstantieId, int? p_NewStatus, string p_UserName) where T : SqlResponse;
		T csp_OnderhandelingPrijslijst_s03<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Onderhandeling_u05<T>(int? p_AfspraakId, int? p_InstantieId, string p_UserName) where T : SqlResponse;
		T csp_OnderhandelingUitgangspositie_i04<T>(int? AfspraakIDBlacklist, int? AfspraakIDContract, int? AfspraakIDModel, int? AfspraakIDSjabloon, int? AfspraakIDSpeerpunt, int? AfspraakIDVolumeContract, int? AfspraakIDVolumeModel, ref int? NewUitgangspositieID, string Username) where T : SqlResponse;
		T csp_Onderhandeling_u06<T>(int? CON_ID, int? ContactPersoonZVSID, int? ContactPersoonZVZID) where T : SqlResponse;
		T csp_Onderhandeling_u07<T>(int? p_AfspraakId, DateTime p_BeginDatum, DateTime p_EindDatum, string p_ReferentieZVS, string p_ReferentieZVZ, int? p_TargetAfspraakIDModel, string p_TariefWijzigingTypeCode) where T : SqlResponse;
		T csp_Contract_s08<T>(int? jaartal, string uzovi, DateTime wijzigingenVanaf) where T : SqlResponse;
		T csp_Contract_i10<T>(int? p_AfspraakID, ref int? p_AfspraakIDContract, bool? p_AutomatischGeaccordeerd, string p_UserName) where T : SqlResponse;
		T csp_OnderhandelingGroep_s01<T>(int? p_AfspraakID) where T : SqlResponse;
		T csp_Onderhandeling_i15<T>(int? p_AfspraakID_From, string p_bevestigingsTekst, ref int? p_InstantieAanZet, int? p_InstantieId, ref int? p_NewId, ref Guid p_NewVersieID, string p_Username, string p_VoorgesteldDoor) where T : SqlResponse;
		T csp_OnderhandelingGroep_s02<T>(int? p_OnderhandelingGroepID) where T : SqlResponse;
		T csp_Onderhandeling_i16<T>(int? p_AfspraakID_From, string p_bevestigingsTekst, ref int? p_InstantieAanZet, int? p_InstantieId, ref int? p_newId, ref Guid p_NewVersieID, string p_Username) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_u03<T>(int? AfspraakID, string DeclaratieCode, IEnumerable<Database.UserDefinedTypes.Afspraak.udtPrestatieInfoTable> Prestaties, decimal? PrijsHon0303, decimal? PrijsHon0307, decimal? PrijsHon0313, decimal? PrijsHon0316, decimal? PrijsHon0318, decimal? PrijsHon0320, decimal? PrijsHon0322, decimal? PrijsHon0330, decimal? PrijsHon0361, decimal? PrijsHon0362, decimal? PrijsHon0363, decimal? PrijsHon0386, decimal? PrijsHon0387, decimal? PrijsHon0388, decimal? PrijsHon0389, decimal? PrijsHonNietOndh, decimal? PrijsHonOverig, decimal? PrijsZKH) where T : SqlResponse;
		T csp_OnderhandelingGroep_u01<T>(object p_AfwijkingConsult, object p_AfwijkingHonOndh, object p_AfwijkingKlinisch, object p_AfwijkingNietKlinisch, object p_AfwijkingZKH, int? p_OnderhandelingGroepID) where T : SqlResponse;
		T csp_ContractAfspraak_u01<T>(int? AfspraakID, int? ContactPersoonZVSID, int? ContactPersoonZVZID) where T : SqlResponse;
		T csp_OnderhandelingGroep_u02<T>(int? OnderhandelingAfspraakID) where T : SqlResponse;
		T csp_Validatie_Geen16Codes_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_OnderhandelingGroepsIndelingGroep_s03<T>(int? AfspraakID, int? GroepsIndelingID) where T : SqlResponse;
		T csp_OnderhandelingGroep_u03<T>(int? p_OnderhandelingGroepID, bool? p_SelectBack) where T : SqlResponse;
		T csp_Validatie_Geen16Codes_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_s06<T>(int? AfspraakID, bool? AlleenIngesloten, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodes, string DeelVanOmschrijving, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> GroepFilter, int? GroepFilterType) where T : SqlResponse;
		T csp_OnderhandelingGroep_u04<T>(int? p_OnderhandelingAfspraakID) where T : SqlResponse;
		T csp_Validatie_TotaalHogerDanPassanten_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_u08<T>(int? AfspraakID, string DeclaratieCode, bool? Ingesloten, decimal? Tarief, int? VolumeComponent1, int? VolumeComponent2, int? VolumeComponent3) where T : SqlResponse;
		T csp_ImportModelData_u01<T>(int? AfspraakID, Guid StagingImportPrijslijstBatchToken) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_s01<T>(bool? p_FilterAlleenUitzonderingen, string p_FilterBehandelingCode, string p_FilterDeclaratieCodes, string p_FilterDiagnoseCode, string p_FilterZorgTypeCode, string p_FilterZorgVraagCode, int? p_OnderhandelingGroepID, int? p_PageNr, int? p_PageSize, string p_SorteringKolom, string p_SorteringVolgorde) where T : SqlResponse;
		T csp_Validatie_TotaalHogerDanPassanten_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_OnderhandelingUitgangspositie_i03<T>(int? AfspraakIDSjabloon, ref int? NieuweUitgangspositieID, string Username) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_s02<T>(int? p_AfspraakID, string p_DeclaratieCode) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_u01<T>(string p_DeclaratieCode, bool? p_ForceerGroepsuitzondering, bool? p_Ingesloten, int? p_OnderhandelingAfspraakID, ref int? p_OnderhandelingGroepsUitzonderingID, decimal? p_PrijsHonOndh, decimal? p_PrijsZKH, string p_TariefWijzigingTypeCode) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_u02<T>(int? p_OnderhandelingAfspraakID, int? p_PrestatieID, bool? p_Uitgesloten, int? p_Volume) where T : SqlResponse;
		T csp_OnderhandelingPrijslijst_s01<T>(int? CON_ID, bool? IsOnlyAfspraken) where T : SqlResponse;
		T csp_CreateModelContractFromOnderhandeling<T>(int? p_AfspraakID, int? p_InstantieType, ref int? p_ModelAfspraakID, string p_ModelCode, string p_ModelOmschrijving) where T : SqlResponse;
		T csp_Contract_d02<T>(int? AfspraakId, int? InstantieId, string Username) where T : SqlResponse;
		T csp_OnderhandelingPrijslijst_u01<T>(int? p_OnderhandelingGroepID, bool? p_SelectBack) where T : SqlResponse;
		T csp_OnderhandelingGroepsUitzonderingHonOndhComp_d01<T>(int? OnderhandelingGroepsuitzonderingID) where T : SqlResponse;
		T csp_Contract_d03<T>(int? AfspraakId, int? InstantieId, string Username) where T : SqlResponse;
		T csp_OnderhandelingPrijslijstHonOndhComp_s02<T>(int? AfspraakID) where T : SqlResponse;
		T csp_OnderhandelingGroepsUitzonderingHonOndhComp_i01<T>(int? OnderhandelingGroepsuitzonderingID, decimal? Prijs, string SpecialismeCode) where T : SqlResponse;
		T csp_Contract_d04<T>(int? AfspraakId, int? InstantieId, string Username) where T : SqlResponse;
		T csp_OnderhandelingStatusovergangCheck_s01<T>(int? p_AfspraakID, int? p_InstantieID, int? p_NewStatus) where T : SqlResponse;
		T csp_Onderhandeling_i10<T>(string AangemaaktDoor, int? AfspraakIDSjabloon, DateTime EindDatum, int? InitierendeInstantieTypeID, ref int? NieuweAfspraakID, int? OnderhandelingUitgangspositieID, DateTime StartDatum, int? ZorgverstrekkerID, int? ZorgverzekeraarID) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_s04<T>(int? p_AfspraakID, string p_DeclaratieCode) where T : SqlResponse;
		T csp_Contract_s06<T>(int? AfspraakID) where T : SqlResponse;
		T csp_OnderhandelingUitgangspositie_i01<T>(int? AfspraakIDBlacklist, int? AfspraakIDContract, int? AfspraakIDModel, int? AfspraakIDSjabloon, int? AfspraakIDSpeerpunt, int? AfspraakIDVolumeContract, int? AfspraakIDVolumeModel, ref int? NewUitgangspositieID, string SegmentCode, bool? TotaalprijsGelijk, string Username) where T : SqlResponse;
		T csp_Onderhandeling_u12<T>(int? AfspraakId, string BevestigingsTekst, string GewijzigdDoor, int? NieuweOnderhandelingStatus, ref int? p_InstantieAanZet, string UserName) where T : SqlResponse;
		T csp_Contract_u04<T>(int? afspraakId) where T : SqlResponse;
		T csp_OnderhandelPeriode_s01<T>(int? p_ZorgverstrekkerID, int? p_ZorgverzekeraarID) where T : SqlResponse;
		T csp_Onderhandeling_u13<T>(int? AfspraakId, string BevestigingsTekst, string GewijzigdDoor, int? NieuweOnderhandelingStatus, string UserName) where T : SqlResponse;
		T csp_OnderhandelPeriode_s02<T>(int? p_PeriodeID, int? p_ZorgverzekeraarID) where T : SqlResponse;
		T csp_Contract_s10<T>(int? AfspraakID, int? InstantieID) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_s05_incl_vergelijken<T>(int? AfspraakID, bool? AlleenIngesloten, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodes, string DeelVanOmschrijving, bool? ForceerTariefVergelijking, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> GroepFilter, int? GroepFilterType, bool? InclHonorariumComponenten, bool? NegeerPrestatieFilter, int? VergelijkingID, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> ZorgproductCodes) where T : SqlResponse;
		T csp_OnderhandelPeriode_save01<T>(bool? p_OnderhandelenToegestaan, int? p_PeriodeID, int? p_ZorgverstrekkerID, int? p_ZorgverzekeraarID) where T : SqlResponse;
		T csp_PrestatiesOpGrijzeEnZwarteLijst_s01<T>(int? AfspraakId) where T : SqlResponse;
		T csp_Afspraak_s06<T>(int? InstantieID, int? PrestatieID) where T : SqlResponse;
		T csp_Contract_s17<T>(bool? ActiveOnly, int? AfspraakID, bool? InclChildContracten, int? InstantieID, int? ZorgsoortID) where T : SqlResponse;
		T csp_Sjabloon_s02<T>(ref int? AfspraakID, int? SjabloonAfspraakID) where T : SqlResponse;
		T csp_PrestatiesOpGrijzeEnZwarteLijst_s02<T>(int? AfspraakId, DateTime Peildatum) where T : SqlResponse;
		T csp_Onderhandeling_s09<T>(int? AfspraakID) where T : SqlResponse;
		T csp_SpeerpuntAfspraak_s01<T>(DateTime periodeEind, DateTime periodeStart, string Segment, int? ZorgverstrekkerID, int? ZorgverzekeraarID) where T : SqlResponse;
		T csp_OnderhandelingFlowgegevens_s01<T>(int? AfspraakId, int? InstantieTypeID) where T : SqlResponse;
		T csp_OnderhandelGeschiedenis_i01<T>(int? AfspraakID, DateTime AktieDatum, int? AktieID, int? GebruikerID, int? InstantieAanZet, string Opmerking, bool? VerbergOpmerkingVoorAnderePartij) where T : SqlResponse;
		T csp_OnderhandelGeschiedenis_s01<T>(int? AfspraakID, int? InstantieID) where T : SqlResponse;
		T csp_Contract_i04<T>(ref int? p_identity, int? p_SjabloonAfspraakID, int? p_SubVersie, int? p_Versie) where T : SqlResponse;
		T csp_Validatie_VoluminaMoet0ZijnBijCodes16Of17_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_VoluminaMoet0ZijnBijCodes16Of17_Solve<T>(int? AfspraakID) where T : SqlResponse;
		T csp_ImportContract8Data_u01<T>(int? p_AfspraakID, Guid p_StagingImportPrijslijstBatchToken) where T : SqlResponse;
		T csp_OnderhandenWerk_s01<T>(int? InvulKwartaal, string Segment, int? SjabloonJaar, int? ZVSID, int? ZVZID) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_u06<T>(int? AfspraakID, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodes, ref bool? OnderhandelingGewijzigd) where T : SqlResponse;
		T csp_OnderhandenWerkSjabloon2010_s01<T>(int? InvulKwartaal, string Segment, int? SjabloonJaar, int? ZVSID, int? ZVZID) where T : SqlResponse;
		T csp_Sjabloon_i01<T>(string Code, string Omschrijving, ref int? SjabloonAfspraakID, string Username) where T : SqlResponse;
		T csp_OnderhandenWerkSjabloon2010_u01<T>(string Gebruiker, Guid ImportIdentifier, int? InvulKwartaal, string Segment, int? SjabloonJaar, string SjabloonVersie, int? ZVSID, int? ZVZID) where T : SqlResponse;
		T csp_Contract_s11<T>(int? CON_ID) where T : SqlResponse;
		T csp_Contract_s14<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_ABSegmentZorgproductenPoorter_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_Correcte17CodesAgisAchmeaComplement_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Contract_s15<T>(int? AnalyseRegioId, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodeList, int? GroepId, int? InstantieId, int? InstantieSoort, DateTime PeilDatum, int? ProvincieId, int? RegioId, string Segment, bool? ToonPassantenTarieven, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> ZorgProductList, int? ZorgverstrekkerId, int? ZorgverzekeraarId) where T : SqlResponse;
		T csp_Validatie_ABSegmentZorgproductenPoorter_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_OvernemenPrijzen17Pendant_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Contract_s13<T>(int? AfspraakID, int? AfspraakIDSjabloon, ref bool? Match) where T : SqlResponse;
		T csp_ContractAfspraakBijlagen_s01<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_OvernemenPrijzen17Pendant_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_OnderhandelingUitgangspositie_s01<T>(int? AfspraakID, int? InstantieID) where T : SqlResponse;
		T csp_Contract_s19<T>(int? AfspraakID) where T : SqlResponse;
		T csp_ContractExport_s01<T>(int? AfspraakID, bool? AlleTarieven, string ExportInhoud) where T : SqlResponse;
		T csp_PassantenTarief_s01<T>(bool? ActiveOnly, int? AfspraakStijl, int? InstantieID, DateTime MaximumBegindatum, string segment) where T : SqlResponse;
		T csp_ContractPrijslijst_s03<T>(int? AfspraakID) where T : SqlResponse;
		T csp_ImportOnderhandeling8Data_u01<T>(int? p_AfspraakID, string p_ImportInhoud, bool? p_ImportPrices, bool? p_ImportVolumes, Guid p_StagingImportPrijslijstBatchToken) where T : SqlResponse;
		T csp_ModelContractExport_s01<T>(int? AfspraakID, bool? AlleTarieven, string ExportInhoud) where T : SqlResponse;
		T csp_Afspraak_s02<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Sjabloon_s04<T>(int? AfspraakIDSjabloonNieuw, int? AfspraakIDSjabloonVorig, ref bool? Identiek) where T : SqlResponse;
		T csp_Afspraak_s01<T>(int? InstantieID, int? ZVS_ID) where T : SqlResponse;
		T csp_Onderhandeling_i09<T>(int? AfspraakIDBlacklist, int? AfspraakIDSjabloon, int? AfspraakIDSpeerpunt, bool? AutomatischGestart, int? CPN_ZVS_ID, int? CPN_ZVZ_ID, DateTime EindDatum, int? INITIATOR, bool? IsPseudoOnderhandeling, ref int? NewAfspraakID, int? OnderhandelingUitgangspositieID, string SegmentCode, DateTime StartDatum, int? TariefType, string USERNAME, int? ZVS_ID, int? ZVZ_ID) where T : SqlResponse;
		T csp_Afspraak_u05<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Contract_s07<T>(bool? ActiveOnly, int? AfspraakID, int? AfspraakStijl, bool? InclChildContracten, bool? InclPassantenTarieven, int? InstantieID, DateTime MaxBegindatum, DateTime MinBeginDatum, string Segment) where T : SqlResponse;
		T csp_Model_d01<T>(int? p_MDL_ID) where T : SqlResponse;
		T csp_Onderhandeling_u10<T>(int? p_AfspraakId, int? p_InstantieTypeID, string p_OnderhandelingOpmerking, string p_Username) where T : SqlResponse;
		T csp_Contract_i11<T>(ref int? AfspraakID, string AGBCode, DateTime BeginDatum, string CreateUser, DateTime EindDatum, string Omschrijving, IEnumerable<Database.UserDefinedTypes.Tarief.udtTariefPrijslijst> Prijslijst, string Segment, int? SjabloonAfspraakID, string UZOVI) where T : SqlResponse;
		T csp_PrestatieComponentModel_u01<T>(int? AfspraakID, int? p_MDLDBC_Aantal, decimal? p_MDLDBC_Specialisten, decimal? p_MDLDBC_Ziekenhuis, string p_username, int? PrestatieID) where T : SqlResponse;
		T csp_OnderhandelingExport_s01<T>(int? AfspraakID, bool? AlleTarieven, string ExportInhoud) where T : SqlResponse;
		T csp_Contract_s20<T>(int? AnalyseRegioId, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodeList, int? GroepId, int? InstantieId, int? InstantieSoort, DateTime PeilDatum, int? ProvincieId, int? RegioId, string Segment, bool? ToonPassantenTarieven, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> ZorgProductList, int? ZorgverstrekkerId, int? ZorgverzekeraarId) where T : SqlResponse;
		T csp_PrestatieComponentModel_s01<T>(int? MDL_ID) where T : SqlResponse;
		T csp_OnderhandelingGroepsIndeling_s01<T>(int? AfspraakID, int? InstantieID) where T : SqlResponse;
		T csp_Contract_s21<T>(int? AfspraakID) where T : SqlResponse;
		T csp_PrestatieComponentModel_d01<T>(int? p_MDL_ID) where T : SqlResponse;
		T csp_OnderhandelingGroepsIndelingGroep_s01<T>(int? AfspraakID, int? GroepsIndelingID, int? VergelijkingID) where T : SqlResponse;
		T csp_Onderhandeling_u08<T>(int? p_AfspraakId, string p_PrestatieFilterCode) where T : SqlResponse;
		T csp_ModelContractExport_s02<T>(int? AfspraakID, bool? AlleTarieven) where T : SqlResponse;
		T csp_OnderhandelingAfspraakBijlage_s01<T>(int? CON_ID) where T : SqlResponse;
		T csp_OnderhandelingGroepsIndelingGroep_s02<T>(int? AfspraakID, int? GroepsIndelingID, int? HoofdGroepID) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_d02<T>(int? AfspraakID, ref bool? OnderhandelingGewijzigd, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> PrestatieIds) where T : SqlResponse;
		T csp_OnderhandelingOpmerking_s01<T>(int? AfspraakID, int? InstantieTypeID) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_u11<T>(int? AfspraakID, object AfwVolume, ref bool? OnderhandelingGewijzigd, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> PrestatieIds) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_s05<T>(int? AfspraakID, bool? AlleenIngesloten, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodes, string DeelVanOmschrijving, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> GroepFilter, int? GroepFilterType, bool? NegeerPrestatieFilter, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> ZorgproductCodes) where T : SqlResponse;
		T csp_Validatie_1416GelijkIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_HonorariumComponent_s01<T>(int? AfspraakID, int? PrestatieID) where T : SqlResponse;
		T csp_Validatie_1416GelijkIntegraal_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_u04<T>(int? AfspraakID, int? AfwBasis, object AfwHon0303, object AfwHon0307, object AfwHon0313, object AfwHon0316, object AfwHon0318, object AfwHon0320, object AfwHon0322, object AfwHon0330, object AfwHon0361, object AfwHon0362, object AfwHon0363, object AfwHon0386, object AfwHon0387, object AfwHon0388, object AfwHon0389, object AfwHonNietOndh, object AfwHonOndh, object AfwHonOverig, object AfwZKH, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodes, int? GroepId, ref bool? OnderhandelingGewijzigd) where T : SqlResponse;
		T csp_Validatie_1517GelijkIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_HonorariumComponent_s03<T>(int? AfspraakID, int? InstantieID, int? PrestatieID) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_u05<T>(int? AfspraakID, ref bool? OnderhandelingGewijzigd) where T : SqlResponse;
		T csp_Validatie_1517GelijkIntegraal_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_Geen16CodesIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_OnderhandelingPrestatieTariefSoort_s01<T>(int? AfspraakID, string DeclaratieCode) where T : SqlResponse;
		T csp_ContractControleBestaandContractImportTool_s02<T>(string AGB, string AGBSoort, DateTime BeginDatum, ref bool? BestaandContract, DateTime EindDatum, string UZOVI) where T : SqlResponse;
		T csp_Validatie_Geen16CodesIntegraal_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_PassantenTarief_d01<T>(int? CON_ID) where T : SqlResponse;
		T csp_OnderhandelingPrestatieToelichting_d01<T>(int? AfspraakID, string DeclaratieCode) where T : SqlResponse;
		T csp_Validatie_GeenOnverzekerdeZorgIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_OnderhandelingPrestatieToelichting_s01<T>(int? AfspraakID, string DeclaratieCode, ref string Toelichting) where T : SqlResponse;
		T csp_Validatie_GeenOnverzekerdeZorgIntegraal_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_OnderhandelingPrestatieToelichting_u01<T>(int? AfspraakID, string DeclaratieCode, string Toelichting) where T : SqlResponse;
		T csp_Validatie_MaxTariefTotaalIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_ContractPrijslijst_s04<T>(int? AfspraakID) where T : SqlResponse;
		T csp_OnderhandelingUitgangspositie_i02<T>(int? AfspraakIDBlacklist, int? AfspraakIDContract, int? AfspraakIDModel, int? AfspraakIDSjabloon, int? AfspraakIDSpeerpunt, int? AfspraakIDVolumeContract, int? AfspraakIDVolumeModel, ref int? NewUitgangspositieID, bool? TotaalprijsGelijk, string Username) where T : SqlResponse;
		T csp_Validatie_MaxTariefTotaalIntegraal_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_OnderhandelingPrijslijst_s02<T>(int? AfspraakID) where T : SqlResponse;
		T csp_PrestatieComponentPassantenTarief_i02<T>(int? p_CON_ID, int? p_CONDBC_Aantal, decimal? p_CONDBC_Specialisten, decimal? p_CONDBC_Ziekenhuis, int? p_DBC_ID, string p_status, string p_username) where T : SqlResponse;
		T csp_Validatie_PrestatiesVallenBinnenSjabloonRegel_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_TariefSoortInfo_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_NegatieveTarievenIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_PrestatieBinnenGrijzeLijst_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_TariefSoortInfo_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_OnderhandelingBinnenSjabloon_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_OvernemenPrijzen16PendantIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_PrestatiesOpGrijzeEnZwarteLijst_d01<T>(int? AfspraakId) where T : SqlResponse;
		T csp_Contract_d01<T>(int? p_CON_ID) where T : SqlResponse;
		T csp_Validatie_PrestatieBinnenGrijzeLijst_Solve<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_OvernemenPrijzen16PendantIntegraal_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_OvernemenPrijzen17PendantIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_OnderhandelingAfspraakBijlage_i01<T>(int? CON_ID, ref Guid ExtID, string FileName, ref int? ID, string ToegevoegdDoor, int? Type_ID) where T : SqlResponse;
		T csp_Validatie_OvernemenPrijzen17PendantIntegraal_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_OnderhandelingAfspraakBijlage_d01<T>(int? ID) where T : SqlResponse;
		T csp_Validatie_PrestatieBinnenGrijzeLijstIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_PrestatiesOpGrijzeEnZwarteLijst_i01<T>(int? AfspraakId) where T : SqlResponse;
		T csp_Validatie_PrestatieBinnenGrijzeLijstIntegraal_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_TariefSoortInfoIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_TotaalHogerDanPassantenIntegraal_Check<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_TotaalHogerDanPassantenIntegraal_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_d01<T>(int? AfspraakID, ref bool? OnderhandelingGewijzigd, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> PrestatieIds) where T : SqlResponse;
		T csp_contract_i07<T>(int? p_AfspraakID, ref int? p_AfspraakIDContract, bool? p_AutomatischGeaccordeerd, ref int? p_ContractAfspraakID, string p_UserName) where T : SqlResponse;
		T csp_Validatie_VoluminaMoet0ZijnBijCodes16Of17Integraal_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_u07<T>(int? AfspraakID, object AfwVolume, ref bool? OnderhandelingGewijzigd, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> PrestatieIds) where T : SqlResponse;
		T csp_Onderhandeling_d01<T>(int? CON_ID) where T : SqlResponse;
		T csp_contract_i08<T>(int? p_AfspraakID, ref int? p_AfspraakIDContract, bool? p_AutomatischGeaccordeerd, string p_UserName) where T : SqlResponse;
		T csp_Validatie_VoluminaMoet0ZijnBijCodes16Of17Integraal_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Contract_i09<T>(ref int? AfspraakID, string AGBCode, DateTime BeginDatum, ref int? ContractAfspraakID, string CreateUser, DateTime EindDatum, int? InstantieSubType, string Omschrijving, int? SjabloonAfspraakID, string UZOVI) where T : SqlResponse;
		T csp_Validatie_ZwarteLijstBlokkerendIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Onderhandeling_s04<T>(int? CON_ORIG_ID, int? INITIATOR) where T : SqlResponse;
		T csp_Contract_s18<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_ZwarteLijstWaarschuwendIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Onderhandeling_s05<T>(int? CON_ID) where T : SqlResponse;
		T csp_ContractControleBestaandContract_s03<T>(int? AfspraakID, ref bool? BestaandContract) where T : SqlResponse;
		T csp_Onderhandeling_u01<T>(DateTime BeginDatum, int? CON_ID, int? ContactPersoonZVSID, int? ContactPersoonZVZID, DateTime EindDatum, bool? HasUpdates, string Omschrijving, string RefZVS, string RefZVZ, string UpdateUser) where T : SqlResponse;
		T csp_ContractPrijslijst_i09<T>(int? AfspraakID, IEnumerable<Database.UserDefinedTypes.Afspraak.udt_GGZPrijslijstTable> PrestatiePrijslijst) where T : SqlResponse;
		T csp_Onderhandeling_s00<T>(int? CON_ID) where T : SqlResponse;
		T csp_GGZContractPrestatie_s01<T>(int? AfspraakID) where T : SqlResponse;
		T csp_GGZOnderhandelingPrestatie_i01<T>(int? AfspraakID, IEnumerable<Database.UserDefinedTypes.Afspraak.udt_GGZPrijslijstTable> PrestatiePrijslijst) where T : SqlResponse;
		T csp_Validatie_GrijzeLijst_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_GGZOnderhandelingPrestatie_s01<T>(int? AfspraakID, bool? AlleenIngesloten, int? PrestatieTypeID) where T : SqlResponse;
		T csp_Validatie_ZwarteLijstBlokkerend_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Onderhandeling_i11<T>(int? p_AfspraakID_From, string p_bevestigingsTekst, ref int? p_InstantieAanZet, ref int? p_NewId, ref Guid p_NewVersieID, ref int? p_OnderhandelingAfspraakID, string p_UserName, string p_VoorgesteldDoor, ref int? p_ZorgSoort) where T : SqlResponse;
		T csp_Validatie_ZwarteLijstBlokkerend_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Onderhandeling_i12<T>(int? p_AfspraakID_From, ref int? p_AfspraakIDVorigeVersie, string p_bevestigingsTekst, ref int? p_InstantieAanZet, ref int? p_newId, ref Guid p_NewVersieID, ref int? p_OnderhandelingAfspraakID, string p_UserName) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_u10<T>(int? AfspraakID, object Afw, int? AfwBasis, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodes, ref bool? OnderhandelingGewijzigd) where T : SqlResponse;
		T csp_Validatie_ZwarteLijstWaarschuwend_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_onderhandeling_i13<T>(int? p_AfspraakID_From, string p_bevestigingsTekst, ref int? p_InstantieAanZet, int? p_InstantieId, ref int? p_NewId, ref Guid p_NewVersieID, string p_Username, string p_VoorgesteldDoor) where T : SqlResponse;
		T csp_Validatie_TariefSoortInfoIntegraal_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_ZwarteLijstWaarschuwend_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Model_s02<T>(int? MDL_ID) where T : SqlResponse;
		T csp_Onderhandeling_i14<T>(int? p_AfspraakID_From, string p_bevestigingsTekst, ref int? p_InstantieAanZet, int? p_InstantieId, ref int? p_newId, ref Guid p_NewVersieID, string p_Username) where T : SqlResponse;
		T csp_Validatie_ZwarteLijstBlokkerendIntegraal_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Model_u01<T>(string p_MDL_Code, int? p_MDL_ID, string p_MDL_Omschrijving, string p_username) where T : SqlResponse;
		T csp_Onderhandeling_u14<T>(int? p_AfspraakId, ref int? p_OnderhandelingAfspraakID_HuidigeVersie, ref int? p_onderhandelingAfspraakID_VorigeVersie, string p_UserName) where T : SqlResponse;
		T csp_Validatie_ZwarteLijstWaarschuwendIntegraal_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Model_i01<T>(ref int? p_identity, string p_MDL_Code, string p_MDL_Omschrijving, string p_username, int? p_ZorgverstrekkerID, int? p_ZorgverzekeraarID) where T : SqlResponse;
		T csp_Onderhandeling_u15<T>(int? p_AfspraakId, int? p_InstantieId, string p_UserName) where T : SqlResponse;
		T csp_Model_s01<T>(int? AfspraakStijl, DateTime BeginDatum, DateTime EindDatum, int? InstantieID, string Segment) where T : SqlResponse;
		T csp_Validatie_GeenOnverzekerdeZorg_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_GeenOnverzekerdeZorg_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_CompleetheidInkoopAgisAchmea_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Sjabloon_s01<T>(string segment, int? ZorgSoort) where T : SqlResponse;
		T csp_Validatie_GGZMutatieTarieven_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_GGZSjabloonMaxTarieven_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_ModelContractAanwezig_Check<T>(int? AfspraakID, ref int? ModelAfspraakID, ref string ModelContractCode, string ModelContractCodePrefix, ref int? OnderhandelingAfspraakID) where T : SqlResponse;
		T csp_Validatie_MarktTariefHonorarium_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_MarktTariefKosten_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_MaxTariefHonorarium_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_MaxTariefHonorarium_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_MaxTariefKosten_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Afspraak_u01<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_MaxTariefKosten_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_HonorariumComponentPassantenTarief_i01<T>(int? AfspraakID, decimal? Kosten, int? PrestatieID, string SpecialismeCode, string Username) where T : SqlResponse;
		T csp_Validatie_MaxTariefTotaal_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Onderhandeling_u11<T>(int? p_AfspraakId, string p_bevestigingsTekst, string p_GewijzigdDoor, int? p_NewAkkoordStatus, string p_UserName) where T : SqlResponse;
		T csp_Validatie_MaxTariefTotaal_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_ImportVolumeSpecificatie_u01<T>(int? p_AfspraakID, int? p_SpecificatieGebaseerdOpJaar, Guid p_StagingImportVolumeSpecificatieBatchToken, string p_ToegevoegdDoor) where T : SqlResponse;
		T csp_OnderhandenWerk_d01<T>(DateTime PeriodeEind, DateTime PeriodeStart, int? ZVSID, int? ZVZID) where T : SqlResponse;
		T csp_Validatie_MinTariefHonorarium_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_VolumeSpecificatie_s01<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Sjabloon_s03<T>(int? SjabloonAfspraakID) where T : SqlResponse;
		T csp_OnderhandenWerk_s02<T>(IEnumerable<Database.UserDefinedTypes.Overig.udtPeriodeTable> Perioden, int? ZVSID, int? ZVZID) where T : SqlResponse;
		T csp_Validatie_MinTariefHonorarium_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_VolumeSpecificatie_s02<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Sjabloon_s05<T>(int? InstantieId, int? ZorgSoort) where T : SqlResponse;
		T csp_OnderhandenWerk_s03<T>(DateTime PeriodeEind, DateTime PeriodeStart, int? ZVSID, int? ZVZID) where T : SqlResponse;
		T csp_Validatie_MinTariefKosten_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_VolumeSpecificatie_s03<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Model_iu01<T>(ref int? l_identity, string p_MDL_Code, string p_MDL_Omschrijving, string p_username, string p_ZVS_AGBCode, string p_ZVZ_UZOVI) where T : SqlResponse;
		T csp_OnderhandenWerk_s04<T>(DateTime PeriodeEind, DateTime PeriodeStart, bool? VoorgaandJaar, int? ZVSID, int? ZVZID) where T : SqlResponse;
		T csp_Validatie_MinTariefKosten_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_OnderhandenWerk_s05<T>(DateTime PeriodeEind, DateTime PeriodeStart, int? ZVZID) where T : SqlResponse;
		T csp_OnderhandenWerk_u01<T>(bool? AkkoordVerklaard, IEnumerable<Database.UserDefinedTypes.Afspraak.udtOnderhandenWerkComponentenTable> ComponentenHuidigJaar, IEnumerable<Database.UserDefinedTypes.Afspraak.udtOnderhandenWerkComponentenTable> ComponentenVoorgaandJaar, decimal? KostprijsHuidigJaar, decimal? KostprijsVoorgaandJaar, string OpgegevenDoor, DateTime PeriodeEind, DateTime PeriodeStart, int? ZVSID, int? ZVZID) where T : SqlResponse;
		T csp_PrestatieComponentPassantenTarief_i01<T>(ref int? l_DBC_ID, int? p_CON_ID, decimal? p_CONDBC_Specialisten, decimal? p_CONDBC_Ziekenhuis, DateTime p_DatumIngang, string p_DeclaratieCode, decimal? p_PoortSpecialismePrijs, string p_prestatieCode, string p_SPC_Code, string p_username) where T : SqlResponse;
		T csp_Onderhandeling_s10<T>(DateTime BeginDatum, DateTime EindDatum, int? HuidigInstantieTypeId, bool? IncConcepten, ref int? OnderhandelingenInPeriode, int? ZorgSoortID, int? ZorgverstrekkerID, int? ZorgverzekeraarID) where T : SqlResponse;
		T csp_PassantenTarief_i02<T>(DateTime p_BeginDatum, DateTime p_EindDatum, ref int? p_identity, string p_Omschrijving, int? p_SubVersie, string p_username, int? p_Versie, int? p_ZVS_ID) where T : SqlResponse;
		T csp_PassantenTarief_i01<T>(DateTime p_BeginDatum, DateTime p_EindDatum, ref int? p_identity, string p_Omschrijving, int? p_SubVersie, string p_username, int? p_Versie, string p_ZVS_AGBCode) where T : SqlResponse;
		T csp_Contract_s16<T>(int? ZorgverstrekkerID, int? ZorgverzekeraarID) where T : SqlResponse;
		T csp_Onderhandeling_s06<T>(int? InstantieTypeID, int? ZorgverstrekkerID, int? ZorgverzekeraarID) where T : SqlResponse;
		T csp_ImportPassantenTarieven_u01<T>(ref int? RecordsInserted, ref int? RecordsUpdated, int? TogImportBatchLogID) where T : SqlResponse;
		T csp_InstantieRegel_s01<T>(int? AfspraakID, int? InstantieRegelID, bool? OnlyOutdated) where T : SqlResponse;
		T csp_Afspraak_u02<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Onderhandeling_s11<T>(int? InstantieID, int? InstantieType, string SegmentCode, int? ZorgSoort) where T : SqlResponse;
		T csp_RegelResultaat_s01<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Onderhandeling_s07<T>(int? AfspraakStijl, int? InstantieTypeID, DateTime MaxBegindatum, DateTime MinBegindatum, string SegmentCode, int? ZorgverstrekkerID, int? ZorgverzekeraarID) where T : SqlResponse;
		T csp_Onderhandeling_s12<T>(int? AfspraakId, int? InstantieTypeID) where T : SqlResponse;
		T csp_VolumeSpecificatie_s04<T>(int? AfspraakID) where T : SqlResponse;
		T csp_RegelResultaat_u01<T>(int? AfspraakID, int? InstantieRegelID, string ResultaatToelichting, int? UitgevoerdDoorID) where T : SqlResponse;
		T csp_Onderhandeling_s08<T>(DateTime BeginDatum, int? CheckInstantieTypeId, DateTime EindDatum, bool? IncConcepten, ref int? OnderhandelingenInPeriode, string Segment, int? ZorgverstrekkerID, int? ZorgverzekeraarID) where T : SqlResponse;
		T csp_VolumeSpecificatie_s05<T>(int? AfspraakID) where T : SqlResponse;
		T csp_RegelResultaat_u02<T>(int? AfspraakID, int? InstantieRegelID, int? UitgevoerdDoorID) where T : SqlResponse;
		T csp_onderhandenwerk_s06<T>(DateTime peilDatum, int? ZVZ_uzovi) where T : SqlResponse;
		T csp_Afspraak_s07<T>(DateTime BeginDatum, DateTime Einddatum, int? InstantieID, string PoortSpecialismeCode, string PrestatieCode) where T : SqlResponse;
		T csp_Validatie_1517Gelijk_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_1416Gelijk_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Afspraak_s05<T>(int? AfspraakID, int? InstantieID, int? PrestatieID) where T : SqlResponse;
		T csp_ContractControleBestaandContract_s01<T>(DateTime BeginDatum, ref bool? BestaandContract, string Segment, int? ZorgSoort, int? ZVS_ID, int? ZVZ_ID) where T : SqlResponse;
		T csp_Validatie_1517Gelijk_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_1416Gelijk_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Afspraak_u03<T>(int? AfspraakID, DateTime BeginDatum, DateTime EindDatum, string Username) where T : SqlResponse;
		T csp_Validatie_Correcte17CodesAgisAchmea_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_OvernemenPrijzen16Pendant_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Afspraak_u04<T>(int? AfspraakID, int? InstantieID, string Username, Guid VersieID, ref Guid VersieIDNieuw) where T : SqlResponse;
		T csp_Validatie_Correcte17CodesAgisAchmea_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_OvernemenPrijzen16Pendant_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse;
		T csp_BlacklistAfspraak_s01<T>(DateTime periodeEind, DateTime periodeStart, string Segment, int? ZorgverstrekkerID, int? ZorgverzekeraarID) where T : SqlResponse;
		T csp_Validatie_HonorariumToeslagZBC_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_PrestatieComponentModel_s02<T>(int? MDL_ID) where T : SqlResponse;
		T csp_Validatie_NegatieveTarieven_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Contract_s12<T>(ref int? AfspraakID, string p_Segment, int? p_ZorgverstrekkerID, int? p_ZorgverzekeraarID) where T : SqlResponse;
		T csp_Contract_i05<T>(int? p_AfspraakID, ref int? p_AfspraakIDContract, bool? p_AutomatischGeaccordeerd, string p_UserName) where T : SqlResponse;
		T csp_Validatie_NulTariefHonorariumdeel_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_ContractGroep_s01<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Contract_i06<T>(ref int? AfspraakID, string AGBCode, DateTime BeginDatum, string CreateUser, DateTime EindDatum, int? InstantieSubType, string Omschrijving, string Segment, int? SjabloonAfspraakID, string UZOVI) where T : SqlResponse;
		T csp_Validatie_NulTariefKostendeel_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_ContractGroepsUitzondering_s01<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Contract_u03<T>(int? AfspraakID) where T : SqlResponse;
		T csp_Validatie_OntbrekenVolumina_Check<T>(int? AfspraakID) where T : SqlResponse;
		T csp_ContractControleBestaandContract_s02<T>(int? AfspraakID, DateTime BeginDatum, ref bool? BestaandContract, DateTime EindDatum, string Segment) where T : SqlResponse;
		T csp_Onderhandeling_u09<T>(int? p_AfspraakID, bool? p_BijwerkenPrijslijst) where T : SqlResponse;
		T csp_ContractPrijslijst_s02<T>(int? AfspraakID, int? InstantieID, bool? VerrijkSjabloon) where T : SqlResponse;
		T csp_ContractPrijslijst_s05<T>(int? AfspraakID) where T : SqlResponse;
		T csp_OnderhandelingGroepsUitzondering_d01<T>(string DeclaratieCode, ref bool? IsVerwijderd, int? OnderhandelingAfspraakID) where T : SqlResponse;
		T csp_ContractPrijslijstHonOndhComp_s02<T>(int? AfspraakID) where T : SqlResponse;
		T csp_ContractPrijslijst_s06<T>(int? AfspraakID) where T : SqlResponse;
		T csp_OnderhandelingPrestatie_s03<T>(int? p_OnderhandelingGroepID) where T : SqlResponse;
		T csp_ImportContractData_u01<T>(int? p_AfspraakID, Guid p_StagingImportPrijslijstBatchToken) where T : SqlResponse;
		T csp_Onderhandeling_s13<T>(int? InstantieTypeID, int? ZorgverstrekkerID, int? ZorgverzekeraarID) where T : SqlResponse;
		T csp_PrestatieFilter_s01<T>(bool? InclSpeerpunt, int? InstantieID, DateTime PeriodeEind, DateTime PeriodeStart, string Segment) where T : SqlResponse;
	}

	public interface IAnalyse
	{
		T csp_ZorgverstrekkerBudget_s04<T>(int? ZorgverstrekkerId, int? ZorgverzekeraarId) where T : SqlResponse;
		T csp_ZorgverstrekkerBudgetBulk_u01<T>(IEnumerable<Database.UserDefinedTypes.Analyse.udtZorgverstrekkerBudget> BudgetRegels) where T : SqlResponse;
		T csp_BehandelingZwarteLijst_s01<T>(DateTime Peildatum, int? ZorgverzekeraarId) where T : SqlResponse;
		T csp_ZorgverstrekkerBudget_s06<T>(bool? AlleenGecontracteerd, int? CategorieId, bool? InclContracten, bool? InclOnderhandelingen, string Inkoper, int? PeriodeId, int? RegioId, int? ZorgverstrekkerId, int? ZorgverzekeraarId) where T : SqlResponse;
		T csp_Periode_s01<T>(DateTime DatumVanaf, int? ZorgverzekeraarId) where T : SqlResponse;
		T csp_Stamgegeven_s01<T>(DateTime BeginDatum, DateTime EindDatum, string GroepSleutel, int? ZorgverzekeraarId) where T : SqlResponse;
		T csp_ZorgverstrekkerBudget_s01<T>(int? PeriodeId, int? ZorgSoortId, int? ZorgverstrekkerId, int? ZorgverzekeraarId) where T : SqlResponse;
		T csp_ZorgverstrekkerBudget_s02<T>(bool? AlleenGecontracteerd, int? CategorieId, bool? InclContracten, bool? InclOnderhandelingen, string Inkoper, int? PeriodeId, int? RegioId, int? ZorgverstrekkerId, int? ZorgverzekeraarId) where T : SqlResponse;
		T csp_ZorgverstrekkerBudget_u01<T>(decimal? BudgetTotaal, int? CategorieId, bool? Contracteerbaar, string Contractnummer, decimal? ExternContractTotaal, string Inkoper, string IPZReferentie, decimal? MandaatTotaal, bool? NietInAutoModelcontract, decimal? OmzetAfspraak, int? OmzetAfspraakSoortId, decimal? OmzetPlafond, bool? OnderhandenWerk, string OnderhandenWerkMailadres, int? PeriodeId, decimal? PrijsAfspraak, string PrijsAfspraakOmschrijving, int? RegioId, int? ZorgSoortId, int? ZorgverstrekkerId, int? ZorgverzekeraarId) where T : SqlResponse;
		T csp_ZorgverstrekkerBudget_s03<T>(bool? AlleenGecontracteerd, int? CategorieId, bool? InclContracten, bool? InclOnderhandelingen, string Inkoper, int? PeriodeId, int? RegioId, int? ZorgverstrekkerId, int? ZorgverzekeraarId) where T : SqlResponse;
		T csp_BehandelingZwarteLijst_u01<T>(IEnumerable<Database.UserDefinedTypes.Analyse.udtUpdateBehandelingZwarteLijst> UpdateList, int? ZorgverzekeraarId) where T : SqlResponse;
		T csp_ZorgverstrekkersScore_s01<T>(int? AfspraakIDModel, bool? AlleenSpeerpuntPrestaties, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> Categorien, bool? GeenSpeerpuntPrestaties, bool? InclContracten, bool? InclOnderhandelingen, int? RapportagePeriodeID, int? ZorgverzekeraarID) where T : SqlResponse;
		T csp_ZorgverstrekkerBudget_s05<T>(DateTime BeginDatum, DateTime EindDatum, int? PeriodeId, int? ZorgSoortId, int? ZorgverstrekkerId, int? ZorgverzekeraarId) where T : SqlResponse;
		T csp_ZorgverstrekkerBudget_d01<T>(int? PeriodeId, int? ZorgSoortId, int? ZorgverstrekkerId, int? ZorgverzekeraarId) where T : SqlResponse;
	}

	public interface IDataStaging
	{
		T csp_TogRecordType36_u01<T>(int? TogImportBatchLogID) where T : SqlResponse;
		T csp_TogRecordType36_i01<T>(string AanduidingPrestatiecodelijst, string DatumEindeTarief, string DatumIngangTarief, string DbcDeclaratieCode, string DbcDeclarerendSpecialisme, string DbcPoortspecialisme, ref int? Identity, string IndicatieDebetCredit, string IndicatieSoortZorg, string Kenmerk, string KenmerkRecord, string Mutatiecode, string SoortTarief, string Tarief, string ToelichtingMutatie, string TypeTarief) where T : SqlResponse;
		T csp_TogRecordType38_d01<T>(int? TogImportBatchLogID) where T : SqlResponse;
		T csp_TogRecordType38_u01<T>(int? TogImportBatchLogID) where T : SqlResponse;
		T csp_TogRecordType36_d01<T>(int? TogImportBatchLogID) where T : SqlResponse;
		T csp_SpreadTogRecords<T>(int? TogImportBatchLogID) where T : SqlResponse;
	}

	public interface IDbc
	{
		T csp_BehandelingStamdata_s01<T>(DateTime Peildatum) where T : SqlResponse;
		T csp_Periode_d01<T>(int? p_PeriodeID) where T : SqlResponse;
		T csp_Periode_i01<T>(string p_Omschrijving, DateTime p_PeriodEnd, DateTime p_PeriodStart) where T : SqlResponse;
		T csp_Periode_s01<T>(bool? p_SortDescending) where T : SqlResponse;
		T csp_Periode_u01<T>(string p_Omschrijving, int? p_PeriodeID, DateTime p_PeriodEnd, DateTime p_PeriodStart) where T : SqlResponse;
		T csp_TariefWijzigingType_s01<T>() where T : SqlResponse;
		T csp_PrestatieCode_s02<T>() where T : SqlResponse;
		T csp_PrestatieCode_s03<T>(string PrestatieCode) where T : SqlResponse;
		T csp_Specialisme_s01<T>(bool? AlleenHonCompSpecialismes) where T : SqlResponse;
		T csp_Specialisme_s03<T>() where T : SqlResponse;
		T csp_Groepsindeling_s01<T>(ref string GroepNaam, int? GroepsIndelingId) where T : SqlResponse;
		T csp_Prestatie_s06<T>(string Omschrijving) where T : SqlResponse;
		T csp_PrestatieCode_s06<T>(string segmentCode) where T : SqlResponse;
		T csp_ZorgType_s01<T>() where T : SqlResponse;
		T csp_ZorgVraag_s01<T>() where T : SqlResponse;
		T csp_Prestatie_s05<T>(int? PrestatieID) where T : SqlResponse;
		T csp_PrestatieCode_s01<T>(int? PrestatieID) where T : SqlResponse;
		T csp_Prestatie_s04<T>(string DBCCode, int? InstantieID) where T : SqlResponse;
		T csp_PrestatieCode_s07<T>(string PoortSpecialismeCode, string PrestatieCode) where T : SqlResponse;
		T csp_Diagnose_s01<T>() where T : SqlResponse;
		T csp_Prestatie_s03<T>(string AGBCode, string BEH_CODE, string DBC_DeclaratieCode, string DBCSEGMENTCODE, string DIA_CODE, int? InstantieID, DateTime PeilDatumTotEnMet, DateTime PeilDatumVanaf, string SPC_CODE, string UZOVICode, string ZTY_CODE, string ZVR_CODE) where T : SqlResponse;
		T csp_Behandeling_s01<T>() where T : SqlResponse;
	}

	public interface Idbo
	{
		T sp_upgraddiagrams<T>() where T : SqlResponse;
		T sp_helpdiagrams<T>(string diagramname, int? owner_id) where T : SqlResponse;
		T sp_helpdiagramdefinition<T>(string diagramname, int? owner_id) where T : SqlResponse;
		T sp_creatediagram<T>(byte[] definition, string diagramname, int? owner_id, int? version) where T : SqlResponse;
		T sp_renamediagram<T>(string diagramname, string new_diagramname, int? owner_id) where T : SqlResponse;
		T sp_alterdiagram<T>(byte[] definition, string diagramname, int? owner_id, int? version) where T : SqlResponse;
		T sp_dropdiagram<T>(string diagramname, int? owner_id) where T : SqlResponse;
	}

	public interface IHelp
	{
		T csp_HelpLink_s01<T>(DateTime DatumActief, string LinkCode, string Username) where T : SqlResponse;
	}

	public interface ILogs
	{
		T csp_OnderhandelingStatusLog_i01<T>(string ActieReden, int? AfspraakId, string BevestigingsTekst, string GewijzigdDoor) where T : SqlResponse;
		T csp_OnderhandelingStatusLog_s01<T>(int? AfspraakId) where T : SqlResponse;
		T csp_OnderhandelingStatusLog_s02<T>(int? AfspraakId) where T : SqlResponse;
		T csp_OnderhandelingStatusLog_s03<T>(int? EersteOnderhandelingId) where T : SqlResponse;
		T csp_log4netentries_s01<T>(string p_Application, DateTime p_DateEnd, DateTime p_DateStart, string p_Identity, bool? p_isTechnical, string p_Level) where T : SqlResponse;
	}

	public interface IOrganisatie
	{
		T csp_Rol_s02<T>(int? GebruikerID) where T : SqlResponse;
		T csp_GebruikerRol_d00<T>(int? GebruikerID, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> ZorgSoortIds) where T : SqlResponse;
		T csp_Gebruiker_s14<T>(int? InstantieID, bool? ToonVoorgesteldeKoppelingen) where T : SqlResponse;
		T csp_Gebruiker_s03<T>(string CommonName) where T : SqlResponse;
		T csp_GebruikerInstantie_d02<T>(int? GebruikerId, int? InstantieID, ref int? RemainingInstantieCount) where T : SqlResponse;
		T csp_Gebruiker_s01<T>(string CommonName, int? GebruikerID, bool? InclusiefNietGeaccepteerd) where T : SqlResponse;
		T csp_GebruikerInstantie_s02<T>() where T : SqlResponse;
		T csp_Gebruiker_s04<T>() where T : SqlResponse;
		T csp_GebruikerInstantie_u01<T>(int? GebruikerId, int? InstantieID, int? KoppelingGeaccepteerdDoor) where T : SqlResponse;
		T csp_Gebruiker_s07<T>(string CommonName, DateTime totDatum, DateTime vanDatum, int? ZorgSoort) where T : SqlResponse;
		T csp_Gebruiker_s08<T>(string CommonName, DateTime totDatum, DateTime vanDatum, int? zorgSoort) where T : SqlResponse;
		T csp_Gebruiker_i01<T>(string Achternaam, string CommonName, string CreateUser, string Email, string Tussenvoegsel, string Voorletters) where T : SqlResponse;
		T csp_GebruikerInstantie_i01<T>(string CreateUser, int? GebruikerID, int? InstantieID, int? KoppelingVoorgesteldDoor) where T : SqlResponse;
		T csp_Instantie_s01<T>(int? InstantieTypeID) where T : SqlResponse;
		T csp_InstantieType_s00<T>() where T : SqlResponse;
		T csp_AGBSoort_s01<T>() where T : SqlResponse;
		T csp_Zorgverzekeraar_s02<T>(string UZOVI) where T : SqlResponse;
		T csp_Gebruiker_s11<T>(bool? InclusiefNietGeaccepteerd, int? InstantieID) where T : SqlResponse;
		T csp_Gebruiker_s13<T>() where T : SqlResponse;
		T csp_Zorgverzekeraar_s10<T>(DateTime totDatum, DateTime vanDatum, int? zorgSoort) where T : SqlResponse;
		T csp_Gebruiker_u02<T>(string Achternaam, string Email, int? GebruikerID, bool? InActief, string Tussenvoegsel, string UpdateUser, string Voorletters) where T : SqlResponse;
		T csp_Provincie_s01<T>() where T : SqlResponse;
		T csp_GebruikerInstantie_d01<T>(string GebruikerIds, int? InstantieID) where T : SqlResponse;
		T csp_GebruikerInstantie_s01<T>(int? InstantieID) where T : SqlResponse;
		T csp_Zorgverstrekker_s11<T>(int? ZorgverstrekkerID) where T : SqlResponse;
		T csp_Zorgverstrekker_s06<T>(DateTime totDatum, DateTime vanDatum, int? zorgSoort) where T : SqlResponse;
		T csp_GebruikerRol_s01<T>() where T : SqlResponse;
		T csp_Instanties_s01<T>(int? InstantieID) where T : SqlResponse;
		T csp_Regio_s01<T>() where T : SqlResponse;
		T csp_Rol_s03<T>() where T : SqlResponse;
		T csp_Zorgverstrekker_s01<T>(string p_AGB, string p_AGBSoort, int? p_CTGCategorie, int? p_CTGNummer) where T : SqlResponse;
		T csp_Settings_i01<T>(int? InstantieID, string SettingName, string SettingValue, int? ZorgSoortID) where T : SqlResponse;
		T csp_Settings_s01<T>(int? InstantieID, string SettingName, int? ZorgSoortID) where T : SqlResponse;
		T csp_Zorgverstrekker_u01<T>(string Adres, string AGB, string AGBSoort, int? CTGCategorie, int? CTGNummer, string Email, int? ID, bool? Inactief, bool? IsHoofdLocatie, string Naam, string Plaats, string Postcode, string Telefoonnummer, string UpdateUser, string Website) where T : SqlResponse;
		T csp_Zorgverzekeraar_u01<T>(int? ID, string Naam, string UpdateUser, string UZOVI, string Website) where T : SqlResponse;
		T csp_Gebruiker_s09<T>(string VecozoCertificaatNummer) where T : SqlResponse;
		T csp_Instantie_s02<T>(int? InstantieID) where T : SqlResponse;
		T csp_GebruikerContactPersoon_s01<T>(bool? IncludeDBCSUsers, int? InstantieID, int? ZorgsoortID) where T : SqlResponse;
		T csp_Zorgverstrekker_s13<T>(string p_AGBParent) where T : SqlResponse;
		T csp_GebruikerRol_u01<T>(string CreateUser, int? GebruikerID, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> teOntnemenRolIDs, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> toeTeKennenRolIDs, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> ZorgSoortIds) where T : SqlResponse;
		T csp_Gebruiker_s05<T>(string CommonName, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> ZorgSoorten) where T : SqlResponse;
		T csp_Taak_s01<T>(int? GebruikerID) where T : SqlResponse;
		T csp_Rol_s01<T>() where T : SqlResponse;
	}

	public interface IOverig
	{
		T csp_Automodellen_i02<T>(DateTime datumMax, DateTime datumMin, string uzovi) where T : SqlResponse;
		T csp_Export_i01<T>(string AGB, string AGBSoort, bool? AlleenWijzigingen, DateTime BereikTot, DateTime BereikVan, string CategorieIds, string ExportIndicator, int? exportType, int? fileType, int? HistorischJaartal, ref int? identity, bool? InclActueleContracten, bool? InclNietSpeerpunten, bool? InclSpeerpunten, bool? InclVervallenContracten, string Inhoud, bool? isNOW, decimal? PrijsZKHMin, string referentie, DateTime wijzigingenVanaf, string ZorgproductCode, int? ZVZ_ID) where T : SqlResponse;
		T csp_Export_i02<T>(int? exportType, int? fileType, int? HistorischJaartal, ref int? identity, string referentie, int? ZVZ_ID) where T : SqlResponse;
		T csp_Export_s01<T>(int? ZVZ_ID) where T : SqlResponse;
		T csp_Export_s02<T>(int? ExportID) where T : SqlResponse;
		T csp_ExportFileType_s01<T>() where T : SqlResponse;
		T csp_RecordType34_s01<T>(bool? alleenWijzigingen, DateTime datumMax, DateTime datumMin, bool? inclActueleContracten, bool? inclVervallenContracten, IEnumerable<Database.UserDefinedTypes.Afspraak.udtInstantiePeriodeTable> nietTeExporterenZorgverstrekkers, decimal? prijsZKHMin, string uzovi, DateTime wijzigingenVanaf) where T : SqlResponse;
		T csp_ExportType_s01<T>() where T : SqlResponse;
		T csp_RecordTypeDatadump_s02<T>(string agb, string agbSoort, bool? inclContracten, bool? inclNietSpeerpunten, bool? inclOnderhandelingen, bool? inclSpeerpunten, DateTime peildatum, string uzovi, string zorgproductCode, int? zvsCategorie) where T : SqlResponse;
		T csp_RecordTypeCZ_s01<T>(int? CON_ID, DateTime wijzigingenVanaf) where T : SqlResponse;
		T csp_Export_s03<T>(string UZOVI) where T : SqlResponse;
		T csp_RecordTypeMZ_s02<T>(DateTime datumMax, DateTime datumMin, string uzovi, DateTime wijzigingenVanaf) where T : SqlResponse;
		T csp_RecordTypeDatadump_s01<T>(string agbSoort, DateTime datumMax, DateTime datumMin, bool? inclContracten, bool? inclOnderhandelingen, string uzovi, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> zvsCategorieen) where T : SqlResponse;
		T csp_TogImportBatchLog_i01<T>(DateTime ImportDatum, bool? IsIncrementeel, ref int? TogImportBatchLogID, int? TogProductieNummer, int? VersienummerBestand) where T : SqlResponse;
		T csp_SchemaChangeLog_s01<T>() where T : SqlResponse;
		T csp_TogImportBatchLog_s01<T>() where T : SqlResponse;
		T csp_TogImportBatchLog_u01<T>(int? AantalRecordsAangepast, int? AantalRecordsToegevoegd, int? AantalRecordsVerwijderd, string Melding, int? Status, string StatusInfo, int? TogImportBatchLogID) where T : SqlResponse;
		T csp_TogImportLog_i01<T>(DateTime Datum, ref int? Identity, int? ImportGeschiedenisID, string Omschrijving, int? TogRecordType) where T : SqlResponse;
		T csp_Automodellen_i01<T>(DateTime datumMax, DateTime datumMin, string uzovi) where T : SqlResponse;
		T csp_DisclaimerGetoond_i01<T>(int? AfspraakID, ref bool? Toegevoegd, string Username) where T : SqlResponse;
		T csp_DisclaimerGetoond_s01<T>(int? AfspraakID) where T : SqlResponse;
		T csp_RecordTypeCZ_S02<T>(bool? alleenWijzigingen, DateTime datumMax, DateTime datumMin, bool? inclActueleContracten, bool? inclVervallenContracten, IEnumerable<Database.UserDefinedTypes.Afspraak.udtInstantiePeriodeTable> nietTeExporterenZorgverstrekkers, decimal? prijsZKHMin, string uzovi, DateTime wijzigingenVanaf) where T : SqlResponse;
		T csp_RecordTypeCZ_S03<T>(bool? alleenWijzigingen, DateTime datumMax, DateTime datumMin, bool? inclActueleContracten, bool? inclVervallenContracten, IEnumerable<Database.UserDefinedTypes.Afspraak.udtInstantiePeriodeTable> nietTeExporterenZorgverstrekkers, decimal? prijsZKHMin, string uzovi, DateTime wijzigingenVanaf) where T : SqlResponse;
		T csp_RecordTypeCZ_S04<T>(bool? alleenWijzigingen, DateTime datumMax, DateTime datumMin, bool? inclActueleContracten, bool? inclVervallenContracten, IEnumerable<Database.UserDefinedTypes.Afspraak.udtInstantiePeriodeTable> nietTeExporterenZorgverstrekkers, decimal? prijsZKHMin, string uzovi, DateTime wijzigingenVanaf) where T : SqlResponse;
		T csp_RecordTypeCZ_S05<T>(bool? alleenWijzigingen, DateTime datumMax, DateTime datumMin, bool? inclActueleContracten, bool? inclVervallenContracten, IEnumerable<Database.UserDefinedTypes.Afspraak.udtInstantiePeriodeTable> nietTeExporterenZorgverstrekkers, decimal? prijsZKHMin, string uzovi, DateTime wijzigingenVanaf) where T : SqlResponse;
		T csp_RecordTypeMenzisCsv_s01<T>(int? CON_ID, DateTime wijzigingenVanaf) where T : SqlResponse;
		T csp_RecordType45_s03<T>(int? jaartalMax, int? jaartalMin, string uzovi, DateTime wijzigingenVanaf) where T : SqlResponse;
		T csp_RecordType45_s01<T>(int? jaartal, string uzovi, DateTime wijzigingenVanaf) where T : SqlResponse;
		T csp_RecordTypeMZ_S01<T>(DateTime datumMax, DateTime datumMin, string uzovi, DateTime wijzigingenVanaf) where T : SqlResponse;
		T csp_Export_u01<T>(int? exportStatus, string fileName, int? ID) where T : SqlResponse;
		T csp_Export_u02<T>(string FileType, int? ID, int? ZVZ_ID) where T : SqlResponse;
		T csp_ExportPeriode_s01<T>(bool? alleenWijzigingen, DateTime datumMax, DateTime datumMin, bool? inclActueleContracten, bool? inclVervallenContracten, IEnumerable<Database.UserDefinedTypes.Afspraak.udtInstantiePeriodeTable> nietTeExporterenZorgverstrekkers, decimal? prijsZKHMin, string uzovi, DateTime wijzigingenVanaf) where T : SqlResponse;
		T csp_ExportPeriode_u01<T>(bool? alleenWijzigingen, DateTime datumMax, DateTime datumMin, bool? inclActueleContracten, bool? inclVervallenContracten, IEnumerable<Database.UserDefinedTypes.Afspraak.udtInstantiePeriodeTable> nietTeExporterenZorgverstrekkers, decimal? prijsZKHMin, string uzovi, DateTime wijzigingenVanaf) where T : SqlResponse;
		T csp_Export_i03<T>(int? exportType, int? fileType, ref int? identity, string referentie, int? ZVZ_ID) where T : SqlResponse;
		T csp_Export_d01<T>(int? ExportID) where T : SqlResponse;
		T csp_RecordTypeAchmeaTIMIntegraal_s01<T>(string AgbSoort, DateTime DatumTot, DateTime DatumVanaf, string Uzovi) where T : SqlResponse;
		T csp_BijlageType_s01<T>() where T : SqlResponse;
		T csp_RecordTypeAchmeaTIM_s01<T>(string AgbSoort, DateTime DatumTot, DateTime DatumVanaf, string Uzovi) where T : SqlResponse;
	}

	public interface IRapportage
	{
		T csp_Prijsvergelijking_s01<T>(string agb, bool? inclNietSpeerpunten, bool? inclSpeerpunten, int? rapportageJaar, ref bool? rapportageNotFound, int? referentieJaar, ref bool? referentieNotFound, int? zorgverzekeraarId) where T : SqlResponse;
		T csp_OverzichtContracten_s01<T>(int? InstantieID) where T : SqlResponse;
		T csp_OverzichtOnderhandelingen_s01<T>(int? InstantieID) where T : SqlResponse;
		T csp_Voortgang_s01<T>(int? InstantieID, DateTime peildatum_1, DateTime peildatum_2) where T : SqlResponse;
		T csp_ModelAfspraak_s01<T>(int? Zorgverzekeraar) where T : SqlResponse;
		T csp_SjabloonPeriode_s01<T>(int? Zorgverzekeraar) where T : SqlResponse;
		T csp_SpeerpuntPeriode_s01<T>(int? Zorgverzekeraar) where T : SqlResponse;
		T csp_ScoreSpeerpunten_s01<T>(int? CategorieId, int? Inhoud, int? ModelAfspraak, int? Niveau, int? Periode, int? RegioId, int? Speerpunt, int? Zorgverzekeraar) where T : SqlResponse;
	}

	public interface ITarief
	{
		T csp_ContractExport_s01<T>(int? AfspraakID, bool? AlleTarieven) where T : SqlResponse;
		T csp_CreateModelContractFromOnderhandeling<T>(int? p_AfspraakID, int? p_InstantieType, ref int? p_ModelAfspraakID, string p_ModelCode, string p_ModelOmschrijving) where T : SqlResponse;
		T csp_OnderhandelingExport_s01<T>(int? AfspraakID, bool? AllePrestaties) where T : SqlResponse;
		T csp_OnderhandelingPrijslijst_u01<T>(int? AfspraakID, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodes, ref bool? OnderhandelingGewijzigd) where T : SqlResponse;
		T csp_OnderhandelingPrijslijst_i01<T>(int? AfspraakId, bool? ImportPrices, bool? ImportVolumes, IEnumerable<Database.UserDefinedTypes.Tarief.udtTariefPrijslijst> Prijslijst) where T : SqlResponse;
		T csp_OnderhandelingPrijslijst_s01<T>(int? AfspraakId) where T : SqlResponse;
	}

	public interface IVergelijking
	{
		T csp_GetDetailKosten_s02<T>(int? p_OnderhandelingGroepId, int? p_VergelijkingsBronID) where T : SqlResponse;
		T csp_CreateVergelijkingsPrestatieSet_i02<T>(int? p_VergelijkingID) where T : SqlResponse;
		T csp_VergelijkingsBronPrijslijst_u01<T>(int? p_VergelijkingID) where T : SqlResponse;
		T csp_GetVergelijkingExport_s02<T>(int? vergelijkingsBronID) where T : SqlResponse;
		T csp_NeemPrijzenOver8Integraal_u01<T>(int? AfspraakID, bool? AlleenLagereTarieven, int? BronIndex, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> FilterPrestatieIDs, bool? FilterPrestaties, int? VergelijkingID) where T : SqlResponse;
		T csp_VergelijkingsBronPrijslijst_u02<T>(int? p_VergelijkingID) where T : SqlResponse;
		T csp_BerekenKosten_i01<T>(int? p_VergelijkingID) where T : SqlResponse;
		T csp_NeemPrijzenOver8_u01<T>(int? AfspraakID, bool? AlleenLagereTarieven, int? BronIndex, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> FilterPrestatieIDs, bool? FilterPrestaties, int? VergelijkingID) where T : SqlResponse;
		T csp_BerekenKosten_i02<T>(int? p_VergelijkingsBronID) where T : SqlResponse;
		T csp_CreateVergelijking_i01<T>(int? p_AfspraakID, int? p_AfspraakIDVolumeSjabloon, ref int? p_VergelijkingID, int? p_VergelijkingType) where T : SqlResponse;
		T csp_CreateVergelijkingsBron_i01<T>(int? p_VergelijkingID, ref int? p_VergelijkingsBronID, int? p_VolumeAfspraakID) where T : SqlResponse;
		T csp_CreateVergelijkingsBron_i02<T>(int? p_AfspraakID, int? p_VergelijkingID, ref int? p_VergelijkingsBronID, int? p_VolumeAfspraakID) where T : SqlResponse;
		T csp_GetAfspraakData_s<T>(ref int? p_AfspraakID, ref int? p_OnderhandelingAfspraakID, int? p_VergelijkingID) where T : SqlResponse;
		T csp_HerBerekenKosten_u01<T>(int? p_VergelijkingID) where T : SqlResponse;
		T csp_GetVergelijkingExport_s01<T>(int? vergelijkingsBronID) where T : SqlResponse;
		T csp_CreateVergelijkingsPrestatieSet_i01<T>(int? p_VergelijkingID) where T : SqlResponse;
		T csp_ReCreateVergelijkingsPrestatieSet_u<T>(int? TariefType, int? VergelijkingID) where T : SqlResponse;
		T csp_NeemPrijzenOver_u01<T>(int? p_VergelijkingsBronID) where T : SqlResponse;
		T csp_ApplyDetailFilter_u01<T>(int? p_OnderhandelingGroepId, int? p_VergelijkingID) where T : SqlResponse;
		T csp_ApplyDetailFilter_u02a<T>(int? p_OnderhandelingGroepId, int? p_VergelijkingID) where T : SqlResponse;
		T csp_ApplyDetailFilter_u02b<T>(string p_DeclaratieCode, int? p_OnderhandelingGroepId, int? p_VergelijkingID) where T : SqlResponse;
		T csp_ApplyDetailFilter_u03<T>(string p_BehandelingCode, string p_DiagnoseCode, int? p_OnderhandelingGroepId, int? p_VergelijkingID, string p_ZorgTypeCode, string p_ZorgVraagCode) where T : SqlResponse;
		T csp_GetBronKosten_s<T>(int? p_VergelijkingsBronID) where T : SqlResponse;
		T csp_GetDetailKosten_s<T>(int? p_OnderhandelingGroepId, int? p_PageNumber, int? p_PageSize, int? p_SortColumn, bool? p_SortOrder, int? p_VergelijkingsBronID) where T : SqlResponse;
		T csp_GetKosten_s<T>(int? p_VergelijkingID) where T : SqlResponse;
		T csp_GetSelectionCount_s<T>(int? p_OnderhandelingGroepId, int? p_VergelijkingID) where T : SqlResponse;
	}

	#endregion

	#region Classes

	public class Afspraak : IAfspraak
	{
		private ISqlExecutor _executor;
		public Afspraak(ISqlExecutor executor)
		{
			_executor = executor;
		}

		public T csp_ImportOnderhandelingData_u01<T>(int? p_AfspraakID, bool? p_ImportPrices, bool? p_ImportVolumes, Guid p_StagingImportPrijslijstBatchToken) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ImportOnderhandelingData_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", ParameterDirection.Input, p_AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ImportPrices", ParameterDirection.Input, p_ImportPrices));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ImportVolumes", ParameterDirection.Input, p_ImportVolumes));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_StagingImportPrijslijstBatchToken", ParameterDirection.Input, p_StagingImportPrijslijstBatchToken));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Onderhandeling_u16<T>(int? p_AfspraakId, int? p_InstantieId, string p_UserName) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_u16");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakId", ParameterDirection.Input, p_AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieId", ParameterDirection.Input, p_InstantieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_UserName", ParameterDirection.Input, p_UserName));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_IsOnderhandelenToegestaanInPeriode<T>(DateTime p_PeriodeEind, DateTime p_PeriodeStart, int? p_ZorgverstrekkerID, int? p_ZorgverzekeraarID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_IsOnderhandelenToegestaanInPeriode");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_PeriodeEind", ParameterDirection.Input, p_PeriodeEind));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_PeriodeStart", ParameterDirection.Input, p_PeriodeStart));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ZorgverstrekkerID", ParameterDirection.Input, p_ZorgverstrekkerID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ZorgverzekeraarID", ParameterDirection.Input, p_ZorgverzekeraarID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingGroepsIndelingGroep_s04<T>(int? AfspraakID, int? GroepsIndelingID, int? VergelijkingID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingGroepsIndelingGroep_s04");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GroepsIndelingID", ParameterDirection.Input, GroepsIndelingID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@VergelijkingID", ParameterDirection.Input, VergelijkingID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingVolumeSpecificatieGewenst_s01<T>(int? AfspraakId, ref bool? VolumeSpecificatieGewenst) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingVolumeSpecificatieGewenst_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakId", ParameterDirection.Input, AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@VolumeSpecificatieGewenst", ParameterDirection.InputOutput, VolumeSpecificatieGewenst));
			var result = _executor.Execute<T>(request);
			VolumeSpecificatieGewenst = (bool?)request.GetParameterValue("@VolumeSpecificatieGewenst");
			return result;
		}

		public T csp_Onderhandeling_d04<T>(int? p_AfspraakID, int? p_InstantieId) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_d04");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", ParameterDirection.Input, p_AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieId", ParameterDirection.Input, p_InstantieId));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingPrestatie_s07<T>(int? AfspraakID, bool? AlleenIngesloten, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodes, string DeelVanOmschrijving, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> GroepFilter, int? GroepFilterType, bool? NegeerPrestatieFilter, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> ZorgproductCodes) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_s07");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AlleenIngesloten", ParameterDirection.Input, AlleenIngesloten));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@DeclaratieCodes", ParameterDirection.Input, "Overig", "udtVarCharTable", DeclaratieCodes));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DeelVanOmschrijving", ParameterDirection.Input, DeelVanOmschrijving));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@GroepFilter", ParameterDirection.Input, "Overig", "udtIntTable", GroepFilter));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GroepFilterType", ParameterDirection.Input, GroepFilterType));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@NegeerPrestatieFilter", ParameterDirection.Input, NegeerPrestatieFilter));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@ZorgproductCodes", ParameterDirection.Input, "Overig", "udtVarCharTable", ZorgproductCodes));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Onderhandeling_d05<T>(int? p_AfspraakID, string p_bevestigingsTekst, int? p_InstantieId, string p_UserName) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_d05");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", ParameterDirection.Input, p_AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_bevestigingsTekst", ParameterDirection.Input, p_bevestigingsTekst));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieId", ParameterDirection.Input, p_InstantieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_UserName", ParameterDirection.Input, p_UserName));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Onderhandeling_i08<T>(int? p_AfspraakID_From, string p_bevestigingsTekst, ref int? p_InstantieAanZet, int? p_InstantieId, ref int? p_newId, ref Guid p_NewVersieID, string p_Username) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_i08");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID_From", ParameterDirection.Input, p_AfspraakID_From));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_bevestigingsTekst", ParameterDirection.Input, p_bevestigingsTekst));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieAanZet", ParameterDirection.InputOutput, p_InstantieAanZet));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieId", ParameterDirection.Input, p_InstantieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_newId", ParameterDirection.InputOutput, p_newId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_NewVersieID", ParameterDirection.InputOutput, p_NewVersieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Username", ParameterDirection.Input, p_Username));
			var result = _executor.Execute<T>(request);
			p_InstantieAanZet = (int?)request.GetParameterValue("@p_InstantieAanZet");
			p_newId = (int?)request.GetParameterValue("@p_newId");
			p_NewVersieID = (Guid)request.GetParameterValue("@p_NewVersieID");
			return result;
		}

		public T csp_OnderhandelingPrestatie_s07_incl_vergelijken<T>(int? AfspraakID, bool? AlleenIngesloten, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodes, string DeelVanOmschrijving, bool? ForceerTariefVergelijking, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> GroepFilter, int? GroepFilterType, bool? NegeerPrestatieFilter, int? VergelijkingID, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> ZorgproductCodes) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_s07_incl_vergelijken");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AlleenIngesloten", ParameterDirection.Input, AlleenIngesloten));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@DeclaratieCodes", ParameterDirection.Input, "Overig", "udtVarCharTable", DeclaratieCodes));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DeelVanOmschrijving", ParameterDirection.Input, DeelVanOmschrijving));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ForceerTariefVergelijking", ParameterDirection.Input, ForceerTariefVergelijking));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@GroepFilter", ParameterDirection.Input, "Overig", "udtIntTable", GroepFilter));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GroepFilterType", ParameterDirection.Input, GroepFilterType));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@NegeerPrestatieFilter", ParameterDirection.Input, NegeerPrestatieFilter));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@VergelijkingID", ParameterDirection.Input, VergelijkingID));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@ZorgproductCodes", ParameterDirection.Input, "Overig", "udtVarCharTable", ZorgproductCodes));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Onderhandeling_i06<T>(int? AfspraakIDBlacklist, int? AfspraakIDSjabloon, int? AfspraakIDSpeerpunt, bool? AutomatischGestart, int? CPN_ZVS_ID, int? CPN_ZVZ_ID, DateTime EindDatum, int? INITIATOR, bool? IsPseudoOnderhandeling, ref int? NewAfspraakID, int? OnderhandelingUitgangspositieID, string SegmentCode, DateTime StartDatum, string USERNAME, int? ZVS_ID, int? ZVZ_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_i06");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDBlacklist", ParameterDirection.Input, AfspraakIDBlacklist));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDSjabloon", ParameterDirection.Input, AfspraakIDSjabloon));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDSpeerpunt", ParameterDirection.Input, AfspraakIDSpeerpunt));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AutomatischGestart", ParameterDirection.Input, AutomatischGestart));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CPN_ZVS_ID", ParameterDirection.Input, CPN_ZVS_ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CPN_ZVZ_ID", ParameterDirection.Input, CPN_ZVZ_ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@EindDatum", ParameterDirection.Input, EindDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@INITIATOR", ParameterDirection.Input, INITIATOR));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@IsPseudoOnderhandeling", ParameterDirection.Input, IsPseudoOnderhandeling));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@NewAfspraakID", ParameterDirection.InputOutput, NewAfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandelingUitgangspositieID", ParameterDirection.Input, OnderhandelingUitgangspositieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SegmentCode", ParameterDirection.Input, SegmentCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@StartDatum", ParameterDirection.Input, StartDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@USERNAME", ParameterDirection.Input, USERNAME));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVS_ID", ParameterDirection.Input, ZVS_ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVZ_ID", ParameterDirection.Input, ZVZ_ID));
			var result = _executor.Execute<T>(request);
			NewAfspraakID = (int?)request.GetParameterValue("@NewAfspraakID");
			return result;
		}

		public T csp_OnderhandelingPrestatie_u09<T>(int? AfspraakID, string DeclaratieCode, IEnumerable<Database.UserDefinedTypes.Afspraak.udtPrestatieInfoTable> Prestaties, decimal? Prijs) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_u09");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DeclaratieCode", ParameterDirection.Input, DeclaratieCode));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@Prestaties", ParameterDirection.Input, "Afspraak", "udtPrestatieInfoTable", Prestaties));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Prijs", ParameterDirection.Input, Prijs));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Onderhandeling_i07<T>(int? p_AfspraakID_From, string p_bevestigingsTekst, ref int? p_InstantieAanZet, int? p_InstantieId, ref int? p_NewId, ref Guid p_NewVersieID, string p_Username, string p_VoorgesteldDoor) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_i07");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID_From", ParameterDirection.Input, p_AfspraakID_From));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_bevestigingsTekst", ParameterDirection.Input, p_bevestigingsTekst));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieAanZet", ParameterDirection.InputOutput, p_InstantieAanZet));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieId", ParameterDirection.Input, p_InstantieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_NewId", ParameterDirection.InputOutput, p_NewId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_NewVersieID", ParameterDirection.InputOutput, p_NewVersieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Username", ParameterDirection.Input, p_Username));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VoorgesteldDoor", ParameterDirection.Input, p_VoorgesteldDoor));
			var result = _executor.Execute<T>(request);
			p_InstantieAanZet = (int?)request.GetParameterValue("@p_InstantieAanZet");
			p_NewId = (int?)request.GetParameterValue("@p_NewId");
			p_NewVersieID = (Guid)request.GetParameterValue("@p_NewVersieID");
			return result;
		}

		public T csp_OnderhandelingPrestatieTariefSoort_s02<T>(int? AfspraakID, string DeclaratieCode) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatieTariefSoort_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DeclaratieCode", ParameterDirection.Input, DeclaratieCode));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Onderhandeling_u04<T>(int? p_AfspraakId, string p_bevestigingsTekst, string p_GewijzigdDoor, ref int? p_InstantieAanZet, int? p_InstantieId, int? p_NewStatus, string p_UserName) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_u04");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakId", ParameterDirection.Input, p_AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_bevestigingsTekst", ParameterDirection.Input, p_bevestigingsTekst));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_GewijzigdDoor", ParameterDirection.Input, p_GewijzigdDoor));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieAanZet", ParameterDirection.InputOutput, p_InstantieAanZet));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieId", ParameterDirection.Input, p_InstantieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_NewStatus", ParameterDirection.Input, p_NewStatus));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_UserName", ParameterDirection.Input, p_UserName));
			var result = _executor.Execute<T>(request);
			p_InstantieAanZet = (int?)request.GetParameterValue("@p_InstantieAanZet");
			return result;
		}

		public T csp_OnderhandelingPrijslijst_s03<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrijslijst_s03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Onderhandeling_u05<T>(int? p_AfspraakId, int? p_InstantieId, string p_UserName) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_u05");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakId", ParameterDirection.Input, p_AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieId", ParameterDirection.Input, p_InstantieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_UserName", ParameterDirection.Input, p_UserName));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingUitgangspositie_i04<T>(int? AfspraakIDBlacklist, int? AfspraakIDContract, int? AfspraakIDModel, int? AfspraakIDSjabloon, int? AfspraakIDSpeerpunt, int? AfspraakIDVolumeContract, int? AfspraakIDVolumeModel, ref int? NewUitgangspositieID, string Username) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingUitgangspositie_i04");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDBlacklist", ParameterDirection.Input, AfspraakIDBlacklist));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDContract", ParameterDirection.Input, AfspraakIDContract));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDModel", ParameterDirection.Input, AfspraakIDModel));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDSjabloon", ParameterDirection.Input, AfspraakIDSjabloon));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDSpeerpunt", ParameterDirection.Input, AfspraakIDSpeerpunt));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDVolumeContract", ParameterDirection.Input, AfspraakIDVolumeContract));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDVolumeModel", ParameterDirection.Input, AfspraakIDVolumeModel));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@NewUitgangspositieID", ParameterDirection.InputOutput, NewUitgangspositieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Username", ParameterDirection.Input, Username));
			var result = _executor.Execute<T>(request);
			NewUitgangspositieID = (int?)request.GetParameterValue("@NewUitgangspositieID");
			return result;
		}

		public T csp_Onderhandeling_u06<T>(int? CON_ID, int? ContactPersoonZVSID, int? ContactPersoonZVZID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_u06");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CON_ID", ParameterDirection.Input, CON_ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ContactPersoonZVSID", ParameterDirection.Input, ContactPersoonZVSID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ContactPersoonZVZID", ParameterDirection.Input, ContactPersoonZVZID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Onderhandeling_u07<T>(int? p_AfspraakId, DateTime p_BeginDatum, DateTime p_EindDatum, string p_ReferentieZVS, string p_ReferentieZVZ, int? p_TargetAfspraakIDModel, string p_TariefWijzigingTypeCode) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_u07");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakId", ParameterDirection.Input, p_AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_BeginDatum", ParameterDirection.Input, p_BeginDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_EindDatum", ParameterDirection.Input, p_EindDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ReferentieZVS", ParameterDirection.Input, p_ReferentieZVS));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ReferentieZVZ", ParameterDirection.Input, p_ReferentieZVZ));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_TargetAfspraakIDModel", ParameterDirection.Input, p_TargetAfspraakIDModel));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_TariefWijzigingTypeCode", ParameterDirection.Input, p_TariefWijzigingTypeCode));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Contract_s08<T>(int? jaartal, string uzovi, DateTime wijzigingenVanaf) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_s08");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@jaartal", ParameterDirection.Input, jaartal));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@uzovi", ParameterDirection.Input, uzovi));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@wijzigingenVanaf", ParameterDirection.Input, wijzigingenVanaf));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Contract_i10<T>(int? p_AfspraakID, ref int? p_AfspraakIDContract, bool? p_AutomatischGeaccordeerd, string p_UserName) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_i10");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", ParameterDirection.Input, p_AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakIDContract", ParameterDirection.InputOutput, p_AfspraakIDContract));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AutomatischGeaccordeerd", ParameterDirection.Input, p_AutomatischGeaccordeerd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_UserName", ParameterDirection.Input, p_UserName));
			var result = _executor.Execute<T>(request);
			p_AfspraakIDContract = (int?)request.GetParameterValue("@p_AfspraakIDContract");
			return result;
		}

		public T csp_OnderhandelingGroep_s01<T>(int? p_AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingGroep_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", ParameterDirection.Input, p_AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Onderhandeling_i15<T>(int? p_AfspraakID_From, string p_bevestigingsTekst, ref int? p_InstantieAanZet, int? p_InstantieId, ref int? p_NewId, ref Guid p_NewVersieID, string p_Username, string p_VoorgesteldDoor) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_i15");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID_From", ParameterDirection.Input, p_AfspraakID_From));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_bevestigingsTekst", ParameterDirection.Input, p_bevestigingsTekst));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieAanZet", ParameterDirection.InputOutput, p_InstantieAanZet));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieId", ParameterDirection.Input, p_InstantieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_NewId", ParameterDirection.InputOutput, p_NewId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_NewVersieID", ParameterDirection.InputOutput, p_NewVersieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Username", ParameterDirection.Input, p_Username));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VoorgesteldDoor", ParameterDirection.Input, p_VoorgesteldDoor));
			var result = _executor.Execute<T>(request);
			p_InstantieAanZet = (int?)request.GetParameterValue("@p_InstantieAanZet");
			p_NewId = (int?)request.GetParameterValue("@p_NewId");
			p_NewVersieID = (Guid)request.GetParameterValue("@p_NewVersieID");
			return result;
		}

		public T csp_OnderhandelingGroep_s02<T>(int? p_OnderhandelingGroepID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingGroep_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingGroepID", ParameterDirection.Input, p_OnderhandelingGroepID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Onderhandeling_i16<T>(int? p_AfspraakID_From, string p_bevestigingsTekst, ref int? p_InstantieAanZet, int? p_InstantieId, ref int? p_newId, ref Guid p_NewVersieID, string p_Username) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_i16");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID_From", ParameterDirection.Input, p_AfspraakID_From));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_bevestigingsTekst", ParameterDirection.Input, p_bevestigingsTekst));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieAanZet", ParameterDirection.InputOutput, p_InstantieAanZet));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieId", ParameterDirection.Input, p_InstantieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_newId", ParameterDirection.InputOutput, p_newId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_NewVersieID", ParameterDirection.InputOutput, p_NewVersieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Username", ParameterDirection.Input, p_Username));
			var result = _executor.Execute<T>(request);
			p_InstantieAanZet = (int?)request.GetParameterValue("@p_InstantieAanZet");
			p_newId = (int?)request.GetParameterValue("@p_newId");
			p_NewVersieID = (Guid)request.GetParameterValue("@p_NewVersieID");
			return result;
		}

		public T csp_OnderhandelingPrestatie_u03<T>(int? AfspraakID, string DeclaratieCode, IEnumerable<Database.UserDefinedTypes.Afspraak.udtPrestatieInfoTable> Prestaties, decimal? PrijsHon0303, decimal? PrijsHon0307, decimal? PrijsHon0313, decimal? PrijsHon0316, decimal? PrijsHon0318, decimal? PrijsHon0320, decimal? PrijsHon0322, decimal? PrijsHon0330, decimal? PrijsHon0361, decimal? PrijsHon0362, decimal? PrijsHon0363, decimal? PrijsHon0386, decimal? PrijsHon0387, decimal? PrijsHon0388, decimal? PrijsHon0389, decimal? PrijsHonNietOndh, decimal? PrijsHonOverig, decimal? PrijsZKH) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_u03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DeclaratieCode", ParameterDirection.Input, DeclaratieCode));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@Prestaties", ParameterDirection.Input, "Afspraak", "udtPrestatieInfoTable", Prestaties));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsHon0303", ParameterDirection.Input, PrijsHon0303));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsHon0307", ParameterDirection.Input, PrijsHon0307));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsHon0313", ParameterDirection.Input, PrijsHon0313));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsHon0316", ParameterDirection.Input, PrijsHon0316));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsHon0318", ParameterDirection.Input, PrijsHon0318));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsHon0320", ParameterDirection.Input, PrijsHon0320));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsHon0322", ParameterDirection.Input, PrijsHon0322));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsHon0330", ParameterDirection.Input, PrijsHon0330));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsHon0361", ParameterDirection.Input, PrijsHon0361));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsHon0362", ParameterDirection.Input, PrijsHon0362));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsHon0363", ParameterDirection.Input, PrijsHon0363));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsHon0386", ParameterDirection.Input, PrijsHon0386));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsHon0387", ParameterDirection.Input, PrijsHon0387));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsHon0388", ParameterDirection.Input, PrijsHon0388));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsHon0389", ParameterDirection.Input, PrijsHon0389));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsHonNietOndh", ParameterDirection.Input, PrijsHonNietOndh));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsHonOverig", ParameterDirection.Input, PrijsHonOverig));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsZKH", ParameterDirection.Input, PrijsZKH));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingGroep_u01<T>(object p_AfwijkingConsult, object p_AfwijkingHonOndh, object p_AfwijkingKlinisch, object p_AfwijkingNietKlinisch, object p_AfwijkingZKH, int? p_OnderhandelingGroepID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingGroep_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfwijkingConsult", ParameterDirection.Input, p_AfwijkingConsult));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfwijkingHonOndh", ParameterDirection.Input, p_AfwijkingHonOndh));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfwijkingKlinisch", ParameterDirection.Input, p_AfwijkingKlinisch));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfwijkingNietKlinisch", ParameterDirection.Input, p_AfwijkingNietKlinisch));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfwijkingZKH", ParameterDirection.Input, p_AfwijkingZKH));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingGroepID", ParameterDirection.Input, p_OnderhandelingGroepID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ContractAfspraak_u01<T>(int? AfspraakID, int? ContactPersoonZVSID, int? ContactPersoonZVZID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ContractAfspraak_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ContactPersoonZVSID", ParameterDirection.Input, ContactPersoonZVSID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ContactPersoonZVZID", ParameterDirection.Input, ContactPersoonZVZID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingGroep_u02<T>(int? OnderhandelingAfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingGroep_u02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandelingAfspraakID", ParameterDirection.Input, OnderhandelingAfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_Geen16Codes_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_Geen16Codes_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingGroepsIndelingGroep_s03<T>(int? AfspraakID, int? GroepsIndelingID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingGroepsIndelingGroep_s03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GroepsIndelingID", ParameterDirection.Input, GroepsIndelingID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingGroep_u03<T>(int? p_OnderhandelingGroepID, bool? p_SelectBack) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingGroep_u03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingGroepID", ParameterDirection.Input, p_OnderhandelingGroepID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_SelectBack", ParameterDirection.Input, p_SelectBack));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_Geen16Codes_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_Geen16Codes_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", ParameterDirection.InputOutput, AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			AfspraakGewijzigd = (bool?)request.GetParameterValue("@AfspraakGewijzigd");
			return result;
		}

		public T csp_OnderhandelingPrestatie_s06<T>(int? AfspraakID, bool? AlleenIngesloten, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodes, string DeelVanOmschrijving, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> GroepFilter, int? GroepFilterType) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_s06");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AlleenIngesloten", ParameterDirection.Input, AlleenIngesloten));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@DeclaratieCodes", ParameterDirection.Input, "Overig", "udtVarCharTable", DeclaratieCodes));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DeelVanOmschrijving", ParameterDirection.Input, DeelVanOmschrijving));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@GroepFilter", ParameterDirection.Input, "Overig", "udtIntTable", GroepFilter));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GroepFilterType", ParameterDirection.Input, GroepFilterType));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingGroep_u04<T>(int? p_OnderhandelingAfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingGroep_u04");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingAfspraakID", ParameterDirection.Input, p_OnderhandelingAfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_TotaalHogerDanPassanten_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_TotaalHogerDanPassanten_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingPrestatie_u08<T>(int? AfspraakID, string DeclaratieCode, bool? Ingesloten, decimal? Tarief, int? VolumeComponent1, int? VolumeComponent2, int? VolumeComponent3) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_u08");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DeclaratieCode", ParameterDirection.Input, DeclaratieCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Ingesloten", ParameterDirection.Input, Ingesloten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Tarief", ParameterDirection.Input, Tarief));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@VolumeComponent1", ParameterDirection.Input, VolumeComponent1));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@VolumeComponent2", ParameterDirection.Input, VolumeComponent2));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@VolumeComponent3", ParameterDirection.Input, VolumeComponent3));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ImportModelData_u01<T>(int? AfspraakID, Guid StagingImportPrijslijstBatchToken) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ImportModelData_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@StagingImportPrijslijstBatchToken", ParameterDirection.Input, StagingImportPrijslijstBatchToken));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingPrestatie_s01<T>(bool? p_FilterAlleenUitzonderingen, string p_FilterBehandelingCode, string p_FilterDeclaratieCodes, string p_FilterDiagnoseCode, string p_FilterZorgTypeCode, string p_FilterZorgVraagCode, int? p_OnderhandelingGroepID, int? p_PageNr, int? p_PageSize, string p_SorteringKolom, string p_SorteringVolgorde) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_FilterAlleenUitzonderingen", ParameterDirection.Input, p_FilterAlleenUitzonderingen));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_FilterBehandelingCode", ParameterDirection.Input, p_FilterBehandelingCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_FilterDeclaratieCodes", ParameterDirection.Input, p_FilterDeclaratieCodes));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_FilterDiagnoseCode", ParameterDirection.Input, p_FilterDiagnoseCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_FilterZorgTypeCode", ParameterDirection.Input, p_FilterZorgTypeCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_FilterZorgVraagCode", ParameterDirection.Input, p_FilterZorgVraagCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingGroepID", ParameterDirection.Input, p_OnderhandelingGroepID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_PageNr", ParameterDirection.Input, p_PageNr));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_PageSize", ParameterDirection.Input, p_PageSize));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_SorteringKolom", ParameterDirection.Input, p_SorteringKolom));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_SorteringVolgorde", ParameterDirection.Input, p_SorteringVolgorde));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_TotaalHogerDanPassanten_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_TotaalHogerDanPassanten_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", ParameterDirection.InputOutput, AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			AfspraakGewijzigd = (bool?)request.GetParameterValue("@AfspraakGewijzigd");
			return result;
		}

		public T csp_OnderhandelingUitgangspositie_i03<T>(int? AfspraakIDSjabloon, ref int? NieuweUitgangspositieID, string Username) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingUitgangspositie_i03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDSjabloon", ParameterDirection.Input, AfspraakIDSjabloon));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@NieuweUitgangspositieID", ParameterDirection.InputOutput, NieuweUitgangspositieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Username", ParameterDirection.Input, Username));
			var result = _executor.Execute<T>(request);
			NieuweUitgangspositieID = (int?)request.GetParameterValue("@NieuweUitgangspositieID");
			return result;
		}

		public T csp_OnderhandelingPrestatie_s02<T>(int? p_AfspraakID, string p_DeclaratieCode) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", ParameterDirection.Input, p_AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_DeclaratieCode", ParameterDirection.Input, p_DeclaratieCode));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingPrestatie_u01<T>(string p_DeclaratieCode, bool? p_ForceerGroepsuitzondering, bool? p_Ingesloten, int? p_OnderhandelingAfspraakID, ref int? p_OnderhandelingGroepsUitzonderingID, decimal? p_PrijsHonOndh, decimal? p_PrijsZKH, string p_TariefWijzigingTypeCode) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_DeclaratieCode", ParameterDirection.Input, p_DeclaratieCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ForceerGroepsuitzondering", ParameterDirection.Input, p_ForceerGroepsuitzondering));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Ingesloten", ParameterDirection.Input, p_Ingesloten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingAfspraakID", ParameterDirection.Input, p_OnderhandelingAfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingGroepsUitzonderingID", ParameterDirection.InputOutput, p_OnderhandelingGroepsUitzonderingID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_PrijsHonOndh", ParameterDirection.Input, p_PrijsHonOndh));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_PrijsZKH", ParameterDirection.Input, p_PrijsZKH));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_TariefWijzigingTypeCode", ParameterDirection.Input, p_TariefWijzigingTypeCode));
			var result = _executor.Execute<T>(request);
			p_OnderhandelingGroepsUitzonderingID = (int?)request.GetParameterValue("@p_OnderhandelingGroepsUitzonderingID");
			return result;
		}

		public T csp_OnderhandelingPrestatie_u02<T>(int? p_OnderhandelingAfspraakID, int? p_PrestatieID, bool? p_Uitgesloten, int? p_Volume) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_u02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingAfspraakID", ParameterDirection.Input, p_OnderhandelingAfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_PrestatieID", ParameterDirection.Input, p_PrestatieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Uitgesloten", ParameterDirection.Input, p_Uitgesloten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Volume", ParameterDirection.Input, p_Volume));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingPrijslijst_s01<T>(int? CON_ID, bool? IsOnlyAfspraken) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrijslijst_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CON_ID", ParameterDirection.Input, CON_ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@IsOnlyAfspraken", ParameterDirection.Input, IsOnlyAfspraken));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_CreateModelContractFromOnderhandeling<T>(int? p_AfspraakID, int? p_InstantieType, ref int? p_ModelAfspraakID, string p_ModelCode, string p_ModelOmschrijving) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_CreateModelContractFromOnderhandeling");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", ParameterDirection.Input, p_AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieType", ParameterDirection.Input, p_InstantieType));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ModelAfspraakID", ParameterDirection.InputOutput, p_ModelAfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ModelCode", ParameterDirection.Input, p_ModelCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ModelOmschrijving", ParameterDirection.Input, p_ModelOmschrijving));
			var result = _executor.Execute<T>(request);
			p_ModelAfspraakID = (int?)request.GetParameterValue("@p_ModelAfspraakID");
			return result;
		}

		public T csp_Contract_d02<T>(int? AfspraakId, int? InstantieId, string Username) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_d02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakId", ParameterDirection.Input, AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieId", ParameterDirection.Input, InstantieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Username", ParameterDirection.Input, Username));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingPrijslijst_u01<T>(int? p_OnderhandelingGroepID, bool? p_SelectBack) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrijslijst_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingGroepID", ParameterDirection.Input, p_OnderhandelingGroepID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_SelectBack", ParameterDirection.Input, p_SelectBack));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingGroepsUitzonderingHonOndhComp_d01<T>(int? OnderhandelingGroepsuitzonderingID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingGroepsUitzonderingHonOndhComp_d01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandelingGroepsuitzonderingID", ParameterDirection.Input, OnderhandelingGroepsuitzonderingID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Contract_d03<T>(int? AfspraakId, int? InstantieId, string Username) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_d03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakId", ParameterDirection.Input, AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieId", ParameterDirection.Input, InstantieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Username", ParameterDirection.Input, Username));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingPrijslijstHonOndhComp_s02<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrijslijstHonOndhComp_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingGroepsUitzonderingHonOndhComp_i01<T>(int? OnderhandelingGroepsuitzonderingID, decimal? Prijs, string SpecialismeCode) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingGroepsUitzonderingHonOndhComp_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandelingGroepsuitzonderingID", ParameterDirection.Input, OnderhandelingGroepsuitzonderingID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Prijs", ParameterDirection.Input, Prijs));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SpecialismeCode", ParameterDirection.Input, SpecialismeCode));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Contract_d04<T>(int? AfspraakId, int? InstantieId, string Username) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_d04");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakId", ParameterDirection.Input, AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieId", ParameterDirection.Input, InstantieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Username", ParameterDirection.Input, Username));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingStatusovergangCheck_s01<T>(int? p_AfspraakID, int? p_InstantieID, int? p_NewStatus) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingStatusovergangCheck_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", ParameterDirection.Input, p_AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieID", ParameterDirection.Input, p_InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_NewStatus", ParameterDirection.Input, p_NewStatus));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Onderhandeling_i10<T>(string AangemaaktDoor, int? AfspraakIDSjabloon, DateTime EindDatum, int? InitierendeInstantieTypeID, ref int? NieuweAfspraakID, int? OnderhandelingUitgangspositieID, DateTime StartDatum, int? ZorgverstrekkerID, int? ZorgverzekeraarID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_i10");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AangemaaktDoor", ParameterDirection.Input, AangemaaktDoor));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDSjabloon", ParameterDirection.Input, AfspraakIDSjabloon));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@EindDatum", ParameterDirection.Input, EindDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InitierendeInstantieTypeID", ParameterDirection.Input, InitierendeInstantieTypeID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@NieuweAfspraakID", ParameterDirection.InputOutput, NieuweAfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandelingUitgangspositieID", ParameterDirection.Input, OnderhandelingUitgangspositieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@StartDatum", ParameterDirection.Input, StartDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerID", ParameterDirection.Input, ZorgverstrekkerID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarID", ParameterDirection.Input, ZorgverzekeraarID));
			var result = _executor.Execute<T>(request);
			NieuweAfspraakID = (int?)request.GetParameterValue("@NieuweAfspraakID");
			return result;
		}

		public T csp_OnderhandelingPrestatie_s04<T>(int? p_AfspraakID, string p_DeclaratieCode) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_s04");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", ParameterDirection.Input, p_AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_DeclaratieCode", ParameterDirection.Input, p_DeclaratieCode));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Contract_s06<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_s06");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingUitgangspositie_i01<T>(int? AfspraakIDBlacklist, int? AfspraakIDContract, int? AfspraakIDModel, int? AfspraakIDSjabloon, int? AfspraakIDSpeerpunt, int? AfspraakIDVolumeContract, int? AfspraakIDVolumeModel, ref int? NewUitgangspositieID, string SegmentCode, bool? TotaalprijsGelijk, string Username) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingUitgangspositie_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDBlacklist", ParameterDirection.Input, AfspraakIDBlacklist));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDContract", ParameterDirection.Input, AfspraakIDContract));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDModel", ParameterDirection.Input, AfspraakIDModel));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDSjabloon", ParameterDirection.Input, AfspraakIDSjabloon));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDSpeerpunt", ParameterDirection.Input, AfspraakIDSpeerpunt));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDVolumeContract", ParameterDirection.Input, AfspraakIDVolumeContract));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDVolumeModel", ParameterDirection.Input, AfspraakIDVolumeModel));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@NewUitgangspositieID", ParameterDirection.InputOutput, NewUitgangspositieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SegmentCode", ParameterDirection.Input, SegmentCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@TotaalprijsGelijk", ParameterDirection.Input, TotaalprijsGelijk));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Username", ParameterDirection.Input, Username));
			var result = _executor.Execute<T>(request);
			NewUitgangspositieID = (int?)request.GetParameterValue("@NewUitgangspositieID");
			return result;
		}

		public T csp_Onderhandeling_u12<T>(int? AfspraakId, string BevestigingsTekst, string GewijzigdDoor, int? NieuweOnderhandelingStatus, ref int? p_InstantieAanZet, string UserName) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_u12");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakId", ParameterDirection.Input, AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BevestigingsTekst", ParameterDirection.Input, BevestigingsTekst));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GewijzigdDoor", ParameterDirection.Input, GewijzigdDoor));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@NieuweOnderhandelingStatus", ParameterDirection.Input, NieuweOnderhandelingStatus));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieAanZet", ParameterDirection.InputOutput, p_InstantieAanZet));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@UserName", ParameterDirection.Input, UserName));
			var result = _executor.Execute<T>(request);
			p_InstantieAanZet = (int?)request.GetParameterValue("@p_InstantieAanZet");
			return result;
		}

		public T csp_Contract_u04<T>(int? afspraakId) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_u04");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@afspraakId", ParameterDirection.Input, afspraakId));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelPeriode_s01<T>(int? p_ZorgverstrekkerID, int? p_ZorgverzekeraarID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelPeriode_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ZorgverstrekkerID", ParameterDirection.Input, p_ZorgverstrekkerID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ZorgverzekeraarID", ParameterDirection.Input, p_ZorgverzekeraarID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Onderhandeling_u13<T>(int? AfspraakId, string BevestigingsTekst, string GewijzigdDoor, int? NieuweOnderhandelingStatus, string UserName) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_u13");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakId", ParameterDirection.Input, AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BevestigingsTekst", ParameterDirection.Input, BevestigingsTekst));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GewijzigdDoor", ParameterDirection.Input, GewijzigdDoor));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@NieuweOnderhandelingStatus", ParameterDirection.Input, NieuweOnderhandelingStatus));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@UserName", ParameterDirection.Input, UserName));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelPeriode_s02<T>(int? p_PeriodeID, int? p_ZorgverzekeraarID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelPeriode_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_PeriodeID", ParameterDirection.Input, p_PeriodeID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ZorgverzekeraarID", ParameterDirection.Input, p_ZorgverzekeraarID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Contract_s10<T>(int? AfspraakID, int? InstantieID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_s10");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", ParameterDirection.Input, InstantieID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingPrestatie_s05_incl_vergelijken<T>(int? AfspraakID, bool? AlleenIngesloten, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodes, string DeelVanOmschrijving, bool? ForceerTariefVergelijking, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> GroepFilter, int? GroepFilterType, bool? InclHonorariumComponenten, bool? NegeerPrestatieFilter, int? VergelijkingID, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> ZorgproductCodes) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_s05_incl_vergelijken");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AlleenIngesloten", ParameterDirection.Input, AlleenIngesloten));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@DeclaratieCodes", ParameterDirection.Input, "Overig", "udtVarCharTable", DeclaratieCodes));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DeelVanOmschrijving", ParameterDirection.Input, DeelVanOmschrijving));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ForceerTariefVergelijking", ParameterDirection.Input, ForceerTariefVergelijking));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@GroepFilter", ParameterDirection.Input, "Overig", "udtIntTable", GroepFilter));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GroepFilterType", ParameterDirection.Input, GroepFilterType));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InclHonorariumComponenten", ParameterDirection.Input, InclHonorariumComponenten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@NegeerPrestatieFilter", ParameterDirection.Input, NegeerPrestatieFilter));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@VergelijkingID", ParameterDirection.Input, VergelijkingID));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@ZorgproductCodes", ParameterDirection.Input, "Overig", "udtVarCharTable", ZorgproductCodes));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelPeriode_save01<T>(bool? p_OnderhandelenToegestaan, int? p_PeriodeID, int? p_ZorgverstrekkerID, int? p_ZorgverzekeraarID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelPeriode_save01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelenToegestaan", ParameterDirection.Input, p_OnderhandelenToegestaan));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_PeriodeID", ParameterDirection.Input, p_PeriodeID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ZorgverstrekkerID", ParameterDirection.Input, p_ZorgverstrekkerID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ZorgverzekeraarID", ParameterDirection.Input, p_ZorgverzekeraarID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_PrestatiesOpGrijzeEnZwarteLijst_s01<T>(int? AfspraakId) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_PrestatiesOpGrijzeEnZwarteLijst_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakId", ParameterDirection.Input, AfspraakId));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Afspraak_s06<T>(int? InstantieID, int? PrestatieID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Afspraak_s06");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", ParameterDirection.Input, InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrestatieID", ParameterDirection.Input, PrestatieID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Contract_s17<T>(bool? ActiveOnly, int? AfspraakID, bool? InclChildContracten, int? InstantieID, int? ZorgsoortID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_s17");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ActiveOnly", ParameterDirection.Input, ActiveOnly));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InclChildContracten", ParameterDirection.Input, InclChildContracten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", ParameterDirection.Input, InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgsoortID", ParameterDirection.Input, ZorgsoortID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Sjabloon_s02<T>(ref int? AfspraakID, int? SjabloonAfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Sjabloon_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.InputOutput, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SjabloonAfspraakID", ParameterDirection.Input, SjabloonAfspraakID));
			var result = _executor.Execute<T>(request);
			AfspraakID = (int?)request.GetParameterValue("@AfspraakID");
			return result;
		}

		public T csp_PrestatiesOpGrijzeEnZwarteLijst_s02<T>(int? AfspraakId, DateTime Peildatum) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_PrestatiesOpGrijzeEnZwarteLijst_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakId", ParameterDirection.Input, AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Peildatum", ParameterDirection.Input, Peildatum));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Onderhandeling_s09<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_s09");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_SpeerpuntAfspraak_s01<T>(DateTime periodeEind, DateTime periodeStart, string Segment, int? ZorgverstrekkerID, int? ZorgverzekeraarID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_SpeerpuntAfspraak_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@periodeEind", ParameterDirection.Input, periodeEind));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@periodeStart", ParameterDirection.Input, periodeStart));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Segment", ParameterDirection.Input, Segment));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerID", ParameterDirection.Input, ZorgverstrekkerID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarID", ParameterDirection.Input, ZorgverzekeraarID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingFlowgegevens_s01<T>(int? AfspraakId, int? InstantieTypeID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingFlowgegevens_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakId", ParameterDirection.Input, AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieTypeID", ParameterDirection.Input, InstantieTypeID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelGeschiedenis_i01<T>(int? AfspraakID, DateTime AktieDatum, int? AktieID, int? GebruikerID, int? InstantieAanZet, string Opmerking, bool? VerbergOpmerkingVoorAnderePartij) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelGeschiedenis_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AktieDatum", ParameterDirection.Input, AktieDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AktieID", ParameterDirection.Input, AktieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GebruikerID", ParameterDirection.Input, GebruikerID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieAanZet", ParameterDirection.Input, InstantieAanZet));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Opmerking", ParameterDirection.Input, Opmerking));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@VerbergOpmerkingVoorAnderePartij", ParameterDirection.Input, VerbergOpmerkingVoorAnderePartij));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelGeschiedenis_s01<T>(int? AfspraakID, int? InstantieID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelGeschiedenis_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", ParameterDirection.Input, InstantieID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Contract_i04<T>(ref int? p_identity, int? p_SjabloonAfspraakID, int? p_SubVersie, int? p_Versie) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_i04");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_identity", ParameterDirection.InputOutput, p_identity));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_SjabloonAfspraakID", ParameterDirection.Input, p_SjabloonAfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_SubVersie", ParameterDirection.Input, p_SubVersie));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Versie", ParameterDirection.Input, p_Versie));
			var result = _executor.Execute<T>(request);
			p_identity = (int?)request.GetParameterValue("@p_identity");
			return result;
		}

		public T csp_Validatie_VoluminaMoet0ZijnBijCodes16Of17_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_VoluminaMoet0ZijnBijCodes16Of17_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_VoluminaMoet0ZijnBijCodes16Of17_Solve<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_VoluminaMoet0ZijnBijCodes16Of17_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ImportContract8Data_u01<T>(int? p_AfspraakID, Guid p_StagingImportPrijslijstBatchToken) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ImportContract8Data_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", ParameterDirection.Input, p_AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_StagingImportPrijslijstBatchToken", ParameterDirection.Input, p_StagingImportPrijslijstBatchToken));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandenWerk_s01<T>(int? InvulKwartaal, string Segment, int? SjabloonJaar, int? ZVSID, int? ZVZID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandenWerk_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InvulKwartaal", ParameterDirection.Input, InvulKwartaal));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Segment", ParameterDirection.Input, Segment));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SjabloonJaar", ParameterDirection.Input, SjabloonJaar));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVSID", ParameterDirection.Input, ZVSID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVZID", ParameterDirection.Input, ZVZID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingPrestatie_u06<T>(int? AfspraakID, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodes, ref bool? OnderhandelingGewijzigd) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_u06");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@DeclaratieCodes", ParameterDirection.Input, "Overig", "udtVarCharTable", DeclaratieCodes));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandelingGewijzigd", ParameterDirection.InputOutput, OnderhandelingGewijzigd));
			var result = _executor.Execute<T>(request);
			OnderhandelingGewijzigd = (bool?)request.GetParameterValue("@OnderhandelingGewijzigd");
			return result;
		}

		public T csp_OnderhandenWerkSjabloon2010_s01<T>(int? InvulKwartaal, string Segment, int? SjabloonJaar, int? ZVSID, int? ZVZID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandenWerkSjabloon2010_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InvulKwartaal", ParameterDirection.Input, InvulKwartaal));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Segment", ParameterDirection.Input, Segment));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SjabloonJaar", ParameterDirection.Input, SjabloonJaar));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVSID", ParameterDirection.Input, ZVSID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVZID", ParameterDirection.Input, ZVZID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Sjabloon_i01<T>(string Code, string Omschrijving, ref int? SjabloonAfspraakID, string Username) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Sjabloon_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Code", ParameterDirection.Input, Code));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Omschrijving", ParameterDirection.Input, Omschrijving));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SjabloonAfspraakID", ParameterDirection.InputOutput, SjabloonAfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Username", ParameterDirection.Input, Username));
			var result = _executor.Execute<T>(request);
			SjabloonAfspraakID = (int?)request.GetParameterValue("@SjabloonAfspraakID");
			return result;
		}

		public T csp_OnderhandenWerkSjabloon2010_u01<T>(string Gebruiker, Guid ImportIdentifier, int? InvulKwartaal, string Segment, int? SjabloonJaar, string SjabloonVersie, int? ZVSID, int? ZVZID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandenWerkSjabloon2010_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Gebruiker", ParameterDirection.Input, Gebruiker));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ImportIdentifier", ParameterDirection.Input, ImportIdentifier));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InvulKwartaal", ParameterDirection.Input, InvulKwartaal));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Segment", ParameterDirection.Input, Segment));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SjabloonJaar", ParameterDirection.Input, SjabloonJaar));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SjabloonVersie", ParameterDirection.Input, SjabloonVersie));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVSID", ParameterDirection.Input, ZVSID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVZID", ParameterDirection.Input, ZVZID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Contract_s11<T>(int? CON_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_s11");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CON_ID", ParameterDirection.Input, CON_ID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Contract_s14<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_s14");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_ABSegmentZorgproductenPoorter_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_ABSegmentZorgproductenPoorter_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_Correcte17CodesAgisAchmeaComplement_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_Correcte17CodesAgisAchmeaComplement_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Contract_s15<T>(int? AnalyseRegioId, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodeList, int? GroepId, int? InstantieId, int? InstantieSoort, DateTime PeilDatum, int? ProvincieId, int? RegioId, string Segment, bool? ToonPassantenTarieven, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> ZorgProductList, int? ZorgverstrekkerId, int? ZorgverzekeraarId) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_s15");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AnalyseRegioId", ParameterDirection.Input, AnalyseRegioId));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@DeclaratieCodeList", ParameterDirection.Input, "Overig", "udtVarCharTable", DeclaratieCodeList));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GroepId", ParameterDirection.Input, GroepId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieId", ParameterDirection.Input, InstantieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieSoort", ParameterDirection.Input, InstantieSoort));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeilDatum", ParameterDirection.Input, PeilDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ProvincieId", ParameterDirection.Input, ProvincieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@RegioId", ParameterDirection.Input, RegioId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Segment", ParameterDirection.Input, Segment));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ToonPassantenTarieven", ParameterDirection.Input, ToonPassantenTarieven));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@ZorgProductList", ParameterDirection.Input, "Overig", "udtVarCharTable", ZorgProductList));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerId", ParameterDirection.Input, ZorgverstrekkerId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", ParameterDirection.Input, ZorgverzekeraarId));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_ABSegmentZorgproductenPoorter_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_ABSegmentZorgproductenPoorter_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", ParameterDirection.InputOutput, AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			AfspraakGewijzigd = (bool?)request.GetParameterValue("@AfspraakGewijzigd");
			return result;
		}

		public T csp_Validatie_OvernemenPrijzen17Pendant_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_OvernemenPrijzen17Pendant_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Contract_s13<T>(int? AfspraakID, int? AfspraakIDSjabloon, ref bool? Match) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_s13");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDSjabloon", ParameterDirection.Input, AfspraakIDSjabloon));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Match", ParameterDirection.InputOutput, Match));
			var result = _executor.Execute<T>(request);
			Match = (bool?)request.GetParameterValue("@Match");
			return result;
		}

		public T csp_ContractAfspraakBijlagen_s01<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ContractAfspraakBijlagen_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_OvernemenPrijzen17Pendant_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_OvernemenPrijzen17Pendant_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", ParameterDirection.InputOutput, AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			AfspraakGewijzigd = (bool?)request.GetParameterValue("@AfspraakGewijzigd");
			return result;
		}

		public T csp_OnderhandelingUitgangspositie_s01<T>(int? AfspraakID, int? InstantieID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingUitgangspositie_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", ParameterDirection.Input, InstantieID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Contract_s19<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_s19");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ContractExport_s01<T>(int? AfspraakID, bool? AlleTarieven, string ExportInhoud) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ContractExport_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AlleTarieven", ParameterDirection.Input, AlleTarieven));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ExportInhoud", ParameterDirection.Input, ExportInhoud));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_PassantenTarief_s01<T>(bool? ActiveOnly, int? AfspraakStijl, int? InstantieID, DateTime MaximumBegindatum, string segment) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_PassantenTarief_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ActiveOnly", ParameterDirection.Input, ActiveOnly));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakStijl", ParameterDirection.Input, AfspraakStijl));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", ParameterDirection.Input, InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@MaximumBegindatum", ParameterDirection.Input, MaximumBegindatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@segment", ParameterDirection.Input, segment));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ContractPrijslijst_s03<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ContractPrijslijst_s03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ImportOnderhandeling8Data_u01<T>(int? p_AfspraakID, string p_ImportInhoud, bool? p_ImportPrices, bool? p_ImportVolumes, Guid p_StagingImportPrijslijstBatchToken) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ImportOnderhandeling8Data_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", ParameterDirection.Input, p_AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ImportInhoud", ParameterDirection.Input, p_ImportInhoud));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ImportPrices", ParameterDirection.Input, p_ImportPrices));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ImportVolumes", ParameterDirection.Input, p_ImportVolumes));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_StagingImportPrijslijstBatchToken", ParameterDirection.Input, p_StagingImportPrijslijstBatchToken));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ModelContractExport_s01<T>(int? AfspraakID, bool? AlleTarieven, string ExportInhoud) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ModelContractExport_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AlleTarieven", ParameterDirection.Input, AlleTarieven));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ExportInhoud", ParameterDirection.Input, ExportInhoud));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Afspraak_s02<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Afspraak_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Sjabloon_s04<T>(int? AfspraakIDSjabloonNieuw, int? AfspraakIDSjabloonVorig, ref bool? Identiek) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Sjabloon_s04");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDSjabloonNieuw", ParameterDirection.Input, AfspraakIDSjabloonNieuw));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDSjabloonVorig", ParameterDirection.Input, AfspraakIDSjabloonVorig));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Identiek", ParameterDirection.InputOutput, Identiek));
			var result = _executor.Execute<T>(request);
			Identiek = (bool?)request.GetParameterValue("@Identiek");
			return result;
		}

		public T csp_Afspraak_s01<T>(int? InstantieID, int? ZVS_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Afspraak_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", ParameterDirection.Input, InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVS_ID", ParameterDirection.Input, ZVS_ID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Onderhandeling_i09<T>(int? AfspraakIDBlacklist, int? AfspraakIDSjabloon, int? AfspraakIDSpeerpunt, bool? AutomatischGestart, int? CPN_ZVS_ID, int? CPN_ZVZ_ID, DateTime EindDatum, int? INITIATOR, bool? IsPseudoOnderhandeling, ref int? NewAfspraakID, int? OnderhandelingUitgangspositieID, string SegmentCode, DateTime StartDatum, int? TariefType, string USERNAME, int? ZVS_ID, int? ZVZ_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_i09");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDBlacklist", ParameterDirection.Input, AfspraakIDBlacklist));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDSjabloon", ParameterDirection.Input, AfspraakIDSjabloon));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDSpeerpunt", ParameterDirection.Input, AfspraakIDSpeerpunt));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AutomatischGestart", ParameterDirection.Input, AutomatischGestart));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CPN_ZVS_ID", ParameterDirection.Input, CPN_ZVS_ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CPN_ZVZ_ID", ParameterDirection.Input, CPN_ZVZ_ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@EindDatum", ParameterDirection.Input, EindDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@INITIATOR", ParameterDirection.Input, INITIATOR));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@IsPseudoOnderhandeling", ParameterDirection.Input, IsPseudoOnderhandeling));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@NewAfspraakID", ParameterDirection.InputOutput, NewAfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandelingUitgangspositieID", ParameterDirection.Input, OnderhandelingUitgangspositieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SegmentCode", ParameterDirection.Input, SegmentCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@StartDatum", ParameterDirection.Input, StartDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@TariefType", ParameterDirection.Input, TariefType));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@USERNAME", ParameterDirection.Input, USERNAME));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVS_ID", ParameterDirection.Input, ZVS_ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVZ_ID", ParameterDirection.Input, ZVZ_ID));
			var result = _executor.Execute<T>(request);
			NewAfspraakID = (int?)request.GetParameterValue("@NewAfspraakID");
			return result;
		}

		public T csp_Afspraak_u05<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Afspraak_u05");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Contract_s07<T>(bool? ActiveOnly, int? AfspraakID, int? AfspraakStijl, bool? InclChildContracten, bool? InclPassantenTarieven, int? InstantieID, DateTime MaxBegindatum, DateTime MinBeginDatum, string Segment) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_s07");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ActiveOnly", ParameterDirection.Input, ActiveOnly));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakStijl", ParameterDirection.Input, AfspraakStijl));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InclChildContracten", ParameterDirection.Input, InclChildContracten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InclPassantenTarieven", ParameterDirection.Input, InclPassantenTarieven));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", ParameterDirection.Input, InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@MaxBegindatum", ParameterDirection.Input, MaxBegindatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@MinBeginDatum", ParameterDirection.Input, MinBeginDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Segment", ParameterDirection.Input, Segment));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Model_d01<T>(int? p_MDL_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Model_d01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_MDL_ID", ParameterDirection.Input, p_MDL_ID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Onderhandeling_u10<T>(int? p_AfspraakId, int? p_InstantieTypeID, string p_OnderhandelingOpmerking, string p_Username) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_u10");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakId", ParameterDirection.Input, p_AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieTypeID", ParameterDirection.Input, p_InstantieTypeID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingOpmerking", ParameterDirection.Input, p_OnderhandelingOpmerking));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Username", ParameterDirection.Input, p_Username));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Contract_i11<T>(ref int? AfspraakID, string AGBCode, DateTime BeginDatum, string CreateUser, DateTime EindDatum, string Omschrijving, IEnumerable<Database.UserDefinedTypes.Tarief.udtTariefPrijslijst> Prijslijst, string Segment, int? SjabloonAfspraakID, string UZOVI) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_i11");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.InputOutput, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AGBCode", ParameterDirection.Input, AGBCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BeginDatum", ParameterDirection.Input, BeginDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CreateUser", ParameterDirection.Input, CreateUser));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@EindDatum", ParameterDirection.Input, EindDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Omschrijving", ParameterDirection.Input, Omschrijving));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@Prijslijst", ParameterDirection.Input, "Tarief", "udtTariefPrijslijst", Prijslijst));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Segment", ParameterDirection.Input, Segment));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SjabloonAfspraakID", ParameterDirection.Input, SjabloonAfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@UZOVI", ParameterDirection.Input, UZOVI));
			var result = _executor.Execute<T>(request);
			AfspraakID = (int?)request.GetParameterValue("@AfspraakID");
			return result;
		}

		public T csp_PrestatieComponentModel_u01<T>(int? AfspraakID, int? p_MDLDBC_Aantal, decimal? p_MDLDBC_Specialisten, decimal? p_MDLDBC_Ziekenhuis, string p_username, int? PrestatieID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_PrestatieComponentModel_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_MDLDBC_Aantal", ParameterDirection.Input, p_MDLDBC_Aantal));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_MDLDBC_Specialisten", ParameterDirection.Input, p_MDLDBC_Specialisten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_MDLDBC_Ziekenhuis", ParameterDirection.Input, p_MDLDBC_Ziekenhuis));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_username", ParameterDirection.Input, p_username));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrestatieID", ParameterDirection.Input, PrestatieID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingExport_s01<T>(int? AfspraakID, bool? AlleTarieven, string ExportInhoud) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingExport_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AlleTarieven", ParameterDirection.Input, AlleTarieven));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ExportInhoud", ParameterDirection.Input, ExportInhoud));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Contract_s20<T>(int? AnalyseRegioId, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodeList, int? GroepId, int? InstantieId, int? InstantieSoort, DateTime PeilDatum, int? ProvincieId, int? RegioId, string Segment, bool? ToonPassantenTarieven, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> ZorgProductList, int? ZorgverstrekkerId, int? ZorgverzekeraarId) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_s20");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AnalyseRegioId", ParameterDirection.Input, AnalyseRegioId));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@DeclaratieCodeList", ParameterDirection.Input, "Overig", "udtVarCharTable", DeclaratieCodeList));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GroepId", ParameterDirection.Input, GroepId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieId", ParameterDirection.Input, InstantieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieSoort", ParameterDirection.Input, InstantieSoort));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeilDatum", ParameterDirection.Input, PeilDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ProvincieId", ParameterDirection.Input, ProvincieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@RegioId", ParameterDirection.Input, RegioId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Segment", ParameterDirection.Input, Segment));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ToonPassantenTarieven", ParameterDirection.Input, ToonPassantenTarieven));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@ZorgProductList", ParameterDirection.Input, "Overig", "udtVarCharTable", ZorgProductList));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerId", ParameterDirection.Input, ZorgverstrekkerId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", ParameterDirection.Input, ZorgverzekeraarId));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_PrestatieComponentModel_s01<T>(int? MDL_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_PrestatieComponentModel_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@MDL_ID", ParameterDirection.Input, MDL_ID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingGroepsIndeling_s01<T>(int? AfspraakID, int? InstantieID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingGroepsIndeling_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", ParameterDirection.Input, InstantieID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Contract_s21<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_s21");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_PrestatieComponentModel_d01<T>(int? p_MDL_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_PrestatieComponentModel_d01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_MDL_ID", ParameterDirection.Input, p_MDL_ID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingGroepsIndelingGroep_s01<T>(int? AfspraakID, int? GroepsIndelingID, int? VergelijkingID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingGroepsIndelingGroep_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GroepsIndelingID", ParameterDirection.Input, GroepsIndelingID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@VergelijkingID", ParameterDirection.Input, VergelijkingID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Onderhandeling_u08<T>(int? p_AfspraakId, string p_PrestatieFilterCode) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_u08");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakId", ParameterDirection.Input, p_AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_PrestatieFilterCode", ParameterDirection.Input, p_PrestatieFilterCode));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ModelContractExport_s02<T>(int? AfspraakID, bool? AlleTarieven) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ModelContractExport_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AlleTarieven", ParameterDirection.Input, AlleTarieven));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingAfspraakBijlage_s01<T>(int? CON_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingAfspraakBijlage_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CON_ID", ParameterDirection.Input, CON_ID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingGroepsIndelingGroep_s02<T>(int? AfspraakID, int? GroepsIndelingID, int? HoofdGroepID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingGroepsIndelingGroep_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GroepsIndelingID", ParameterDirection.Input, GroepsIndelingID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@HoofdGroepID", ParameterDirection.Input, HoofdGroepID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingPrestatie_d02<T>(int? AfspraakID, ref bool? OnderhandelingGewijzigd, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> PrestatieIds) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_d02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandelingGewijzigd", ParameterDirection.InputOutput, OnderhandelingGewijzigd));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@PrestatieIds", ParameterDirection.Input, "Overig", "udtIntTable", PrestatieIds));
			var result = _executor.Execute<T>(request);
			OnderhandelingGewijzigd = (bool?)request.GetParameterValue("@OnderhandelingGewijzigd");
			return result;
		}

		public T csp_OnderhandelingOpmerking_s01<T>(int? AfspraakID, int? InstantieTypeID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingOpmerking_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieTypeID", ParameterDirection.Input, InstantieTypeID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingPrestatie_u11<T>(int? AfspraakID, object AfwVolume, ref bool? OnderhandelingGewijzigd, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> PrestatieIds) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_u11");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwVolume", ParameterDirection.Input, AfwVolume));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandelingGewijzigd", ParameterDirection.InputOutput, OnderhandelingGewijzigd));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@PrestatieIds", ParameterDirection.Input, "Overig", "udtIntTable", PrestatieIds));
			var result = _executor.Execute<T>(request);
			OnderhandelingGewijzigd = (bool?)request.GetParameterValue("@OnderhandelingGewijzigd");
			return result;
		}

		public T csp_OnderhandelingPrestatie_s05<T>(int? AfspraakID, bool? AlleenIngesloten, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodes, string DeelVanOmschrijving, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> GroepFilter, int? GroepFilterType, bool? NegeerPrestatieFilter, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> ZorgproductCodes) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_s05");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AlleenIngesloten", ParameterDirection.Input, AlleenIngesloten));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@DeclaratieCodes", ParameterDirection.Input, "Overig", "udtVarCharTable", DeclaratieCodes));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DeelVanOmschrijving", ParameterDirection.Input, DeelVanOmschrijving));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@GroepFilter", ParameterDirection.Input, "Overig", "udtIntTable", GroepFilter));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GroepFilterType", ParameterDirection.Input, GroepFilterType));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@NegeerPrestatieFilter", ParameterDirection.Input, NegeerPrestatieFilter));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@ZorgproductCodes", ParameterDirection.Input, "Overig", "udtVarCharTable", ZorgproductCodes));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_1416GelijkIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_1416GelijkIntegraal_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_HonorariumComponent_s01<T>(int? AfspraakID, int? PrestatieID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_HonorariumComponent_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrestatieID", ParameterDirection.Input, PrestatieID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_1416GelijkIntegraal_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_1416GelijkIntegraal_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", ParameterDirection.InputOutput, AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			AfspraakGewijzigd = (bool?)request.GetParameterValue("@AfspraakGewijzigd");
			return result;
		}

		public T csp_OnderhandelingPrestatie_u04<T>(int? AfspraakID, int? AfwBasis, object AfwHon0303, object AfwHon0307, object AfwHon0313, object AfwHon0316, object AfwHon0318, object AfwHon0320, object AfwHon0322, object AfwHon0330, object AfwHon0361, object AfwHon0362, object AfwHon0363, object AfwHon0386, object AfwHon0387, object AfwHon0388, object AfwHon0389, object AfwHonNietOndh, object AfwHonOndh, object AfwHonOverig, object AfwZKH, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodes, int? GroepId, ref bool? OnderhandelingGewijzigd) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_u04");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwBasis", ParameterDirection.Input, AfwBasis));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwHon0303", ParameterDirection.Input, AfwHon0303));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwHon0307", ParameterDirection.Input, AfwHon0307));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwHon0313", ParameterDirection.Input, AfwHon0313));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwHon0316", ParameterDirection.Input, AfwHon0316));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwHon0318", ParameterDirection.Input, AfwHon0318));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwHon0320", ParameterDirection.Input, AfwHon0320));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwHon0322", ParameterDirection.Input, AfwHon0322));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwHon0330", ParameterDirection.Input, AfwHon0330));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwHon0361", ParameterDirection.Input, AfwHon0361));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwHon0362", ParameterDirection.Input, AfwHon0362));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwHon0363", ParameterDirection.Input, AfwHon0363));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwHon0386", ParameterDirection.Input, AfwHon0386));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwHon0387", ParameterDirection.Input, AfwHon0387));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwHon0388", ParameterDirection.Input, AfwHon0388));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwHon0389", ParameterDirection.Input, AfwHon0389));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwHonNietOndh", ParameterDirection.Input, AfwHonNietOndh));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwHonOndh", ParameterDirection.Input, AfwHonOndh));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwHonOverig", ParameterDirection.Input, AfwHonOverig));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwZKH", ParameterDirection.Input, AfwZKH));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@DeclaratieCodes", ParameterDirection.Input, "Overig", "udtVarCharTable", DeclaratieCodes));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GroepId", ParameterDirection.Input, GroepId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandelingGewijzigd", ParameterDirection.InputOutput, OnderhandelingGewijzigd));
			var result = _executor.Execute<T>(request);
			OnderhandelingGewijzigd = (bool?)request.GetParameterValue("@OnderhandelingGewijzigd");
			return result;
		}

		public T csp_Validatie_1517GelijkIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_1517GelijkIntegraal_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_HonorariumComponent_s03<T>(int? AfspraakID, int? InstantieID, int? PrestatieID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_HonorariumComponent_s03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", ParameterDirection.Input, InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrestatieID", ParameterDirection.Input, PrestatieID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingPrestatie_u05<T>(int? AfspraakID, ref bool? OnderhandelingGewijzigd) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_u05");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandelingGewijzigd", ParameterDirection.InputOutput, OnderhandelingGewijzigd));
			var result = _executor.Execute<T>(request);
			OnderhandelingGewijzigd = (bool?)request.GetParameterValue("@OnderhandelingGewijzigd");
			return result;
		}

		public T csp_Validatie_1517GelijkIntegraal_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_1517GelijkIntegraal_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", ParameterDirection.InputOutput, AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			AfspraakGewijzigd = (bool?)request.GetParameterValue("@AfspraakGewijzigd");
			return result;
		}

		public T csp_Validatie_Geen16CodesIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_Geen16CodesIntegraal_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingPrestatieTariefSoort_s01<T>(int? AfspraakID, string DeclaratieCode) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatieTariefSoort_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DeclaratieCode", ParameterDirection.Input, DeclaratieCode));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ContractControleBestaandContractImportTool_s02<T>(string AGB, string AGBSoort, DateTime BeginDatum, ref bool? BestaandContract, DateTime EindDatum, string UZOVI) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ContractControleBestaandContractImportTool_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AGB", ParameterDirection.Input, AGB));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AGBSoort", ParameterDirection.Input, AGBSoort));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BeginDatum", ParameterDirection.Input, BeginDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BestaandContract", ParameterDirection.InputOutput, BestaandContract));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@EindDatum", ParameterDirection.Input, EindDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@UZOVI", ParameterDirection.Input, UZOVI));
			var result = _executor.Execute<T>(request);
			BestaandContract = (bool?)request.GetParameterValue("@BestaandContract");
			return result;
		}

		public T csp_Validatie_Geen16CodesIntegraal_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_Geen16CodesIntegraal_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", ParameterDirection.InputOutput, AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			AfspraakGewijzigd = (bool?)request.GetParameterValue("@AfspraakGewijzigd");
			return result;
		}

		public T csp_PassantenTarief_d01<T>(int? CON_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_PassantenTarief_d01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CON_ID", ParameterDirection.Input, CON_ID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingPrestatieToelichting_d01<T>(int? AfspraakID, string DeclaratieCode) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatieToelichting_d01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DeclaratieCode", ParameterDirection.Input, DeclaratieCode));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_GeenOnverzekerdeZorgIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_GeenOnverzekerdeZorgIntegraal_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingPrestatieToelichting_s01<T>(int? AfspraakID, string DeclaratieCode, ref string Toelichting) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatieToelichting_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DeclaratieCode", ParameterDirection.Input, DeclaratieCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Toelichting", ParameterDirection.InputOutput, Toelichting));
			var result = _executor.Execute<T>(request);
			Toelichting = (string)request.GetParameterValue("@Toelichting");
			return result;
		}

		public T csp_Validatie_GeenOnverzekerdeZorgIntegraal_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_GeenOnverzekerdeZorgIntegraal_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", ParameterDirection.InputOutput, AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			AfspraakGewijzigd = (bool?)request.GetParameterValue("@AfspraakGewijzigd");
			return result;
		}

		public T csp_OnderhandelingPrestatieToelichting_u01<T>(int? AfspraakID, string DeclaratieCode, string Toelichting) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatieToelichting_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DeclaratieCode", ParameterDirection.Input, DeclaratieCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Toelichting", ParameterDirection.Input, Toelichting));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_MaxTariefTotaalIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_MaxTariefTotaalIntegraal_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ContractPrijslijst_s04<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ContractPrijslijst_s04");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingUitgangspositie_i02<T>(int? AfspraakIDBlacklist, int? AfspraakIDContract, int? AfspraakIDModel, int? AfspraakIDSjabloon, int? AfspraakIDSpeerpunt, int? AfspraakIDVolumeContract, int? AfspraakIDVolumeModel, ref int? NewUitgangspositieID, bool? TotaalprijsGelijk, string Username) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingUitgangspositie_i02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDBlacklist", ParameterDirection.Input, AfspraakIDBlacklist));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDContract", ParameterDirection.Input, AfspraakIDContract));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDModel", ParameterDirection.Input, AfspraakIDModel));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDSjabloon", ParameterDirection.Input, AfspraakIDSjabloon));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDSpeerpunt", ParameterDirection.Input, AfspraakIDSpeerpunt));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDVolumeContract", ParameterDirection.Input, AfspraakIDVolumeContract));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDVolumeModel", ParameterDirection.Input, AfspraakIDVolumeModel));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@NewUitgangspositieID", ParameterDirection.InputOutput, NewUitgangspositieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@TotaalprijsGelijk", ParameterDirection.Input, TotaalprijsGelijk));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Username", ParameterDirection.Input, Username));
			var result = _executor.Execute<T>(request);
			NewUitgangspositieID = (int?)request.GetParameterValue("@NewUitgangspositieID");
			return result;
		}

		public T csp_Validatie_MaxTariefTotaalIntegraal_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_MaxTariefTotaalIntegraal_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", ParameterDirection.InputOutput, AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			AfspraakGewijzigd = (bool?)request.GetParameterValue("@AfspraakGewijzigd");
			return result;
		}

		public T csp_OnderhandelingPrijslijst_s02<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrijslijst_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_PrestatieComponentPassantenTarief_i02<T>(int? p_CON_ID, int? p_CONDBC_Aantal, decimal? p_CONDBC_Specialisten, decimal? p_CONDBC_Ziekenhuis, int? p_DBC_ID, string p_status, string p_username) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_PrestatieComponentPassantenTarief_i02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_CON_ID", ParameterDirection.Input, p_CON_ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_CONDBC_Aantal", ParameterDirection.Input, p_CONDBC_Aantal));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_CONDBC_Specialisten", ParameterDirection.Input, p_CONDBC_Specialisten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_CONDBC_Ziekenhuis", ParameterDirection.Input, p_CONDBC_Ziekenhuis));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_DBC_ID", ParameterDirection.Input, p_DBC_ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_status", ParameterDirection.Input, p_status));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_username", ParameterDirection.Input, p_username));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_PrestatiesVallenBinnenSjabloonRegel_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_PrestatiesVallenBinnenSjabloonRegel_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_TariefSoortInfo_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_TariefSoortInfo_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_NegatieveTarievenIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_NegatieveTarievenIntegraal_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_PrestatieBinnenGrijzeLijst_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_PrestatieBinnenGrijzeLijst_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_TariefSoortInfo_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_TariefSoortInfo_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", ParameterDirection.InputOutput, AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			AfspraakGewijzigd = (bool?)request.GetParameterValue("@AfspraakGewijzigd");
			return result;
		}

		public T csp_Validatie_OnderhandelingBinnenSjabloon_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_OnderhandelingBinnenSjabloon_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_OvernemenPrijzen16PendantIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_OvernemenPrijzen16PendantIntegraal_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_PrestatiesOpGrijzeEnZwarteLijst_d01<T>(int? AfspraakId) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_PrestatiesOpGrijzeEnZwarteLijst_d01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakId", ParameterDirection.Input, AfspraakId));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Contract_d01<T>(int? p_CON_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_d01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_CON_ID", ParameterDirection.Input, p_CON_ID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_PrestatieBinnenGrijzeLijst_Solve<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_PrestatieBinnenGrijzeLijst_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_OvernemenPrijzen16PendantIntegraal_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_OvernemenPrijzen16PendantIntegraal_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", ParameterDirection.InputOutput, AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			AfspraakGewijzigd = (bool?)request.GetParameterValue("@AfspraakGewijzigd");
			return result;
		}

		public T csp_Validatie_OvernemenPrijzen17PendantIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_OvernemenPrijzen17PendantIntegraal_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingAfspraakBijlage_i01<T>(int? CON_ID, ref Guid ExtID, string FileName, ref int? ID, string ToegevoegdDoor, int? Type_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingAfspraakBijlage_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CON_ID", ParameterDirection.Input, CON_ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ExtID", ParameterDirection.InputOutput, ExtID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@FileName", ParameterDirection.Input, FileName));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ID", ParameterDirection.InputOutput, ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ToegevoegdDoor", ParameterDirection.Input, ToegevoegdDoor));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Type_ID", ParameterDirection.Input, Type_ID));
			var result = _executor.Execute<T>(request);
			ExtID = (Guid)request.GetParameterValue("@ExtID");
			ID = (int?)request.GetParameterValue("@ID");
			return result;
		}

		public T csp_Validatie_OvernemenPrijzen17PendantIntegraal_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_OvernemenPrijzen17PendantIntegraal_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", ParameterDirection.InputOutput, AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			AfspraakGewijzigd = (bool?)request.GetParameterValue("@AfspraakGewijzigd");
			return result;
		}

		public T csp_OnderhandelingAfspraakBijlage_d01<T>(int? ID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingAfspraakBijlage_d01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ID", ParameterDirection.Input, ID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_PrestatieBinnenGrijzeLijstIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_PrestatieBinnenGrijzeLijstIntegraal_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_PrestatiesOpGrijzeEnZwarteLijst_i01<T>(int? AfspraakId) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_PrestatiesOpGrijzeEnZwarteLijst_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakId", ParameterDirection.Input, AfspraakId));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_PrestatieBinnenGrijzeLijstIntegraal_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_PrestatieBinnenGrijzeLijstIntegraal_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", ParameterDirection.InputOutput, AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			AfspraakGewijzigd = (bool?)request.GetParameterValue("@AfspraakGewijzigd");
			return result;
		}

		public T csp_Validatie_TariefSoortInfoIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_TariefSoortInfoIntegraal_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_TotaalHogerDanPassantenIntegraal_Check<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_TotaalHogerDanPassantenIntegraal_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", ParameterDirection.InputOutput, AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			AfspraakGewijzigd = (bool?)request.GetParameterValue("@AfspraakGewijzigd");
			return result;
		}

		public T csp_Validatie_TotaalHogerDanPassantenIntegraal_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_TotaalHogerDanPassantenIntegraal_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", ParameterDirection.InputOutput, AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			AfspraakGewijzigd = (bool?)request.GetParameterValue("@AfspraakGewijzigd");
			return result;
		}

		public T csp_OnderhandelingPrestatie_d01<T>(int? AfspraakID, ref bool? OnderhandelingGewijzigd, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> PrestatieIds) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_d01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandelingGewijzigd", ParameterDirection.InputOutput, OnderhandelingGewijzigd));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@PrestatieIds", ParameterDirection.Input, "Overig", "udtIntTable", PrestatieIds));
			var result = _executor.Execute<T>(request);
			OnderhandelingGewijzigd = (bool?)request.GetParameterValue("@OnderhandelingGewijzigd");
			return result;
		}

		public T csp_contract_i07<T>(int? p_AfspraakID, ref int? p_AfspraakIDContract, bool? p_AutomatischGeaccordeerd, ref int? p_ContractAfspraakID, string p_UserName) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_contract_i07");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", ParameterDirection.Input, p_AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakIDContract", ParameterDirection.InputOutput, p_AfspraakIDContract));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AutomatischGeaccordeerd", ParameterDirection.Input, p_AutomatischGeaccordeerd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ContractAfspraakID", ParameterDirection.InputOutput, p_ContractAfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_UserName", ParameterDirection.Input, p_UserName));
			var result = _executor.Execute<T>(request);
			p_AfspraakIDContract = (int?)request.GetParameterValue("@p_AfspraakIDContract");
			p_ContractAfspraakID = (int?)request.GetParameterValue("@p_ContractAfspraakID");
			return result;
		}

		public T csp_Validatie_VoluminaMoet0ZijnBijCodes16Of17Integraal_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_VoluminaMoet0ZijnBijCodes16Of17Integraal_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingPrestatie_u07<T>(int? AfspraakID, object AfwVolume, ref bool? OnderhandelingGewijzigd, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> PrestatieIds) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_u07");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwVolume", ParameterDirection.Input, AfwVolume));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandelingGewijzigd", ParameterDirection.InputOutput, OnderhandelingGewijzigd));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@PrestatieIds", ParameterDirection.Input, "Overig", "udtIntTable", PrestatieIds));
			var result = _executor.Execute<T>(request);
			OnderhandelingGewijzigd = (bool?)request.GetParameterValue("@OnderhandelingGewijzigd");
			return result;
		}

		public T csp_Onderhandeling_d01<T>(int? CON_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_d01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CON_ID", ParameterDirection.Input, CON_ID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_contract_i08<T>(int? p_AfspraakID, ref int? p_AfspraakIDContract, bool? p_AutomatischGeaccordeerd, string p_UserName) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_contract_i08");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", ParameterDirection.Input, p_AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakIDContract", ParameterDirection.InputOutput, p_AfspraakIDContract));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AutomatischGeaccordeerd", ParameterDirection.Input, p_AutomatischGeaccordeerd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_UserName", ParameterDirection.Input, p_UserName));
			var result = _executor.Execute<T>(request);
			p_AfspraakIDContract = (int?)request.GetParameterValue("@p_AfspraakIDContract");
			return result;
		}

		public T csp_Validatie_VoluminaMoet0ZijnBijCodes16Of17Integraal_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_VoluminaMoet0ZijnBijCodes16Of17Integraal_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", ParameterDirection.InputOutput, AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			AfspraakGewijzigd = (bool?)request.GetParameterValue("@AfspraakGewijzigd");
			return result;
		}

		public T csp_Contract_i09<T>(ref int? AfspraakID, string AGBCode, DateTime BeginDatum, ref int? ContractAfspraakID, string CreateUser, DateTime EindDatum, int? InstantieSubType, string Omschrijving, int? SjabloonAfspraakID, string UZOVI) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_i09");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.InputOutput, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AGBCode", ParameterDirection.Input, AGBCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BeginDatum", ParameterDirection.Input, BeginDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ContractAfspraakID", ParameterDirection.InputOutput, ContractAfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CreateUser", ParameterDirection.Input, CreateUser));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@EindDatum", ParameterDirection.Input, EindDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieSubType", ParameterDirection.Input, InstantieSubType));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Omschrijving", ParameterDirection.Input, Omschrijving));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SjabloonAfspraakID", ParameterDirection.Input, SjabloonAfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@UZOVI", ParameterDirection.Input, UZOVI));
			var result = _executor.Execute<T>(request);
			AfspraakID = (int?)request.GetParameterValue("@AfspraakID");
			ContractAfspraakID = (int?)request.GetParameterValue("@ContractAfspraakID");
			return result;
		}

		public T csp_Validatie_ZwarteLijstBlokkerendIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_ZwarteLijstBlokkerendIntegraal_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Onderhandeling_s04<T>(int? CON_ORIG_ID, int? INITIATOR) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_s04");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CON_ORIG_ID", ParameterDirection.Input, CON_ORIG_ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@INITIATOR", ParameterDirection.Input, INITIATOR));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Contract_s18<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_s18");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_ZwarteLijstWaarschuwendIntegraal_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_ZwarteLijstWaarschuwendIntegraal_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Onderhandeling_s05<T>(int? CON_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_s05");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CON_ID", ParameterDirection.Input, CON_ID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ContractControleBestaandContract_s03<T>(int? AfspraakID, ref bool? BestaandContract) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ContractControleBestaandContract_s03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BestaandContract", ParameterDirection.InputOutput, BestaandContract));
			var result = _executor.Execute<T>(request);
			BestaandContract = (bool?)request.GetParameterValue("@BestaandContract");
			return result;
		}

		public T csp_Onderhandeling_u01<T>(DateTime BeginDatum, int? CON_ID, int? ContactPersoonZVSID, int? ContactPersoonZVZID, DateTime EindDatum, bool? HasUpdates, string Omschrijving, string RefZVS, string RefZVZ, string UpdateUser) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BeginDatum", ParameterDirection.Input, BeginDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CON_ID", ParameterDirection.Input, CON_ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ContactPersoonZVSID", ParameterDirection.Input, ContactPersoonZVSID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ContactPersoonZVZID", ParameterDirection.Input, ContactPersoonZVZID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@EindDatum", ParameterDirection.Input, EindDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@HasUpdates", ParameterDirection.Input, HasUpdates));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Omschrijving", ParameterDirection.Input, Omschrijving));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@RefZVS", ParameterDirection.Input, RefZVS));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@RefZVZ", ParameterDirection.Input, RefZVZ));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@UpdateUser", ParameterDirection.Input, UpdateUser));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ContractPrijslijst_i09<T>(int? AfspraakID, IEnumerable<Database.UserDefinedTypes.Afspraak.udt_GGZPrijslijstTable> PrestatiePrijslijst) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ContractPrijslijst_i09");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@PrestatiePrijslijst", ParameterDirection.Input, "Afspraak", "udt_GGZPrijslijstTable", PrestatiePrijslijst));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Onderhandeling_s00<T>(int? CON_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_s00");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CON_ID", ParameterDirection.Input, CON_ID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_GGZContractPrestatie_s01<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_GGZContractPrestatie_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_GGZOnderhandelingPrestatie_i01<T>(int? AfspraakID, IEnumerable<Database.UserDefinedTypes.Afspraak.udt_GGZPrijslijstTable> PrestatiePrijslijst) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_GGZOnderhandelingPrestatie_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@PrestatiePrijslijst", ParameterDirection.Input, "Afspraak", "udt_GGZPrijslijstTable", PrestatiePrijslijst));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_GrijzeLijst_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_GrijzeLijst_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_GGZOnderhandelingPrestatie_s01<T>(int? AfspraakID, bool? AlleenIngesloten, int? PrestatieTypeID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_GGZOnderhandelingPrestatie_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AlleenIngesloten", ParameterDirection.Input, AlleenIngesloten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrestatieTypeID", ParameterDirection.Input, PrestatieTypeID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_ZwarteLijstBlokkerend_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_ZwarteLijstBlokkerend_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Onderhandeling_i11<T>(int? p_AfspraakID_From, string p_bevestigingsTekst, ref int? p_InstantieAanZet, ref int? p_NewId, ref Guid p_NewVersieID, ref int? p_OnderhandelingAfspraakID, string p_UserName, string p_VoorgesteldDoor, ref int? p_ZorgSoort) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_i11");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID_From", ParameterDirection.Input, p_AfspraakID_From));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_bevestigingsTekst", ParameterDirection.Input, p_bevestigingsTekst));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieAanZet", ParameterDirection.InputOutput, p_InstantieAanZet));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_NewId", ParameterDirection.InputOutput, p_NewId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_NewVersieID", ParameterDirection.InputOutput, p_NewVersieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingAfspraakID", ParameterDirection.InputOutput, p_OnderhandelingAfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_UserName", ParameterDirection.Input, p_UserName));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VoorgesteldDoor", ParameterDirection.Input, p_VoorgesteldDoor));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ZorgSoort", ParameterDirection.InputOutput, p_ZorgSoort));
			var result = _executor.Execute<T>(request);
			p_InstantieAanZet = (int?)request.GetParameterValue("@p_InstantieAanZet");
			p_NewId = (int?)request.GetParameterValue("@p_NewId");
			p_NewVersieID = (Guid)request.GetParameterValue("@p_NewVersieID");
			p_OnderhandelingAfspraakID = (int?)request.GetParameterValue("@p_OnderhandelingAfspraakID");
			p_ZorgSoort = (int?)request.GetParameterValue("@p_ZorgSoort");
			return result;
		}

		public T csp_Validatie_ZwarteLijstBlokkerend_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_ZwarteLijstBlokkerend_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", ParameterDirection.InputOutput, AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			AfspraakGewijzigd = (bool?)request.GetParameterValue("@AfspraakGewijzigd");
			return result;
		}

		public T csp_Onderhandeling_i12<T>(int? p_AfspraakID_From, ref int? p_AfspraakIDVorigeVersie, string p_bevestigingsTekst, ref int? p_InstantieAanZet, ref int? p_newId, ref Guid p_NewVersieID, ref int? p_OnderhandelingAfspraakID, string p_UserName) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_i12");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID_From", ParameterDirection.Input, p_AfspraakID_From));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakIDVorigeVersie", ParameterDirection.InputOutput, p_AfspraakIDVorigeVersie));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_bevestigingsTekst", ParameterDirection.Input, p_bevestigingsTekst));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieAanZet", ParameterDirection.InputOutput, p_InstantieAanZet));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_newId", ParameterDirection.InputOutput, p_newId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_NewVersieID", ParameterDirection.InputOutput, p_NewVersieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingAfspraakID", ParameterDirection.InputOutput, p_OnderhandelingAfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_UserName", ParameterDirection.Input, p_UserName));
			var result = _executor.Execute<T>(request);
			p_AfspraakIDVorigeVersie = (int?)request.GetParameterValue("@p_AfspraakIDVorigeVersie");
			p_InstantieAanZet = (int?)request.GetParameterValue("@p_InstantieAanZet");
			p_newId = (int?)request.GetParameterValue("@p_newId");
			p_NewVersieID = (Guid)request.GetParameterValue("@p_NewVersieID");
			p_OnderhandelingAfspraakID = (int?)request.GetParameterValue("@p_OnderhandelingAfspraakID");
			return result;
		}

		public T csp_OnderhandelingPrestatie_u10<T>(int? AfspraakID, object Afw, int? AfwBasis, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodes, ref bool? OnderhandelingGewijzigd) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_u10");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Afw", ParameterDirection.Input, Afw));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfwBasis", ParameterDirection.Input, AfwBasis));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@DeclaratieCodes", ParameterDirection.Input, "Overig", "udtVarCharTable", DeclaratieCodes));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandelingGewijzigd", ParameterDirection.InputOutput, OnderhandelingGewijzigd));
			var result = _executor.Execute<T>(request);
			OnderhandelingGewijzigd = (bool?)request.GetParameterValue("@OnderhandelingGewijzigd");
			return result;
		}

		public T csp_Validatie_ZwarteLijstWaarschuwend_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_ZwarteLijstWaarschuwend_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_onderhandeling_i13<T>(int? p_AfspraakID_From, string p_bevestigingsTekst, ref int? p_InstantieAanZet, int? p_InstantieId, ref int? p_NewId, ref Guid p_NewVersieID, string p_Username, string p_VoorgesteldDoor) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_onderhandeling_i13");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID_From", ParameterDirection.Input, p_AfspraakID_From));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_bevestigingsTekst", ParameterDirection.Input, p_bevestigingsTekst));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieAanZet", ParameterDirection.InputOutput, p_InstantieAanZet));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieId", ParameterDirection.Input, p_InstantieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_NewId", ParameterDirection.InputOutput, p_NewId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_NewVersieID", ParameterDirection.InputOutput, p_NewVersieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Username", ParameterDirection.Input, p_Username));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VoorgesteldDoor", ParameterDirection.Input, p_VoorgesteldDoor));
			var result = _executor.Execute<T>(request);
			p_InstantieAanZet = (int?)request.GetParameterValue("@p_InstantieAanZet");
			p_NewId = (int?)request.GetParameterValue("@p_NewId");
			p_NewVersieID = (Guid)request.GetParameterValue("@p_NewVersieID");
			return result;
		}

		public T csp_Validatie_TariefSoortInfoIntegraal_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_TariefSoortInfoIntegraal_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", ParameterDirection.InputOutput, AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			AfspraakGewijzigd = (bool?)request.GetParameterValue("@AfspraakGewijzigd");
			return result;
		}

		public T csp_Validatie_ZwarteLijstWaarschuwend_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_ZwarteLijstWaarschuwend_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", ParameterDirection.InputOutput, AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			AfspraakGewijzigd = (bool?)request.GetParameterValue("@AfspraakGewijzigd");
			return result;
		}

		public T csp_Model_s02<T>(int? MDL_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Model_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@MDL_ID", ParameterDirection.Input, MDL_ID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Onderhandeling_i14<T>(int? p_AfspraakID_From, string p_bevestigingsTekst, ref int? p_InstantieAanZet, int? p_InstantieId, ref int? p_newId, ref Guid p_NewVersieID, string p_Username) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_i14");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID_From", ParameterDirection.Input, p_AfspraakID_From));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_bevestigingsTekst", ParameterDirection.Input, p_bevestigingsTekst));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieAanZet", ParameterDirection.InputOutput, p_InstantieAanZet));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieId", ParameterDirection.Input, p_InstantieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_newId", ParameterDirection.InputOutput, p_newId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_NewVersieID", ParameterDirection.InputOutput, p_NewVersieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Username", ParameterDirection.Input, p_Username));
			var result = _executor.Execute<T>(request);
			p_InstantieAanZet = (int?)request.GetParameterValue("@p_InstantieAanZet");
			p_newId = (int?)request.GetParameterValue("@p_newId");
			p_NewVersieID = (Guid)request.GetParameterValue("@p_NewVersieID");
			return result;
		}

		public T csp_Validatie_ZwarteLijstBlokkerendIntegraal_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_ZwarteLijstBlokkerendIntegraal_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", ParameterDirection.InputOutput, AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			AfspraakGewijzigd = (bool?)request.GetParameterValue("@AfspraakGewijzigd");
			return result;
		}

		public T csp_Model_u01<T>(string p_MDL_Code, int? p_MDL_ID, string p_MDL_Omschrijving, string p_username) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Model_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_MDL_Code", ParameterDirection.Input, p_MDL_Code));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_MDL_ID", ParameterDirection.Input, p_MDL_ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_MDL_Omschrijving", ParameterDirection.Input, p_MDL_Omschrijving));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_username", ParameterDirection.Input, p_username));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Onderhandeling_u14<T>(int? p_AfspraakId, ref int? p_OnderhandelingAfspraakID_HuidigeVersie, ref int? p_onderhandelingAfspraakID_VorigeVersie, string p_UserName) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_u14");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakId", ParameterDirection.Input, p_AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingAfspraakID_HuidigeVersie", ParameterDirection.InputOutput, p_OnderhandelingAfspraakID_HuidigeVersie));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_onderhandelingAfspraakID_VorigeVersie", ParameterDirection.InputOutput, p_onderhandelingAfspraakID_VorigeVersie));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_UserName", ParameterDirection.Input, p_UserName));
			var result = _executor.Execute<T>(request);
			p_OnderhandelingAfspraakID_HuidigeVersie = (int?)request.GetParameterValue("@p_OnderhandelingAfspraakID_HuidigeVersie");
			p_onderhandelingAfspraakID_VorigeVersie = (int?)request.GetParameterValue("@p_onderhandelingAfspraakID_VorigeVersie");
			return result;
		}

		public T csp_Validatie_ZwarteLijstWaarschuwendIntegraal_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_ZwarteLijstWaarschuwendIntegraal_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", ParameterDirection.InputOutput, AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			AfspraakGewijzigd = (bool?)request.GetParameterValue("@AfspraakGewijzigd");
			return result;
		}

		public T csp_Model_i01<T>(ref int? p_identity, string p_MDL_Code, string p_MDL_Omschrijving, string p_username, int? p_ZorgverstrekkerID, int? p_ZorgverzekeraarID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Model_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_identity", ParameterDirection.InputOutput, p_identity));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_MDL_Code", ParameterDirection.Input, p_MDL_Code));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_MDL_Omschrijving", ParameterDirection.Input, p_MDL_Omschrijving));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_username", ParameterDirection.Input, p_username));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ZorgverstrekkerID", ParameterDirection.Input, p_ZorgverstrekkerID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ZorgverzekeraarID", ParameterDirection.Input, p_ZorgverzekeraarID));
			var result = _executor.Execute<T>(request);
			p_identity = (int?)request.GetParameterValue("@p_identity");
			return result;
		}

		public T csp_Onderhandeling_u15<T>(int? p_AfspraakId, int? p_InstantieId, string p_UserName) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_u15");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakId", ParameterDirection.Input, p_AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieId", ParameterDirection.Input, p_InstantieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_UserName", ParameterDirection.Input, p_UserName));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Model_s01<T>(int? AfspraakStijl, DateTime BeginDatum, DateTime EindDatum, int? InstantieID, string Segment) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Model_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakStijl", ParameterDirection.Input, AfspraakStijl));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BeginDatum", ParameterDirection.Input, BeginDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@EindDatum", ParameterDirection.Input, EindDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", ParameterDirection.Input, InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Segment", ParameterDirection.Input, Segment));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_GeenOnverzekerdeZorg_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_GeenOnverzekerdeZorg_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_GeenOnverzekerdeZorg_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_GeenOnverzekerdeZorg_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", ParameterDirection.InputOutput, AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			AfspraakGewijzigd = (bool?)request.GetParameterValue("@AfspraakGewijzigd");
			return result;
		}

		public T csp_Validatie_CompleetheidInkoopAgisAchmea_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_CompleetheidInkoopAgisAchmea_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Sjabloon_s01<T>(string segment, int? ZorgSoort) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Sjabloon_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@segment", ParameterDirection.Input, segment));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgSoort", ParameterDirection.Input, ZorgSoort));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_GGZMutatieTarieven_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_GGZMutatieTarieven_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_GGZSjabloonMaxTarieven_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_GGZSjabloonMaxTarieven_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_ModelContractAanwezig_Check<T>(int? AfspraakID, ref int? ModelAfspraakID, ref string ModelContractCode, string ModelContractCodePrefix, ref int? OnderhandelingAfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_ModelContractAanwezig_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ModelAfspraakID", ParameterDirection.InputOutput, ModelAfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ModelContractCode", ParameterDirection.InputOutput, ModelContractCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ModelContractCodePrefix", ParameterDirection.Input, ModelContractCodePrefix));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandelingAfspraakID", ParameterDirection.InputOutput, OnderhandelingAfspraakID));
			var result = _executor.Execute<T>(request);
			ModelAfspraakID = (int?)request.GetParameterValue("@ModelAfspraakID");
			ModelContractCode = (string)request.GetParameterValue("@ModelContractCode");
			OnderhandelingAfspraakID = (int?)request.GetParameterValue("@OnderhandelingAfspraakID");
			return result;
		}

		public T csp_Validatie_MarktTariefHonorarium_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_MarktTariefHonorarium_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_MarktTariefKosten_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_MarktTariefKosten_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_MaxTariefHonorarium_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_MaxTariefHonorarium_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_MaxTariefHonorarium_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_MaxTariefHonorarium_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", ParameterDirection.InputOutput, AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			AfspraakGewijzigd = (bool?)request.GetParameterValue("@AfspraakGewijzigd");
			return result;
		}

		public T csp_Validatie_MaxTariefKosten_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_MaxTariefKosten_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Afspraak_u01<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Afspraak_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_MaxTariefKosten_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_MaxTariefKosten_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", ParameterDirection.InputOutput, AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			AfspraakGewijzigd = (bool?)request.GetParameterValue("@AfspraakGewijzigd");
			return result;
		}

		public T csp_HonorariumComponentPassantenTarief_i01<T>(int? AfspraakID, decimal? Kosten, int? PrestatieID, string SpecialismeCode, string Username) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_HonorariumComponentPassantenTarief_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Kosten", ParameterDirection.Input, Kosten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrestatieID", ParameterDirection.Input, PrestatieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SpecialismeCode", ParameterDirection.Input, SpecialismeCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Username", ParameterDirection.Input, Username));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_MaxTariefTotaal_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_MaxTariefTotaal_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Onderhandeling_u11<T>(int? p_AfspraakId, string p_bevestigingsTekst, string p_GewijzigdDoor, int? p_NewAkkoordStatus, string p_UserName) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_u11");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakId", ParameterDirection.Input, p_AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_bevestigingsTekst", ParameterDirection.Input, p_bevestigingsTekst));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_GewijzigdDoor", ParameterDirection.Input, p_GewijzigdDoor));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_NewAkkoordStatus", ParameterDirection.Input, p_NewAkkoordStatus));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_UserName", ParameterDirection.Input, p_UserName));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_MaxTariefTotaal_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_MaxTariefTotaal_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", ParameterDirection.InputOutput, AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			AfspraakGewijzigd = (bool?)request.GetParameterValue("@AfspraakGewijzigd");
			return result;
		}

		public T csp_ImportVolumeSpecificatie_u01<T>(int? p_AfspraakID, int? p_SpecificatieGebaseerdOpJaar, Guid p_StagingImportVolumeSpecificatieBatchToken, string p_ToegevoegdDoor) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ImportVolumeSpecificatie_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", ParameterDirection.Input, p_AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_SpecificatieGebaseerdOpJaar", ParameterDirection.Input, p_SpecificatieGebaseerdOpJaar));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_StagingImportVolumeSpecificatieBatchToken", ParameterDirection.Input, p_StagingImportVolumeSpecificatieBatchToken));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ToegevoegdDoor", ParameterDirection.Input, p_ToegevoegdDoor));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandenWerk_d01<T>(DateTime PeriodeEind, DateTime PeriodeStart, int? ZVSID, int? ZVZID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandenWerk_d01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeriodeEind", ParameterDirection.Input, PeriodeEind));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeriodeStart", ParameterDirection.Input, PeriodeStart));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVSID", ParameterDirection.Input, ZVSID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVZID", ParameterDirection.Input, ZVZID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_MinTariefHonorarium_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_MinTariefHonorarium_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_VolumeSpecificatie_s01<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_VolumeSpecificatie_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Sjabloon_s03<T>(int? SjabloonAfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Sjabloon_s03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SjabloonAfspraakID", ParameterDirection.Input, SjabloonAfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandenWerk_s02<T>(IEnumerable<Database.UserDefinedTypes.Overig.udtPeriodeTable> Perioden, int? ZVSID, int? ZVZID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandenWerk_s02");
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@Perioden", ParameterDirection.Input, "Overig", "udtPeriodeTable", Perioden));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVSID", ParameterDirection.Input, ZVSID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVZID", ParameterDirection.Input, ZVZID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_MinTariefHonorarium_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_MinTariefHonorarium_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", ParameterDirection.InputOutput, AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			AfspraakGewijzigd = (bool?)request.GetParameterValue("@AfspraakGewijzigd");
			return result;
		}

		public T csp_VolumeSpecificatie_s02<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_VolumeSpecificatie_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Sjabloon_s05<T>(int? InstantieId, int? ZorgSoort) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Sjabloon_s05");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieId", ParameterDirection.Input, InstantieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgSoort", ParameterDirection.Input, ZorgSoort));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandenWerk_s03<T>(DateTime PeriodeEind, DateTime PeriodeStart, int? ZVSID, int? ZVZID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandenWerk_s03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeriodeEind", ParameterDirection.Input, PeriodeEind));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeriodeStart", ParameterDirection.Input, PeriodeStart));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVSID", ParameterDirection.Input, ZVSID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVZID", ParameterDirection.Input, ZVZID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_MinTariefKosten_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_MinTariefKosten_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_VolumeSpecificatie_s03<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_VolumeSpecificatie_s03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Model_iu01<T>(ref int? l_identity, string p_MDL_Code, string p_MDL_Omschrijving, string p_username, string p_ZVS_AGBCode, string p_ZVZ_UZOVI) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Model_iu01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@l_identity", ParameterDirection.InputOutput, l_identity));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_MDL_Code", ParameterDirection.Input, p_MDL_Code));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_MDL_Omschrijving", ParameterDirection.Input, p_MDL_Omschrijving));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_username", ParameterDirection.Input, p_username));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ZVS_AGBCode", ParameterDirection.Input, p_ZVS_AGBCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ZVZ_UZOVI", ParameterDirection.Input, p_ZVZ_UZOVI));
			var result = _executor.Execute<T>(request);
			l_identity = (int?)request.GetParameterValue("@l_identity");
			return result;
		}

		public T csp_OnderhandenWerk_s04<T>(DateTime PeriodeEind, DateTime PeriodeStart, bool? VoorgaandJaar, int? ZVSID, int? ZVZID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandenWerk_s04");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeriodeEind", ParameterDirection.Input, PeriodeEind));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeriodeStart", ParameterDirection.Input, PeriodeStart));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@VoorgaandJaar", ParameterDirection.Input, VoorgaandJaar));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVSID", ParameterDirection.Input, ZVSID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVZID", ParameterDirection.Input, ZVZID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_MinTariefKosten_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_MinTariefKosten_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", ParameterDirection.InputOutput, AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			AfspraakGewijzigd = (bool?)request.GetParameterValue("@AfspraakGewijzigd");
			return result;
		}

		public T csp_OnderhandenWerk_s05<T>(DateTime PeriodeEind, DateTime PeriodeStart, int? ZVZID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandenWerk_s05");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeriodeEind", ParameterDirection.Input, PeriodeEind));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeriodeStart", ParameterDirection.Input, PeriodeStart));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVZID", ParameterDirection.Input, ZVZID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandenWerk_u01<T>(bool? AkkoordVerklaard, IEnumerable<Database.UserDefinedTypes.Afspraak.udtOnderhandenWerkComponentenTable> ComponentenHuidigJaar, IEnumerable<Database.UserDefinedTypes.Afspraak.udtOnderhandenWerkComponentenTable> ComponentenVoorgaandJaar, decimal? KostprijsHuidigJaar, decimal? KostprijsVoorgaandJaar, string OpgegevenDoor, DateTime PeriodeEind, DateTime PeriodeStart, int? ZVSID, int? ZVZID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandenWerk_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AkkoordVerklaard", ParameterDirection.Input, AkkoordVerklaard));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@ComponentenHuidigJaar", ParameterDirection.Input, "Afspraak", "udtOnderhandenWerkComponentenTable", ComponentenHuidigJaar));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@ComponentenVoorgaandJaar", ParameterDirection.Input, "Afspraak", "udtOnderhandenWerkComponentenTable", ComponentenVoorgaandJaar));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@KostprijsHuidigJaar", ParameterDirection.Input, KostprijsHuidigJaar));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@KostprijsVoorgaandJaar", ParameterDirection.Input, KostprijsVoorgaandJaar));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OpgegevenDoor", ParameterDirection.Input, OpgegevenDoor));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeriodeEind", ParameterDirection.Input, PeriodeEind));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeriodeStart", ParameterDirection.Input, PeriodeStart));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVSID", ParameterDirection.Input, ZVSID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVZID", ParameterDirection.Input, ZVZID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_PrestatieComponentPassantenTarief_i01<T>(ref int? l_DBC_ID, int? p_CON_ID, decimal? p_CONDBC_Specialisten, decimal? p_CONDBC_Ziekenhuis, DateTime p_DatumIngang, string p_DeclaratieCode, decimal? p_PoortSpecialismePrijs, string p_prestatieCode, string p_SPC_Code, string p_username) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_PrestatieComponentPassantenTarief_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@l_DBC_ID", ParameterDirection.InputOutput, l_DBC_ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_CON_ID", ParameterDirection.Input, p_CON_ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_CONDBC_Specialisten", ParameterDirection.Input, p_CONDBC_Specialisten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_CONDBC_Ziekenhuis", ParameterDirection.Input, p_CONDBC_Ziekenhuis));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_DatumIngang", ParameterDirection.Input, p_DatumIngang));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_DeclaratieCode", ParameterDirection.Input, p_DeclaratieCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_PoortSpecialismePrijs", ParameterDirection.Input, p_PoortSpecialismePrijs));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_prestatieCode", ParameterDirection.Input, p_prestatieCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_SPC_Code", ParameterDirection.Input, p_SPC_Code));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_username", ParameterDirection.Input, p_username));
			var result = _executor.Execute<T>(request);
			l_DBC_ID = (int?)request.GetParameterValue("@l_DBC_ID");
			return result;
		}

		public T csp_Onderhandeling_s10<T>(DateTime BeginDatum, DateTime EindDatum, int? HuidigInstantieTypeId, bool? IncConcepten, ref int? OnderhandelingenInPeriode, int? ZorgSoortID, int? ZorgverstrekkerID, int? ZorgverzekeraarID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_s10");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BeginDatum", ParameterDirection.Input, BeginDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@EindDatum", ParameterDirection.Input, EindDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@HuidigInstantieTypeId", ParameterDirection.Input, HuidigInstantieTypeId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@IncConcepten", ParameterDirection.Input, IncConcepten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandelingenInPeriode", ParameterDirection.InputOutput, OnderhandelingenInPeriode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgSoortID", ParameterDirection.Input, ZorgSoortID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerID", ParameterDirection.Input, ZorgverstrekkerID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarID", ParameterDirection.Input, ZorgverzekeraarID));
			var result = _executor.Execute<T>(request);
			OnderhandelingenInPeriode = (int?)request.GetParameterValue("@OnderhandelingenInPeriode");
			return result;
		}

		public T csp_PassantenTarief_i02<T>(DateTime p_BeginDatum, DateTime p_EindDatum, ref int? p_identity, string p_Omschrijving, int? p_SubVersie, string p_username, int? p_Versie, int? p_ZVS_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_PassantenTarief_i02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_BeginDatum", ParameterDirection.Input, p_BeginDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_EindDatum", ParameterDirection.Input, p_EindDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_identity", ParameterDirection.InputOutput, p_identity));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Omschrijving", ParameterDirection.Input, p_Omschrijving));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_SubVersie", ParameterDirection.Input, p_SubVersie));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_username", ParameterDirection.Input, p_username));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Versie", ParameterDirection.Input, p_Versie));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ZVS_ID", ParameterDirection.Input, p_ZVS_ID));
			var result = _executor.Execute<T>(request);
			p_identity = (int?)request.GetParameterValue("@p_identity");
			return result;
		}

		public T csp_PassantenTarief_i01<T>(DateTime p_BeginDatum, DateTime p_EindDatum, ref int? p_identity, string p_Omschrijving, int? p_SubVersie, string p_username, int? p_Versie, string p_ZVS_AGBCode) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_PassantenTarief_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_BeginDatum", ParameterDirection.Input, p_BeginDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_EindDatum", ParameterDirection.Input, p_EindDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_identity", ParameterDirection.InputOutput, p_identity));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Omschrijving", ParameterDirection.Input, p_Omschrijving));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_SubVersie", ParameterDirection.Input, p_SubVersie));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_username", ParameterDirection.Input, p_username));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Versie", ParameterDirection.Input, p_Versie));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ZVS_AGBCode", ParameterDirection.Input, p_ZVS_AGBCode));
			var result = _executor.Execute<T>(request);
			p_identity = (int?)request.GetParameterValue("@p_identity");
			return result;
		}

		public T csp_Contract_s16<T>(int? ZorgverstrekkerID, int? ZorgverzekeraarID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_s16");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerID", ParameterDirection.Input, ZorgverstrekkerID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarID", ParameterDirection.Input, ZorgverzekeraarID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Onderhandeling_s06<T>(int? InstantieTypeID, int? ZorgverstrekkerID, int? ZorgverzekeraarID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_s06");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieTypeID", ParameterDirection.Input, InstantieTypeID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerID", ParameterDirection.Input, ZorgverstrekkerID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarID", ParameterDirection.Input, ZorgverzekeraarID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ImportPassantenTarieven_u01<T>(ref int? RecordsInserted, ref int? RecordsUpdated, int? TogImportBatchLogID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ImportPassantenTarieven_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@RecordsInserted", ParameterDirection.InputOutput, RecordsInserted));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@RecordsUpdated", ParameterDirection.InputOutput, RecordsUpdated));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@TogImportBatchLogID", ParameterDirection.Input, TogImportBatchLogID));
			var result = _executor.Execute<T>(request);
			RecordsInserted = (int?)request.GetParameterValue("@RecordsInserted");
			RecordsUpdated = (int?)request.GetParameterValue("@RecordsUpdated");
			return result;
		}

		public T csp_InstantieRegel_s01<T>(int? AfspraakID, int? InstantieRegelID, bool? OnlyOutdated) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_InstantieRegel_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieRegelID", ParameterDirection.Input, InstantieRegelID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnlyOutdated", ParameterDirection.Input, OnlyOutdated));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Afspraak_u02<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Afspraak_u02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Onderhandeling_s11<T>(int? InstantieID, int? InstantieType, string SegmentCode, int? ZorgSoort) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_s11");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", ParameterDirection.Input, InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieType", ParameterDirection.Input, InstantieType));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SegmentCode", ParameterDirection.Input, SegmentCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgSoort", ParameterDirection.Input, ZorgSoort));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_RegelResultaat_s01<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_RegelResultaat_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Onderhandeling_s07<T>(int? AfspraakStijl, int? InstantieTypeID, DateTime MaxBegindatum, DateTime MinBegindatum, string SegmentCode, int? ZorgverstrekkerID, int? ZorgverzekeraarID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_s07");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakStijl", ParameterDirection.Input, AfspraakStijl));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieTypeID", ParameterDirection.Input, InstantieTypeID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@MaxBegindatum", ParameterDirection.Input, MaxBegindatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@MinBegindatum", ParameterDirection.Input, MinBegindatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SegmentCode", ParameterDirection.Input, SegmentCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerID", ParameterDirection.Input, ZorgverstrekkerID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarID", ParameterDirection.Input, ZorgverzekeraarID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Onderhandeling_s12<T>(int? AfspraakId, int? InstantieTypeID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_s12");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakId", ParameterDirection.Input, AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieTypeID", ParameterDirection.Input, InstantieTypeID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_VolumeSpecificatie_s04<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_VolumeSpecificatie_s04");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_RegelResultaat_u01<T>(int? AfspraakID, int? InstantieRegelID, string ResultaatToelichting, int? UitgevoerdDoorID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_RegelResultaat_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieRegelID", ParameterDirection.Input, InstantieRegelID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ResultaatToelichting", ParameterDirection.Input, ResultaatToelichting));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@UitgevoerdDoorID", ParameterDirection.Input, UitgevoerdDoorID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Onderhandeling_s08<T>(DateTime BeginDatum, int? CheckInstantieTypeId, DateTime EindDatum, bool? IncConcepten, ref int? OnderhandelingenInPeriode, string Segment, int? ZorgverstrekkerID, int? ZorgverzekeraarID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_s08");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BeginDatum", ParameterDirection.Input, BeginDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CheckInstantieTypeId", ParameterDirection.Input, CheckInstantieTypeId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@EindDatum", ParameterDirection.Input, EindDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@IncConcepten", ParameterDirection.Input, IncConcepten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandelingenInPeriode", ParameterDirection.InputOutput, OnderhandelingenInPeriode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Segment", ParameterDirection.Input, Segment));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerID", ParameterDirection.Input, ZorgverstrekkerID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarID", ParameterDirection.Input, ZorgverzekeraarID));
			var result = _executor.Execute<T>(request);
			OnderhandelingenInPeriode = (int?)request.GetParameterValue("@OnderhandelingenInPeriode");
			return result;
		}

		public T csp_VolumeSpecificatie_s05<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_VolumeSpecificatie_s05");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_RegelResultaat_u02<T>(int? AfspraakID, int? InstantieRegelID, int? UitgevoerdDoorID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_RegelResultaat_u02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieRegelID", ParameterDirection.Input, InstantieRegelID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@UitgevoerdDoorID", ParameterDirection.Input, UitgevoerdDoorID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_onderhandenwerk_s06<T>(DateTime peilDatum, int? ZVZ_uzovi) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_onderhandenwerk_s06");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@peilDatum", ParameterDirection.Input, peilDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVZ_uzovi", ParameterDirection.Input, ZVZ_uzovi));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Afspraak_s07<T>(DateTime BeginDatum, DateTime Einddatum, int? InstantieID, string PoortSpecialismeCode, string PrestatieCode) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Afspraak_s07");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BeginDatum", ParameterDirection.Input, BeginDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Einddatum", ParameterDirection.Input, Einddatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", ParameterDirection.Input, InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PoortSpecialismeCode", ParameterDirection.Input, PoortSpecialismeCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrestatieCode", ParameterDirection.Input, PrestatieCode));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_1517Gelijk_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_1517Gelijk_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_1416Gelijk_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_1416Gelijk_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Afspraak_s05<T>(int? AfspraakID, int? InstantieID, int? PrestatieID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Afspraak_s05");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", ParameterDirection.Input, InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrestatieID", ParameterDirection.Input, PrestatieID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ContractControleBestaandContract_s01<T>(DateTime BeginDatum, ref bool? BestaandContract, string Segment, int? ZorgSoort, int? ZVS_ID, int? ZVZ_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ContractControleBestaandContract_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BeginDatum", ParameterDirection.Input, BeginDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BestaandContract", ParameterDirection.InputOutput, BestaandContract));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Segment", ParameterDirection.Input, Segment));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgSoort", ParameterDirection.Input, ZorgSoort));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVS_ID", ParameterDirection.Input, ZVS_ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVZ_ID", ParameterDirection.Input, ZVZ_ID));
			var result = _executor.Execute<T>(request);
			BestaandContract = (bool?)request.GetParameterValue("@BestaandContract");
			return result;
		}

		public T csp_Validatie_1517Gelijk_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_1517Gelijk_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", ParameterDirection.InputOutput, AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			AfspraakGewijzigd = (bool?)request.GetParameterValue("@AfspraakGewijzigd");
			return result;
		}

		public T csp_Validatie_1416Gelijk_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_1416Gelijk_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", ParameterDirection.InputOutput, AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			AfspraakGewijzigd = (bool?)request.GetParameterValue("@AfspraakGewijzigd");
			return result;
		}

		public T csp_Afspraak_u03<T>(int? AfspraakID, DateTime BeginDatum, DateTime EindDatum, string Username) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Afspraak_u03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BeginDatum", ParameterDirection.Input, BeginDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@EindDatum", ParameterDirection.Input, EindDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Username", ParameterDirection.Input, Username));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_Correcte17CodesAgisAchmea_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_Correcte17CodesAgisAchmea_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_OvernemenPrijzen16Pendant_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_OvernemenPrijzen16Pendant_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Afspraak_u04<T>(int? AfspraakID, int? InstantieID, string Username, Guid VersieID, ref Guid VersieIDNieuw) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Afspraak_u04");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", ParameterDirection.Input, InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Username", ParameterDirection.Input, Username));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@VersieID", ParameterDirection.Input, VersieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@VersieIDNieuw", ParameterDirection.InputOutput, VersieIDNieuw));
			var result = _executor.Execute<T>(request);
			VersieIDNieuw = (Guid)request.GetParameterValue("@VersieIDNieuw");
			return result;
		}

		public T csp_Validatie_Correcte17CodesAgisAchmea_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_Correcte17CodesAgisAchmea_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", ParameterDirection.InputOutput, AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			AfspraakGewijzigd = (bool?)request.GetParameterValue("@AfspraakGewijzigd");
			return result;
		}

		public T csp_Validatie_OvernemenPrijzen16Pendant_Solve<T>(ref bool? AfspraakGewijzigd, int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_OvernemenPrijzen16Pendant_Solve");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakGewijzigd", ParameterDirection.InputOutput, AfspraakGewijzigd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			AfspraakGewijzigd = (bool?)request.GetParameterValue("@AfspraakGewijzigd");
			return result;
		}

		public T csp_BlacklistAfspraak_s01<T>(DateTime periodeEind, DateTime periodeStart, string Segment, int? ZorgverstrekkerID, int? ZorgverzekeraarID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_BlacklistAfspraak_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@periodeEind", ParameterDirection.Input, periodeEind));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@periodeStart", ParameterDirection.Input, periodeStart));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Segment", ParameterDirection.Input, Segment));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerID", ParameterDirection.Input, ZorgverstrekkerID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarID", ParameterDirection.Input, ZorgverzekeraarID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_HonorariumToeslagZBC_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_HonorariumToeslagZBC_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_PrestatieComponentModel_s02<T>(int? MDL_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_PrestatieComponentModel_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@MDL_ID", ParameterDirection.Input, MDL_ID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_NegatieveTarieven_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_NegatieveTarieven_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Contract_s12<T>(ref int? AfspraakID, string p_Segment, int? p_ZorgverstrekkerID, int? p_ZorgverzekeraarID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_s12");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.InputOutput, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Segment", ParameterDirection.Input, p_Segment));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ZorgverstrekkerID", ParameterDirection.Input, p_ZorgverstrekkerID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ZorgverzekeraarID", ParameterDirection.Input, p_ZorgverzekeraarID));
			var result = _executor.Execute<T>(request);
			AfspraakID = (int?)request.GetParameterValue("@AfspraakID");
			return result;
		}

		public T csp_Contract_i05<T>(int? p_AfspraakID, ref int? p_AfspraakIDContract, bool? p_AutomatischGeaccordeerd, string p_UserName) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_i05");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", ParameterDirection.Input, p_AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakIDContract", ParameterDirection.InputOutput, p_AfspraakIDContract));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AutomatischGeaccordeerd", ParameterDirection.Input, p_AutomatischGeaccordeerd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_UserName", ParameterDirection.Input, p_UserName));
			var result = _executor.Execute<T>(request);
			p_AfspraakIDContract = (int?)request.GetParameterValue("@p_AfspraakIDContract");
			return result;
		}

		public T csp_Validatie_NulTariefHonorariumdeel_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_NulTariefHonorariumdeel_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ContractGroep_s01<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ContractGroep_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Contract_i06<T>(ref int? AfspraakID, string AGBCode, DateTime BeginDatum, string CreateUser, DateTime EindDatum, int? InstantieSubType, string Omschrijving, string Segment, int? SjabloonAfspraakID, string UZOVI) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_i06");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.InputOutput, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AGBCode", ParameterDirection.Input, AGBCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BeginDatum", ParameterDirection.Input, BeginDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CreateUser", ParameterDirection.Input, CreateUser));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@EindDatum", ParameterDirection.Input, EindDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieSubType", ParameterDirection.Input, InstantieSubType));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Omschrijving", ParameterDirection.Input, Omschrijving));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Segment", ParameterDirection.Input, Segment));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SjabloonAfspraakID", ParameterDirection.Input, SjabloonAfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@UZOVI", ParameterDirection.Input, UZOVI));
			var result = _executor.Execute<T>(request);
			AfspraakID = (int?)request.GetParameterValue("@AfspraakID");
			return result;
		}

		public T csp_Validatie_NulTariefKostendeel_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_NulTariefKostendeel_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ContractGroepsUitzondering_s01<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ContractGroepsUitzondering_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Contract_u03<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Contract_u03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Validatie_OntbrekenVolumina_Check<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Validatie_OntbrekenVolumina_Check");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ContractControleBestaandContract_s02<T>(int? AfspraakID, DateTime BeginDatum, ref bool? BestaandContract, DateTime EindDatum, string Segment) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ContractControleBestaandContract_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BeginDatum", ParameterDirection.Input, BeginDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BestaandContract", ParameterDirection.InputOutput, BestaandContract));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@EindDatum", ParameterDirection.Input, EindDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Segment", ParameterDirection.Input, Segment));
			var result = _executor.Execute<T>(request);
			BestaandContract = (bool?)request.GetParameterValue("@BestaandContract");
			return result;
		}

		public T csp_Onderhandeling_u09<T>(int? p_AfspraakID, bool? p_BijwerkenPrijslijst) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_u09");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", ParameterDirection.Input, p_AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_BijwerkenPrijslijst", ParameterDirection.Input, p_BijwerkenPrijslijst));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ContractPrijslijst_s02<T>(int? AfspraakID, int? InstantieID, bool? VerrijkSjabloon) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ContractPrijslijst_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", ParameterDirection.Input, InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@VerrijkSjabloon", ParameterDirection.Input, VerrijkSjabloon));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ContractPrijslijst_s05<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ContractPrijslijst_s05");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingGroepsUitzondering_d01<T>(string DeclaratieCode, ref bool? IsVerwijderd, int? OnderhandelingAfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingGroepsUitzondering_d01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DeclaratieCode", ParameterDirection.Input, DeclaratieCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@IsVerwijderd", ParameterDirection.InputOutput, IsVerwijderd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandelingAfspraakID", ParameterDirection.Input, OnderhandelingAfspraakID));
			var result = _executor.Execute<T>(request);
			IsVerwijderd = (bool?)request.GetParameterValue("@IsVerwijderd");
			return result;
		}

		public T csp_ContractPrijslijstHonOndhComp_s02<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ContractPrijslijstHonOndhComp_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ContractPrijslijst_s06<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ContractPrijslijst_s06");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingPrestatie_s03<T>(int? p_OnderhandelingGroepID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_OnderhandelingPrestatie_s03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingGroepID", ParameterDirection.Input, p_OnderhandelingGroepID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ImportContractData_u01<T>(int? p_AfspraakID, Guid p_StagingImportPrijslijstBatchToken) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_ImportContractData_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", ParameterDirection.Input, p_AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_StagingImportPrijslijstBatchToken", ParameterDirection.Input, p_StagingImportPrijslijstBatchToken));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Onderhandeling_s13<T>(int? InstantieTypeID, int? ZorgverstrekkerID, int? ZorgverzekeraarID) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_Onderhandeling_s13");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieTypeID", ParameterDirection.Input, InstantieTypeID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerID", ParameterDirection.Input, ZorgverstrekkerID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarID", ParameterDirection.Input, ZorgverzekeraarID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_PrestatieFilter_s01<T>(bool? InclSpeerpunt, int? InstantieID, DateTime PeriodeEind, DateTime PeriodeStart, string Segment) where T : SqlResponse
		{
			var request = new SqlRequest("Afspraak", "csp_PrestatieFilter_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InclSpeerpunt", ParameterDirection.Input, InclSpeerpunt));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", ParameterDirection.Input, InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeriodeEind", ParameterDirection.Input, PeriodeEind));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeriodeStart", ParameterDirection.Input, PeriodeStart));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Segment", ParameterDirection.Input, Segment));
			var result = _executor.Execute<T>(request);
			return result;
		}
	}

	public class Analyse : IAnalyse
	{
		private ISqlExecutor _executor;
		public Analyse(ISqlExecutor executor)
		{
			_executor = executor;
		}

		public T csp_ZorgverstrekkerBudget_s04<T>(int? ZorgverstrekkerId, int? ZorgverzekeraarId) where T : SqlResponse
		{
			var request = new SqlRequest("Analyse", "csp_ZorgverstrekkerBudget_s04");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerId", ParameterDirection.Input, ZorgverstrekkerId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", ParameterDirection.Input, ZorgverzekeraarId));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ZorgverstrekkerBudgetBulk_u01<T>(IEnumerable<Database.UserDefinedTypes.Analyse.udtZorgverstrekkerBudget> BudgetRegels) where T : SqlResponse
		{
			var request = new SqlRequest("Analyse", "csp_ZorgverstrekkerBudgetBulk_u01");
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@BudgetRegels", ParameterDirection.Input, "Analyse", "udtZorgverstrekkerBudget", BudgetRegels));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_BehandelingZwarteLijst_s01<T>(DateTime Peildatum, int? ZorgverzekeraarId) where T : SqlResponse
		{
			var request = new SqlRequest("Analyse", "csp_BehandelingZwarteLijst_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Peildatum", ParameterDirection.Input, Peildatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", ParameterDirection.Input, ZorgverzekeraarId));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ZorgverstrekkerBudget_s06<T>(bool? AlleenGecontracteerd, int? CategorieId, bool? InclContracten, bool? InclOnderhandelingen, string Inkoper, int? PeriodeId, int? RegioId, int? ZorgverstrekkerId, int? ZorgverzekeraarId) where T : SqlResponse
		{
			var request = new SqlRequest("Analyse", "csp_ZorgverstrekkerBudget_s06");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AlleenGecontracteerd", ParameterDirection.Input, AlleenGecontracteerd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CategorieId", ParameterDirection.Input, CategorieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InclContracten", ParameterDirection.Input, InclContracten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InclOnderhandelingen", ParameterDirection.Input, InclOnderhandelingen));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Inkoper", ParameterDirection.Input, Inkoper));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeriodeId", ParameterDirection.Input, PeriodeId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@RegioId", ParameterDirection.Input, RegioId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerId", ParameterDirection.Input, ZorgverstrekkerId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", ParameterDirection.Input, ZorgverzekeraarId));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Periode_s01<T>(DateTime DatumVanaf, int? ZorgverzekeraarId) where T : SqlResponse
		{
			var request = new SqlRequest("Analyse", "csp_Periode_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DatumVanaf", ParameterDirection.Input, DatumVanaf));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", ParameterDirection.Input, ZorgverzekeraarId));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Stamgegeven_s01<T>(DateTime BeginDatum, DateTime EindDatum, string GroepSleutel, int? ZorgverzekeraarId) where T : SqlResponse
		{
			var request = new SqlRequest("Analyse", "csp_Stamgegeven_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BeginDatum", ParameterDirection.Input, BeginDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@EindDatum", ParameterDirection.Input, EindDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GroepSleutel", ParameterDirection.Input, GroepSleutel));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", ParameterDirection.Input, ZorgverzekeraarId));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ZorgverstrekkerBudget_s01<T>(int? PeriodeId, int? ZorgSoortId, int? ZorgverstrekkerId, int? ZorgverzekeraarId) where T : SqlResponse
		{
			var request = new SqlRequest("Analyse", "csp_ZorgverstrekkerBudget_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeriodeId", ParameterDirection.Input, PeriodeId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgSoortId", ParameterDirection.Input, ZorgSoortId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerId", ParameterDirection.Input, ZorgverstrekkerId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", ParameterDirection.Input, ZorgverzekeraarId));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ZorgverstrekkerBudget_s02<T>(bool? AlleenGecontracteerd, int? CategorieId, bool? InclContracten, bool? InclOnderhandelingen, string Inkoper, int? PeriodeId, int? RegioId, int? ZorgverstrekkerId, int? ZorgverzekeraarId) where T : SqlResponse
		{
			var request = new SqlRequest("Analyse", "csp_ZorgverstrekkerBudget_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AlleenGecontracteerd", ParameterDirection.Input, AlleenGecontracteerd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CategorieId", ParameterDirection.Input, CategorieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InclContracten", ParameterDirection.Input, InclContracten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InclOnderhandelingen", ParameterDirection.Input, InclOnderhandelingen));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Inkoper", ParameterDirection.Input, Inkoper));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeriodeId", ParameterDirection.Input, PeriodeId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@RegioId", ParameterDirection.Input, RegioId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerId", ParameterDirection.Input, ZorgverstrekkerId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", ParameterDirection.Input, ZorgverzekeraarId));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ZorgverstrekkerBudget_u01<T>(decimal? BudgetTotaal, int? CategorieId, bool? Contracteerbaar, string Contractnummer, decimal? ExternContractTotaal, string Inkoper, string IPZReferentie, decimal? MandaatTotaal, bool? NietInAutoModelcontract, decimal? OmzetAfspraak, int? OmzetAfspraakSoortId, decimal? OmzetPlafond, bool? OnderhandenWerk, string OnderhandenWerkMailadres, int? PeriodeId, decimal? PrijsAfspraak, string PrijsAfspraakOmschrijving, int? RegioId, int? ZorgSoortId, int? ZorgverstrekkerId, int? ZorgverzekeraarId) where T : SqlResponse
		{
			var request = new SqlRequest("Analyse", "csp_ZorgverstrekkerBudget_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BudgetTotaal", ParameterDirection.Input, BudgetTotaal));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CategorieId", ParameterDirection.Input, CategorieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Contracteerbaar", ParameterDirection.Input, Contracteerbaar));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Contractnummer", ParameterDirection.Input, Contractnummer));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ExternContractTotaal", ParameterDirection.Input, ExternContractTotaal));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Inkoper", ParameterDirection.Input, Inkoper));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@IPZReferentie", ParameterDirection.Input, IPZReferentie));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@MandaatTotaal", ParameterDirection.Input, MandaatTotaal));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@NietInAutoModelcontract", ParameterDirection.Input, NietInAutoModelcontract));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OmzetAfspraak", ParameterDirection.Input, OmzetAfspraak));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OmzetAfspraakSoortId", ParameterDirection.Input, OmzetAfspraakSoortId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OmzetPlafond", ParameterDirection.Input, OmzetPlafond));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandenWerk", ParameterDirection.Input, OnderhandenWerk));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandenWerkMailadres", ParameterDirection.Input, OnderhandenWerkMailadres));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeriodeId", ParameterDirection.Input, PeriodeId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsAfspraak", ParameterDirection.Input, PrijsAfspraak));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsAfspraakOmschrijving", ParameterDirection.Input, PrijsAfspraakOmschrijving));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@RegioId", ParameterDirection.Input, RegioId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgSoortId", ParameterDirection.Input, ZorgSoortId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerId", ParameterDirection.Input, ZorgverstrekkerId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", ParameterDirection.Input, ZorgverzekeraarId));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ZorgverstrekkerBudget_s03<T>(bool? AlleenGecontracteerd, int? CategorieId, bool? InclContracten, bool? InclOnderhandelingen, string Inkoper, int? PeriodeId, int? RegioId, int? ZorgverstrekkerId, int? ZorgverzekeraarId) where T : SqlResponse
		{
			var request = new SqlRequest("Analyse", "csp_ZorgverstrekkerBudget_s03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AlleenGecontracteerd", ParameterDirection.Input, AlleenGecontracteerd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CategorieId", ParameterDirection.Input, CategorieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InclContracten", ParameterDirection.Input, InclContracten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InclOnderhandelingen", ParameterDirection.Input, InclOnderhandelingen));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Inkoper", ParameterDirection.Input, Inkoper));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeriodeId", ParameterDirection.Input, PeriodeId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@RegioId", ParameterDirection.Input, RegioId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerId", ParameterDirection.Input, ZorgverstrekkerId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", ParameterDirection.Input, ZorgverzekeraarId));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_BehandelingZwarteLijst_u01<T>(IEnumerable<Database.UserDefinedTypes.Analyse.udtUpdateBehandelingZwarteLijst> UpdateList, int? ZorgverzekeraarId) where T : SqlResponse
		{
			var request = new SqlRequest("Analyse", "csp_BehandelingZwarteLijst_u01");
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@UpdateList", ParameterDirection.Input, "Analyse", "udtUpdateBehandelingZwarteLijst", UpdateList));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", ParameterDirection.Input, ZorgverzekeraarId));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ZorgverstrekkersScore_s01<T>(int? AfspraakIDModel, bool? AlleenSpeerpuntPrestaties, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> Categorien, bool? GeenSpeerpuntPrestaties, bool? InclContracten, bool? InclOnderhandelingen, int? RapportagePeriodeID, int? ZorgverzekeraarID) where T : SqlResponse
		{
			var request = new SqlRequest("Analyse", "csp_ZorgverstrekkersScore_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakIDModel", ParameterDirection.Input, AfspraakIDModel));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AlleenSpeerpuntPrestaties", ParameterDirection.Input, AlleenSpeerpuntPrestaties));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@Categorien", ParameterDirection.Input, "Overig", "udtIntTable", Categorien));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GeenSpeerpuntPrestaties", ParameterDirection.Input, GeenSpeerpuntPrestaties));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InclContracten", ParameterDirection.Input, InclContracten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InclOnderhandelingen", ParameterDirection.Input, InclOnderhandelingen));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@RapportagePeriodeID", ParameterDirection.Input, RapportagePeriodeID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarID", ParameterDirection.Input, ZorgverzekeraarID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ZorgverstrekkerBudget_s05<T>(DateTime BeginDatum, DateTime EindDatum, int? PeriodeId, int? ZorgSoortId, int? ZorgverstrekkerId, int? ZorgverzekeraarId) where T : SqlResponse
		{
			var request = new SqlRequest("Analyse", "csp_ZorgverstrekkerBudget_s05");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BeginDatum", ParameterDirection.Input, BeginDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@EindDatum", ParameterDirection.Input, EindDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeriodeId", ParameterDirection.Input, PeriodeId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgSoortId", ParameterDirection.Input, ZorgSoortId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerId", ParameterDirection.Input, ZorgverstrekkerId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", ParameterDirection.Input, ZorgverzekeraarId));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ZorgverstrekkerBudget_d01<T>(int? PeriodeId, int? ZorgSoortId, int? ZorgverstrekkerId, int? ZorgverzekeraarId) where T : SqlResponse
		{
			var request = new SqlRequest("Analyse", "csp_ZorgverstrekkerBudget_d01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeriodeId", ParameterDirection.Input, PeriodeId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgSoortId", ParameterDirection.Input, ZorgSoortId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerId", ParameterDirection.Input, ZorgverstrekkerId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverzekeraarId", ParameterDirection.Input, ZorgverzekeraarId));
			var result = _executor.Execute<T>(request);
			return result;
		}
	}

	public class DataStaging : IDataStaging
	{
		private ISqlExecutor _executor;
		public DataStaging(ISqlExecutor executor)
		{
			_executor = executor;
		}

		public T csp_TogRecordType36_u01<T>(int? TogImportBatchLogID) where T : SqlResponse
		{
			var request = new SqlRequest("DataStaging", "csp_TogRecordType36_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@TogImportBatchLogID", ParameterDirection.Input, TogImportBatchLogID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_TogRecordType36_i01<T>(string AanduidingPrestatiecodelijst, string DatumEindeTarief, string DatumIngangTarief, string DbcDeclaratieCode, string DbcDeclarerendSpecialisme, string DbcPoortspecialisme, ref int? Identity, string IndicatieDebetCredit, string IndicatieSoortZorg, string Kenmerk, string KenmerkRecord, string Mutatiecode, string SoortTarief, string Tarief, string ToelichtingMutatie, string TypeTarief) where T : SqlResponse
		{
			var request = new SqlRequest("DataStaging", "csp_TogRecordType36_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AanduidingPrestatiecodelijst", ParameterDirection.Input, AanduidingPrestatiecodelijst));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DatumEindeTarief", ParameterDirection.Input, DatumEindeTarief));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DatumIngangTarief", ParameterDirection.Input, DatumIngangTarief));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DbcDeclaratieCode", ParameterDirection.Input, DbcDeclaratieCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DbcDeclarerendSpecialisme", ParameterDirection.Input, DbcDeclarerendSpecialisme));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DbcPoortspecialisme", ParameterDirection.Input, DbcPoortspecialisme));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Identity", ParameterDirection.InputOutput, Identity));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@IndicatieDebetCredit", ParameterDirection.Input, IndicatieDebetCredit));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@IndicatieSoortZorg", ParameterDirection.Input, IndicatieSoortZorg));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Kenmerk", ParameterDirection.Input, Kenmerk));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@KenmerkRecord", ParameterDirection.Input, KenmerkRecord));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Mutatiecode", ParameterDirection.Input, Mutatiecode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SoortTarief", ParameterDirection.Input, SoortTarief));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Tarief", ParameterDirection.Input, Tarief));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ToelichtingMutatie", ParameterDirection.Input, ToelichtingMutatie));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@TypeTarief", ParameterDirection.Input, TypeTarief));
			var result = _executor.Execute<T>(request);
			Identity = (int?)request.GetParameterValue("@Identity");
			return result;
		}

		public T csp_TogRecordType38_d01<T>(int? TogImportBatchLogID) where T : SqlResponse
		{
			var request = new SqlRequest("DataStaging", "csp_TogRecordType38_d01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@TogImportBatchLogID", ParameterDirection.Input, TogImportBatchLogID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_TogRecordType38_u01<T>(int? TogImportBatchLogID) where T : SqlResponse
		{
			var request = new SqlRequest("DataStaging", "csp_TogRecordType38_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@TogImportBatchLogID", ParameterDirection.Input, TogImportBatchLogID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_TogRecordType36_d01<T>(int? TogImportBatchLogID) where T : SqlResponse
		{
			var request = new SqlRequest("DataStaging", "csp_TogRecordType36_d01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@TogImportBatchLogID", ParameterDirection.Input, TogImportBatchLogID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_SpreadTogRecords<T>(int? TogImportBatchLogID) where T : SqlResponse
		{
			var request = new SqlRequest("DataStaging", "csp_SpreadTogRecords");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@TogImportBatchLogID", ParameterDirection.Input, TogImportBatchLogID));
			var result = _executor.Execute<T>(request);
			return result;
		}
	}

	public class Dbc : IDbc
	{
		private ISqlExecutor _executor;
		public Dbc(ISqlExecutor executor)
		{
			_executor = executor;
		}

		public T csp_BehandelingStamdata_s01<T>(DateTime Peildatum) where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_BehandelingStamdata_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Peildatum", ParameterDirection.Input, Peildatum));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Periode_d01<T>(int? p_PeriodeID) where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_Periode_d01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_PeriodeID", ParameterDirection.Input, p_PeriodeID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Periode_i01<T>(string p_Omschrijving, DateTime p_PeriodEnd, DateTime p_PeriodStart) where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_Periode_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Omschrijving", ParameterDirection.Input, p_Omschrijving));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_PeriodEnd", ParameterDirection.Input, p_PeriodEnd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_PeriodStart", ParameterDirection.Input, p_PeriodStart));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Periode_s01<T>(bool? p_SortDescending) where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_Periode_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_SortDescending", ParameterDirection.Input, p_SortDescending));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Periode_u01<T>(string p_Omschrijving, int? p_PeriodeID, DateTime p_PeriodEnd, DateTime p_PeriodStart) where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_Periode_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Omschrijving", ParameterDirection.Input, p_Omschrijving));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_PeriodeID", ParameterDirection.Input, p_PeriodeID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_PeriodEnd", ParameterDirection.Input, p_PeriodEnd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_PeriodStart", ParameterDirection.Input, p_PeriodStart));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_TariefWijzigingType_s01<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_TariefWijzigingType_s01");
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_PrestatieCode_s02<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_PrestatieCode_s02");
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_PrestatieCode_s03<T>(string PrestatieCode) where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_PrestatieCode_s03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrestatieCode", ParameterDirection.Input, PrestatieCode));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Specialisme_s01<T>(bool? AlleenHonCompSpecialismes) where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_Specialisme_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AlleenHonCompSpecialismes", ParameterDirection.Input, AlleenHonCompSpecialismes));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Specialisme_s03<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_Specialisme_s03");
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Groepsindeling_s01<T>(ref string GroepNaam, int? GroepsIndelingId) where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_Groepsindeling_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GroepNaam", ParameterDirection.InputOutput, GroepNaam));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GroepsIndelingId", ParameterDirection.Input, GroepsIndelingId));
			var result = _executor.Execute<T>(request);
			GroepNaam = (string)request.GetParameterValue("@GroepNaam");
			return result;
		}

		public T csp_Prestatie_s06<T>(string Omschrijving) where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_Prestatie_s06");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Omschrijving", ParameterDirection.Input, Omschrijving));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_PrestatieCode_s06<T>(string segmentCode) where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_PrestatieCode_s06");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@segmentCode", ParameterDirection.Input, segmentCode));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ZorgType_s01<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_ZorgType_s01");
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ZorgVraag_s01<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_ZorgVraag_s01");
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Prestatie_s05<T>(int? PrestatieID) where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_Prestatie_s05");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrestatieID", ParameterDirection.Input, PrestatieID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_PrestatieCode_s01<T>(int? PrestatieID) where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_PrestatieCode_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrestatieID", ParameterDirection.Input, PrestatieID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Prestatie_s04<T>(string DBCCode, int? InstantieID) where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_Prestatie_s04");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DBCCode", ParameterDirection.Input, DBCCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", ParameterDirection.Input, InstantieID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_PrestatieCode_s07<T>(string PoortSpecialismeCode, string PrestatieCode) where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_PrestatieCode_s07");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PoortSpecialismeCode", ParameterDirection.Input, PoortSpecialismeCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrestatieCode", ParameterDirection.Input, PrestatieCode));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Diagnose_s01<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_Diagnose_s01");
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Prestatie_s03<T>(string AGBCode, string BEH_CODE, string DBC_DeclaratieCode, string DBCSEGMENTCODE, string DIA_CODE, int? InstantieID, DateTime PeilDatumTotEnMet, DateTime PeilDatumVanaf, string SPC_CODE, string UZOVICode, string ZTY_CODE, string ZVR_CODE) where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_Prestatie_s03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AGBCode", ParameterDirection.Input, AGBCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BEH_CODE", ParameterDirection.Input, BEH_CODE));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DBC_DeclaratieCode", ParameterDirection.Input, DBC_DeclaratieCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DBCSEGMENTCODE", ParameterDirection.Input, DBCSEGMENTCODE));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DIA_CODE", ParameterDirection.Input, DIA_CODE));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", ParameterDirection.Input, InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeilDatumTotEnMet", ParameterDirection.Input, PeilDatumTotEnMet));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PeilDatumVanaf", ParameterDirection.Input, PeilDatumVanaf));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SPC_CODE", ParameterDirection.Input, SPC_CODE));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@UZOVICode", ParameterDirection.Input, UZOVICode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZTY_CODE", ParameterDirection.Input, ZTY_CODE));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVR_CODE", ParameterDirection.Input, ZVR_CODE));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Behandeling_s01<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Dbc", "csp_Behandeling_s01");
			var result = _executor.Execute<T>(request);
			return result;
		}
	}

	public class dbo : Idbo
	{
		private ISqlExecutor _executor;
		public dbo(ISqlExecutor executor)
		{
			_executor = executor;
		}

		public T sp_upgraddiagrams<T>() where T : SqlResponse
		{
			var request = new SqlRequest("dbo", "sp_upgraddiagrams");
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T sp_helpdiagrams<T>(string diagramname, int? owner_id) where T : SqlResponse
		{
			var request = new SqlRequest("dbo", "sp_helpdiagrams");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@diagramname", ParameterDirection.Input, diagramname));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@owner_id", ParameterDirection.Input, owner_id));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T sp_helpdiagramdefinition<T>(string diagramname, int? owner_id) where T : SqlResponse
		{
			var request = new SqlRequest("dbo", "sp_helpdiagramdefinition");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@diagramname", ParameterDirection.Input, diagramname));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@owner_id", ParameterDirection.Input, owner_id));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T sp_creatediagram<T>(byte[] definition, string diagramname, int? owner_id, int? version) where T : SqlResponse
		{
			var request = new SqlRequest("dbo", "sp_creatediagram");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@definition", ParameterDirection.Input, definition));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@diagramname", ParameterDirection.Input, diagramname));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@owner_id", ParameterDirection.Input, owner_id));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@version", ParameterDirection.Input, version));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T sp_renamediagram<T>(string diagramname, string new_diagramname, int? owner_id) where T : SqlResponse
		{
			var request = new SqlRequest("dbo", "sp_renamediagram");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@diagramname", ParameterDirection.Input, diagramname));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@new_diagramname", ParameterDirection.Input, new_diagramname));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@owner_id", ParameterDirection.Input, owner_id));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T sp_alterdiagram<T>(byte[] definition, string diagramname, int? owner_id, int? version) where T : SqlResponse
		{
			var request = new SqlRequest("dbo", "sp_alterdiagram");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@definition", ParameterDirection.Input, definition));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@diagramname", ParameterDirection.Input, diagramname));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@owner_id", ParameterDirection.Input, owner_id));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@version", ParameterDirection.Input, version));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T sp_dropdiagram<T>(string diagramname, int? owner_id) where T : SqlResponse
		{
			var request = new SqlRequest("dbo", "sp_dropdiagram");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@diagramname", ParameterDirection.Input, diagramname));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@owner_id", ParameterDirection.Input, owner_id));
			var result = _executor.Execute<T>(request);
			return result;
		}
	}

	public class Help : IHelp
	{
		private ISqlExecutor _executor;
		public Help(ISqlExecutor executor)
		{
			_executor = executor;
		}

		public T csp_HelpLink_s01<T>(DateTime DatumActief, string LinkCode, string Username) where T : SqlResponse
		{
			var request = new SqlRequest("Help", "csp_HelpLink_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DatumActief", ParameterDirection.Input, DatumActief));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@LinkCode", ParameterDirection.Input, LinkCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Username", ParameterDirection.Input, Username));
			var result = _executor.Execute<T>(request);
			return result;
		}
	}

	public class Logs : ILogs
	{
		private ISqlExecutor _executor;
		public Logs(ISqlExecutor executor)
		{
			_executor = executor;
		}

		public T csp_OnderhandelingStatusLog_i01<T>(string ActieReden, int? AfspraakId, string BevestigingsTekst, string GewijzigdDoor) where T : SqlResponse
		{
			var request = new SqlRequest("Logs", "csp_OnderhandelingStatusLog_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ActieReden", ParameterDirection.Input, ActieReden));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakId", ParameterDirection.Input, AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BevestigingsTekst", ParameterDirection.Input, BevestigingsTekst));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GewijzigdDoor", ParameterDirection.Input, GewijzigdDoor));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingStatusLog_s01<T>(int? AfspraakId) where T : SqlResponse
		{
			var request = new SqlRequest("Logs", "csp_OnderhandelingStatusLog_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakId", ParameterDirection.Input, AfspraakId));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingStatusLog_s02<T>(int? AfspraakId) where T : SqlResponse
		{
			var request = new SqlRequest("Logs", "csp_OnderhandelingStatusLog_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakId", ParameterDirection.Input, AfspraakId));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingStatusLog_s03<T>(int? EersteOnderhandelingId) where T : SqlResponse
		{
			var request = new SqlRequest("Logs", "csp_OnderhandelingStatusLog_s03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@EersteOnderhandelingId", ParameterDirection.Input, EersteOnderhandelingId));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_log4netentries_s01<T>(string p_Application, DateTime p_DateEnd, DateTime p_DateStart, string p_Identity, bool? p_isTechnical, string p_Level) where T : SqlResponse
		{
			var request = new SqlRequest("Logs", "csp_log4netentries_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Application", ParameterDirection.Input, p_Application));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_DateEnd", ParameterDirection.Input, p_DateEnd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_DateStart", ParameterDirection.Input, p_DateStart));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Identity", ParameterDirection.Input, p_Identity));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_isTechnical", ParameterDirection.Input, p_isTechnical));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_Level", ParameterDirection.Input, p_Level));
			var result = _executor.Execute<T>(request);
			return result;
		}
	}

	public class Organisatie : IOrganisatie
	{
		private ISqlExecutor _executor;
		public Organisatie(ISqlExecutor executor)
		{
			_executor = executor;
		}

		public T csp_Rol_s02<T>(int? GebruikerID) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Rol_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GebruikerID", ParameterDirection.Input, GebruikerID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_GebruikerRol_d00<T>(int? GebruikerID, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> ZorgSoortIds) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_GebruikerRol_d00");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GebruikerID", ParameterDirection.Input, GebruikerID));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@ZorgSoortIds", ParameterDirection.Input, "Overig", "udtIntTable", ZorgSoortIds));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Gebruiker_s14<T>(int? InstantieID, bool? ToonVoorgesteldeKoppelingen) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Gebruiker_s14");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", ParameterDirection.Input, InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ToonVoorgesteldeKoppelingen", ParameterDirection.Input, ToonVoorgesteldeKoppelingen));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Gebruiker_s03<T>(string CommonName) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Gebruiker_s03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CommonName", ParameterDirection.Input, CommonName));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_GebruikerInstantie_d02<T>(int? GebruikerId, int? InstantieID, ref int? RemainingInstantieCount) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_GebruikerInstantie_d02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GebruikerId", ParameterDirection.Input, GebruikerId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", ParameterDirection.Input, InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@RemainingInstantieCount", ParameterDirection.InputOutput, RemainingInstantieCount));
			var result = _executor.Execute<T>(request);
			RemainingInstantieCount = (int?)request.GetParameterValue("@RemainingInstantieCount");
			return result;
		}

		public T csp_Gebruiker_s01<T>(string CommonName, int? GebruikerID, bool? InclusiefNietGeaccepteerd) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Gebruiker_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CommonName", ParameterDirection.Input, CommonName));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GebruikerID", ParameterDirection.Input, GebruikerID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InclusiefNietGeaccepteerd", ParameterDirection.Input, InclusiefNietGeaccepteerd));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_GebruikerInstantie_s02<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_GebruikerInstantie_s02");
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Gebruiker_s04<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Gebruiker_s04");
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_GebruikerInstantie_u01<T>(int? GebruikerId, int? InstantieID, int? KoppelingGeaccepteerdDoor) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_GebruikerInstantie_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GebruikerId", ParameterDirection.Input, GebruikerId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", ParameterDirection.Input, InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@KoppelingGeaccepteerdDoor", ParameterDirection.Input, KoppelingGeaccepteerdDoor));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Gebruiker_s07<T>(string CommonName, DateTime totDatum, DateTime vanDatum, int? ZorgSoort) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Gebruiker_s07");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CommonName", ParameterDirection.Input, CommonName));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@totDatum", ParameterDirection.Input, totDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@vanDatum", ParameterDirection.Input, vanDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgSoort", ParameterDirection.Input, ZorgSoort));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Gebruiker_s08<T>(string CommonName, DateTime totDatum, DateTime vanDatum, int? zorgSoort) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Gebruiker_s08");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CommonName", ParameterDirection.Input, CommonName));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@totDatum", ParameterDirection.Input, totDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@vanDatum", ParameterDirection.Input, vanDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@zorgSoort", ParameterDirection.Input, zorgSoort));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Gebruiker_i01<T>(string Achternaam, string CommonName, string CreateUser, string Email, string Tussenvoegsel, string Voorletters) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Gebruiker_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Achternaam", ParameterDirection.Input, Achternaam));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CommonName", ParameterDirection.Input, CommonName));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CreateUser", ParameterDirection.Input, CreateUser));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Email", ParameterDirection.Input, Email));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Tussenvoegsel", ParameterDirection.Input, Tussenvoegsel));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Voorletters", ParameterDirection.Input, Voorletters));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_GebruikerInstantie_i01<T>(string CreateUser, int? GebruikerID, int? InstantieID, int? KoppelingVoorgesteldDoor) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_GebruikerInstantie_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CreateUser", ParameterDirection.Input, CreateUser));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GebruikerID", ParameterDirection.Input, GebruikerID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", ParameterDirection.Input, InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@KoppelingVoorgesteldDoor", ParameterDirection.Input, KoppelingVoorgesteldDoor));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Instantie_s01<T>(int? InstantieTypeID) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Instantie_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieTypeID", ParameterDirection.Input, InstantieTypeID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_InstantieType_s00<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_InstantieType_s00");
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_AGBSoort_s01<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_AGBSoort_s01");
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Zorgverzekeraar_s02<T>(string UZOVI) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Zorgverzekeraar_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@UZOVI", ParameterDirection.Input, UZOVI));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Gebruiker_s11<T>(bool? InclusiefNietGeaccepteerd, int? InstantieID) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Gebruiker_s11");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InclusiefNietGeaccepteerd", ParameterDirection.Input, InclusiefNietGeaccepteerd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", ParameterDirection.Input, InstantieID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Gebruiker_s13<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Gebruiker_s13");
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Zorgverzekeraar_s10<T>(DateTime totDatum, DateTime vanDatum, int? zorgSoort) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Zorgverzekeraar_s10");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@totDatum", ParameterDirection.Input, totDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@vanDatum", ParameterDirection.Input, vanDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@zorgSoort", ParameterDirection.Input, zorgSoort));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Gebruiker_u02<T>(string Achternaam, string Email, int? GebruikerID, bool? InActief, string Tussenvoegsel, string UpdateUser, string Voorletters) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Gebruiker_u02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Achternaam", ParameterDirection.Input, Achternaam));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Email", ParameterDirection.Input, Email));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GebruikerID", ParameterDirection.Input, GebruikerID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InActief", ParameterDirection.Input, InActief));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Tussenvoegsel", ParameterDirection.Input, Tussenvoegsel));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@UpdateUser", ParameterDirection.Input, UpdateUser));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Voorletters", ParameterDirection.Input, Voorletters));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Provincie_s01<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Provincie_s01");
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_GebruikerInstantie_d01<T>(string GebruikerIds, int? InstantieID) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_GebruikerInstantie_d01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GebruikerIds", ParameterDirection.Input, GebruikerIds));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", ParameterDirection.Input, InstantieID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_GebruikerInstantie_s01<T>(int? InstantieID) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_GebruikerInstantie_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", ParameterDirection.Input, InstantieID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Zorgverstrekker_s11<T>(int? ZorgverstrekkerID) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Zorgverstrekker_s11");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgverstrekkerID", ParameterDirection.Input, ZorgverstrekkerID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Zorgverstrekker_s06<T>(DateTime totDatum, DateTime vanDatum, int? zorgSoort) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Zorgverstrekker_s06");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@totDatum", ParameterDirection.Input, totDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@vanDatum", ParameterDirection.Input, vanDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@zorgSoort", ParameterDirection.Input, zorgSoort));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_GebruikerRol_s01<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_GebruikerRol_s01");
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Instanties_s01<T>(int? InstantieID) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Instanties_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", ParameterDirection.Input, InstantieID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Regio_s01<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Regio_s01");
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Rol_s03<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Rol_s03");
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Zorgverstrekker_s01<T>(string p_AGB, string p_AGBSoort, int? p_CTGCategorie, int? p_CTGNummer) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Zorgverstrekker_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AGB", ParameterDirection.Input, p_AGB));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AGBSoort", ParameterDirection.Input, p_AGBSoort));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_CTGCategorie", ParameterDirection.Input, p_CTGCategorie));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_CTGNummer", ParameterDirection.Input, p_CTGNummer));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Settings_i01<T>(int? InstantieID, string SettingName, string SettingValue, int? ZorgSoortID) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Settings_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", ParameterDirection.Input, InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SettingName", ParameterDirection.Input, SettingName));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SettingValue", ParameterDirection.Input, SettingValue));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgSoortID", ParameterDirection.Input, ZorgSoortID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Settings_s01<T>(int? InstantieID, string SettingName, int? ZorgSoortID) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Settings_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", ParameterDirection.Input, InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@SettingName", ParameterDirection.Input, SettingName));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgSoortID", ParameterDirection.Input, ZorgSoortID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Zorgverstrekker_u01<T>(string Adres, string AGB, string AGBSoort, int? CTGCategorie, int? CTGNummer, string Email, int? ID, bool? Inactief, bool? IsHoofdLocatie, string Naam, string Plaats, string Postcode, string Telefoonnummer, string UpdateUser, string Website) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Zorgverstrekker_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Adres", ParameterDirection.Input, Adres));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AGB", ParameterDirection.Input, AGB));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AGBSoort", ParameterDirection.Input, AGBSoort));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CTGCategorie", ParameterDirection.Input, CTGCategorie));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CTGNummer", ParameterDirection.Input, CTGNummer));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Email", ParameterDirection.Input, Email));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ID", ParameterDirection.Input, ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Inactief", ParameterDirection.Input, Inactief));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@IsHoofdLocatie", ParameterDirection.Input, IsHoofdLocatie));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Naam", ParameterDirection.Input, Naam));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Plaats", ParameterDirection.Input, Plaats));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Postcode", ParameterDirection.Input, Postcode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Telefoonnummer", ParameterDirection.Input, Telefoonnummer));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@UpdateUser", ParameterDirection.Input, UpdateUser));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Website", ParameterDirection.Input, Website));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Zorgverzekeraar_u01<T>(int? ID, string Naam, string UpdateUser, string UZOVI, string Website) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Zorgverzekeraar_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ID", ParameterDirection.Input, ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Naam", ParameterDirection.Input, Naam));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@UpdateUser", ParameterDirection.Input, UpdateUser));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@UZOVI", ParameterDirection.Input, UZOVI));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Website", ParameterDirection.Input, Website));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Gebruiker_s09<T>(string VecozoCertificaatNummer) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Gebruiker_s09");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@VecozoCertificaatNummer", ParameterDirection.Input, VecozoCertificaatNummer));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Instantie_s02<T>(int? InstantieID) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Instantie_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", ParameterDirection.Input, InstantieID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_GebruikerContactPersoon_s01<T>(bool? IncludeDBCSUsers, int? InstantieID, int? ZorgsoortID) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_GebruikerContactPersoon_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@IncludeDBCSUsers", ParameterDirection.Input, IncludeDBCSUsers));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", ParameterDirection.Input, InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgsoortID", ParameterDirection.Input, ZorgsoortID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Zorgverstrekker_s13<T>(string p_AGBParent) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Zorgverstrekker_s13");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AGBParent", ParameterDirection.Input, p_AGBParent));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_GebruikerRol_u01<T>(string CreateUser, int? GebruikerID, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> teOntnemenRolIDs, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> toeTeKennenRolIDs, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> ZorgSoortIds) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_GebruikerRol_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CreateUser", ParameterDirection.Input, CreateUser));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GebruikerID", ParameterDirection.Input, GebruikerID));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@teOntnemenRolIDs", ParameterDirection.Input, "Overig", "udtIntTable", teOntnemenRolIDs));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@toeTeKennenRolIDs", ParameterDirection.Input, "Overig", "udtIntTable", toeTeKennenRolIDs));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@ZorgSoortIds", ParameterDirection.Input, "Overig", "udtIntTable", ZorgSoortIds));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Gebruiker_s05<T>(string CommonName, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> ZorgSoorten) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Gebruiker_s05");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CommonName", ParameterDirection.Input, CommonName));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@ZorgSoorten", ParameterDirection.Input, "Overig", "udtIntTable", ZorgSoorten));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Taak_s01<T>(int? GebruikerID) where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Taak_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@GebruikerID", ParameterDirection.Input, GebruikerID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Rol_s01<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Organisatie", "csp_Rol_s01");
			var result = _executor.Execute<T>(request);
			return result;
		}
	}

	public class Overig : IOverig
	{
		private ISqlExecutor _executor;
		public Overig(ISqlExecutor executor)
		{
			_executor = executor;
		}

		public T csp_Automodellen_i02<T>(DateTime datumMax, DateTime datumMin, string uzovi) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_Automodellen_i02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMax", ParameterDirection.Input, datumMax));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMin", ParameterDirection.Input, datumMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@uzovi", ParameterDirection.Input, uzovi));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Export_i01<T>(string AGB, string AGBSoort, bool? AlleenWijzigingen, DateTime BereikTot, DateTime BereikVan, string CategorieIds, string ExportIndicator, int? exportType, int? fileType, int? HistorischJaartal, ref int? identity, bool? InclActueleContracten, bool? InclNietSpeerpunten, bool? InclSpeerpunten, bool? InclVervallenContracten, string Inhoud, bool? isNOW, decimal? PrijsZKHMin, string referentie, DateTime wijzigingenVanaf, string ZorgproductCode, int? ZVZ_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_Export_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AGB", ParameterDirection.Input, AGB));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AGBSoort", ParameterDirection.Input, AGBSoort));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AlleenWijzigingen", ParameterDirection.Input, AlleenWijzigingen));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BereikTot", ParameterDirection.Input, BereikTot));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BereikVan", ParameterDirection.Input, BereikVan));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CategorieIds", ParameterDirection.Input, CategorieIds));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ExportIndicator", ParameterDirection.Input, ExportIndicator));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@exportType", ParameterDirection.Input, exportType));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@fileType", ParameterDirection.Input, fileType));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@HistorischJaartal", ParameterDirection.Input, HistorischJaartal));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@identity", ParameterDirection.InputOutput, identity));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InclActueleContracten", ParameterDirection.Input, InclActueleContracten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InclNietSpeerpunten", ParameterDirection.Input, InclNietSpeerpunten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InclSpeerpunten", ParameterDirection.Input, InclSpeerpunten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InclVervallenContracten", ParameterDirection.Input, InclVervallenContracten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Inhoud", ParameterDirection.Input, Inhoud));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@isNOW", ParameterDirection.Input, isNOW));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@PrijsZKHMin", ParameterDirection.Input, PrijsZKHMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@referentie", ParameterDirection.Input, referentie));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@wijzigingenVanaf", ParameterDirection.Input, wijzigingenVanaf));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZorgproductCode", ParameterDirection.Input, ZorgproductCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVZ_ID", ParameterDirection.Input, ZVZ_ID));
			var result = _executor.Execute<T>(request);
			identity = (int?)request.GetParameterValue("@identity");
			return result;
		}

		public T csp_Export_i02<T>(int? exportType, int? fileType, int? HistorischJaartal, ref int? identity, string referentie, int? ZVZ_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_Export_i02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@exportType", ParameterDirection.Input, exportType));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@fileType", ParameterDirection.Input, fileType));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@HistorischJaartal", ParameterDirection.Input, HistorischJaartal));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@identity", ParameterDirection.InputOutput, identity));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@referentie", ParameterDirection.Input, referentie));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVZ_ID", ParameterDirection.Input, ZVZ_ID));
			var result = _executor.Execute<T>(request);
			identity = (int?)request.GetParameterValue("@identity");
			return result;
		}

		public T csp_Export_s01<T>(int? ZVZ_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_Export_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVZ_ID", ParameterDirection.Input, ZVZ_ID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Export_s02<T>(int? ExportID) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_Export_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ExportID", ParameterDirection.Input, ExportID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ExportFileType_s01<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_ExportFileType_s01");
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_RecordType34_s01<T>(bool? alleenWijzigingen, DateTime datumMax, DateTime datumMin, bool? inclActueleContracten, bool? inclVervallenContracten, IEnumerable<Database.UserDefinedTypes.Afspraak.udtInstantiePeriodeTable> nietTeExporterenZorgverstrekkers, decimal? prijsZKHMin, string uzovi, DateTime wijzigingenVanaf) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_RecordType34_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@alleenWijzigingen", ParameterDirection.Input, alleenWijzigingen));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMax", ParameterDirection.Input, datumMax));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMin", ParameterDirection.Input, datumMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclActueleContracten", ParameterDirection.Input, inclActueleContracten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclVervallenContracten", ParameterDirection.Input, inclVervallenContracten));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@nietTeExporterenZorgverstrekkers", ParameterDirection.Input, "Afspraak", "udtInstantiePeriodeTable", nietTeExporterenZorgverstrekkers));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@prijsZKHMin", ParameterDirection.Input, prijsZKHMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@uzovi", ParameterDirection.Input, uzovi));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@wijzigingenVanaf", ParameterDirection.Input, wijzigingenVanaf));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ExportType_s01<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_ExportType_s01");
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_RecordTypeDatadump_s02<T>(string agb, string agbSoort, bool? inclContracten, bool? inclNietSpeerpunten, bool? inclOnderhandelingen, bool? inclSpeerpunten, DateTime peildatum, string uzovi, string zorgproductCode, int? zvsCategorie) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_RecordTypeDatadump_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@agb", ParameterDirection.Input, agb));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@agbSoort", ParameterDirection.Input, agbSoort));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclContracten", ParameterDirection.Input, inclContracten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclNietSpeerpunten", ParameterDirection.Input, inclNietSpeerpunten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclOnderhandelingen", ParameterDirection.Input, inclOnderhandelingen));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclSpeerpunten", ParameterDirection.Input, inclSpeerpunten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@peildatum", ParameterDirection.Input, peildatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@uzovi", ParameterDirection.Input, uzovi));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@zorgproductCode", ParameterDirection.Input, zorgproductCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@zvsCategorie", ParameterDirection.Input, zvsCategorie));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_RecordTypeCZ_s01<T>(int? CON_ID, DateTime wijzigingenVanaf) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_RecordTypeCZ_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CON_ID", ParameterDirection.Input, CON_ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@wijzigingenVanaf", ParameterDirection.Input, wijzigingenVanaf));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Export_s03<T>(string UZOVI) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_Export_s03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@UZOVI", ParameterDirection.Input, UZOVI));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_RecordTypeMZ_s02<T>(DateTime datumMax, DateTime datumMin, string uzovi, DateTime wijzigingenVanaf) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_RecordTypeMZ_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMax", ParameterDirection.Input, datumMax));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMin", ParameterDirection.Input, datumMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@uzovi", ParameterDirection.Input, uzovi));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@wijzigingenVanaf", ParameterDirection.Input, wijzigingenVanaf));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_RecordTypeDatadump_s01<T>(string agbSoort, DateTime datumMax, DateTime datumMin, bool? inclContracten, bool? inclOnderhandelingen, string uzovi, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> zvsCategorieen) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_RecordTypeDatadump_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@agbSoort", ParameterDirection.Input, agbSoort));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMax", ParameterDirection.Input, datumMax));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMin", ParameterDirection.Input, datumMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclContracten", ParameterDirection.Input, inclContracten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclOnderhandelingen", ParameterDirection.Input, inclOnderhandelingen));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@uzovi", ParameterDirection.Input, uzovi));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@zvsCategorieen", ParameterDirection.Input, "Overig", "udtIntTable", zvsCategorieen));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_TogImportBatchLog_i01<T>(DateTime ImportDatum, bool? IsIncrementeel, ref int? TogImportBatchLogID, int? TogProductieNummer, int? VersienummerBestand) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_TogImportBatchLog_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ImportDatum", ParameterDirection.Input, ImportDatum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@IsIncrementeel", ParameterDirection.Input, IsIncrementeel));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@TogImportBatchLogID", ParameterDirection.InputOutput, TogImportBatchLogID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@TogProductieNummer", ParameterDirection.Input, TogProductieNummer));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@VersienummerBestand", ParameterDirection.Input, VersienummerBestand));
			var result = _executor.Execute<T>(request);
			TogImportBatchLogID = (int?)request.GetParameterValue("@TogImportBatchLogID");
			return result;
		}

		public T csp_SchemaChangeLog_s01<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_SchemaChangeLog_s01");
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_TogImportBatchLog_s01<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_TogImportBatchLog_s01");
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_TogImportBatchLog_u01<T>(int? AantalRecordsAangepast, int? AantalRecordsToegevoegd, int? AantalRecordsVerwijderd, string Melding, int? Status, string StatusInfo, int? TogImportBatchLogID) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_TogImportBatchLog_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AantalRecordsAangepast", ParameterDirection.Input, AantalRecordsAangepast));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AantalRecordsToegevoegd", ParameterDirection.Input, AantalRecordsToegevoegd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AantalRecordsVerwijderd", ParameterDirection.Input, AantalRecordsVerwijderd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Melding", ParameterDirection.Input, Melding));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Status", ParameterDirection.Input, Status));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@StatusInfo", ParameterDirection.Input, StatusInfo));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@TogImportBatchLogID", ParameterDirection.Input, TogImportBatchLogID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_TogImportLog_i01<T>(DateTime Datum, ref int? Identity, int? ImportGeschiedenisID, string Omschrijving, int? TogRecordType) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_TogImportLog_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Datum", ParameterDirection.Input, Datum));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Identity", ParameterDirection.InputOutput, Identity));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ImportGeschiedenisID", ParameterDirection.Input, ImportGeschiedenisID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Omschrijving", ParameterDirection.Input, Omschrijving));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@TogRecordType", ParameterDirection.Input, TogRecordType));
			var result = _executor.Execute<T>(request);
			Identity = (int?)request.GetParameterValue("@Identity");
			return result;
		}

		public T csp_Automodellen_i01<T>(DateTime datumMax, DateTime datumMin, string uzovi) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_Automodellen_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMax", ParameterDirection.Input, datumMax));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMin", ParameterDirection.Input, datumMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@uzovi", ParameterDirection.Input, uzovi));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_DisclaimerGetoond_i01<T>(int? AfspraakID, ref bool? Toegevoegd, string Username) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_DisclaimerGetoond_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Toegevoegd", ParameterDirection.InputOutput, Toegevoegd));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Username", ParameterDirection.Input, Username));
			var result = _executor.Execute<T>(request);
			Toegevoegd = (bool?)request.GetParameterValue("@Toegevoegd");
			return result;
		}

		public T csp_DisclaimerGetoond_s01<T>(int? AfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_DisclaimerGetoond_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_RecordTypeCZ_S02<T>(bool? alleenWijzigingen, DateTime datumMax, DateTime datumMin, bool? inclActueleContracten, bool? inclVervallenContracten, IEnumerable<Database.UserDefinedTypes.Afspraak.udtInstantiePeriodeTable> nietTeExporterenZorgverstrekkers, decimal? prijsZKHMin, string uzovi, DateTime wijzigingenVanaf) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_RecordTypeCZ_S02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@alleenWijzigingen", ParameterDirection.Input, alleenWijzigingen));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMax", ParameterDirection.Input, datumMax));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMin", ParameterDirection.Input, datumMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclActueleContracten", ParameterDirection.Input, inclActueleContracten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclVervallenContracten", ParameterDirection.Input, inclVervallenContracten));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@nietTeExporterenZorgverstrekkers", ParameterDirection.Input, "Afspraak", "udtInstantiePeriodeTable", nietTeExporterenZorgverstrekkers));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@prijsZKHMin", ParameterDirection.Input, prijsZKHMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@uzovi", ParameterDirection.Input, uzovi));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@wijzigingenVanaf", ParameterDirection.Input, wijzigingenVanaf));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_RecordTypeCZ_S03<T>(bool? alleenWijzigingen, DateTime datumMax, DateTime datumMin, bool? inclActueleContracten, bool? inclVervallenContracten, IEnumerable<Database.UserDefinedTypes.Afspraak.udtInstantiePeriodeTable> nietTeExporterenZorgverstrekkers, decimal? prijsZKHMin, string uzovi, DateTime wijzigingenVanaf) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_RecordTypeCZ_S03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@alleenWijzigingen", ParameterDirection.Input, alleenWijzigingen));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMax", ParameterDirection.Input, datumMax));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMin", ParameterDirection.Input, datumMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclActueleContracten", ParameterDirection.Input, inclActueleContracten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclVervallenContracten", ParameterDirection.Input, inclVervallenContracten));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@nietTeExporterenZorgverstrekkers", ParameterDirection.Input, "Afspraak", "udtInstantiePeriodeTable", nietTeExporterenZorgverstrekkers));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@prijsZKHMin", ParameterDirection.Input, prijsZKHMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@uzovi", ParameterDirection.Input, uzovi));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@wijzigingenVanaf", ParameterDirection.Input, wijzigingenVanaf));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_RecordTypeCZ_S04<T>(bool? alleenWijzigingen, DateTime datumMax, DateTime datumMin, bool? inclActueleContracten, bool? inclVervallenContracten, IEnumerable<Database.UserDefinedTypes.Afspraak.udtInstantiePeriodeTable> nietTeExporterenZorgverstrekkers, decimal? prijsZKHMin, string uzovi, DateTime wijzigingenVanaf) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_RecordTypeCZ_S04");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@alleenWijzigingen", ParameterDirection.Input, alleenWijzigingen));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMax", ParameterDirection.Input, datumMax));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMin", ParameterDirection.Input, datumMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclActueleContracten", ParameterDirection.Input, inclActueleContracten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclVervallenContracten", ParameterDirection.Input, inclVervallenContracten));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@nietTeExporterenZorgverstrekkers", ParameterDirection.Input, "Afspraak", "udtInstantiePeriodeTable", nietTeExporterenZorgverstrekkers));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@prijsZKHMin", ParameterDirection.Input, prijsZKHMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@uzovi", ParameterDirection.Input, uzovi));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@wijzigingenVanaf", ParameterDirection.Input, wijzigingenVanaf));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_RecordTypeCZ_S05<T>(bool? alleenWijzigingen, DateTime datumMax, DateTime datumMin, bool? inclActueleContracten, bool? inclVervallenContracten, IEnumerable<Database.UserDefinedTypes.Afspraak.udtInstantiePeriodeTable> nietTeExporterenZorgverstrekkers, decimal? prijsZKHMin, string uzovi, DateTime wijzigingenVanaf) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_RecordTypeCZ_S05");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@alleenWijzigingen", ParameterDirection.Input, alleenWijzigingen));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMax", ParameterDirection.Input, datumMax));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMin", ParameterDirection.Input, datumMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclActueleContracten", ParameterDirection.Input, inclActueleContracten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclVervallenContracten", ParameterDirection.Input, inclVervallenContracten));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@nietTeExporterenZorgverstrekkers", ParameterDirection.Input, "Afspraak", "udtInstantiePeriodeTable", nietTeExporterenZorgverstrekkers));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@prijsZKHMin", ParameterDirection.Input, prijsZKHMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@uzovi", ParameterDirection.Input, uzovi));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@wijzigingenVanaf", ParameterDirection.Input, wijzigingenVanaf));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_RecordTypeMenzisCsv_s01<T>(int? CON_ID, DateTime wijzigingenVanaf) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_RecordTypeMenzisCsv_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CON_ID", ParameterDirection.Input, CON_ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@wijzigingenVanaf", ParameterDirection.Input, wijzigingenVanaf));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_RecordType45_s03<T>(int? jaartalMax, int? jaartalMin, string uzovi, DateTime wijzigingenVanaf) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_RecordType45_s03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@jaartalMax", ParameterDirection.Input, jaartalMax));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@jaartalMin", ParameterDirection.Input, jaartalMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@uzovi", ParameterDirection.Input, uzovi));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@wijzigingenVanaf", ParameterDirection.Input, wijzigingenVanaf));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_RecordType45_s01<T>(int? jaartal, string uzovi, DateTime wijzigingenVanaf) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_RecordType45_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@jaartal", ParameterDirection.Input, jaartal));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@uzovi", ParameterDirection.Input, uzovi));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@wijzigingenVanaf", ParameterDirection.Input, wijzigingenVanaf));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_RecordTypeMZ_S01<T>(DateTime datumMax, DateTime datumMin, string uzovi, DateTime wijzigingenVanaf) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_RecordTypeMZ_S01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMax", ParameterDirection.Input, datumMax));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMin", ParameterDirection.Input, datumMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@uzovi", ParameterDirection.Input, uzovi));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@wijzigingenVanaf", ParameterDirection.Input, wijzigingenVanaf));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Export_u01<T>(int? exportStatus, string fileName, int? ID) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_Export_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@exportStatus", ParameterDirection.Input, exportStatus));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@fileName", ParameterDirection.Input, fileName));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ID", ParameterDirection.Input, ID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Export_u02<T>(string FileType, int? ID, int? ZVZ_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_Export_u02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@FileType", ParameterDirection.Input, FileType));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ID", ParameterDirection.Input, ID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVZ_ID", ParameterDirection.Input, ZVZ_ID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ExportPeriode_s01<T>(bool? alleenWijzigingen, DateTime datumMax, DateTime datumMin, bool? inclActueleContracten, bool? inclVervallenContracten, IEnumerable<Database.UserDefinedTypes.Afspraak.udtInstantiePeriodeTable> nietTeExporterenZorgverstrekkers, decimal? prijsZKHMin, string uzovi, DateTime wijzigingenVanaf) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_ExportPeriode_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@alleenWijzigingen", ParameterDirection.Input, alleenWijzigingen));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMax", ParameterDirection.Input, datumMax));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMin", ParameterDirection.Input, datumMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclActueleContracten", ParameterDirection.Input, inclActueleContracten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclVervallenContracten", ParameterDirection.Input, inclVervallenContracten));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@nietTeExporterenZorgverstrekkers", ParameterDirection.Input, "Afspraak", "udtInstantiePeriodeTable", nietTeExporterenZorgverstrekkers));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@prijsZKHMin", ParameterDirection.Input, prijsZKHMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@uzovi", ParameterDirection.Input, uzovi));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@wijzigingenVanaf", ParameterDirection.Input, wijzigingenVanaf));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ExportPeriode_u01<T>(bool? alleenWijzigingen, DateTime datumMax, DateTime datumMin, bool? inclActueleContracten, bool? inclVervallenContracten, IEnumerable<Database.UserDefinedTypes.Afspraak.udtInstantiePeriodeTable> nietTeExporterenZorgverstrekkers, decimal? prijsZKHMin, string uzovi, DateTime wijzigingenVanaf) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_ExportPeriode_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@alleenWijzigingen", ParameterDirection.Input, alleenWijzigingen));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMax", ParameterDirection.Input, datumMax));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@datumMin", ParameterDirection.Input, datumMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclActueleContracten", ParameterDirection.Input, inclActueleContracten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclVervallenContracten", ParameterDirection.Input, inclVervallenContracten));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@nietTeExporterenZorgverstrekkers", ParameterDirection.Input, "Afspraak", "udtInstantiePeriodeTable", nietTeExporterenZorgverstrekkers));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@prijsZKHMin", ParameterDirection.Input, prijsZKHMin));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@uzovi", ParameterDirection.Input, uzovi));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@wijzigingenVanaf", ParameterDirection.Input, wijzigingenVanaf));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Export_i03<T>(int? exportType, int? fileType, ref int? identity, string referentie, int? ZVZ_ID) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_Export_i03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@exportType", ParameterDirection.Input, exportType));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@fileType", ParameterDirection.Input, fileType));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@identity", ParameterDirection.InputOutput, identity));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@referentie", ParameterDirection.Input, referentie));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ZVZ_ID", ParameterDirection.Input, ZVZ_ID));
			var result = _executor.Execute<T>(request);
			identity = (int?)request.GetParameterValue("@identity");
			return result;
		}

		public T csp_Export_d01<T>(int? ExportID) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_Export_d01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ExportID", ParameterDirection.Input, ExportID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_RecordTypeAchmeaTIMIntegraal_s01<T>(string AgbSoort, DateTime DatumTot, DateTime DatumVanaf, string Uzovi) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_RecordTypeAchmeaTIMIntegraal_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AgbSoort", ParameterDirection.Input, AgbSoort));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DatumTot", ParameterDirection.Input, DatumTot));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DatumVanaf", ParameterDirection.Input, DatumVanaf));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Uzovi", ParameterDirection.Input, Uzovi));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_BijlageType_s01<T>() where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_BijlageType_s01");
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_RecordTypeAchmeaTIM_s01<T>(string AgbSoort, DateTime DatumTot, DateTime DatumVanaf, string Uzovi) where T : SqlResponse
		{
			var request = new SqlRequest("Overig", "csp_RecordTypeAchmeaTIM_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AgbSoort", ParameterDirection.Input, AgbSoort));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DatumTot", ParameterDirection.Input, DatumTot));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@DatumVanaf", ParameterDirection.Input, DatumVanaf));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Uzovi", ParameterDirection.Input, Uzovi));
			var result = _executor.Execute<T>(request);
			return result;
		}
	}

	public class Rapportage : IRapportage
	{
		private ISqlExecutor _executor;
		public Rapportage(ISqlExecutor executor)
		{
			_executor = executor;
		}

		public T csp_Prijsvergelijking_s01<T>(string agb, bool? inclNietSpeerpunten, bool? inclSpeerpunten, int? rapportageJaar, ref bool? rapportageNotFound, int? referentieJaar, ref bool? referentieNotFound, int? zorgverzekeraarId) where T : SqlResponse
		{
			var request = new SqlRequest("Rapportage", "csp_Prijsvergelijking_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@agb", ParameterDirection.Input, agb));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclNietSpeerpunten", ParameterDirection.Input, inclNietSpeerpunten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@inclSpeerpunten", ParameterDirection.Input, inclSpeerpunten));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@rapportageJaar", ParameterDirection.Input, rapportageJaar));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@rapportageNotFound", ParameterDirection.InputOutput, rapportageNotFound));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@referentieJaar", ParameterDirection.Input, referentieJaar));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@referentieNotFound", ParameterDirection.InputOutput, referentieNotFound));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@zorgverzekeraarId", ParameterDirection.Input, zorgverzekeraarId));
			var result = _executor.Execute<T>(request);
			rapportageNotFound = (bool?)request.GetParameterValue("@rapportageNotFound");
			referentieNotFound = (bool?)request.GetParameterValue("@referentieNotFound");
			return result;
		}

		public T csp_OverzichtContracten_s01<T>(int? InstantieID) where T : SqlResponse
		{
			var request = new SqlRequest("Rapportage", "csp_OverzichtContracten_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", ParameterDirection.Input, InstantieID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OverzichtOnderhandelingen_s01<T>(int? InstantieID) where T : SqlResponse
		{
			var request = new SqlRequest("Rapportage", "csp_OverzichtOnderhandelingen_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", ParameterDirection.Input, InstantieID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_Voortgang_s01<T>(int? InstantieID, DateTime peildatum_1, DateTime peildatum_2) where T : SqlResponse
		{
			var request = new SqlRequest("Rapportage", "csp_Voortgang_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@InstantieID", ParameterDirection.Input, InstantieID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@peildatum_1", ParameterDirection.Input, peildatum_1));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@peildatum_2", ParameterDirection.Input, peildatum_2));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ModelAfspraak_s01<T>(int? Zorgverzekeraar) where T : SqlResponse
		{
			var request = new SqlRequest("Rapportage", "csp_ModelAfspraak_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Zorgverzekeraar", ParameterDirection.Input, Zorgverzekeraar));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_SjabloonPeriode_s01<T>(int? Zorgverzekeraar) where T : SqlResponse
		{
			var request = new SqlRequest("Rapportage", "csp_SjabloonPeriode_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Zorgverzekeraar", ParameterDirection.Input, Zorgverzekeraar));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_SpeerpuntPeriode_s01<T>(int? Zorgverzekeraar) where T : SqlResponse
		{
			var request = new SqlRequest("Rapportage", "csp_SpeerpuntPeriode_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Zorgverzekeraar", ParameterDirection.Input, Zorgverzekeraar));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ScoreSpeerpunten_s01<T>(int? CategorieId, int? Inhoud, int? ModelAfspraak, int? Niveau, int? Periode, int? RegioId, int? Speerpunt, int? Zorgverzekeraar) where T : SqlResponse
		{
			var request = new SqlRequest("Rapportage", "csp_ScoreSpeerpunten_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@CategorieId", ParameterDirection.Input, CategorieId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Inhoud", ParameterDirection.Input, Inhoud));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ModelAfspraak", ParameterDirection.Input, ModelAfspraak));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Niveau", ParameterDirection.Input, Niveau));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Periode", ParameterDirection.Input, Periode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@RegioId", ParameterDirection.Input, RegioId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Speerpunt", ParameterDirection.Input, Speerpunt));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@Zorgverzekeraar", ParameterDirection.Input, Zorgverzekeraar));
			var result = _executor.Execute<T>(request);
			return result;
		}
	}

	public class Tarief : ITarief
	{
		private ISqlExecutor _executor;
		public Tarief(ISqlExecutor executor)
		{
			_executor = executor;
		}

		public T csp_ContractExport_s01<T>(int? AfspraakID, bool? AlleTarieven) where T : SqlResponse
		{
			var request = new SqlRequest("Tarief", "csp_ContractExport_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AlleTarieven", ParameterDirection.Input, AlleTarieven));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_CreateModelContractFromOnderhandeling<T>(int? p_AfspraakID, int? p_InstantieType, ref int? p_ModelAfspraakID, string p_ModelCode, string p_ModelOmschrijving) where T : SqlResponse
		{
			var request = new SqlRequest("Tarief", "csp_CreateModelContractFromOnderhandeling");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", ParameterDirection.Input, p_AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_InstantieType", ParameterDirection.Input, p_InstantieType));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ModelAfspraakID", ParameterDirection.InputOutput, p_ModelAfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ModelCode", ParameterDirection.Input, p_ModelCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ModelOmschrijving", ParameterDirection.Input, p_ModelOmschrijving));
			var result = _executor.Execute<T>(request);
			p_ModelAfspraakID = (int?)request.GetParameterValue("@p_ModelAfspraakID");
			return result;
		}

		public T csp_OnderhandelingExport_s01<T>(int? AfspraakID, bool? AllePrestaties) where T : SqlResponse
		{
			var request = new SqlRequest("Tarief", "csp_OnderhandelingExport_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AllePrestaties", ParameterDirection.Input, AllePrestaties));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingPrijslijst_u01<T>(int? AfspraakID, IEnumerable<Database.UserDefinedTypes.Overig.udtVarCharTable> DeclaratieCodes, ref bool? OnderhandelingGewijzigd) where T : SqlResponse
		{
			var request = new SqlRequest("Tarief", "csp_OnderhandelingPrijslijst_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@DeclaratieCodes", ParameterDirection.Input, "Overig", "udtVarCharTable", DeclaratieCodes));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@OnderhandelingGewijzigd", ParameterDirection.InputOutput, OnderhandelingGewijzigd));
			var result = _executor.Execute<T>(request);
			OnderhandelingGewijzigd = (bool?)request.GetParameterValue("@OnderhandelingGewijzigd");
			return result;
		}

		public T csp_OnderhandelingPrijslijst_i01<T>(int? AfspraakId, bool? ImportPrices, bool? ImportVolumes, IEnumerable<Database.UserDefinedTypes.Tarief.udtTariefPrijslijst> Prijslijst) where T : SqlResponse
		{
			var request = new SqlRequest("Tarief", "csp_OnderhandelingPrijslijst_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakId", ParameterDirection.Input, AfspraakId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ImportPrices", ParameterDirection.Input, ImportPrices));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@ImportVolumes", ParameterDirection.Input, ImportVolumes));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@Prijslijst", ParameterDirection.Input, "Tarief", "udtTariefPrijslijst", Prijslijst));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_OnderhandelingPrijslijst_s01<T>(int? AfspraakId) where T : SqlResponse
		{
			var request = new SqlRequest("Tarief", "csp_OnderhandelingPrijslijst_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakId", ParameterDirection.Input, AfspraakId));
			var result = _executor.Execute<T>(request);
			return result;
		}
	}

	public class Vergelijking : IVergelijking
	{
		private ISqlExecutor _executor;
		public Vergelijking(ISqlExecutor executor)
		{
			_executor = executor;
		}

		public T csp_GetDetailKosten_s02<T>(int? p_OnderhandelingGroepId, int? p_VergelijkingsBronID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_GetDetailKosten_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingGroepId", ParameterDirection.Input, p_OnderhandelingGroepId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingsBronID", ParameterDirection.Input, p_VergelijkingsBronID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_CreateVergelijkingsPrestatieSet_i02<T>(int? p_VergelijkingID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_CreateVergelijkingsPrestatieSet_i02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingID", ParameterDirection.Input, p_VergelijkingID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_VergelijkingsBronPrijslijst_u01<T>(int? p_VergelijkingID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_VergelijkingsBronPrijslijst_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingID", ParameterDirection.Input, p_VergelijkingID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_GetVergelijkingExport_s02<T>(int? vergelijkingsBronID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_GetVergelijkingExport_s02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@vergelijkingsBronID", ParameterDirection.Input, vergelijkingsBronID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_NeemPrijzenOver8Integraal_u01<T>(int? AfspraakID, bool? AlleenLagereTarieven, int? BronIndex, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> FilterPrestatieIDs, bool? FilterPrestaties, int? VergelijkingID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_NeemPrijzenOver8Integraal_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AlleenLagereTarieven", ParameterDirection.Input, AlleenLagereTarieven));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BronIndex", ParameterDirection.Input, BronIndex));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@FilterPrestatieIDs", ParameterDirection.Input, "Overig", "udtIntTable", FilterPrestatieIDs));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@FilterPrestaties", ParameterDirection.Input, FilterPrestaties));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@VergelijkingID", ParameterDirection.Input, VergelijkingID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_VergelijkingsBronPrijslijst_u02<T>(int? p_VergelijkingID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_VergelijkingsBronPrijslijst_u02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingID", ParameterDirection.Input, p_VergelijkingID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_BerekenKosten_i01<T>(int? p_VergelijkingID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_BerekenKosten_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingID", ParameterDirection.Input, p_VergelijkingID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_NeemPrijzenOver8_u01<T>(int? AfspraakID, bool? AlleenLagereTarieven, int? BronIndex, IEnumerable<Database.UserDefinedTypes.Overig.udtIntTable> FilterPrestatieIDs, bool? FilterPrestaties, int? VergelijkingID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_NeemPrijzenOver8_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AfspraakID", ParameterDirection.Input, AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@AlleenLagereTarieven", ParameterDirection.Input, AlleenLagereTarieven));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@BronIndex", ParameterDirection.Input, BronIndex));
			request.Parameters.Add(new StoredProcedureTableTypeParameter("@FilterPrestatieIDs", ParameterDirection.Input, "Overig", "udtIntTable", FilterPrestatieIDs));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@FilterPrestaties", ParameterDirection.Input, FilterPrestaties));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@VergelijkingID", ParameterDirection.Input, VergelijkingID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_BerekenKosten_i02<T>(int? p_VergelijkingsBronID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_BerekenKosten_i02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingsBronID", ParameterDirection.Input, p_VergelijkingsBronID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_CreateVergelijking_i01<T>(int? p_AfspraakID, int? p_AfspraakIDVolumeSjabloon, ref int? p_VergelijkingID, int? p_VergelijkingType) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_CreateVergelijking_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", ParameterDirection.Input, p_AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakIDVolumeSjabloon", ParameterDirection.Input, p_AfspraakIDVolumeSjabloon));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingID", ParameterDirection.InputOutput, p_VergelijkingID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingType", ParameterDirection.Input, p_VergelijkingType));
			var result = _executor.Execute<T>(request);
			p_VergelijkingID = (int?)request.GetParameterValue("@p_VergelijkingID");
			return result;
		}

		public T csp_CreateVergelijkingsBron_i01<T>(int? p_VergelijkingID, ref int? p_VergelijkingsBronID, int? p_VolumeAfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_CreateVergelijkingsBron_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingID", ParameterDirection.Input, p_VergelijkingID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingsBronID", ParameterDirection.InputOutput, p_VergelijkingsBronID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VolumeAfspraakID", ParameterDirection.Input, p_VolumeAfspraakID));
			var result = _executor.Execute<T>(request);
			p_VergelijkingsBronID = (int?)request.GetParameterValue("@p_VergelijkingsBronID");
			return result;
		}

		public T csp_CreateVergelijkingsBron_i02<T>(int? p_AfspraakID, int? p_VergelijkingID, ref int? p_VergelijkingsBronID, int? p_VolumeAfspraakID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_CreateVergelijkingsBron_i02");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", ParameterDirection.Input, p_AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingID", ParameterDirection.Input, p_VergelijkingID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingsBronID", ParameterDirection.InputOutput, p_VergelijkingsBronID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VolumeAfspraakID", ParameterDirection.Input, p_VolumeAfspraakID));
			var result = _executor.Execute<T>(request);
			p_VergelijkingsBronID = (int?)request.GetParameterValue("@p_VergelijkingsBronID");
			return result;
		}

		public T csp_GetAfspraakData_s<T>(ref int? p_AfspraakID, ref int? p_OnderhandelingAfspraakID, int? p_VergelijkingID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_GetAfspraakData_s");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_AfspraakID", ParameterDirection.InputOutput, p_AfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingAfspraakID", ParameterDirection.InputOutput, p_OnderhandelingAfspraakID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingID", ParameterDirection.Input, p_VergelijkingID));
			var result = _executor.Execute<T>(request);
			p_AfspraakID = (int?)request.GetParameterValue("@p_AfspraakID");
			p_OnderhandelingAfspraakID = (int?)request.GetParameterValue("@p_OnderhandelingAfspraakID");
			return result;
		}

		public T csp_HerBerekenKosten_u01<T>(int? p_VergelijkingID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_HerBerekenKosten_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingID", ParameterDirection.Input, p_VergelijkingID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_GetVergelijkingExport_s01<T>(int? vergelijkingsBronID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_GetVergelijkingExport_s01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@vergelijkingsBronID", ParameterDirection.Input, vergelijkingsBronID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_CreateVergelijkingsPrestatieSet_i01<T>(int? p_VergelijkingID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_CreateVergelijkingsPrestatieSet_i01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingID", ParameterDirection.Input, p_VergelijkingID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ReCreateVergelijkingsPrestatieSet_u<T>(int? TariefType, int? VergelijkingID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_ReCreateVergelijkingsPrestatieSet_u");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@TariefType", ParameterDirection.Input, TariefType));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@VergelijkingID", ParameterDirection.Input, VergelijkingID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_NeemPrijzenOver_u01<T>(int? p_VergelijkingsBronID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_NeemPrijzenOver_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingsBronID", ParameterDirection.Input, p_VergelijkingsBronID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ApplyDetailFilter_u01<T>(int? p_OnderhandelingGroepId, int? p_VergelijkingID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_ApplyDetailFilter_u01");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingGroepId", ParameterDirection.Input, p_OnderhandelingGroepId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingID", ParameterDirection.Input, p_VergelijkingID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ApplyDetailFilter_u02a<T>(int? p_OnderhandelingGroepId, int? p_VergelijkingID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_ApplyDetailFilter_u02a");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingGroepId", ParameterDirection.Input, p_OnderhandelingGroepId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingID", ParameterDirection.Input, p_VergelijkingID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ApplyDetailFilter_u02b<T>(string p_DeclaratieCode, int? p_OnderhandelingGroepId, int? p_VergelijkingID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_ApplyDetailFilter_u02b");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_DeclaratieCode", ParameterDirection.Input, p_DeclaratieCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingGroepId", ParameterDirection.Input, p_OnderhandelingGroepId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingID", ParameterDirection.Input, p_VergelijkingID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_ApplyDetailFilter_u03<T>(string p_BehandelingCode, string p_DiagnoseCode, int? p_OnderhandelingGroepId, int? p_VergelijkingID, string p_ZorgTypeCode, string p_ZorgVraagCode) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_ApplyDetailFilter_u03");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_BehandelingCode", ParameterDirection.Input, p_BehandelingCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_DiagnoseCode", ParameterDirection.Input, p_DiagnoseCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingGroepId", ParameterDirection.Input, p_OnderhandelingGroepId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingID", ParameterDirection.Input, p_VergelijkingID));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ZorgTypeCode", ParameterDirection.Input, p_ZorgTypeCode));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_ZorgVraagCode", ParameterDirection.Input, p_ZorgVraagCode));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_GetBronKosten_s<T>(int? p_VergelijkingsBronID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_GetBronKosten_s");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingsBronID", ParameterDirection.Input, p_VergelijkingsBronID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_GetDetailKosten_s<T>(int? p_OnderhandelingGroepId, int? p_PageNumber, int? p_PageSize, int? p_SortColumn, bool? p_SortOrder, int? p_VergelijkingsBronID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_GetDetailKosten_s");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingGroepId", ParameterDirection.Input, p_OnderhandelingGroepId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_PageNumber", ParameterDirection.Input, p_PageNumber));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_PageSize", ParameterDirection.Input, p_PageSize));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_SortColumn", ParameterDirection.Input, p_SortColumn));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_SortOrder", ParameterDirection.Input, p_SortOrder));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingsBronID", ParameterDirection.Input, p_VergelijkingsBronID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_GetKosten_s<T>(int? p_VergelijkingID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_GetKosten_s");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingID", ParameterDirection.Input, p_VergelijkingID));
			var result = _executor.Execute<T>(request);
			return result;
		}

		public T csp_GetSelectionCount_s<T>(int? p_OnderhandelingGroepId, int? p_VergelijkingID) where T : SqlResponse
		{
			var request = new SqlRequest("Vergelijking", "csp_GetSelectionCount_s");
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_OnderhandelingGroepId", ParameterDirection.Input, p_OnderhandelingGroepId));
			request.Parameters.Add(new StoredProcedureSimpleParameter("@p_VergelijkingID", ParameterDirection.Input, p_VergelijkingID));
			var result = _executor.Execute<T>(request);
			return result;
		}
	}

	#endregion
}
