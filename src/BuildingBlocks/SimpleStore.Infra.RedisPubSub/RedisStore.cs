using Microsoft.Extensions.Options;
using SimpleStore.Infra.RedisPubSub.Options;
using StackExchange.Redis;
using System;

namespace SimpleStore.Infra.RedisPubSub
{
    public class RedisStore
    {
        private static Lazy<ConnectionMultiplexer> _lazyConnection;

        public RedisStore(IOptions<RedisOptions> redisOptions)
        {
            var configurationOptions = new ConfigurationOptions
            {
                EndPoints =
                {
                    redisOptions.Value.RedisAddress
                },
                Password = redisOptions.Value.RedisSecret
            };

            _lazyConnection =
                new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(configurationOptions));
        }

        public ConnectionMultiplexer Connection => _lazyConnection.Value;

        public IDatabase RedisCache => Connection.GetDatabase();
    }
}
