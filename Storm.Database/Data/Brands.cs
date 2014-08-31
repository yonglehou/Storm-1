using FluentMigrator;
using Flyingpie.Storm.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Storm.Database.Data
{
    [Profile("TestData")]
    public class Brands : Migration
    {
        class Brand
        {
            public string Name { get; set; }

            public string Description { get; set; }

            public int HorsePower { get; set; }
        }

        public override void Up()
        {
            Insert
                .IntoTable(Constants.Tables.BRANDS)
                .InSchema(Constants.Schemas.CARS)

                .Row(new Brand() { Name = "Audi", Description = "The steering wheel is an option", HorsePower = 160 })
                .Row(new Brand() { Name = "Bentley", Description = null, HorsePower = 200 })
                .Row(new Brand() { Name = "Hyundai", Description = "Too bad they didn't come in 14%", HorsePower = 140 })
                .Row(new Brand() { Name = "Lexus", Description = "You get your own mechanic with this one", HorsePower = 125 })
                .Row(new Brand() { Name = "Mercedes", Description = "Only for the elite", HorsePower = 250 })
                .Row(new Brand() { Name = "Seat", Description = "Spanish and spicy", HorsePower = 90 })
                .Row(new Brand() { Name = "Skoda", Description = "", HorsePower = 100 })
                .Row(new Brand() { Name = "Toyota", Description = "Xander was here", HorsePower = 110 })
                .Row(new Brand() { Name = "Volkswagen", Description = "Nice, but pricy", HorsePower = 120 })
                .Row(new Brand() { Name = "Volvo", Description = "The search for perfection ends here", HorsePower = 120 })
            ;
        }

        public override void Down()
        {

        }
    }
}
