using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoBE.Migrations
{
    /// <inheritdoc />
    public partial class Fixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Propuestas_Alumnos_AlumnoId",
                table: "Propuestas");

            migrationBuilder.DropIndex(
                name: "IX_Propuestas_AlumnoId",
                table: "Propuestas");

            migrationBuilder.DropColumn(
                name: "AlumnoId",
                table: "Propuestas");

            migrationBuilder.DropColumn(
                name: "IdAlumno",
                table: "Propuestas");

            migrationBuilder.RenameColumn(
                name: "FechaCreacion",
                table: "Propuestas",
                newName: "FechaSubida");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Propuestas",
                newName: "Definicion");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Propuestas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Alumno1Id",
                table: "Propuestas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Alumno2Id",
                table: "Propuestas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Archivo",
                table: "Propuestas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaModificacion",
                table: "Propuestas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Observaciones",
                table: "Propuestas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RevisorId",
                table: "Propuestas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cedula",
                table: "Gestores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PropuestasIds",
                table: "Gestores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rol",
                table: "Gestores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alumno1Id",
                table: "Propuestas");

            migrationBuilder.DropColumn(
                name: "Alumno2Id",
                table: "Propuestas");

            migrationBuilder.DropColumn(
                name: "Archivo",
                table: "Propuestas");

            migrationBuilder.DropColumn(
                name: "FechaModificacion",
                table: "Propuestas");

            migrationBuilder.DropColumn(
                name: "Observaciones",
                table: "Propuestas");

            migrationBuilder.DropColumn(
                name: "RevisorId",
                table: "Propuestas");

            migrationBuilder.DropColumn(
                name: "Cedula",
                table: "Gestores");

            migrationBuilder.DropColumn(
                name: "PropuestasIds",
                table: "Gestores");

            migrationBuilder.DropColumn(
                name: "Rol",
                table: "Gestores");

            migrationBuilder.RenameColumn(
                name: "FechaSubida",
                table: "Propuestas",
                newName: "FechaCreacion");

            migrationBuilder.RenameColumn(
                name: "Definicion",
                table: "Propuestas",
                newName: "Descripcion");

            migrationBuilder.AlterColumn<int>(
                name: "Estado",
                table: "Propuestas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AlumnoId",
                table: "Propuestas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdAlumno",
                table: "Propuestas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Propuestas_AlumnoId",
                table: "Propuestas",
                column: "AlumnoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Propuestas_Alumnos_AlumnoId",
                table: "Propuestas",
                column: "AlumnoId",
                principalTable: "Alumnos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
