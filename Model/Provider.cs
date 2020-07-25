using AV_Soft.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AV_Soft.Model
{
    public class Provider
    {
        private readonly AVSContext Db;
        public Provider(AVSContext context)
        {
            Db = context;
        }
        public IQueryable<Tab1> GetDataTab1()
        {
            return from k in Db.Tab1 select k;
        }
        public void SetData(Tab1 tab1)
        {
            Db.Tab1.Add(tab1);
        }

        public void GetDataTab2()
        {
            List<Tab1> tab1 = new List<Tab1>();

            foreach (var data in Db.Tab1.OrderBy(k => k.KEY).ToList())
            {
                if (!tab1.Any(k => k.KEY == data.KEY))
                {
                    tab1.Add(data);
                }
            }
            foreach (var data in tab1)
            {
                Db.Tab2.Add(new Tab2
                {
                    KEY = data.KEY,
                    COUNT = Db.Tab1.Where(k => k.KEY == data.KEY).Count(),
                    COUNTMORETHENONE = Db.Tab1.Where(k => k.KEY == data.KEY && k.VALUE > 1).Count()
                });

            }
            Db.SaveChanges();
        }
    }
}
