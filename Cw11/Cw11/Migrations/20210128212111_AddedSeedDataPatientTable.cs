using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cw11.Migrations
{
    public partial class AddedSeedDataPatientTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "IdPatient", "BirthDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { -1, new DateTime(1990, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michał", "Michalczewski" },
                    { -2, new DateTime(1990, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tomasz", "Piaskowy" },
                    { -3, new DateTime(1990, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adam", "Szklany" },
                    { -4, new DateTime(1990, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stanisław", "Stanowski" },
                    { -5, new DateTime(1990, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Konrad", "Kwiatkowski" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: -1);
        }
    }
}
