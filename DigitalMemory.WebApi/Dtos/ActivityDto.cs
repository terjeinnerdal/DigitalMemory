namespace DigitalMemory.WebApi.Dtos;

public class ActivityDto
{
    public enum State
    {
        NotStarted = 0,
        Started = 1,
        Completed = 2
    }

    public ActivityDto(string name)
    {
        Name = name;
    }

    public Guid Id { get; private set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }
    public EntryDto? Entry { get; set; }
    public DiaryDto? Diary { get; set; }
    public State Status { get; set; } = State.NotStarted;
}