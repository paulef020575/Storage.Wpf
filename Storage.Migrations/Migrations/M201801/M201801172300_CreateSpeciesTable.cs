using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Migrations
{
    [Migration(201801172300)]
    public class M201801172300_CreateSpeciesTable : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Create.Table("Species")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("IdCompany").AsInt32().NotNullable()
                .WithColumn("Code").AsInt32().NotNullable()
                .WithColumn("ExternalCode").AsString(255).Nullable()
                .WithColumn("Name").AsString(30).NotNullable();
        }
    }
}
