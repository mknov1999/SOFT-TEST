using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AV_Soft.Data;
using AV_Soft.Model;

namespace AV_Soft.Pages.Tb1
{
    public class CreateModel : PageModel
    {
        private readonly AVSContext _context;

        public CreateModel(AVSContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Tab1 Tab1 { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tab1.Add(Tab1);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
