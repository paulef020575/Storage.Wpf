using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Migrations
{
    [Migration(201801292335)]
    public class M201801292335_AddMaxCountFieldToStore : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Alter.Table("Store")
                .AddColumn("MaxPackageCount").AsInt32().NotNullable().WithDefaultValue(3);
        }
    }
}
