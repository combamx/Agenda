using Agenda.Models;
using Agenda.Models.Request;
using Agenda.Services;
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
        private readonly agendaContext _context;
        public ActivityController(agendaContext context)
        {
            _context = context;
        }

        [HttpGet("ListaActividad")]
        public ResultRequest ListaActividad()
        {
            ResultRequest result = new ResultRequest();

            try
            {
                ActivityService activityService = new ActivityService(_context);
                List<ActivityRequest> requestsActivity = activityService.GetListActividad();

                result.Status = 200;
                result.Message = "";
                result.Data = requestsActivity;
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

        [HttpGet("Actividad/{id}")]
        public ResultRequest Actividad(int id)
        {
            ResultRequest result = new ResultRequest();

            Activity item = new Activity();

            try
            {
                item = _context.Activities.Where(x => x.Id == id).First();
                
                ActivityRequest i = new ActivityRequest()
                {
                    Id = item.Id,
                    PropertyId = item.PropertyId,
                    DateActivity = String.Format("{0:yyyy-MM-dd}", item.DateActivity),
                    Schedule = item.Schedule,
                    Status = item.Status,
                    TimeBegin = item.TimeBegin.ToString(),
                    TimeEnd = item.TimeEnd.ToString(),
                    Title = item.Title
                };

                result.Status = 200;
                result.Message = "";
                result.Data = i;
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

        [HttpPost("PostActividad/{property_id}/{schedule}/{title}/{estatus}")]
        public ResultRequest PostActividad(int property_id, DateTime schedule, string title, string estatus)
        {
            ResultRequest result = new ResultRequest();
            
            string Msg = "";
            int status = 200;

            try
            {
                Property property = _context.Properties.FirstOrDefault(x => x.Id == property_id);

                if (property != null && property.Status == "Active")
                {
                    DateTime s1 = DateTime.Parse(schedule.ToString());

                    string d1 = s1.ToString("yyy-MM-dd");
                    string s = s1.ToString("HH:mm");

                    TimeSpan t1 = TimeSpan.Parse(s);
                    int hora = t1.Hours + 1;
                    int dia = t1.Days - 1;

                    TimeSpan t2 = new TimeSpan(hora, t1.Minutes, 0);

                    var rangoFecha = (from st in _context.Activities
                                      where st.DateActivity.ToString() == d1 &&
                                            (st.TimeBegin >= t1 && st.TimeEnd <= t2) &&
                                            st.PropertyId == property_id
                                      select st).Count();

                    if (rangoFecha == 0)
                    {
                        Activity activity = new Activity();

                        activity.Title = title.ToUpper();
                        activity.PropertyId = property_id;
                        activity.Schedule = schedule;
                        activity.Status = estatus;
                        activity.DateActivity = s1;
                        activity.TimeBegin = t1;
                        activity.TimeEnd = t2;

                        _context.Activities.AddAsync(activity);
                        _context.SaveChanges();

                        Msg = "La actividad se agrego correctamente";
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

                result.Status = status;
                result.Message = Msg;
                result.Data = 1;
                result.Parameters = $"property_id={property_id}, schedule={schedule}, title={title}";
                result.Function = "ActivityController.PostActividad";
            }
            catch (Exception err)
            {
                result.Status = 500;
                result.Message = err.Message;
                result.Data = null;
                result.Parameters = $"property_id={property_id}, schedule={schedule}, title={title}";
                result.Function = "ActivityController.PostActividad";
            }

            return result;
        }

        [HttpPost("PutActividad/{actividad_id}/{property_id}/{schedule}/{title}/{estatus}")]
        public ResultRequest PutActividad(int actividad_id, int property_id, DateTime schedule, string title, string estatus)
        {
            ResultRequest result = new ResultRequest();

            string Msg = "";
            int status = 200;

            try
            {
                Activity activity = _context.Activities.Find(actividad_id);

                Property property = _context.Properties.FirstOrDefault(x => x.Id == property_id);

                if (property != null && property.Status == "Active")
                {
                    DateTime s1 = DateTime.Parse(schedule.ToString());

                    string d1 = s1.ToString("yyyy-MM-dd");
                    string s = s1.ToString("HH:mm");

                    TimeSpan t1 = TimeSpan.Parse(s);
                    int hora = t1.Hours + 1;
                    int dia = t1.Days - 1;

                    TimeSpan t2 = new TimeSpan(hora, t1.Minutes, 0);
                    int rangoFecha = 0;

                    if (activity.TimeBegin != t1)
                    {
                         rangoFecha = (from st in _context.Activities
                                          where st.DateActivity.ToString() == d1 &&
                                                (st.TimeBegin >= t1 && st.TimeEnd <= t2) &&
                                                st.PropertyId == property_id
                                          select st).Count();
                    }

                    if (rangoFecha == 0)
                    {
                        activity.Title = title.ToUpper();
                        activity.PropertyId = property_id;
                        activity.Schedule = schedule;
                        activity.Status = estatus;
                        activity.DateActivity = s1;
                        activity.TimeBegin = t1;
                        activity.TimeEnd = t2;

                        _context.Entry(activity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        _context.SaveChanges();

                        Msg = "La actividad se actualizo correctamente";
                    }
                    else
                    {
                        Msg = "No se puede actualizar actividad en la misma fecha y hora";
                        status = 400;
                    }
                }
                else
                {
                    Msg = "No se puede actualizar la actividad si la propiedad esta desactivada";
                    status = 400;
                }

                result.Status = status;
                result.Message = Msg;
                result.Data = 1;
                result.Parameters = $"id={actividad_id}, property_id={property_id}, schedule={schedule}, title={title}";
                result.Function = "ActivityController.PutActividad";
            }
            catch (Exception err)
            {
                result.Status = 500;
                result.Message = err.Message;
                result.Data = null;
                result.Parameters = $"id={actividad_id}, property_id={property_id}, schedule={schedule}, title={title}";
                result.Function = "ActivityController.PutActividad";
            }

            return result;
        }

        [HttpPost("PutActividadEstatus/{id}/{estatus}")]
        public ResultRequest PutActividadEstatus(int actividad_id, string estatus)
        {
            ResultRequest result = new ResultRequest();

            string Msg = "";
            int status = 200;

            try
            {
                Activity activity = _context.Activities.Find(actividad_id);

                activity.Status = estatus;

                _context.Entry(activity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();

                Msg = "La actividad se actualizo correctamente";

                result.Status = status;
                result.Message = Msg;
                result.Data = 1;
                result.Parameters = $"id={actividad_id}, estatus={estatus}";
                result.Function = "ActivityController.PutActividadEstatus";
            }
            catch (Exception err)
            {
                result.Status = 500;
                result.Message = err.Message;
                result.Data = null;
                result.Parameters = $"id={actividad_id}, estatus={estatus}";
                result.Function = "ActivityController.PutActividadEstatus";
            }

            return result;
        }

        [HttpPost("DeleteActividad/{actividad_id}")]
        public ResultRequest DeleteActividad(int actividad_id)
        {
            ResultRequest result = new ResultRequest();
            List<Activity> lst = new List<Activity>();

            string Msg = "";
            int status = 200;

            try
            {
                Activity activity = _context.Activities.Find(actividad_id);

                _context.Remove(activity);
                _context.SaveChanges();

                Msg = "La actividad se elimino correctamente";

                result.Status = status;
                result.Message = Msg;
                result.Data = 1;
                result.Parameters = $"id={actividad_id}";
                result.Function = "ActivityController.DeleteActividad";
            }
            catch (Exception err)
            {
                result.Status = 500;
                result.Message = err.Message;
                result.Data = null;
                result.Parameters = $"ID = {actividad_id}";
                result.Function = "ActivityController.DeleteActividad";
            }

            return result;
        }

        [HttpPost("PutReagendarActividad/{actividad_id}/{schedule}")]
        public ResultRequest PutReagendarActividad(int actividad_id, DateTime schedule)
        {
            ResultRequest result = new ResultRequest();

            string Msg = "";
            int status = 200;

            try
            {
                Activity activity = _context.Activities.FirstOrDefault(x => x.Id == actividad_id);

                DateTime s1 = DateTime.Parse(schedule.ToString());

                string d1 = s1.ToString("yyy-MM-dd");
                string s = s1.ToString("HH:mm");

                TimeSpan t1 = TimeSpan.Parse(s);
                int hora = t1.Hours + 1;
                int dia = t1.Days - 1;

                TimeSpan t2 = new TimeSpan(hora, t1.Minutes, 0);

                var rangoFecha = (from st in _context.Activities
                                  where st.DateActivity.ToString() == d1 &&
                                        (st.TimeBegin >= t1 && st.TimeEnd <= t2) &&
                                        st.PropertyId == activity.PropertyId
                                  select st).Count();

                if (rangoFecha == 0)
                {
                    activity.Schedule = schedule;
                    activity.DateActivity = s1;
                    activity.TimeBegin = t1;
                    activity.TimeEnd = t2;

                    _context.Entry(activity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();

                    Msg = "La actividad se actualizo correctamente";
                }
                else
                {
                    Msg = "No se puede actualizar actividad en la misma fecha y hora";
                    status = 400;
                }

                result.Status = status;
                result.Message = Msg;
                result.Data = 1;
                result.Parameters = $"id={actividad_id}, schedule={schedule}";
                result.Function = "ActivityController.PutActividad";
            }
            catch (Exception err)
            {
                result.Status = 500;
                result.Message = err.Message;
                result.Data = null;
                result.Parameters = $"id={actividad_id}, schedule={schedule}";
                result.Function = "ActivityController.PutActividad";
            }

            return result;
        }

        [HttpPost("PutCancelarActividad/{actividad_id}")]
        public ResultRequest PutCancelarActividad(int actividad_id)
        {
            ResultRequest result = new ResultRequest();

            string Msg = "";
            int status = 200;

            try
            {
                Activity activity = _context.Activities.FirstOrDefault(x => x.Id == actividad_id);
                
                activity.Status = "Cancel";

                _context.Entry(activity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();

                Msg = "La actividad se cancelo correctamente";

                result.Status = status;
                result.Message = Msg;
                result.Data = 1;
                result.Parameters = $"id={actividad_id}";
                result.Function = "ActivityController.PutCancelarActividad";
            }
            catch (Exception err)
            {
                result.Status = 500;
                result.Message = err.Message;
                result.Data = null;
                result.Parameters = $"id={actividad_id}";
                result.Function = "ActivityController.PutCancelarActividad";
            }

            return result;
        }
    }
}
