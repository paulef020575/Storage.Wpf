using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Migrations
{
    [Migration(201802021300)]
    public class M201802021300_AddStoreGrade : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Create.Table("StoreGrade")
                .WithColumn("IdStore").AsInt32().ForeignKey("Store", "Id").NotNullable()
                .WithColumn("IdGrade").AsInt32().ForeignKey("Grade", "Id").NotNullable();
        }
    }
}
