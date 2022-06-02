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
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Permission()
        {
            //查询已申请的委托人、未申请的委托人以及跑腿员
            Model1 model1 = new Model1();

            List<account> list = model1.account.Where(p => p.ApplyFor == "已申请").ToList();
            List<account> list2 = model1.account.Where(p => p.ApplyFor == "未申请").ToList();
            List<account> list3 = model1.account.Where(p => p.ApplyFor == "已通过").ToList();
            ViewBag.list = list;
            ViewBag.list2 = list2;
            ViewBag.list3 = list3;
            return View();
        }

        public ActionResult Confered()
        {
            //授予权限，将状态改为已通过
            Model1 model1 = new Model1();
            var cardnumber = Request["cardnumber"];

            account account= model1.account.Where(p => p.CardNumber == cardnumber.ToString()).FirstOrDefault();
            account.ApplyFor = "已通过";

            model1.Entry(account).State = System.Data.Entity.EntityState.Modified;

            //将client表中的数据移到runner表中
            runner runner = new runner();
            client client = model1.client.Where(p => p.CardNumber == cardnumber.ToString()).FirstOrDefault();
            runner.CardNumber = client.CardNumber;
            runner.RunnerID = (Convert.ToInt32((model1.runner.OrderByDescending(d => d.RunnerID).FirstOrDefault()).RunnerID) + 1).ToString();
            runner.Effective = "有效";
            //model1.client.Remove(client);
            model1.runner.Add(runner);

            model1.SaveChanges();



            return Content("<script>alert('操作成功！');location.href='Permission'</script>");
        }

        public ActionResult Deprived()
        {
            //授予权限，将状态改为未申请
            Model1 model1 = new Model1();
            var cardnumber = Request["cardnumber"];

            account account = model1.account.Where(p => p.CardNumber == cardnumber.ToString()).FirstOrDefault();
            account.ApplyFor = "未申请";

            model1.Entry(account).State = System.Data.Entity.EntityState.Modified;

            //将runner表中Effective改为无效，视为无权限
            runner runner = model1.runner.Where(p => p.CardNumber == cardnumber.ToString()).FirstOrDefault();
            runner.Effective = "无效";
            

            model1.SaveChanges();

            return Content("<script>alert('操作成功！');location.href='Permission'</script>");
        }
    }
}