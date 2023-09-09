﻿// <auto-generated />
using System;
using DigitalMemory.WebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DigitalMemory.WebApi.Migrations;

[DbContext(typeof(DigitalMemoryWebApiContext))]
[Migration("20230901032019_FixedPersonClass")]
partial class FixedPersonClass
{
    /// <inheritdoc />
    protected override void BuildTargetModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder
            .HasAnnotation("ProductVersion", "7.0.10")
            .HasAnnotation("Relational:MaxIdentifierLength", 63);

        NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

        modelBuilder.Entity("DiaryEvent", b =>
            {
                b.Property<Guid>("DiariesId")
                    .HasColumnType("uuid");

                b.Property<Guid>("EventsId")
                    .HasColumnType("uuid");

                b.HasKey("DiariesId", "EventsId");

                b.HasIndex("EventsId");

                b.ToTable("DiaryEvent");
            });

        modelBuilder.Entity("DiaryPerson", b =>
            {
                b.Property<Guid>("DiariesId")
                    .HasColumnType("uuid");

                b.Property<Guid>("PersonsId")
                    .HasColumnType("uuid");

                b.HasKey("DiariesId", "PersonsId");

                b.HasIndex("PersonsId");

                b.ToTable("DiaryPerson");
            });

        modelBuilder.Entity("DigitalMemory.Models.Activity", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property<DateTime>("Created")
                    .HasColumnType("timestamp with time zone");

                b.Property<string>("Description")
                    .HasColumnType("text");

                b.Property<Guid?>("DiaryId")
                    .HasColumnType("uuid");

                b.Property<DateTime?>("End")
                    .HasColumnType("timestamp with time zone");

                b.Property<Guid?>("EntryId")
                    .HasColumnType("uuid");

                b.Property<DateTime?>("Modified")
                    .HasColumnType("timestamp with time zone");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("text");

                b.Property<DateTime?>("Start")
                    .HasColumnType("timestamp with time zone");

                b.Property<int>("Status")
                    .HasColumnType("integer");

                b.HasKey("Id");

                b.HasIndex("DiaryId");

                b.HasIndex("EntryId");

                b.ToTable("Activity");
            });

        modelBuilder.Entity("DigitalMemory.Models.Diary", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property<DateTime>("Created")
                    .HasColumnType("timestamp with time zone");

                b.Property<DateTime?>("Modified")
                    .HasColumnType("timestamp with time zone");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("text");

                b.HasKey("Id");

                b.ToTable("Diaries");
            });

        modelBuilder.Entity("DigitalMemory.Models.Entry", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property<DateTime>("Created")
                    .HasColumnType("timestamp with time zone");

                b.Property<DateOnly>("Date")
                    .HasColumnType("date");

                b.Property<Guid?>("DiaryId")
                    .HasColumnType("uuid");

                b.Property<DateTime?>("Modified")
                    .HasColumnType("timestamp with time zone");

                b.Property<string>("Text")
                    .IsRequired()
                    .HasColumnType("text");

                b.HasKey("Id");

                b.HasIndex("DiaryId");

                b.ToTable("Entries");
            });

        modelBuilder.Entity("DigitalMemory.Models.Event", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property<DateTime>("Created")
                    .HasColumnType("timestamp with time zone");

                b.Property<Guid?>("EntryId")
                    .HasColumnType("uuid");

                b.Property<Guid?>("LocationsId")
                    .HasColumnType("uuid");

                b.Property<DateTime?>("Modified")
                    .HasColumnType("timestamp with time zone");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("text");

                b.HasKey("Id");

                b.HasIndex("EntryId");

                b.HasIndex("LocationsId");

                b.ToTable("Events");
            });

        modelBuilder.Entity("DigitalMemory.Models.Location", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property<DateTime>("Created")
                    .HasColumnType("timestamp with time zone");

                b.Property<DateTime?>("Modified")
                    .HasColumnType("timestamp with time zone");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("text");

                b.HasKey("Id");

                b.ToTable("Locations");
            });

        modelBuilder.Entity("DigitalMemory.Models.Person", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property<DateTime>("Created")
                    .HasColumnType("timestamp with time zone");

                b.Property<DateTime?>("Modified")
                    .HasColumnType("timestamp with time zone");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("text");

                b.HasKey("Id");

                b.ToTable("Persons");
            });

        modelBuilder.Entity("DigitalMemory.Models.Picture", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property<DateTime>("Created")
                    .HasColumnType("timestamp with time zone");

                b.Property<Guid?>("EntriesId")
                    .HasColumnType("uuid");

                b.Property<Guid?>("LocationId")
                    .HasColumnType("uuid");

                b.Property<DateTime?>("Modified")
                    .HasColumnType("timestamp with time zone");

                b.Property<string>("Uri")
                    .IsRequired()
                    .HasColumnType("text");

                b.HasKey("Id");

                b.HasIndex("EntriesId");

                b.HasIndex("LocationId");

                b.ToTable("Pictures");
            });

        modelBuilder.Entity("DigitalMemory.Models.Video", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property<DateTime>("Created")
                    .HasColumnType("timestamp with time zone");

                b.Property<Guid?>("EntryId")
                    .HasColumnType("uuid");

                b.Property<Guid?>("EventId")
                    .HasColumnType("uuid");

                b.Property<Guid?>("LocationId")
                    .HasColumnType("uuid");

                b.Property<DateTime?>("Modified")
                    .HasColumnType("timestamp with time zone");

                b.Property<string>("Uri")
                    .IsRequired()
                    .HasColumnType("text");

                b.HasKey("Id");

                b.HasIndex("EntryId");

                b.HasIndex("EventId");

                b.HasIndex("LocationId");

                b.ToTable("Videos");
            });

        modelBuilder.Entity("EntryLocation", b =>
            {
                b.Property<Guid>("EntriesId")
                    .HasColumnType("uuid");

                b.Property<Guid>("LocationsId")
                    .HasColumnType("uuid");

                b.HasKey("EntriesId", "LocationsId");

                b.HasIndex("LocationsId");

                b.ToTable("EntryLocation");
            });

        modelBuilder.Entity("EntryPerson", b =>
            {
                b.Property<Guid>("EntriesId")
                    .HasColumnType("uuid");

                b.Property<Guid>("PersonsId")
                    .HasColumnType("uuid");

                b.HasKey("EntriesId", "PersonsId");

                b.HasIndex("PersonsId");

                b.ToTable("EntryPerson");
            });

        modelBuilder.Entity("EventPicture", b =>
            {
                b.Property<Guid>("EventsId")
                    .HasColumnType("uuid");

                b.Property<Guid>("PicturesId")
                    .HasColumnType("uuid");

                b.HasKey("EventsId", "PicturesId");

                b.HasIndex("PicturesId");

                b.ToTable("EventPicture");
            });

        modelBuilder.Entity("DiaryEvent", b =>
            {
                b.HasOne("DigitalMemory.Models.Diary", null)
                    .WithMany()
                    .HasForeignKey("DiariesId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("DigitalMemory.Models.Event", null)
                    .WithMany()
                    .HasForeignKey("EventsId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

        modelBuilder.Entity("DiaryPerson", b =>
            {
                b.HasOne("DigitalMemory.Models.Diary", null)
                    .WithMany()
                    .HasForeignKey("DiariesId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("DigitalMemory.Models.Person", null)
                    .WithMany()
                    .HasForeignKey("PersonsId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

        modelBuilder.Entity("DigitalMemory.Models.Activity", b =>
            {
                b.HasOne("DigitalMemory.Models.Diary", "Diary")
                    .WithMany("Activities")
                    .HasForeignKey("DiaryId");

                b.HasOne("DigitalMemory.Models.Entry", "Entry")
                    .WithMany()
                    .HasForeignKey("EntryId");

                b.Navigation("Diary");

                b.Navigation("Entry");
            });

        modelBuilder.Entity("DigitalMemory.Models.Entry", b =>
            {
                b.HasOne("DigitalMemory.Models.Diary", null)
                    .WithMany("Entries")
                    .HasForeignKey("DiaryId");
            });

        modelBuilder.Entity("DigitalMemory.Models.Event", b =>
            {
                b.HasOne("DigitalMemory.Models.Entry", "Entry")
                    .WithMany("Events")
                    .HasForeignKey("EntryId");

                b.HasOne("DigitalMemory.Models.Location", "Locations")
                    .WithMany("Events")
                    .HasForeignKey("LocationsId");

                b.Navigation("Entry");

                b.Navigation("Locations");
            });

        modelBuilder.Entity("DigitalMemory.Models.Picture", b =>
            {
                b.HasOne("DigitalMemory.Models.Entry", "Entries")
                    .WithMany("Pictures")
                    .HasForeignKey("EntriesId");

                b.HasOne("DigitalMemory.Models.Location", "Location")
                    .WithMany("Pictures")
                    .HasForeignKey("LocationId");

                b.Navigation("Entries");

                b.Navigation("Location");
            });

        modelBuilder.Entity("DigitalMemory.Models.Video", b =>
            {
                b.HasOne("DigitalMemory.Models.Entry", "Entry")
                    .WithMany("Videos")
                    .HasForeignKey("EntryId");

                b.HasOne("DigitalMemory.Models.Event", "Event")
                    .WithMany("Videos")
                    .HasForeignKey("EventId");

                b.HasOne("DigitalMemory.Models.Location", "Location")
                    .WithMany("Videos")
                    .HasForeignKey("LocationId");

                b.Navigation("Entry");

                b.Navigation("Event");

                b.Navigation("Location");
            });

        modelBuilder.Entity("EntryLocation", b =>
            {
                b.HasOne("DigitalMemory.Models.Entry", null)
                    .WithMany()
                    .HasForeignKey("EntriesId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("DigitalMemory.Models.Location", null)
                    .WithMany()
                    .HasForeignKey("LocationsId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

        modelBuilder.Entity("EntryPerson", b =>
            {
                b.HasOne("DigitalMemory.Models.Entry", null)
                    .WithMany()
                    .HasForeignKey("EntriesId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("DigitalMemory.Models.Person", null)
                    .WithMany()
                    .HasForeignKey("PersonsId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

        modelBuilder.Entity("EventPicture", b =>
            {
                b.HasOne("DigitalMemory.Models.Event", null)
                    .WithMany()
                    .HasForeignKey("EventsId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("DigitalMemory.Models.Picture", null)
                    .WithMany()
                    .HasForeignKey("PicturesId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

        modelBuilder.Entity("DigitalMemory.Models.Diary", b =>
            {
                b.Navigation("Activities");

                b.Navigation("Entries");
            });

        modelBuilder.Entity("DigitalMemory.Models.Entry", b =>
            {
                b.Navigation("Events");

                b.Navigation("Pictures");

                b.Navigation("Videos");
            });

        modelBuilder.Entity("DigitalMemory.Models.Event", b =>
            {
                b.Navigation("Videos");
            });

        modelBuilder.Entity("DigitalMemory.Models.Location", b =>
            {
                b.Navigation("Events");

                b.Navigation("Pictures");

                b.Navigation("Videos");
            });
#pragma warning restore 612, 618
    }
}
