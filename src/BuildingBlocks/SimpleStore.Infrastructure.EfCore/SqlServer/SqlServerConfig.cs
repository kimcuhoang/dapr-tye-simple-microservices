namespace SimpleStore.Infrastructure.EfCore.SqlServer
{
    public class SqlServerConfig
    {
        public string Server { get; set; }
        public string DatabaseName { get; set; }
        public string AccountName { get; set; }
        public string AccountPassword { get; set; }
    }
}
