﻿using Desk.Core.Queries.Intefaces;

namespace Desk.Core.Queries.Filter;

public record FilterModel : IPageFilter
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string SortBy { get; set; } = "Id";
    public bool IsAscending { get; set; }
    public string? SearchByText { get; set; }
}