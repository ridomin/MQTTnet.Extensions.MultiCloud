﻿namespace MQTTnet.Extensions.MultiCloud.AzureIoTClient.Untyped
{
    public interface IBaseCommandResponse
    {
        public int Status { get; set; }
        public object ReponsePayload { get; set; }
    }
}
