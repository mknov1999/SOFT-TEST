using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AV_Soft.Data;
using AV_Soft.Model;

namespace AV_Soft
{
    [Route("{controller = Home}/{action=Index}/{id?}")]
    public class Tab2Controller : Controller
    {
        private readonly AVSContext _context;

        public Tab2Controller(AVSContext context)
        {
            _context = context;
            if (!_context.Tab2.Any())
            {
                var provider = new Provider(_context);
                provider.GetDataTab2();
            }
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tab2.ToListAsync());
        }
    }
}
