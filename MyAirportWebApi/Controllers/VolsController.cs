using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AB.AC.MyAirport.EF;

namespace MyAirportWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class VolsController : ControllerBase
    {
        private readonly AirportContext _context;

        public VolsController(AirportContext context)
        {
            _context = context;
        }

        // GET: api/Vols
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vol>>> GetVols()
        {
            return await _context.Vols.ToListAsync();
        }
        /// <summary>
        /// L'option bagages permet d'indiquer si l'on veut retourner la liste des
        /// bagages associés au vol
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bagages"></param>
        /// <returns></returns>
        // GET: api/Vols/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vol>> GetVol(int id, [FromQuery] bool bagages = false)
        {
            var vol = await _context.Vols.FindAsync(id);
            Vol volsRes;

            if (bagages == true)
            {
                volsRes = await _context.Vols.Include(v => v.Bagages).Where(v => v.ID_VOL == id).FirstAsync();
            }
            else
            {
                volsRes = await _context.Vols.FindAsync(id);
            }

            if (volsRes == null)
            {
                return NotFound();
            }

            return volsRes;
        }

        // PUT: api/Vols/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVol(int id, Vol vol)
        {
            if (id != vol.ID_VOL)
            {
                return BadRequest();
            }

            _context.Entry(vol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VolExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Vols
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Vol>> PostVol(Vol vol)
        {
            _context.Vols.Add(vol);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVol", new { id = vol.ID_VOL }, vol);
        }

        // DELETE: api/Vols/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vol>> DeleteVol(int id)
        {
            var vol = await _context.Vols.FindAsync(id);
            if (vol == null)
            {
                return NotFound();
            }

            _context.Vols.Remove(vol);
            await _context.SaveChangesAsync();

            return vol;
        }

        private bool VolExists(int id)
        {
            return _context.Vols.Any(e => e.ID_VOL == id);
        }
    }
}
