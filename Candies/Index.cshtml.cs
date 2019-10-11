using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Candy2.Data;

namespace Candy2.Pages.Candies
{
    public class IndexModel : PageModel
    {
        private readonly Candy2.Data.ApplicationDbContext _context;

        public IndexModel(Candy2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Candy> Candy { get;set; }

        public async Task OnGetAsync()
        {
            Candy = await _context.Candy
                .Include(c => c.CandStore).ToListAsync();
        }
    }
}
