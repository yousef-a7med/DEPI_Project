using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.DAL.Migrations;

/// <inheritdoc />
public partial class _20261125140158_Add_Users_Patients_Tables : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Users",
            columns: table => new
            {
                ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Role = table.Column<int>(type: "int", nullable: false),
                IsActive = table.Column<bool>(type: "bit", nullable: false),
                CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                CreatorUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                ModifirrUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                DeleterUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Users", x => x.ID);
            });

        migrationBuilder.CreateTable(
            name: "Patients",
            columns: table => new
            {
                ID = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Gender = table.Column<int>(type: "int", nullable: false),
                BloodType = table.Column<int>(type: "int", nullable: false),
                BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                Allergies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                CreatorUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                ModifirrUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                DeleterUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                UserID = table.Column<string>(type: "nvarchar(450)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Patients", x => x.ID);
                table.ForeignKey(
                    name: "FK_Patients_Users_UserID",
                    column: x => x.UserID,
                    principalTable: "Users",
                    principalColumn: "ID",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Patients_UserID",
            table: "Patients",
            column: "UserID");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Patients");

        migrationBuilder.DropTable(
            name: "Users");
    }
}
