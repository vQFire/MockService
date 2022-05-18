#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MockService.Data;
using MockService.Models;

namespace MockService.Controllers
{
    [Route("api/unit")]
    [ApiController]
    public class OrganizationalUnitController : ControllerBase
    {
        private readonly MockServiceContext _context;

        public OrganizationalUnitController(MockServiceContext context)
        {
            _context = context;
        }

        // GET: api/OrganizationalUnit
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrganizationalUnit>>> GetOrganizationalUnits()
        {
            return await _context.OrganizationalUnits.ToListAsync();
        }

        // GET: api/OrganizationalUnit/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrganizationalUnit>> GetOrganizationalUnit(Guid id)
        {
            var organizationalUnit = await _context.OrganizationalUnits.FindAsync(id);

            if (organizationalUnit == null)
            {
                return NotFound();
            }

            return organizationalUnit;
        }

        // PUT: api/OrganizationalUnit/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganizationalUnit(Guid id, OrganizationalUnit organizationalUnit)
        {
            organizationalUnit.Id = id;

            _context.Entry(organizationalUnit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizationalUnitExists(id))
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

        // POST: api/OrganizationalUnit
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrganizationalUnit>> PostOrganizationalUnit(OrganizationalUnit organizationalUnit)
        {
            _context.OrganizationalUnits.Add(organizationalUnit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrganizationalUnit", new { id = organizationalUnit.Id }, organizationalUnit);
        }

        // DELETE: api/OrganizationalUnit/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganizationalUnit(Guid id)
        {
            var organizationalUnit = await _context.OrganizationalUnits.FindAsync(id);
            if (organizationalUnit == null)
            {
                return NotFound();
            }

            _context.OrganizationalUnits.Remove(organizationalUnit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrganizationalUnitExists(Guid id)
        {
            return _context.OrganizationalUnits.Any(e => e.Id == id);
        }
    }
}
