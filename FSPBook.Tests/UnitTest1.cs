using FSPBook.Data;
using FSPBook.Data.Entities;
using FSPBook.Pages;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System;
using Xunit;
using FSPBook.Tests;

namespace FSPBook.Tests
{
    public class UnitTest1
    {
        public Profile profile { get; set; }
        public Post post { get; set; }

        [Fact]
        public void PostDataBaseEntryTestCase()
        {
            using (var db = new Context(Utilities.TestDbContextOptions()))
            {
                // Arrange
                var expectedMessage = "Hello How are you";
                var post = new Post { Id = 1, Content = expectedMessage, DateTimePosted = DateTimeOffset.Now, AuthorId = 1 };

                db.Post.Add(post);
                db.SaveChanges();

                // Act
                post = db.Post.FirstOrDefault();

                // Assert
                var actualMessage = Assert.IsAssignableFrom<string>(post.Content);
                Assert.Equal(expectedMessage, actualMessage);
            }
        }
        [Fact]
        public void ProfileDataBaseEntryTestCase()
        {
            using (var db = new Context(Utilities.TestDbContextOptions()))
            {
                // Arrange
                var firstname = "Jane";
                var lastname = "Doe";
                var jobtitle = "Developer";
                var fullname = "Jane Doe";
                var profile = new Profile { Id = 1, FirstName = firstname, LastName = lastname, JobTitle = jobtitle };

                db.Profile.Add(profile);
                db.SaveChanges();

                // Act
                profile = db.Profile.FirstOrDefault();

                // Assert
                var actualfirstname = Assert.IsAssignableFrom<string>(profile.FirstName);
                var actuallastname = Assert.IsAssignableFrom<string>(profile.LastName);
                var actualjobtitle = Assert.IsAssignableFrom<string>(profile.JobTitle);
                var actualfullname = Assert.IsAssignableFrom<string>(profile.FullName);
                Assert.Equal(firstname,actualfirstname);
                Assert.Equal(lastname, actuallastname);
                Assert.Equal(jobtitle, actualjobtitle);
                Assert.Equal(fullname, actualfullname);
            }

        }
    }
}