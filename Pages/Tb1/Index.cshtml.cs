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
    public class IndexModel : PageModel
    {
        private readonly AVSContext _context;

        public IndexModel(AVSContext context)
        {
            _context = context;
        }

        public IList<Tab1> Tab1 { get;set; }
        public string FilterValue { get; set; }
        public string FilterKey { get; set; }
        public async Task OnGetAsync(string searchValue, string searchKey)
        {
            FilterValue = searchValue;
            FilterKey = searchKey;

            var keys = new Provider(_context).GetDataTab1();

            if (!String.IsNullOrEmpty(searchValue))
            {
                keys = keys.Where(s => s.VALUE.ToString().Contains(searchValue));
            }
            if (!String.IsNullOrEmpty(searchKey))
            {
                keys = keys.Where(s => s.KEY.ToString().Contains(searchKey));
            }
            Tab1 = await keys.AsNoTracking().ToListAsync();
        }
    }
}
