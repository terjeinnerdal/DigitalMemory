using Microsoft.EntityFrameworkCore;
using Models;

namespace DigitalMemory.WebApi.Data
{
    public sealed class DigitalMemoryWebApiContext : DbContext
    {
        public DigitalMemoryWebApiContext (DbContextOptions<DigitalMemoryWebApiContext> options)
            : base(options)
        {
        }

        public DbSet<Diary> Diaries { get; set; } = default!;
        public DbSet<Entry> Entries { get; set; } = default!;
        public DbSet<Person> Persons { get; set; } = default!;
        public DbSet<Location> Locations { get; set; } = default!;
        public DbSet<Event> Events { get; set; } = default!;
        public DbSet<Video> Videos { get; set; } = default!;
        public DbSet<Picture> Pictures { get; set; } = default!;
    }
}
