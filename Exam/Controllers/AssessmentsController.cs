using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Exam.Models;

namespace Exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssessmentsController : ControllerBase
    {
        private readonly edulmsContext _context;

        public AssessmentsController(edulmsContext context)
        {
            _context = context;
        }


        // GET://GetAsessmentAnswers
        [Route("GetAsessmentAnswers")]
        [HttpGet]
        public ActionResult<ExamModel> GetAsessmentAnswers()
        {
            //write bussiness logic here
            // Exam For Level 1 Contain All Question Types
            var Model = new ExamModel();
            Model.ExamInfo = _context.Assessments.IgnoreAutoIncludes().OrderByDescending(x=>x.CreatedAt).FirstOrDefault();
            var ExamQuestionsIds = _context.AssessmentQuestionsRelations.Where(r => r.AssessmentId == Model.ExamInfo.Id).ToList();
            //1 type
            var MatchQuestionsIds = _context.AssessmentQuestions.IgnoreAutoIncludes().Where(x => x.Level == 1 && x.Type == "match" && ExamQuestionsIds.Any(r => r.QuestionId == x.Id)).ToList();
            Model.MatchQuestions = _context.AssessmentMatches.Where(q => MatchQuestionsIds.Any(i => i.Id == q.QuestionId)).ToList();
            //3 types
            var TextQuestionsIds = _context.AssessmentQuestions.IgnoreAutoIncludes().Where(x => x.Level == 1 && x.Type == "text" && ExamQuestionsIds.Any(r => r.QuestionId == x.Id)).ToList();
            Model.TextQuestions= _context.AssessmentTexts.Where(q => TextQuestionsIds.Any(i => i.Id == q.QuestionId)).ToList();
            //1 type
            var TrueFalsQuestionIds = _context.AssessmentQuestions.IgnoreAutoIncludes().Where(x => x.Level == 1 && x.Type == "true_false" && ExamQuestionsIds.Any(r => r.QuestionId == x.Id)).ToList();
            Model.TextQuestions = _context.AssessmentTexts.Where(q => TrueFalsQuestionIds.Any(i => i.Id == q.QuestionId)).ToList();

            var MultiOptionQuestionIds = _context.AssessmentQuestions.IgnoreAutoIncludes().Where(x => x.Level == 1 && x.Type == "Option" && ExamQuestionsIds.Any(r => r.QuestionId == x.Id)).ToList();
            Model.MultiselectQuestions = _context.AssessmentOptions.Where(q => MultiOptionQuestionIds.Any(i => i.Id == q.QuestionId)).ToList();

            return Model;

        }


    }
}
