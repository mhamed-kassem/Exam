using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class ExamModel
    {
        public Assessment ExamInfo { get; set; }

        //Multiple-select  Multiple-choice
        public List<AssessmentOption> MultiselectQuestions { get; set; }
        //Fill in blanks  Long answer  Short answer
        public List<AssessmentText> TextQuestions { get; set; }

        public List<AssessmentTrueFalse> TrueFalseQuestions { get; set; }
        public List<AssessmentMatch> MatchQuestions { get; set; }

        


    }
}
