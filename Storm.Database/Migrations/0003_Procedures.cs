using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flyingpie.Storm.Database.Migrations
{
    [Migration(3, "Procedures")]
    public class Procedures : Migration
    {
        public override void Up()
        {
            // Orm
            Execute.Sql(string.Format(@"
                CREATE PROCEDURE {0}.GetBrands
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
	                FROM {0}.{1}
	                WHERE
		                (@Name IS NULL OR Name = @Name)
		                AND
		                (@Description IS NULL OR Description = Description)
                END", Constants.Schemas.CARS, Constants.Tables.BRANDS));

            Execute.Sql(string.Format(@"
                CREATE PROCEDURE {0}.AddBrand
                (
                    @Vendors {0}.Brand READONLY
                )
                AS
                BEGIN
                    INSERT INTO {0}.{1}
                    (
                        Name,
                        Description,
                        HorsePower
                    )
                    SELECT
                        Name,
                        Description,
                        HorsePower
                    FROM @Vendors
                END", Constants.Schemas.CARS, Constants.Tables.BRANDS));

            Execute.Sql(string.Format(@"
                CREATE PROCEDURE {0}.GetBrandsAndModels
                AS
                BEGIN
                    SELECT
                        Name,
                        Description,
                        HorsePower
                    FROM {0}.Brands

                    SELECT
                        Name,
                        BrandId
                    FROM {0}.Models
                END", Constants.Schemas.CARS));

            Execute.Sql(string.Format(@"
                CREATE PROCEDURE {0}.GetAddition
                (
                    @ValueA     INT,
                    @ValueB     INT
                )
                AS
                BEGIN
                    SELECT @ValueA + @ValueB;

                    RETURN
                END", Constants.Schemas.UTILITY));

            Execute.Sql(string.Format(@"
                CREATE PROCEDURE {0}.EchoDateTime
                (
                    @DateTime   DATETIME2
                )
                AS
                BEGIN
                    SELECT @DateTime;
                    RETURN;
                END", Constants.Schemas.UTILITY));
        }

        public override void Down()
        {
        }
    }
}
