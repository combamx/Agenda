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
            
            string Msg = "";
            int status = 200;

            try
            {
                using (agendaContext db = new agendaContext())
                {
                    Property property = db.Properties.FirstOrDefault(x => x.Id == activityRequest.PropertyId);

                    if(property != null && property.Status == "Active")
                    {
                        DateTime s1 = DateTime.Parse(activityRequest.Schedule.ToString());

                        string d1 = s1.ToString("yyy-MM-dd");
                        string s = s1.ToString("H:mm");

                        TimeSpan t1 = TimeSpan.Parse(s);
                        TimeSpan t2 = t1 + TimeSpan.FromHours(1);

                        var rangoFecha = (from st in db.Activities
                                          where st.DateActivity.ToString() == d1 && 
                                                (st.TimeBegin >= t1 && st.TimeEnd <= t2) &&
                                                st.PropertyId == activityRequest.PropertyId
                                          select st).Count();

                        if(rangoFecha == 0)
                        {
                            Activity activity = new Activity();

                            activity.Title = activityRequest.Title.ToUpper();
                            activity.PropertyId = activityRequest.PropertyId;
                            activity.Schedule = activityRequest.Schedule;
                            activity.Status = activityRequest.Status;
                            activity.DateActivity = s1;
                            activity.TimeBegin = t1;
                            activity.TimeEnd = t2;

                            db.Activities.AddAsync(activity);
                            db.SaveChanges();
                        }
                        else
                        {
                            Msg = "No se puede crear actividad en la misma fecha y hora";
                            status = 400;
                        }
                    }
                    else
                    {
                        Msg = "No se puede crear la actividad si la propiedad esta desactivada";
                        status = 400;
                    }
                }

                result.Status = status;
                result.Message = Msg;
                result.Data = 1;
                result.Parameters = JsonConvert.SerializeObject(activityRequest);
                result.Function = "ActivityController.PostActividad";
            }
            catch (Exception err)
            {
                result.Status = 500;
                result.Message = err.Message;
                result.Data = null;
                result.Parameters = JsonConvert.SerializeObject(activityRequest);
                result.Function = "ActivityController.PostActividad";
            }

            return result;
        }

        [HttpPut("PutActividad")]
        public ResultRequest PutActividad([FromQuery] ActivityRequest activityRequest)
        {
            ResultRequest result = new ResultRequest();

            string Msg = "";
            int status = 200;

            try
            {
                using (agendaContext db = new agendaContext())
                {
                    Property property = db.Properties.FirstOrDefault(x => x.Id == activityRequest.PropertyId);

                    if (property != null && property.Status == "Active")
                    {
                        DateTime s1 = DateTime.Parse(activityRequest.Schedule.ToString());

                        string d1 = s1.ToString("yyy-MM-dd");
                        string s = s1.ToString("H:mm");

                        TimeSpan t1 = TimeSpan.Parse(s);
                        TimeSpan t2 = t1 + TimeSpan.FromHours(1);

                        var rangoFecha = (from st in db.Activities
                                          where st.DateActivity.ToString() == d1 &&
                                                (st.TimeBegin >= t1 && st.TimeEnd <= t2) &&
                                                st.PropertyId == activityRequest.PropertyId
                                          select st).Count();

                        if (rangoFecha == 0)
                        {
                            Activity activity = db.Activities.Find(activityRequest.Id);

                            if (activity != null)
                            {
                                activity.Title = activityRequest.Title.ToUpper();
                                activity.PropertyId = activityRequest.PropertyId;
                                activity.Schedule = activityRequest.Schedule;
                                activity.Status = activityRequest.Status;
                                activity.DateActivity = s1;
                                activity.TimeBegin = t1;
                                activity.TimeEnd = t2;

                                db.Entry(activity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                                db.SaveChanges();
                            }
                        }
                        else
                        {
                            Msg = "No se puede crear actividad en la misma fecha y hora";
                            status = 400;
                        }
                    }
                    else
                    {
                        Msg = "No se puede crear la actividad si la propiedad esta desactivada";
                        status = 400;
                    }
                }

                result.Status = status;
                result.Message = Msg;
                result.Data = 1;
                result.Parameters = JsonConvert.SerializeObject(activityRequest);
                result.Function = "ActivityController.PutActividad";
            }
            catch (Exception err)
            {
                result.Status = 500;
                result.Message = err.Message;
                result.Data = null;
                result.Parameters = JsonConvert.SerializeObject(activityRequest);
                result.Function = "ActivityController.PutActividad";
            }

            return result;
        }

        [HttpPut("PutActividadEstatus/{id}/{estatus}")]
        public ResultRequest PutActividadEstatus(int id, string estatus)
        {
            ResultRequest result = new ResultRequest();

            try
            {
                using (agendaContext db = new agendaContext())
                {
                    Activity activity = db.Activities.Find(id);

                    if (activity != null)
                    {
                        activity.Status = estatus;

                        db.Entry(activity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        db.SaveChanges();
                    }
                }

                result.Status = 201;
                result.Message = "";
                result.Data = 1;
                result.Parameters = $"id={id}, estatus={estatus}";
                result.Function = "ActivityController.PutActividad";
            }
            catch (Exception err)
            {
                result.Status = 500;
                result.Message = err.Message;
                result.Data = null;
                result.Parameters = $"id={id}, estatus={estatus}";
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
                }

                result.Status = 201;
                result.Message = "";
                result.Data = 1;
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
