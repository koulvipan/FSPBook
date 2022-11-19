using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using FSPBook.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using JW;
using System.Net.Http;
using System;

namespace FSPBook.Pages;
public class IndexModel : PageModel
{

    private readonly FSPBook.Data.Context _context;
    public IEnumerable<Post> Items { get; set; }
    public Pager pager { get; set; }
    public int TotalItems { get; set; }
    public int PageSize { get; set; }
    public int MaxPages { get; set; }

    public IndexModel(FSPBook.Data.Context context)
    {
        _context = context;
    }

    public IList<Post> Post { get; set; }
    public IList<Profile> Profile { get; set; }

    public async Task OnGetAsync(int p = 1)
    {
        if (_context.Post != null)
        {
            Post = await _context.Post.OrderByDescending(dt => dt.DateTimePosted).ToListAsync();
            TotalItems = Post.Count();
            PageSize = 10;
            MaxPages = (TotalItems / PageSize) + 1;

            pager = new Pager(TotalItems, p, PageSize, MaxPages);
            Items = Post.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);

            //try
            //{
            //    string Baseurl = "GET https://api.thenewsapi.com/v1/news/top?api_token=A1ZIkEEyiWjzyURU9HNa0rJMM3Me1D0qECgNKQf7&locale=gb&limit=5";
            //    using (var client = new HttpClient())
            //    {
            //        HttpRequestMessage request = new HttpRequestMessage();
            //        request.RequestUri = new Uri(Baseurl);
            //        request.Method = HttpMethod.Get;
            //        HttpResponseMessage response = await client.SendAsync(request);
            //        var responseString = await response.Content.ReadAsStringAsync();
            //        var statusCode = response.StatusCode;
            //        if (response.IsSuccessStatusCode)
            //        {
                        
            //        }

            //        else
            //        {
            //            //API Call Failed, Check Error Details
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{

            //    throw;
            //}
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