using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EStudy.Infrastructure.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedFromIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Assigned = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EnglishName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CodeEDEBO = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Area = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Accreditation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Logo50 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Logo150 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    AddressInfo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Locality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Region = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    CodeForTeacher = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CodeForStudent = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedFromIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    IsEdit = table.Column<bool>(type: "bit", nullable: false),
                    DateLastEdit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditedFromIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditedByUserId = table.Column<int>(type: "int", nullable: true),
                    History = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    About = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Born = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Avatar50 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    IsShowPhone = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsShowEmail = table.Column<bool>(type: "bit", nullable: false),
                    Twitter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GitHub = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    ConfirmCode = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CodeValidUntil = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConfirmedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ConfirmedFromIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedFromIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    IsEdit = table.Column<bool>(type: "bit", nullable: false),
                    DateLastEdit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditedFromIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditedByUserId = table.Column<int>(type: "int", nullable: true),
                    History = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Shifr = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HeadById = table.Column<int>(type: "int", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ContactInformation = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    UniversityId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedFromIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    IsEdit = table.Column<bool>(type: "bit", nullable: false),
                    DateLastEdit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditedFromIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditedByUserId = table.Column<int>(type: "int", nullable: true),
                    History = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Shifr = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Qualification = table.Column<int>(type: "int", nullable: false),
                    EducationalProgram = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ProfessionalQualification = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    About = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedFromIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    IsEdit = table.Column<bool>(type: "bit", nullable: false),
                    DateLastEdit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditedFromIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditedByUserId = table.Column<int>(type: "int", nullable: true),
                    History = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specialties_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Course = table.Column<byte>(type: "tinyint", nullable: false),
                    StartStudy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndStudy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IndexItemToChanged = table.Column<byte>(type: "tinyint", nullable: true),
                    IsReleased = table.Column<bool>(type: "bit", nullable: false),
                    CodeForConnect = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsShowEmail = table.Column<bool>(type: "bit", nullable: false),
                    SpecialtyId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedFromIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    IsEdit = table.Column<bool>(type: "bit", nullable: false),
                    DateLastEdit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditedFromIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditedByUserId = table.Column<int>(type: "int", nullable: true),
                    History = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Specialties_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OrientedOnCourse = table.Column<int>(type: "int", nullable: true),
                    Theme = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WithExam = table.Column<bool>(type: "bit", nullable: false),
                    MaxMarkUpToExam = table.Column<int>(type: "int", nullable: false),
                    MaxMarkOnExam = table.Column<int>(type: "int", nullable: false),
                    CommonHours = table.Column<int>(type: "int", nullable: false),
                    HoursPracticalTasks = table.Column<int>(type: "int", nullable: true),
                    HoursSeminarTasks = table.Column<int>(type: "int", nullable: true),
                    HoursLectures = table.Column<int>(type: "int", nullable: true),
                    TypeSubject = table.Column<int>(type: "int", nullable: false),
                    Literature = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    FinalMark = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedFromIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    IsEdit = table.Column<bool>(type: "bit", nullable: false),
                    DateLastEdit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditedFromIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditedByUserId = table.Column<int>(type: "int", nullable: true),
                    History = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courses_Users_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Key = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedFromIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    IsEdit = table.Column<bool>(type: "bit", nullable: false),
                    DateLastEdit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditedFromIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditedByUserId = table.Column<int>(type: "int", nullable: true),
                    History = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emails_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    MemberRole = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedFromIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    IsEdit = table.Column<bool>(type: "bit", nullable: false),
                    DateLastEdit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditedFromIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditedByUserId = table.Column<int>(type: "int", nullable: true),
                    History = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupMembers_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupMembers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Theme = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: true),
                    Mark = table.Column<int>(type: "int", nullable: false),
                    DateLesson = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeLesson = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedFromIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    IsEdit = table.Column<bool>(type: "bit", nullable: false),
                    DateLastEdit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditedFromIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditedByUserId = table.Column<int>(type: "int", nullable: true),
                    History = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Homeworks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsComplate = table.Column<bool>(type: "bit", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Links = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Mark = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    MarkSetAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserSetMark = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    LessonId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedFromIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    IsEdit = table.Column<bool>(type: "bit", nullable: false),
                    DateLastEdit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditedFromIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditedByUserId = table.Column<int>(type: "int", nullable: true),
                    History = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homeworks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Homeworks_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Homeworks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LessonFiles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MD5CheckSum = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    SizeInBytes = table.Column<int>(type: "int", nullable: false),
                    OriginalName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Path = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LessonId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonFiles_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomeworkFiles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoadByUserId = table.Column<int>(type: "int", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    OriginalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeworkId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeworkFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeworkFiles_Homeworks_HomeworkId",
                        column: x => x.HomeworkId,
                        principalTable: "Homeworks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_GroupId",
                table: "Courses",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Name_ShortName_Theme_GroupId_TeacherId",
                table: "Courses",
                columns: new[] { "Name", "ShortName", "Theme", "GroupId", "TeacherId" });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Name_Phone_Shifr_UniversityId",
                table: "Departments",
                columns: new[] { "Name", "Phone", "Shifr", "UniversityId" });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_UniversityId",
                table: "Departments",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_Address_Password_Title_Key",
                table: "Emails",
                columns: new[] { "Address", "Password", "Title", "Key" });

            migrationBuilder.CreateIndex(
                name: "IX_Emails_GroupId",
                table: "Emails",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_Path_Extension_Size",
                table: "Files",
                columns: new[] { "Path", "Extension", "Size" });

            migrationBuilder.CreateIndex(
                name: "IX_GroupMembers_GroupId",
                table: "GroupMembers",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMembers_UserId_GroupId_Title_MemberRole",
                table: "GroupMembers",
                columns: new[] { "UserId", "GroupId", "Title", "MemberRole" });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_Name_CodeForConnect_Course_IsReleased_SpecialtyId",
                table: "Groups",
                columns: new[] { "Name", "CodeForConnect", "Course", "IsReleased", "SpecialtyId" });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_SpecialtyId",
                table: "Groups",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkFiles_HomeworkId",
                table: "HomeworkFiles",
                column: "HomeworkId");

            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_LessonId",
                table: "Homeworks",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_UserId_LessonId_IsComplate_Text",
                table: "Homeworks",
                columns: new[] { "UserId", "LessonId", "IsComplate", "Text" });

            migrationBuilder.CreateIndex(
                name: "IX_LessonFiles_LessonId",
                table: "LessonFiles",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonFiles_OriginalName_MD5CheckSum_Path_LessonId_Extension",
                table: "LessonFiles",
                columns: new[] { "OriginalName", "MD5CheckSum", "Path", "LessonId", "Extension" });

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_CourseId",
                table: "Lessons",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_Theme_TypeLesson_DateLesson_CourseId",
                table: "Lessons",
                columns: new[] { "Theme", "TypeLesson", "DateLesson", "CourseId" });

            migrationBuilder.CreateIndex(
                name: "IX_Specialties_DepartmentId",
                table: "Specialties",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Specialties_Name_Code_DepartmentId_Shifr",
                table: "Specialties",
                columns: new[] { "Name", "Code", "DepartmentId", "Shifr" });

            migrationBuilder.CreateIndex(
                name: "IX_Universities_Name_EnglishName_ShortName_CodeEDEBO",
                table: "Universities",
                columns: new[] { "Name", "EnglishName", "ShortName", "CodeEDEBO" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_FirstName_MiddleName_LastName",
                table: "Users",
                columns: new[] { "FirstName", "MiddleName", "LastName" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                table: "Users",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true,
                filter: "[Username] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "GroupMembers");

            migrationBuilder.DropTable(
                name: "HomeworkFiles");

            migrationBuilder.DropTable(
                name: "LessonFiles");

            migrationBuilder.DropTable(
                name: "Homeworks");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Specialties");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Universities");
        }
    }
}
