﻿namespace DigitalMemory.WebApi.Models;

public class Activity(string name) : EntityBase
{
    public enum State
    {
        NotStarted = 0,
        Started = 1,
        Completed = 2
    }

    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; } = name;
    public string? Description { get; set; }
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }
    public Entry? Entry { get; set; }
    public Diary? Diary { get; set; }
    public State Status { get; set; } = State.NotStarted;
}