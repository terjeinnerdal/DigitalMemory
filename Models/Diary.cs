namespace Models
{
    public class Diary : EntityBase
    {
        public Diary(string name) => Name = name;

        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }
        public ICollection<Entry>? Entries { get; set; }
        public ICollection<Activity>? Activities { get; set; }
        public ICollection<Person>? Persons { get; set; }
        public ICollection<Event>? Events { get; set; }
    }
}