namespace DigitalMemory.WebApi.Dtos;

public class PictureDto
{
    public PictureDto(Guid id, Uri uri) 
    {
        Uri = uri;
        Id = id;
    }

    public Guid Id { get; private set; }
    public Uri Uri { get; set; }
    //public EntryDto? Entry { get; set; }
    //public LocationDto? Location { get; set; }
    //public ICollection<EventDto>? Events { get; set; }
}