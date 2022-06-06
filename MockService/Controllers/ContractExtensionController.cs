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
    [Route("api/contract/extension")]
    [ApiController]
    public class ContractExtensionController : ControllerBase
    {
        private readonly MockServiceContext _context;

        public ContractExtensionController(MockServiceContext context)
        {
            _context = context;
        }

        // GET: api/ContractExtension
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeContractExtension>>> GetEmployeeContractExtensions()
        {
            return await _context.EmployeeContractExtensions
                .Include(c => c.OrganizationalUnit)
                .Include(c => c.EmployeeContract.Employee)
                .ToListAsync();
        }

        // GET: api/ContractExtension/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeContractExtension>> GetEmployeeContractExtension(Guid id)
        {
            var employeeContractExtension = _context.EmployeeContractExtensions
                .Include(c => c.OrganizationalUnit)
                .Include(c => c.EmployeeContract.Employee)
                .FirstOrDefault(c => c.Id == id);

            if (employeeContractExtension == null)
            {
                return NotFound();
            }

            return employeeContractExtension;
        }
        
        [HttpGet("contract/{id}")]
        public async Task<ActionResult<EmployeeContractExtension>> GetEmployeeContractExtensionByContract(Guid id)
        {
            var employeeContractExtension = _context.EmployeeContractExtensions
                .Include(c => c.OrganizationalUnit)
                .Include(c => c.EmployeeContract.Employee)
                .FirstOrDefault(c => c.EmployeeContract.Id == id);

            if (employeeContractExtension == null)
            {
                return NotFound();
            }

            return employeeContractExtension;
        }
        
        [HttpGet("unit/{id}")]
        public async Task<ActionResult<IEnumerable<EmployeeContractExtension>>> GetEmployeeContractExtensionsByUnit(Guid id)
        {
            return await _context.EmployeeContractExtensions
                .Include(c => c.OrganizationalUnit)
                .Include(c => c.EmployeeContract.Employee)
                .Where(c => c.OrganizationalUnit.Id == id)
                .ToListAsync();
        }

        [HttpGet("employee/{id}")]
        public async Task<ActionResult<IEnumerable<EmployeeContractExtension>>> GetEmployeeContractExtensionsByEmployee(Guid id)
        {
            return await _context.EmployeeContractExtensions
                .Include(c => c.OrganizationalUnit)
                .Include(c => c.EmployeeContract.Employee)
                .Where(c => c.EmployeeContract.Employee.Id == id)
                .ToListAsync();
        }

        // PUT: api/ContractExtension/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeContractExtension(Guid id, EmployeeContractExtension employeeContractExtension)
        {
            employeeContractExtension.Id = id;

            _context.Entry(employeeContractExtension).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeContractExtensionExists(id))
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

        // POST: api/ContractExtension
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeContractExtension>> PostEmployeeContractExtension(EmployeeContractExtensionDTO employeeContractExtension)
        {
            var id = Guid.NewGuid();
            
            EmployeeContract contract =
                await _context.EmployeeContracts.FindAsync(employeeContractExtension.EmployeeContractID);
            OrganizationalUnit unit =
                await _context.OrganizationalUnits.FindAsync(employeeContractExtension.OrganizationalUnitID);

            if (contract == null)
            {
                return NotFound("Contract not Found");
            }

            if (unit == null)
            {
                return NotFound("Unit not Found");
            }
            
            var newContractExtension = new EmployeeContractExtension
            {
                Id = id,
                EmployeeContract = contract,
                OrganizationalUnit = unit,
                Function = employeeContractExtension.Function,
                LaborMinutesPerWeekMin = employeeContractExtension.LaborMinutesPerWeekMin,
                LaborMinutesPerWeekMax = employeeContractExtension.LaborMinutesPerWeekMax,
                validFrom = employeeContractExtension.ValidFrom,
                validTo = employeeContractExtension.ValidTo
            };
            
            
            _context.EmployeeContractExtensions.Add(newContractExtension);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeContractExtension", new { id = newContractExtension.Id }, newContractExtension);
        }

        // DELETE: api/ContractExtension/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeContractExtension(Guid id)
        {
            var employeeContractExtension = await _context.EmployeeContractExtensions.FindAsync(id);
            if (employeeContractExtension == null)
            {
                return NotFound();
            }

            _context.EmployeeContractExtensions.Remove(employeeContractExtension);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeContractExtensionExists(Guid id)
        {
            return _context.EmployeeContractExtensions.Any(e => e.Id == id);
        }
    }
}
