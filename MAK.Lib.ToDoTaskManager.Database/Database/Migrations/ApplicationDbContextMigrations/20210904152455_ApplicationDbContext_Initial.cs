using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MAK.Lib.ToDoTaskManager.Database.Database.Migrations.ApplicationDbContextMigrations
{
    public partial class ApplicationDbContext_Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    Occupation = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToDoTaskCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoTaskCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ToDoTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Detail = table.Column<string>(type: "TEXT", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: true),
                    Complete = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    ToDoTaskCategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDoTasks_ToDoTaskCategories_ToDoTaskCategoryId",
                        column: x => x.ToDoTaskCategoryId,
                        principalTable: "ToDoTaskCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1", "b8e3d9da-3acd-4402-802b-d52699519b7c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2", "dfce050d-99de-44fd-825d-991fc1ad1f74", "SuperAdmin", "SUPERADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3", "3772fc39-c65a-4c9b-889d-fcfaab735add", "Editor", "EDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4", "e60c6a3b-e908-47fa-bdef-f4026574fc63", "RegularUser", "REGULARUSER" });

            migrationBuilder.InsertData(
                table: "ToDoTaskCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Unspecified" });

            migrationBuilder.InsertData(
                table: "ToDoTaskCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Important" });

            migrationBuilder.InsertData(
                table: "ToDoTaskCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Urgent" });

            migrationBuilder.InsertData(
                table: "ToDoTasks",
                columns: new[] { "Id", "Complete", "CreatedDate", "Detail", "Image", "Title", "ToDoTaskCategoryId" },
                values: new object[] { 1, false, new DateTimeOffset(new DateTime(2021, 9, 4, 15, 24, 54, 883, DateTimeKind.Unspecified).AddTicks(5646), new TimeSpan(0, 0, 0, 0, 0)), "Detail 1", "https://localhost:5551/Images/UploadFiles/Default.png", "Title 1", 1 });

            migrationBuilder.InsertData(
                table: "ToDoTasks",
                columns: new[] { "Id", "Complete", "CreatedDate", "Detail", "Image", "Title", "ToDoTaskCategoryId" },
                values: new object[] { 3, false, new DateTimeOffset(new DateTime(2021, 9, 4, 15, 24, 54, 883, DateTimeKind.Unspecified).AddTicks(7420), new TimeSpan(0, 0, 0, 0, 0)), "Detail 3", "https://localhost:5551/Images/UploadFiles/Default.png", "Title 3", 1 });

            migrationBuilder.InsertData(
                table: "ToDoTasks",
                columns: new[] { "Id", "Complete", "CreatedDate", "Detail", "Image", "Title", "ToDoTaskCategoryId" },
                values: new object[] { 5, false, new DateTimeOffset(new DateTime(2021, 9, 4, 15, 24, 54, 883, DateTimeKind.Unspecified).AddTicks(7428), new TimeSpan(0, 0, 0, 0, 0)), "Detail 5", "https://localhost:5551/Images/UploadFiles/Default.png", "Title 5", 1 });

            migrationBuilder.InsertData(
                table: "ToDoTasks",
                columns: new[] { "Id", "Complete", "CreatedDate", "Detail", "Image", "Title", "ToDoTaskCategoryId" },
                values: new object[] { 8, false, new DateTimeOffset(new DateTime(2021, 9, 4, 15, 24, 54, 883, DateTimeKind.Unspecified).AddTicks(7439), new TimeSpan(0, 0, 0, 0, 0)), "Detail 8", "https://localhost:5551/Images/UploadFiles/Default.png", "Title 8", 1 });

            migrationBuilder.InsertData(
                table: "ToDoTasks",
                columns: new[] { "Id", "Complete", "CreatedDate", "Detail", "Image", "Title", "ToDoTaskCategoryId" },
                values: new object[] { 10, false, new DateTimeOffset(new DateTime(2021, 9, 4, 15, 24, 54, 883, DateTimeKind.Unspecified).AddTicks(7446), new TimeSpan(0, 0, 0, 0, 0)), "Detail 10", "https://localhost:5551/Images/UploadFiles/Default.png", "Title 10", 1 });

            migrationBuilder.InsertData(
                table: "ToDoTasks",
                columns: new[] { "Id", "Complete", "CreatedDate", "Detail", "Image", "Title", "ToDoTaskCategoryId" },
                values: new object[] { 13, false, new DateTimeOffset(new DateTime(2021, 9, 4, 15, 24, 54, 883, DateTimeKind.Unspecified).AddTicks(7455), new TimeSpan(0, 0, 0, 0, 0)), "Detail 13", "https://localhost:5551/Images/UploadFiles/Default.png", "Title 13", 1 });

            migrationBuilder.InsertData(
                table: "ToDoTasks",
                columns: new[] { "Id", "Complete", "CreatedDate", "Detail", "Image", "Title", "ToDoTaskCategoryId" },
                values: new object[] { 15, false, new DateTimeOffset(new DateTime(2021, 9, 4, 15, 24, 54, 883, DateTimeKind.Unspecified).AddTicks(7460), new TimeSpan(0, 0, 0, 0, 0)), "Detail 15", "https://localhost:5551/Images/UploadFiles/Default.png", "Title 15", 1 });

            migrationBuilder.InsertData(
                table: "ToDoTasks",
                columns: new[] { "Id", "Complete", "CreatedDate", "Detail", "Image", "Title", "ToDoTaskCategoryId" },
                values: new object[] { 2, false, new DateTimeOffset(new DateTime(2021, 9, 4, 15, 24, 54, 883, DateTimeKind.Unspecified).AddTicks(7406), new TimeSpan(0, 0, 0, 0, 0)), "Detail 2", "https://localhost:5551/Images/UploadFiles/Default.png", "Title 2", 2 });

            migrationBuilder.InsertData(
                table: "ToDoTasks",
                columns: new[] { "Id", "Complete", "CreatedDate", "Detail", "Image", "Title", "ToDoTaskCategoryId" },
                values: new object[] { 7, false, new DateTimeOffset(new DateTime(2021, 9, 4, 15, 24, 54, 883, DateTimeKind.Unspecified).AddTicks(7436), new TimeSpan(0, 0, 0, 0, 0)), "Detail 7", "https://localhost:5551/Images/UploadFiles/Default.png", "Title 7", 2 });

            migrationBuilder.InsertData(
                table: "ToDoTasks",
                columns: new[] { "Id", "Complete", "CreatedDate", "Detail", "Image", "Title", "ToDoTaskCategoryId" },
                values: new object[] { 11, false, new DateTimeOffset(new DateTime(2021, 9, 4, 15, 24, 54, 883, DateTimeKind.Unspecified).AddTicks(7449), new TimeSpan(0, 0, 0, 0, 0)), "Detail 11", "https://localhost:5551/Images/UploadFiles/Default.png", "Title 11", 2 });

            migrationBuilder.InsertData(
                table: "ToDoTasks",
                columns: new[] { "Id", "Complete", "CreatedDate", "Detail", "Image", "Title", "ToDoTaskCategoryId" },
                values: new object[] { 12, false, new DateTimeOffset(new DateTime(2021, 9, 4, 15, 24, 54, 883, DateTimeKind.Unspecified).AddTicks(7452), new TimeSpan(0, 0, 0, 0, 0)), "Detail 12", "https://localhost:5551/Images/UploadFiles/Default.png", "Title 12", 2 });

            migrationBuilder.InsertData(
                table: "ToDoTasks",
                columns: new[] { "Id", "Complete", "CreatedDate", "Detail", "Image", "Title", "ToDoTaskCategoryId" },
                values: new object[] { 16, false, new DateTimeOffset(new DateTime(2021, 9, 4, 15, 24, 54, 883, DateTimeKind.Unspecified).AddTicks(7509), new TimeSpan(0, 0, 0, 0, 0)), "Detail 16", "https://localhost:5551/Images/UploadFiles/Default.png", "Title 16", 2 });

            migrationBuilder.InsertData(
                table: "ToDoTasks",
                columns: new[] { "Id", "Complete", "CreatedDate", "Detail", "Image", "Title", "ToDoTaskCategoryId" },
                values: new object[] { 4, false, new DateTimeOffset(new DateTime(2021, 9, 4, 15, 24, 54, 883, DateTimeKind.Unspecified).AddTicks(7424), new TimeSpan(0, 0, 0, 0, 0)), "Detail 4", "https://localhost:5551/Images/UploadFiles/Default.png", "Title 4", 3 });

            migrationBuilder.InsertData(
                table: "ToDoTasks",
                columns: new[] { "Id", "Complete", "CreatedDate", "Detail", "Image", "Title", "ToDoTaskCategoryId" },
                values: new object[] { 6, false, new DateTimeOffset(new DateTime(2021, 9, 4, 15, 24, 54, 883, DateTimeKind.Unspecified).AddTicks(7433), new TimeSpan(0, 0, 0, 0, 0)), "Detail 6", "https://localhost:5551/Images/UploadFiles/Default.png", "Title 6", 3 });

            migrationBuilder.InsertData(
                table: "ToDoTasks",
                columns: new[] { "Id", "Complete", "CreatedDate", "Detail", "Image", "Title", "ToDoTaskCategoryId" },
                values: new object[] { 9, false, new DateTimeOffset(new DateTime(2021, 9, 4, 15, 24, 54, 883, DateTimeKind.Unspecified).AddTicks(7442), new TimeSpan(0, 0, 0, 0, 0)), "Detail 9", "https://localhost:5551/Images/UploadFiles/Default.png", "Title 9", 3 });

            migrationBuilder.InsertData(
                table: "ToDoTasks",
                columns: new[] { "Id", "Complete", "CreatedDate", "Detail", "Image", "Title", "ToDoTaskCategoryId" },
                values: new object[] { 14, false, new DateTimeOffset(new DateTime(2021, 9, 4, 15, 24, 54, 883, DateTimeKind.Unspecified).AddTicks(7457), new TimeSpan(0, 0, 0, 0, 0)), "Detail 14", "https://localhost:5551/Images/UploadFiles/Default.png", "Title 14", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ToDoTasks_ToDoTaskCategoryId",
                table: "ToDoTasks",
                column: "ToDoTaskCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ToDoTasks");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ToDoTaskCategories");
        }
    }
}
