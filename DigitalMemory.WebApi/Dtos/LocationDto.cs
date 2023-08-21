namespace DigitalMemory.WebApi.Dtos;

public class LocationDto
{
    public LocationDto(string name) => Name = name;

    public Guid Id { get; private set; }
    public required string Name { get; set; }
    public string? LatitudeLongitude { get; set; }
    //public ICollection<EntryDto>? Entries { get; set; }
    //public ICollection<VideoDto>? Videos { get; set; }
    //public ICollection<PictureDto>? Pictures { get; set; }
    //public ICollection<EventDto>? Events { get; set; }
}