using System.Collections.Generic;

namespace DotNetCoreApi.Configuration.Auto
{
    public class Nested
    {
        public string Item { get; set; }
        public string Value { get; set; }
        public string Metadata { get; set; }
        public IList<ComplexList> ComplexList { get; set; }
        public IList<string> SimpleList { get; set; }
    }
}