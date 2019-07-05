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
    [Route("api/favourite")]
    [ApiController]
    public class FavouriteController : ControllerBase
    {
        private readonly youtubeappContext _context;

        public FavouriteController(youtubeappContext context)
        {
            _context = context;
            // _context.Favourite.Load();
        }

        // GET: api/Favourite
        // <summary>
        // Get allfavourite list
        // </summary>
        [HttpGet]
        public IEnumerable<Favourite> GetFavourite()
        {
            return _context.Favourite;
        }

        // GET: api/Favourite/5
        // <summary>
        // Get favourite list for selected user with mark
        // </summary>
        [HttpGet("{user_id}")]
        public async Task<ActionResult> GetFavourite([FromRoute] int user_id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var favourite = _context.Favourite.Where(o => o.UserId == user_id)
                            .Join(_context.VoteforVideo, 
                            favor => new {favor.VideoId, favor.UserId}, 
                            vote => new {vote.VideoId, vote.UserId},
                            (a, b) => new {a.UserId, a.VideoId, a.Link, a.Title, a.Thubmail, a.Description, a.Avg, mark = b.Mark})
                            .ToArray();

            if (favourite == null)
            {
                return NotFound();
            }

            return Ok(favourite);
        }

        // // PUT: api/Favourite/5
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutFavourite([FromRoute] int id, [FromBody] Favourite favourite)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }

        //     if (id != favourite.Id)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(favourite).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!FavouriteExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return NoContent();
        // }

        // // POST: api/Favourite
        // [HttpPost]
        // public async Task<IActionResult> PostFavourite([FromBody] Favourite favourite)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }

        //     _context.Favourite.Add(favourite);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("GetFavourite", new { id = favourite.Id }, favourite);
        // }

        // // DELETE: api/Favourite/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteFavourite([FromRoute] int id)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }

        //     var favourite = await _context.Favourite.FindAsync(id);
        //     if (favourite == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Favourite.Remove(favourite);
        //     await _context.SaveChangesAsync();

        //     return Ok(favourite);
        // }

        private bool FavouriteExists(int id)
        {
            return _context.Favourite.Any(e => e.UserId == id);
        }
    }
}