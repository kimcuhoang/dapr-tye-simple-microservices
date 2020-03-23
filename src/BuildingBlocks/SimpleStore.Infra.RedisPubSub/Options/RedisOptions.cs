using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Infra.RedisPubSub.Options
{
    public class RedisOptions
    {
        public string RedisAddress { get; set; }
        public string RedisSecret { get; set; }
    }
}
