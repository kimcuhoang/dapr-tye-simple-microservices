namespace SimpleStore.Infrastructure.EfCore.SqlServer
{
    public class SqlServerConfig
    {
        public string Server { get; set; }
        public string DatabaseName { get; set; }
        public string AccountName { get; set; }
        public string AccountPassword { get; set; }

        public string ConnectionStrings 
        => $"Server={this.Server};Database={this.DatabaseName};User ID={this.AccountName};Password={this.AccountPassword};MultipleActiveResultSets=true";
    }
}
