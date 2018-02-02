using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Migrations
{
    [Migration(201802021430)]
    public class M201802021430_CreateNomenclature : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Create.Table("Nomenclature")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("IdCompany").AsInt32().NotNullable().WithDefaultValue(1)
                .WithColumn("Code").AsInt32().NotNullable()
                .WithColumn("ExternalCode").AsString(255).Nullable()
                .WithColumn("Name").AsString(30).NotNullable()
                .WithColumn("Active").AsBoolean().NotNullable().WithDefaultValue(true)
                .WithColumn("IdSpecies").AsInt32().NotNullable().ForeignKey("Species", "Id")
                .WithColumn("IdTypeProd").AsInt32().NotNullable().ForeignKey("TypeProd", "Id")
                .WithColumn("IdGrade").AsInt32().NotNullable().ForeignKey("Grade", "Id")
                .WithColumn("Request").AsInt32().NotNullable().WithDefaultValue(0)
                .WithColumn("Wethness").AsInt32().NotNullable().WithDefaultValue(0)
                .WithColumn("Height").AsInt32().NotNullable()
                .WithColumn("Width").AsInt32().NotNullable();

        }
    }
}
