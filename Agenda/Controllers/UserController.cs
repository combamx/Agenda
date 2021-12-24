using Agenda.Models;
using Agenda.Models.Request;
using Agenda.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userServices)
        {
            _userService = userServices;
        }

        [HttpPost("login")]
        public ResultRequest Autentificar([FromBody] AuthRequest model)
        {
            ResultRequest result = new ResultRequest();

            try
            {
                var userResquest = _userService.Auth(model);

                if(userResquest == null)
                {
                    result.Status = 400;
                    result.Message = "Usuario y contraseña incorrectos";
                    result.Data = "";
                    result.Parameters = JsonConvert.SerializeObject(model);
                    result.Function = "UserController.Autentificar";
                }


                result.Status = 200;
                result.Message = "Token creado correctamente";
                result.Data = userResquest;
                result.Parameters = JsonConvert.SerializeObject(model);
                result.Function = "UserController.Autentificar";
            }
            catch (Exception err)
            {
                result.Status = 500;
                result.Message = err.Message;
                result.Data = null;
                result.Parameters = JsonConvert.SerializeObject(model);
                result.Function = "UserController.Autentificar";
            }

            return result;
        }
    }
}
