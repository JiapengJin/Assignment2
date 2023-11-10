using MVCEntity;
using MVCLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApplication.Controllers
{
    public class HomeController : BaseController
    {

        LogicUser logicUser = new LogicUser();
        LogicGoods logicGoods = new LogicGoods();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            //如果账号或者密码有空，直接返回失败
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return ErrorResult("缺少必要参数，请求失败");
            }
            else
            {
                //调用用户登录的方法
                var data = logicUser.CheckLogin(username, password);
                if (data != null)
                {
                    return SuccessResult("登录成功");
                }
                else
                {
                    return ErrorResult("登录失败");
                }
            }
        }


        public ActionResult GoodsList()
        {
            return View();
        }

        public string GetGoodsList(string keyWord)
        {
            var data = logicGoods.GetGoodsList(keyWord);
            return data.ToJsonCon();
        }


        public ActionResult DelGoods(int ID)
        {
            bool b = logicGoods.DelGood(ID);
            if (b)
            {
                return SuccessResult("删除成功");
            }
            else
            {
                return ErrorResult("删除失败");
            }
        }

        public ActionResult GoodsDetail()
        {
            return View();
        }

        public ActionResult UpdateSingleGood(Goods goods)
        {
            logicGoods.UpdateSingleGood(goods);
            return SuccessResult("修改成功");
        }

        public string GetSingleGood(int ID)
        {
            var data = logicGoods.GetSingleGood(ID);
            return data.ToJsonCon();
        }


        public ActionResult InsertSingleGood(Goods goods)
        {
            logicGoods.InsertGood(goods);
            return SuccessResult("新增成功");
        }



        public ActionResult UserList()
        {
            return View();
        }

        public string GetUserList(string keyWord)
        {
            var pageData = logicUser.GetUsersList(keyWord);
            return pageData.ToJsonCon();
        }


        public ActionResult DelUser(int ID)
        {
            bool b = logicUser.DelUser(ID);
            if (b)
            {
                return SuccessResult("删除成功");
            }
            else
            {
                return SuccessResult("删除失败");
            }
        }

        public ActionResult UserDetail()
        {
            return View();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string GetSingleUser(int ID)
        {
            var data = logicUser.GetSingleUser(ID);
            return data.ToJsonCon();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="FlowerName"></param>
        /// <param name="Price"></param>
        /// <param name="Color"></param>
        /// <returns></returns>
        public ActionResult UpdateSingleUser(User user)
        {
            logicUser.UpdateSingleUser(user);
            return SuccessResult("修改成功");
        }
    }
}