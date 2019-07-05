using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreApi.Configuration.Manual
{
    public class SuperComplex : ISuperComplex
    {
        public IEnumerable<int> List { get; set; }

        public IEnumerable<ItemList> ItemList { get; set; }

        public SuperComplex(IConfiguration configuration)
        {

        }
    }
}
