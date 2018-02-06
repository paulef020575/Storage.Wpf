using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Migrations
{
    [Migration(201802041600)]
    public class M201802041600_StoreCell : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Create.Table("StoreCell")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("IdCompany").AsInt32().NotNullable()
                .WithColumn("Code").AsInt32().NotNullable()
                .WithColumn("ExternalCode").AsString(255).Nullable()
                .WithColumn("IdStore").AsInt32().NotNullable().ForeignKey("Store", "Id")
                .WithColumn("RowsCount").AsInt32().NotNullable().WithDefaultValue(1)
                .WithColumn("ColumnsCount").AsInt32().NotNullable().WithDefaultValue(1)
                .WithColumn("Active").AsBoolean().NotNullable().WithDefaultValue(true)
                .WithColumn("IsVertical").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("IdRoadLeft").AsInt32().Nullable().ForeignKey("Road", "Id")
                .WithColumn("IdRoadRight").AsInt32().Nullable().ForeignKey("Road", "Id")
                .WithColumn("IdRoadTop").AsInt32().Nullable().ForeignKey("Road", "Id")
                .WithColumn("IdRoadBot").AsInt32().Nullable().ForeignKey("Road", "Id")
                .WithColumn("X").AsInt32().NotNullable().WithDefaultValue(1)
                .WithColumn("Y").AsInt32().NotNullable().WithDefaultValue(1);
        }
    }

    [Migration(201802061630)]
    public class M201802061630_AlterStoreCell : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Alter.Table("StoreCell")
                .AddColumn("Name").AsString(50).NotNullable().WithDefaultValue("");
        }
    }
}
