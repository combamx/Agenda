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
    public class SurveyController : ControllerBase
    {
        [HttpGet("ListaEncuesta")]
        public ResultRequest ListaEncuesta()
        {
            ResultRequest result = new ResultRequest();

            List<Survey> lst = new List<Survey>();

            try
            {
                using (agendaContext db = new agendaContext())
                {
                    lst = db.Surveys.ToList();
                }

                result.Status = 200;
                result.Message = "";
                result.Data = lst;
                result.Parameters = "";
                result.Function = "SurveyController.ListaEncuesta";
            }
            catch (Exception err)
            {
                result.Status = 500;
                result.Message = err.Message;
                result.Data = null;
                result.Parameters = "";
                result.Function = "SurveyController.ListaEncuesta";
            }

            return result;
        }

        [HttpPost("PostEncuesta")]
        public ResultRequest PostEncuesta([FromQuery] SurveyRequest surveyRequest)
        {
            ResultRequest result = new ResultRequest();
            List<Survey> lst = new List<Survey>();

            try
            {
                using (agendaContext db = new agendaContext())
                {
                    Survey survey = new Survey();
                   
                    survey.ActivityId = surveyRequest.ActivityId;
                    survey.Answers = surveyRequest.Answers;

                    db.Surveys.AddAsync(survey);
                    db.SaveChanges();

                    lst = db.Surveys.OrderByDescending(x => x.Id).ToList();
                }

                result.Status = 201;
                result.Message = "";
                result.Data = lst;
                result.Parameters = JsonConvert.SerializeObject(surveyRequest); ;
                result.Function = "SurveyController.PostEncuesta";
            }
            catch (Exception err)
            {
                result.Status = 500;
                result.Message = err.Message;
                result.Data = null;
                result.Parameters = JsonConvert.SerializeObject(surveyRequest); ;
                result.Function = "SurveyController.PostEncuesta";
            }

            return result;
        }

        [HttpPut("PutEncuesta")]
        public ResultRequest PutEncuesta([FromQuery] SurveyRequest surveyRequest)
        {
            ResultRequest result = new ResultRequest();
            List<Survey> lst = new List<Survey>();

            try
            {
                using (agendaContext db = new agendaContext())
                {
                    Survey survey = db.Surveys.Find(surveyRequest.Id);

                    if (survey != null)
                    {
                        survey.ActivityId = surveyRequest.ActivityId;
                        survey.Answers = surveyRequest.Answers;

                        db.Entry(survey).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        db.SaveChanges();
                    }

                    lst = db.Surveys.OrderByDescending(x => x.Id).ToList();
                }

                result.Status = 201;
                result.Message = "";
                result.Data = lst;
                result.Parameters = JsonConvert.SerializeObject(surveyRequest);
                result.Function = "SurveyController.PutEncuesta";
            }
            catch (Exception err)
            {
                result.Status = 500;
                result.Message = err.Message;
                result.Data = null;
                result.Parameters = JsonConvert.SerializeObject(surveyRequest); ;
                result.Function = "SurveyController.PutEncuesta";
            }

            return result;
        }

        [HttpDelete("DeleteEncuesta/{id}")]
        public ResultRequest DeleteEncuesta(int id)
        {
            ResultRequest result = new ResultRequest();
            List<Survey> lst = new List<Survey>();

            try
            {
                using (agendaContext db = new agendaContext())
                {
                    Survey survey = db.Surveys.Find(id);
                    
                    if (survey != null)
                    {
                        db.Remove(survey);
                        db.SaveChanges();
                    }

                    lst = db.Surveys.OrderByDescending(x => x.Id).ToList();
                }

                result.Status = 201;
                result.Message = "";
                result.Data = lst;
                result.Parameters = $"ID = {id}";
                result.Function = "SurveyController.DeleteEncuesta";
            }
            catch (Exception err)
            {
                result.Status = 500;
                result.Message = err.Message;
                result.Data = null;
                result.Parameters = $"ID = {id}";
                result.Function = "SurveyController.DeleteEncuesta";
            }

            return result;
        }
    }
}
