#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MockService.Data;
using MockService.Dtos;
using MockService.Models;

namespace MockService.Controllers
{
    [Route("api/competence")]
    [ApiController]
    public class CompetenceController : ControllerBase
    {
        private readonly MockServiceContext _context;

        public CompetenceController(MockServiceContext context)
        {
            _context = context;
        }

        // GET: api/Competence
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Competence>>> GetCompetences()
        {
            return await _context.Competences.ToListAsync();
        }

        // GET: api/Competence/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Competence>> GetCompetence(Guid id)
        {
            var competence = await _context.Competences.FindAsync(id);

            if (competence == null)
            {
                return NotFound();
            }

            return competence;
        }

        // PUT: api/Competence/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompetence(Guid id, Competence competence)
        {
            competence.Id = id;

            _context.Entry(competence).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompetenceExists(id))
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

        // POST: api/Competence
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Competence>> PostCompetence(CreateCompetenceDTO competence)
        {
            var id = Guid.NewGuid();
            var newCompetence = new Competence
            {
                Id = id,
                Code = competence.Code,
                Name = competence.Name
            };
            
            _context.Competences.Add(newCompetence);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompetence", new { id = newCompetence.Id }, newCompetence);
        }

        // DELETE: api/Competence/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompetence(Guid id)
        {
            var competence = await _context.Competences.FindAsync(id);
            if (competence == null)
            {
                return NotFound();
            }

            _context.Competences.Remove(competence);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompetenceExists(Guid id)
        {
            return _context.Competences.Any(e => e.Id == id);
        }
    }
}
