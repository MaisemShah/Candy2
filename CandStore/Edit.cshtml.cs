using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Candy2.Data;

namespace Candy2.Pages.CandStore
{
    public class EditModel : PageModel
    {
        private readonly Candy2.Data.ApplicationDbContext _context;

        public EditModel(Candy2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CandyStore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandyStoreExists(CandyStore.CSID))
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

        private bool CandyStoreExists(int id)
        {
            return _context.CandyStore.Any(e => e.CSID == id);
        }
    }
}
