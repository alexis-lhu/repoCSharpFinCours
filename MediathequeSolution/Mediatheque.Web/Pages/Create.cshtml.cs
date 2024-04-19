using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mediatheque.Core.DAL;
using Mediatheque.Core.Model;

namespace Mediatheque.Web.Pages
{
    public class CreateModel : PageModel
    {
        private readonly Mediatheque.Core.DAL.ApplicationDbContext _context;

        public CreateModel(Mediatheque.Core.DAL.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Dvd Dvd { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Dvd.Add(Dvd);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
