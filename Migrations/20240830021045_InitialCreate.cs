using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clinic_management_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_CM_ADDRESS",
                columns: table => new
                {
                    id_address = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nm_street = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    nr_address = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ds_neighborhood = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ds_city = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ds_state = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    nr_postal_code = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_CM_ADDRESS", x => x.id_address);
                });

            migrationBuilder.CreateTable(
                name: "T_CM_HEALTH_PLAN",
                columns: table => new
                {
                    id_health_plan = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ds_name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    cod_plan = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ds_coverage = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_CM_HEALTH_PLAN", x => x.id_health_plan);
                });

            migrationBuilder.CreateTable(
                name: "T_CM_PATIENT",
                columns: table => new
                {
                    id_patient = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ds_name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    dt_birth = table.Column<string>(type: "NVARCHAR2(10)", nullable: false),
                    nr_cpf = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    nr_phone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    id_address = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    id_health_plan = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_CM_PATIENT", x => x.id_patient);
                    table.ForeignKey(
                        name: "FK_T_CM_PATIENT_T_CM_ADDRESS_id_address",
                        column: x => x.id_address,
                        principalTable: "T_CM_ADDRESS",
                        principalColumn: "id_address",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_CM_PATIENT_T_CM_HEALTH_PLAN_id_health_plan",
                        column: x => x.id_health_plan,
                        principalTable: "T_CM_HEALTH_PLAN",
                        principalColumn: "id_health_plan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_CM_PATIENT_id_address",
                table: "T_CM_PATIENT",
                column: "id_address");

            migrationBuilder.CreateIndex(
                name: "IX_T_CM_PATIENT_id_health_plan",
                table: "T_CM_PATIENT",
                column: "id_health_plan");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_CM_PATIENT");

            migrationBuilder.DropTable(
                name: "T_CM_ADDRESS");

            migrationBuilder.DropTable(
                name: "T_CM_HEALTH_PLAN");
        }
    }
}
