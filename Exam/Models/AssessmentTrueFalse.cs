using System;
using System.Collections.Generic;

#nullable disable

namespace Exam.Models
{
    public partial class AssessmentTrueFalse
    {
        public long Id { get; set; }
        public long QuestionId { get; set; }
        public int IsTrue { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual AssessmentQuestion Question { get; set; }
    }
}
