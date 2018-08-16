using log4net;
using Mg.Logger;
using Mg.Untility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mg.Untility.Logger
{
    public class LoggerBase : ILogger
    {
        //日志对象
        private ILog log;
        static LoggerBase()
        {
            SetConfig();
        }
        private static void SetConfig()
        {
            SetConfig(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + ConstantSetting.Log4NetPath));
        }
        public static void SetConfig(string path)
        {
            FileInfo configFile = new FileInfo(path);
            log4net.Config.XmlConfigurator.Configure(configFile);
        }
         
        public LoggerBase():this(typeof(LoggerBase))
        {
         
        }
        public LoggerBase(Type type)
        {
            log = LogManager.GetLogger(type);
        }

        public static ILogger CreateInstance()
        {
            return new LoggerBase();
        }
        #region 日志对象的操作
        public void Debug(object message)
        {
            log.Debug(message);
        }

        public void Debug(object message, Exception e)
        {
            log.Debug(message, e);
        }

        public void Error(object message)
        {
            log.Error(message);
        }

        public void Error(object message, Exception e)
        {
            log.Error(message, e);
        }

        public void Fatal(object message)
        {
            log.Fatal(message);
        }

        public void Fatal(object message, Exception e)
        {
            log.Fatal(message, e);
        }

        public void Info(object message)
        {
            log.Info(message);
        }

        public void Info(object message, Exception e)
        {
            log.Info(message, e);
        }

        public void Warn(object message)
        {
            log.Warn(message);
        }

        public void Warn(object message, Exception e)
        {
            log.Warn(message, e);
        } 
        #endregion
    }
}
