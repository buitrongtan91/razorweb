using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using webappEF.Models;

namespace webappEF.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly MyBlogContext _myBlogContext;

    public IndexModel(ILogger<IndexModel> logger, MyBlogContext myBlogContext)
    {
        _logger = logger;
        _myBlogContext = myBlogContext;
    }

    public void OnGet()
    {
        var posts = _myBlogContext.Articles.ToList();
        ViewData["Posts"] = posts;
    }
}
