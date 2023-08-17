namespace Models
{
    public class Video : EntityBase
    {
        public Video(Uri uri) => Uri = uri;

        public Guid Id { get; set; } = Guid.NewGuid();
        public Uri Uri { get; set; }
        public Entry? Entry { get; set; }
        public Location? Location { get; set; }
        public Event? Event { get; set; }
    }
}