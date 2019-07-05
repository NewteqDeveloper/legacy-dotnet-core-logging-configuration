using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreApi.Configuration.Auto
{
    public class OptionSettings
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public Nested Nested { get; set; }

        public IList<ComplexList> ComplexList { get; set; }

        public IList<string> SimpleList { get; set; }
    }
}
