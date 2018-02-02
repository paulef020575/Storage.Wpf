using FluentMigrator;
using FluentMigrator.Runner.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Migrations
{
    [Migration(201801132200)]
    public class M_201801132200 : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Create.Table("TypeProd")
                .WithColumn("Id").AsInt32().Identity(1, 1)
                .WithColumn("Code").AsInt32().NotNullable()
                .WithColumn("ExternalCode").AsString(255)
                .WithColumn("Name").AsString(30).NotNullable()
                .WithColumn("IdCompany").AsInt32().NotNullable().WithDefaultValue(1);

            Create.PrimaryKey("PK_TypeProd")
                .OnTable("TypeProd")
                .Column("Id");
        }
    }
}
