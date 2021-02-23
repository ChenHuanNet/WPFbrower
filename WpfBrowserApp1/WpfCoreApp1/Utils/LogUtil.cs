using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace WpfCoreApp1.Utils
{
    public class LogUtil
    {
        private static readonly Logger log = LogManager.GetLogger("");

        public static void Error(string msg, Exception exp = null)
        {
            if (exp == null)
                log.Error(msg);
            else
                log.Error(exp, msg);
        }

        public static void Debug(string msg, Exception exp = null)
        {
            if (exp == null)
                log.Debug(msg);
            else
                log.Debug(exp, msg);
        }

        public static void Info(string msg, Exception exp = null)
        {
            if (exp == null)
                log.Info(msg);
            else
                log.Info(exp, msg);
        }


        public static void Warn(string msg, Exception exp = null)
        {
            if (exp == null)
                log.Warn(msg);
            else
                log.Warn(exp, msg);
        }
    }
}
