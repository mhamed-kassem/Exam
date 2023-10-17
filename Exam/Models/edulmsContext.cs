using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Exam.Models
{
    public partial class edulmsContext : DbContext
    {
        public edulmsContext()
        {
        }

        public edulmsContext(DbContextOptions<edulmsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Assessment> Assessments { get; set; }
        public virtual DbSet<AssessmentAnswer> AssessmentAnswers { get; set; }
        public virtual DbSet<AssessmentDatum> AssessmentData { get; set; }
        public virtual DbSet<AssessmentDepartment> AssessmentDepartments { get; set; }
        public virtual DbSet<AssessmentEnrol> AssessmentEnrols { get; set; }
        public virtual DbSet<AssessmentMatch> AssessmentMatches { get; set; }
        public virtual DbSet<AssessmentMetum> AssessmentMeta { get; set; }
        public virtual DbSet<AssessmentOption> AssessmentOptions { get; set; }
        public virtual DbSet<AssessmentQuestion> AssessmentQuestions { get; set; }
        public virtual DbSet<AssessmentQuestionsRelation> AssessmentQuestionsRelations { get; set; }
        public virtual DbSet<AssessmentSection> AssessmentSections { get; set; }
        public virtual DbSet<AssessmentText> AssessmentTexts { get; set; }
        public virtual DbSet<AssessmentTrueFalse> AssessmentTrueFalses { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.; Database= edulms; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Arabic_CI_AS");

            modelBuilder.Entity<Assessment>(entity =>
            {
                entity.ToTable("assessments");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Duration)
                    .HasColumnName("duration")
                    .HasDefaultValueSql("('7')");

                entity.Property(e => e.Published)
                    .HasColumnName("published")
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.ShortDescription)
                    .HasColumnType("text")
                    .HasColumnName("short_description");

                entity.Property(e => e.Slug)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("slug");

                entity.Property(e => e.Thumbnail)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("thumbnail");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            });

            modelBuilder.Entity<AssessmentAnswer>(entity =>
            {
                entity.ToTable("assessment_answers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("answer");

                entity.Property(e => e.AssessmentId).HasColumnName("assessment_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.QuestionId).HasColumnName("question_id");

                entity.Property(e => e.Score)
                    .HasColumnName("score")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Assessment)
                    .WithMany(p => p.AssessmentAnswers)
                    .HasForeignKey(d => d.AssessmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_assessment_answers_assessments");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.AssessmentAnswers)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_assessment_answers_assessment_questions");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AssessmentAnswers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_assessment_answers_users");
            });

            modelBuilder.Entity<AssessmentDatum>(entity =>
            {
                entity.ToTable("assessment_data");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AssessmentId).HasColumnName("assessment_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Data)
                    .HasColumnType("text")
                    .HasColumnName("data");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Assessment)
                    .WithMany(p => p.AssessmentData)
                    .HasForeignKey(d => d.AssessmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_assessment_data_assessments");
            });

            modelBuilder.Entity<AssessmentDepartment>(entity =>
            {
                entity.ToTable("assessment_department");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AssessmentId).HasColumnName("assessment_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Assessment)
                    .WithMany(p => p.AssessmentDepartments)
                    .HasForeignKey(d => d.AssessmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_assessment_department_assessments");
            });

            modelBuilder.Entity<AssessmentEnrol>(entity =>
            {
                entity.ToTable("assessment_enrols");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AssessmentId).HasColumnName("assessment_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Result).HasColumnName("result");

                entity.Property(e => e.Score)
                    .HasColumnName("score")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Assessment)
                    .WithMany(p => p.AssessmentEnrols)
                    .HasForeignKey(d => d.AssessmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_assessment_enrols_assessments");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AssessmentEnrols)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_assessment_enrols_users");
            });

            modelBuilder.Entity<AssessmentMatch>(entity =>
            {
                entity.ToTable("assessment_match");

                entity.HasIndex(e => e.AnswerIdKey, "IX_assessment_match")
                    .IsUnique();

                entity.HasIndex(e => e.QuestionIdKey, "IX_assessment_match_1")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Answer)
                    .HasColumnType("text")
                    .HasColumnName("answer");

                entity.Property(e => e.AnswerIdKey)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("answer_id_key")
                    .IsFixedLength(true);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Option)
                    .HasColumnType("text")
                    .HasColumnName("option");

                entity.Property(e => e.Order)
                    .HasColumnName("order")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.QuestionId).HasColumnName("question_id");

                entity.Property(e => e.QuestionIdKey)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("question_id_key")
                    .IsFixedLength(true);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.AssessmentMatches)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_assessment_match_assessment_questions");
            });

            modelBuilder.Entity<AssessmentMetum>(entity =>
            {
                entity.ToTable("assessment_meta");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AssessmentId).HasColumnName("assessment_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Type)
                    .HasColumnType("text")
                    .HasColumnName("type");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.Value)
                    .HasColumnType("text")
                    .HasColumnName("value");

                entity.HasOne(d => d.Assessment)
                    .WithMany(p => p.AssessmentMeta)
                    .HasForeignKey(d => d.AssessmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_assessment_meta_assessments");
            });

            modelBuilder.Entity<AssessmentOption>(entity =>
            {
                entity.ToTable("assessment_options");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Correct)
                    .HasColumnName("correct")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Option)
                    .HasColumnType("text")
                    .HasColumnName("option");

                entity.Property(e => e.Order)
                    .HasColumnName("order")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.QuestionId).HasColumnName("question_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.AssessmentOptions)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_assessment_options_assessment_questions");
            });

            modelBuilder.Entity<AssessmentQuestion>(entity =>
            {
                entity.ToTable("assessment_questions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Order)
                    .HasColumnName("order")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Question)
                    .HasColumnType("text")
                    .HasColumnName("question");

                entity.Property(e => e.Type)
                    .HasColumnType("text")
                    .HasColumnName("type");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<AssessmentQuestionsRelation>(entity =>
            {
                entity.ToTable("assessment_questions_relation");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AssessmentId).HasColumnName("assessment_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.QuestionId).HasColumnName("question_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Assessment)
                    .WithMany(p => p.AssessmentQuestionsRelations)
                    .HasForeignKey(d => d.AssessmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_assessment_questions_relation_assessments");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.AssessmentQuestionsRelations)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_assessment_questions_relation_assessment_questions");
            });

            modelBuilder.Entity<AssessmentSection>(entity =>
            {
                entity.ToTable("assessment_sections");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AssessmentId).HasColumnName("assessment_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Order)
                    .HasColumnName("order")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Assessment)
                    .WithMany(p => p.AssessmentSections)
                    .HasForeignKey(d => d.AssessmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_assessment_sections_assessments");
            });

            modelBuilder.Entity<AssessmentText>(entity =>
            {
                entity.ToTable("assessment_text");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Answer)
                    .HasColumnType("text")
                    .HasColumnName("answer");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Order)
                    .HasColumnName("order")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.QuestionId).HasColumnName("question_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.AssessmentTexts)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_assessment_text_assessment_questions");
            });

            modelBuilder.Entity<AssessmentTrueFalse>(entity =>
            {
                entity.ToTable("assessment_true_false");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.IsTrue)
                    .HasColumnName("is_true")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.QuestionId).HasColumnName("question_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.AssessmentTrueFalses)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_assessment_true_false_assessment_questions");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApiKey)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("api_key")
                    .IsFixedLength(true);

                entity.Property(e => e.ConfirmCode)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("confirm_code")
                    .IsFixedLength(true);

                entity.Property(e => e.ConfirmedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("confirmed_at");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("display_name");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.IsBanned)
                    .HasColumnName("is_banned")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsLdap)
                    .HasColumnName("is_ldap")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsVerified)
                    .HasColumnName("is_verified")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.Otp)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("otp");

                entity.Property(e => e.OtpCreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("otp_created_at");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.PasswordChangedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("password_changed_at");

                entity.Property(e => e.ProfilePictureId).HasColumnName("profile_picture_id");

                entity.Property(e => e.RememberToken)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("remember_token");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UserUrl)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("user_url");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
