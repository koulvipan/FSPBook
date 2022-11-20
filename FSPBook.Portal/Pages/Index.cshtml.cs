using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using FSPBook.Data;
using FSPBook.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using JW;
using System.Net.Http;
using System;
using Newtonsoft;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace FSPBook.Pages;
public class IndexModel : PageModel
{

    private readonly Context _context;
    public IEnumerable<Post> Items { get; set; }
    public Pager pager { get; set; }
    public int TotalItems { get; set; }
    public int PageSize { get; set; }
    public int MaxPages { get; set; }

    public IndexModel(Context context)
    {
        _context = context;
    }

    public IList<Post> Posts { get; set; }
    public IList<Profile> Profile { get; set; }
    public News News { get; set; }

    public async Task OnGetAsync(int p = 1)
    {
        if (_context.Post != null)
        {
            Posts = await _context.Post.OrderByDescending(dt => dt.DateTimePosted).ToListAsync();
            TotalItems = Posts.Count();
            PageSize = 10;
            MaxPages = (TotalItems / PageSize) + 1;

            pager = new Pager(TotalItems, p, PageSize, MaxPages);
            Items = Posts.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);

            try
            {
                string Baseurl = "https://api.thenewsapi.com/v1/news/top?api_token=A1ZIkEEyiWjzyURU9HNa0rJMM3Me1D0qECgNKQf7&locale=gb&limit=5&categories=tech";
                using (var client = new HttpClient())
                {
                    HttpRequestMessage request = new HttpRequestMessage();
                    request.RequestUri = new Uri(Baseurl);
                    request.Method = HttpMethod.Get;
                    HttpResponseMessage response = await client.SendAsync(request);
                    var responseString = await response.Content.ReadAsStringAsync();
                    var statusCode = response.StatusCode;
                    if (response.IsSuccessStatusCode)
                    {
                        News = JsonConvert.DeserializeObject<News>(responseString);
                    }

                    else
                    {
                        var message = "API call failed";
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }

    public string GetAuthor(int id)
    {
        Profile = _context.Profile.ToList();
        var AuthorName = "";
        foreach (var prof in Profile)
        {
            if (prof.Id == id)
            {
                AuthorName =  prof.FullName;
                break;
            }
        }
        return AuthorName;
    }
}