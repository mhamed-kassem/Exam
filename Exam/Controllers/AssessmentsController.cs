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

        // GET: api/GetAsessmentAnswers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assessment>>> GetAsessmentAnswers()
        {
            //write bussiness logic here
            return await _context.Assessments.ToListAsync();
        }

       
    }
}
