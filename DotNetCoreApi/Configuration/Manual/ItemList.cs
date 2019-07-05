using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreApi.Configuration.Manual
{
    public class ItemList : IItemList
    {
        public string Item { get; set; }

        public int Index { get; set; }

        public ItemList(IConfiguration configuration)
        {

        }
    }
}
