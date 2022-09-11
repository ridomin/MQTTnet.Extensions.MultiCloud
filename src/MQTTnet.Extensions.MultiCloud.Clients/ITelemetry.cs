﻿using MQTTnet.Client;
using System.Threading;
using System.Threading.Tasks;

namespace MQTTnet.Extensions.MultiCloud.Clients
{
    public interface ITelemetry<T>
    {
        Task<MqttClientPublishResult> SendTelemetryAsync(T payload, CancellationToken cancellationToken = default);
    }
}