// <copyright file="Chapter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Studio.Domain.Chapters;

using Studio.Domain.Common;

public class Chapter : StudioEntity
{
    /// <summary>
    /// Gets or sets the description of the chapter.
    /// </summary>
    public string? Description { get; set; }

    public Chapter(
        string title)
        : base(title)
    {
        this.Title = title;
    }
}
