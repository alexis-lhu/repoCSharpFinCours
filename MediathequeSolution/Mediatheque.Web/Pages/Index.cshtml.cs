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
    public class IndexModel : PageModel
    {
        private readonly Mediatheque.Core.DAL.ApplicationDbContext _context;

        public IndexModel(Mediatheque.Core.DAL.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Dvd> Dvd { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Dvd = await _context.Dvd.ToListAsync();
        }
    }
}
