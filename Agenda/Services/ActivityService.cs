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
        private readonly IConfiguration _configuracion;
        private readonly string CnnString;

        public ActivityService(IConfiguration configuracion)
        {
            _configuracion = configuracion;
        }

        public List<Activity> GetListActividad()
        {
            throw new NotImplementedException();
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
    }
}
