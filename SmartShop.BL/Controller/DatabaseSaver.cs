using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.BL.Controller
{
    public class DatabaseSaver : IDataSaver
    {
        public List<T> Load<T>() where T : class
        {
            using (var db = new SmartphoneContext())
            {
                var result = db.Set<T>().Where(t => true).ToList();
                return result;
            }
        }

        public void Save<T>(List<T> item) where T : class
        {
            using (var db = new SmartphoneContext())
            {
                db.Set<T>().AddRange(item);
                db.SaveChanges();
            }
        }
    }
}
