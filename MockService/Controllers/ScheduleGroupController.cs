#nullable disable
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MockService.Data;
using MockService.Models;

namespace MockService.Controllers
{
    [Route("api/schedule/group/schedule")]
    [ApiController]
    public class ScheduleGroupController : ControllerBase
    {
        private readonly MockServiceContext _context;

        public ScheduleGroupController(MockServiceContext context)
        {
            _context = context;
        }

        // GET: api/ScheduleGroup
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScheduleGroup>>> GetScheduleGroup()
        {
            return await _context.ScheduleGroup.ToListAsync();
        }

        // GET: api/ScheduleGroup/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduleGroup>> GetScheduleGroup(Guid id)
        {
            var scheduleGroup = await _context.ScheduleGroup.FindAsync(id);

            if (scheduleGroup == null)
            {
                return NotFound();
            }

            return scheduleGroup;
        }

        // PUT: api/ScheduleGroup/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScheduleGroup(Guid id, ScheduleGroup scheduleGroup)
        {
            scheduleGroup.Id = id;

            _context.Entry(scheduleGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScheduleGroupExists(id))
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

        // POST: api/ScheduleGroup
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ScheduleGroup>> PostScheduleGroup(ScheduleGroup scheduleGroup)
        {
            Collection<OrganizationalUnitScheduleGroup> organizationalUnits = new Collection<OrganizationalUnitScheduleGroup>();
            foreach (var scheduleGroupOrganizationalUnit in scheduleGroup.OrganizationalUnits)
            {
                var organizationalUnit =
                    await _context.OrganizationalUnits.FindAsync(scheduleGroupOrganizationalUnit.OrganizationalUnit.Id);
                if (organizationalUnit != null)
                {
                    _context.Entry(organizationalUnit).State = EntityState.Unchanged;
                    organizationalUnits.Add(new OrganizationalUnitScheduleGroup(organizationalUnit));
                }
                else
                {
                    BadRequest("Unit " +scheduleGroupOrganizationalUnit.OrganizationalUnit.Id + " Not found");
                }
            }

            Collection<CompetenceScheduleGroup> competences = new Collection<CompetenceScheduleGroup>();
            foreach (var competenceScheduleGroup in scheduleGroup.CompetenceScheduleGroups)
            {
                var competence = await _context.Competences.FindAsync(competenceScheduleGroup.Competence.Id);
                if (competence != null)
                {
                    _context.Entry(competence).State = EntityState.Unchanged;
                    competences.Add(new CompetenceScheduleGroup(competence));
                }
                else
                {
                    BadRequest("Competence " + competenceScheduleGroup.Competence.Id + " Not found");
                }
            }

            scheduleGroup.OrganizationalUnits = organizationalUnits;
            scheduleGroup.CompetenceScheduleGroups = competences;
            

            _context.ScheduleGroup.Add(scheduleGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScheduleGroup", new { id = scheduleGroup.Id }, scheduleGroup);
        }

        // DELETE: api/ScheduleGroup/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScheduleGroup(Guid id)
        {
            var scheduleGroup = await _context.ScheduleGroup.FindAsync(id);
            if (scheduleGroup == null)
            {
                return NotFound();
            }

            _context.ScheduleGroup.Remove(scheduleGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScheduleGroupExists(Guid id)
        {
            return _context.ScheduleGroup.Any(e => e.Id == id);
        }
    }
}
