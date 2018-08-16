using Mg.Framework.IService;
using RepositoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mg.Core;
using Mg.Untility;

namespace Mg.Framework.Service
{
    public class Sys_UserService : AppService<Sys_User>, ISys_UserService
    {
        public IResult Login(Sys_User sysUser)
        {
            CommandResult result = CommandResult.Instance_Error;
            if (sysUser.Code.IsEmpty())
            {
                result.ResultMsg = "账号不能为空,请确认!";
            }
            else if (sysUser.Password.IsEmpty())
            {
                result.ResultMsg = "密码不能为空,请确认!";
            }
            var users = base.GetList(u => u.Code == sysUser.Code).ToList();
            if (users == null || users.Count() == 0)
            {
                if (sysUser.Code.Equals("admin") && sysUser.Password.Equals("21232f297a57a5a743894a0e4a801fc3"))
                {
                    sysUser.Name = "系统管理员";
                    result = CommandResult.Instance_Succeed;
                    result.ResultData = sysUser;
                    //result.ResultUrl = "/Home/Index";
                }
                else
                {
                    result.ResultMsg = "账号不存在!";
                } 
            }
            else
            {
                var pwd = sysUser.Password;
                foreach (var u in users)
                {
                    if (u.Password.Equals(pwd))
                    {
                        if (u.Status == "停用")
                        {
                            result.ResultMsg = "账号已停用!";
                        }
                        else
                        {
                            result = CommandResult.Instance_Succeed;
                            result.ResultData = u;
                            //result.ResultUrl = "/Home/Index";
                        }
                        break;
                    }
                }
            }
            return result;
        }
    }
}
