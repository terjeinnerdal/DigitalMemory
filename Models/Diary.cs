//namespace DigitalMemory.Models
//{
//    // todo: Will it be wise to make entry a owned entity of Diary?
//    // This would mean that every entry get lazyloaded when fetching a diary.
//    public class Diary : EntityBase
//    {
//        public Diary(string name) : base() => Name = name;

//        public required string Name { get; set; }
//        public string? Description { get; set; }
//        public ICollection<Entry>? Entries { get; set; } // todo: Owned?
//        //public ICollection<Activity>? Activities { get; set; }
//        public ICollection<Person>? Persons { get; set; }
//        public ICollection<Event>? Events { get; set; } // todo: Owned?
//    }
//}