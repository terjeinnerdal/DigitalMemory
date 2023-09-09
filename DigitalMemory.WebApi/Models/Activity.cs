namespace DigitalMemory.WebApi.Models;

/// <summary>
/// This class is not directly related to a Diary. It's for keeping things
/// you need to remember in the future. Basically a todo list.
/// </summary>
public class Activity : EntityBase
{
    public enum State
    {
        NotStarted = 0,
        Started = 1,
        Completed = 2
    }

    public Activity(string name)
    {
        Name = name;
    }

    public required string Name { get; set; }
    public string? Description { get; set; }
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }
    public State Status { get; set; } = State.NotStarted;
}