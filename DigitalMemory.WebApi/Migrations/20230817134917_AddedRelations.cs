using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalMemory.WebApi.Migrations;

/// <inheritdoc />
public partial class AddedRelations : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Entries_Diary_DiaryId",
            table: "Entries");

        migrationBuilder.DropForeignKey(
            name: "FK_Persons_Entries_EntryId",
            table: "Persons");

        migrationBuilder.DropIndex(
            name: "IX_Persons_EntryId",
            table: "Persons");

        migrationBuilder.DropPrimaryKey(
            name: "PK_Diary",
            table: "Diary");

        migrationBuilder.DropColumn(
            name: "EntryId",
            table: "Persons");

        migrationBuilder.RenameTable(
            name: "Diary",
            newName: "Diaries");

        migrationBuilder.AddColumn<DateTime>(
            name: "Created",
            table: "Persons",
            type: "timestamp with time zone",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

        migrationBuilder.AddColumn<DateTime>(
            name: "Modified",
            table: "Persons",
            type: "timestamp with time zone",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

        migrationBuilder.AddColumn<DateTime>(
            name: "Created",
            table: "Entries",
            type: "timestamp with time zone",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

        migrationBuilder.AddColumn<DateTime>(
            name: "Modified",
            table: "Entries",
            type: "timestamp with time zone",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

        migrationBuilder.AddColumn<DateTime>(
            name: "Created",
            table: "Diaries",
            type: "timestamp with time zone",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

        migrationBuilder.AddColumn<DateTime>(
            name: "Modified",
            table: "Diaries",
            type: "timestamp with time zone",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

        migrationBuilder.AddPrimaryKey(
            name: "PK_Diaries",
            table: "Diaries",
            column: "Id");

        migrationBuilder.CreateTable(
            name: "Activity",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "text", nullable: false),
                Description = table.Column<string>(type: "text", nullable: true),
                Start = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                End = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                EntryId = table.Column<Guid>(type: "uuid", nullable: true),
                DiaryId = table.Column<Guid>(type: "uuid", nullable: true),
                Status = table.Column<int>(type: "integer", nullable: false),
                Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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
            name: "DiaryPerson",
            columns: table => new
            {
                DiariesId = table.Column<Guid>(type: "uuid", nullable: false),
                PersonsId = table.Column<Guid>(type: "uuid", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_DiaryPerson", x => new { x.DiariesId, x.PersonsId });
                table.ForeignKey(
                    name: "FK_DiaryPerson_Diaries_DiariesId",
                    column: x => x.DiariesId,
                    principalTable: "Diaries",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_DiaryPerson_Persons_PersonsId",
                    column: x => x.PersonsId,
                    principalTable: "Persons",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "EntryPerson",
            columns: table => new
            {
                EntriesId = table.Column<Guid>(type: "uuid", nullable: false),
                PersonsId = table.Column<Guid>(type: "uuid", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_EntryPerson", x => new { x.EntriesId, x.PersonsId });
                table.ForeignKey(
                    name: "FK_EntryPerson_Entries_EntriesId",
                    column: x => x.EntriesId,
                    principalTable: "Entries",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_EntryPerson_Persons_PersonsId",
                    column: x => x.PersonsId,
                    principalTable: "Persons",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Locations",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "text", nullable: false),
                Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Locations", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "EntryLocation",
            columns: table => new
            {
                LocationsId = table.Column<Guid>(type: "uuid", nullable: false),
                LocationsId1 = table.Column<Guid>(type: "uuid", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_EntryLocation", x => new { x.LocationsId, x.LocationsId1 });
                table.ForeignKey(
                    name: "FK_EntryLocation_Entries_LocationsId",
                    column: x => x.LocationsId,
                    principalTable: "Entries",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_EntryLocation_Locations_LocationsId1",
                    column: x => x.LocationsId1,
                    principalTable: "Locations",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Events",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "text", nullable: false),
                EntryId = table.Column<Guid>(type: "uuid", nullable: true),
                LocationsId = table.Column<Guid>(type: "uuid", nullable: true),
                Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Events", x => x.Id);
                table.ForeignKey(
                    name: "FK_Events_Entries_EntryId",
                    column: x => x.EntryId,
                    principalTable: "Entries",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_Events_Locations_LocationsId",
                    column: x => x.LocationsId,
                    principalTable: "Locations",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateTable(
            name: "Pictures",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Uri = table.Column<string>(type: "text", nullable: false),
                EntriesId = table.Column<Guid>(type: "uuid", nullable: true),
                LocationId = table.Column<Guid>(type: "uuid", nullable: true),
                Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Pictures", x => x.Id);
                table.ForeignKey(
                    name: "FK_Pictures_Entries_EntriesId",
                    column: x => x.EntriesId,
                    principalTable: "Entries",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_Pictures_Locations_LocationId",
                    column: x => x.LocationId,
                    principalTable: "Locations",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateTable(
            name: "DiaryEvent",
            columns: table => new
            {
                DiariesId = table.Column<Guid>(type: "uuid", nullable: false),
                EventsId = table.Column<Guid>(type: "uuid", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_DiaryEvent", x => new { x.DiariesId, x.EventsId });
                table.ForeignKey(
                    name: "FK_DiaryEvent_Diaries_DiariesId",
                    column: x => x.DiariesId,
                    principalTable: "Diaries",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_DiaryEvent_Events_EventsId",
                    column: x => x.EventsId,
                    principalTable: "Events",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Videos",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Uri = table.Column<string>(type: "text", nullable: false),
                EntryId = table.Column<Guid>(type: "uuid", nullable: true),
                LocationId = table.Column<Guid>(type: "uuid", nullable: true),
                EventId = table.Column<Guid>(type: "uuid", nullable: true),
                Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Videos", x => x.Id);
                table.ForeignKey(
                    name: "FK_Videos_Entries_EntryId",
                    column: x => x.EntryId,
                    principalTable: "Entries",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_Videos_Events_EventId",
                    column: x => x.EventId,
                    principalTable: "Events",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_Videos_Locations_LocationId",
                    column: x => x.LocationId,
                    principalTable: "Locations",
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
            name: "IX_DiaryEvent_EventsId",
            table: "DiaryEvent",
            column: "EventsId");

        migrationBuilder.CreateIndex(
            name: "IX_DiaryPerson_PersonsId",
            table: "DiaryPerson",
            column: "PersonsId");

        migrationBuilder.CreateIndex(
            name: "IX_EntryLocation_LocationsId1",
            table: "EntryLocation",
            column: "LocationsId1");

        migrationBuilder.CreateIndex(
            name: "IX_EntryPerson_PersonsId",
            table: "EntryPerson",
            column: "PersonsId");

        migrationBuilder.CreateIndex(
            name: "IX_EventPicture_PicturesId",
            table: "EventPicture",
            column: "PicturesId");

        migrationBuilder.CreateIndex(
            name: "IX_Events_EntryId",
            table: "Events",
            column: "EntryId");

        migrationBuilder.CreateIndex(
            name: "IX_Events_LocationsId",
            table: "Events",
            column: "LocationsId");

        migrationBuilder.CreateIndex(
            name: "IX_Pictures_EntriesId",
            table: "Pictures",
            column: "EntriesId");

        migrationBuilder.CreateIndex(
            name: "IX_Pictures_LocationId",
            table: "Pictures",
            column: "LocationId");

        migrationBuilder.CreateIndex(
            name: "IX_Videos_EntryId",
            table: "Videos",
            column: "EntryId");

        migrationBuilder.CreateIndex(
            name: "IX_Videos_EventId",
            table: "Videos",
            column: "EventId");

        migrationBuilder.CreateIndex(
            name: "IX_Videos_LocationId",
            table: "Videos",
            column: "LocationId");

        migrationBuilder.AddForeignKey(
            name: "FK_Entries_Diaries_DiaryId",
            table: "Entries",
            column: "DiaryId",
            principalTable: "Diaries",
            principalColumn: "Id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Entries_Diaries_DiaryId",
            table: "Entries");

        migrationBuilder.DropTable(
            name: "Activity");

        migrationBuilder.DropTable(
            name: "DiaryEvent");

        migrationBuilder.DropTable(
            name: "DiaryPerson");

        migrationBuilder.DropTable(
            name: "EntryLocation");

        migrationBuilder.DropTable(
            name: "EntryPerson");

        migrationBuilder.DropTable(
            name: "EventPicture");

        migrationBuilder.DropTable(
            name: "Videos");

        migrationBuilder.DropTable(
            name: "Pictures");

        migrationBuilder.DropTable(
            name: "Events");

        migrationBuilder.DropTable(
            name: "Locations");

        migrationBuilder.DropPrimaryKey(
            name: "PK_Diaries",
            table: "Diaries");

        migrationBuilder.DropColumn(
            name: "Created",
            table: "Persons");

        migrationBuilder.DropColumn(
            name: "Modified",
            table: "Persons");

        migrationBuilder.DropColumn(
            name: "Created",
            table: "Entries");

        migrationBuilder.DropColumn(
            name: "Modified",
            table: "Entries");

        migrationBuilder.DropColumn(
            name: "Created",
            table: "Diaries");

        migrationBuilder.DropColumn(
            name: "Modified",
            table: "Diaries");

        migrationBuilder.RenameTable(
            name: "Diaries",
            newName: "Diary");

        migrationBuilder.AddColumn<Guid>(
            name: "EntryId",
            table: "Persons",
            type: "uuid",
            nullable: true);

        migrationBuilder.AddPrimaryKey(
            name: "PK_Diary",
            table: "Diary",
            column: "Id");

        migrationBuilder.CreateIndex(
            name: "IX_Persons_EntryId",
            table: "Persons",
            column: "EntryId");

        migrationBuilder.AddForeignKey(
            name: "FK_Entries_Diary_DiaryId",
            table: "Entries",
            column: "DiaryId",
            principalTable: "Diary",
            principalColumn: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_Persons_Entries_EntryId",
            table: "Persons",
            column: "EntryId",
            principalTable: "Entries",
            principalColumn: "Id");
    }
}
