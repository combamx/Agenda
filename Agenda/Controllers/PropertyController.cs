using Agenda.Models;
using Agenda.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
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
        public ResultRequest PostPropiedad([FromQuery] PropertyRequest propertyRequest)
        {
            ResultRequest result = new ResultRequest();
            List<Property> lst = new List<Property>();

            try
            {
                using (agendaContext db = new agendaContext())
                {
                    Property property = new Property();
                    property.Title = propertyRequest.Title;
                    property.Address = propertyRequest.Address;
                    property.Description = propertyRequest.Description;
                    property.Status = propertyRequest.Status;

                    db.Properties.AddAsync(property);
                    db.SaveChanges();

                    lst = db.Properties.OrderByDescending(x => x.Id).ToList();
                }

                result.Status = 201;
                result.Message = "";
                result.Data = lst;
                result.Parameters = JsonConvert.SerializeObject(propertyRequest); ;
                result.Function = "PropertyController.PostPropiedad";
            }
            catch (Exception err)
            {
                result.Status = 500;
                result.Message = err.Message;
                result.Data = null;
                result.Parameters = JsonConvert.SerializeObject(propertyRequest); ;
                result.Function = "PropertyController.PostPropiedad";
            }

            return result;
        }

        [HttpPut("PutPropiedad")]
        public ResultRequest PutPropiedad([FromQuery] PropertyRequest propertyRequest)
        {
            ResultRequest result = new ResultRequest();
            List<Property> lst = new List<Property>();

            try
            {
                using (agendaContext db = new agendaContext())
                {
                    Property property = db.Properties.Find(propertyRequest.Id);

                    if(property != null)
                    {
                        property.Title = propertyRequest.Title;
                        property.Address = propertyRequest.Address;
                        property.Description = propertyRequest.Description;
                        property.Status = propertyRequest.Status;

                        db.Entry(property).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        db.SaveChanges();
                    }

                    lst = db.Properties.OrderByDescending(x => x.Id).ToList();
                }

                result.Status = 201;
                result.Message = "";
                result.Data = lst;
                result.Parameters = JsonConvert.SerializeObject(propertyRequest);
                result.Function = "PropertyController.PutPropiedad";
            }
            catch (Exception err)
            {
                result.Status = 500;
                result.Message = err.Message;
                result.Data = null;
                result.Parameters = JsonConvert.SerializeObject(propertyRequest); ;
                result.Function = "PropertyController.PutPropiedad";
            }

            return result;
        }

        [HttpDelete("DeletePropiedad/{id}")]
        public ResultRequest DeletePropiedad(int id)
        {
            ResultRequest result = new ResultRequest();
            List<Property> lst = new List<Property>();

            try
            {
                using (agendaContext db = new agendaContext())
                {
                    Property property = db.Properties.Find(id);
                    if (property != null)
                    {
                        db.Remove(property);
                        db.SaveChanges();
                    }

                    lst = db.Properties.OrderByDescending(x => x.Id).ToList();
                }

                result.Status = 201;
                result.Message = "";
                result.Data = lst;
                result.Parameters = $"ID = {id}";
                result.Function = "PropertyController.DeletePropiedad";
            }
            catch (Exception err)
            {
                result.Status = 500;
                result.Message = err.Message;
                result.Data = null;
                result.Parameters = $"ID = {id}";
                result.Function = "PropertyController.DeletePropiedad";
            }

            return result;
        }
    }
}
