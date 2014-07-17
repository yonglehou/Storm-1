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
        }

        public override void Down()
        {
            Execute
                .Sql(@"DROP PROCEDURE Orm.GetSmallTable")
            ;

            Delete
                .Table("SmallTable")
                .InSchema("Orm")
            ;

            Delete
                .Schema("Orm")
            ;
        }
    }
}
