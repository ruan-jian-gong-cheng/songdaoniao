using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrary1;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace songdaoniao.Controllers
{
   
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ceshi()
        {
            return View();
        }

        public ActionResult Paotui()
        {
            return View();
        }

        public ActionResult Ceshi1()
        {
            return View();
        }

        public ActionResult Ceshi2()
        {
            return View();
        }

        public ActionResult Login()
        {
            account account = new account();
            Model1 model1 = new Model1();

            var CardNumber = Request.Form["CardNumber"];
            var Password = Request.Form["password"];

            if (string.IsNullOrEmpty(CardNumber) || string.IsNullOrEmpty(Password)){
                return Content("<script>alert('请输入账号密码！');location.href='Index'</script>");
            }

            var data = model1.account.Where(p => p.CardNumber == CardNumber && p.Password == Password).FirstOrDefault();
            var a = model1.runner.Where(p => p.CardNumber == CardNumber).FirstOrDefault();

            if (data != null)
            {
                if(CardNumber== "1000000001")
                {
                    Session["cardnumber"] = CardNumber;
                    //return Redirect("/Admin/Permission");
                    return Content("<script>alert('欢迎管理员');location.href='/Admin/Permission'</script>");
                }
                else if (a == null || (a!=null && a.Effective=="无效"))
                {
                    Session["cardnumber"] = CardNumber;
                    return Content("<script>alert('登陆成功');location.href='Ceshi'</script>");
                }
                else
                {
                    Session["cardnumber"] = CardNumber;
                    return Content("<script>alert('登陆成功');location.href='Paotui'</script>");
                }
                
            }
            else
            {
                return Content("<script>alert('账号或密码错误，请重试！');location.href='Index'</script>");
            }


        }

        public ActionResult Reque()
        {
            //修改账户的申请状态为已申请

            Model1 model1 = new Model1();
            var cardnumber = Session["cardnumber"];
            account account = model1.account.Where(p => p.CardNumber == cardnumber.ToString()).FirstOrDefault();
            account.ApplyFor = "已申请";

            model1.Entry(account).State = System.Data.Entity.EntityState.Modified;
            model1.SaveChanges();
            return Content("<script>alert('申请成功！');location.href='Ceshi'</script>");
        }
    }
}