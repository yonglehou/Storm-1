using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flyingpie.Storm.Database.Data
{
    [Profile("TestData")]
    public class Models : Migration
    {
        public class Model
        {
            public string Name { get; set; }

            public int BrandId { get; set; }
        }

        public override void Up()
        {
            Insert
                .IntoTable(Constants.Tables.MODELS)
                .InSchema(Constants.Schemas.CARS)

                .Row(new Model() { Name = "V40", BrandId = 10 }) // TODO: Retrieve id
            ;
        }

        public override void Down()
        {
        }
    }
}
