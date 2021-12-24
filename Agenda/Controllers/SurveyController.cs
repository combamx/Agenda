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
        private readonly agendaContext _context;

        public SurveyController(agendaContext context)
        {
            _context = context;
        }

        [HttpGet("ListaEncuesta")]
        public ResultRequest ListaEncuesta()
        {
            ResultRequest result = new ResultRequest();

            List<Survey> lst = new List<Survey>();

            try
            {
                lst = _context.Surveys.ToList();

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

            try
            {
                Survey survey = new Survey();

                survey.ActivityId = surveyRequest.ActivityId;
                survey.Answers = surveyRequest.Answers.ToUpper();

                _context.Surveys.AddAsync(survey);
                _context.SaveChanges();

                result.Status = 201;
                result.Message = "";
                result.Data = 1;
                result.Parameters = JsonConvert.SerializeObject(surveyRequest);
                result.Function = "SurveyController.PostEncuesta";
            }
            catch (Exception err)
            {
                result.Status = 500;
                result.Message = err.Message;
                result.Data = null;
                result.Parameters = JsonConvert.SerializeObject(surveyRequest);
                result.Function = "SurveyController.PostEncuesta";
            }

            return result;
        }

        [HttpPut("PutEncuesta")]
        public ResultRequest PutEncuesta([FromQuery] SurveyRequest surveyRequest)
        {
            ResultRequest result = new ResultRequest();

            try
            {
                Survey survey = _context.Surveys.Find(surveyRequest.Id);

                if (survey != null)
                {
                    survey.ActivityId = surveyRequest.ActivityId;
                    survey.Answers = surveyRequest.Answers.ToUpper();

                    _context.Entry(survey).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }

                result.Status = 201;
                result.Message = "";
                result.Data = 1;
                result.Parameters = JsonConvert.SerializeObject(surveyRequest);
                result.Function = "SurveyController.PutEncuesta";
            }
            catch (Exception err)
            {
                result.Status = 500;
                result.Message = err.Message;
                result.Data = null;
                result.Parameters = JsonConvert.SerializeObject(surveyRequest);
                result.Function = "SurveyController.PutEncuesta";
            }

            return result;
        }

        [HttpDelete("DeleteEncuesta/{id}")]
        public ResultRequest DeleteEncuesta(int id)
        {
            ResultRequest result = new ResultRequest();

            try
            {
                Survey survey = _context.Surveys.Find(id);

                if (survey != null)
                {
                    _context.Remove(survey);
                    _context.SaveChanges();
                }

                result.Status = 201;
                result.Message = "";
                result.Data = 1;
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

        [HttpGet("ListaEncuestaActivity/{activity_id}")]
        public ResultRequest ListaEncuestaActivity(int activity_id)
        {
            ResultRequest result = new ResultRequest();
            List<Survey> lst = new List<Survey>();

            try
            {
                lst = _context.Surveys.Where(x => x.ActivityId == activity_id).ToList();

                result.Status = 200;
                result.Message = "";
                result.Data = lst;
                result.Parameters = "";
                result.Function = "SurveyController.ListaEncuestaActivity";
            }
            catch (Exception err)
            {
                result.Status = 500;
                result.Message = err.Message;
                result.Data = null;
                result.Parameters = "";
                result.Function = "SurveyController.ListaEncuestaActivity";
            }

            return result;
        }
    }
}
