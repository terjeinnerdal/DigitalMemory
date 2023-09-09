using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalMemory.WebApi.Migrations;

/// <inheritdoc />
public partial class AddedDiaryToEntry : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Entries_Diaries_DiaryId",
            table: "Entries");

        migrationBuilder.AlterColumn<Guid>(
            name: "DiaryId",
            table: "Entries",
            type: "uuid",
            nullable: false,
            defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
            oldClrType: typeof(Guid),
            oldType: "uuid",
            oldNullable: true);

        migrationBuilder.AddForeignKey(
            name: "FK_Entries_Diaries_DiaryId",
            table: "Entries",
            column: "DiaryId",
            principalTable: "Diaries",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Entries_Diaries_DiaryId",
            table: "Entries");

        migrationBuilder.AlterColumn<Guid>(
            name: "DiaryId",
            table: "Entries",
            type: "uuid",
            nullable: true,
            oldClrType: typeof(Guid),
            oldType: "uuid");

        migrationBuilder.AddForeignKey(
            name: "FK_Entries_Diaries_DiaryId",
            table: "Entries",
            column: "DiaryId",
            principalTable: "Diaries",
            principalColumn: "Id");
    }
}
