using System;
using System.Threading.Tasks;

namespace SimpleStore.Infrastructure.Common
{
    public interface IEventBus
    {
        Task PublishAsync<TMessage>(TMessage msg, params string[] channels) where TMessage : DomainEventNotification;
        Task SubscribeAsync(Action<string, object> handler, params string[] channels);
    }
}
