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
            return await _context.Schedule.ToListAsync();
        }

        // GET: api/Schedule/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Schedule>> GetSchedule(Guid id)
        {
            var schedule = await _context.Schedule
                .Include(c => c.EmployeeContract)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (schedule == null)
            {
                return NotFound();
            }

            return schedule;
        }
        // GET: api/Schedule/ids
        // BODY: {"ids": [id1, id2, ...]}
        [HttpGet("ids")]
        public async Task<ActionResult<IEnumerable<ScheduleDTO>>> GetScheduleByIds([FromBody]IEnumerable<Guid> scheduleIds)
        {
            var schedules = await _context.Schedule
                .Include(c => c.EmployeeContract)
                .Where(c => scheduleIds.Contains(c.Id)).ToListAsync();

            var scheduleDtos = schedules.Select(c => new ScheduleDTO
            {
                Id = c.Id,
                Date = c.Date,
                Start = c.Start,
                End = c.End,
                Competences = c.ScheduleGroup.CompetenceScheduleGroups.Select(c => c.Competence.Id),
                EmployeeName = c.EmployeeContract.Employee.Name
            });

            return new ActionResult<IEnumerable<ScheduleDTO>>(scheduleDtos);
        }
        
        [HttpGet("employee/{id}")]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetSchedulesByEmployee(Guid id)
        {
            return await _context.Schedule
                .Include(c => c.EmployeeContract)
                .Where(c => c.EmployeeContract.Id == id)
                .ToListAsync();
        }
        
        [HttpGet("employee/{id}/future")]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetFutureSchedulesByEmployee(Guid id)
        {
            return await _context.Schedule
                .Include(c => c.EmployeeContract)
                .Where(c => c.EmployeeContract.Id == id && c.Start.ToUniversalTime().CompareTo(DateTime.Now.ToUniversalTime()) > 0 )
                .ToListAsync();
        }

        [HttpGet("employee/{id}/today")]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetTodaysScheduleByEmployee(Guid id)
        {
            return await _context.Schedule
                .Include(c => c.EmployeeContract)
                .Where(c => c.EmployeeContract.Employee.Id == id && c.Start.ToUniversalTime().Date == DateTime.Now.Date)
                .ToListAsync();
        }
        
        [HttpGet("employee/{id}/date/{date}")]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetScheduleByEmployeeAndDay(Guid id, DateTime date)
        {
            return await _context.Schedule
                .Include(c => c.EmployeeContract)
                .Where(c => c.EmployeeContract.Employee.Id == id && c.Start.ToUniversalTime().Date == date.ToUniversalTime().Date)
                .ToListAsync();
        }
        
        [HttpGet("contract/{id}")]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetSchedulesByContract(Guid id)
        {
            return await _context.Schedule
                .Include(c => c.EmployeeContract)
                .Where(c => c.EmployeeContract.Id == id)
                .ToListAsync();
        }
        
        [HttpGet("contract/{id}/future")]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetFutureSchedulesByContract(Guid id)
        {
            return await _context.Schedule
                .Include(c => c.EmployeeContract)
                .Where(c => c.EmployeeContract.Id == id && c.Start.ToUniversalTime().CompareTo(DateTime.Now.ToUniversalTime()) > 0 )
                .ToListAsync();
        }

        [HttpGet("contract/{id}/today")]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetTodaysScheduleByContract(Guid id)
        {
            return await _context.Schedule
                .Include(c => c.EmployeeContract)
                .Where(c => c.EmployeeContract.Id == id && c.Start.ToUniversalTime().Date == DateTime.Now.Date)
                .ToListAsync();
        }
        
        [HttpGet("contract/{id}/date/{date}")]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetScheduleByContractAndDay(Guid id, DateTime date)
        {
            return await _context.Schedule
                .Include(c => c.EmployeeContract)
                .Where(c => c.EmployeeContract.Id == id && c.Start.ToUniversalTime().Date == date.ToUniversalTime().Date)
                .ToListAsync();
        }

        // PUT: api/Schedule/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchedule(Guid id, Schedule schedule)
        {
            schedule.Id = id;

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
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Schedule
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Schedule>> PostSchedule(Schedule schedule)
        {
            schedule.Id = Guid.NewGuid();

            EmployeeContract contract = await _context.EmployeeContracts.FindAsync(schedule.EmployeeContract.Id);
            ScheduleGroup scheduleGroup = await _context.ScheduleGroup.FindAsync(schedule.ScheduleGroup.Id);

            if (contract == null)
            {
                return NotFound("Contract not Found");
            }

            if (scheduleGroup == null)
            {
                return NotFound("ScheduleGroup not Found");
            }

            schedule.EmployeeContract = contract;
            schedule.ScheduleGroup = scheduleGroup;

            _context.Schedule.Add(schedule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSchedule", new { id = schedule.Id }, schedule);
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
