using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalMemory.WebApi.Migrations;

/// <inheritdoc />
public partial class RenamedLocationPropertyToEntries : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_EntryLocation_Entries_LocationsId",
            table: "EntryLocation");

        migrationBuilder.DropForeignKey(
            name: "FK_EntryLocation_Locations_LocationsId1",
            table: "EntryLocation");

        migrationBuilder.DropPrimaryKey(
            name: "PK_EntryLocation",
            table: "EntryLocation");

        migrationBuilder.DropIndex(
            name: "IX_EntryLocation_LocationsId1",
            table: "EntryLocation");

        migrationBuilder.RenameColumn(
            name: "LocationsId1",
            table: "EntryLocation",
            newName: "EntriesId");

        migrationBuilder.AddPrimaryKey(
            name: "PK_EntryLocation",
            table: "EntryLocation",
            columns: new[] { "EntriesId", "LocationsId" });

        migrationBuilder.CreateIndex(
            name: "IX_EntryLocation_LocationsId",
            table: "EntryLocation",
            column: "LocationsId");

        migrationBuilder.AddForeignKey(
            name: "FK_EntryLocation_Entries_EntriesId",
            table: "EntryLocation",
            column: "EntriesId",
            principalTable: "Entries",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);

        migrationBuilder.AddForeignKey(
            name: "FK_EntryLocation_Locations_LocationsId",
            table: "EntryLocation",
            column: "LocationsId",
            principalTable: "Locations",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_EntryLocation_Entries_EntriesId",
            table: "EntryLocation");

        migrationBuilder.DropForeignKey(
            name: "FK_EntryLocation_Locations_LocationsId",
            table: "EntryLocation");

        migrationBuilder.DropPrimaryKey(
            name: "PK_EntryLocation",
            table: "EntryLocation");

        migrationBuilder.DropIndex(
            name: "IX_EntryLocation_LocationsId",
            table: "EntryLocation");

        migrationBuilder.RenameColumn(
            name: "EntriesId",
            table: "EntryLocation",
            newName: "LocationsId1");

        migrationBuilder.AddPrimaryKey(
            name: "PK_EntryLocation",
            table: "EntryLocation",
            columns: new[] { "LocationsId", "LocationsId1" });

        migrationBuilder.CreateIndex(
            name: "IX_EntryLocation_LocationsId1",
            table: "EntryLocation",
            column: "LocationsId1");

        migrationBuilder.AddForeignKey(
            name: "FK_EntryLocation_Entries_LocationsId",
            table: "EntryLocation",
            column: "LocationsId",
            principalTable: "Entries",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);

        migrationBuilder.AddForeignKey(
            name: "FK_EntryLocation_Locations_LocationsId1",
            table: "EntryLocation",
            column: "LocationsId1",
            principalTable: "Locations",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }
}
