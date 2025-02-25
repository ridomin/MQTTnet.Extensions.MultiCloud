﻿//  <auto-generated/> 

using MQTTnet.Client;
using MQTTnet.Extensions.MultiCloud;
using MQTTnet.Extensions.MultiCloud.AwsIoTClient;
using MQTTnet.Extensions.MultiCloud.AwsIoTClient.TopicBindings;
using MQTTnet.Extensions.MultiCloud.BrokerIoTClient;

namespace dtmi_rido_pnp_memmon.aws;

public class memmon : AwsMqttClient, Imemmon
{
    public IReadOnlyProperty<DateTime> Property_started { get; set; }
    public IWritableProperty<bool> Property_enabled { get; set; }
    public IWritableProperty<int> Property_interval { get; set; }
    public ITelemetry<double> Telemetry_workingSet { get; set; }
    public ICommand<DiagnosticsMode, Dictionary<string, string>> Command_getRuntimeStats { get; set; }

    public string InitialState => String.Empty;

    internal memmon(IMqttClient c) : base(c, Imemmon.ModelId)
    {
        Property_started = new ReadOnlyProperty<DateTime>(c, "started");
        Property_interval = new WritableProperty<int>(c, "interval");
        Property_enabled = new AwsWritablePropertyUTFJson<bool>(c, "enabled");
        Telemetry_workingSet = new Telemetry<double>(c, "workingSet");
        Command_getRuntimeStats = new Command<DiagnosticsMode, Dictionary<string, string>>(c, "getRuntimeStats");
    }
}