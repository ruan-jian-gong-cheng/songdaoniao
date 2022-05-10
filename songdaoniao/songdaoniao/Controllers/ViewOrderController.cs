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
    public class ViewOrderController : Controller
    {
        // GET: ViewOrder
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Orderview()
        {
            order order = new order();
            Model1 model1 = new Model1();

            var ordernumber = Session["OrderNumber"];
            var data = model1.order.Where(p => p.OrderNumber == ordernumber.ToString()).FirstOrDefault();
            base.ViewData["订单类型"] = data.Type;
            base.ViewData["生成时间"] = data.Date;
            base.ViewData["具体要求"] = data.Text;
            if (string.IsNullOrEmpty(data.Tip))
            {
                base.ViewData["打赏小费"] = "未设置金额";
            }
            else
            {
                base.ViewData["打赏小费"] = data.Tip;
            }
            if (string.IsNullOrEmpty(data.RunnerPhone))
            {
                base.ViewData["骑手联系方式"] = "暂未有骑手接单";
            }
            else
            {
                base.ViewData["骑手联系方式"] = data.RunnerPhone;
            }

            return View();
        }

        public ActionResult Refresh()
        {
            return Content("<script>alert('正在刷新，请稍候……');location.href='/ViewOrder/Orderview'</script>");
        }
    }
}