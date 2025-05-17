using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PhoneBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MobilePhone = table.Column<string>(type: "text", nullable: false),
                    TitleJob = table.Column<string>(type: "text", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "BirthDate", "MobilePhone", "Name", "TitleJob" },
                values: new object[,]
                {
                    { new Guid("c16487f1-6d0a-4ce1-bffa-13755b63cf60"), new DateOnly(2004, 9, 26), "+375 (29) 123-45-67", "Vladislav", ".NET Developer" },
                    { new Guid("c86d2102-0a92-4039-be3f-230d15768498"), new DateOnly(2020, 1, 1), "+1 (111) 111-11-11", "Test", "Test" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
