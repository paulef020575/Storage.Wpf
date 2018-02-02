using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Migrations
{
    [Migration(201801200845)]
    public class M201801200840_Store : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Create.Table("Store")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("IdCompany").AsInt32().NotNullable().WithDefaultValue(1)
                .WithColumn("Code").AsInt32().NotNullable()
                .WithColumn("ExternalCode").AsString(255).Nullable()
                .WithColumn("Name").AsString(30).NotNullable()
                .WithColumn("Active").AsBoolean().NotNullable().WithDefaultValue(true)
                .WithColumn("MaxDay").AsInt32().Nullable()
                .WithColumn("Logistic").AsBoolean().NotNullable().WithDefaultValue(true)
                .WithColumn("Protrusion").AsDecimal(2, 2).NotNullable()
                .WithColumn("TotalProtrustion").AsDecimal(2, 2).NotNullable()
                .WithColumn("Couple").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("Type").AsInt32().NotNullable().WithDefaultValue(0);

        }
    }

    [Migration(201801222225)]
    public class M201801222225_Store : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Delete.Column("TotalProtrustion")
                .FromTable("Store");

            Alter.Table("Store")
                .AddColumn("TotalProtrusion")
                .AsDecimal(2, 2)
                .NotNullable()
                .WithDefaultValue(0);
        }
    }
}
