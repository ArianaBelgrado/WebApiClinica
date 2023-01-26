using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WSClinica.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habitaciones_Clinicas_ClinicaId",
                table: "Habitaciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Habitaciones",
                table: "Habitaciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clinicas",
                table: "Clinicas");

            migrationBuilder.RenameTable(
                name: "Habitaciones",
                newName: "Habitacion");

            migrationBuilder.RenameTable(
                name: "Clinicas",
                newName: "Clinica");

            migrationBuilder.RenameIndex(
                name: "IX_Habitaciones_ClinicaId",
                table: "Habitacion",
                newName: "IX_Habitacion_ClinicaId");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Habitacion",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Clinica",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaInicioActividaes",
                table: "Clinica",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Clinica",
                type: "varchar(60)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Habitacion",
                table: "Habitacion",
                column: "HabitacionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clinica",
                table: "Clinica",
                column: "ClinicaId");

            migrationBuilder.CreateTable(
                name: "Especialidad",
                columns: table => new
                {
                    EspecialidadId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidad", x => x.EspecialidadId);
                });

            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    MedicoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apellido = table.Column<string>(type: "varchar(50)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: false),
                    Matricula = table.Column<int>(nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "date", nullable: false),
                    EspecialidadId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.MedicoId);
                    table.ForeignKey(
                        name: "FK_Medico_Especialidad_EspecialidadId",
                        column: x => x.EspecialidadId,
                        principalTable: "Especialidad",
                        principalColumn: "EspecialidadId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    PacienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: false),
                    Apellido = table.Column<string>(type: "varchar(50)", nullable: false),
                    MedicoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.PacienteId);
                    table.ForeignKey(
                        name: "FK_Paciente_Medico_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medico",
                        principalColumn: "MedicoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medico_EspecialidadId",
                table: "Medico",
                column: "EspecialidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_MedicoId",
                table: "Paciente",
                column: "MedicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Habitacion_Clinica_ClinicaId",
                table: "Habitacion",
                column: "ClinicaId",
                principalTable: "Clinica",
                principalColumn: "ClinicaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habitacion_Clinica_ClinicaId",
                table: "Habitacion");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "Especialidad");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Habitacion",
                table: "Habitacion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clinica",
                table: "Clinica");

            migrationBuilder.RenameTable(
                name: "Habitacion",
                newName: "Habitaciones");

            migrationBuilder.RenameTable(
                name: "Clinica",
                newName: "Clinicas");

            migrationBuilder.RenameIndex(
                name: "IX_Habitacion_ClinicaId",
                table: "Habitaciones",
                newName: "IX_Habitaciones_ClinicaId");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Habitaciones",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Clinicas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaInicioActividaes",
                table: "Clinicas",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Clinicas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(60)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Habitaciones",
                table: "Habitaciones",
                column: "HabitacionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clinicas",
                table: "Clinicas",
                column: "ClinicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Habitaciones_Clinicas_ClinicaId",
                table: "Habitaciones",
                column: "ClinicaId",
                principalTable: "Clinicas",
                principalColumn: "ClinicaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
