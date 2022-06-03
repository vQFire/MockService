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
    [Route("api/employee/competence")]
    [ApiController]
    public class EmployeeCompetenceController : ControllerBase
    {
        private readonly MockServiceContext _context;

        public EmployeeCompetenceController(MockServiceContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeCompetence
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeContractCompetence>>> GetEmployeeContractCompetences()
        {
            return await _context.EmployeeContractCompetences
                .Include(c => c.Competence)
                .Include(c => c.EmployeeContract.Employee)
                .ToListAsync();
        }

        // GET: api/EmployeeCompetence/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeContractCompetence>> GetEmployeeContractCompetence(Guid id)
        {
            var employeeContractCompetence = await _context.EmployeeContractCompetences
                .Include(c => c.Competence)
                .Include(c => c.EmployeeContract.Employee)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (employeeContractCompetence == null)
            {
                return NotFound();
            }

            return employeeContractCompetence;
        }
        
        [HttpGet("contract/{id}")]
        public async Task<ActionResult<IEnumerable<EmployeeContractCompetence>>> GetEmployeeContractCompetencesByContract(Guid id)
        {
            return await _context.EmployeeContractCompetences
                .Include(c => c.Competence)
                .Where(c => c.EmployeeContract.Id == id)
                .ToListAsync();
        }

        // PUT: api/EmployeeCompetence/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeContractCompetence(Guid id, EmployeeContractCompetence employeeContractCompetence)
        {
            employeeContractCompetence.Id = id;

            _context.Entry(employeeContractCompetence).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeContractCompetenceExists(id))
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

        // POST: api/EmployeeCompetence
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeContractCompetence>> PostEmployeeContractCompetence(CreateEmployeeCompetenceDTO employeeContractCompetence)
        {
            var id = Guid.NewGuid();

            EmployeeContract employeeContract = await _context.EmployeeContracts
                .Include(c => c.Employee)
                .FirstOrDefaultAsync(c => c.Id == employeeContractCompetence.EmployeeContractID);
            Competence competence = await _context.Competences.FindAsync(employeeContractCompetence.CompetenceID);
            
            if (employeeContract == null)
            {
                return NotFound("Contract not Found");
            }
            
            if (competence == null)
            {
                return NotFound("Competence not Found");
            }
            
            var newEmployeeContractCompetence = new EmployeeContractCompetence
            {
                Id = id,
                EmployeeContract = employeeContract,
                Competence = competence,
                validFrom = employeeContractCompetence.ValidFrom,
                validTo = employeeContractCompetence.ValidTo
            };

            _context.EmployeeContractCompetences.Add(newEmployeeContractCompetence);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeContractCompetence", new { id = newEmployeeContractCompetence.Id }, newEmployeeContractCompetence);
        }

        // DELETE: api/EmployeeCompetence/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeContractCompetence(Guid id)
        {
            var employeeContractCompetence = await _context.EmployeeContractCompetences.FindAsync(id);
            if (employeeContractCompetence == null)
            {
                return NotFound();
            }

            _context.EmployeeContractCompetences.Remove(employeeContractCompetence);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeContractCompetenceExists(Guid id)
        {
            return _context.EmployeeContractCompetences.Any(e => e.Id == id);
        }
    }
}
