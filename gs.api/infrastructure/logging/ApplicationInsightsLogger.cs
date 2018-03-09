using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Microsoft.ApplicationInsights;

namespace gs.api.infrastructure.logging
{
    /// <summary>
    /// Класс, логирующий в applicationInsights.
    /// </summary>
    public class ApplicationInsightsLogger : ILog
    {
        private readonly TelemetryClient _telemetryClient;

        public ApplicationInsightsLogger([NotNull] TelemetryClient telemetryClient)
        {
            _telemetryClient = telemetryClient ?? throw new ArgumentNullException(nameof(telemetryClient));
        }

        public void LogDebug(string eventName, string message, IDictionary<string, string> properties = null)
        {
            properties?.Add("Message", message);
            _telemetryClient.TrackEvent(eventName, properties);
        }

        public void LogError(string message, Exception err, IDictionary<string, string> properties = null)
        {
            properties?.Add("Message", message);
            _telemetryClient.TrackException(err, properties);
        }
    }
}