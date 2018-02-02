using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Migrations
{
    [Migration(201801211745)]
    public class M201801211740Enumeration : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Create.Table("Enumeration")
                .WithColumn("Name").AsString(100).NotNullable()
                .WithColumn("Index").AsInt32().NotNullable()
                .WithColumn("Description").AsString(100).NotNullable();

            Create.UniqueConstraint()
                .OnTable("Enumeration")
                .Columns(new[] { "Name", "Index" });

            Insert.IntoTable("Enumeration")
                .Row(new Dictionary<string, object> {
                    { "Name", "StoreType" }, { "Index", 1 }, { "Description", "Склад пиломатериалов" } })
                .Row(new Dictionary<string, object> {
                    { "Name", "StoreType" }, { "Index", 2 }, { "Description", "Производственная линия" } })
                .Row(new Dictionary<string, object> {
                    { "Name", "StoreType" }, { "Index", 3 }, { "Description", "Отгрузочная площадка" } });
        }
    }

    [Migration(201801211935)]
    public class M201801211935Enumeration : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Alter.Table("Enumeration")
                .AddColumn("id").AsInt32().Identity().PrimaryKey()
                .AddColumn("IdCompany").AsInt32().NotNullable().WithDefaultValue(1);


        }
    }

    [Migration(201801211945)]
    public class M201801211940Enumeration : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Delete.Table("Enumeration");

            Create.Table("Enumeration")
                .WithColumn("id").AsInt32().Identity().PrimaryKey()
                .WithColumn("IdCompany").AsInt32().NotNullable().WithDefaultValue(1)
                .WithColumn("Name").AsString(100).NotNullable()
                .WithColumn("ItemIndex").AsInt32().NotNullable()
                .WithColumn("Description").AsString(100).NotNullable();

            Create.UniqueConstraint()
                .OnTable("Enumeration")
                .Columns(new[] { "Name", "ItemIndex" });


        }
    }

    [Migration(201801222247)]
    public class M201801222245Enumeration : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {


            Insert.IntoTable("Enumeration")
                .Row(new Dictionary<string, object> {
                    { "Name", "StoreType" }, { "ItemIndex", 1 }, { "Description", "Склад пиломатериалов" } })
                .Row(new Dictionary<string, object> {
                    { "Name", "StoreType" }, { "ItemIndex", 2 }, { "Description", "Производственная линия" } })
                .Row(new Dictionary<string, object> {
                    { "Name", "StoreType" }, { "ItemIndex", 3 }, { "Description", "Отгрузочная площадка" } })
                .Row(new Dictionary<string, object> {
                    { "Name", "StoreType" }, { "ItemIndex", 4 }, { "Description", @"Сушильная камера" } })
                .Row(new Dictionary<string, object> {
                    { "Name", "StoreType" }, { "ItemIndex", 5 }, { "Description", @"Сортировочная линия" } });

        }
    }
}