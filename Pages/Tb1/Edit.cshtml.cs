using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AV_Soft.Data;
using AV_Soft.Model;

namespace AV_Soft.Pages.Tb1
{
    public class EditModel : PageModel
    {
        private readonly AVSContext _context;

        public EditModel(AVSContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tab1 Tab1 { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tab1 = await _context.Tab1.FirstOrDefaultAsync(m => m.ID == id);

            if (Tab1 == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Tab1).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tab1Exists(Tab1.ID))
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

        private bool Tab1Exists(int id)
        {
            return _context.Tab1.Any(e => e.ID == id);
        }
    }
}
