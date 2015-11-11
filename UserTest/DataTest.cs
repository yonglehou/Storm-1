using Database;
using Flyingpie.Storm.Dapper;
using Flyingpie.Storm.Execution;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UserTest
{
    [TestClass]
    public class DataTest
    {
        [TestMethod]
        public void MyTestMethod()
        {
            var queryChain = new QueryChain();
            queryChain
                .UseConsoleLogger()
                .UseDapper(new DapperConfiguration()
                {
                    ConnectionString = "server=storm.database.windows.net;database=Storm;user=storm;password=WRQLgVSsAHy2W8pHe6T4;"
                });

            var data = new Data(queryChain);

            // Query
            //var result = data.CspInstantieS01(null, null, null, null, null, null).Query<InstantieDto>();

            // Multiple
            using (var reader = data.CspWithMultipleResultSets(null).Multiple())
            {
                var result1 = reader.Read<InstantieDto>();

                var result2 = reader.Read<GebruikerDto>();
            }
        }
    }

    public class InstantieDto
    {
        public int InstantieID { get; set; }

        public int InstantieTypeID { get; set; }

        public int InstantieSubTypeID { get; set; }

        public string UZOVI { get; set; }

        public string AGBSoort { get; set; }

        public string AGBNummer { get; set; }

        public string AGB { get; set; }

        public string Naam { get; set; }
    }

    public class GebruikerDto
    {
        public int GebruikerID { get; set; }

        public string Voornaam { get; set; }

        public string Tussenvoegsel { get; set; }

        public string Achternaam { get; set; }
    }
}