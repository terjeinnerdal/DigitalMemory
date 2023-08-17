using System.Collections.Generic;

namespace Models
{
    public class Event : EntityBase
    {
        public Event(string name) => Name = name;

        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }
        public Entry? Entry { get; set; }
        public Location? Locations { get; set; }
        public ICollection<Video>? Videos { get; set; }
        public ICollection<Diary>? Diaries { get; set; }
        public ICollection<Picture>? Pictures { get; set; }
    }
}