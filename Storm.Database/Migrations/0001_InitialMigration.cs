using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Storm.Database.Migrations
{
    [Migration(1)]
    public class InitialMigration : Migration
    {
        public override void Up()
        {
            var schema = "Orm";
            Create.Schema(schema);
            Create
                .Table("SmallTable")
                .InSchema(schema)

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
            ;

            Execute.Sql(@"
                CREATE PROCEDURE Orm.GetSmallTable
                (
	                @Name			NVARCHAR(255),
	                @Description	NVARCHAR(255)
                )
                AS
                BEGIN
	                SELECT
		                Id,
		                Name,
		                Description
	                FROM Orm.SmallTable
	                WHERE
		                (@Name IS NULL OR Name = @Name)
		                AND
		                (@Description IS NULL OR Description = Description)
                END");

            Execute.Sql(@"
                CREATE TYPE Orm.Vendor AS TABLE
                (
                    Name        NVARCHAR(255),
                    Description NVARCHAR(255)
                )");

            Execute.Sql(@"
                CREATE PROCEDURE Orm.AddVendors
                (
                    @Vendors Orm.Vendor READONLY
                )
                AS
                BEGIN
                    INSERT INTO Orm.SmallTable
                    (
                        Name,
                        Description
                    )
                    SELECT
                        Name,
                        Description
                    FROM @Vendors
                END");
        }

        public override void Down()
        {
            Execute.Sql("DROP PROCEDURE Orm.AddVendors");
            Execute.Sql("DROP TYPE Orm.Vendor");
            Execute.Sql("DROP PROCEDURE Orm.GetSmallTable");
            Execute.Sql("DROP TABLE Orm.SmallTable");
            Execute.Sql("DROP SCHEMA Orm");
        }
    }
}
