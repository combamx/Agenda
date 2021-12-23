using Agenda.Models;
using Agenda.Models.Request;
using Agenda.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Services
{
    public class ActivityService : IActivityService
    {
        private readonly agendaContext _context;

        public ActivityService(agendaContext context) => _context = context;

        public List<ActivityRequest> GetListActividad()
        {
            List<Activity> lst = new List<Activity>();

            try
            {
                lst = _context.Activities.OrderByDescending(x => x.Id).ToList();
                List<ActivityRequest> requestsActivity = new List<ActivityRequest>();

                foreach (var item in lst)
                {
                    ActivityRequest i = new ActivityRequest()
                    {
                        Id = item.Id,
                        PropertyId = item.PropertyId,
                        DateActivity = String.Format("{0:dd/MM/yyyy}", item.DateActivity),
                        Schedule = item.Schedule,
                        Status = item.Status,
                        TimeBegin = item.TimeBegin.ToString(),
                        TimeEnd = item.TimeEnd.ToString(),
                        Title = item.Title,
                        Survey = _context.Surveys.Count(x => x.ActivityId == item.Id)
                    };

                    requestsActivity.Add(i);
                }

                return requestsActivity;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public int PostActividad(int property_id, DateTime schedule, string title)
        {
            throw new NotImplementedException();
        }

        public int PutActividad(ActivityRequest activityRequest)
        {
            throw new NotImplementedException();
        }

        public int PutActividadEstatus(int id, string estatus)
        {
            throw new NotImplementedException();
        }
        public int DeleteActividad(int id)
        {
            throw new NotImplementedException();
        }

        public ActivityRequest GetActividad(int id)
        {
            throw new NotImplementedException();
        }
    }
}
