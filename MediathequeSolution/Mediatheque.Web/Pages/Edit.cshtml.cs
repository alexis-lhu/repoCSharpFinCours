using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mediatheque.Core.DAL;
using Mediatheque.Core.Model;

namespace Mediatheque.Web.Pages
{
    public class EditModel : PageModel
    {
        private readonly Mediatheque.Core.DAL.ApplicationDbContext _context;

        public EditModel(Mediatheque.Core.DAL.ApplicationDbContext context)
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

            var dvd =  await _context.Dvd.FirstOrDefaultAsync(m => m.Id == id);
            if (dvd == null)
            {
                return NotFound();
            }
            Dvd = dvd;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Dvd).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DvdExists(Dvd.Id))
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

        private bool DvdExists(int id)
        {
            return _context.Dvd.Any(e => e.Id == id);
        }
    }
}
