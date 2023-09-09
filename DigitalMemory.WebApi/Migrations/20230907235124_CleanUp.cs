using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalMemory.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class CleanUp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Diaries_DiaryId",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Entries_EntriesId",
                table: "Pictures");

            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "EventPicture");

            migrationBuilder.RenameColumn(
                name: "EntriesId",
                table: "Pictures",
                newName: "EventId");

            migrationBuilder.RenameIndex(
                name: "IX_Pictures_EntriesId",
                table: "Pictures",
                newName: "IX_Pictures_EventId");

            migrationBuilder.AddColumn<Guid>(
                name: "EntryId",
                table: "Pictures",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "Persons",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AlterColumn<Guid>(
                name: "DiaryId",
                table: "Entries",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Diaries",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_EntryId",
                table: "Pictures",
                column: "EntryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Diaries_DiaryId",
                table: "Entries",
                column: "DiaryId",
                principalTable: "Diaries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Entries_EntryId",
                table: "Pictures",
                column: "EntryId",
                principalTable: "Entries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Events_EventId",
                table: "Pictures",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Diaries_DiaryId",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Entries_EntryId",
                table: "Pictures");

            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Events_EventId",
                table: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_Pictures_EntryId",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "EntryId",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Diaries");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "Pictures",
                newName: "EntriesId");

            migrationBuilder.RenameIndex(
                name: "IX_Pictures_EventId",
                table: "Pictures",
                newName: "IX_Pictures_EntriesId");

            migrationBuilder.AlterColumn<Guid>(
                name: "DiaryId",
                table: "Entries",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DiaryId = table.Column<Guid>(type: "uuid", nullable: true),
                    EntryId = table.Column<Guid>(type: "uuid", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    End = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Start = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activity_Diaries_DiaryId",
                        column: x => x.DiaryId,
                        principalTable: "Diaries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Activity_Entries_EntryId",
                        column: x => x.EntryId,
                        principalTable: "Entries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EventPicture",
                columns: table => new
                {
                    EventsId = table.Column<Guid>(type: "uuid", nullable: false),
                    PicturesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPicture", x => new { x.EventsId, x.PicturesId });
                    table.ForeignKey(
                        name: "FK_EventPicture_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventPicture_Pictures_PicturesId",
                        column: x => x.PicturesId,
                        principalTable: "Pictures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_DiaryId",
                table: "Activity",
                column: "DiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_EntryId",
                table: "Activity",
                column: "EntryId");

            migrationBuilder.CreateIndex(
                name: "IX_EventPicture_PicturesId",
                table: "EventPicture",
                column: "PicturesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Diaries_DiaryId",
                table: "Entries",
                column: "DiaryId",
                principalTable: "Diaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Entries_EntriesId",
                table: "Pictures",
                column: "EntriesId",
                principalTable: "Entries",
                principalColumn: "Id");
        }
    }
}
