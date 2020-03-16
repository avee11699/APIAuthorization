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
    public class User_LoginController : ControllerBase
    {
        private User_LoginContext _userLoginContext;
        
        public User_LoginController(User_LoginContext userLoginContext)
        {
            _userLoginContext = userLoginContext;   
        }
    }
}