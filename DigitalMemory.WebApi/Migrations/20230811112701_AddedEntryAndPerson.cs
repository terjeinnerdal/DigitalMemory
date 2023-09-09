using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalMemory.WebApi.Migrations;

/// <inheritdoc />
public partial class AddedEntryAndPerson : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Entry_Diary_DiaryId",
            table: "Entry");

        migrationBuilder.DropForeignKey(
            name: "FK_Person_Entry_EntryId",
            table: "Person");

        migrationBuilder.DropPrimaryKey(
            name: "PK_Person",
            table: "Person");

        migrationBuilder.DropPrimaryKey(
            name: "PK_Entry",
            table: "Entry");

        migrationBuilder.RenameTable(
            name: "Person",
            newName: "Persons");

        migrationBuilder.RenameTable(
            name: "Entry",
            newName: "Entries");

        migrationBuilder.RenameIndex(
            name: "IX_Person_EntryId",
            table: "Persons",
            newName: "IX_Persons_EntryId");

        migrationBuilder.RenameIndex(
            name: "IX_Entry_DiaryId",
            table: "Entries",
            newName: "IX_Entries_DiaryId");

        migrationBuilder.AddPrimaryKey(
            name: "PK_Persons",
            table: "Persons",
            column: "Id");

        migrationBuilder.AddPrimaryKey(
            name: "PK_Entries",
            table: "Entries",
            column: "Id");

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

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Entries_Diary_DiaryId",
            table: "Entries");

        migrationBuilder.DropForeignKey(
            name: "FK_Persons_Entries_EntryId",
            table: "Persons");

        migrationBuilder.DropPrimaryKey(
            name: "PK_Persons",
            table: "Persons");

        migrationBuilder.DropPrimaryKey(
            name: "PK_Entries",
            table: "Entries");

        migrationBuilder.RenameTable(
            name: "Persons",
            newName: "Person");

        migrationBuilder.RenameTable(
            name: "Entries",
            newName: "Entry");

        migrationBuilder.RenameIndex(
            name: "IX_Persons_EntryId",
            table: "Person",
            newName: "IX_Person_EntryId");

        migrationBuilder.RenameIndex(
            name: "IX_Entries_DiaryId",
            table: "Entry",
            newName: "IX_Entry_DiaryId");

        migrationBuilder.AddPrimaryKey(
            name: "PK_Person",
            table: "Person",
            column: "Id");

        migrationBuilder.AddPrimaryKey(
            name: "PK_Entry",
            table: "Entry",
            column: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_Entry_Diary_DiaryId",
            table: "Entry",
            column: "DiaryId",
            principalTable: "Diary",
            principalColumn: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_Person_Entry_EntryId",
            table: "Person",
            column: "EntryId",
            principalTable: "Entry",
            principalColumn: "Id");
    }
}
