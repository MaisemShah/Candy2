using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Candy2.Data;

namespace Candy2.Pages.CandStore
{
    public class CreateModel : PageModel
    {
        private readonly Candy2.Data.ApplicationDbContext _context;

        public CreateModel(Candy2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CandyStore CandyStore { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CandyStore.Add(CandyStore);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
