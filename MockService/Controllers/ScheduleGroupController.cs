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
using MockService.Dtos;
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
            return await _context.ScheduleGroup
                .Include(c => c.OrganizationalUnits).ThenInclude(c => c.OrganizationalUnit)
                .Include(c => c.CompetenceScheduleGroups).ThenInclude(c => c.Competence)
                .Include(c => c.ScheduleGroupSchedules)
                .ToListAsync();
        }

        // GET: api/ScheduleGroup/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduleGroup>> GetScheduleGroup(Guid id)
        {
            var scheduleGroup = await _context.ScheduleGroup
                .Include(c => c.OrganizationalUnits).ThenInclude(c => c.OrganizationalUnit)
                .Include(c => c.CompetenceScheduleGroups).ThenInclude(c => c.Competence)
                .Include(c => c.ScheduleGroupSchedules)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (scheduleGroup == null)
            {
                return NotFound();
            }

            return scheduleGroup;
        }
        
        [HttpGet("unit/{id}")]
        public async Task<ActionResult<IEnumerable<ScheduleGroup>>> GetScheduleGroupByUnit(Guid id)
        {
            return await _context.ScheduleGroup
                .Include(c => c.OrganizationalUnits).ThenInclude(c => c.OrganizationalUnit)
                .Include(c => c.CompetenceScheduleGroups).ThenInclude(c => c.Competence)
                .Include(c => c.ScheduleGroupSchedules)
                .Where(c => c.OrganizationalUnits.Any(u => u.OrganizationalUnit.Id == id))
                .ToListAsync();
        }
        
        [HttpGet("competence/{id}")]
        public async Task<ActionResult<IEnumerable<ScheduleGroup>>> GetScheduleGroupByCompetence(Guid id)
        {
            return await _context.ScheduleGroup
                .Include(c => c.OrganizationalUnits).ThenInclude(c => c.OrganizationalUnit)
                .Include(c => c.CompetenceScheduleGroups).ThenInclude(c => c.Competence)
                .Include(c => c.ScheduleGroupSchedules)
                .Where(c => c.CompetenceScheduleGroups.Any(u => u.Competence.Id == id))
                .ToListAsync();
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
        public async Task<ActionResult<ScheduleGroup>> PostScheduleGroup(CreateScheduleGroupDTO scheduleGroup)
        {
            Collection<OrganizationalUnitScheduleGroup> organizationalUnits = new Collection<OrganizationalUnitScheduleGroup>();
            foreach (var scheduleGroupOrganizationalUnitID in scheduleGroup.OrganizationalUnitIDs)
            {
                var organizationalUnit =
                    await _context.OrganizationalUnits.FindAsync(scheduleGroupOrganizationalUnitID);
                if (organizationalUnit != null)
                {
                    _context.Entry(organizationalUnit).State = EntityState.Unchanged;
                    organizationalUnits.Add(new OrganizationalUnitScheduleGroup(organizationalUnit));
                }
                else
                {
                    BadRequest("Unit " +scheduleGroupOrganizationalUnitID + " Not found");
                }
            }

            Collection<CompetenceScheduleGroup> competences = new Collection<CompetenceScheduleGroup>();
            foreach (var competenceScheduleGroupID in scheduleGroup.CompetenceScheduleGroupIds)
            {
                var competence = await _context.Competences.FindAsync(competenceScheduleGroupID);
                if (competence != null)
                {
                    _context.Entry(competence).State = EntityState.Unchanged;
                    competences.Add(new CompetenceScheduleGroup(competence));
                }
                else
                {
                    BadRequest("Competence " + competenceScheduleGroupID + " Not found");
                }
            }

            var newScheduleGroup = new ScheduleGroup();
            newScheduleGroup.OrganizationalUnits = organizationalUnits;
            newScheduleGroup.CompetenceScheduleGroups = competences;
            newScheduleGroup.Description = scheduleGroup.Description;
            newScheduleGroup.Id = Guid.NewGuid();
            newScheduleGroup.IgnoreInCalculations = scheduleGroup.IgnoreInCalculations;

            _context.ScheduleGroup.Add(newScheduleGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScheduleGroup", new { id = newScheduleGroup.Id }, newScheduleGroup);
        }

        // DELETE: api/ScheduleGroup/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScheduleGroup(Guid id)
        {
            var scheduleGroup = await _context.ScheduleGroup
                .Include(c => c.OrganizationalUnits)
                .Include(c => c.CompetenceScheduleGroups)
                .FirstOrDefaultAsync(c => c.Id == id);
            
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
