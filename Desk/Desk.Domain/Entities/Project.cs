﻿namespace Desk.Domain.Entities;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
}