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
    [Route("api/item")]
    [ApiController]
    public class IteminVideosforUserController : ControllerBase
    {
        private readonly youtubeappContext _context;

        public IteminVideosforUserController(youtubeappContext context)
        {
            _context = context;
        }

        // GET: api/IteminVideosforUser
        [HttpGet]
        public IEnumerable<IteminVideosforUser> GetIteminVideosforUser()
        {
            return _context.IteminVideosforUser;
        }

        // GET: api/IteminVideosforUser/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIteminVideosforUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var iteminVideosforUser = await _context.IteminVideosforUser.Where(c =>  c.UserId == id).ToArrayAsync();

            if (iteminVideosforUser == null)
            {
                return NotFound();
            }

            return Ok(iteminVideosforUser);
        }

        // PUT: api/IteminVideosforUser/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIteminVideosforUser([FromRoute] int id, [FromBody] IteminVideosforUser iteminVideosforUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != iteminVideosforUser.UserId)
            {
                return BadRequest();
            }

            _context.Entry(iteminVideosforUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IteminVideosforUserExists(id))
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

        // POST: api/IteminVideosforUser
        [HttpPost]
        public async Task<IActionResult> PostIteminVideosforUser([FromBody] IteminVideosforUser iteminVideosforUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.IteminVideosforUser.Add(iteminVideosforUser);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (IteminVideosforUserExists(iteminVideosforUser.UserId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetIteminVideosforUser", new { id = iteminVideosforUser.UserId }, iteminVideosforUser);
        }

        // DELETE: api/IteminVideosforUser/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIteminVideosforUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var iteminVideosforUser = await _context.IteminVideosforUser.FindAsync(id);
            if (iteminVideosforUser == null)
            {
                return NotFound();
            }

            _context.IteminVideosforUser.Remove(iteminVideosforUser);
            await _context.SaveChangesAsync();

            return Ok(iteminVideosforUser);
        }

        private bool IteminVideosforUserExists(int id)
        {
            return _context.IteminVideosforUser.Any(e => e.UserId == id);
        }
    }
}