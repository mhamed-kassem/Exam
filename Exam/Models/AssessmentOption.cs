using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Exam.Models
{
    public partial class AssessmentOption
    {
        public long Id { get; set; }
        public string Option { get; set; }
        public long QuestionId { get; set; }
        public byte Correct { get; set; }
        public int Order { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey("QuestionId")]
        public virtual AssessmentQuestion Question { get; set; }
    }
}
