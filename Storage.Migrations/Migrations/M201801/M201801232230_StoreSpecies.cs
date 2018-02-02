using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Migrations
{
    [Migration(201801232230)]
    public class M201801232230_StoreSpecies : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Create.Table("StoreSpecies")
                .WithColumn("IdStore").AsInt32().ForeignKey("Store", "Id").NotNullable()
                .WithColumn("IdSpecies").AsInt32().ForeignKey("Species", "Id").NotNullable();
        }
    }
}
