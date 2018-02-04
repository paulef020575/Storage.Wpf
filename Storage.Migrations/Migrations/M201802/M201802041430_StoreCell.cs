using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Migrations
{
    [Migration(201802041430)]
    public class M201802041430_Road : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Create.Table("Road")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("IdCompany").AsInt32().NotNullable().WithDefaultValue(1)
                .WithColumn("Code").AsString(2).NotNullable()
                .WithColumn("Blocked").AsBoolean().NotNullable().WithDefaultValue(false);
        }
    }
}
