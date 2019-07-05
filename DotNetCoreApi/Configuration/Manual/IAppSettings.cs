namespace DotNetCoreApi.Configuration.Manual
{
    public interface IAppSettings
    {
        int IntValue { get; set; }
        ISettings Settings { get; set; }
        string StringValue { get; set; }
    }
}