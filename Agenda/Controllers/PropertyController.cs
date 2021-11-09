using Agenda.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        [HttpGet("ListaPropiedades")]
        public ResultRequest ListaPropiedades()
        {
            ResultRequest result = new ResultRequest();

            List<Property> lst = new List<Property>();

            try
            {
                using (agendaContext db = new agendaContext())
                {
                    lst = db.Properties.ToList();
                }

                result.Status = 200;
                result.Message = "";
                result.Data = lst;
                result.Parameters = "";
                result.Function = "PropertyController.ListaPropiedades";
            }
            catch (Exception err)
            {
                result.Status = 500;
                result.Message = err.Message;
                result.Data = null;
                result.Parameters = "";
                result.Function = "PropertyController.ListaPropiedades";
            }

            return result;
        }

        [HttpPost("PostPropiedad")]
        public ResultRequest PostPropiedad([] Property property)
        {
            ResultRequest result = new ResultRequest();

            List<Property> lst = new List<Property>();

            try
            {
                using (agendaContext db = new agendaContext())
                {
                    lst = db.Properties.ToList();
                }

                result.Status = 200;
                result.Message = "";
                result.Data = lst;
                result.Parameters = "";
                result.Function = "PropertyController.ListaPropiedades";
            }
            catch (Exception err)
            {
                result.Status = 500;
                result.Message = err.Message;
                result.Data = null;
                result.Parameters = "";
                result.Function = "PropertyController.ListaPropiedades";
            }

            return result;
        }
    }
}
