namespace SimpleStore.Infrastructure.Common.Tracing
{
    public class ZipkinOption
    {
        public bool Enabled { get; set; }
        public string EndpointUrl { get; set; }
    }
}
