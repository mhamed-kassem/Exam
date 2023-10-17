using System;
using System.Collections.Generic;

#nullable disable

namespace Exam.Models
{
    public partial class AssessmentQuestion
    {
        public AssessmentQuestion()
        {
            AssessmentAnswers = new HashSet<AssessmentAnswer>();
            AssessmentMatches = new HashSet<AssessmentMatch>();
            AssessmentOptions = new HashSet<AssessmentOption>();
            AssessmentQuestionsRelations = new HashSet<AssessmentQuestionsRelation>();
            AssessmentTexts = new HashSet<AssessmentText>();
            AssessmentTrueFalses = new HashSet<AssessmentTrueFalse>();
        }

        public long Id { get; set; }
        public string Question { get; set; }
        public long CategoryId { get; set; }
        public int Level { get; set; }
        public int Order { get; set; }
        public string Type { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<AssessmentAnswer> AssessmentAnswers { get; set; }
        public virtual ICollection<AssessmentMatch> AssessmentMatches { get; set; }
        public virtual ICollection<AssessmentOption> AssessmentOptions { get; set; }
        public virtual ICollection<AssessmentQuestionsRelation> AssessmentQuestionsRelations { get; set; }
        public virtual ICollection<AssessmentText> AssessmentTexts { get; set; }
        public virtual ICollection<AssessmentTrueFalse> AssessmentTrueFalses { get; set; }
    }
}
