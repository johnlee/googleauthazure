using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GoogleAuthAzure.Data;
using GoogleAuthAzure.Models;

namespace GoogleAuthAzure.Pages.Widgets
{
    public class DetailsModel : PageModel
    {
        private readonly GoogleAuthAzure.Data.ApplicationDbContext _context;

        public DetailsModel(GoogleAuthAzure.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Widget Widget { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Widget = await _context.Widget.FirstOrDefaultAsync(m => m.ID == id);

            if (Widget == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
