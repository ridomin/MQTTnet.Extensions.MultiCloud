﻿using MQTTnet.Client;
using System.Text;
using System.Text.Json.Nodes;

namespace MQTTnet.Extensions.MultiCloud.AzureIoTClient.Untyped
{
    public class GenericDesiredUpdatePropertyBinder
    {
        private readonly IMqttClient connection;
        public Func<JsonNode, GenericPropertyAck>? OnProperty_Updated = null;
        public GenericDesiredUpdatePropertyBinder(IMqttClient c, TwinRequestResponseBinder updTwinBinder)
        {
            connection = c;
            _ = connection.SubscribeWithReplyAsync("$iothub/twin/PATCH/properties/desired/#");
            connection.ApplicationMessageReceivedAsync += async m =>
             {
                 var topic = m.ApplicationMessage.Topic;
                 if (topic.StartsWith("$iothub/twin/PATCH/properties/desired"))
                 {
                     string msg = Encoding.UTF8.GetString(m.ApplicationMessage.Payload);
                     JsonNode? desired = JsonNode.Parse(msg);

                     if (desired != null)
                     {
                         if (OnProperty_Updated != null)
                         {
                             var ack = OnProperty_Updated(desired);
                             if (ack != null)
                             {
                                 _ = updTwinBinder.UpdateTwinAsync(ack.BuildAck());
                             }
                         }
                     }
                 }
                 await Task.Yield();
             };
        }
        public async Task InitiSubscriptionsAsync() => await connection.SubscribeWithReplyAsync("$iothub/twin/PATCH/properties/desired/#");
    }
}
