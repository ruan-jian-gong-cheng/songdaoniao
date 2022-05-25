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
    public class ReceiveOrderController : Controller
    {
        // GET: ReceiveOrder
        public ActionResult Index()
        {
            Model1 model1 = new Model1();
            //order order = new order();
            
            List<order> list = model1.order.Where(p => p.RunnerPhone == null).ToList();
            ViewBag.list = list;
            return View();
        }

        public ActionResult HaveReceived()
        {
            //order order = new order();
            runner runner = new runner();
            Model1 model1 = new Model1();

            int maxOrderCount = 8;            //接单上限
            int orderCount = 0;               //已接单数量
            var cardNumber = Session["cardnumber"];
            var orderid = Request["orderid"];
            
            if (orderCount <= maxOrderCount && orderid!=null)
            {                              
                
                order order = model1.order.Where(p => p.OrderNumber == orderid.ToString()).FirstOrDefault();
                var data1 = model1.runner.Where(p => p.CardNumber == cardNumber.ToString()).FirstOrDefault();
                var runnerid = data1.RunnerID;
                order.RunnerID = runnerid;

                var data2 = model1.account.Where(p => p.CardNumber == cardNumber.ToString()).FirstOrDefault();
                var runnerphone = data2.Telephone;
                order.RunnerPhone = runnerphone; 
                
                orderCount = orderCount + 1;

                //修改订单并保存
                model1.Entry(order).State = System.Data.Entity.EntityState.Modified;
                model1.SaveChanges();

               
            }

            if(orderCount >= maxOrderCount)
            {
                return Content("<script>alert('抱歉，您接收的订单数量已达上限，请先完成现有订单!');location.href='HaveReceived'</script>");
            }
            
            
            runner = model1.runner.Where(p => p.CardNumber == cardNumber.ToString()).FirstOrDefault();
            var runnerID = runner.RunnerID;

            List<order> list = model1.order.Where(p => p.RunnerID == runnerID).ToList();
            ViewBag.list = list;

            return View();
            
            
        }

        public ActionResult CancelOrder()
        {
            Model1 model1 = new Model1();

            var orderID = Request["orderid"];

            order order = model1.order.Where(p => p.OrderNumber == orderID.ToString()).FirstOrDefault();
            
            if (order.State == "未完成")
            {
                order.RunnerID = null;
                order.RunnerPhone = null;

                model1.Entry(order).State = System.Data.Entity.EntityState.Modified;
                model1.SaveChanges();
                return Content("<script>alert('退单成功！');location.href='/ReceiveOrder/Index'</script>");
            }
                
            else
                return Content("<script>alert('已完成订单不可退单！');location.href='/ReceiveOrder/HaveReceived'</script>");
        }
      
        public ActionResult FinishOrder()
        {
            // runner runner = new runner();
            Model1 model1 = new Model1();
           
            var FinishID = Request["orderid"];
            order FinishOrder = model1.order.Where(p => p.OrderNumber == FinishID.ToString()).FirstOrDefault();
            
            if (FinishOrder.State == "未完成")
            {
                FinishOrder.State = "已完成";
                model1.Entry(FinishOrder).State = System.Data.Entity.EntityState.Modified;
                model1.SaveChanges();
                return Content("<script>alert('成功完成该订单！');location.href='/ReceiveOrder/HaveReceived'</script>");
            }
            else
            {
                return Content("<script>alert('该订单为已完成订单！');location.href='/ReceiveOrder/HaveReceived'</script>");
            }

        }
    }
}