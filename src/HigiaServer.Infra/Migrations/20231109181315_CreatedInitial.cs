using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HigiaServer.Infra.Migrations
{
    /// <inheritdoc />
    public partial class CreatedInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "task",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    initial_coordinate = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                    final_coordinate = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                    description = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                    observation = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                    InitialTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    expected_end_time = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    end_time = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    start_time = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_task", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_admin = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    first_name = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                    last_name = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                    address = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                    birthday = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    phone_number = table.Column<string>(type: "NVARCHAR(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "task_user",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    task_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_task_user", x => new { x.user_id, x.task_id });
                    table.ForeignKey(
                        name: "FK_task_user_task_task_id",
                        column: x => x.task_id,
                        principalTable: "task",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_task_user_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_task_id",
                table: "task",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_task_user_task_id",
                table: "task_user",
                column: "task_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_id",
                table: "user",
                column: "id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "task_user");

            migrationBuilder.DropTable(
                name: "task");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
