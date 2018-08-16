using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mg.Logger
{
    public interface ILogger
    {
        void Info(object message);
        void Info(object message, Exception e);
        void Debug(object message);
        void Debug(object message, Exception e);
        void Warn(object message);
        void Warn(object message, Exception e);
        void Error(object message);
        void Error(object message, Exception e);
        void Fatal(object message);
        void Fatal(object message, Exception e);
    }
}
