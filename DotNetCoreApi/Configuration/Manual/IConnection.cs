namespace DotNetCoreApi.Configuration.Manual
{
    public interface IConnection
    {
        string Password { get; set; }
        int Port { get; set; }
        string URL { get; set; }
        string Username { get; set; }
    }
}