using FluentMigrator;
using Flyingpie.Storm.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Storm.Database.Migrations
{
    [Migration(1, "Tables")]
    public class InitialMigration : Migration
    {
        public override void Up()
        {
            Create.Schema(Constants.Schemas.CARS);
            Create.Schema(Constants.Schemas.CUSTOMERS);
            Create.Schema(Constants.Schemas.UTILITY);

            Create
                .Table(Constants.Tables.BRANDS)
                .InSchema(Constants.Schemas.CARS)

                .WithColumn("Id")
                .AsInt32()
                .PrimaryKey()
                .Identity()

                .WithColumn("Name")
                .AsString()
                .NotNullable()

                .WithColumn("Description")
                .AsString()
                .Nullable()

                .WithColumn("HorsePower")
                .AsInt32()
                .NotNullable()
            ;

            Create
                .Table(Constants.Tables.MODELS)
                .InSchema(Constants.Schemas.CARS)

                .WithColumn("Id")
                .AsInt32()
                .PrimaryKey()
                .Identity()

                .WithColumn("Name")
                .AsString()
                .NotNullable()
                
                .WithColumn("BrandId")
                .AsInt32()
            ;
        }

        public override void Down()
        {
        }
    }
}
