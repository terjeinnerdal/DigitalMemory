namespace DigitalMemory.WebApi.Dtos;

public class PersonDto
{
    //public PersonDto(Guid id)
    //{
    //    Id = id;
    //}
    public Guid Id { get; private set; }
    public required string Name { get; set; }
    //public ICollection<EntryDto>? Entries { get; set; }
    //public ICollection<DiaryDto>? Diaries { get; set; }
}