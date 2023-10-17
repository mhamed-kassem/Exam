﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Exam.Models
{
    public partial class AssessmentMatch
    {
        public long Id { get; set; }
        public string AnswerIdKey { get; set; }
        public string QuestionIdKey { get; set; }
        public string Option { get; set; }
        public string Answer { get; set; }
        public long QuestionId { get; set; }
        public int Order { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey("QuestionId")]
        public virtual AssessmentQuestion Question { get; set; }
    }
}
