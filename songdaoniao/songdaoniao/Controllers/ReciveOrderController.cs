using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrary1;

namespace songdaoniao.Controllers
{
    public class ReciveOrderController : Controller
    {
        // GET: ReciveOrder
        public ActionResult Index()
        {
            Model1 model1 = new Model1();
            //order order = new order();
            
            List<order> list= model1.order.Where(p => p.RunnerPhone==null).ToList();
            ViewBag.list = list;
            return View();
        }

    }
}