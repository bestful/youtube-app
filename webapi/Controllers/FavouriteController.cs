using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouriteController : ControllerBase
    {
        private readonly youtubeappContect _context;

        public FavouriteController(youtubeappContect context)
        {
            _context = context;
        }

        // GET: api/Favourite
        [HttpGet]
        public IEnumerable<Favourite> GetFavourite()
        {
            return _context.Favourite;
        }

        // GET: api/Favourite/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFavourite([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var favourite = await _context.Favourite.FindAsync(id);

            if (favourite == null)
            {
                return NotFound();
            }

            return Ok(favourite);
        }

        // PUT: api/Favourite/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavourite([FromRoute] int id, [FromBody] Favourite favourite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != favourite.Id)
            {
                return BadRequest();
            }

            _context.Entry(favourite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavouriteExists(id))
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

        // POST: api/Favourite
        [HttpPost]
        public async Task<IActionResult> PostFavourite([FromBody] Favourite favourite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Favourite.Add(favourite);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFavourite", new { id = favourite.Id }, favourite);
        }

        // DELETE: api/Favourite/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavourite([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var favourite = await _context.Favourite.FindAsync(id);
            if (favourite == null)
            {
                return NotFound();
            }

            _context.Favourite.Remove(favourite);
            await _context.SaveChangesAsync();

            return Ok(favourite);
        }

        private bool FavouriteExists(int id)
        {
            return _context.Favourite.Any(e => e.Id == id);
        }
    }
}