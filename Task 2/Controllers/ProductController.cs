using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task_2.Models;

namespace Task_2.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
       static IList<Product> Values = new List<Product>
            {
                new Product{Id=1 ,PName="Boost" ,Price=20,Cusname="yamini" ,CustomerPhoneNumber="994405789",PurchaseDate=new DateTime(2022,12,11)},
                new Product{Id=2 ,PName="Dairy Milk" ,Price=30,Cusname="harishmitha" ,CustomerPhoneNumber="994545224",PurchaseDate=new DateTime(2023,7,1)},
                new Product{Id=3 ,PName="Watch" ,Price=1200,Cusname="ranita" ,CustomerPhoneNumber="757575454",PurchaseDate=new DateTime(2022,11,1)}


            };
        public ActionResult Index()
        {
           
            return View(Values);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PName,Price,Cusname,CustomerPhoneNumber,PurchaseDate")] Product P  )
        { 
        if(!ModelState.IsValid)
            {
                Values.Add(P);
                return RedirectToAction("Index");
            }
        return View(Values);
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var t = Values.Where(s => s.Id == Id).FirstOrDefault();
            
            return View(t);
        }

        [HttpPost]
        public ActionResult Edit(Product P)
        {
            var ProductList =Values.Where(s=>s.Id == P.Id).FirstOrDefault();
            Values.Remove(ProductList);
            Values.Add(P);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int Id)
        {
            var P = Values.Where(s => s.Id == Id).FirstOrDefault();
            return View(P);
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var P= Values.Where(s=>s.Id == Id).FirstOrDefault();
            Values.Remove(P);
            return RedirectToAction("Index");
        }
    }
}