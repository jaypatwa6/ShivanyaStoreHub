
namespace SSH.Framework.Logging
{
    public class DefaultLogger : ILogger
    {
        private static readonly ILogger? _instance;

        public static ILogger Instance => _instance ?? new DefaultLogger();

        public void Log(string message, params object[] parameters)
        {
            Debug(message, parameters);
        }

        public void LogSqlStatement(string databaseName, string dataContextId, string message)
        {
            System.Diagnostics.Debug.WriteLine(
                new string(' ', 150) + string.Format("--[{0}, DbContextId:#{1}] Generated SQL log at {2:o}:", databaseName, dataContextId, DateTime.Now) +
                Environment.NewLine +
                message);
        }

        public void Debug(string message, params object[] parameters)
        {
            WriteDebugLog(string.Format(message, parameters));
        }

        public void Debug(LogSegment logSegment, string message, params object[] parameters)
        {
            WriteDebugLog(string.Format("[{0}]: ", logSegment.SegmentName) + string.Format(message, parameters));
        }

        public void DebugSegmentStart(LogSegment logSegment, string message, params object[] parameters)
        {
            WriteDebugLog(string.Format("[{0}]:  STARTED\r\n", logSegment.SegmentName) + string.Format(message, parameters));
        }

        public void DebugSegmentEnd(LogSegment logSegment, string message, params object[] parameters)
        {
            WriteDebugLog(string.Format("[{0}]:  END\r\n", logSegment.SegmentName) + string.Format(message, parameters));
        }
        public void DebugCreateInstance(LogSegment logSegment)
        {
            Debug("[{0}]: NEW INSTANCE CREATED!", logSegment.SegmentName);
        }

        public void Error(string message, params object[] parameters)
        {
            Debug("[ERROR]: " + message, parameters);
        }

        public void Error(Exception exception)
        {
            Debug("[EXCEPTION]: {0}", exception);
        }

        public void Error(LogSegment logSegment, Exception exception)
        {
            Debug("[EXCEPTION] [{0}]: {1}", logSegment.SegmentName, exception);
        }

        public void Fatal(string message, params object[] parameters)
        {
            Debug("[Fatal]: " + message, parameters);
        }

        public void Fatal(Exception exception)
        {
            Debug("[EXCEPTION]: {0}", exception);
        }

        public void Fatal(LogSegment logSegment, Exception exception)
        {
            Debug("[EXCEPTION] [{0}]: {1}", logSegment.SegmentName, exception);
        }

        public void Info(string message, params object[] parameters)
        {
            Debug("[Info]: " + message, parameters);
        }

        public void Info(Exception exception)
        {
            Debug("[Info]: {0}", exception);
        }

        public void Info(LogSegment logSegment, Exception exception)
        {
            Debug("[Info] [{0}]: {1}", logSegment.SegmentName, exception);
        }

        public void Warn(string message, params object[] parameters)
        {
            Debug("[Warn]: " + message, parameters);
        }

        public void Warn(Exception exception)
        {
            Debug("[Warn]: {0}", exception);
        }

        public void Warn(LogSegment logSegment, Exception exception)
        {
            Debug("[Warn] [{0}]: {1}", logSegment.SegmentName, exception);
        }

        private static void WriteDebugLog(string message)
        {
            System.Diagnostics.Debug.WriteLine(
                string.Format("----<DEBUG [{0:o}] [Thread:{1:D}]", DateTime.Now, Thread.CurrentThread.ManagedThreadId) + new string('-', 50) +
                Environment.NewLine + message + Environment.NewLine +
                new string('-', 100) + "DEBUG/>"
                );
        }
    }
}
