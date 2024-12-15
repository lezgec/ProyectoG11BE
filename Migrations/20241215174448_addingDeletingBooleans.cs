using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoBE.Migrations
{
    /// <inheritdoc />
    public partial class addingDeletingBooleans : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "RevisionesPropuesta",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "RevisionesPropuesta",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "PropuestasGestores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PropuestasGestores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Propuestas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Propuestas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Gestores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Gestores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Coordinadores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Coordinadores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Alumnos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Alumnos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "RevisionesPropuesta");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "RevisionesPropuesta");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "PropuestasGestores");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PropuestasGestores");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Propuestas");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Propuestas");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Gestores");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Gestores");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Coordinadores");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Coordinadores");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Alumnos");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Alumnos");
        }
    }
}
