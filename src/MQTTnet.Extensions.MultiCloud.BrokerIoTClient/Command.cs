﻿using MQTTnet.Client;
using MQTTnet.Extensions.MultiCloud.Binders;

namespace MQTTnet.Extensions.MultiCloud.BrokerIoTClient;

public class Command<T, TResp> : CloudToDeviceBinder<T, TResp>, ICommand<T, TResp>
{
    public Command(IMqttClient client, string name)
        : base(client, name)
    {
        RequestTopicPattern = "device/{clientId}/commands/{name}";
        ResponseTopicPattern = "device/{clientId}/commands/{name}/resp";
    }
}
