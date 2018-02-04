using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Migrations
{
    [Migration(201802022130)]
    public class M201802022130_createCustomer : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Create.Table("Customer")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("IdCompany").AsInt32().NotNullable().WithDefaultValue(1)
                .WithColumn("Code").AsInt32().NotNullable()
                .WithColumn("ExternalCode").AsString(255).Nullable()
                .WithColumn("Name").AsString(120).NotNullable();
        }
    }
}
