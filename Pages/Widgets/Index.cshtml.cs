using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GoogleAuthAzure.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GoogleAuthAzure.Pages.Widgets
{
    public class IndexModel : PageModel
    {
        private readonly GoogleAuthAzure.Data.ApplicationDbContext _context;

        public IndexModel(GoogleAuthAzure.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Widget> Widget { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Names { get; set; }
        
        public async Task OnGetAsync()
        {
            var widgets = from w in _context.Widget select w;

            if (!string.IsNullOrEmpty(SearchString))
            {
                widgets = widgets.Where(s => s.Name.Contains(SearchString));
            }

            Widget = await widgets.ToListAsync();
        }
    }
}
