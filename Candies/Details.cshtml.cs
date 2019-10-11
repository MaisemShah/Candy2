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
    public class DetailsModel : PageModel
    {
        private readonly Candy2.Data.ApplicationDbContext _context;

        public DetailsModel(Candy2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Candy Candy { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Candy = await _context.Candy
                .Include(c => c.CandStore).FirstOrDefaultAsync(m => m.CID == id);

            if (Candy == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
