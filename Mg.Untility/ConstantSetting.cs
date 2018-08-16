using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
namespace Mg.Untility
{
    /// <summary>
    /// 常量设置
    /// </summary>
   public static class ConstantSetting
    {
        /// <summary>
        /// log4net 日志配置文件相对路径
        /// </summary>
        public static string Log4NetPath = "\\CfgFiles\\log4net.Config";
        /// <summary>
        /// Unity 配置文件相对路径
        /// </summary>
        public static string UnityPath = "\\CfgFiles\\Unity.Config";
        /// SqlScripts 数据库脚本相对路径
        /// </summary>
        public static string SqlScriptPath = "\\SqlScripts\\";
        /// SqlScripts 数据库脚本后缀名
        /// </summary>
        public static string SqlScriptExt = ".txt";

        /// <summary>
        /// Unity 容器名字（配置文件中的名字）
        /// </summary>
        public static string UnityContainerName = "MyContainer";

        public static string EasyuiVersionCookiesName = "EasyuiVersion";
        public static string EasyuiThemeCookiesName = "EasyuiTheme";

        public static string UserCacheName = "UserCacheName";


        public static readonly int CommonExpiredTime_Never = 60 * 24 * 365;
        public static readonly int CommonExpiredTime_Day = 60 * 24;
        public static readonly int CommonExpiredTime_Hour = 60;

        /// <summary>
        /// 需要跟踪实体修改的字段（VD_Base）
        /// </summary>
        public static readonly string TraceFieldCollection = "TraceFieldCollection";
    }
}
