using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManament.Migrations
{
    /// <inheritdoc />
    public partial class inti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dapartmant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dapartmant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DapartmantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Dapartmant_DapartmantId",
                        column: x => x.DapartmantId,
                        principalTable: "Dapartmant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmantId = table.Column<int>(type: "int", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructors_Dapartmant_DepartmantId",
                        column: x => x.DepartmantId,
                        principalTable: "Dapartmant",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Instructors_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    DepartmantId = table.Column<int>(type: "int", nullable: true),
                    InstructorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Dapartmant_DepartmantId",
                        column: x => x.DepartmantId,
                        principalTable: "Dapartmant",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Courses_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OfficeAssignments",
                columns: table => new
                {
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeAssignments", x => x.InstructorId);
                    table.ForeignKey(
                        name: "FK_OfficeAssignments_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPresent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendances_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendances_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseStudent",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "int", nullable: false),
                    StudentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudent", x => new { x.CoursesId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_CourseStudent_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudent_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrollments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Credits", "DepartmantId", "InstructorId", "Name" },
                values: new object[,]
                {
                    { 1, 3, null, null, "Python Basics" },
                    { 2, 4, null, null, "Machine Learning" },
                    { 3, 3, null, null, "Cybersecurity Fundamentals" },
                    { 4, 2, null, null, "Software Testing" },
                    { 5, 3, null, null, "Data Visualization" }
                });

            migrationBuilder.InsertData(
                table: "Dapartmant",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Artificial Intelligence" },
                    { 2, "Cyber Security" },
                    { 3, "Digital Marketing" },
                    { 4, "Software Engineering" },
                    { 5, "Data Science" }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "DepartmantId", "Email", "HireDate", "Name", "StudentId" },
                values: new object[,]
                {
                    { 1, null, "heba.youssef@example.com", new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr. Heba Youssef", null },
                    { 2, null, "karim.nabil@example.com", new DateTime(2018, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr. Karim Nabil", null },
                    { 3, null, "salma.fathy@example.com", new DateTime(2019, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr. Salma Fathy", null },
                    { 4, null, "ehab.hassan@example.com", new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr. Ehab Hassan", null },
                    { 5, null, "rasha.emad@example.com", new DateTime(2022, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr. Rasha Emad", null }
                });

            migrationBuilder.InsertData(
                table: "OfficeAssignments",
                columns: new[] { "InstructorId", "Location" },
                values: new object[,]
                {
                    { 1, "Room F101" },
                    { 2, "Room G202" },
                    { 3, "Room H303" },
                    { 4, "Room I404" },
                    { 5, "Room J505" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DapartmantId", "DataOfBirth", "Email", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2002, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "omar.khaled@example.com", "Omar Khaled" },
                    { 2, 2, new DateTime(2003, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "laila.mahmoud@example.com", "Laila Mahmoud" },
                    { 3, 3, new DateTime(2001, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "khaled.samir@example.com", "Khaled Samir" },
                    { 4, 4, new DateTime(2002, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "fatma.adel@example.com", "Fatma Adel" },
                    { 5, 5, new DateTime(2000, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "mostafa.ahmed@example.com", "Mostafa Ahmed" }
                });

            migrationBuilder.InsertData(
                table: "Attendances",
                columns: new[] { "Id", "CourseId", "Date", "IsPresent", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1 },
                    { 2, 2, new DateTime(2025, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2 },
                    { 3, 3, new DateTime(2025, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 3 },
                    { 4, 4, new DateTime(2025, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4 },
                    { 5, 5, new DateTime(2025, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 5 }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "Id", "CourseId", "EnrollmentDate", "Grade", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "B+", 1 },
                    { 2, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", 2 },
                    { 3, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "B", 3 },
                    { 4, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C+", 4 },
                    { 5, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A-", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_CourseId",
                table: "Attendances",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_StudentId",
                table: "Attendances",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DepartmantId",
                table: "Courses",
                column: "DepartmantId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_InstructorId",
                table: "Courses",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_StudentsId",
                table: "CourseStudent",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CourseId",
                table: "Enrollments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentId",
                table: "Enrollments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_DepartmantId",
                table: "Instructors",
                column: "DepartmantId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_StudentId",
                table: "Instructors",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_DapartmantId",
                table: "Students",
                column: "DapartmantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "CourseStudent");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "OfficeAssignments");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Dapartmant");
        }
    }
}
