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
    public class DetailsModel : PageModel
    {
        private readonly Mediatheque.Core.DAL.ApplicationDbContext _context;

        public DetailsModel(Mediatheque.Core.DAL.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
