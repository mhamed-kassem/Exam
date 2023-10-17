using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Exam.Models
{
    public partial class AssessmentDatum
    {
        public long Id { get; set; }
        public long AssessmentId { get; set; }
        public string Data { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey("AssessmentId")]
        public virtual Assessment Assessment { get; set; }
    }
}
