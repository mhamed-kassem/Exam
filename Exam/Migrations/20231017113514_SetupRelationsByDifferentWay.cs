using Microsoft.EntityFrameworkCore.Migrations;

namespace Exam.Migrations
{
    public partial class SetupRelationsByDifferentWay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assessment_answers_assessment_questions",
                table: "assessment_answers");

            migrationBuilder.DropForeignKey(
                name: "FK_assessment_answers_assessments",
                table: "assessment_answers");

            migrationBuilder.DropForeignKey(
                name: "FK_assessment_answers_users",
                table: "assessment_answers");

            migrationBuilder.DropForeignKey(
                name: "FK_assessment_data_assessments",
                table: "assessment_data");

            migrationBuilder.DropForeignKey(
                name: "FK_assessment_department_assessments",
                table: "assessment_department");

            migrationBuilder.DropForeignKey(
                name: "FK_assessment_enrols_assessments",
                table: "assessment_enrols");

            migrationBuilder.DropForeignKey(
                name: "FK_assessment_enrols_users",
                table: "assessment_enrols");

            migrationBuilder.DropForeignKey(
                name: "FK_assessment_match_assessment_questions",
                table: "assessment_match");

            migrationBuilder.DropForeignKey(
                name: "FK_assessment_meta_assessments",
                table: "assessment_meta");

            migrationBuilder.DropForeignKey(
                name: "FK_assessment_options_assessment_questions",
                table: "assessment_options");

            migrationBuilder.DropForeignKey(
                name: "FK_assessment_questions_relation_assessment_questions",
                table: "assessment_questions_relation");

            migrationBuilder.DropForeignKey(
                name: "FK_assessment_questions_relation_assessments",
                table: "assessment_questions_relation");

            migrationBuilder.DropForeignKey(
                name: "FK_assessment_sections_assessments",
                table: "assessment_sections");

            migrationBuilder.DropForeignKey(
                name: "FK_assessment_text_assessment_questions",
                table: "assessment_text");

            migrationBuilder.DropForeignKey(
                name: "FK_assessment_true_false_assessment_questions",
                table: "assessment_true_false");

            migrationBuilder.AddForeignKey(
                name: "FK_assessment_answers_assessment_questions_question_id",
                table: "assessment_answers",
                column: "question_id",
                principalTable: "assessment_questions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_assessment_answers_assessments_assessment_id",
                table: "assessment_answers",
                column: "assessment_id",
                principalTable: "assessments",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_assessment_answers_users_user_id",
                table: "assessment_answers",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_assessment_data_assessments_assessment_id",
                table: "assessment_data",
                column: "assessment_id",
                principalTable: "assessments",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_assessment_department_assessments_assessment_id",
                table: "assessment_department",
                column: "assessment_id",
                principalTable: "assessments",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_assessment_enrols_assessments_assessment_id",
                table: "assessment_enrols",
                column: "assessment_id",
                principalTable: "assessments",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_assessment_enrols_users_user_id",
                table: "assessment_enrols",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_assessment_match_assessment_questions_question_id",
                table: "assessment_match",
                column: "question_id",
                principalTable: "assessment_questions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_assessment_meta_assessments_assessment_id",
                table: "assessment_meta",
                column: "assessment_id",
                principalTable: "assessments",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_assessment_options_assessment_questions_question_id",
                table: "assessment_options",
                column: "question_id",
                principalTable: "assessment_questions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_assessment_questions_relation_assessment_questions_question_id",
                table: "assessment_questions_relation",
                column: "question_id",
                principalTable: "assessment_questions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_assessment_questions_relation_assessments_assessment_id",
                table: "assessment_questions_relation",
                column: "assessment_id",
                principalTable: "assessments",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_assessment_sections_assessments_assessment_id",
                table: "assessment_sections",
                column: "assessment_id",
                principalTable: "assessments",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_assessment_text_assessment_questions_question_id",
                table: "assessment_text",
                column: "question_id",
                principalTable: "assessment_questions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_assessment_true_false_assessment_questions_question_id",
                table: "assessment_true_false",
                column: "question_id",
                principalTable: "assessment_questions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assessment_answers_assessment_questions_question_id",
                table: "assessment_answers");

            migrationBuilder.DropForeignKey(
                name: "FK_assessment_answers_assessments_assessment_id",
                table: "assessment_answers");

            migrationBuilder.DropForeignKey(
                name: "FK_assessment_answers_users_user_id",
                table: "assessment_answers");

            migrationBuilder.DropForeignKey(
                name: "FK_assessment_data_assessments_assessment_id",
                table: "assessment_data");

            migrationBuilder.DropForeignKey(
                name: "FK_assessment_department_assessments_assessment_id",
                table: "assessment_department");

            migrationBuilder.DropForeignKey(
                name: "FK_assessment_enrols_assessments_assessment_id",
                table: "assessment_enrols");

            migrationBuilder.DropForeignKey(
                name: "FK_assessment_enrols_users_user_id",
                table: "assessment_enrols");

            migrationBuilder.DropForeignKey(
                name: "FK_assessment_match_assessment_questions_question_id",
                table: "assessment_match");

            migrationBuilder.DropForeignKey(
                name: "FK_assessment_meta_assessments_assessment_id",
                table: "assessment_meta");

            migrationBuilder.DropForeignKey(
                name: "FK_assessment_options_assessment_questions_question_id",
                table: "assessment_options");

            migrationBuilder.DropForeignKey(
                name: "FK_assessment_questions_relation_assessment_questions_question_id",
                table: "assessment_questions_relation");

            migrationBuilder.DropForeignKey(
                name: "FK_assessment_questions_relation_assessments_assessment_id",
                table: "assessment_questions_relation");

            migrationBuilder.DropForeignKey(
                name: "FK_assessment_sections_assessments_assessment_id",
                table: "assessment_sections");

            migrationBuilder.DropForeignKey(
                name: "FK_assessment_text_assessment_questions_question_id",
                table: "assessment_text");

            migrationBuilder.DropForeignKey(
                name: "FK_assessment_true_false_assessment_questions_question_id",
                table: "assessment_true_false");

            migrationBuilder.AddForeignKey(
                name: "FK_assessment_answers_assessment_questions",
                table: "assessment_answers",
                column: "question_id",
                principalTable: "assessment_questions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_assessment_answers_assessments",
                table: "assessment_answers",
                column: "assessment_id",
                principalTable: "assessments",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_assessment_answers_users",
                table: "assessment_answers",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_assessment_data_assessments",
                table: "assessment_data",
                column: "assessment_id",
                principalTable: "assessments",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_assessment_department_assessments",
                table: "assessment_department",
                column: "assessment_id",
                principalTable: "assessments",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_assessment_enrols_assessments",
                table: "assessment_enrols",
                column: "assessment_id",
                principalTable: "assessments",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_assessment_enrols_users",
                table: "assessment_enrols",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_assessment_match_assessment_questions",
                table: "assessment_match",
                column: "question_id",
                principalTable: "assessment_questions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_assessment_meta_assessments",
                table: "assessment_meta",
                column: "assessment_id",
                principalTable: "assessments",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_assessment_options_assessment_questions",
                table: "assessment_options",
                column: "question_id",
                principalTable: "assessment_questions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_assessment_questions_relation_assessment_questions",
                table: "assessment_questions_relation",
                column: "question_id",
                principalTable: "assessment_questions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_assessment_questions_relation_assessments",
                table: "assessment_questions_relation",
                column: "assessment_id",
                principalTable: "assessments",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_assessment_sections_assessments",
                table: "assessment_sections",
                column: "assessment_id",
                principalTable: "assessments",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_assessment_text_assessment_questions",
                table: "assessment_text",
                column: "question_id",
                principalTable: "assessment_questions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_assessment_true_false_assessment_questions",
                table: "assessment_true_false",
                column: "question_id",
                principalTable: "assessment_questions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
