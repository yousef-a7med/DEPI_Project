using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.DAL.Migrations;

/// <inheritdoc />
public partial class _20261127202651_Add_DataBase : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Medications",
            columns: table => new
            {
                MedicationId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                StockQuantity = table.Column<int>(type: "int", nullable: false),
                UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Medications", x => x.MedicationId);
            });

        migrationBuilder.CreateTable(
            name: "Users",
            columns: table => new
            {
                ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Role = table.Column<int>(type: "int", nullable: false),
                IsActive = table.Column<bool>(type: "bit", nullable: false),
                Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Users", x => x.ID);
            });

        migrationBuilder.CreateTable(
            name: "Doctors",
            columns: table => new
            {
                DoctorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                LicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                ConsultationFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                UserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Doctors", x => x.DoctorId);
                table.ForeignKey(
                    name: "FK_Doctors_Users_UserID",
                    column: x => x.UserID,
                    principalTable: "Users",
                    principalColumn: "ID");
            });

        migrationBuilder.CreateTable(
            name: "Nurses",
            columns: table => new
            {
                NurseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                Shift = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                LicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                UserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Nurses", x => x.NurseId);
                table.ForeignKey(
                    name: "FK_Nurses_Users_UserID",
                    column: x => x.UserID,
                    principalTable: "Users",
                    principalColumn: "ID");
            });

        migrationBuilder.CreateTable(
            name: "Patients",
            columns: table => new
            {
                ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                Gender = table.Column<int>(type: "int", nullable: false),
                BloodType = table.Column<int>(type: "int", nullable: false),
                BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                Allergies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                UserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Patients", x => x.ID);
                table.ForeignKey(
                    name: "FK_Patients_Users_UserID",
                    column: x => x.UserID,
                    principalTable: "Users",
                    principalColumn: "ID");
            });

        migrationBuilder.CreateTable(
            name: "DoctorSchedule",
            columns: table => new
            {
                DoctorScheduleId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                DayOfWeek = table.Column<int>(type: "int", nullable: false),
                StartTime = table.Column<TimeOnly>(type: "time", nullable: false),
                EndTime = table.Column<TimeOnly>(type: "time", nullable: false),
                IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                DoctorId = table.Column<string>(type: "nvarchar(450)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_DoctorSchedule", x => x.DoctorScheduleId);
                table.ForeignKey(
                    name: "FK_DoctorSchedule_Doctors_DoctorId",
                    column: x => x.DoctorId,
                    principalTable: "Doctors",
                    principalColumn: "DoctorId");
            });

        migrationBuilder.CreateTable(
            name: "Appointments",
            columns: table => new
            {
                AppointmentId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                PatientId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                DoctorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                NurseId = table.Column<string>(type: "nvarchar(450)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Appointments", x => x.AppointmentId);
                table.ForeignKey(
                    name: "FK_Appointments_Doctors_DoctorId",
                    column: x => x.DoctorId,
                    principalTable: "Doctors",
                    principalColumn: "DoctorId");
                table.ForeignKey(
                    name: "FK_Appointments_Nurses_NurseId",
                    column: x => x.NurseId,
                    principalTable: "Nurses",
                    principalColumn: "NurseId");
                table.ForeignKey(
                    name: "FK_Appointments_Patients_PatientId",
                    column: x => x.PatientId,
                    principalTable: "Patients",
                    principalColumn: "ID");
            });

        migrationBuilder.CreateTable(
            name: "MedicalRecords",
            columns: table => new
            {
                MedicalRecordId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                TreatmentPlan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Symptoms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                AppointmentId = table.Column<int>(type: "int", nullable: true),
                NurseId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                DoctorId = table.Column<string>(type: "nvarchar(450)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_MedicalRecords", x => x.MedicalRecordId);
                table.ForeignKey(
                    name: "FK_MedicalRecords_Appointments_AppointmentId",
                    column: x => x.AppointmentId,
                    principalTable: "Appointments",
                    principalColumn: "AppointmentId");
                table.ForeignKey(
                    name: "FK_MedicalRecords_Doctors_DoctorId",
                    column: x => x.DoctorId,
                    principalTable: "Doctors",
                    principalColumn: "DoctorId");
                table.ForeignKey(
                    name: "FK_MedicalRecords_Nurses_NurseId",
                    column: x => x.NurseId,
                    principalTable: "Nurses",
                    principalColumn: "NurseId");
            });

        migrationBuilder.CreateTable(
            name: "Prescriptions",
            columns: table => new
            {
                PrescriptionId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                IssuedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Instructions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                MedicalRecordId = table.Column<int>(type: "int", nullable: true),
                PatientId = table.Column<string>(type: "nvarchar(450)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Prescriptions", x => x.PrescriptionId);
                table.ForeignKey(
                    name: "FK_Prescriptions_MedicalRecords_MedicalRecordId",
                    column: x => x.MedicalRecordId,
                    principalTable: "MedicalRecords",
                    principalColumn: "MedicalRecordId");
                table.ForeignKey(
                    name: "FK_Prescriptions_Patients_PatientId",
                    column: x => x.PatientId,
                    principalTable: "Patients",
                    principalColumn: "ID");
            });

        migrationBuilder.CreateTable(
            name: "PrescriptionItems",
            columns: table => new
            {
                PrescriptionItemId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Frequency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Quantity = table.Column<int>(type: "int", nullable: false),
                Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                PrescriptionId = table.Column<int>(type: "int", nullable: true),
                MedicationId = table.Column<int>(type: "int", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_PrescriptionItems", x => x.PrescriptionItemId);
                table.ForeignKey(
                    name: "FK_PrescriptionItems_Medications_MedicationId",
                    column: x => x.MedicationId,
                    principalTable: "Medications",
                    principalColumn: "MedicationId");
                table.ForeignKey(
                    name: "FK_PrescriptionItems_Prescriptions_PrescriptionId",
                    column: x => x.PrescriptionId,
                    principalTable: "Prescriptions",
                    principalColumn: "PrescriptionId");
            });

        migrationBuilder.CreateIndex(
            name: "IX_Appointments_DoctorId",
            table: "Appointments",
            column: "DoctorId");

        migrationBuilder.CreateIndex(
            name: "IX_Appointments_NurseId",
            table: "Appointments",
            column: "NurseId");

        migrationBuilder.CreateIndex(
            name: "IX_Appointments_PatientId",
            table: "Appointments",
            column: "PatientId");

        migrationBuilder.CreateIndex(
            name: "IX_Doctors_UserID",
            table: "Doctors",
            column: "UserID");

        migrationBuilder.CreateIndex(
            name: "IX_DoctorSchedule_DoctorId",
            table: "DoctorSchedule",
            column: "DoctorId");

        migrationBuilder.CreateIndex(
            name: "IX_MedicalRecords_AppointmentId",
            table: "MedicalRecords",
            column: "AppointmentId",
            unique: true,
            filter: "[AppointmentId] IS NOT NULL");

        migrationBuilder.CreateIndex(
            name: "IX_MedicalRecords_DoctorId",
            table: "MedicalRecords",
            column: "DoctorId");

        migrationBuilder.CreateIndex(
            name: "IX_MedicalRecords_NurseId",
            table: "MedicalRecords",
            column: "NurseId");

        migrationBuilder.CreateIndex(
            name: "IX_Nurses_UserID",
            table: "Nurses",
            column: "UserID");

        migrationBuilder.CreateIndex(
            name: "IX_Patients_UserID",
            table: "Patients",
            column: "UserID");

        migrationBuilder.CreateIndex(
            name: "IX_PrescriptionItems_MedicationId",
            table: "PrescriptionItems",
            column: "MedicationId");

        migrationBuilder.CreateIndex(
            name: "IX_PrescriptionItems_PrescriptionId",
            table: "PrescriptionItems",
            column: "PrescriptionId");

        migrationBuilder.CreateIndex(
            name: "IX_Prescriptions_MedicalRecordId",
            table: "Prescriptions",
            column: "MedicalRecordId");

        migrationBuilder.CreateIndex(
            name: "IX_Prescriptions_PatientId",
            table: "Prescriptions",
            column: "PatientId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "DoctorSchedule");

        migrationBuilder.DropTable(
            name: "PrescriptionItems");

        migrationBuilder.DropTable(
            name: "Medications");

        migrationBuilder.DropTable(
            name: "Prescriptions");

        migrationBuilder.DropTable(
            name: "MedicalRecords");

        migrationBuilder.DropTable(
            name: "Appointments");

        migrationBuilder.DropTable(
            name: "Doctors");

        migrationBuilder.DropTable(
            name: "Nurses");

        migrationBuilder.DropTable(
            name: "Patients");

        migrationBuilder.DropTable(
            name: "Users");
    }
}
