using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Storm.Database.Data
{
    [Profile("TestData")]
    public class SmallTable : Migration
    {
        class Row
        {
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public override void Up()
        {
            Insert
                .IntoTable("SmallTable")
                .InSchema("Orm")

                .Row(new Row() { Name = "Audi", Description = "The steering wheel is an option" })
                .Row(new Row() { Name = "Bentley", Description = null })
                .Row(new Row() { Name = "Hyundai", Description = "Too bad they didn't come in 14%" })
                .Row(new Row() { Name = "Lexus", Description = "You get your own mechanic with this one" })
                .Row(new Row() { Name = "Mercedes", Description = "Only for the elite" })
                .Row(new Row() { Name = "Seat", Description = "Spanish and spicy" })
                .Row(new Row() { Name = "Skoda", Description = "" })
                .Row(new Row() { Name = "Toyota", Description = "Xander was here" })
                .Row(new Row() { Name = "Volkswagen", Description = "Nice, but pricy" })
                .Row(new Row() { Name = "Volvo", Description = "The search for perfection ends here" })
            ;
        }

        public override void Down()
        {

        }
    }
}
