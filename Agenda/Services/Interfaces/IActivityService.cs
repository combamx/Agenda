using Agenda.Models;
using Agenda.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Services.Interfaces
{
    public interface IActivityService
    {
        List<ActivityRequest> GetListActividad();

        ActivityRequest GetActividad(int id);

        int PostActividad(int property_id, DateTime schedule, string title);

        int PutActividad(ActivityRequest activityRequest);

        int PutActividadEstatus(int id, string estatus);

        int DeleteActividad(int id);
    }
}
