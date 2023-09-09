namespace DigitalMemory.WebApi.Models;

public class Video : EntityBase
{
    public Video(Uri uri) => Uri = uri;
    public Uri Uri { get; set; }
}