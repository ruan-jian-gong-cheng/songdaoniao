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
    public class CreateOrderController : Controller
    {
        // GET: CreateOrder
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateResponse()
        {
            
            order order = new order();
            Model1 model1 = new Model1();

            String OrderType = Request.Form["Select"];
            var detail = Request.Form["details"];
            var id = Session["cardnumber"];

            if (string.IsNullOrEmpty(detail))
            {
                return Content("<script>alert('请输入详细要求！');location.href='create'</script>");
            }

            order.Date = DateTime.Now;
            order.Text = detail;
            //order.RunnerID = "暂未绑定";
            //order.RunnerPhone = "暂未绑定";
            order.Type = OrderType;

            var data1 = model1.client.Where(p => p.CardNumber == id.ToString()).FirstOrDefault();
            var clientid = data1.ClientID;
            order.ClientID = clientid;

            var data2 = model1.account.Where(p => p.CardNumber == id.ToString()).FirstOrDefault();
            var clientphone = data2.Telephone;
            order.ClientPhone = clientphone;

            var tip = Request.Form["tip"];
            if (string.IsNullOrEmpty(tip))
            {

            }
            else
            {
                order.Tip = tip;
            }

            order.OrderNumber = (Convert.ToInt32((model1.order.OrderByDescending(d => d.Date).FirstOrDefault()).OrderNumber) + 1).ToString();
            Session["OrderNumber"] = order.OrderNumber;

            model1.order.Add(order);
            model1.SaveChanges();

            return Content("<script>alert('订单发布成功');location.href='/ViewOrder/Orderview'</script>");

        }
    }
}