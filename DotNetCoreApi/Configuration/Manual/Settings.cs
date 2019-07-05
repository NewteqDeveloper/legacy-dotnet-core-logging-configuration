using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreApi.Configuration.Manual
{
    public class Settings : ISettings
    {
        public IConnection Connection { get; set; }

        public IEnumerable<string> Scopes { get; set; }

        public IList<ISuperList> SuperList { get; set; }

        public ISuperComplex SuperComplex { get; set; }

        public Settings(IConfigurationSection configurationSection)
        {
            Connection = new Connection(configurationSection.GetSection(nameof(Connection)));
            Scopes = configurationSection.GetSection(nameof(Scopes)).Get<IEnumerable<string>>();
            var superListItems = configurationSection.GetSection(nameof(SuperList));
            var superListActualItems = superListItems.GetChildren();
            if (superListActualItems.Any())
            {
                SuperList = new List<ISuperList>();
                foreach (var child in superListActualItems)
                {
                    SuperList.Add(new SuperList(child));
                }
            }
        }
    }
}
