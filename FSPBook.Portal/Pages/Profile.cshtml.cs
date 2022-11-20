using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FSPBook.Data;
using FSPBook.Data.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace FSPBook.Portal.Pages
{
    public class ProfileModel : PageModel
    {
        private readonly Context _context;

        public ProfileModel(Context context)
        {
            _context = context;
        }
        public Profile Profile { get; set; }
        public IList<Post> Posts { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Profile == null)
            {
                return NotFound();
            }

            var profile = await _context.Profile.FirstOrDefaultAsync(m => m.Id == id);
            if (profile == null)
            {
                return NotFound();
            }
            else
            {
                Profile = profile;
                Posts = await _context.Post.OrderByDescending(dt => dt.DateTimePosted).Where(profile => profile.AuthorId == id).ToListAsync();
                
            }
            return Page();
        }
    }
}
