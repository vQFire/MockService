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
    [Route("api/schedule/group")]
    [ApiController]
    public class GroupScheduleController : ControllerBase
    {
        private readonly MockServiceContext _context;

        public GroupScheduleController(MockServiceContext context)
        {
            _context = context;
        }

        // GET: api/GroupSchedule
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScheduleGroupSchedule>>> GetScheduleGroupSchedule()
        {
            return await _context.ScheduleGroupSchedule
                .Include(c => c.ScheduleGroup.OrganizationalUnits)
                .Include(c => c.ScheduleGroup.Competences)
                .ToListAsync();
        }

        // GET: api/GroupSchedule/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduleGroupSchedule>> GetScheduleGroupSchedule(Guid id)
        {
            var scheduleGroupSchedule = await _context.ScheduleGroupSchedule
                .Include(c => c.ScheduleGroup.OrganizationalUnits)
                .Include(c => c.ScheduleGroup.Competences)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (scheduleGroupSchedule == null)
            {
                return NotFound();
            }

            return scheduleGroupSchedule;
        }

        // PUT: api/GroupSchedule/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScheduleGroupSchedule(Guid id, ScheduleGroupSchedule scheduleGroupSchedule)
        {
            scheduleGroupSchedule.Id = id;

            _context.Entry(scheduleGroupSchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScheduleGroupScheduleExists(id))
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

        // POST: api/GroupSchedule
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ScheduleGroupSchedule>> PostScheduleGroupSchedule(CreateGroupScheduleDTO scheduleGroupSchedule)
        {
            var id = Guid.NewGuid();
            var scheduleGroup = await _context.ScheduleGroup
                .Include(c => c.OrganizationalUnits)
                .Include(c => c.Competences)
                .FirstOrDefaultAsync(c => c.Id == scheduleGroupSchedule.ScheduleGroupId);

            if (scheduleGroup == null)
            {
                return NotFound("ScheduleGroup not Found");
            }

            var newScheduleGroupSchedule = new ScheduleGroupSchedule
            {
                Id = id,
                ScheduleGroup = scheduleGroup,
                ScheduleType = scheduleGroupSchedule.ScheduleType,
                Start = scheduleGroupSchedule.StartDate,
                End = scheduleGroupSchedule.EndDate,
            };
            
            _context.ScheduleGroupSchedule.Add(newScheduleGroupSchedule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScheduleGroupSchedule", new { id = newScheduleGroupSchedule.Id }, newScheduleGroupSchedule);
        }

        // DELETE: api/GroupSchedule/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScheduleGroupSchedule(Guid id)
        {
            var scheduleGroupSchedule = await _context.ScheduleGroupSchedule.FindAsync(id);
            if (scheduleGroupSchedule == null)
            {
                return NotFound();
            }

            _context.ScheduleGroupSchedule.Remove(scheduleGroupSchedule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScheduleGroupScheduleExists(Guid id)
        {
            return _context.ScheduleGroupSchedule.Any(e => e.Id == id);
        }
    }
}
