using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AV_Soft.Data;
using AV_Soft.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AV_Soft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HTMLController : ControllerBase
    {
        AVSContext db;
        public HTMLController(AVSContext context)
        {
            db = context;
            if (!db.Tab2.Any())
            {
                var provider = new Provider(db);
                provider.GetDataTab2();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tab2>>> Get()
        {
            return await db.Tab2.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tab2>> Get(int id)
        {
            Tab2 tab2 = await db.Tab2.FirstOrDefaultAsync(x => x.ID == id);
            if (tab2 == null)
                return NotFound();
            return new ObjectResult(tab2);
        }

        [HttpPost]
        public async Task<ActionResult<Tab2>> Post(Tab2 tab2)
        {
            if (tab2 == null)
            {
                return BadRequest();
            }

            db.Tab2.Add(tab2);
            await db.SaveChangesAsync();
            return Ok(tab2);
        }
    }
}
