using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIAuthorization.Data;
using Microsoft.AspNetCore.Mvc;

namespace APIAuthorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterCard_AuthSettingController : ControllerBase
    {
        private MC_AuthSettingContext _authSettingContext;
        public MasterCard_AuthSettingController(MC_AuthSettingContext authSettingContext)
        {
            _authSettingContext = authSettingContext;
        }
    }
}