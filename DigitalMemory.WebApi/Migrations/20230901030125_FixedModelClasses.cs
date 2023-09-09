using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalMemory.WebApi.Migrations;

/// <inheritdoc />
public partial class FixedModelClasses : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<DateTime>(
            name: "Modified",
            table: "Videos",
            type: "timestamp with time zone",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "timestamp with time zone");

        migrationBuilder.AlterColumn<DateTime>(
            name: "Modified",
            table: "Pictures",
            type: "timestamp with time zone",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "timestamp with time zone");

        migrationBuilder.AlterColumn<DateTime>(
            name: "Modified",
            table: "Persons",
            type: "timestamp with time zone",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "timestamp with time zone");

        migrationBuilder.AlterColumn<DateTime>(
            name: "Modified",
            table: "Locations",
            type: "timestamp with time zone",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "timestamp with time zone");

        migrationBuilder.AlterColumn<DateTime>(
            name: "Modified",
            table: "Events",
            type: "timestamp with time zone",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "timestamp with time zone");

        migrationBuilder.AlterColumn<DateTime>(
            name: "Modified",
            table: "Entries",
            type: "timestamp with time zone",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "timestamp with time zone");

        migrationBuilder.AlterColumn<DateTime>(
            name: "Modified",
            table: "Diaries",
            type: "timestamp with time zone",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "timestamp with time zone");

        migrationBuilder.AlterColumn<DateTime>(
            name: "Modified",
            table: "Activity",
            type: "timestamp with time zone",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "timestamp with time zone");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<DateTime>(
            name: "Modified",
            table: "Videos",
            type: "timestamp with time zone",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "timestamp with time zone",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "Modified",
            table: "Pictures",
            type: "timestamp with time zone",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "timestamp with time zone",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "Modified",
            table: "Persons",
            type: "timestamp with time zone",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "timestamp with time zone",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "Modified",
            table: "Locations",
            type: "timestamp with time zone",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "timestamp with time zone",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "Modified",
            table: "Events",
            type: "timestamp with time zone",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "timestamp with time zone",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "Modified",
            table: "Entries",
            type: "timestamp with time zone",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "timestamp with time zone",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "Modified",
            table: "Diaries",
            type: "timestamp with time zone",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "timestamp with time zone",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "Modified",
            table: "Activity",
            type: "timestamp with time zone",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "timestamp with time zone",
            oldNullable: true);
    }
}
