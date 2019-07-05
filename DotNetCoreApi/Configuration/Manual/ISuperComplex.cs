using System.Collections.Generic;

namespace DotNetCoreApi.Configuration.Manual
{
    public interface ISuperComplex
    {
        IEnumerable<ItemList> ItemList { get; set; }
        IEnumerable<int> List { get; set; }
    }
}