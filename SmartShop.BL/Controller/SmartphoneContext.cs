using SmartShop.BL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.BL.Controller
{
    public class SmartphoneContext : DbContext
    { 
        public SmartphoneContext() : base("DbConnection") { }

        public DbSet<Smartphone> Smartphones { get; set; }
        //  public DbSet<User> Users { get; set; }
    }
}
