namespace DigitalMemory.WebApi.Dtos;

public class EntryDto : BaseDto
{
    public EntryDto(DateOnly date, string text) : base()
    {
        Date = date;
        Text = text;
    }

    public required DateOnly Date { get; set; }
    public required string Text { get; set; }
    public Guid? DiaryId { get; set; } = null;
    public DiaryDto? Diary { get; set; } = null;
    public ICollection<PersonDto>? Persons { get; set; }
    public ICollection<PictureDto>? Pictures { get; set; }
    public ICollection<VideoDto>? Videos { get; set; }
    public ICollection<LocationDto>? Locations { get; set; }
    public ICollection<EventDto>? Events { get; set; }
}