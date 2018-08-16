using App.ViewModel;
using Mg.Core;
using Mg.Core.IOC;
using Mg.Encrypt;
using Mg.Framework.IService;
using Mg.Logger;
using Mg.Untility.Logger;
using Mg.Untility.Web;
using Mg.Web.Core;
using Newtonsoft.Json.Linq;
using RepositoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public class AccountController : Controller
    {

        protected ILogger log = new LoggerBase(typeof(AccountController));
        // GET: Account
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public JsonResult Login(JObject data)
        {
            string UserCode = data.Value<string>("username");
            string Password = data.Value<string>("password");
            string IP = data.Value<string>("ip");
            string City = data.Value<string>("city");
            Sys_User user = new Sys_User()
            {
                Code = UserCode,
                Password = MD5Encrypt.Encrypt(Password, 64)
            };

            ISys_UserService bLL = DIFactory.GetService<ISys_UserService>();
            var loginResult = bLL.Login(user);
            if (loginResult.Succeed && loginResult.ResultData != null)
            {
                //登录成功后，查询当前用户数据 
                user = loginResult.ResultData as Sys_User;

                //调用框架中的登录机制
                var loginer = new BaseLoginer
                {
                    UserId = 0,// user.UserId,
                    ID = user.Id,
                    UserCode = user.Code,
                    Password = user.Password,
                    UserName = user.Name,
                    Data = user,
                    IsAdmin = user.Explain == "管理员用户"  //根据用户Explain判断。用户类型：0=未定义 1=超级管理员 2=普通用户 3=其他
                };

                //读取配置登录默认失效时长：小时
                var effectiveHours = Convert.ToInt32(60 * ConfigUtil.GetConfigDecimal("LoginEffectiveHours"));


                //执行web登录
                FormsAuth.SignIn(loginer.ID.ToString(), loginer, effectiveHours);
                log.Info("登录成功！用户：" + loginer.UserName + "，账号：" + loginer.UserCode + "，密码：---");
                //设置服务基类中，当前登录用户信息
               // this.CurrentBaseLoginer = loginer;
                //登陆后处理
                //更新用户登陆次数及时间（存储过程登录，数据库已经处理）
                //添加登录日志
                string userinfo = string.Format("用户姓名：{0}，用户编号：{1}，登录账号：{2}，登录密码：{3}",
                    loginer.UserName, loginer.UserCode, loginer.UserCode, "---"/*loginer.Password*/);
                //更新其它业务
            }
            else
            {
                log.Info("登录失败！账号：" + UserCode + "，密码：" + Password + "。原因：" + loginResult.ResultMsg);
            }
            return Json(loginResult, JsonRequestBehavior.DenyGet);

        }
    }
}