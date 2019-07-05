using System.Collections.Generic;

namespace DotNetCoreApi.Configuration.Manual
{
    public interface ISettings
    {
        IConnection Connection { get; set; }
        IEnumerable<string> Scopes { get; set; }
        ISuperComplex SuperComplex { get; set; }
        IList<ISuperList> SuperList { get; set; }
    }
}