using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Exam.Models
{
    public partial class AssessmentEnrol
    {
        public long Id { get; set; }
        public long AssessmentId { get; set; }
        public long UserId { get; set; }
        public int? Result { get; set; }
        public byte Score { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey("AssessmentId")]
        public virtual Assessment Assessment { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
