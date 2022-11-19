﻿using FSPBook.Data;
using FSPBook.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FSPBook.Utilities;
internal static class SeedData
{
    public static void Seed(IServiceProvider serviceProvider)
    {
        using (var context = new Context(
            serviceProvider.GetRequiredService<
                DbContextOptions<Context>>()))
        {
            if (context.Profile.Count() == 0)
            {
                var profiles = new List<Profile> {
                    new Profile { Id = 1, FirstName = "Jane", LastName = "Doe", JobTitle = "Developer" },
                    new Profile { Id = 2, FirstName = "John", LastName = "Smith", JobTitle = "Consultant" },
                    new Profile { Id = 3, FirstName = "Maisie", LastName = "Jones", JobTitle = "Project Manager" },
                    new Profile { Id = 4, FirstName = "Jack", LastName = "Simpson", JobTitle = "Engagement Officer" },
                    new Profile { Id = 5, FirstName = "Sadie", LastName = "Williams", JobTitle = "Finance Director" },
                    new Profile { Id = 6, FirstName = "Pete", LastName = "Jackson", JobTitle = "Developer" },
                    new Profile { Id = 7, FirstName = "Sinead", LastName = "O'Leary", JobTitle = "Consultant" }
                };
                context.Profile.AddRange(profiles);

                var posts = new List<Post>
                {
                    new Post { Id = 1, Content = exampleText, DateTimePosted = new DateTimeOffset(2020, 11, 1, 10, 0, 0, TimeSpan.Zero), AuthorId = 1 },
                    new Post { Id = 2, Content = exampleText, DateTimePosted = new DateTimeOffset(2020, 11, 1, 15, 0, 0, TimeSpan.Zero), AuthorId = 2 },
                    new Post { Id = 3, Content = exampleText, DateTimePosted = new DateTimeOffset(2021, 9, 2, 16, 0, 0, TimeSpan.Zero), AuthorId = 3 },
                    new Post { Id = 4, Content = exampleText, DateTimePosted = new DateTimeOffset(2021, 12, 4, 16, 30, 0, TimeSpan.Zero), AuthorId = 4 },
                    new Post { Id = 5, Content = exampleText, DateTimePosted = new DateTimeOffset(2021, 12, 6, 15, 0, 0, TimeSpan.Zero), AuthorId = 5 },
                    new Post { Id = 6, Content = exampleText, DateTimePosted = new DateTimeOffset(2021, 12, 8, 12, 0, 0, TimeSpan.Zero), AuthorId = 6 },
                    new Post { Id = 7, Content = exampleText, DateTimePosted = new DateTimeOffset(2021, 12, 15, 17, 0, 0, TimeSpan.Zero), AuthorId = 7 },
                    new Post { Id = 8, Content = exampleText, DateTimePosted = new DateTimeOffset(2022, 1, 1, 11, 0, 0, TimeSpan.Zero), AuthorId = 1 },
                    new Post { Id = 9, Content = exampleText, DateTimePosted = new DateTimeOffset(2022, 2, 1, 15, 0, 0, TimeSpan.Zero), AuthorId = 2 },
                    new Post { Id = 10, Content = exampleText, DateTimePosted = new DateTimeOffset(2022, 3, 1, 15, 0, 0, TimeSpan.Zero), AuthorId = 3 },
                    new Post { Id = 11, Content = exampleText, DateTimePosted = new DateTimeOffset(2022, 4, 1, 15, 0, 0, TimeSpan.Zero), AuthorId = 4 },
                    new Post { Id = 12, Content = exampleText, DateTimePosted = new DateTimeOffset(2022, 5, 5, 15, 0, 0, TimeSpan.Zero), AuthorId = 5 },
                    new Post { Id = 13, Content = exampleText, DateTimePosted = new DateTimeOffset(2022, 5, 6, 15, 0, 0, TimeSpan.Zero), AuthorId = 6 },
                    new Post { Id = 14, Content = exampleText, DateTimePosted = new DateTimeOffset(2022, 5, 6, 17, 30, 0, TimeSpan.Zero), AuthorId = 7 },
                    new Post { Id = 15, Content = exampleText, DateTimePosted = new DateTimeOffset(2022, 6, 1, 15, 0, 0, TimeSpan.Zero), AuthorId = 1 }
                };

                context.Post.AddRange(posts);

                context.SaveChanges();
            }
        }
    }

    private static string exampleText = "Lorem Ipsum is simply dummy text of the printing and typesetting " +
        "industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an " +
        "unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived " +
        "not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.";
}
