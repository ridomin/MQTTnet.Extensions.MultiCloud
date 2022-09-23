﻿//  <auto-generated/> 

using MQTTnet.Client;
using MQTTnet.Extensions.MultiCloud;
using MQTTnet.Extensions.MultiCloud.BrokerIoTClient;
using MQTTnet.Extensions.MultiCloud.BrokerIoTClient.PnPTopicBindings;

namespace dtmi_com_example_devicetemplate.mqtt;

public class devicetemplate : PnPMqttClient, Idevicetemplate
{
    public IReadOnlyProperty<string> Property_sdkInfo { get; set; }
    public IWritableProperty<int> Property_interval { get; set; }
    public ITelemetry<double> Telemetry_temp { get; set; }
    public ICommand<Cmd_echo_Request, Cmd_echo_Response> Command_echo { get; set; }

    public devicetemplate(IMqttClient c) : base(c, Idevicetemplate.ModelId)
    {
        Property_sdkInfo = new ReadOnlyProperty<string>(c, "sdkInfo");
        Property_interval = new WritableProperty<int>(c, "interval");
        Telemetry_temp = new Telemetry<double>(c, "temp");
        Command_echo = new Command<Cmd_echo_Request, Cmd_echo_Response>(c, "echo");
    }

    public async Task<MqttClientPublishResult> SendTelemetryAsync(AllTelemetries payload, CancellationToken t) =>
        await base.SendTelemetryAsync(payload, t);
}
