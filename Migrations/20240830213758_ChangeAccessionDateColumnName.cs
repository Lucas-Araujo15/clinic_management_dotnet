using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clinic_management_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAccessionDateColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccessionDate",
                table: "T_CM_PATIENT_HEALTH_PLAN",
                newName: "dt_accession");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "dt_accession",
                table: "T_CM_PATIENT_HEALTH_PLAN",
                newName: "AccessionDate");
        }
    }
}
