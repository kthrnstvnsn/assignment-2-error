using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tees.DAL;
using Tees.ViewModels;

namespace Tees.Controllers
{
    public class HomeController : Controller
    {
        private StoreContext db = new StoreContext();
        public ActionResult Index()
        {
            var topSellers = (from topProducts in db.OrderLines
                              where (topProducts.ProductID != null)
                              group topProducts by topProducts.Product into topGroup
                              select new BestSellersViewModel
                              {
                                  Product = topGroup.Key,
                                  SalesCount = topGroup.Sum(o => o.Quantity),
                                  ProductImage = topGroup.Key.ProductImageMappings.
                              OrderBy(pim
                              =>
                              pim.ImageNumber).FirstOrDefault().ProductImage.FileName
                              }).OrderByDescending(tg => tg.SalesCount).Take(3);
            return View(topSellers);
        }

        public ActionResult About(string id)
        {
            ViewBag.Message = "Your application description page. You entered the ID " + id;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}