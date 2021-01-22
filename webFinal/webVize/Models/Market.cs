using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;


namespace webVize.Models
{
    public class Market
    {

       public virtual string Urun_Id { get; set; }
        public virtual string Urun_Isim { get; set; }
        public virtual string Urun_Adet { get; set; }

        
    }

    public class MarketMap : ClassMapping<Market>
    {
        public MarketMap()
        {
            Property(x => x.Urun_Id, c=> c.Length(10));
            Property(x => x.Urun_Isim, c => c.Length(10));
            Property(x => x.Urun_Adet, c => c.Length(10));
        }

    }

}
