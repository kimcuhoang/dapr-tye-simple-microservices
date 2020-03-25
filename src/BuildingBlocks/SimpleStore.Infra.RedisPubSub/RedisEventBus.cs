using Microsoft.Extensions.Logging;
using SimpleStore.Infrastructure.Common;
using StackExchange.Redis;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace SimpleStore.Infra.RedisPubSub
{
    public class RedisEventBus : IEventBus
    {
        private readonly ILogger<RedisEventBus> _logger;
        private readonly RedisStore _redisStore;

        public RedisEventBus(RedisStore redisStore, ILogger<RedisEventBus> logger)
        {
            this._redisStore = redisStore;
            this._logger = logger;
        }

        #region Implementation of IEventBus

        public async Task PublishAsync<TMessage>(TMessage msg, params string[] channels) where TMessage : DomainEventNotification
        {
            var redis = _redisStore.RedisCache;
            var pub = redis.Multiplexer.GetSubscriber();

            var jsonObject = JsonSerializer.Serialize(msg.DomainEvent, msg.DomainEvent.GetType());

            foreach (var channel in channels)
            {
                _logger.LogInformation($"[{channel}] Publishing the message...");
                await pub.PublishAsync(channel, jsonObject, CommandFlags.FireAndForget);
            }
        }

        public async Task SubscribeAsync(Action<string, object> handler, params string[] channels)
        {
            var redis = _redisStore.RedisCache;
            var sub = redis.Multiplexer.GetSubscriber();

            foreach (var channel in channels)
            {
                await sub.SubscribeAsync(channel, (_, message) =>
                {
                    this._logger.LogInformation($"{channel} receive {message}");
                    handler.Invoke(channel, message.ToString());
                });
            }
        }

        #endregion
    }
}
