using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class SeedDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "IT" },
                    { 2, "HR" },
                    { 3, "Finance" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Software Engineer" },
                    { 2, "HR Specialist" },
                    { 3, "Accountant" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DepartmentId", "Email", "FirstName", "LastName", "PositionId" },
                values: new object[,]
                {
                    { 1, 1, "john.doe@example.com", "John", "Doe", 1 },
                    { 2, 2, "jane.smith@example.com", "Jane", "Smith", 2 },
                    { 3, 3, "michael.brown@example.com", "Michael", "Brown", 3 }
                });

            migrationBuilder.InsertData(
                table: "Leaves",
                columns: new[] { "Id", "EmployeeId", "EndDate", "Reason", "StartDate", "Status", "Type" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vacation", new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Approved", "Paid" },
                    { 2, 2, new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Flu", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "Sick" },
                    { 3, 3, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Personal reasons", new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rejected", "Unpaid" }
                });

            migrationBuilder.InsertData(
                table: "Salaries",
                columns: new[] { "Id", "Amount", "EmployeeId", "PaymentDate" },
                values: new object[,]
                {
                    { 1, 5000m, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 4000m, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 4500m, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
