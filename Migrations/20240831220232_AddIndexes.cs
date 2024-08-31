using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clinic_management_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "nr_phone",
                table: "T_CM_PATIENT",
                type: "NVARCHAR2(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<string>(
                name: "nr_cpf",
                table: "T_CM_PATIENT",
                type: "NVARCHAR2(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<string>(
                name: "cod_plan",
                table: "T_CM_HEALTH_PLAN",
                type: "NVARCHAR2(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.CreateIndex(
                name: "IX_T_CM_PATIENT_nr_cpf",
                table: "T_CM_PATIENT",
                column: "nr_cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_T_CM_PATIENT_nr_phone",
                table: "T_CM_PATIENT",
                column: "nr_phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_T_CM_HEALTH_PLAN_cod_plan",
                table: "T_CM_HEALTH_PLAN",
                column: "cod_plan",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_T_CM_PATIENT_nr_cpf",
                table: "T_CM_PATIENT");

            migrationBuilder.DropIndex(
                name: "IX_T_CM_PATIENT_nr_phone",
                table: "T_CM_PATIENT");

            migrationBuilder.DropIndex(
                name: "IX_T_CM_HEALTH_PLAN_cod_plan",
                table: "T_CM_HEALTH_PLAN");

            migrationBuilder.AlterColumn<string>(
                name: "nr_phone",
                table: "T_CM_PATIENT",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(450)");

            migrationBuilder.AlterColumn<string>(
                name: "nr_cpf",
                table: "T_CM_PATIENT",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(450)");

            migrationBuilder.AlterColumn<string>(
                name: "cod_plan",
                table: "T_CM_HEALTH_PLAN",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(450)");
        }
    }
}
