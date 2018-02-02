using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Migrations.Migrations.M201801
{
    [Migration(201801200846)]
    public class M201801200846_AddStoreColumns : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Alter.Table("Store")
                .AddColumn("WidthFrom").AsInt32().NotNullable().WithDefaultValue(0)
                .AddColumn("WidthTo").AsInt32().NotNullable().WithDefaultValue(1000)
                .AddColumn("HeightFrom").AsInt32().NotNullable().WithDefaultValue(0)
                .AddColumn("HeightTo").AsInt32().NotNullable().WithDefaultValue(1000);
        }
    }

    [Migration(201801211500)]
    public class M201801211500_AddStoreColumns : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Alter.Table("Store")
                .AddColumn("Height").AsInt32().NotNullable();
        }
    }
}
