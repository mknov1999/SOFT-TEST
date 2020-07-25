using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AV_Soft.Data;
using AV_Soft.Model;

namespace AV_Soft.Pages.Tb1
{
    public class DeleteModel : PageModel
    {
        private readonly AVSContext _context;

        public DeleteModel(AVSContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tab1 = await _context.Tab1.FindAsync(id);

            if (Tab1 != null)
            {
                _context.Tab1.Remove(Tab1);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
