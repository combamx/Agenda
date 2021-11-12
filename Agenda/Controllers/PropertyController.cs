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
        private readonly agendaContext _context;

        public PropertyController(agendaContext context)
        {
            _context = context;
        }

        [HttpGet("ListaPropiedades")]
        public ResultRequest ListaPropiedades()
        {
            ResultRequest result = new ResultRequest();

            List<Property> lst = new List<Property>();

            try
            {
                lst = _context.Properties.ToList();

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

            try
            {
                Property property = new Property();
                property.Title = propertyRequest.Title.ToUpper();
                property.Address = propertyRequest.Address.ToUpper();
                property.Description = propertyRequest.Description.ToUpper();
                property.Status = propertyRequest.Status;

                _context.Properties.AddAsync(property);
                _context.SaveChanges();

                result.Status = 201;
                result.Message = "";
                result.Data = 1;
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
            
            try
            {
                Property property = _context.Properties.Find(propertyRequest.Id);

                if (property != null)
                {
                    property.Title = propertyRequest.Title.ToUpper();
                    property.Address = propertyRequest.Address.ToUpper();
                    property.Description = propertyRequest.Description.ToUpper();
                    property.Status = propertyRequest.Status;

                    _context.Entry(property).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }

                result.Status = 201;
                result.Message = "";
                result.Data = 1;
                result.Parameters = JsonConvert.SerializeObject(propertyRequest);
                result.Function = "PropertyController.PutPropiedad";
            }
            catch (Exception err)
            {
                result.Status = 500;
                result.Message = err.Message;
                result.Data = null;
                result.Parameters = JsonConvert.SerializeObject(propertyRequest);
                result.Function = "PropertyController.PutPropiedad";
            }

            return result;
        }

        [HttpPut("PutPropiedadEstatus/{id}/{estatus}")]
        public ResultRequest PutPropiedadEstatus(int id, string estatus)
        {
            ResultRequest result = new ResultRequest();

            try
            {
                Property property = _context.Properties.Find(id);

                if (property != null)
                {
                    property.Status = estatus;

                    _context.Entry(property).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }

                result.Status = 201;
                result.Message = "";
                result.Data = 1;
                result.Parameters = $"id={id}, estatus={estatus}";
                result.Function = "PropertyController.PutPropiedad";
            }
            catch (Exception err)
            {
                result.Status = 500;
                result.Message = err.Message;
                result.Data = null;
                result.Parameters = $"id={id}, estatus={estatus}";
                result.Function = "PropertyController.PutPropiedad";
            }

            return result;
        }

        [HttpDelete("DeletePropiedad/{id}")]
        public ResultRequest DeletePropiedad(int id)
        {
            ResultRequest result = new ResultRequest();

            try
            {
                Property property = _context.Properties.Find(id);
                if (property != null)
                {
                    _context.Remove(property);
                    _context.SaveChanges();
                }

                result.Status = 201;
                result.Message = "";
                result.Data = 1;
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
