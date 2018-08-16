
using log4net;
using log4net.Core;
using Mg.Untility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AH.Untility.Logger
{
    public sealed class LoggerHelper 
    { 
        static LoggerHelper()
        {
            SetConfig();
        }
        public static void SetConfig()
        {
            SetConfig(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + ConstantSetting.Log4NetPath));
        }
        public static void SetConfig(string path)
        {
            FileInfo configFile = new FileInfo(path);
            log4net.Config.XmlConfigurator.Configure(configFile);
        }
        private LoggerHelper()
        {
             
        }

        public static LoggerBase CreateLogger(Type type)
        {
            return new LoggerBase(type);
        }

        private static readonly ILogger.ILogger logger = new LoggerBase();
        public static void Debug(object message)
        {
            logger.Debug(message);
        }

        public static void Debug(object message, Exception e)
        {
            logger.Debug(message, e);
        }

        public static void Error(object message)
        {
            logger.Error(message);
        }

        public static void Error(object message, Exception e)
        {
            logger.Error(message, e);
        }

        public static void Fatal(object message)
        {
            logger.Fatal(message);
        }

        public static void Fatal(object message, Exception e)
        {
            logger.Fatal(message, e);
        }

        public static void Info(object message)
        {
            logger.Info(message);
        }

        public static void Info(object message, Exception e)
        {
            logger.Info(message, e);
        }

        public static void Warn(object message)
        {
            logger.Warn(message);
        }

        public static void Warn(object message, Exception e)
        {
            logger.Warn(message, e);
        }
    }
}
