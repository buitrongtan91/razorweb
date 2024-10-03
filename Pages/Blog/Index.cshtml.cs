using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using webappEF.Models;

namespace webappEF.Pages_Blog
{
    public class IndexModel : PageModel
    {
        private readonly webappEF.Models.MyBlogContext _context;

        public IndexModel(webappEF.Models.MyBlogContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get; set; } = default!;

        public async Task OnGetAsync(string SearchString)
        {
            // Article = await _context.Articles.ToListAsync();
            var query = from a in _context.Articles
                        orderby a.CreatedAt descending
                        select a;

            if (!string.IsNullOrEmpty(SearchString))
            {
                Article = query.Where(a => a.Title.Contains(SearchString)).ToList();

            }
            else
            {
                Article = await query.ToListAsync();
            }


        }
    }
}
