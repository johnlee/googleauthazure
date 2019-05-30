using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GoogleAuthAzure.Data;
using GoogleAuthAzure.Models;

namespace GoogleAuthAzure.Pages.Widgets
{
    public class CreateModel : PageModel
    {
        private readonly GoogleAuthAzure.Data.ApplicationDbContext _context;

        public CreateModel(GoogleAuthAzure.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Widget Widget { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Widget.Add(Widget);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}