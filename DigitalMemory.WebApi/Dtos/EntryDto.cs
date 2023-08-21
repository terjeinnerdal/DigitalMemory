namespace DigitalMemory.WebApi.Dtos;

public class EntryDto
{
    public EntryDto(DateOnly date, string text)
    {
        Date = date;
        Text = text;
    }

    public Guid Id { get; private set; }
    public required DateOnly Date { get; set; }
    public required string Text { get; set; }
    public ICollection<PersonDto>? Persons { get; set; }
    public ICollection<PictureDto>? Pictures { get; set; }
    public ICollection<VideoDto>? Videos { get; set; }
    public ICollection<LocationDto>? Locations { get; set; }
    public ICollection<EventDto>? Events { get; set; }
}