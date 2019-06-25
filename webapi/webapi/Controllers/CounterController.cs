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
    [Route("api/counter")]
    [ApiController]
    public class CounterController : ControllerBase
    {
        private readonly youtubeappContext _context;

        public CounterController(youtubeappContext context)
        {
            _context = context;
        }

        // GET: api/Counter
        [HttpGet]
        public IEnumerable<Counter> GetCounter()
        {
            return _context.Counter;
        }

        // GET: api/Counter/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCounter([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var counter = await _context.Counter.FindAsync(id);

            if (counter == null)
            {
                return NotFound();
            }

            return Ok(counter);
        }

        // PUT: api/Counter/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCounter([FromRoute] string id, [FromBody] Counter counter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != counter.Type)
            {
                return BadRequest();
            }

            _context.Entry(counter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CounterExists(id))
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

        // POST: api/Counter
        [HttpPost]
        public async Task<IActionResult> PostCounter([FromBody] Counter counter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Counter.Add(counter);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CounterExists(counter.Type))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCounter", new { id = counter.Type }, counter);
        }

        // DELETE: api/Counter/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCounter([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var counter = await _context.Counter.FindAsync(id);
            if (counter == null)
            {
                return NotFound();
            }

            _context.Counter.Remove(counter);
            await _context.SaveChangesAsync();

            return Ok(counter);
        }

        private bool CounterExists(string id)
        {
            return _context.Counter.Any(e => e.Type == id);
        }
    }
}