using System;
using System.Collections.Generic;

#nullable disable

namespace Exam.Models
{
    public partial class Assessment
    {
        public Assessment()
        {
            //AssessmentAnswers = new HashSet<AssessmentAnswer>();
            //AssessmentData = new HashSet<AssessmentDatum>();
            //AssessmentDepartments = new HashSet<AssessmentDepartment>();
            //AssessmentEnrols = new HashSet<AssessmentEnrol>();
            //AssessmentMeta = new HashSet<AssessmentMetum>();
            //AssessmentQuestionsRelations = new HashSet<AssessmentQuestionsRelation>();
            //AssessmentSections = new HashSet<AssessmentSection>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public int Duration { get; set; }
        public long? CategoryId { get; set; }
        public string Thumbnail { get; set; }
        public byte Published { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        //public virtual ICollection<AssessmentAnswer> AssessmentAnswers { get; set; }
        //public virtual ICollection<AssessmentDatum> AssessmentData { get; set; }
        //public virtual ICollection<AssessmentDepartment> AssessmentDepartments { get; set; }
        //public virtual ICollection<AssessmentEnrol> AssessmentEnrols { get; set; }
        //public virtual ICollection<AssessmentMetum> AssessmentMeta { get; set; }
        //public virtual ICollection<AssessmentQuestionsRelation> AssessmentQuestionsRelations { get; set; }
        //public virtual ICollection<AssessmentSection> AssessmentSections { get; set; }
    }
}
