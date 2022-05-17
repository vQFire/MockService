#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MockService.Data;
using MockService.Models;

namespace MockService.Controllers
{
    [Route("api/contract")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly MockServiceContext _context;

        public ContractController(MockServiceContext context)
        {
            _context = context;
        }

        // GET: api/Contract
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeContract>>> GetEmployeeContracts()
        {
            return await _context.EmployeeContracts.Include(c => c.Employee).ToListAsync();
        }

        // GET: api/Contract/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeContract>> GetEmployeeContract(Guid id)
        {
            var employeeContract = await _context.EmployeeContracts.Include(c => c.Employee).FirstOrDefaultAsync(c => c.Id == id);

            if (employeeContract == null)
            {
                return NotFound();
            }

            return employeeContract;
        }

        // PUT: api/Contract/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeContract(Guid id, EmployeeContract employeeContract)
        {
            if (id != employeeContract.Id)
            {
                return BadRequest();
            }

            _context.Entry(employeeContract).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeContractExists(id))
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

        // POST: api/Contract
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeContract>> PostEmployeeContract(EmployeeContract employeeContract)
        {
            _context.EmployeeContracts.Add(employeeContract);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeContract", new { id = employeeContract.Id }, employeeContract);
        }

        // DELETE: api/Contract/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeContract(Guid id)
        {
            var employeeContract = await _context.EmployeeContracts.FindAsync(id);
            if (employeeContract == null)
            {
                return NotFound();
            }

            _context.EmployeeContracts.Remove(employeeContract);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeContractExists(Guid id)
        {
            return _context.EmployeeContracts.Any(e => e.Id == id);
        }
    }
}
