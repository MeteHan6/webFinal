using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webVize.Controllers
{
    public class MarketController : Controller
    {
        // GET: Market
        public ActionResult Index()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var markts = session.Query<Models.Market>().Fetch(x => x.Urunler).ToList();
                return View(markts);
            }
        }

        public ActionResult Listele()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var markts = session.Query<Models.Market>().ToList();
                return View(markts);
            }
        }

        public ActionResult Yeni()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var markts = session.Query<Models.Market>().FirstOrDefault(x => x.Id == id);
                return View(markts);
            }
        }


        [HttpPost]
        public ActionResult Edit(Models.Market market)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var mkt = session.Query<Models.Market>().FirstOrDefault(x => x.Urun_Id == market.Urun_Id);
                mkt.Isim = market.Urun_Isim;
                mkt.Adet = market.Urun_Adet;
                session.SaveOrUpdate(mkt);
                session.Flush();
                return RedirectToAction("/Index");
            }
        }
}