using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Exam.Migrations
{
    public partial class StandUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "assessment_questions",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    question = table.Column<string>(type: "text", nullable: true),
                    category_id = table.Column<long>(type: "bigint", nullable: false),
                    level = table.Column<int>(type: "int", nullable: false, defaultValueSql: "('0')"),
                    order = table.Column<int>(type: "int", nullable: false, defaultValueSql: "('0')"),
                    type = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assessment_questions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "assessments",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    short_description = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    slug = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    updated_by = table.Column<int>(type: "int", nullable: true),
                    duration = table.Column<int>(type: "int", nullable: false, defaultValueSql: "('7')"),
                    category_id = table.Column<long>(type: "bigint", nullable: true),
                    thumbnail = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    published = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "('1')"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assessments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    api_key = table.Column<string>(type: "char(36)", unicode: false, fixedLength: true, maxLength: 36, nullable: true),
                    username = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    first_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    last_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    is_banned = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "('0')"),
                    is_verified = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "('0')"),
                    confirm_code = table.Column<string>(type: "char(36)", unicode: false, fixedLength: true, maxLength: 36, nullable: false),
                    confirmed_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    password_changed_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    display_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    user_url = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    is_ldap = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "('0')"),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    updated_by = table.Column<long>(type: "bigint", nullable: false),
                    remember_token = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    otp = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    otp_created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    profile_picture_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "assessment_match",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    answer_id_key = table.Column<string>(type: "char(36)", unicode: false, fixedLength: true, maxLength: 36, nullable: false),
                    question_id_key = table.Column<string>(type: "char(36)", unicode: false, fixedLength: true, maxLength: 36, nullable: false),
                    option = table.Column<string>(type: "text", nullable: true),
                    answer = table.Column<string>(type: "text", nullable: true),
                    question_id = table.Column<long>(type: "bigint", nullable: false),
                    order = table.Column<int>(type: "int", nullable: false, defaultValueSql: "('0')"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assessment_match", x => x.id);
                    table.ForeignKey(
                        name: "FK_assessment_match_assessment_questions",
                        column: x => x.question_id,
                        principalTable: "assessment_questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "assessment_options",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    option = table.Column<string>(type: "text", nullable: true),
                    question_id = table.Column<long>(type: "bigint", nullable: false),
                    correct = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "('0')"),
                    order = table.Column<int>(type: "int", nullable: false, defaultValueSql: "('0')"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assessment_options", x => x.id);
                    table.ForeignKey(
                        name: "FK_assessment_options_assessment_questions",
                        column: x => x.question_id,
                        principalTable: "assessment_questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "assessment_text",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    answer = table.Column<string>(type: "text", nullable: true),
                    question_id = table.Column<long>(type: "bigint", nullable: false),
                    order = table.Column<int>(type: "int", nullable: false, defaultValueSql: "('0')"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assessment_text", x => x.id);
                    table.ForeignKey(
                        name: "FK_assessment_text_assessment_questions",
                        column: x => x.question_id,
                        principalTable: "assessment_questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "assessment_true_false",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    question_id = table.Column<long>(type: "bigint", nullable: false),
                    is_true = table.Column<int>(type: "int", nullable: false, defaultValueSql: "('0')"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assessment_true_false", x => x.id);
                    table.ForeignKey(
                        name: "FK_assessment_true_false_assessment_questions",
                        column: x => x.question_id,
                        principalTable: "assessment_questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "assessment_data",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    assessment_id = table.Column<long>(type: "bigint", nullable: false),
                    data = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assessment_data", x => x.id);
                    table.ForeignKey(
                        name: "FK_assessment_data_assessments",
                        column: x => x.assessment_id,
                        principalTable: "assessments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "assessment_department",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    group_id = table.Column<long>(type: "bigint", nullable: false),
                    assessment_id = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assessment_department", x => x.id);
                    table.ForeignKey(
                        name: "FK_assessment_department_assessments",
                        column: x => x.assessment_id,
                        principalTable: "assessments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "assessment_meta",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    assessment_id = table.Column<long>(type: "bigint", nullable: false),
                    type = table.Column<string>(type: "text", nullable: true),
                    value = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assessment_meta", x => x.id);
                    table.ForeignKey(
                        name: "FK_assessment_meta_assessments",
                        column: x => x.assessment_id,
                        principalTable: "assessments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "assessment_questions_relation",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    question_id = table.Column<long>(type: "bigint", nullable: false),
                    assessment_id = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assessment_questions_relation", x => x.id);
                    table.ForeignKey(
                        name: "FK_assessment_questions_relation_assessment_questions",
                        column: x => x.question_id,
                        principalTable: "assessment_questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_assessment_questions_relation_assessments",
                        column: x => x.assessment_id,
                        principalTable: "assessments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "assessment_sections",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    assessment_id = table.Column<long>(type: "bigint", nullable: false),
                    order = table.Column<int>(type: "int", nullable: false, defaultValueSql: "('0')"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assessment_sections", x => x.id);
                    table.ForeignKey(
                        name: "FK_assessment_sections_assessments",
                        column: x => x.assessment_id,
                        principalTable: "assessments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "assessment_answers",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    assessment_id = table.Column<long>(type: "bigint", nullable: false),
                    question_id = table.Column<long>(type: "bigint", nullable: false),
                    answer = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    score = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "('0')"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assessment_answers", x => x.id);
                    table.ForeignKey(
                        name: "FK_assessment_answers_assessment_questions",
                        column: x => x.question_id,
                        principalTable: "assessment_questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_assessment_answers_assessments",
                        column: x => x.assessment_id,
                        principalTable: "assessments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_assessment_answers_users",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "assessment_enrols",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    assessment_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    result = table.Column<int>(type: "int", nullable: true),
                    score = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "('0')"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assessment_enrols", x => x.id);
                    table.ForeignKey(
                        name: "FK_assessment_enrols_assessments",
                        column: x => x.assessment_id,
                        principalTable: "assessments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_assessment_enrols_users",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_assessment_answers_assessment_id",
                table: "assessment_answers",
                column: "assessment_id");

            migrationBuilder.CreateIndex(
                name: "IX_assessment_answers_question_id",
                table: "assessment_answers",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_assessment_answers_user_id",
                table: "assessment_answers",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_assessment_data_assessment_id",
                table: "assessment_data",
                column: "assessment_id");

            migrationBuilder.CreateIndex(
                name: "IX_assessment_department_assessment_id",
                table: "assessment_department",
                column: "assessment_id");

            migrationBuilder.CreateIndex(
                name: "IX_assessment_enrols_assessment_id",
                table: "assessment_enrols",
                column: "assessment_id");

            migrationBuilder.CreateIndex(
                name: "IX_assessment_enrols_user_id",
                table: "assessment_enrols",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_assessment_match",
                table: "assessment_match",
                column: "answer_id_key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_assessment_match_1",
                table: "assessment_match",
                column: "question_id_key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_assessment_match_question_id",
                table: "assessment_match",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_assessment_meta_assessment_id",
                table: "assessment_meta",
                column: "assessment_id");

            migrationBuilder.CreateIndex(
                name: "IX_assessment_options_question_id",
                table: "assessment_options",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_assessment_questions_relation_assessment_id",
                table: "assessment_questions_relation",
                column: "assessment_id");

            migrationBuilder.CreateIndex(
                name: "IX_assessment_questions_relation_question_id",
                table: "assessment_questions_relation",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_assessment_sections_assessment_id",
                table: "assessment_sections",
                column: "assessment_id");

            migrationBuilder.CreateIndex(
                name: "IX_assessment_text_question_id",
                table: "assessment_text",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_assessment_true_false_question_id",
                table: "assessment_true_false",
                column: "question_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "assessment_answers");

            migrationBuilder.DropTable(
                name: "assessment_data");

            migrationBuilder.DropTable(
                name: "assessment_department");

            migrationBuilder.DropTable(
                name: "assessment_enrols");

            migrationBuilder.DropTable(
                name: "assessment_match");

            migrationBuilder.DropTable(
                name: "assessment_meta");

            migrationBuilder.DropTable(
                name: "assessment_options");

            migrationBuilder.DropTable(
                name: "assessment_questions_relation");

            migrationBuilder.DropTable(
                name: "assessment_sections");

            migrationBuilder.DropTable(
                name: "assessment_text");

            migrationBuilder.DropTable(
                name: "assessment_true_false");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "assessments");

            migrationBuilder.DropTable(
                name: "assessment_questions");
        }
    }
}
