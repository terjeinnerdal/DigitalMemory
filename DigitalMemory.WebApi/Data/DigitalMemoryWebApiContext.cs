using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalMemory.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalMemory.WebApi.Data;

public sealed class DigitalMemoryWebApiContext(DbContextOptions<DigitalMemoryWebApiContext> options) : DbContext(options)
{
    public DbSet<Diary> Diaries { get; set; } = default!;
    public DbSet<Entry> Entries { get; set; } = default!;
    public DbSet<Person> Persons { get; set; } = default!;
    public DbSet<Location> Locations { get; set; } = default!;
    public DbSet<Event> Events { get; set; } = default!;
    public DbSet<Video> Videos { get; set; } = default!;
    public DbSet<Picture> Pictures { get; set; } = default!;
}
