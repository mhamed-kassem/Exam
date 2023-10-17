using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Exam.Models
{
    public partial class AssessmentSection
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long AssessmentId { get; set; }
        public int Order { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey("AssessmentId")]
        public virtual Assessment Assessment { get; set; }
    }
}
