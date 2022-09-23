﻿// <auto-generated />

using Google.Protobuf;
using mqtt_grpc_device_protos;
using MQTTnet.Client;
using MQTTnet.Extensions.MultiCloud.BrokerIoTClient.GrpcBindings;
using System.Threading;
using System.Threading.Tasks;

namespace mqtt_grpc_device;

internal class mqtt_grpc_sample_device 
{
    internal GrpcCommand CommandEcho;
    internal GrpcPropertySetter PropSetterInterval;

    internal IMqttClient Connection;
    internal Properties Props;

    public mqtt_grpc_sample_device(IMqttClient client) 
    {
        Connection = client;
        Props = new Properties();
        CommandEcho = new GrpcCommand(client, "echo");
        PropSetterInterval = new GrpcPropertySetter(client, "interval");
    }

    public async Task<MqttClientPublishResult> SendTelemetryAsync(Telemetries telemetries, CancellationToken cancellationToken = default) =>
     await Connection.PublishBinaryAsync(
         $"grpc/{Connection.Options.ClientId}/tel",
         telemetries.ToByteArray(),
         MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce,
         false,
         cancellationToken);

    public async Task<MqttClientPublishResult> ReportPropertyAsync(string propName, Properties prop, CancellationToken cancellationToken = default) =>
         await Connection.PublishBinaryAsync(
             $"grpc/{Connection.Options.ClientId}/props/{propName}",
             prop.ToByteArray(),
             MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce,
             true,
             cancellationToken);

    public async Task<MqttClientPublishResult> ReportPropertiesAsync(CancellationToken cancellationToken = default) =>
            await Connection.PublishBinaryAsync(
                $"grpc/{Connection.Options.ClientId}/props",
                Props.ToByteArray(),
                MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce,
                true,
                cancellationToken);

 
}