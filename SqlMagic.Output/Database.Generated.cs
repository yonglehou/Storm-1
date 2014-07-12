using System;

namespace Database
{
public class Afspraak
{
public SqlMagic.Lib.ISqlExecutor SqlExecutor { get; set; }
public class udt_GGZPrijslijstTable : System.Collections.Generic.List<udt_GGZPrijslijstTable.udt_GGZPrijslijstTableItem>
{
public class udt_GGZPrijslijstTableItem
{
public int PrestatieID { get; set; }
public int AantalAmbulant { get; set; }
public int AantalBasisGGZ { get; set; }
public int AantalDeelprestaties { get; set; }
public int AantalMetBev2 { get; set; }
public int AantalMetBev3 { get; set; }
public int AantalMetPMU { get; set; }
public int AantalRegNHC { get; set; }
public int AantalVerblijf { get; set; }
public decimal Tarief { get; set; }
public decimal TariefBev2 { get; set; }
public decimal TariefBev3 { get; set; }
public decimal TariefExclNHC { get; set; }
public decimal TariefNHC { get; set; }
public decimal TariefPMU { get; set; }
public char DeclaratieCode { get; set; }
}
}
public class udtInstantiePeriodeTable : System.Collections.Generic.List<udtInstantiePeriodeTable.udtInstantiePeriodeTableItem>
{
public class udtInstantiePeriodeTableItem
{
public System.DateTime BeginDatum { get; set; }
public System.DateTime EindDatum { get; set; }
public int InstantieID { get; set; }
}
}
public class udtOnderhandenWerkComponentenTable : System.Collections.Generic.List<udtOnderhandenWerkComponentenTable.udtOnderhandenWerkComponentenTableItem>
{
public class udtOnderhandenWerkComponentenTableItem
{
public int ZorgverzekeraarId { get; set; }
public object Percentage { get; set; }
}
}
public class udtPrestatieInfoTable : System.Collections.Generic.List<udtPrestatieInfoTable.udtPrestatieInfoTableItem>
{
public class udtPrestatieInfoTableItem
{
public int VolumeComponent1 { get; set; }
public int VolumeComponent2 { get; set; }
public int VolumeComponent3 { get; set; }
public int PrestatieId { get; set; }
public bool Ingesloten { get; set; }
}
}
public Afspraak(SqlMagic.Lib.ISqlExecutor sqlExecutor)
{
SqlExecutor = sqlExecutor;
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingPrijslijst_u01<T>(int p_OnderhandelingGroepID, bool p_SelectBack)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingPrijslijst_u01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_OnderhandelingGroepID",
Value = p_OnderhandelingGroepID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_SelectBack",
Value = p_SelectBack
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_HonorariumComponent_s01<T>(int AfspraakID, int PrestatieID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_HonorariumComponent_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PrestatieID",
Value = PrestatieID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingPrestatie_s01<T>(bool p_FilterAlleenUitzonderingen, char p_FilterBehandelingCode, string p_FilterDeclaratieCodes, char p_FilterDiagnoseCode, char p_FilterZorgTypeCode, char p_FilterZorgVraagCode, int p_OnderhandelingGroepID, int p_PageNr, int p_PageSize, char p_SorteringKolom, string p_SorteringVolgorde)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingPrestatie_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_FilterAlleenUitzonderingen",
Value = p_FilterAlleenUitzonderingen
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_FilterBehandelingCode",
Value = p_FilterBehandelingCode
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_FilterDeclaratieCodes",
Value = p_FilterDeclaratieCodes
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_FilterDiagnoseCode",
Value = p_FilterDiagnoseCode
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_FilterZorgTypeCode",
Value = p_FilterZorgTypeCode
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_FilterZorgVraagCode",
Value = p_FilterZorgVraagCode
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_OnderhandelingGroepID",
Value = p_OnderhandelingGroepID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_PageNr",
Value = p_PageNr
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_PageSize",
Value = p_PageSize
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_SorteringKolom",
Value = p_SorteringKolom
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_SorteringVolgorde",
Value = p_SorteringVolgorde
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingUitgangspositie_i01<T>(int AfspraakIDBlacklist, int AfspraakIDContract, int AfspraakIDModel, int AfspraakIDSjabloon, int AfspraakIDSpeerpunt, int AfspraakIDVolumeContract, int AfspraakIDVolumeModel, ref int NewUitgangspositieID, string SegmentCode, bool TotaalprijsGelijk, string Username)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingUitgangspositie_i01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakIDBlacklist",
Value = AfspraakIDBlacklist
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakIDContract",
Value = AfspraakIDContract
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakIDModel",
Value = AfspraakIDModel
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakIDSjabloon",
Value = AfspraakIDSjabloon
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakIDSpeerpunt",
Value = AfspraakIDSpeerpunt
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakIDVolumeContract",
Value = AfspraakIDVolumeContract
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakIDVolumeModel",
Value = AfspraakIDVolumeModel
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@NewUitgangspositieID",
Value = NewUitgangspositieID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@SegmentCode",
Value = SegmentCode
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@TotaalprijsGelijk",
Value = TotaalprijsGelijk
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Username",
Value = Username
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_HonorariumComponent_s03<T>(int AfspraakID, int InstantieID, int PrestatieID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_HonorariumComponent_s03",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieID",
Value = InstantieID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PrestatieID",
Value = PrestatieID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingPrestatie_s03<T>(int p_OnderhandelingGroepID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingPrestatie_s03",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_OnderhandelingGroepID",
Value = p_OnderhandelingGroepID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingUitgangspositie_i02<T>(int AfspraakIDBlacklist, int AfspraakIDContract, int AfspraakIDModel, int AfspraakIDSjabloon, int AfspraakIDSpeerpunt, int AfspraakIDVolumeContract, int AfspraakIDVolumeModel, ref int NewUitgangspositieID, bool TotaalprijsGelijk, string Username)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingUitgangspositie_i02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakIDBlacklist",
Value = AfspraakIDBlacklist
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakIDContract",
Value = AfspraakIDContract
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakIDModel",
Value = AfspraakIDModel
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakIDSjabloon",
Value = AfspraakIDSjabloon
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakIDSpeerpunt",
Value = AfspraakIDSpeerpunt
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakIDVolumeContract",
Value = AfspraakIDVolumeContract
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakIDVolumeModel",
Value = AfspraakIDVolumeModel
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@NewUitgangspositieID",
Value = NewUitgangspositieID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@TotaalprijsGelijk",
Value = TotaalprijsGelijk
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Username",
Value = Username
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_HonorariumComponentPassantenTarief_i01<T>(int AfspraakID, decimal Kosten, int PrestatieID, string SpecialismeCode, string Username)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_HonorariumComponentPassantenTarief_i01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Kosten",
Value = Kosten
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PrestatieID",
Value = PrestatieID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@SpecialismeCode",
Value = SpecialismeCode
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Username",
Value = Username
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingPrestatie_s05_incl_vergelijken<T>(int AfspraakID, bool AlleenIngesloten, Overig.udtVarCharTable DeclaratieCodes, string DeelVanOmschrijving, bool ForceerTariefVergelijking, Overig.udtIntTable GroepFilter, int GroepFilterType, bool InclHonorariumComponenten, bool NegeerPrestatieFilter, int VergelijkingID, Overig.udtVarCharTable ZorgproductCodes)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingPrestatie_s05_incl_vergelijken",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AlleenIngesloten",
Value = AlleenIngesloten
},
new SqlMagic.Lib.StoredProcedureTableTypeParameter()
{
Name = "@DeclaratieCodes",
Table = DeclaratieCodes
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@DeelVanOmschrijving",
Value = DeelVanOmschrijving
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ForceerTariefVergelijking",
Value = ForceerTariefVergelijking
},
new SqlMagic.Lib.StoredProcedureTableTypeParameter()
{
Name = "@GroepFilter",
Table = GroepFilter
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@GroepFilterType",
Value = GroepFilterType
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InclHonorariumComponenten",
Value = InclHonorariumComponenten
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@NegeerPrestatieFilter",
Value = NegeerPrestatieFilter
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@VergelijkingID",
Value = VergelijkingID
},
new SqlMagic.Lib.StoredProcedureTableTypeParameter()
{
Name = "@ZorgproductCodes",
Table = ZorgproductCodes
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingVolumeSpecificatieGewenst_s01<T>(int AfspraakId, ref bool VolumeSpecificatieGewenst)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingVolumeSpecificatieGewenst_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakId",
Value = AfspraakId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@VolumeSpecificatieGewenst",
Value = VolumeSpecificatieGewenst
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ImportContract8Data_u01<T>(int p_AfspraakID, System.Guid p_StagingImportPrijslijstBatchToken)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ImportContract8Data_u01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfspraakID",
Value = p_AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_StagingImportPrijslijstBatchToken",
Value = p_StagingImportPrijslijstBatchToken
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingPrestatie_u06<T>(int AfspraakID, Overig.udtVarCharTable DeclaratieCodes, ref bool OnderhandelingGewijzigd)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingPrestatie_u06",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureTableTypeParameter()
{
Name = "@DeclaratieCodes",
Table = DeclaratieCodes
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@OnderhandelingGewijzigd",
Value = OnderhandelingGewijzigd
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelPeriode_s01<T>(int p_ZorgverstrekkerID, int p_ZorgverzekeraarID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelPeriode_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_ZorgverstrekkerID",
Value = p_ZorgverstrekkerID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_ZorgverzekeraarID",
Value = p_ZorgverzekeraarID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ImportContractData_u01<T>(int p_AfspraakID, System.Guid p_StagingImportPrijslijstBatchToken)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ImportContractData_u01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfspraakID",
Value = p_AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_StagingImportPrijslijstBatchToken",
Value = p_StagingImportPrijslijstBatchToken
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingPrestatieTariefSoort_s01<T>(int AfspraakID, char DeclaratieCode)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingPrestatieTariefSoort_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@DeclaratieCode",
Value = DeclaratieCode
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelPeriode_s02<T>(int p_PeriodeID, int p_ZorgverzekeraarID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelPeriode_s02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_PeriodeID",
Value = p_PeriodeID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_ZorgverzekeraarID",
Value = p_ZorgverzekeraarID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ImportModelData_u01<T>(int AfspraakID, System.Guid StagingImportPrijslijstBatchToken)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ImportModelData_u01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@StagingImportPrijslijstBatchToken",
Value = StagingImportPrijslijstBatchToken
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_PrestatiesOpGrijzeEnZwarteLijst_i01<T>(int AfspraakId)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_PrestatiesOpGrijzeEnZwarteLijst_i01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakId",
Value = AfspraakId
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandenWerk_s01<T>(int InvulKwartaal, string Segment, int SjabloonJaar, int ZVSID, int ZVZID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandenWerk_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InvulKwartaal",
Value = InvulKwartaal
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Segment",
Value = Segment
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@SjabloonJaar",
Value = SjabloonJaar
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVSID",
Value = ZVSID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVZID",
Value = ZVZID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ImportVolumeSpecificatie_u01<T>(int p_AfspraakID, int p_SpecificatieGebaseerdOpJaar, System.Guid p_StagingImportVolumeSpecificatieBatchToken, string p_ToegevoegdDoor)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ImportVolumeSpecificatie_u01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfspraakID",
Value = p_AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_SpecificatieGebaseerdOpJaar",
Value = p_SpecificatieGebaseerdOpJaar
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_StagingImportVolumeSpecificatieBatchToken",
Value = p_StagingImportVolumeSpecificatieBatchToken
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_ToegevoegdDoor",
Value = p_ToegevoegdDoor
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_PrestatiesOpGrijzeEnZwarteLijst_s02<T>(int AfspraakId, System.DateTime Peildatum)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_PrestatiesOpGrijzeEnZwarteLijst_s02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakId",
Value = AfspraakId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Peildatum",
Value = Peildatum
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandenWerk_s02<T>(Overig.udtPeriodeTable Perioden, int ZVSID, int ZVZID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandenWerk_s02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureTableTypeParameter()
{
Name = "@Perioden",
Table = Perioden
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVSID",
Value = ZVSID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVZID",
Value = ZVZID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_IsOnderhandelenToegestaanInPeriode<T>(System.DateTime p_PeriodeEind, System.DateTime p_PeriodeStart, int p_ZorgverstrekkerID, int p_ZorgverzekeraarID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_IsOnderhandelenToegestaanInPeriode",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_PeriodeEind",
Value = p_PeriodeEind
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_PeriodeStart",
Value = p_PeriodeStart
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_ZorgverstrekkerID",
Value = p_ZorgverstrekkerID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_ZorgverzekeraarID",
Value = p_ZorgverzekeraarID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_RegelResultaat_s01<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_RegelResultaat_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandenWerk_s03<T>(System.DateTime PeriodeEind, System.DateTime PeriodeStart, int ZVSID, int ZVZID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandenWerk_s03",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PeriodeEind",
Value = PeriodeEind
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PeriodeStart",
Value = PeriodeStart
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVSID",
Value = ZVSID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVZID",
Value = ZVZID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Model_d01<T>(int p_MDL_ID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Model_d01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_MDL_ID",
Value = p_MDL_ID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_TariefSoortInfo_Check<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_TariefSoortInfo_Check",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandenWerk_s04<T>(System.DateTime PeriodeEind, System.DateTime PeriodeStart, bool VoorgaandJaar, int ZVSID, int ZVZID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandenWerk_s04",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PeriodeEind",
Value = PeriodeEind
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PeriodeStart",
Value = PeriodeStart
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@VoorgaandJaar",
Value = VoorgaandJaar
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVSID",
Value = ZVSID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVZID",
Value = ZVZID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Model_i01<T>(ref int p_identity, string p_MDL_Code, string p_MDL_Omschrijving, string p_username, int p_ZorgverstrekkerID, int p_ZorgverzekeraarID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Model_i01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_identity",
Value = p_identity
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_MDL_Code",
Value = p_MDL_Code
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_MDL_Omschrijving",
Value = p_MDL_Omschrijving
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_username",
Value = p_username
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_ZorgverstrekkerID",
Value = p_ZorgverstrekkerID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_ZorgverzekeraarID",
Value = p_ZorgverzekeraarID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandenWerk_s05<T>(System.DateTime PeriodeEind, System.DateTime PeriodeStart, int ZVZID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandenWerk_s05",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PeriodeEind",
Value = PeriodeEind
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PeriodeStart",
Value = PeriodeStart
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVZID",
Value = ZVZID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Model_s02<T>(int MDL_ID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Model_s02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@MDL_ID",
Value = MDL_ID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandenWerkSjabloon2010_u01<T>(string Gebruiker, System.Guid ImportIdentifier, int InvulKwartaal, string Segment, int SjabloonJaar, string SjabloonVersie, int ZVSID, int ZVZID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandenWerkSjabloon2010_u01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Gebruiker",
Value = Gebruiker
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ImportIdentifier",
Value = ImportIdentifier
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InvulKwartaal",
Value = InvulKwartaal
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Segment",
Value = Segment
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@SjabloonJaar",
Value = SjabloonJaar
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@SjabloonVersie",
Value = SjabloonVersie
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVSID",
Value = ZVSID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVZID",
Value = ZVZID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Model_u01<T>(string p_MDL_Code, int p_MDL_ID, string p_MDL_Omschrijving, string p_username)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Model_u01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_MDL_Code",
Value = p_MDL_Code
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_MDL_ID",
Value = p_MDL_ID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_MDL_Omschrijving",
Value = p_MDL_Omschrijving
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_username",
Value = p_username
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_PassantenTarief_i01<T>(System.DateTime p_BeginDatum, System.DateTime p_EindDatum, ref int p_identity, string p_Omschrijving, int p_SubVersie, string p_username, int p_Versie, char p_ZVS_AGBCode)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_PassantenTarief_i01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_BeginDatum",
Value = p_BeginDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_EindDatum",
Value = p_EindDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_identity",
Value = p_identity
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_Omschrijving",
Value = p_Omschrijving
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_SubVersie",
Value = p_SubVersie
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_username",
Value = p_username
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_Versie",
Value = p_Versie
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_ZVS_AGBCode",
Value = p_ZVS_AGBCode
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ModelContractExport_s01<T>(int AfspraakID, bool AlleTarieven, char ExportInhoud)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ModelContractExport_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AlleTarieven",
Value = AlleTarieven
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ExportInhoud",
Value = ExportInhoud
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_PassantenTarief_s01<T>(bool ActiveOnly, int AfspraakStijl, int InstantieID, char segment)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_PassantenTarief_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ActiveOnly",
Value = ActiveOnly
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakStijl",
Value = AfspraakStijl
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieID",
Value = InstantieID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@segment",
Value = segment
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Onderhandeling_d01<T>(int CON_ID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Onderhandeling_d01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@CON_ID",
Value = CON_ID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_PrestatiesOpGrijzeEnZwarteLijst_s01<T>(int AfspraakId)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_PrestatiesOpGrijzeEnZwarteLijst_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakId",
Value = AfspraakId
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Onderhandeling_s00<T>(int CON_ID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Onderhandeling_s00",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@CON_ID",
Value = CON_ID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ProductieAfspraken_s01<T>(Overig.udtPeriodeTable Perioden, int ZVSID, int ZVZID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ProductieAfspraken_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureTableTypeParameter()
{
Name = "@Perioden",
Table = Perioden
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVSID",
Value = ZVSID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVZID",
Value = ZVZID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Onderhandeling_s04<T>(int CON_ORIG_ID, int INITIATOR)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Onderhandeling_s04",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@CON_ORIG_ID",
Value = CON_ORIG_ID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@INITIATOR",
Value = INITIATOR
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ProductieAfspraken_s02<T>(System.DateTime PeriodeEind, System.DateTime PeriodeStart, int ZVSID, int ZVZID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ProductieAfspraken_s02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PeriodeEind",
Value = PeriodeEind
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PeriodeStart",
Value = PeriodeStart
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVSID",
Value = ZVSID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVZID",
Value = ZVZID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Onderhandeling_s05<T>(int CON_ID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Onderhandeling_s05",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@CON_ID",
Value = CON_ID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ProductieAfspraken_s03<T>(System.DateTime PeriodeEind, System.DateTime PeriodeStart, int ZVSID, int ZVZID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ProductieAfspraken_s03",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PeriodeEind",
Value = PeriodeEind
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PeriodeStart",
Value = PeriodeStart
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVSID",
Value = ZVSID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVZID",
Value = ZVZID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Onderhandeling_u01<T>(System.DateTime BeginDatum, int CON_ID, int ContactPersoonZVSID, int ContactPersoonZVZID, System.DateTime EindDatum, bool HasUpdates, string Omschrijving, string RefZVS, string RefZVZ, string UpdateUser)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Onderhandeling_u01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@BeginDatum",
Value = BeginDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@CON_ID",
Value = CON_ID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ContactPersoonZVSID",
Value = ContactPersoonZVSID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ContactPersoonZVZID",
Value = ContactPersoonZVZID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@EindDatum",
Value = EindDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@HasUpdates",
Value = HasUpdates
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Omschrijving",
Value = Omschrijving
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@RefZVS",
Value = RefZVS
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@RefZVZ",
Value = RefZVZ
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@UpdateUser",
Value = UpdateUser
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_1416Gelijk_Solve<T>(ref bool AfspraakGewijzigd, int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_1416Gelijk_Solve",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakGewijzigd",
Value = AfspraakGewijzigd
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Onderhandeling_u06<T>(int CON_ID, int ContactPersoonZVSID, int ContactPersoonZVZID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Onderhandeling_u06",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@CON_ID",
Value = CON_ID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ContactPersoonZVSID",
Value = ContactPersoonZVSID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ContactPersoonZVZID",
Value = ContactPersoonZVZID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_1517Gelijk_Solve<T>(ref bool AfspraakGewijzigd, int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_1517Gelijk_Solve",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakGewijzigd",
Value = AfspraakGewijzigd
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Onderhandeling_u07<T>(int p_AfspraakId, System.DateTime p_BeginDatum, System.DateTime p_EindDatum, string p_ReferentieZVS, string p_ReferentieZVZ, int p_TargetAfspraakIDModel, string p_TariefWijzigingTypeCode)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Onderhandeling_u07",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfspraakId",
Value = p_AfspraakId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_BeginDatum",
Value = p_BeginDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_EindDatum",
Value = p_EindDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_ReferentieZVS",
Value = p_ReferentieZVS
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_ReferentieZVZ",
Value = p_ReferentieZVZ
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_TargetAfspraakIDModel",
Value = p_TargetAfspraakIDModel
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_TariefWijzigingTypeCode",
Value = p_TariefWijzigingTypeCode
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_ABSegmentZorgproductenPoorter_Solve<T>(ref bool AfspraakGewijzigd, int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_ABSegmentZorgproductenPoorter_Solve",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakGewijzigd",
Value = AfspraakGewijzigd
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Onderhandeling_u10<T>(int p_AfspraakId, int p_InstantieTypeID, string p_OnderhandelingOpmerking, string p_Username)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Onderhandeling_u10",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfspraakId",
Value = p_AfspraakId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_InstantieTypeID",
Value = p_InstantieTypeID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_OnderhandelingOpmerking",
Value = p_OnderhandelingOpmerking
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_Username",
Value = p_Username
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_Correcte17CodesAgisAchmea_Solve<T>(ref bool AfspraakGewijzigd, int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_Correcte17CodesAgisAchmea_Solve",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakGewijzigd",
Value = AfspraakGewijzigd
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Onderhandeling_u14<T>(int p_AfspraakId, ref int p_OnderhandelingAfspraakID_HuidigeVersie, ref int p_onderhandelingAfspraakID_VorigeVersie, string p_UserName)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Onderhandeling_u14",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfspraakId",
Value = p_AfspraakId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_OnderhandelingAfspraakID_HuidigeVersie",
Value = p_OnderhandelingAfspraakID_HuidigeVersie
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_onderhandelingAfspraakID_VorigeVersie",
Value = p_onderhandelingAfspraakID_VorigeVersie
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_UserName",
Value = p_UserName
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_Geen16Codes_Solve<T>(ref bool AfspraakGewijzigd, int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_Geen16Codes_Solve",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakGewijzigd",
Value = AfspraakGewijzigd
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingAfspraakBijlage_d01<T>(int ID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingAfspraakBijlage_d01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ID",
Value = ID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_GeenOnverzekerdeZorg_Solve<T>(ref bool AfspraakGewijzigd, int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_GeenOnverzekerdeZorg_Solve",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakGewijzigd",
Value = AfspraakGewijzigd
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingExport_s01<T>(int AfspraakID, bool AlleTarieven, char ExportInhoud)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingExport_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AlleTarieven",
Value = AlleTarieven
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ExportInhoud",
Value = ExportInhoud
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_HonorariumToeslagZBC_Check<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_HonorariumToeslagZBC_Check",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingGroep_s01<T>(int p_AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingGroep_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfspraakID",
Value = p_AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_MaxTariefHonorarium_Solve<T>(ref bool AfspraakGewijzigd, int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_MaxTariefHonorarium_Solve",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakGewijzigd",
Value = AfspraakGewijzigd
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingGroep_s02<T>(int p_OnderhandelingGroepID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingGroep_s02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_OnderhandelingGroepID",
Value = p_OnderhandelingGroepID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_MaxTariefKosten_Solve<T>(ref bool AfspraakGewijzigd, int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_MaxTariefKosten_Solve",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakGewijzigd",
Value = AfspraakGewijzigd
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingGroep_u01<T>(object p_AfwijkingConsult, object p_AfwijkingHonOndh, object p_AfwijkingKlinisch, object p_AfwijkingNietKlinisch, object p_AfwijkingZKH, int p_OnderhandelingGroepID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingGroep_u01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfwijkingConsult",
Value = p_AfwijkingConsult
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfwijkingHonOndh",
Value = p_AfwijkingHonOndh
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfwijkingKlinisch",
Value = p_AfwijkingKlinisch
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfwijkingNietKlinisch",
Value = p_AfwijkingNietKlinisch
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfwijkingZKH",
Value = p_AfwijkingZKH
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_OnderhandelingGroepID",
Value = p_OnderhandelingGroepID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_MaxTariefTotaal_Solve<T>(ref bool AfspraakGewijzigd, int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_MaxTariefTotaal_Solve",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakGewijzigd",
Value = AfspraakGewijzigd
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingGroepsIndelingGroep_s02<T>(int AfspraakID, int GroepsIndelingID, int HoofdGroepID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingGroepsIndelingGroep_s02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@GroepsIndelingID",
Value = GroepsIndelingID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@HoofdGroepID",
Value = HoofdGroepID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_MinTariefHonorarium_Solve<T>(ref bool AfspraakGewijzigd, int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_MinTariefHonorarium_Solve",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakGewijzigd",
Value = AfspraakGewijzigd
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingGroepsIndelingGroep_s03<T>(int AfspraakID, int GroepsIndelingID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingGroepsIndelingGroep_s03",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@GroepsIndelingID",
Value = GroepsIndelingID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_MinTariefKosten_Solve<T>(ref bool AfspraakGewijzigd, int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_MinTariefKosten_Solve",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakGewijzigd",
Value = AfspraakGewijzigd
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingGroepsUitzondering_d01<T>(char DeclaratieCode, ref bool IsVerwijderd, int OnderhandelingAfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingGroepsUitzondering_d01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@DeclaratieCode",
Value = DeclaratieCode
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@IsVerwijderd",
Value = IsVerwijderd
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@OnderhandelingAfspraakID",
Value = OnderhandelingAfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_OvernemenPrijzen16Pendant_Solve<T>(ref bool AfspraakGewijzigd, int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_OvernemenPrijzen16Pendant_Solve",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakGewijzigd",
Value = AfspraakGewijzigd
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingGroepsUitzonderingHonOndhComp_d01<T>(int OnderhandelingGroepsuitzonderingID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingGroepsUitzonderingHonOndhComp_d01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@OnderhandelingGroepsuitzonderingID",
Value = OnderhandelingGroepsuitzonderingID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_OvernemenPrijzen17Pendant_Solve<T>(ref bool AfspraakGewijzigd, int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_OvernemenPrijzen17Pendant_Solve",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakGewijzigd",
Value = AfspraakGewijzigd
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingGroepsUitzonderingHonOndhComp_i01<T>(int OnderhandelingGroepsuitzonderingID, decimal Prijs, char SpecialismeCode)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingGroepsUitzonderingHonOndhComp_i01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@OnderhandelingGroepsuitzonderingID",
Value = OnderhandelingGroepsuitzonderingID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Prijs",
Value = Prijs
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@SpecialismeCode",
Value = SpecialismeCode
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_TariefSoortInfo_Solve<T>(ref bool AfspraakGewijzigd, int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_TariefSoortInfo_Solve",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakGewijzigd",
Value = AfspraakGewijzigd
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingOpmerking_s01<T>(int AfspraakID, int InstantieTypeID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingOpmerking_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieTypeID",
Value = InstantieTypeID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_TotaalHogerDanPassanten_Solve<T>(ref bool AfspraakGewijzigd, int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_TotaalHogerDanPassanten_Solve",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakGewijzigd",
Value = AfspraakGewijzigd
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingPrestatie_d01<T>(int AfspraakID, ref bool OnderhandelingGewijzigd, Overig.udtIntTable PrestatieIds)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingPrestatie_d01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@OnderhandelingGewijzigd",
Value = OnderhandelingGewijzigd
},
new SqlMagic.Lib.StoredProcedureTableTypeParameter()
{
Name = "@PrestatieIds",
Table = PrestatieIds
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingPrestatie_s02<T>(int p_AfspraakID, char p_DeclaratieCode)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingPrestatie_s02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfspraakID",
Value = p_AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_DeclaratieCode",
Value = p_DeclaratieCode
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingPrestatie_s04<T>(int p_AfspraakID, char p_DeclaratieCode)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingPrestatie_s04",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfspraakID",
Value = p_AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_DeclaratieCode",
Value = p_DeclaratieCode
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingPrestatie_s05<T>(int AfspraakID, bool AlleenIngesloten, Overig.udtVarCharTable DeclaratieCodes, string DeelVanOmschrijving, Overig.udtIntTable GroepFilter, int GroepFilterType, bool NegeerPrestatieFilter, Overig.udtVarCharTable ZorgproductCodes)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingPrestatie_s05",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AlleenIngesloten",
Value = AlleenIngesloten
},
new SqlMagic.Lib.StoredProcedureTableTypeParameter()
{
Name = "@DeclaratieCodes",
Table = DeclaratieCodes
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@DeelVanOmschrijving",
Value = DeelVanOmschrijving
},
new SqlMagic.Lib.StoredProcedureTableTypeParameter()
{
Name = "@GroepFilter",
Table = GroepFilter
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@GroepFilterType",
Value = GroepFilterType
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@NegeerPrestatieFilter",
Value = NegeerPrestatieFilter
},
new SqlMagic.Lib.StoredProcedureTableTypeParameter()
{
Name = "@ZorgproductCodes",
Table = ZorgproductCodes
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingPrestatie_s06<T>(int AfspraakID, bool AlleenIngesloten, Overig.udtVarCharTable DeclaratieCodes, string DeelVanOmschrijving, Overig.udtIntTable GroepFilter, int GroepFilterType)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingPrestatie_s06",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AlleenIngesloten",
Value = AlleenIngesloten
},
new SqlMagic.Lib.StoredProcedureTableTypeParameter()
{
Name = "@DeclaratieCodes",
Table = DeclaratieCodes
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@DeelVanOmschrijving",
Value = DeelVanOmschrijving
},
new SqlMagic.Lib.StoredProcedureTableTypeParameter()
{
Name = "@GroepFilter",
Table = GroepFilter
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@GroepFilterType",
Value = GroepFilterType
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingPrestatie_u01<T>(char p_DeclaratieCode, bool p_ForceerGroepsuitzondering, bool p_Ingesloten, int p_OnderhandelingAfspraakID, ref int p_OnderhandelingGroepsUitzonderingID, decimal p_PrijsHonOndh, decimal p_PrijsZKH, char p_TariefWijzigingTypeCode)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingPrestatie_u01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_DeclaratieCode",
Value = p_DeclaratieCode
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_ForceerGroepsuitzondering",
Value = p_ForceerGroepsuitzondering
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_Ingesloten",
Value = p_Ingesloten
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_OnderhandelingAfspraakID",
Value = p_OnderhandelingAfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_OnderhandelingGroepsUitzonderingID",
Value = p_OnderhandelingGroepsUitzonderingID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_PrijsHonOndh",
Value = p_PrijsHonOndh
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_PrijsZKH",
Value = p_PrijsZKH
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_TariefWijzigingTypeCode",
Value = p_TariefWijzigingTypeCode
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingPrestatie_u02<T>(int p_OnderhandelingAfspraakID, int p_PrestatieID, bool p_Uitgesloten, int p_Volume)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingPrestatie_u02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_OnderhandelingAfspraakID",
Value = p_OnderhandelingAfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_PrestatieID",
Value = p_PrestatieID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_Uitgesloten",
Value = p_Uitgesloten
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_Volume",
Value = p_Volume
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingPrestatie_u07<T>(int AfspraakID, object AfwVolume, ref bool OnderhandelingGewijzigd, Overig.udtIntTable PrestatieIds)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingPrestatie_u07",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfwVolume",
Value = AfwVolume
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@OnderhandelingGewijzigd",
Value = OnderhandelingGewijzigd
},
new SqlMagic.Lib.StoredProcedureTableTypeParameter()
{
Name = "@PrestatieIds",
Table = PrestatieIds
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingPrestatie_u08<T>(int AfspraakID, char DeclaratieCode, bool Ingesloten, decimal Tarief, int VolumeComponent1, int VolumeComponent2, int VolumeComponent3)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingPrestatie_u08",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@DeclaratieCode",
Value = DeclaratieCode
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Ingesloten",
Value = Ingesloten
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Tarief",
Value = Tarief
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@VolumeComponent1",
Value = VolumeComponent1
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@VolumeComponent2",
Value = VolumeComponent2
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@VolumeComponent3",
Value = VolumeComponent3
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingPrestatieToelichting_d01<T>(int AfspraakID, char DeclaratieCode)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingPrestatieToelichting_d01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@DeclaratieCode",
Value = DeclaratieCode
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingPrestatieToelichting_s01<T>(int AfspraakID, char DeclaratieCode, ref string Toelichting)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingPrestatieToelichting_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@DeclaratieCode",
Value = DeclaratieCode
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Toelichting",
Value = Toelichting
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingPrestatieToelichting_u01<T>(int AfspraakID, char DeclaratieCode, string Toelichting)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingPrestatieToelichting_u01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@DeclaratieCode",
Value = DeclaratieCode
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Toelichting",
Value = Toelichting
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingPrijslijst_s01<T>(int CON_ID, bool IsOnlyAfspraken)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingPrijslijst_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@CON_ID",
Value = CON_ID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@IsOnlyAfspraken",
Value = IsOnlyAfspraken
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingPrijslijst_s02<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingPrijslijst_s02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingPrijslijstHonOndhComp_s02<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingPrijslijstHonOndhComp_s02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingStatusovergangCheck_s01<T>(int p_AfspraakID, int p_InstantieID, int p_NewStatus)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingStatusovergangCheck_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfspraakID",
Value = p_AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_InstantieID",
Value = p_InstantieID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_NewStatus",
Value = p_NewStatus
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingUitgangspositie_i03<T>(int AfspraakIDSjabloon, ref int NieuweUitgangspositieID, string Username)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingUitgangspositie_i03",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakIDSjabloon",
Value = AfspraakIDSjabloon
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@NieuweUitgangspositieID",
Value = NieuweUitgangspositieID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Username",
Value = Username
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingUitgangspositie_s01<T>(int AfspraakID, int InstantieID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingUitgangspositie_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieID",
Value = InstantieID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelPeriode_save01<T>(bool p_OnderhandelenToegestaan, int p_PeriodeID, int p_ZorgverstrekkerID, int p_ZorgverzekeraarID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelPeriode_save01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_OnderhandelenToegestaan",
Value = p_OnderhandelenToegestaan
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_PeriodeID",
Value = p_PeriodeID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_ZorgverstrekkerID",
Value = p_ZorgverstrekkerID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_ZorgverzekeraarID",
Value = p_ZorgverzekeraarID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandenWerk_d01<T>(System.DateTime PeriodeEind, System.DateTime PeriodeStart, int ZVSID, int ZVZID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandenWerk_d01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PeriodeEind",
Value = PeriodeEind
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PeriodeStart",
Value = PeriodeStart
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVSID",
Value = ZVSID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVZID",
Value = ZVZID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_onderhandenwerk_s06<T>(System.DateTime peilDatum, int ZVZ_uzovi)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_onderhandenwerk_s06",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@peilDatum",
Value = peilDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVZ_uzovi",
Value = ZVZ_uzovi
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandenWerk_u01<T>(bool AkkoordVerklaard, Afspraak.udtOnderhandenWerkComponentenTable ComponentenHuidigJaar, Afspraak.udtOnderhandenWerkComponentenTable ComponentenVoorgaandJaar, decimal KostprijsHuidigJaar, decimal KostprijsVoorgaandJaar, string OpgegevenDoor, System.DateTime PeriodeEind, System.DateTime PeriodeStart, int ZVSID, int ZVZID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandenWerk_u01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AkkoordVerklaard",
Value = AkkoordVerklaard
},
new SqlMagic.Lib.StoredProcedureTableTypeParameter()
{
Name = "@ComponentenHuidigJaar",
Table = ComponentenHuidigJaar
},
new SqlMagic.Lib.StoredProcedureTableTypeParameter()
{
Name = "@ComponentenVoorgaandJaar",
Table = ComponentenVoorgaandJaar
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@KostprijsHuidigJaar",
Value = KostprijsHuidigJaar
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@KostprijsVoorgaandJaar",
Value = KostprijsVoorgaandJaar
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@OpgegevenDoor",
Value = OpgegevenDoor
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PeriodeEind",
Value = PeriodeEind
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PeriodeStart",
Value = PeriodeStart
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVSID",
Value = ZVSID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVZID",
Value = ZVZID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandenWerkSjabloon2010_s01<T>(int InvulKwartaal, string Segment, int SjabloonJaar, int ZVSID, int ZVZID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandenWerkSjabloon2010_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InvulKwartaal",
Value = InvulKwartaal
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Segment",
Value = Segment
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@SjabloonJaar",
Value = SjabloonJaar
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVSID",
Value = ZVSID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVZID",
Value = ZVZID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_PassantenTarief_d01<T>(int CON_ID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_PassantenTarief_d01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@CON_ID",
Value = CON_ID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_PassantenTarief_i02<T>(System.DateTime p_BeginDatum, System.DateTime p_EindDatum, ref int p_identity, string p_Omschrijving, int p_SubVersie, string p_username, int p_Versie, int p_ZVS_ID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_PassantenTarief_i02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_BeginDatum",
Value = p_BeginDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_EindDatum",
Value = p_EindDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_identity",
Value = p_identity
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_Omschrijving",
Value = p_Omschrijving
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_SubVersie",
Value = p_SubVersie
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_username",
Value = p_username
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_Versie",
Value = p_Versie
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_ZVS_ID",
Value = p_ZVS_ID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_PrestatieComponentModel_d01<T>(int p_MDL_ID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_PrestatieComponentModel_d01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_MDL_ID",
Value = p_MDL_ID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_PrestatieComponentModel_i02<T>(int MDL_ID, int SJA_ID, int SJA_NumHCP, string USERNAME)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_PrestatieComponentModel_i02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@MDL_ID",
Value = MDL_ID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@SJA_ID",
Value = SJA_ID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@SJA_NumHCP",
Value = SJA_NumHCP
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@USERNAME",
Value = USERNAME
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_PrestatieComponentModel_i03<T>(int CON_ID, int SJA_ID, int SJA_NumHCP, string USERNAME)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_PrestatieComponentModel_i03",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@CON_ID",
Value = CON_ID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@SJA_ID",
Value = SJA_ID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@SJA_NumHCP",
Value = SJA_NumHCP
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@USERNAME",
Value = USERNAME
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_PrestatieComponentModel_i04<T>(int SJA_ID, string USERNAME)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_PrestatieComponentModel_i04",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@SJA_ID",
Value = SJA_ID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@USERNAME",
Value = USERNAME
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_PrestatieComponentModel_s01<T>(int MDL_ID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_PrestatieComponentModel_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@MDL_ID",
Value = MDL_ID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_PrestatieComponentModel_s02<T>(int MDL_ID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_PrestatieComponentModel_s02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@MDL_ID",
Value = MDL_ID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_PrestatieComponentModel_u01<T>(int AfspraakID, int p_MDLDBC_Aantal, decimal p_MDLDBC_Specialisten, decimal p_MDLDBC_Ziekenhuis, string p_username, int PrestatieID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_PrestatieComponentModel_u01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_MDLDBC_Aantal",
Value = p_MDLDBC_Aantal
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_MDLDBC_Specialisten",
Value = p_MDLDBC_Specialisten
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_MDLDBC_Ziekenhuis",
Value = p_MDLDBC_Ziekenhuis
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_username",
Value = p_username
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PrestatieID",
Value = PrestatieID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_PrestatieComponentPassantenTarief_i01<T>(ref int l_DBC_ID, int p_CON_ID, decimal p_CONDBC_Specialisten, decimal p_CONDBC_Ziekenhuis, System.DateTime p_DatumIngang, char p_DeclaratieCode, decimal p_PoortSpecialismePrijs, string p_prestatieCode, string p_SPC_Code, string p_username)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_PrestatieComponentPassantenTarief_i01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@l_DBC_ID",
Value = l_DBC_ID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_CON_ID",
Value = p_CON_ID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_CONDBC_Specialisten",
Value = p_CONDBC_Specialisten
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_CONDBC_Ziekenhuis",
Value = p_CONDBC_Ziekenhuis
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_DatumIngang",
Value = p_DatumIngang
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_DeclaratieCode",
Value = p_DeclaratieCode
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_PoortSpecialismePrijs",
Value = p_PoortSpecialismePrijs
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_prestatieCode",
Value = p_prestatieCode
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_SPC_Code",
Value = p_SPC_Code
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_username",
Value = p_username
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_PrestatieComponentPassantenTarief_i02<T>(int p_CON_ID, int p_CONDBC_Aantal, decimal p_CONDBC_Specialisten, decimal p_CONDBC_Ziekenhuis, int p_DBC_ID, char p_status, string p_username)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_PrestatieComponentPassantenTarief_i02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_CON_ID",
Value = p_CON_ID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_CONDBC_Aantal",
Value = p_CONDBC_Aantal
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_CONDBC_Specialisten",
Value = p_CONDBC_Specialisten
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_CONDBC_Ziekenhuis",
Value = p_CONDBC_Ziekenhuis
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_DBC_ID",
Value = p_DBC_ID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_status",
Value = p_status
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_username",
Value = p_username
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_PrestatieFilter_s01<T>(bool InclSpeerpunt, int InstantieID, System.DateTime PeriodeEind, System.DateTime PeriodeStart, string Segment)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_PrestatieFilter_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InclSpeerpunt",
Value = InclSpeerpunt
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieID",
Value = InstantieID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PeriodeEind",
Value = PeriodeEind
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PeriodeStart",
Value = PeriodeStart
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Segment",
Value = Segment
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_PrestatiesOpGrijzeEnZwarteLijst_d01<T>(int AfspraakId)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_PrestatiesOpGrijzeEnZwarteLijst_d01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakId",
Value = AfspraakId
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ProductieAfspraken_d01<T>(System.DateTime PeriodeEind, System.DateTime PeriodeStart, int ZVSID, int ZVZID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ProductieAfspraken_d01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PeriodeEind",
Value = PeriodeEind
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PeriodeStart",
Value = PeriodeStart
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVSID",
Value = ZVSID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVZID",
Value = ZVZID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ProductieAfspraken_u01<T>(bool AkkoordVerklaard, int Dagverpleging, int EerstePolikliniekbezoeken, int KlinischeOpname, string OpgegevenDoor, System.DateTime PeriodeEind, System.DateTime PeriodeStart, int PolikliniekbezoekenTotaal, int Verpleegdagen, int ZVSID, int ZVZID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ProductieAfspraken_u01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AkkoordVerklaard",
Value = AkkoordVerklaard
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Dagverpleging",
Value = Dagverpleging
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@EerstePolikliniekbezoeken",
Value = EerstePolikliniekbezoeken
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@KlinischeOpname",
Value = KlinischeOpname
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@OpgegevenDoor",
Value = OpgegevenDoor
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PeriodeEind",
Value = PeriodeEind
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PeriodeStart",
Value = PeriodeStart
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PolikliniekbezoekenTotaal",
Value = PolikliniekbezoekenTotaal
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Verpleegdagen",
Value = Verpleegdagen
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVSID",
Value = ZVSID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVZID",
Value = ZVZID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_RegelResultaat_u01<T>(int AfspraakID, int InstantieRegelID, string ResultaatToelichting, int UitgevoerdDoorID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_RegelResultaat_u01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieRegelID",
Value = InstantieRegelID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ResultaatToelichting",
Value = ResultaatToelichting
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@UitgevoerdDoorID",
Value = UitgevoerdDoorID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_RegelResultaat_u02<T>(int AfspraakID, int InstantieRegelID, int UitgevoerdDoorID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_RegelResultaat_u02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieRegelID",
Value = InstantieRegelID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@UitgevoerdDoorID",
Value = UitgevoerdDoorID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Sjabloon_i01<T>(string Code, string Omschrijving, ref int SjabloonAfspraakID, string Username)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Sjabloon_i01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Code",
Value = Code
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Omschrijving",
Value = Omschrijving
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@SjabloonAfspraakID",
Value = SjabloonAfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Username",
Value = Username
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Sjabloon_s01<T>(string segment, int ZorgSoort)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Sjabloon_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@segment",
Value = segment
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgSoort",
Value = ZorgSoort
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_contract_i07<T>(int p_AfspraakID, ref int p_AfspraakIDContract, bool p_AutomatischGeaccordeerd, ref int p_ContractAfspraakID, string p_UserName)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_contract_i07",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfspraakID",
Value = p_AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfspraakIDContract",
Value = p_AfspraakIDContract
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AutomatischGeaccordeerd",
Value = p_AutomatischGeaccordeerd
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_ContractAfspraakID",
Value = p_ContractAfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_UserName",
Value = p_UserName
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Sjabloon_s02<T>(ref int AfspraakID, int SjabloonAfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Sjabloon_s02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@SjabloonAfspraakID",
Value = SjabloonAfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_contract_i08<T>(int p_AfspraakID, ref int p_AfspraakIDContract, bool p_AutomatischGeaccordeerd, string p_UserName)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_contract_i08",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfspraakID",
Value = p_AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfspraakIDContract",
Value = p_AfspraakIDContract
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AutomatischGeaccordeerd",
Value = p_AutomatischGeaccordeerd
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_UserName",
Value = p_UserName
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Sjabloon_s03<T>(int SjabloonAfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Sjabloon_s03",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@SjabloonAfspraakID",
Value = SjabloonAfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Onderhandeling_d04<T>(int p_AfspraakID, int p_InstantieId)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Onderhandeling_d04",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfspraakID",
Value = p_AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_InstantieId",
Value = p_InstantieId
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Sjabloon_s04<T>(int AfspraakIDSjabloonNieuw, int AfspraakIDSjabloonVorig, ref bool Identiek)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Sjabloon_s04",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakIDSjabloonNieuw",
Value = AfspraakIDSjabloonNieuw
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakIDSjabloonVorig",
Value = AfspraakIDSjabloonVorig
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Identiek",
Value = Identiek
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Onderhandeling_d05<T>(int p_AfspraakID, string p_bevestigingsTekst, int p_InstantieId, string p_UserName)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Onderhandeling_d05",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfspraakID",
Value = p_AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_bevestigingsTekst",
Value = p_bevestigingsTekst
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_InstantieId",
Value = p_InstantieId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_UserName",
Value = p_UserName
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Sjabloon_s05<T>(int InstantieId, int ZorgSoort)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Sjabloon_s05",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieId",
Value = InstantieId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgSoort",
Value = ZorgSoort
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Onderhandeling_i10<T>(string AangemaaktDoor, int AfspraakIDSjabloon, System.DateTime EindDatum, int InitierendeInstantieTypeID, ref int NieuweAfspraakID, int OnderhandelingUitgangspositieID, System.DateTime StartDatum, int ZorgverstrekkerID, int ZorgverzekeraarID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Onderhandeling_i10",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AangemaaktDoor",
Value = AangemaaktDoor
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakIDSjabloon",
Value = AfspraakIDSjabloon
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@EindDatum",
Value = EindDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InitierendeInstantieTypeID",
Value = InitierendeInstantieTypeID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@NieuweAfspraakID",
Value = NieuweAfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@OnderhandelingUitgangspositieID",
Value = OnderhandelingUitgangspositieID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@StartDatum",
Value = StartDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgverstrekkerID",
Value = ZorgverstrekkerID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgverzekeraarID",
Value = ZorgverzekeraarID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_SpeerpuntAfspraak_s01<T>(System.DateTime periodeEind, System.DateTime periodeStart, string Segment, int ZorgverstrekkerID, int ZorgverzekeraarID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_SpeerpuntAfspraak_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@periodeEind",
Value = periodeEind
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@periodeStart",
Value = periodeStart
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Segment",
Value = Segment
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgverstrekkerID",
Value = ZorgverstrekkerID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgverzekeraarID",
Value = ZorgverzekeraarID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Onderhandeling_i12<T>(int p_AfspraakID_From, ref int p_AfspraakIDVorigeVersie, string p_bevestigingsTekst, ref int p_newId, ref System.Guid p_NewVersieID, ref int p_OnderhandelingAfspraakID, string p_UserName)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Onderhandeling_i12",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfspraakID_From",
Value = p_AfspraakID_From
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfspraakIDVorigeVersie",
Value = p_AfspraakIDVorigeVersie
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_bevestigingsTekst",
Value = p_bevestigingsTekst
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_newId",
Value = p_newId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_NewVersieID",
Value = p_NewVersieID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_OnderhandelingAfspraakID",
Value = p_OnderhandelingAfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_UserName",
Value = p_UserName
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_1416Gelijk_Check<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_1416Gelijk_Check",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Onderhandeling_i14<T>(int p_AfspraakID_From, string p_bevestigingsTekst, int p_InstantieId, ref int p_newId, ref System.Guid p_NewVersieID, string p_Username)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Onderhandeling_i14",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfspraakID_From",
Value = p_AfspraakID_From
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_bevestigingsTekst",
Value = p_bevestigingsTekst
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_InstantieId",
Value = p_InstantieId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_newId",
Value = p_newId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_NewVersieID",
Value = p_NewVersieID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_Username",
Value = p_Username
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_1517Gelijk_Check<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_1517Gelijk_Check",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Onderhandeling_u05<T>(int p_AfspraakId, int p_InstantieId, string p_UserName)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Onderhandeling_u05",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfspraakId",
Value = p_AfspraakId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_InstantieId",
Value = p_InstantieId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_UserName",
Value = p_UserName
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_ABSegmentZorgproductenPoorter_Check<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_ABSegmentZorgproductenPoorter_Check",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Onderhandeling_u11<T>(int p_AfspraakId, string p_bevestigingsTekst, string p_GewijzigdDoor, int p_NewAkkoordStatus, string p_UserName)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Onderhandeling_u11",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfspraakId",
Value = p_AfspraakId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_bevestigingsTekst",
Value = p_bevestigingsTekst
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_GewijzigdDoor",
Value = p_GewijzigdDoor
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_NewAkkoordStatus",
Value = p_NewAkkoordStatus
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_UserName",
Value = p_UserName
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_CompleetheidInkoopAgisAchmea_Check<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_CompleetheidInkoopAgisAchmea_Check",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Onderhandeling_u13<T>(int AfspraakId, string BevestigingsTekst, string GewijzigdDoor, int NieuweOnderhandelingStatus, string UserName)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Onderhandeling_u13",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakId",
Value = AfspraakId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@BevestigingsTekst",
Value = BevestigingsTekst
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@GewijzigdDoor",
Value = GewijzigdDoor
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@NieuweOnderhandelingStatus",
Value = NieuweOnderhandelingStatus
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@UserName",
Value = UserName
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_Correcte17CodesAgisAchmea_Check<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_Correcte17CodesAgisAchmea_Check",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Onderhandeling_u15<T>(int p_AfspraakId, int p_InstantieId, string p_UserName)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Onderhandeling_u15",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfspraakId",
Value = p_AfspraakId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_InstantieId",
Value = p_InstantieId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_UserName",
Value = p_UserName
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_Correcte17CodesAgisAchmeaComplement_Check<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_Correcte17CodesAgisAchmeaComplement_Check",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_MarktTariefHonorarium_Check<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_MarktTariefHonorarium_Check",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_Geen16Codes_Check<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_Geen16Codes_Check",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_MarktTariefKosten_Check<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_MarktTariefKosten_Check",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_GeenOnverzekerdeZorg_Check<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_GeenOnverzekerdeZorg_Check",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_MaxTariefHonorarium_Check<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_MaxTariefHonorarium_Check",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_GGZMutatieTarieven_Check<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_GGZMutatieTarieven_Check",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_MaxTariefKosten_Check<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_MaxTariefKosten_Check",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_GGZSjabloonMaxTarieven_Check<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_GGZSjabloonMaxTarieven_Check",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_MaxTariefTotaal_Check<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_MaxTariefTotaal_Check",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_ModelContractAanwezig_Check<T>(int AfspraakID, ref int ModelAfspraakID, ref string ModelContractCode, string ModelContractCodePrefix, ref int OnderhandelingAfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_ModelContractAanwezig_Check",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ModelAfspraakID",
Value = ModelAfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ModelContractCode",
Value = ModelContractCode
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ModelContractCodePrefix",
Value = ModelContractCodePrefix
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@OnderhandelingAfspraakID",
Value = OnderhandelingAfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_MinTariefHonorarium_Check<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_MinTariefHonorarium_Check",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_NegatieveTarieven_Check<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_NegatieveTarieven_Check",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_MinTariefKosten_Check<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_MinTariefKosten_Check",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_NulTariefHonorariumdeel_Check<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_NulTariefHonorariumdeel_Check",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Contract_i05<T>(int p_AfspraakID, ref int p_AfspraakIDContract, bool p_AutomatischGeaccordeerd, string p_UserName)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Contract_i05",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfspraakID",
Value = p_AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfspraakIDContract",
Value = p_AfspraakIDContract
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AutomatischGeaccordeerd",
Value = p_AutomatischGeaccordeerd
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_UserName",
Value = p_UserName
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_NulTariefKostendeel_Check<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_NulTariefKostendeel_Check",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Onderhandeling_i08<T>(int p_AfspraakID_From, string p_bevestigingsTekst, int p_InstantieId, ref int p_newId, ref System.Guid p_NewVersieID, string p_Username)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Onderhandeling_i08",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfspraakID_From",
Value = p_AfspraakID_From
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_bevestigingsTekst",
Value = p_bevestigingsTekst
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_InstantieId",
Value = p_InstantieId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_newId",
Value = p_newId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_NewVersieID",
Value = p_NewVersieID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_Username",
Value = p_Username
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_OnderhandelingBinnenSjabloon_Check<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_OnderhandelingBinnenSjabloon_Check",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Afspraak_s01<T>(int InstantieID, int ZVS_ID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Afspraak_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieID",
Value = InstantieID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVS_ID",
Value = ZVS_ID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_OntbrekenVolumina_Check<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_OntbrekenVolumina_Check",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Afspraak_s06<T>(int InstantieID, int PrestatieID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Afspraak_s06",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieID",
Value = InstantieID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PrestatieID",
Value = PrestatieID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_OvernemenPrijzen16Pendant_Check<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_OvernemenPrijzen16Pendant_Check",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Afspraak_s07<T>(System.DateTime BeginDatum, System.DateTime Einddatum, int InstantieID, char PoortSpecialismeCode, char PrestatieCode)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Afspraak_s07",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@BeginDatum",
Value = BeginDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Einddatum",
Value = Einddatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieID",
Value = InstantieID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PoortSpecialismeCode",
Value = PoortSpecialismeCode
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PrestatieCode",
Value = PrestatieCode
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_OvernemenPrijzen17Pendant_Check<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_OvernemenPrijzen17Pendant_Check",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Contract_i06<T>(ref int AfspraakID, char AGBCode, System.DateTime BeginDatum, string CreateUser, System.DateTime EindDatum, int InstantieSubType, string Omschrijving, string Segment, int SjabloonAfspraakID, char UZOVI)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Contract_i06",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AGBCode",
Value = AGBCode
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@BeginDatum",
Value = BeginDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@CreateUser",
Value = CreateUser
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@EindDatum",
Value = EindDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieSubType",
Value = InstantieSubType
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Omschrijving",
Value = Omschrijving
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Segment",
Value = Segment
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@SjabloonAfspraakID",
Value = SjabloonAfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@UZOVI",
Value = UZOVI
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_PrestatieBinnenGrijzeLijst_Check<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_PrestatieBinnenGrijzeLijst_Check",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Contract_i09<T>(ref int AfspraakID, char AGBCode, System.DateTime BeginDatum, ref int ContractAfspraakID, string CreateUser, System.DateTime EindDatum, int InstantieSubType, string Omschrijving, int SjabloonAfspraakID, char UZOVI)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Contract_i09",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AGBCode",
Value = AGBCode
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@BeginDatum",
Value = BeginDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ContractAfspraakID",
Value = ContractAfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@CreateUser",
Value = CreateUser
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@EindDatum",
Value = EindDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieSubType",
Value = InstantieSubType
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Omschrijving",
Value = Omschrijving
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@SjabloonAfspraakID",
Value = SjabloonAfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@UZOVI",
Value = UZOVI
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_PrestatieBinnenGrijzeLijst_Solve<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_PrestatieBinnenGrijzeLijst_Solve",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Contract_s06<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Contract_s06",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_PrestatiesVallenBinnenSjabloonRegel_Check<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_PrestatiesVallenBinnenSjabloonRegel_Check",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Contract_s07<T>(bool ActiveOnly, int AfspraakID, int AfspraakStijl, bool InclChildContracten, bool InclPassantenTarieven, int InstantieID, string Segment)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Contract_s07",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ActiveOnly",
Value = ActiveOnly
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakStijl",
Value = AfspraakStijl
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InclChildContracten",
Value = InclChildContracten
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InclPassantenTarieven",
Value = InclPassantenTarieven
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieID",
Value = InstantieID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Segment",
Value = Segment
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Validatie_TotaalHogerDanPassanten_Check<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Validatie_TotaalHogerDanPassanten_Check",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Contract_s08<T>(int jaartal, char uzovi, System.DateTime wijzigingenVanaf)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Contract_s08",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@jaartal",
Value = jaartal
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@uzovi",
Value = uzovi
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@wijzigingenVanaf",
Value = wijzigingenVanaf
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_VolumeSpecificatie_s01<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_VolumeSpecificatie_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Contract_s10<T>(int AfspraakID, int InstantieID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Contract_s10",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieID",
Value = InstantieID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_VolumeSpecificatie_s02<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_VolumeSpecificatie_s02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Contract_s11<T>(int CON_ID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Contract_s11",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@CON_ID",
Value = CON_ID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_VolumeSpecificatie_s03<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_VolumeSpecificatie_s03",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Afspraak_s05<T>(int AfspraakID, int InstantieID, int PrestatieID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Afspraak_s05",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieID",
Value = InstantieID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PrestatieID",
Value = PrestatieID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Contract_s14<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Contract_s14",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_VolumeSpecificatie_s04<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_VolumeSpecificatie_s04",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Afspraak_u01<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Afspraak_u01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Contract_s15<T>(int AnalyseRegioId, Overig.udtVarCharTable DeclaratieCodeList, int GroepId, int InstantieId, int InstantieSoort, System.DateTime PeilDatum, int ProvincieId, int RegioId, string Segment, bool ToonPassantenTarieven, Overig.udtVarCharTable ZorgProductList, int ZorgverstrekkerId, int ZorgverzekeraarId)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Contract_s15",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AnalyseRegioId",
Value = AnalyseRegioId
},
new SqlMagic.Lib.StoredProcedureTableTypeParameter()
{
Name = "@DeclaratieCodeList",
Table = DeclaratieCodeList
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@GroepId",
Value = GroepId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieId",
Value = InstantieId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieSoort",
Value = InstantieSoort
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PeilDatum",
Value = PeilDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ProvincieId",
Value = ProvincieId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@RegioId",
Value = RegioId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Segment",
Value = Segment
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ToonPassantenTarieven",
Value = ToonPassantenTarieven
},
new SqlMagic.Lib.StoredProcedureTableTypeParameter()
{
Name = "@ZorgProductList",
Table = ZorgProductList
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgverstrekkerId",
Value = ZorgverstrekkerId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgverzekeraarId",
Value = ZorgverzekeraarId
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_VolumeSpecificatie_s05<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_VolumeSpecificatie_s05",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Afspraak_u02<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Afspraak_u02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Contract_s16<T>(int ZorgverstrekkerID, int ZorgverzekeraarID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Contract_s16",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgverstrekkerID",
Value = ZorgverstrekkerID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgverzekeraarID",
Value = ZorgverzekeraarID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Afspraak_u03<T>(int AfspraakID, System.DateTime BeginDatum, System.DateTime EindDatum, string Username)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Afspraak_u03",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@BeginDatum",
Value = BeginDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@EindDatum",
Value = EindDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Username",
Value = Username
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Contract_s17<T>(bool ActiveOnly, int AfspraakID, bool InclChildContracten, int InstantieID, int ZorgsoortID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Contract_s17",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ActiveOnly",
Value = ActiveOnly
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InclChildContracten",
Value = InclChildContracten
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieID",
Value = InstantieID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgsoortID",
Value = ZorgsoortID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Afspraak_u04<T>(int AfspraakID, int InstantieID, string Username, System.Guid VersieID, ref System.Guid VersieIDNieuw)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Afspraak_u04",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieID",
Value = InstantieID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Username",
Value = Username
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@VersieID",
Value = VersieID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@VersieIDNieuw",
Value = VersieIDNieuw
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Contract_s18<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Contract_s18",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_BlacklistAfspraak_s01<T>(System.DateTime periodeEind, System.DateTime periodeStart, string Segment, int ZorgverstrekkerID, int ZorgverzekeraarID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_BlacklistAfspraak_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@periodeEind",
Value = periodeEind
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@periodeStart",
Value = periodeStart
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Segment",
Value = Segment
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgverstrekkerID",
Value = ZorgverstrekkerID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgverzekeraarID",
Value = ZorgverzekeraarID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ContractControleBestaandContractImportTool_s02<T>(char AGB, char AGBSoort, System.DateTime BeginDatum, ref bool BestaandContract, System.DateTime EindDatum, char UZOVI)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ContractControleBestaandContractImportTool_s02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AGB",
Value = AGB
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AGBSoort",
Value = AGBSoort
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@BeginDatum",
Value = BeginDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@BestaandContract",
Value = BestaandContract
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@EindDatum",
Value = EindDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@UZOVI",
Value = UZOVI
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Contract_d01<T>(int p_CON_ID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Contract_d01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_CON_ID",
Value = p_CON_ID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_GGZContractPrestatie_s01<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_GGZContractPrestatie_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Contract_d02<T>(int AfspraakId, int InstantieId, string Username)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Contract_d02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakId",
Value = AfspraakId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieId",
Value = InstantieId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Username",
Value = Username
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_GGZOnderhandelingPrestatie_s01<T>(int AfspraakID, bool AlleenIngesloten, int PrestatieTypeID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_GGZOnderhandelingPrestatie_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AlleenIngesloten",
Value = AlleenIngesloten
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PrestatieTypeID",
Value = PrestatieTypeID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Contract_d03<T>(int AfspraakId, int InstantieId, string Username)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Contract_d03",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakId",
Value = AfspraakId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieId",
Value = InstantieId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Username",
Value = Username
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ImportOnderhandeling8Data_u01<T>(int p_AfspraakID, char p_ImportInhoud, bool p_ImportPrices, bool p_ImportVolumes, System.Guid p_StagingImportPrijslijstBatchToken)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ImportOnderhandeling8Data_u01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfspraakID",
Value = p_AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_ImportInhoud",
Value = p_ImportInhoud
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_ImportPrices",
Value = p_ImportPrices
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_ImportVolumes",
Value = p_ImportVolumes
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_StagingImportPrijslijstBatchToken",
Value = p_StagingImportPrijslijstBatchToken
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Contract_d04<T>(int AfspraakId, int InstantieId, string Username)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Contract_d04",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakId",
Value = AfspraakId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieId",
Value = InstantieId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Username",
Value = Username
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ImportOnderhandelingData_u01<T>(int p_AfspraakID, bool p_ImportPrices, bool p_ImportVolumes, System.Guid p_StagingImportPrijslijstBatchToken)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ImportOnderhandelingData_u01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfspraakID",
Value = p_AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_ImportPrices",
Value = p_ImportPrices
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_ImportVolumes",
Value = p_ImportVolumes
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_StagingImportPrijslijstBatchToken",
Value = p_StagingImportPrijslijstBatchToken
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Contract_i04<T>(ref int p_identity, int p_SjabloonAfspraakID, int p_SubVersie, int p_Versie)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Contract_i04",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_identity",
Value = p_identity
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_SjabloonAfspraakID",
Value = p_SjabloonAfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_SubVersie",
Value = p_SubVersie
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_Versie",
Value = p_Versie
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ImportPassantenTarieven_u01<T>(ref int RecordsInserted, ref int RecordsUpdated, int TogImportBatchLogID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ImportPassantenTarieven_u01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@RecordsInserted",
Value = RecordsInserted
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@RecordsUpdated",
Value = RecordsUpdated
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@TogImportBatchLogID",
Value = TogImportBatchLogID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Contract_s12<T>(ref int AfspraakID, char p_Segment, int p_ZorgverstrekkerID, int p_ZorgverzekeraarID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Contract_s12",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_Segment",
Value = p_Segment
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_ZorgverstrekkerID",
Value = p_ZorgverstrekkerID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_ZorgverzekeraarID",
Value = p_ZorgverzekeraarID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Model_iu01<T>(ref int l_identity, string p_MDL_Code, string p_MDL_Omschrijving, string p_username, char p_ZVS_AGBCode, char p_ZVZ_UZOVI)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Model_iu01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@l_identity",
Value = l_identity
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_MDL_Code",
Value = p_MDL_Code
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_MDL_Omschrijving",
Value = p_MDL_Omschrijving
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_username",
Value = p_username
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_ZVS_AGBCode",
Value = p_ZVS_AGBCode
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_ZVZ_UZOVI",
Value = p_ZVZ_UZOVI
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Contract_s13<T>(int AfspraakID, int AfspraakIDSjabloon, ref bool Match)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Contract_s13",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakIDSjabloon",
Value = AfspraakIDSjabloon
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Match",
Value = Match
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Model_s01<T>(int AfspraakStijl, System.DateTime BeginDatum, System.DateTime EindDatum, int InstantieID, string Segment)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Model_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakStijl",
Value = AfspraakStijl
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@BeginDatum",
Value = BeginDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@EindDatum",
Value = EindDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieID",
Value = InstantieID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Segment",
Value = Segment
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Contract_u03<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Contract_u03",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Onderhandeling_i06<T>(int AfspraakIDBlacklist, int AfspraakIDSjabloon, int AfspraakIDSpeerpunt, bool AutomatischGestart, int CPN_ZVS_ID, int CPN_ZVZ_ID, System.DateTime EindDatum, int INITIATOR, bool IsPseudoOnderhandeling, ref int NewAfspraakID, int OnderhandelingUitgangspositieID, string SegmentCode, System.DateTime StartDatum, string USERNAME, int ZVS_ID, int ZVZ_ID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Onderhandeling_i06",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakIDBlacklist",
Value = AfspraakIDBlacklist
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakIDSjabloon",
Value = AfspraakIDSjabloon
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakIDSpeerpunt",
Value = AfspraakIDSpeerpunt
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AutomatischGestart",
Value = AutomatischGestart
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@CPN_ZVS_ID",
Value = CPN_ZVS_ID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@CPN_ZVZ_ID",
Value = CPN_ZVZ_ID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@EindDatum",
Value = EindDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@INITIATOR",
Value = INITIATOR
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@IsPseudoOnderhandeling",
Value = IsPseudoOnderhandeling
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@NewAfspraakID",
Value = NewAfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@OnderhandelingUitgangspositieID",
Value = OnderhandelingUitgangspositieID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@SegmentCode",
Value = SegmentCode
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@StartDatum",
Value = StartDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@USERNAME",
Value = USERNAME
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVS_ID",
Value = ZVS_ID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVZ_ID",
Value = ZVZ_ID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Contract_u04<T>(int afspraakId)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Contract_u04",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@afspraakId",
Value = afspraakId
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Onderhandeling_i07<T>(int p_AfspraakID_From, string p_bevestigingsTekst, int p_InstantieId, ref int p_NewId, ref System.Guid p_NewVersieID, string p_Username, string p_VoorgesteldDoor)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Onderhandeling_i07",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfspraakID_From",
Value = p_AfspraakID_From
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_bevestigingsTekst",
Value = p_bevestigingsTekst
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_InstantieId",
Value = p_InstantieId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_NewId",
Value = p_NewId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_NewVersieID",
Value = p_NewVersieID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_Username",
Value = p_Username
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_VoorgesteldDoor",
Value = p_VoorgesteldDoor
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ContractAfspraak_u01<T>(int AfspraakID, int ContactPersoonZVSID, int ContactPersoonZVZID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ContractAfspraak_u01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ContactPersoonZVSID",
Value = ContactPersoonZVSID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ContactPersoonZVZID",
Value = ContactPersoonZVZID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Onderhandeling_i09<T>(int AfspraakIDBlacklist, int AfspraakIDSjabloon, int AfspraakIDSpeerpunt, bool AutomatischGestart, int CPN_ZVS_ID, int CPN_ZVZ_ID, System.DateTime EindDatum, int INITIATOR, bool IsPseudoOnderhandeling, ref int NewAfspraakID, int OnderhandelingUitgangspositieID, string SegmentCode, System.DateTime StartDatum, string USERNAME, int ZVS_ID, int ZVZ_ID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Onderhandeling_i09",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakIDBlacklist",
Value = AfspraakIDBlacklist
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakIDSjabloon",
Value = AfspraakIDSjabloon
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakIDSpeerpunt",
Value = AfspraakIDSpeerpunt
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AutomatischGestart",
Value = AutomatischGestart
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@CPN_ZVS_ID",
Value = CPN_ZVS_ID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@CPN_ZVZ_ID",
Value = CPN_ZVZ_ID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@EindDatum",
Value = EindDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@INITIATOR",
Value = INITIATOR
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@IsPseudoOnderhandeling",
Value = IsPseudoOnderhandeling
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@NewAfspraakID",
Value = NewAfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@OnderhandelingUitgangspositieID",
Value = OnderhandelingUitgangspositieID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@SegmentCode",
Value = SegmentCode
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@StartDatum",
Value = StartDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@USERNAME",
Value = USERNAME
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVS_ID",
Value = ZVS_ID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVZ_ID",
Value = ZVZ_ID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ContractAfspraakBijlagen_s01<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ContractAfspraakBijlagen_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Onderhandeling_i11<T>(int p_AfspraakID_From, string p_bevestigingsTekst, ref int p_NewId, ref System.Guid p_NewVersieID, ref int p_OnderhandelingAfspraakID, string p_UserName, string p_VoorgesteldDoor, ref int p_ZorgSoort)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Onderhandeling_i11",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfspraakID_From",
Value = p_AfspraakID_From
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_bevestigingsTekst",
Value = p_bevestigingsTekst
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_NewId",
Value = p_NewId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_NewVersieID",
Value = p_NewVersieID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_OnderhandelingAfspraakID",
Value = p_OnderhandelingAfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_UserName",
Value = p_UserName
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_VoorgesteldDoor",
Value = p_VoorgesteldDoor
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_ZorgSoort",
Value = p_ZorgSoort
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ContractControleBestaandContract_s01<T>(System.DateTime BeginDatum, ref bool BestaandContract, string Segment, int ZorgSoort, int ZVS_ID, int ZVZ_ID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ContractControleBestaandContract_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@BeginDatum",
Value = BeginDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@BestaandContract",
Value = BestaandContract
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Segment",
Value = Segment
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgSoort",
Value = ZorgSoort
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVS_ID",
Value = ZVS_ID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVZ_ID",
Value = ZVZ_ID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_onderhandeling_i13<T>(int p_AfspraakID_From, string p_bevestigingsTekst, int p_InstantieId, ref int p_NewId, ref System.Guid p_NewVersieID, string p_Username, string p_VoorgesteldDoor)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_onderhandeling_i13",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfspraakID_From",
Value = p_AfspraakID_From
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_bevestigingsTekst",
Value = p_bevestigingsTekst
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_InstantieId",
Value = p_InstantieId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_NewId",
Value = p_NewId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_NewVersieID",
Value = p_NewVersieID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_Username",
Value = p_Username
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_VoorgesteldDoor",
Value = p_VoorgesteldDoor
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ContractControleBestaandContract_s02<T>(int AfspraakID, System.DateTime BeginDatum, ref bool BestaandContract, System.DateTime EindDatum, string Segment)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ContractControleBestaandContract_s02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@BeginDatum",
Value = BeginDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@BestaandContract",
Value = BestaandContract
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@EindDatum",
Value = EindDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Segment",
Value = Segment
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_InstantieRegel_s01<T>(int AfspraakID, int InstantieRegelID, bool OnlyOutdated)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_InstantieRegel_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieRegelID",
Value = InstantieRegelID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@OnlyOutdated",
Value = OnlyOutdated
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Onderhandeling_s09<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Onderhandeling_s09",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ContractControleBestaandContract_s03<T>(int AfspraakID, ref bool BestaandContract)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ContractControleBestaandContract_s03",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@BestaandContract",
Value = BestaandContract
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Onderhandeling_s06<T>(int InstantieTypeID, int ZorgverstrekkerID, int ZorgverzekeraarID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Onderhandeling_s06",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieTypeID",
Value = InstantieTypeID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgverstrekkerID",
Value = ZorgverstrekkerID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgverzekeraarID",
Value = ZorgverzekeraarID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Onderhandeling_u04<T>(int p_AfspraakId, string p_bevestigingsTekst, string p_GewijzigdDoor, int p_InstantieId, int p_NewStatus, string p_UserName)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Onderhandeling_u04",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfspraakId",
Value = p_AfspraakId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_bevestigingsTekst",
Value = p_bevestigingsTekst
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_GewijzigdDoor",
Value = p_GewijzigdDoor
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_InstantieId",
Value = p_InstantieId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_NewStatus",
Value = p_NewStatus
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_UserName",
Value = p_UserName
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ContractExport_s01<T>(int AfspraakID, bool AlleTarieven, char ExportInhoud)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ContractExport_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AlleTarieven",
Value = AlleTarieven
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ExportInhoud",
Value = ExportInhoud
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Onderhandeling_s07<T>(int AfspraakStijl, int InstantieTypeID, string SegmentCode, int ZorgverstrekkerID, int ZorgverzekeraarID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Onderhandeling_s07",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakStijl",
Value = AfspraakStijl
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieTypeID",
Value = InstantieTypeID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@SegmentCode",
Value = SegmentCode
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgverstrekkerID",
Value = ZorgverstrekkerID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgverzekeraarID",
Value = ZorgverzekeraarID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Onderhandeling_u09<T>(int p_AfspraakID, bool p_BijwerkenPrijslijst)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Onderhandeling_u09",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfspraakID",
Value = p_AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_BijwerkenPrijslijst",
Value = p_BijwerkenPrijslijst
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ContractGroep_s01<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ContractGroep_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Onderhandeling_s08<T>(System.DateTime BeginDatum, int CheckInstantieTypeId, System.DateTime EindDatum, ref bool OnderhandelingInPeriode, string Segment, int ZorgverstrekkerID, int ZorgverzekeraarID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Onderhandeling_s08",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@BeginDatum",
Value = BeginDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@CheckInstantieTypeId",
Value = CheckInstantieTypeId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@EindDatum",
Value = EindDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@OnderhandelingInPeriode",
Value = OnderhandelingInPeriode
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Segment",
Value = Segment
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgverstrekkerID",
Value = ZorgverstrekkerID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgverzekeraarID",
Value = ZorgverzekeraarID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Onderhandeling_u12<T>(int AfspraakId, string BevestigingsTekst, string GewijzigdDoor, int NieuweOnderhandelingStatus, string UserName)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Onderhandeling_u12",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakId",
Value = AfspraakId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@BevestigingsTekst",
Value = BevestigingsTekst
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@GewijzigdDoor",
Value = GewijzigdDoor
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@NieuweOnderhandelingStatus",
Value = NieuweOnderhandelingStatus
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@UserName",
Value = UserName
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ContractGroepsUitzondering_s01<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ContractGroepsUitzondering_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Onderhandeling_s10<T>(System.DateTime BeginDatum, System.DateTime EindDatum, int HuidigInstantieTypeId, ref bool OnderhandelingInPeriode, int ZorgSoortID, int ZorgverstrekkerID, int ZorgverzekeraarID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Onderhandeling_s10",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@BeginDatum",
Value = BeginDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@EindDatum",
Value = EindDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@HuidigInstantieTypeId",
Value = HuidigInstantieTypeId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@OnderhandelingInPeriode",
Value = OnderhandelingInPeriode
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgSoortID",
Value = ZorgSoortID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgverstrekkerID",
Value = ZorgverstrekkerID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgverzekeraarID",
Value = ZorgverzekeraarID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingAfspraakBijlage_i01<T>(int CON_ID, ref System.Guid ExtID, string FileName, ref int ID, string ToegevoegdDoor, int Type_ID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingAfspraakBijlage_i01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@CON_ID",
Value = CON_ID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ExtID",
Value = ExtID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@FileName",
Value = FileName
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ID",
Value = ID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ToegevoegdDoor",
Value = ToegevoegdDoor
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Type_ID",
Value = Type_ID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ContractPrijslijst_i09<T>(int AfspraakID, Afspraak.udt_GGZPrijslijstTable PrestatiePrijslijst)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ContractPrijslijst_i09",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureTableTypeParameter()
{
Name = "@PrestatiePrijslijst",
Table = PrestatiePrijslijst
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Onderhandeling_s11<T>(int InstantieID, int InstantieType, string SegmentCode, int ZorgSoort)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Onderhandeling_s11",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieID",
Value = InstantieID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieType",
Value = InstantieType
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@SegmentCode",
Value = SegmentCode
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgSoort",
Value = ZorgSoort
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingGroep_u02<T>(int OnderhandelingAfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingGroep_u02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@OnderhandelingAfspraakID",
Value = OnderhandelingAfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ContractPrijslijst_s02<T>(int AfspraakID, int InstantieID, bool VerrijkSjabloon)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ContractPrijslijst_s02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieID",
Value = InstantieID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@VerrijkSjabloon",
Value = VerrijkSjabloon
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Onderhandeling_s12<T>(int AfspraakId, int InstantieTypeID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Onderhandeling_s12",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakId",
Value = AfspraakId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieTypeID",
Value = InstantieTypeID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingGroepsIndeling_s01<T>(int AfspraakID, int InstantieID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingGroepsIndeling_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieID",
Value = InstantieID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ContractPrijslijst_s03<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ContractPrijslijst_s03",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Onderhandeling_u08<T>(int p_AfspraakId, string p_PrestatieFilterCode)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Onderhandeling_u08",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfspraakId",
Value = p_AfspraakId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_PrestatieFilterCode",
Value = p_PrestatieFilterCode
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingGroepsIndelingGroep_s01<T>(int AfspraakID, int GroepsIndelingID, int VergelijkingID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingGroepsIndelingGroep_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@GroepsIndelingID",
Value = GroepsIndelingID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@VergelijkingID",
Value = VergelijkingID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ContractPrijslijst_s04<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ContractPrijslijst_s04",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingAfspraakBijlage_s01<T>(int CON_ID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingAfspraakBijlage_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@CON_ID",
Value = CON_ID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingPrestatie_u03<T>(int AfspraakID, char DeclaratieCode, Afspraak.udtPrestatieInfoTable Prestaties, decimal PrijsHon0303, decimal PrijsHon0307, decimal PrijsHon0313, decimal PrijsHon0316, decimal PrijsHon0318, decimal PrijsHon0320, decimal PrijsHon0322, decimal PrijsHon0330, decimal PrijsHon0361, decimal PrijsHon0362, decimal PrijsHon0363, decimal PrijsHon0386, decimal PrijsHon0387, decimal PrijsHon0388, decimal PrijsHon0389, decimal PrijsHonNietOndh, decimal PrijsHonOverig, decimal PrijsZKH)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingPrestatie_u03",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@DeclaratieCode",
Value = DeclaratieCode
},
new SqlMagic.Lib.StoredProcedureTableTypeParameter()
{
Name = "@Prestaties",
Table = Prestaties
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PrijsHon0303",
Value = PrijsHon0303
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PrijsHon0307",
Value = PrijsHon0307
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PrijsHon0313",
Value = PrijsHon0313
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PrijsHon0316",
Value = PrijsHon0316
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PrijsHon0318",
Value = PrijsHon0318
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PrijsHon0320",
Value = PrijsHon0320
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PrijsHon0322",
Value = PrijsHon0322
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PrijsHon0330",
Value = PrijsHon0330
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PrijsHon0361",
Value = PrijsHon0361
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PrijsHon0362",
Value = PrijsHon0362
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PrijsHon0363",
Value = PrijsHon0363
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PrijsHon0386",
Value = PrijsHon0386
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PrijsHon0387",
Value = PrijsHon0387
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PrijsHon0388",
Value = PrijsHon0388
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PrijsHon0389",
Value = PrijsHon0389
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PrijsHonNietOndh",
Value = PrijsHonNietOndh
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PrijsHonOverig",
Value = PrijsHonOverig
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PrijsZKH",
Value = PrijsZKH
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ContractPrijslijstHonOndhComp_s02<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ContractPrijslijstHonOndhComp_s02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingFlowgegevens_s01<T>(int AfspraakId, int InstantieTypeID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingFlowgegevens_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakId",
Value = AfspraakId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieTypeID",
Value = InstantieTypeID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingPrestatie_u04<T>(int AfspraakID, int AfwBasis, object AfwHon0303, object AfwHon0307, object AfwHon0313, object AfwHon0316, object AfwHon0318, object AfwHon0320, object AfwHon0322, object AfwHon0330, object AfwHon0361, object AfwHon0362, object AfwHon0363, object AfwHon0386, object AfwHon0387, object AfwHon0388, object AfwHon0389, object AfwHonNietOndh, object AfwHonOndh, object AfwHonOverig, object AfwZKH, Overig.udtVarCharTable DeclaratieCodes, int GroepId, ref bool OnderhandelingGewijzigd)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingPrestatie_u04",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfwBasis",
Value = AfwBasis
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfwHon0303",
Value = AfwHon0303
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfwHon0307",
Value = AfwHon0307
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfwHon0313",
Value = AfwHon0313
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfwHon0316",
Value = AfwHon0316
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfwHon0318",
Value = AfwHon0318
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfwHon0320",
Value = AfwHon0320
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfwHon0322",
Value = AfwHon0322
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfwHon0330",
Value = AfwHon0330
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfwHon0361",
Value = AfwHon0361
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfwHon0362",
Value = AfwHon0362
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfwHon0363",
Value = AfwHon0363
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfwHon0386",
Value = AfwHon0386
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfwHon0387",
Value = AfwHon0387
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfwHon0388",
Value = AfwHon0388
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfwHon0389",
Value = AfwHon0389
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfwHonNietOndh",
Value = AfwHonNietOndh
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfwHonOndh",
Value = AfwHonOndh
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfwHonOverig",
Value = AfwHonOverig
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfwZKH",
Value = AfwZKH
},
new SqlMagic.Lib.StoredProcedureTableTypeParameter()
{
Name = "@DeclaratieCodes",
Table = DeclaratieCodes
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@GroepId",
Value = GroepId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@OnderhandelingGewijzigd",
Value = OnderhandelingGewijzigd
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_CreateModelContractFromOnderhandeling<T>(int p_AfspraakID, int p_InstantieType, ref int p_ModelAfspraakID, string p_ModelCode, string p_ModelOmschrijving)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_CreateModelContractFromOnderhandeling",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfspraakID",
Value = p_AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_InstantieType",
Value = p_InstantieType
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_ModelAfspraakID",
Value = p_ModelAfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_ModelCode",
Value = p_ModelCode
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_ModelOmschrijving",
Value = p_ModelOmschrijving
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingGroep_u03<T>(int p_OnderhandelingGroepID, bool p_SelectBack)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingGroep_u03",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_OnderhandelingGroepID",
Value = p_OnderhandelingGroepID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_SelectBack",
Value = p_SelectBack
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingPrestatie_u05<T>(int AfspraakID, ref bool OnderhandelingGewijzigd)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingPrestatie_u05",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@OnderhandelingGewijzigd",
Value = OnderhandelingGewijzigd
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_GGZOnderhandelingPrestatie_i01<T>(int AfspraakID, Afspraak.udt_GGZPrijslijstTable PrestatiePrijslijst)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_GGZOnderhandelingPrestatie_i01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureTableTypeParameter()
{
Name = "@PrestatiePrijslijst",
Table = PrestatiePrijslijst
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingGroep_u04<T>(int p_OnderhandelingAfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingGroep_u04",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_OnderhandelingAfspraakID",
Value = p_OnderhandelingAfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
}
public class Analyse
{
public SqlMagic.Lib.ISqlExecutor SqlExecutor { get; set; }
public class udtUpdateBehandelingZwarteLijst : System.Collections.Generic.List<udtUpdateBehandelingZwarteLijst.udtUpdateBehandelingZwarteLijstItem>
{
public class udtUpdateBehandelingZwarteLijstItem
{
public int UitsluitingId { get; set; }
public int ZorgverstrekkerId { get; set; }
public int PeriodeId { get; set; }
public int BehandelingId { get; set; }
}
}
public class udtZorgverstrekkerBudget : System.Collections.Generic.List<udtZorgverstrekkerBudget.udtZorgverstrekkerBudgetItem>
{
public class udtZorgverstrekkerBudgetItem
{
public int ZorgSoortId { get; set; }
public int OmzetAfspraakSoortId { get; set; }
public int ZorgverzekeraarId { get; set; }
public int ZorgverstrekkerId { get; set; }
public int PeriodeId { get; set; }
public int RegioId { get; set; }
public int CategorieId { get; set; }
public decimal BudgetTotaal { get; set; }
public decimal ExternContractTotaal { get; set; }
public decimal OmzetPlafond { get; set; }
public decimal MandaatTotaal { get; set; }
public decimal OmzetAfspraak { get; set; }
public decimal PrijsAfspraak { get; set; }
public bool OnderhandenWerk { get; set; }
public bool NietInAutoModelcontract { get; set; }
public bool Contracteerbaar { get; set; }
public string Inkoper { get; set; }
public string OnderhandenWerkMailadres { get; set; }
public string Contractnummer { get; set; }
public string IPZReferentie { get; set; }
public string PrijsAfspraakOmschrijving { get; set; }
}
}
public Analyse(SqlMagic.Lib.ISqlExecutor sqlExecutor)
{
SqlExecutor = sqlExecutor;
}
public SqlMagic.Lib.SqlResponse<T> csp_ZorgverstrekkerBudget_s03<T>(bool AlleenGecontracteerd, int CategorieId, bool InclContracten, bool InclOnderhandelingen, string Inkoper, int PeriodeId, int RegioId, int ZorgverstrekkerId, int ZorgverzekeraarId)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ZorgverstrekkerBudget_s03",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AlleenGecontracteerd",
Value = AlleenGecontracteerd
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@CategorieId",
Value = CategorieId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InclContracten",
Value = InclContracten
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InclOnderhandelingen",
Value = InclOnderhandelingen
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Inkoper",
Value = Inkoper
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PeriodeId",
Value = PeriodeId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@RegioId",
Value = RegioId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgverstrekkerId",
Value = ZorgverstrekkerId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgverzekeraarId",
Value = ZorgverzekeraarId
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ZorgverstrekkersScore_s01<T>(int AfspraakIDModel, bool AlleenSpeerpuntPrestaties, Overig.udtIntTable Categorien, bool GeenSpeerpuntPrestaties, bool InclContracten, bool InclOnderhandelingen, int RapportagePeriodeID, int ZorgverzekeraarID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ZorgverstrekkersScore_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakIDModel",
Value = AfspraakIDModel
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AlleenSpeerpuntPrestaties",
Value = AlleenSpeerpuntPrestaties
},
new SqlMagic.Lib.StoredProcedureTableTypeParameter()
{
Name = "@Categorien",
Table = Categorien
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@GeenSpeerpuntPrestaties",
Value = GeenSpeerpuntPrestaties
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InclContracten",
Value = InclContracten
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InclOnderhandelingen",
Value = InclOnderhandelingen
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@RapportagePeriodeID",
Value = RapportagePeriodeID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgverzekeraarID",
Value = ZorgverzekeraarID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ZorgverstrekkerBudget_s02<T>(bool AlleenGecontracteerd, int CategorieId, bool InclContracten, bool InclOnderhandelingen, string Inkoper, int PeriodeId, int RegioId, int ZorgverstrekkerId, int ZorgverzekeraarId)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ZorgverstrekkerBudget_s02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AlleenGecontracteerd",
Value = AlleenGecontracteerd
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@CategorieId",
Value = CategorieId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InclContracten",
Value = InclContracten
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InclOnderhandelingen",
Value = InclOnderhandelingen
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Inkoper",
Value = Inkoper
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PeriodeId",
Value = PeriodeId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@RegioId",
Value = RegioId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgverstrekkerId",
Value = ZorgverstrekkerId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgverzekeraarId",
Value = ZorgverzekeraarId
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ZorgverstrekkerBudget_s06<T>(bool AlleenGecontracteerd, int CategorieId, bool InclContracten, bool InclOnderhandelingen, string Inkoper, int PeriodeId, int RegioId, int ZorgverstrekkerId, int ZorgverzekeraarId)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ZorgverstrekkerBudget_s06",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AlleenGecontracteerd",
Value = AlleenGecontracteerd
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@CategorieId",
Value = CategorieId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InclContracten",
Value = InclContracten
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InclOnderhandelingen",
Value = InclOnderhandelingen
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Inkoper",
Value = Inkoper
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PeriodeId",
Value = PeriodeId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@RegioId",
Value = RegioId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgverstrekkerId",
Value = ZorgverstrekkerId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgverzekeraarId",
Value = ZorgverzekeraarId
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_BehandelingZwarteLijst_s01<T>(System.DateTime Peildatum, int ZorgverzekeraarId)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_BehandelingZwarteLijst_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Peildatum",
Value = Peildatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgverzekeraarId",
Value = ZorgverzekeraarId
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_BehandelingZwarteLijst_u01<T>(Analyse.udtUpdateBehandelingZwarteLijst UpdateList, int ZorgverzekeraarId)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_BehandelingZwarteLijst_u01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureTableTypeParameter()
{
Name = "@UpdateList",
Table = UpdateList
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgverzekeraarId",
Value = ZorgverzekeraarId
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Periode_s01<T>(System.DateTime DatumVanaf, bool p_SortDescending, int ZorgverzekeraarId)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Periode_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@DatumVanaf",
Value = DatumVanaf
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_SortDescending",
Value = p_SortDescending
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgverzekeraarId",
Value = ZorgverzekeraarId
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Stamgegeven_s01<T>(System.DateTime BeginDatum, System.DateTime EindDatum, string GroepSleutel, int ZorgverzekeraarId)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Stamgegeven_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@BeginDatum",
Value = BeginDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@EindDatum",
Value = EindDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@GroepSleutel",
Value = GroepSleutel
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgverzekeraarId",
Value = ZorgverzekeraarId
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ZorgverstrekkerBudget_d01<T>(int PeriodeId, int ZorgSoortId, int ZorgverstrekkerId, int ZorgverzekeraarId)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ZorgverstrekkerBudget_d01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PeriodeId",
Value = PeriodeId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgSoortId",
Value = ZorgSoortId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgverstrekkerId",
Value = ZorgverstrekkerId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgverzekeraarId",
Value = ZorgverzekeraarId
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ZorgverstrekkerBudget_s01<T>(int PeriodeId, int ZorgverstrekkerId, int ZorgverzekeraarId)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ZorgverstrekkerBudget_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PeriodeId",
Value = PeriodeId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgverstrekkerId",
Value = ZorgverstrekkerId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgverzekeraarId",
Value = ZorgverzekeraarId
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ZorgverstrekkerBudget_s04<T>(int ZorgverstrekkerId, int ZorgverzekeraarId)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ZorgverstrekkerBudget_s04",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgverstrekkerId",
Value = ZorgverstrekkerId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgverzekeraarId",
Value = ZorgverzekeraarId
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ZorgverstrekkerBudget_s05<T>(System.DateTime BeginDatum, System.DateTime EindDatum, int PeriodeId, int ZorgSoortId, int ZorgverstrekkerId, int ZorgverzekeraarId)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ZorgverstrekkerBudget_s05",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@BeginDatum",
Value = BeginDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@EindDatum",
Value = EindDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PeriodeId",
Value = PeriodeId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgSoortId",
Value = ZorgSoortId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgverstrekkerId",
Value = ZorgverstrekkerId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgverzekeraarId",
Value = ZorgverzekeraarId
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ZorgverstrekkerBudget_u01<T>(decimal BudgetTotaal, int CategorieId, bool Contracteerbaar, string Contractnummer, decimal ExternContractTotaal, string Inkoper, string IPZReferentie, decimal MandaatTotaal, bool NietInAutoModelcontract, decimal OmzetAfspraak, int OmzetAfspraakSoortId, decimal OmzetPlafond, bool OnderhandenWerk, string OnderhandenWerkMailadres, int PeriodeId, decimal PrijsAfspraak, string PrijsAfspraakOmschrijving, int RegioId, int ZorgSoortId, int ZorgverstrekkerId, int ZorgverzekeraarId)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ZorgverstrekkerBudget_u01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@BudgetTotaal",
Value = BudgetTotaal
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@CategorieId",
Value = CategorieId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Contracteerbaar",
Value = Contracteerbaar
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Contractnummer",
Value = Contractnummer
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ExternContractTotaal",
Value = ExternContractTotaal
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Inkoper",
Value = Inkoper
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@IPZReferentie",
Value = IPZReferentie
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@MandaatTotaal",
Value = MandaatTotaal
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@NietInAutoModelcontract",
Value = NietInAutoModelcontract
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@OmzetAfspraak",
Value = OmzetAfspraak
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@OmzetAfspraakSoortId",
Value = OmzetAfspraakSoortId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@OmzetPlafond",
Value = OmzetPlafond
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@OnderhandenWerk",
Value = OnderhandenWerk
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@OnderhandenWerkMailadres",
Value = OnderhandenWerkMailadres
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PeriodeId",
Value = PeriodeId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PrijsAfspraak",
Value = PrijsAfspraak
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PrijsAfspraakOmschrijving",
Value = PrijsAfspraakOmschrijving
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@RegioId",
Value = RegioId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgSoortId",
Value = ZorgSoortId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgverstrekkerId",
Value = ZorgverstrekkerId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgverzekeraarId",
Value = ZorgverzekeraarId
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ZorgverstrekkerBudgetBulk_u01<T>(Analyse.udtZorgverstrekkerBudget BudgetRegels)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ZorgverstrekkerBudgetBulk_u01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureTableTypeParameter()
{
Name = "@BudgetRegels",
Table = BudgetRegels
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
}
public class DataStaging
{
public SqlMagic.Lib.ISqlExecutor SqlExecutor { get; set; }
public DataStaging(SqlMagic.Lib.ISqlExecutor sqlExecutor)
{
SqlExecutor = sqlExecutor;
}
public SqlMagic.Lib.SqlResponse<T> csp_SpreadTogRecords<T>(int TogImportBatchLogID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_SpreadTogRecords",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@TogImportBatchLogID",
Value = TogImportBatchLogID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_TogRecordType36_d01<T>(int TogImportBatchLogID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_TogRecordType36_d01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@TogImportBatchLogID",
Value = TogImportBatchLogID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_TogRecordType36_i01<T>(char AanduidingPrestatiecodelijst, char DatumEindeTarief, char DatumIngangTarief, char DbcDeclaratieCode, char DbcDeclarerendSpecialisme, char DbcPoortspecialisme, ref int Identity, char IndicatieDebetCredit, char IndicatieSoortZorg, char Kenmerk, char KenmerkRecord, char Mutatiecode, char SoortTarief, char Tarief, char ToelichtingMutatie, char TypeTarief)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_TogRecordType36_i01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AanduidingPrestatiecodelijst",
Value = AanduidingPrestatiecodelijst
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@DatumEindeTarief",
Value = DatumEindeTarief
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@DatumIngangTarief",
Value = DatumIngangTarief
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@DbcDeclaratieCode",
Value = DbcDeclaratieCode
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@DbcDeclarerendSpecialisme",
Value = DbcDeclarerendSpecialisme
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@DbcPoortspecialisme",
Value = DbcPoortspecialisme
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Identity",
Value = Identity
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@IndicatieDebetCredit",
Value = IndicatieDebetCredit
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@IndicatieSoortZorg",
Value = IndicatieSoortZorg
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Kenmerk",
Value = Kenmerk
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@KenmerkRecord",
Value = KenmerkRecord
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Mutatiecode",
Value = Mutatiecode
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@SoortTarief",
Value = SoortTarief
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Tarief",
Value = Tarief
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ToelichtingMutatie",
Value = ToelichtingMutatie
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@TypeTarief",
Value = TypeTarief
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_TogRecordType36_u01<T>(int TogImportBatchLogID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_TogRecordType36_u01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@TogImportBatchLogID",
Value = TogImportBatchLogID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_TogRecordType38_d01<T>(int TogImportBatchLogID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_TogRecordType38_d01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@TogImportBatchLogID",
Value = TogImportBatchLogID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_TogRecordType38_u01<T>(int TogImportBatchLogID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_TogRecordType38_u01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@TogImportBatchLogID",
Value = TogImportBatchLogID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
}
public class Dbc
{
public SqlMagic.Lib.ISqlExecutor SqlExecutor { get; set; }
public Dbc(SqlMagic.Lib.ISqlExecutor sqlExecutor)
{
SqlExecutor = sqlExecutor;
}
public SqlMagic.Lib.SqlResponse<T> csp_PrestatieCode_s02<T>()
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_PrestatieCode_s02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_PrestatieCode_s03<T>(char PrestatieCode)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_PrestatieCode_s03",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PrestatieCode",
Value = PrestatieCode
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_PrestatieCode_s06<T>(char segmentCode)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_PrestatieCode_s06",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@segmentCode",
Value = segmentCode
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_PrestatieCode_s07<T>(char PoortSpecialismeCode, char PrestatieCode)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_PrestatieCode_s07",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PoortSpecialismeCode",
Value = PoortSpecialismeCode
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PrestatieCode",
Value = PrestatieCode
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Specialisme_s01<T>(bool AlleenHonCompSpecialismes)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Specialisme_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AlleenHonCompSpecialismes",
Value = AlleenHonCompSpecialismes
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Specialisme_s03<T>()
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Specialisme_s03",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_TariefWijzigingType_s01<T>()
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_TariefWijzigingType_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ZorgType_s01<T>()
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ZorgType_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ZorgVraag_s01<T>()
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ZorgVraag_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Prestatie_s03<T>(char AGBCode, string BEH_CODE, char DBC_DeclaratieCode, char DBCSEGMENTCODE, string DIA_CODE, int InstantieID, System.DateTime PeilDatumTotEnMet, System.DateTime PeilDatumVanaf, string SPC_CODE, char UZOVICode, char ZTY_CODE, char ZVR_CODE)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Prestatie_s03",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AGBCode",
Value = AGBCode
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@BEH_CODE",
Value = BEH_CODE
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@DBC_DeclaratieCode",
Value = DBC_DeclaratieCode
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@DBCSEGMENTCODE",
Value = DBCSEGMENTCODE
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@DIA_CODE",
Value = DIA_CODE
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieID",
Value = InstantieID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PeilDatumTotEnMet",
Value = PeilDatumTotEnMet
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PeilDatumVanaf",
Value = PeilDatumVanaf
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@SPC_CODE",
Value = SPC_CODE
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@UZOVICode",
Value = UZOVICode
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZTY_CODE",
Value = ZTY_CODE
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVR_CODE",
Value = ZVR_CODE
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Prestatie_s04<T>(string DBCCode, int InstantieID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Prestatie_s04",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@DBCCode",
Value = DBCCode
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieID",
Value = InstantieID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Behandeling_s01<T>()
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Behandeling_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_BehandelingStamdata_s01<T>()
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_BehandelingStamdata_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Diagnose_s01<T>()
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Diagnose_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Groepsindeling_s01<T>(ref string GroepNaam, int GroepsIndelingId)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Groepsindeling_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@GroepNaam",
Value = GroepNaam
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@GroepsIndelingId",
Value = GroepsIndelingId
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Periode_d01<T>(int p_PeriodeID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Periode_d01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_PeriodeID",
Value = p_PeriodeID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Periode_i01<T>(string p_Omschrijving, System.DateTime p_PeriodEnd, System.DateTime p_PeriodStart)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Periode_i01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_Omschrijving",
Value = p_Omschrijving
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_PeriodEnd",
Value = p_PeriodEnd
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_PeriodStart",
Value = p_PeriodStart
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Periode_s01<T>(System.DateTime DatumVanaf, bool p_SortDescending, int ZorgverzekeraarId)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Periode_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@DatumVanaf",
Value = DatumVanaf
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_SortDescending",
Value = p_SortDescending
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgverzekeraarId",
Value = ZorgverzekeraarId
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Periode_u01<T>(string p_Omschrijving, int p_PeriodeID, System.DateTime p_PeriodEnd, System.DateTime p_PeriodStart)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Periode_u01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_Omschrijving",
Value = p_Omschrijving
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_PeriodeID",
Value = p_PeriodeID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_PeriodEnd",
Value = p_PeriodEnd
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_PeriodStart",
Value = p_PeriodStart
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Prestatie_s05<T>(int PrestatieID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Prestatie_s05",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PrestatieID",
Value = PrestatieID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Prestatie_s06<T>(string Omschrijving)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Prestatie_s06",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Omschrijving",
Value = Omschrijving
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_PrestatieCode_s01<T>(int PrestatieID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_PrestatieCode_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PrestatieID",
Value = PrestatieID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
}
public class Help
{
public SqlMagic.Lib.ISqlExecutor SqlExecutor { get; set; }
public Help(SqlMagic.Lib.ISqlExecutor sqlExecutor)
{
SqlExecutor = sqlExecutor;
}
public SqlMagic.Lib.SqlResponse<T> csp_HelpLink_s01<T>(System.DateTime DatumActief, string LinkCode, string Username)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_HelpLink_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@DatumActief",
Value = DatumActief
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@LinkCode",
Value = LinkCode
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Username",
Value = Username
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
}
public class Logs
{
public SqlMagic.Lib.ISqlExecutor SqlExecutor { get; set; }
public Logs(SqlMagic.Lib.ISqlExecutor sqlExecutor)
{
SqlExecutor = sqlExecutor;
}
public SqlMagic.Lib.SqlResponse<T> csp_log4netentries_s01<T>(string p_Application, System.DateTime p_DateEnd, System.DateTime p_DateStart, string p_Identity, bool p_isTechnical, string p_Level)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_log4netentries_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_Application",
Value = p_Application
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_DateEnd",
Value = p_DateEnd
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_DateStart",
Value = p_DateStart
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_Identity",
Value = p_Identity
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_isTechnical",
Value = p_isTechnical
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_Level",
Value = p_Level
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingStatusLog_i01<T>(string ActieReden, int AfspraakId, string BevestigingsTekst, string GewijzigdDoor)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingStatusLog_i01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ActieReden",
Value = ActieReden
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakId",
Value = AfspraakId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@BevestigingsTekst",
Value = BevestigingsTekst
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@GewijzigdDoor",
Value = GewijzigdDoor
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingStatusLog_s01<T>(int AfspraakId)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingStatusLog_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakId",
Value = AfspraakId
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingStatusLog_s02<T>(int AfspraakId)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingStatusLog_s02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakId",
Value = AfspraakId
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OnderhandelingStatusLog_s03<T>(int EersteOnderhandelingId)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OnderhandelingStatusLog_s03",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@EersteOnderhandelingId",
Value = EersteOnderhandelingId
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
}
public class Organisatie
{
public SqlMagic.Lib.ISqlExecutor SqlExecutor { get; set; }
public Organisatie(SqlMagic.Lib.ISqlExecutor sqlExecutor)
{
SqlExecutor = sqlExecutor;
}
public SqlMagic.Lib.SqlResponse<T> csp_Gebruiker_s01<T>(string CommonName, int GebruikerID, bool InclusiefNietGeaccepteerd)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Gebruiker_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@CommonName",
Value = CommonName
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@GebruikerID",
Value = GebruikerID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InclusiefNietGeaccepteerd",
Value = InclusiefNietGeaccepteerd
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Gebruiker_i01<T>(string Achternaam, string CommonName, string CreateUser, string Email, string Tussenvoegsel, string Voorletters)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Gebruiker_i01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Achternaam",
Value = Achternaam
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@CommonName",
Value = CommonName
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@CreateUser",
Value = CreateUser
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Email",
Value = Email
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Tussenvoegsel",
Value = Tussenvoegsel
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Voorletters",
Value = Voorletters
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Gebruiker_s04<T>()
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Gebruiker_s04",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Gebruiker_s11<T>(bool InclusiefNietGeaccepteerd, int InstantieID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Gebruiker_s11",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InclusiefNietGeaccepteerd",
Value = InclusiefNietGeaccepteerd
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieID",
Value = InstantieID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Gebruiker_s13<T>()
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Gebruiker_s13",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Gebruiker_s14<T>(int InstantieID, bool ToonVoorgesteldeKoppelingen)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Gebruiker_s14",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieID",
Value = InstantieID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ToonVoorgesteldeKoppelingen",
Value = ToonVoorgesteldeKoppelingen
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Gebruiker_u02<T>(string Achternaam, string Email, int GebruikerID, bool InActief, string Tussenvoegsel, string UpdateUser, string Voorletters)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Gebruiker_u02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Achternaam",
Value = Achternaam
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Email",
Value = Email
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@GebruikerID",
Value = GebruikerID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InActief",
Value = InActief
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Tussenvoegsel",
Value = Tussenvoegsel
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@UpdateUser",
Value = UpdateUser
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Voorletters",
Value = Voorletters
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_GebruikerContactPersoon_s01<T>(bool IncludeDBCSUsers, int InstantieID, int ZorgsoortID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_GebruikerContactPersoon_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@IncludeDBCSUsers",
Value = IncludeDBCSUsers
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieID",
Value = InstantieID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgsoortID",
Value = ZorgsoortID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_GebruikerInstantie_d01<T>(string GebruikerIds, int InstantieID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_GebruikerInstantie_d01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@GebruikerIds",
Value = GebruikerIds
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieID",
Value = InstantieID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_GebruikerInstantie_d02<T>(int GebruikerId, int InstantieID, ref int RemainingInstantieCount)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_GebruikerInstantie_d02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@GebruikerId",
Value = GebruikerId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieID",
Value = InstantieID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@RemainingInstantieCount",
Value = RemainingInstantieCount
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_GebruikerInstantie_i01<T>(string CreateUser, int GebruikerID, int InstantieID, int KoppelingVoorgesteldDoor)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_GebruikerInstantie_i01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@CreateUser",
Value = CreateUser
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@GebruikerID",
Value = GebruikerID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieID",
Value = InstantieID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@KoppelingVoorgesteldDoor",
Value = KoppelingVoorgesteldDoor
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_GebruikerInstantie_u01<T>(int GebruikerId, int InstantieID, int KoppelingGeaccepteerdDoor)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_GebruikerInstantie_u01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@GebruikerId",
Value = GebruikerId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieID",
Value = InstantieID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@KoppelingGeaccepteerdDoor",
Value = KoppelingGeaccepteerdDoor
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_GebruikerRol_d00<T>(int GebruikerID, Overig.udtIntTable ZorgSoortIds)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_GebruikerRol_d00",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@GebruikerID",
Value = GebruikerID
},
new SqlMagic.Lib.StoredProcedureTableTypeParameter()
{
Name = "@ZorgSoortIds",
Table = ZorgSoortIds
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_GebruikerRol_i01<T>(string CreateUser, int GebruikerID, Overig.udtIntTable RolIds, Overig.udtIntTable ZorgSoortIds)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_GebruikerRol_i01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@CreateUser",
Value = CreateUser
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@GebruikerID",
Value = GebruikerID
},
new SqlMagic.Lib.StoredProcedureTableTypeParameter()
{
Name = "@RolIds",
Table = RolIds
},
new SqlMagic.Lib.StoredProcedureTableTypeParameter()
{
Name = "@ZorgSoortIds",
Table = ZorgSoortIds
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_GebruikerRol_s01<T>()
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_GebruikerRol_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Instantie_s01<T>(int InstantieTypeID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Instantie_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieTypeID",
Value = InstantieTypeID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Instantie_s02<T>(int InstantieID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Instantie_s02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieID",
Value = InstantieID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Instanties_s01<T>(int InstantieID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Instanties_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieID",
Value = InstantieID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_InstantieType_s00<T>()
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_InstantieType_s00",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Regio_s01<T>()
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Regio_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Rol_s01<T>()
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Rol_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Rol_s02<T>(int GebruikerID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Rol_s02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@GebruikerID",
Value = GebruikerID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_AGBSoort_s01<T>()
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_AGBSoort_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Rol_s03<T>()
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Rol_s03",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Gebruiker_s03<T>(string CommonName)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Gebruiker_s03",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@CommonName",
Value = CommonName
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Settings_i01<T>(int InstantieID, string SettingName, string SettingValue)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Settings_i01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieID",
Value = InstantieID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@SettingName",
Value = SettingName
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@SettingValue",
Value = SettingValue
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Gebruiker_s05<T>(string CommonName, Overig.udtIntTable ZorgSoorten)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Gebruiker_s05",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@CommonName",
Value = CommonName
},
new SqlMagic.Lib.StoredProcedureTableTypeParameter()
{
Name = "@ZorgSoorten",
Table = ZorgSoorten
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Settings_s01<T>(int InstantieID, string SettingName)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Settings_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieID",
Value = InstantieID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@SettingName",
Value = SettingName
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Gebruiker_s07<T>(string CommonName, System.DateTime totDatum, System.DateTime vanDatum, int ZorgSoort)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Gebruiker_s07",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@CommonName",
Value = CommonName
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@totDatum",
Value = totDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@vanDatum",
Value = vanDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgSoort",
Value = ZorgSoort
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Taak_s01<T>(int GebruikerID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Taak_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@GebruikerID",
Value = GebruikerID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Gebruiker_s08<T>(string CommonName, System.DateTime totDatum, System.DateTime vanDatum, int zorgSoort)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Gebruiker_s08",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@CommonName",
Value = CommonName
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@totDatum",
Value = totDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@vanDatum",
Value = vanDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@zorgSoort",
Value = zorgSoort
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Zorgverstrekker_s11<T>(int ZorgverstrekkerID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Zorgverstrekker_s11",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgverstrekkerID",
Value = ZorgverstrekkerID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Gebruiker_s09<T>(char VecozoCertificaatNummer)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Gebruiker_s09",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@VecozoCertificaatNummer",
Value = VecozoCertificaatNummer
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Zorgverstrekker_u01<T>(string Adres, char AGB, char AGBSoort, int CTGCategorie, int CTGNummer, string Email, int ID, bool Inactief, bool IsHoofdLocatie, string Naam, string Plaats, string Postcode, string Telefoonnummer, string UpdateUser, string Website)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Zorgverstrekker_u01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Adres",
Value = Adres
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AGB",
Value = AGB
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AGBSoort",
Value = AGBSoort
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@CTGCategorie",
Value = CTGCategorie
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@CTGNummer",
Value = CTGNummer
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Email",
Value = Email
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ID",
Value = ID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Inactief",
Value = Inactief
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@IsHoofdLocatie",
Value = IsHoofdLocatie
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Naam",
Value = Naam
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Plaats",
Value = Plaats
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Postcode",
Value = Postcode
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Telefoonnummer",
Value = Telefoonnummer
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@UpdateUser",
Value = UpdateUser
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Website",
Value = Website
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_GebruikerInstantie_s01<T>(int InstantieID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_GebruikerInstantie_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieID",
Value = InstantieID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Zorgverzekeraar_u01<T>(int ID, string Naam, string UpdateUser, char UZOVI, string Website)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Zorgverzekeraar_u01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ID",
Value = ID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Naam",
Value = Naam
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@UpdateUser",
Value = UpdateUser
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@UZOVI",
Value = UZOVI
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Website",
Value = Website
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_GebruikerInstantie_s02<T>()
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_GebruikerInstantie_s02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Provincie_s01<T>()
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Provincie_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Zorgverstrekker_s01<T>(char p_AGB, char p_AGBSoort, int p_CTGCategorie, int p_CTGNummer)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Zorgverstrekker_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AGB",
Value = p_AGB
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AGBSoort",
Value = p_AGBSoort
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_CTGCategorie",
Value = p_CTGCategorie
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_CTGNummer",
Value = p_CTGNummer
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Zorgverstrekker_s06<T>(System.DateTime totDatum, System.DateTime vanDatum, int zorgSoort)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Zorgverstrekker_s06",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@totDatum",
Value = totDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@vanDatum",
Value = vanDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@zorgSoort",
Value = zorgSoort
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Zorgverstrekker_s13<T>(char p_AGBParent)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Zorgverstrekker_s13",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AGBParent",
Value = p_AGBParent
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Zorgverzekeraar_s02<T>(string UZOVI)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Zorgverzekeraar_s02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@UZOVI",
Value = UZOVI
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Zorgverzekeraar_s10<T>(System.DateTime totDatum, System.DateTime vanDatum, int zorgSoort)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Zorgverzekeraar_s10",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@totDatum",
Value = totDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@vanDatum",
Value = vanDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@zorgSoort",
Value = zorgSoort
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
}
public class Overig
{
public SqlMagic.Lib.ISqlExecutor SqlExecutor { get; set; }
public class udtDateTimeTable : System.Collections.Generic.List<udtDateTimeTable.udtDateTimeTableItem>
{
public class udtDateTimeTableItem
{
public System.DateTime value { get; set; }
}
}
public class udtIntTable : System.Collections.Generic.List<udtIntTable.udtIntTableItem>
{
public class udtIntTableItem
{
public int value { get; set; }
}
}
public class udtPeriodeTable : System.Collections.Generic.List<udtPeriodeTable.udtPeriodeTableItem>
{
public class udtPeriodeTableItem
{
public System.DateTime StartDatum { get; set; }
public System.DateTime EindDatum { get; set; }
}
}
public class udtVarCharTable : System.Collections.Generic.List<udtVarCharTable.udtVarCharTableItem>
{
public class udtVarCharTableItem
{
public string value { get; set; }
}
}
public Overig(SqlMagic.Lib.ISqlExecutor sqlExecutor)
{
SqlExecutor = sqlExecutor;
}
public SqlMagic.Lib.SqlResponse<T> csp_RecordTypeAchmeaTIM_s01<T>(char AgbSoort, System.DateTime DatumTot, System.DateTime DatumVanaf, char Uzovi)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_RecordTypeAchmeaTIM_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AgbSoort",
Value = AgbSoort
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@DatumTot",
Value = DatumTot
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@DatumVanaf",
Value = DatumVanaf
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Uzovi",
Value = Uzovi
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_RecordTypeDatadump_s01<T>(char agbSoort, System.DateTime datumMax, System.DateTime datumMin, bool inclContracten, bool inclOnderhandelingen, char uzovi, Overig.udtIntTable zvsCategorieen)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_RecordTypeDatadump_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@agbSoort",
Value = agbSoort
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@datumMax",
Value = datumMax
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@datumMin",
Value = datumMin
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@inclContracten",
Value = inclContracten
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@inclOnderhandelingen",
Value = inclOnderhandelingen
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@uzovi",
Value = uzovi
},
new SqlMagic.Lib.StoredProcedureTableTypeParameter()
{
Name = "@zvsCategorieen",
Table = zvsCategorieen
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_RecordTypeDatadump_s02<T>(char agb, char agbSoort, bool inclContracten, bool inclNietSpeerpunten, bool inclOnderhandelingen, bool inclSpeerpunten, System.DateTime peildatum, char uzovi, string zorgproductCode, int zvsCategorie)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_RecordTypeDatadump_s02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@agb",
Value = agb
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@agbSoort",
Value = agbSoort
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@inclContracten",
Value = inclContracten
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@inclNietSpeerpunten",
Value = inclNietSpeerpunten
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@inclOnderhandelingen",
Value = inclOnderhandelingen
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@inclSpeerpunten",
Value = inclSpeerpunten
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@peildatum",
Value = peildatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@uzovi",
Value = uzovi
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@zorgproductCode",
Value = zorgproductCode
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@zvsCategorie",
Value = zvsCategorie
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_RecordTypeMZ_S01<T>(System.DateTime datumMax, System.DateTime datumMin, char uzovi, System.DateTime wijzigingenVanaf)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_RecordTypeMZ_S01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@datumMax",
Value = datumMax
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@datumMin",
Value = datumMin
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@uzovi",
Value = uzovi
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@wijzigingenVanaf",
Value = wijzigingenVanaf
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_RecordTypeMZ_s02<T>(System.DateTime datumMax, System.DateTime datumMin, char uzovi, System.DateTime wijzigingenVanaf)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_RecordTypeMZ_s02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@datumMax",
Value = datumMax
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@datumMin",
Value = datumMin
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@uzovi",
Value = uzovi
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@wijzigingenVanaf",
Value = wijzigingenVanaf
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ExportPeriode_s01<T>(bool alleenWijzigingen, System.DateTime datumMax, System.DateTime datumMin, bool inclActueleContracten, bool inclVervallenContracten, Afspraak.udtInstantiePeriodeTable nietTeExporterenZorgverstrekkers, decimal prijsZKHMin, char uzovi, System.DateTime wijzigingenVanaf)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ExportPeriode_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@alleenWijzigingen",
Value = alleenWijzigingen
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@datumMax",
Value = datumMax
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@datumMin",
Value = datumMin
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@inclActueleContracten",
Value = inclActueleContracten
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@inclVervallenContracten",
Value = inclVervallenContracten
},
new SqlMagic.Lib.StoredProcedureTableTypeParameter()
{
Name = "@nietTeExporterenZorgverstrekkers",
Table = nietTeExporterenZorgverstrekkers
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@prijsZKHMin",
Value = prijsZKHMin
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@uzovi",
Value = uzovi
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@wijzigingenVanaf",
Value = wijzigingenVanaf
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ExportPeriode_u01<T>(bool alleenWijzigingen, System.DateTime datumMax, System.DateTime datumMin, bool inclActueleContracten, bool inclVervallenContracten, Afspraak.udtInstantiePeriodeTable nietTeExporterenZorgverstrekkers, decimal prijsZKHMin, char uzovi, System.DateTime wijzigingenVanaf)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ExportPeriode_u01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@alleenWijzigingen",
Value = alleenWijzigingen
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@datumMax",
Value = datumMax
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@datumMin",
Value = datumMin
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@inclActueleContracten",
Value = inclActueleContracten
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@inclVervallenContracten",
Value = inclVervallenContracten
},
new SqlMagic.Lib.StoredProcedureTableTypeParameter()
{
Name = "@nietTeExporterenZorgverstrekkers",
Table = nietTeExporterenZorgverstrekkers
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@prijsZKHMin",
Value = prijsZKHMin
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@uzovi",
Value = uzovi
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@wijzigingenVanaf",
Value = wijzigingenVanaf
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_RecordType34_s01<T>(bool alleenWijzigingen, System.DateTime datumMax, System.DateTime datumMin, bool inclActueleContracten, bool inclVervallenContracten, Afspraak.udtInstantiePeriodeTable nietTeExporterenZorgverstrekkers, bool onderdrukNulTariefRegels, decimal prijsZKHMin, char uzovi, System.DateTime wijzigingenVanaf)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_RecordType34_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@alleenWijzigingen",
Value = alleenWijzigingen
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@datumMax",
Value = datumMax
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@datumMin",
Value = datumMin
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@inclActueleContracten",
Value = inclActueleContracten
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@inclVervallenContracten",
Value = inclVervallenContracten
},
new SqlMagic.Lib.StoredProcedureTableTypeParameter()
{
Name = "@nietTeExporterenZorgverstrekkers",
Table = nietTeExporterenZorgverstrekkers
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@onderdrukNulTariefRegels",
Value = onderdrukNulTariefRegels
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@prijsZKHMin",
Value = prijsZKHMin
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@uzovi",
Value = uzovi
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@wijzigingenVanaf",
Value = wijzigingenVanaf
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_RecordTypeCZ_S02<T>(bool alleenWijzigingen, System.DateTime datumMax, System.DateTime datumMin, bool inclActueleContracten, bool inclVervallenContracten, Afspraak.udtInstantiePeriodeTable nietTeExporterenZorgverstrekkers, decimal prijsZKHMin, char uzovi, System.DateTime wijzigingenVanaf)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_RecordTypeCZ_S02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@alleenWijzigingen",
Value = alleenWijzigingen
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@datumMax",
Value = datumMax
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@datumMin",
Value = datumMin
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@inclActueleContracten",
Value = inclActueleContracten
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@inclVervallenContracten",
Value = inclVervallenContracten
},
new SqlMagic.Lib.StoredProcedureTableTypeParameter()
{
Name = "@nietTeExporterenZorgverstrekkers",
Table = nietTeExporterenZorgverstrekkers
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@prijsZKHMin",
Value = prijsZKHMin
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@uzovi",
Value = uzovi
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@wijzigingenVanaf",
Value = wijzigingenVanaf
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_RecordTypeCZ_S03<T>(bool alleenWijzigingen, System.DateTime datumMax, System.DateTime datumMin, bool inclActueleContracten, bool inclVervallenContracten, Afspraak.udtInstantiePeriodeTable nietTeExporterenZorgverstrekkers, decimal prijsZKHMin, char uzovi, System.DateTime wijzigingenVanaf)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_RecordTypeCZ_S03",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@alleenWijzigingen",
Value = alleenWijzigingen
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@datumMax",
Value = datumMax
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@datumMin",
Value = datumMin
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@inclActueleContracten",
Value = inclActueleContracten
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@inclVervallenContracten",
Value = inclVervallenContracten
},
new SqlMagic.Lib.StoredProcedureTableTypeParameter()
{
Name = "@nietTeExporterenZorgverstrekkers",
Table = nietTeExporterenZorgverstrekkers
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@prijsZKHMin",
Value = prijsZKHMin
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@uzovi",
Value = uzovi
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@wijzigingenVanaf",
Value = wijzigingenVanaf
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_RecordTypeCZ_S04<T>(bool alleenWijzigingen, System.DateTime datumMax, System.DateTime datumMin, bool inclActueleContracten, bool inclVervallenContracten, Afspraak.udtInstantiePeriodeTable nietTeExporterenZorgverstrekkers, decimal prijsZKHMin, char uzovi, System.DateTime wijzigingenVanaf)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_RecordTypeCZ_S04",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@alleenWijzigingen",
Value = alleenWijzigingen
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@datumMax",
Value = datumMax
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@datumMin",
Value = datumMin
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@inclActueleContracten",
Value = inclActueleContracten
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@inclVervallenContracten",
Value = inclVervallenContracten
},
new SqlMagic.Lib.StoredProcedureTableTypeParameter()
{
Name = "@nietTeExporterenZorgverstrekkers",
Table = nietTeExporterenZorgverstrekkers
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@prijsZKHMin",
Value = prijsZKHMin
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@uzovi",
Value = uzovi
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@wijzigingenVanaf",
Value = wijzigingenVanaf
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_RecordTypeCZ_S05<T>(bool alleenWijzigingen, System.DateTime datumMax, System.DateTime datumMin, bool inclActueleContracten, bool inclVervallenContracten, Afspraak.udtInstantiePeriodeTable nietTeExporterenZorgverstrekkers, decimal prijsZKHMin, char uzovi, System.DateTime wijzigingenVanaf)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_RecordTypeCZ_S05",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@alleenWijzigingen",
Value = alleenWijzigingen
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@datumMax",
Value = datumMax
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@datumMin",
Value = datumMin
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@inclActueleContracten",
Value = inclActueleContracten
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@inclVervallenContracten",
Value = inclVervallenContracten
},
new SqlMagic.Lib.StoredProcedureTableTypeParameter()
{
Name = "@nietTeExporterenZorgverstrekkers",
Table = nietTeExporterenZorgverstrekkers
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@prijsZKHMin",
Value = prijsZKHMin
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@uzovi",
Value = uzovi
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@wijzigingenVanaf",
Value = wijzigingenVanaf
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_BijlageType_s01<T>()
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_BijlageType_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_DisclaimerGetoond_i01<T>(int AfspraakID, ref bool Toegevoegd, string Username)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_DisclaimerGetoond_i01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Toegevoegd",
Value = Toegevoegd
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Username",
Value = Username
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_DisclaimerGetoond_s01<T>(int AfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_DisclaimerGetoond_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Export_d01<T>(int ExportID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Export_d01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ExportID",
Value = ExportID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Export_i01<T>(string AGB, char AGBSoort, bool AlleenWijzigingen, System.DateTime BereikTot, System.DateTime BereikVan, string CategorieIds, string ExportIndicator, int exportType, int fileType, int HistorischJaartal, ref int identity, bool InclActueleContracten, bool InclNietSpeerpunten, bool InclSpeerpunten, bool InclVervallenContracten, string Inhoud, bool isNOW, decimal PrijsZKHMin, string referentie, System.DateTime wijzigingenVanaf, string ZorgproductCode, int ZVZ_ID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Export_i01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AGB",
Value = AGB
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AGBSoort",
Value = AGBSoort
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AlleenWijzigingen",
Value = AlleenWijzigingen
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@BereikTot",
Value = BereikTot
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@BereikVan",
Value = BereikVan
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@CategorieIds",
Value = CategorieIds
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ExportIndicator",
Value = ExportIndicator
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@exportType",
Value = exportType
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@fileType",
Value = fileType
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@HistorischJaartal",
Value = HistorischJaartal
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@identity",
Value = identity
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InclActueleContracten",
Value = InclActueleContracten
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InclNietSpeerpunten",
Value = InclNietSpeerpunten
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InclSpeerpunten",
Value = InclSpeerpunten
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InclVervallenContracten",
Value = InclVervallenContracten
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Inhoud",
Value = Inhoud
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@isNOW",
Value = isNOW
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@PrijsZKHMin",
Value = PrijsZKHMin
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@referentie",
Value = referentie
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@wijzigingenVanaf",
Value = wijzigingenVanaf
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZorgproductCode",
Value = ZorgproductCode
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVZ_ID",
Value = ZVZ_ID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Export_i02<T>(int exportType, int fileType, int HistorischJaartal, ref int identity, string referentie, int ZVZ_ID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Export_i02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@exportType",
Value = exportType
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@fileType",
Value = fileType
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@HistorischJaartal",
Value = HistorischJaartal
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@identity",
Value = identity
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@referentie",
Value = referentie
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVZ_ID",
Value = ZVZ_ID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Export_i03<T>(int exportType, int fileType, ref int identity, string referentie, int ZVZ_ID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Export_i03",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@exportType",
Value = exportType
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@fileType",
Value = fileType
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@identity",
Value = identity
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@referentie",
Value = referentie
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVZ_ID",
Value = ZVZ_ID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Automodellen_i01<T>(System.DateTime datumMax, System.DateTime datumMin, char uzovi)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Automodellen_i01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@datumMax",
Value = datumMax
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@datumMin",
Value = datumMin
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@uzovi",
Value = uzovi
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Export_u01<T>(int exportStatus, string fileName, int ID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Export_u01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@exportStatus",
Value = exportStatus
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@fileName",
Value = fileName
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ID",
Value = ID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Export_s01<T>(int ZVZ_ID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Export_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVZ_ID",
Value = ZVZ_ID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Export_u02<T>(string FileType, int ID, int ZVZ_ID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Export_u02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@FileType",
Value = FileType
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ID",
Value = ID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVZ_ID",
Value = ZVZ_ID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Export_s02<T>(int ExportID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Export_s02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ExportID",
Value = ExportID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ExportFileType_s01<T>()
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ExportFileType_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Export_s03<T>(char UZOVI)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Export_s03",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@UZOVI",
Value = UZOVI
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ExportType_s01<T>()
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ExportType_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_RecordType34_s03<T>(bool alleenWijzigingen, System.DateTime datumMax, System.DateTime datumMin, bool inclActueleContracten, bool inclVervallenContracten, Afspraak.udtInstantiePeriodeTable nietTeExporterenZorgverstrekkers, decimal prijsZKHMin, char uzovi, System.DateTime wijzigingenVanaf)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_RecordType34_s03",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@alleenWijzigingen",
Value = alleenWijzigingen
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@datumMax",
Value = datumMax
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@datumMin",
Value = datumMin
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@inclActueleContracten",
Value = inclActueleContracten
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@inclVervallenContracten",
Value = inclVervallenContracten
},
new SqlMagic.Lib.StoredProcedureTableTypeParameter()
{
Name = "@nietTeExporterenZorgverstrekkers",
Table = nietTeExporterenZorgverstrekkers
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@prijsZKHMin",
Value = prijsZKHMin
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@uzovi",
Value = uzovi
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@wijzigingenVanaf",
Value = wijzigingenVanaf
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_RecordTypeCZ_s01<T>(int CON_ID, System.DateTime wijzigingenVanaf)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_RecordTypeCZ_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@CON_ID",
Value = CON_ID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@wijzigingenVanaf",
Value = wijzigingenVanaf
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_RecordType45_s01<T>(int jaartal, char uzovi, System.DateTime wijzigingenVanaf)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_RecordType45_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@jaartal",
Value = jaartal
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@uzovi",
Value = uzovi
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@wijzigingenVanaf",
Value = wijzigingenVanaf
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_RecordTypeMenzisCsv_s01<T>(int CON_ID, System.DateTime wijzigingenVanaf)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_RecordTypeMenzisCsv_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@CON_ID",
Value = CON_ID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@wijzigingenVanaf",
Value = wijzigingenVanaf
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_RecordType45_s03<T>(int jaartalMax, int jaartalMin, char uzovi, System.DateTime wijzigingenVanaf)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_RecordType45_s03",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@jaartalMax",
Value = jaartalMax
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@jaartalMin",
Value = jaartalMin
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@uzovi",
Value = uzovi
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@wijzigingenVanaf",
Value = wijzigingenVanaf
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_SchemaChangeLog_s01<T>()
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_SchemaChangeLog_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Zorgprofiel_s01<T>(int startJaar, int zvsId, int zvzId)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Zorgprofiel_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@startJaar",
Value = startJaar
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@zvsId",
Value = zvsId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@zvzId",
Value = zvzId
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_TogImportBatchLog_i01<T>(System.DateTime ImportDatum, bool IsIncrementeel, ref int TogImportBatchLogID, int TogProductieNummer, int VersienummerBestand)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_TogImportBatchLog_i01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ImportDatum",
Value = ImportDatum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@IsIncrementeel",
Value = IsIncrementeel
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@TogImportBatchLogID",
Value = TogImportBatchLogID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@TogProductieNummer",
Value = TogProductieNummer
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@VersienummerBestand",
Value = VersienummerBestand
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_TogImportBatchLog_s01<T>()
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_TogImportBatchLog_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_TogImportBatchLog_u01<T>(int AantalRecordsAangepast, int AantalRecordsToegevoegd, int AantalRecordsVerwijderd, string Melding, int Status, string StatusInfo, int TogImportBatchLogID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_TogImportBatchLog_u01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AantalRecordsAangepast",
Value = AantalRecordsAangepast
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AantalRecordsToegevoegd",
Value = AantalRecordsToegevoegd
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AantalRecordsVerwijderd",
Value = AantalRecordsVerwijderd
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Melding",
Value = Melding
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Status",
Value = Status
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@StatusInfo",
Value = StatusInfo
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@TogImportBatchLogID",
Value = TogImportBatchLogID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_TogImportLog_i01<T>(System.DateTime Datum, ref int Identity, int ImportGeschiedenisID, string Omschrijving, int TogRecordType)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_TogImportLog_i01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Datum",
Value = Datum
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Identity",
Value = Identity
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ImportGeschiedenisID",
Value = ImportGeschiedenisID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Omschrijving",
Value = Omschrijving
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@TogRecordType",
Value = TogRecordType
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Zorgprofiel_d01<T>(int Jaar, int Tijdvak, int ZVSID, int ZVZID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Zorgprofiel_d01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Jaar",
Value = Jaar
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Tijdvak",
Value = Tijdvak
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVSID",
Value = ZVSID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVZID",
Value = ZVZID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Zorgprofiel_i01<T>(System.Guid FileGuid, string FileName, int Jaar, int Tijdvak, string ToegevoegdDoor, int ZVSID, int ZVZID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Zorgprofiel_i01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@FileGuid",
Value = FileGuid
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@FileName",
Value = FileName
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Jaar",
Value = Jaar
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Tijdvak",
Value = Tijdvak
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ToegevoegdDoor",
Value = ToegevoegdDoor
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVSID",
Value = ZVSID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ZVZID",
Value = ZVZID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Zorgprofiel_s02<T>(int startJaar, int tijdvak, int zvsId, int zvzId)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Zorgprofiel_s02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@startJaar",
Value = startJaar
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@tijdvak",
Value = tijdvak
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@zvsId",
Value = zvsId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@zvzId",
Value = zvzId
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
}
public class Rapportage
{
public SqlMagic.Lib.ISqlExecutor SqlExecutor { get; set; }
public Rapportage(SqlMagic.Lib.ISqlExecutor sqlExecutor)
{
SqlExecutor = sqlExecutor;
}
public SqlMagic.Lib.SqlResponse<T> csp_OverzichtOnderhandelingen_s01<T>(int InstantieID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OverzichtOnderhandelingen_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieID",
Value = InstantieID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ScoreSpeerpunten_s01<T>(int CategorieId, int Inhoud, int ModelAfspraak, int Niveau, int Periode, int RegioId, int Speerpunt, int Zorgverzekeraar)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ScoreSpeerpunten_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@CategorieId",
Value = CategorieId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Inhoud",
Value = Inhoud
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@ModelAfspraak",
Value = ModelAfspraak
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Niveau",
Value = Niveau
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Periode",
Value = Periode
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@RegioId",
Value = RegioId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Speerpunt",
Value = Speerpunt
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Zorgverzekeraar",
Value = Zorgverzekeraar
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Voortgang_s01<T>(int InstantieID, System.DateTime peildatum_1, System.DateTime peildatum_2)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Voortgang_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieID",
Value = InstantieID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@peildatum_1",
Value = peildatum_1
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@peildatum_2",
Value = peildatum_2
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_OverzichtContracten_s01<T>(int InstantieID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_OverzichtContracten_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@InstantieID",
Value = InstantieID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_Prijsvergelijking_s01<T>(char agb, bool inclNietSpeerpunten, bool inclSpeerpunten, int rapportageJaar, ref bool rapportageNotFound, int referentieJaar, ref bool referentieNotFound, int zorgverzekeraarId)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_Prijsvergelijking_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@agb",
Value = agb
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@inclNietSpeerpunten",
Value = inclNietSpeerpunten
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@inclSpeerpunten",
Value = inclSpeerpunten
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@rapportageJaar",
Value = rapportageJaar
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@rapportageNotFound",
Value = rapportageNotFound
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@referentieJaar",
Value = referentieJaar
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@referentieNotFound",
Value = referentieNotFound
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@zorgverzekeraarId",
Value = zorgverzekeraarId
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ModelAfspraak_s01<T>(int Zorgverzekeraar)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ModelAfspraak_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Zorgverzekeraar",
Value = Zorgverzekeraar
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_SjabloonPeriode_s01<T>(int Zorgverzekeraar)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_SjabloonPeriode_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Zorgverzekeraar",
Value = Zorgverzekeraar
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_SpeerpuntPeriode_s01<T>(int Zorgverzekeraar)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_SpeerpuntPeriode_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@Zorgverzekeraar",
Value = Zorgverzekeraar
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
}
public class Vergelijking
{
public SqlMagic.Lib.ISqlExecutor SqlExecutor { get; set; }
public Vergelijking(SqlMagic.Lib.ISqlExecutor sqlExecutor)
{
SqlExecutor = sqlExecutor;
}
public SqlMagic.Lib.SqlResponse<T> csp_CreateVergelijkingsPrestatieSet_i01<T>(int p_VergelijkingID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_CreateVergelijkingsPrestatieSet_i01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_VergelijkingID",
Value = p_VergelijkingID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_NeemPrijzenOver8_u01<T>(int AfspraakID, bool AlleenLagereTarieven, int BronIndex, Overig.udtIntTable FilterPrestatieIDs, bool FilterPrestaties, int VergelijkingID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_NeemPrijzenOver8_u01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AfspraakID",
Value = AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@AlleenLagereTarieven",
Value = AlleenLagereTarieven
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@BronIndex",
Value = BronIndex
},
new SqlMagic.Lib.StoredProcedureTableTypeParameter()
{
Name = "@FilterPrestatieIDs",
Table = FilterPrestatieIDs
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@FilterPrestaties",
Value = FilterPrestaties
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@VergelijkingID",
Value = VergelijkingID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_GetBronKosten_s<T>(int p_VergelijkingsBronID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_GetBronKosten_s",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_VergelijkingsBronID",
Value = p_VergelijkingsBronID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_GetDetailKosten_s<T>(int p_OnderhandelingGroepId, int p_PageNumber, int p_PageSize, int p_SortColumn, bool p_SortOrder, int p_VergelijkingsBronID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_GetDetailKosten_s",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_OnderhandelingGroepId",
Value = p_OnderhandelingGroepId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_PageNumber",
Value = p_PageNumber
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_PageSize",
Value = p_PageSize
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_SortColumn",
Value = p_SortColumn
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_SortOrder",
Value = p_SortOrder
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_VergelijkingsBronID",
Value = p_VergelijkingsBronID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_GetDetailKosten_s02<T>(int p_OnderhandelingGroepId, int p_VergelijkingsBronID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_GetDetailKosten_s02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_OnderhandelingGroepId",
Value = p_OnderhandelingGroepId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_VergelijkingsBronID",
Value = p_VergelijkingsBronID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_GetKosten_s<T>(int p_VergelijkingID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_GetKosten_s",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_VergelijkingID",
Value = p_VergelijkingID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ApplyDetailFilter_u01<T>(int p_OnderhandelingGroepId, int p_VergelijkingID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ApplyDetailFilter_u01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_OnderhandelingGroepId",
Value = p_OnderhandelingGroepId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_VergelijkingID",
Value = p_VergelijkingID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ApplyDetailFilter_u02a<T>(int p_OnderhandelingGroepId, int p_VergelijkingID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ApplyDetailFilter_u02a",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_OnderhandelingGroepId",
Value = p_OnderhandelingGroepId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_VergelijkingID",
Value = p_VergelijkingID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ApplyDetailFilter_u02b<T>(char p_DeclaratieCode, int p_OnderhandelingGroepId, int p_VergelijkingID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ApplyDetailFilter_u02b",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_DeclaratieCode",
Value = p_DeclaratieCode
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_OnderhandelingGroepId",
Value = p_OnderhandelingGroepId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_VergelijkingID",
Value = p_VergelijkingID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ApplyDetailFilter_u03<T>(char p_BehandelingCode, char p_DiagnoseCode, int p_OnderhandelingGroepId, int p_VergelijkingID, char p_ZorgTypeCode, char p_ZorgVraagCode)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ApplyDetailFilter_u03",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_BehandelingCode",
Value = p_BehandelingCode
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_DiagnoseCode",
Value = p_DiagnoseCode
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_OnderhandelingGroepId",
Value = p_OnderhandelingGroepId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_VergelijkingID",
Value = p_VergelijkingID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_ZorgTypeCode",
Value = p_ZorgTypeCode
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_ZorgVraagCode",
Value = p_ZorgVraagCode
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_GetSelectionCount_s<T>(int p_OnderhandelingGroepId, int p_VergelijkingID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_GetSelectionCount_s",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_OnderhandelingGroepId",
Value = p_OnderhandelingGroepId
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_VergelijkingID",
Value = p_VergelijkingID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_GetVergelijkingExport_s01<T>(int vergelijkingsBronID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_GetVergelijkingExport_s01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@vergelijkingsBronID",
Value = vergelijkingsBronID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_GetVergelijkingExport_s02<T>(int vergelijkingsBronID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_GetVergelijkingExport_s02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@vergelijkingsBronID",
Value = vergelijkingsBronID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_NeemPrijzenOver_u01<T>(int p_VergelijkingsBronID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_NeemPrijzenOver_u01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_VergelijkingsBronID",
Value = p_VergelijkingsBronID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_ReCreateVergelijkingsPrestatieSet_u<T>(int p_VergelijkingID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_ReCreateVergelijkingsPrestatieSet_u",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_VergelijkingID",
Value = p_VergelijkingID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_BerekenKosten_i01<T>(int p_VergelijkingID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_BerekenKosten_i01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_VergelijkingID",
Value = p_VergelijkingID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_BerekenKosten_i02<T>(int p_VergelijkingsBronID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_BerekenKosten_i02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_VergelijkingsBronID",
Value = p_VergelijkingsBronID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_CreateVergelijking_i01<T>(int p_AfspraakID, int p_AfspraakIDVolumeSjabloon, ref int p_VergelijkingID, int p_VergelijkingType)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_CreateVergelijking_i01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfspraakID",
Value = p_AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfspraakIDVolumeSjabloon",
Value = p_AfspraakIDVolumeSjabloon
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_VergelijkingID",
Value = p_VergelijkingID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_VergelijkingType",
Value = p_VergelijkingType
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_CreateVergelijkingsBron_i01<T>(int p_VergelijkingID, ref int p_VergelijkingsBronID, int p_VolumeAfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_CreateVergelijkingsBron_i01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_VergelijkingID",
Value = p_VergelijkingID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_VergelijkingsBronID",
Value = p_VergelijkingsBronID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_VolumeAfspraakID",
Value = p_VolumeAfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_CreateVergelijkingsBron_i02<T>(int p_AfspraakID, int p_VergelijkingID, ref int p_VergelijkingsBronID, int p_VolumeAfspraakID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_CreateVergelijkingsBron_i02",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfspraakID",
Value = p_AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_VergelijkingID",
Value = p_VergelijkingID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_VergelijkingsBronID",
Value = p_VergelijkingsBronID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_VolumeAfspraakID",
Value = p_VolumeAfspraakID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_GetAfspraakData_s<T>(ref int p_AfspraakID, ref int p_OnderhandelingAfspraakID, int p_VergelijkingID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_GetAfspraakData_s",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_AfspraakID",
Value = p_AfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_OnderhandelingAfspraakID",
Value = p_OnderhandelingAfspraakID
},
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_VergelijkingID",
Value = p_VergelijkingID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_HerBerekenKosten_u01<T>(int p_VergelijkingID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_HerBerekenKosten_u01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_VergelijkingID",
Value = p_VergelijkingID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
public SqlMagic.Lib.SqlResponse<T> csp_VergelijkingsBronPrijslijst_u01<T>(int p_VergelijkingID)
{
var sqlRequest = new SqlMagic.Lib.SqlRequest()
{
StoredProcedureName = "csp_VergelijkingsBronPrijslijst_u01",
Parameters = new System.Collections.Generic.List<SqlMagic.Lib.StoredProcedureParameter>()
{
new SqlMagic.Lib.StoredProcedureSimpleParameter()
{
Name = "@p_VergelijkingID",
Value = p_VergelijkingID
},
}
};

return SqlExecutor.Execute<T>(sqlRequest);
}
}
}
