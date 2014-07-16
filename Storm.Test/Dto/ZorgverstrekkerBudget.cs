using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Storm.Test.Dto
{
    public class ZorgverstrekkerBudget
    {
        public int? Id { get; set; }

        public int ZorgverzekeraarId { get; set; }

        public int ZorgverstrekkerId { get; set; }

        public string ZVSAGBCode { get; set; }

        public string ZVSNaam { get; set; }

        public int PeriodeId { get; set; }

        public DateTime PeriodeBeginDatum { get; set; }

        public DateTime PeriodeEindDatum { get; set; }

        public int RegioId { get; set; }

        public string RegioNaam { get; set; }

        public int CategorieId { get; set; }

        public string CategorieNaam { get; set; }

        public string Inkoper { get; set; }

        public decimal BudgetTotaal { get; set; }

        public decimal ExternContractTotaal { get; set; }

        public bool OnderhandenWerk { get; set; }

        public string OnderhandenWerkMailadres { get; set; }

        public bool NietInAutoModelcontract { get; set; }

        public bool Contracteerbaar { get; set; }

        public string ContracteerbaarToelichting { get; set; }

        public string Contractnummer { get; set; }

        public int ZorgSoortId { get; set; }

        public string IPZReferentie { get; set; }

        public decimal OmzetPlafond { get; set; }
    }
}
