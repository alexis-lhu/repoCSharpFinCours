using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mediatheque.Core.DAL;
using Mediatheque.Core.Model;

namespace Mediatheque.Web.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly Mediatheque.Core.DAL.ApplicationDbContext _context;

        public DeleteModel(Mediatheque.Core.DAL.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Dvd Dvd { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dvd = await _context.Dvd.FirstOrDefaultAsync(m => m.Id == id);

            if (dvd == null)
            {
                return NotFound();
            }
            else
            {
                Dvd = dvd;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dvd = await _context.Dvd.FindAsync(id);
            if (dvd != null)
            {
                Dvd = dvd;
                _context.Dvd.Remove(Dvd);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
