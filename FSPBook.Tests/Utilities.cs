using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FSPBook.Data;
using FSPBook.Data.Entities;
using FSPBook.Pages;

namespace FSPBook.Tests
{
    public static class Utilities
    {
        public static DbContextOptions<Context> TestDbContextOptions()
        {
            // New service provider for a new in-memory database.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance using an in-memory database and 
            // IServiceProvider that the context should resolve all of its 
            // services from.
            var builder = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase("TestInMemoryDB")
                .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }
    }
}