using DotNetCoreApi.Configuration.Manual;
using DotNetCoreApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text;

namespace DotNetCoreApi.Controllers
{
    public class SettingsController : BaseApiController
    {
        private readonly IAppSettings appSettings;

        public SettingsController(IAppSettings appSettings)
        {
            this.appSettings = appSettings;
        }

        [Route("string")]
        [HttpGet]
        public IActionResult GetStringValue()
        {
            var result = $"The value from settings is: {this.appSettings.StringValue}. The type of this value is: {this.appSettings.StringValue.GetType()}";
            return Ok(result);
        }

        [Route("int")]
        [HttpGet]
        public IActionResult GetIntValue()
        {
            var result = $"The value from settings is: {this.appSettings.IntValue}. The type of this value is: {this.appSettings.IntValue.GetType()}";
            return Ok(result);
        }

        [Route("scopes")]
        [HttpGet]
        public IActionResult GetScopes()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("These are the scopes we found in the settings:\r\n");
            foreach (var item in this.appSettings.Settings.Scopes)
            {
                stringBuilder.Append($"{item}\r\n");
            }
            return Ok(stringBuilder.ToString());
        }

        [Route("superlist")]
        [HttpGet]
        public IActionResult GetSuperList()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("These are the super list items we found in the settings:\r\n");
            if (this.appSettings.Settings.SuperList == null || !this.appSettings.Settings.SuperList.Any())
            {
                stringBuilder.Append("NOTHING");
            }
            else
            {
                foreach (var item in this.appSettings.Settings.SuperList)
                {
                    stringBuilder.Append($"Listed: {item.Listed} && Metadata: {item.Metadata}\r\n");
                }
            }
            return Ok(stringBuilder.ToString());
        }
    }
}
