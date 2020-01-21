using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.BL.Migration
{
    internal sealed class Configuration : DbMigrationsConfiguration<SmartShop.BL.Controller.SmartphoneContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "SmartShop.BL.Controller.SmartphoneContext";
        }

        protected override void Seed(SmartShop.BL.Controller.SmartphoneContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
