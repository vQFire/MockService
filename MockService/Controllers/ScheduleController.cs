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
    [Route("api/schedule")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly MockServiceContext _context;

        public ScheduleController(MockServiceContext context)
        {
            _context = context;
        }

        // GET: api/Schedule
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetSchedules()
        {
            return await _context.Schedule.Include(c => c.ScheduleGroup.CompetenceScheduleGroups).ThenInclude(c => c.Competence).Include(c => c.EmployeeContract.Employee).ToListAsync();
        }

        // GET: api/Schedule/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Schedule>> GetSchedule(Guid id)
        {
            var schedule = await _context.Schedule
                .Include(c => c.EmployeeContract.Employee)
                .Include(c => c.ScheduleGroup.CompetenceScheduleGroups)
                .ThenInclude(c => c.Competence)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (schedule == null)
            {
                return NotFound();
            }

            return schedule;
        }
        // GET: api/Schedule/ids
        // BODY: {"scheduleIds": [id1, id2, ...]}
        [HttpPost("ids")]
        public async Task<ActionResult<IEnumerable<TradeOfferScheduleDTO>>> GetScheduleByIds([FromBody]IEnumerable<Guid> scheduleIds)
        {
            var schedules = await _context.Schedule
                .Include(c => c.EmployeeContract.Employee)
                .Include(c => c.ScheduleGroup.CompetenceScheduleGroups)
                .ThenInclude(c => c.Competence)
                .Where(c => scheduleIds.Contains(c.Id)).ToListAsync();

            var scheduleDtos = schedules.Select(c => new TradeOfferScheduleDTO
            {
                Id = c.Id,
                Date = c.Date,
                Start = c.Start,
                End = c.End,
                Competences = c.ScheduleGroup.CompetenceScheduleGroups.Select(d => d.Competence.Id),
                EmployeeId = c.EmployeeContract.Employee.Id,
                EmployeeName = $"{c.EmployeeContract.Employee.FirstName} {c.EmployeeContract.Employee.Name}"
            });

            return new ActionResult<IEnumerable<TradeOfferScheduleDTO>>(scheduleDtos);
        }
        
        [HttpGet("employee/{id}")]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetSchedulesByEmployee(Guid id)
        {
            return await _context.Schedule
                .Include(c => c.EmployeeContract)
                .Include(c => c.ScheduleGroup.CompetenceScheduleGroups).ThenInclude(c => c.Competence)
                .Where(c => c.EmployeeContract.Id == id)
                .ToListAsync();
        }
        
        [HttpGet("employee/{id}/future")]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetFutureSchedulesByEmployee(Guid id)
        {
            return await _context.Schedule
                .Include(c => c.EmployeeContract)
                .Include(c => c.ScheduleGroup.CompetenceScheduleGroups).ThenInclude(c => c.Competence)
                .Where(c => c.EmployeeContract.Id == id && c.Start.ToUniversalTime().CompareTo(DateTime.Now.ToUniversalTime()) > 0 )
                .ToListAsync();
        }

        [HttpGet("employee/{id}/today")]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetTodaysScheduleByEmployee(Guid id)
        {
            return await _context.Schedule
                .Include(c => c.EmployeeContract)
                .Include(c => c.ScheduleGroup.CompetenceScheduleGroups).ThenInclude(c => c.Competence)
                .Where(c => c.EmployeeContract.Employee.Id == id && c.Start.ToUniversalTime().Date == DateTime.Now.Date)
                .ToListAsync();
        }
        
        [HttpGet("employee/{id}/date/{date}")]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetScheduleByEmployeeAndDay(Guid id, DateTime date)
        {
            return await _context.Schedule
                .Include(c => c.EmployeeContract)
                .Include(c => c.ScheduleGroup.CompetenceScheduleGroups).ThenInclude(c => c.Competence)
                .Where(c => c.EmployeeContract.Employee.Id == id && c.Start.ToUniversalTime().Date == date.ToUniversalTime().Date)
                .ToListAsync();
        }
        
        [HttpGet("contract/{id}")]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetSchedulesByContract(Guid id)
        {
            return await _context.Schedule
                .Include(c => c.EmployeeContract)
                .Include(c => c.ScheduleGroup.CompetenceScheduleGroups).ThenInclude(c => c.Competence)
                .Where(c => c.EmployeeContract.Id == id)
                .ToListAsync();
        }
        
        [HttpGet("contract/{id}/future")]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetFutureSchedulesByContract(Guid id)
        {
            return await _context.Schedule
                .Include(c => c.EmployeeContract)
                .Include(c => c.ScheduleGroup.CompetenceScheduleGroups).ThenInclude(c => c.Competence)
                .Where(c => c.EmployeeContract.Id == id && c.Start.ToUniversalTime().CompareTo(DateTime.Now.ToUniversalTime()) > 0 )
                .ToListAsync();
        }

        [HttpGet("contract/{id}/today")]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetTodaysScheduleByContract(Guid id)
        {
            return await _context.Schedule
                .Include(c => c.EmployeeContract)
                .Include(c => c.ScheduleGroup.CompetenceScheduleGroups).ThenInclude(c => c.Competence)
                .Where(c => c.EmployeeContract.Id == id && c.Start.ToUniversalTime().Date == DateTime.Now.Date)
                .ToListAsync();
        }
        
        [HttpGet("contract/{id}/date/{date}")]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetScheduleByContractAndDay(Guid id, DateTime date)
        {
            return await _context.Schedule
                .Include(c => c.EmployeeContract)
                .Include(c => c.ScheduleGroup.CompetenceScheduleGroups).ThenInclude(c => c.Competence)
                .Where(c => c.EmployeeContract.Id == id && c.Start.ToUniversalTime().Date == date.ToUniversalTime().Date)
                .ToListAsync();
        }

        // PUT: api/Schedule/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchedule(Guid id, CreateScheduleDTO scheduleDto)
        {
            var schedule = await _context.Schedule.FindAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }
            schedule.EmployeeContractId = scheduleDto.EmployeeContractId;
            schedule.ScheduleGroupId = scheduleDto.ScheduleGroupId;
            schedule.ScheduleType = scheduleDto.ScheduleType;
            schedule.Date = scheduleDto.Date;
            schedule.Start = scheduleDto.Start;
            schedule.End = scheduleDto.End;
            schedule.HasChanged = true;

            _context.Entry(schedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScheduleExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return Ok();
        }

        // POST: api/Schedule
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Schedule>> PostSchedule(CreateScheduleDTO schedule)
        {
            EmployeeContract contract = await _context.EmployeeContracts.FindAsync(schedule.EmployeeContractId);
            ScheduleGroup scheduleGroup = await _context.ScheduleGroup.FindAsync(schedule.ScheduleGroupId);

            if (contract == null)
            {
                return NotFound("Contract not Found");
            }

            if (scheduleGroup == null)
            {
                return NotFound("ScheduleGroup not Found");
            }

            Schedule newSchedule = new Schedule
            {
                Id = Guid.NewGuid(),
                EmployeeContract = contract,
                ScheduleGroup = scheduleGroup,
                Start = schedule.Start,
                End = schedule.End
            };

            await _context.Schedule.AddAsync(newSchedule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSchedule", new { id = newSchedule.Id }, newSchedule);
        }

        // DELETE: api/Schedule/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchedule(Guid id)
        {
            var schedule = await _context.Schedule.FindAsync(id);

            if (schedule == null)
            {
                return NotFound();
            }

            _context.Schedule.Remove(schedule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScheduleExists(Guid id)
        {
            return _context.Schedule.Any(e => e.Id == id);
        }
    }
}
