using Agenda.Models;
using Agenda.Models.Request;
using Microsoft.AspNetCore.Http;
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
    public class ActivityController : ControllerBase
    {
        [HttpGet("ListaActividad")]
        public ResultRequest ListaActividad()
        {
            ResultRequest result = new ResultRequest();

            List<Activity> lst = new List<Activity>();

            try
            {
                using (agendaContext db = new agendaContext())
                {
                    lst = db.Activities.ToList();
                }

                result.Status = 200;
                result.Message = "";
                result.Data = lst;
                result.Parameters = "";
                result.Function = "ActivityController.ListaActividad";
            }
            catch (Exception err)
            {
                result.Status = 500;
                result.Message = err.Message;
                result.Data = null;
                result.Parameters = "";
                result.Function = "ActivityController.ListaActividad";
            }

            return result;
        }

        [HttpPost("PostActividad")]
        public ResultRequest PostActividad([FromQuery] ActivityRequest activityRequest)
        {
            ResultRequest result = new ResultRequest();
            List<Activity> lst = new List<Activity>();

            try
            {
                using (agendaContext db = new agendaContext())
                {
                    Activity activity = new Activity();

                    activity.Title = activityRequest.Title;
                    activity.PropertyId = activityRequest.PropertyId;
                    activity.Schedule = activityRequest.Schedule;
                    activity.Status = activityRequest.Status;

                    db.Activities.AddAsync(activity);
                    db.SaveChanges();

                    lst = db.Activities.OrderByDescending(x => x.Id).ToList();
                }

                result.Status = 201;
                result.Message = "";
                result.Data = lst;
                result.Parameters = JsonConvert.SerializeObject(activityRequest); ;
                result.Function = "ActivityController.PostActividad";
            }
            catch (Exception err)
            {
                result.Status = 500;
                result.Message = err.Message;
                result.Data = null;
                result.Parameters = JsonConvert.SerializeObject(activityRequest); ;
                result.Function = "ActivityController.PostActividad";
            }

            return result;
        }

        [HttpPut("PutActividad")]
        public ResultRequest PutActividad([FromQuery] ActivityRequest activityRequest)
        {
            ResultRequest result = new ResultRequest();
            List<Activity> lst = new List<Activity>();

            try
            {
                using (agendaContext db = new agendaContext())
                {
                    Activity activity = db.Activities.Find(activityRequest.Id);

                    if(activity != null)
                    {
                        activity.Title = activityRequest.Title;
                        activity.PropertyId = activityRequest.PropertyId;
                        activity.Schedule = activityRequest.Schedule;
                        activity.Status = activityRequest.Status;

                        db.Entry(activity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        db.SaveChanges();
                    }

                    lst = db.Activities.OrderByDescending(x => x.Id).ToList();
                }

                result.Status = 201;
                result.Message = "";
                result.Data = lst;
                result.Parameters = JsonConvert.SerializeObject(activityRequest);
                result.Function = "ActivityController.PutActividad";
            }
            catch (Exception err)
            {
                result.Status = 500;
                result.Message = err.Message;
                result.Data = null;
                result.Parameters = JsonConvert.SerializeObject(activityRequest); ;
                result.Function = "ActivityController.PutActividad";
            }

            return result;
        }

        [HttpDelete("DeleteActividad/{id}")]
        public ResultRequest DeleteActividad(int id)
        {
            ResultRequest result = new ResultRequest();
            List<Activity> lst = new List<Activity>();

            try
            {
                using (agendaContext db = new agendaContext())
                {
                    Activity activity = db.Activities.Find(id);

                    if(activity != null)
                    {
                        db.Remove(activity);
                        db.SaveChanges();
                    }
                    

                    lst = db.Activities.OrderByDescending(x => x.Id).ToList();
                }

                result.Status = 201;
                result.Message = "";
                result.Data = lst;
                result.Parameters = $"ID = {id}";
                result.Function = "ActivityController.DeleteActividad";
            }
            catch (Exception err)
            {
                result.Status = 500;
                result.Message = err.Message;
                result.Data = null;
                result.Parameters = $"ID = {id}";
                result.Function = "ActivityController.DeleteActividad";
            }

            return result;
        }
    }
}
