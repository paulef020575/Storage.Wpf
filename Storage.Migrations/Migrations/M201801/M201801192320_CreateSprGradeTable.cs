using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Migrations
{
    [Migration(201901192320)]
    public class M201801192320_CreateSprGradeTable : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Create.Table("Grade")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("IdCompany").AsInt32().NotNullable().WithDefaultValue(1)
                .WithColumn("Code").AsInt32().NotNullable()
                .WithColumn("ExternalCode").AsString(255).Nullable()
                .WithColumn("Name").AsString(30).NotNullable()
                .WithColumn("IsTop").AsBoolean().NotNullable().WithDefaultValue(false);
        }
    }
}
