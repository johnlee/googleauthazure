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
    public class DeleteModel : PageModel
    {
        private readonly GoogleAuthAzure.Data.ApplicationDbContext _context;

        public DeleteModel(GoogleAuthAzure.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Widget = await _context.Widget.FindAsync(id);

            if (Widget != null)
            {
                _context.Widget.Remove(Widget);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
