using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSH.Framework.Logging
{
    public interface ILogger
    {
        void Log(string message, params object[] parameters);

        void LogSqlStatement(string databaseName, string dataContextId, string message);

        void Debug(string message, params object[] parameters);

        void Debug(LogSegment logSegment, string message, params object[] parameters);

        void DebugSegmentStart(LogSegment logSegment, string message, params object[] parameters);

        void DebugSegmentEnd(LogSegment logSegment, string message, params object[] parameters);

        void DebugCreateInstance(LogSegment logSegment);

        void Error(string message, params object[] parameters);

        void Error(Exception exception);

        void Error(LogSegment logSegment, Exception exception);

        void Fatal(string message, params object[] parameters);

        void Fatal(Exception exception);

        void Fatal(LogSegment logSegment, Exception exception);

        void Info(string message, params object[] parameters);

        void Info(Exception exception);

        void Info(LogSegment logSegment, Exception exception);

        void Warn(string message, params object[] parameters);

        void Warn(Exception exception);

        void Warn(LogSegment logSegment, Exception exception);
    }
}
