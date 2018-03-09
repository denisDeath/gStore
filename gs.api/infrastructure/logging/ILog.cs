using System;
using System.Collections.Generic;

namespace gs.api.infrastructure.logging
{
    public interface ILog
    {
        void LogDebug(string eventName, string message, IDictionary<string, string> properties = null);
        void LogError(string message, Exception err, IDictionary<string, string> properties = null);
    }
}