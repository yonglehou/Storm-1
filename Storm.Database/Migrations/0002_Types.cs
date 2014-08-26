using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flyingpie.Storm.Database.Migrations
{
    [Migration(2, "Types")]
    public class Types : Migration
    {
        public override void Up()
        {
            Execute.Sql(string.Format(@"
                CREATE TYPE {0}.Brand AS TABLE
                (
                    Name        NVARCHAR(255),
                    Description NVARCHAR(255),
                    HorsePower  INT,
                    Image       VARBINARY(1024)
                )", Constants.Schemas.CARS));
        }

        public override void Down()
        {
        }
    }
}
