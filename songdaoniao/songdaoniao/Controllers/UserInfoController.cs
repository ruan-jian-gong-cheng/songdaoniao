using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrary1;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebApplication5.Controllers
{
    public class UserInfoController : Controller
    {
        // GET: UserInfo
        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        public ActionResult Register()
        {
            account account = new account();
            account.CardNumber = Request.Form["CardNumber"];
            account.Name = Request.Form["name"];
            account.Nickname = Request.Form["username"];
            account.Password = Request.Form["password"];
            account.Telephone = Request.Form["phone"];
            account.Address = Request.Form["address"];
            account.Email = Request.Form["email"];
            account.ApplyFor = "未申请";

            client client = new client();
            client.CardNumber = Request.Form["CardNumber"];

            Model1 model1 = new Model1();
            model1.account.Add(account);

            //var data = model1.account.ToList();
            //data = data.Where(p => p.CardNumber.Contains(account.CardNumber)).ToList();
            var data = model1.account.Where(p => p.CardNumber == account.CardNumber).FirstOrDefault();

            if (string.IsNullOrEmpty(account.CardNumber) || string.IsNullOrEmpty(account.Name) || string.IsNullOrEmpty(account.Nickname) || string.IsNullOrEmpty(account.Password) || string.IsNullOrEmpty(account.Telephone) || string.IsNullOrEmpty(account.Address))
            {
                return Content("<script>alert('带*信息不能为空');location.href='Index'</script>");
            }

            else if (data != null)
            {
                return Content("<script>alert('该卡号已注册');location.href='Index'</script>");
            }

            else
            {
                // Model1 model1 = new Model1();
                //model1.account.Add(account);
                client.ClientID = (Convert.ToInt32((model1.client.OrderByDescending(d => d.ClientID).FirstOrDefault()).ClientID)+1).ToString();
   
                model1.client.Add(client);
                model1.SaveChanges();
                //return RedirectToAction("register");
                return Content("<script>alert('亲注册成功');location.href='/Login/Index'</script>");
            }

        }


    }

}