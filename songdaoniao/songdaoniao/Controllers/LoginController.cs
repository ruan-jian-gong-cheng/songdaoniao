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
            if (data != null)
            {
                return Content("<script>alert('登陆成功');location.href='Index'</script>");
            }
            else
            {
                return Content("<script>alert('账号或密码错误，请重试！');location.href='Index'</script>");
            }


        }
    }
}