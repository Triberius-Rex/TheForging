using System;

namespace Server.Custom.ScriptVisitor.Utils.Logger
{
    public static class SVLogger
    {
        // TODO use TraceSource / Log4Net

        private static readonly ConsoleColor m_DEBUG_COLOR = ConsoleColor.DarkCyan;
        private static readonly ConsoleColor m_WARN_COLOR = ConsoleColor.DarkYellow;
        private static readonly ConsoleColor m_ERROR_COLOR = ConsoleColor.Red;

        private enum Level
        {
            Debug, Info, Warn, Error
        }

        #region DEBUG

        public static void Debug(string message)
        {
#if DEBUG
            Write(Level.Debug, m_DEBUG_COLOR, null, message);
#endif
        }

        public static void Debug(string format, params object[] args)
        {
#if DEBUG
            Write(Level.Debug, m_DEBUG_COLOR, null, format, args);
#endif
        }

        public static void Debug(Exception e, string message)
        {
#if DEBUG
            Write(Level.Debug, m_DEBUG_COLOR, e, message);
#endif
        }

        public static void Debug(Exception e, string format, params object[] args)
        {
#if DEBUG
            Write(Level.Debug, m_DEBUG_COLOR, e, format, args);
#endif
        }

        #endregion

        #region INFO

        public static void Info(string message)
        {
            Write(Level.Info, null, message);
        }

        public static void Info(string format, params object[] args)
        {
            Write(Level.Info, null, format, args);
        }

        public static void Info(Exception e, string message)
        {
            Write(Level.Info, e, message);
        }

        public static void Info(Exception e, string format, params object[] args)
        {
            Write(Level.Info, e, format, args);
        }

        #endregion

        #region WARN

        public static void Warn(string message)
        {
            Write(Level.Warn, m_WARN_COLOR, null, message);
        }

        public static void Warn(string format, params object[] args)
        {
            Write(Level.Warn, m_WARN_COLOR, null, format, args);
        }

        public static void Warn(Exception e, string message)
        {
            Write(Level.Warn, m_WARN_COLOR, e, message);
        }

        public static void Warn(Exception e, string format, params object[] args)
        {
            Write(Level.Warn, m_WARN_COLOR, e, format, args);
        }

        #endregion

        #region ERROR

        public static void Error(string message)
        {
            Write(Level.Error, m_ERROR_COLOR, null, message);
        }

        public static void Error(string format, params object[] args)
        {
            Write(Level.Error, m_ERROR_COLOR, null, format, args);
        }

        public static void Error(Exception e, string message)
        {
            Write(Level.Error, m_ERROR_COLOR, e, message);
        }

        public static void Error(Exception e, string format, params object[] args)
        {
            Write(Level.Error, m_ERROR_COLOR, e, format, args);
        }

        #endregion

        #region internal writers

        private static void Write(Level loglevel, ConsoleColor color, Exception e, string format, params object[] args)
        {
            Utility.PushColor(color);
            Write(loglevel, e, format, args);
            Utility.PopColor();
        }

        private static void Write(Level loglevel, Exception e, string format, params object[] args)
        {
            WriteLine(loglevel, format, args);
            WriteException(e);
        }

        private static void WriteLine(Level loglevel, string format, params object[] args)
        {
            string loglevelString;
            switch (loglevel)
            {
                case Level.Debug: loglevelString = "DEBUG"; break;
                case Level.Info: loglevelString = "INFO"; break;
                case Level.Warn: loglevelString = "WARN"; break;
                case Level.Error: loglevelString = "ERROR"; break;
                default: loglevelString = "UNKN"; break;
            }
            string logPrefix = string.Format("{0}<{1,5}> : ", DateTime.UtcNow.ToString(FileLogger.DateFormat), loglevelString);
            if (format == null)
                Console.WriteLine(logPrefix + "message text is <null>");
            else
                Console.WriteLine(logPrefix + format, args);
        }

        private static void WriteException(Exception e)
        {
            if (e == null)
                return;

            Console.WriteLine(e);
        }

        /* test
            SVLogger.Debug("test 1");
            SVLogger.Debug("test {0}", 2);
            SVLogger.Debug(new NotImplementedException(), "test 3");
            SVLogger.Debug(new NotImplementedException(), "test {0}", 4);
            SVLogger.Debug(new NotImplementedException(), "test {0}", null, null, null, 5);
            SVLogger.Debug(new NotImplementedException(), null);
            SVLogger.Debug(null);
            SVLogger.Debug(null, "abc");
            SVLogger.Debug(null, null, null);
        */

        #endregion
    }
}
