namespace Models
{
    public class Entry : EntityBase
    {
        public Entry(DateOnly date, string text)
        {
            Date = date;
            Text = text;
        }

        public required DateOnly Date { get; set; }
        public required string Text { get; set; }
        public ICollection<Person>? Persons { get; set; }
        public ICollection<Picture>? Pictures { get; set; }
        public ICollection<Video>? Videos { get; set; }
        public ICollection<Location>? Locations { get; set; }
    }
}