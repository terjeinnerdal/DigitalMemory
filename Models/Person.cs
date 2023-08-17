using System.Collections;

namespace Models
{
    public class Person : EntityBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }
        public ICollection<Entry>? Entries { get; set; }
        public ICollection<Diary>? Diaries { get; set; }
    }
}