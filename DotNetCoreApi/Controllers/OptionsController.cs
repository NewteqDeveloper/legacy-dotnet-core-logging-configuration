using DotNetCoreApi.Configuration.Auto;
using DotNetCoreApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreApi.Controllers
{
    public class OptionsController : BaseApiController
    {
        private readonly OptionSettings settings;
        private readonly IList<ComplexList> complex;

        public OptionsController(IOptions<OptionSettings> settings, IOptions<List<ComplexList>> complex)
        {
            this.settings = settings.Value;
            this.complex = complex.Value;
        }

        [Route("username")]
        [HttpGet]
        public IActionResult GetUsernameAndPassword()
        {
            var result = $"{this.settings.Username} with password: {this.settings.Password}";

            return Ok(result);
        }

        [Route("complex")]
        [HttpGet]
        public IActionResult GetComplex()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append("This is directly form the optionSettings\r\n");
            foreach (var item in this.settings.ComplexList)
            {
                stringBuilder.Append($"{item.Value}\r\n");
            }

            stringBuilder.Append("\r\n\r\nThis is directly from the complex list itself\r\n\r\n");

            foreach (var item in this.complex)
            {
                stringBuilder.Append($"{item.Value}\r\n");
            }

            return Ok(stringBuilder.ToString());
        }
    }
}
