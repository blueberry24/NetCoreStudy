using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreStudy.Infrastructure.Migrations
{
    public partial class AddTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Examination",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    PassLine = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TotalScore = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ExamTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ReExamineTimes = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    InvigilatorCount = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    SubjectId = table.Column<string>(type: "varchar(64)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examination", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Examination_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Examination_SubjectId",
                table: "Examination",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Examination");
        }
    }
}
