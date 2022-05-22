using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrary1;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity.Validation;

namespace songdaoniao.Controllers
{
    public class FinishController : Controller
    {
        // GET: Finish
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Finish()
        {
           // runner runner = new runner();
            Model1 model1 = new Model1();
            order order = new order();
            order.State = "已完成";
            return View();
        }



    }
}
