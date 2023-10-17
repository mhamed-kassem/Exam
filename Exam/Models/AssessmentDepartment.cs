using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Exam.Models
{
    public partial class AssessmentDepartment
    {
        public long Id { get; set; }
        public long GroupId { get; set; }
        public long AssessmentId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey("AssessmentId")]
        public virtual Assessment Assessment { get; set; }
    }
}
