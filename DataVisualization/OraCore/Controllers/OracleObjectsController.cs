using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OraCore.Models;

namespace OraCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OracleObjectsController : ControllerBase
    {
        private readonly OraDbContext _context;

        public OracleObjectsController(OraDbContext context)
        {
            _context = context;
        }

        // GET: api/OracleObjects
        [HttpGet]
        public IEnumerable<OracleObject> GetObjects()
        {
            return _context.Objects;
        }

        // GET: api/OracleObjects/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOracleObject([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var oracleObject = await _context.Objects.FindAsync(id);

            if (oracleObject == null)
            {
                return NotFound();
            }

            return Ok(oracleObject);
        }

        // PUT: api/OracleObjects/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOracleObject([FromRoute] int id, [FromBody] OracleObject oracleObject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != oracleObject.Id)
            {
                return BadRequest();
            }

            _context.Entry(oracleObject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OracleObjectExists(id))
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

        // POST: api/OracleObjects
        [HttpPost]
        public async Task<IActionResult> PostOracleObject([FromBody] OracleObject oracleObject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Objects.Add(oracleObject);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOracleObject", new { id = oracleObject.Id }, oracleObject);
        }

        // DELETE: api/OracleObjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOracleObject([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var oracleObject = await _context.Objects.FindAsync(id);
            if (oracleObject == null)
            {
                return NotFound();
            }

            _context.Objects.Remove(oracleObject);
            await _context.SaveChangesAsync();

            return Ok(oracleObject);
        }

        private bool OracleObjectExists(int id)
        {
            return _context.Objects.Any(e => e.Id == id);
        }
    }
}