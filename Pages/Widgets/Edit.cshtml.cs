using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoogleAuthAzure.Data;
using GoogleAuthAzure.Models;

namespace GoogleAuthAzure.Pages.Widgets
{
    public class EditModel : PageModel
    {
        private readonly GoogleAuthAzure.Data.ApplicationDbContext _context;

        public EditModel(GoogleAuthAzure.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Widget).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WidgetExists(Widget.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WidgetExists(int id)
        {
            return _context.Widget.Any(e => e.ID == id);
        }
    }
}
