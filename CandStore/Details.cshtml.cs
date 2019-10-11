using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Candy2.Data;

namespace Candy2.Pages.CandStore
{
    public class DetailsModel : PageModel
    {
        private readonly Candy2.Data.ApplicationDbContext _context;

        public DetailsModel(Candy2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public CandyStore CandyStore { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CandyStore = await _context.CandyStore.FirstOrDefaultAsync(m => m.CSID == id);

            if (CandyStore == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
