using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clinic_management_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class AddPatientHealthPlanTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_CM_PATIENT_T_CM_HEALTH_PLAN_id_health_plan",
                table: "T_CM_PATIENT");

            migrationBuilder.DropIndex(
                name: "IX_T_CM_PATIENT_id_health_plan",
                table: "T_CM_PATIENT");

            migrationBuilder.DropColumn(
                name: "id_health_plan",
                table: "T_CM_PATIENT");

            migrationBuilder.CreateTable(
                name: "T_CM_PATIENT_HEALTH_PLAN",
                columns: table => new
                {
                    id_patient_health_plan = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    id_patient = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    id_health_plan = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AccessionDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_CM_PATIENT_HEALTH_PLAN", x => x.id_patient_health_plan);
                    table.ForeignKey(
                        name: "FK_T_CM_PATIENT_HEALTH_PLAN_T_CM_HEALTH_PLAN_id_health_plan",
                        column: x => x.id_health_plan,
                        principalTable: "T_CM_HEALTH_PLAN",
                        principalColumn: "id_health_plan",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_CM_PATIENT_HEALTH_PLAN_T_CM_PATIENT_id_patient",
                        column: x => x.id_patient,
                        principalTable: "T_CM_PATIENT",
                        principalColumn: "id_patient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_CM_PATIENT_HEALTH_PLAN_id_health_plan",
                table: "T_CM_PATIENT_HEALTH_PLAN",
                column: "id_health_plan");

            migrationBuilder.CreateIndex(
                name: "IX_T_CM_PATIENT_HEALTH_PLAN_id_patient",
                table: "T_CM_PATIENT_HEALTH_PLAN",
                column: "id_patient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_CM_PATIENT_HEALTH_PLAN");

            migrationBuilder.AddColumn<int>(
                name: "id_health_plan",
                table: "T_CM_PATIENT",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_T_CM_PATIENT_id_health_plan",
                table: "T_CM_PATIENT",
                column: "id_health_plan");

            migrationBuilder.AddForeignKey(
                name: "FK_T_CM_PATIENT_T_CM_HEALTH_PLAN_id_health_plan",
                table: "T_CM_PATIENT",
                column: "id_health_plan",
                principalTable: "T_CM_HEALTH_PLAN",
                principalColumn: "id_health_plan",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
