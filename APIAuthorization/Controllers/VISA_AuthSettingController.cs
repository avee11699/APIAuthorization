using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIAuthorization.Data;
using APIAuthorization.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIAuthorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VISA_AuthSettingController : ControllerBase
    {
        private AuthSettingContext _authSettingContext;
        public VISA_AuthSettingController(AuthSettingContext authSettingContext)
        {
            _authSettingContext = authSettingContext;
        }
        public IEnumerable<authsetting> GetList([FromBody] AuthSettingPostman setting)
        {
            //PaymentDetails json = JsonConvert.DeserializeObject(PaymentDetails);
            // var avneesh = new AuthSetting { KEY = setting.KEY, VALUE = output };
            return _authSettingContext.AuthorizationSettings.ToList();

        }

        [HttpGet("{KEY}")]
        public IActionResult GetSingleValue(Guid KEY, [FromBody] AuthSettingPostman searchString)
        {
            var authsetting = _authSettingContext.AuthorizationSettings.SingleOrDefault(m => m.KEY == KEY);
            //if (authSetting == null)
            //{
            //    return NotFound("NO RECORD FOUND...!");
            //}
            //return Ok(authSetting);
            if (!String.IsNullOrEmpty(searchString.ToString()))
            {
               // authSetting =authsetting.Where(m => m.KEY.Contains(searchString));
            }
            return null;
        }
    }
}