﻿namespace Boutique.Messages.EventBusRabbitMQ.Interfaces
{
    public interface IEventBus
    {
        void Publish(IEvent @event);
    }
}