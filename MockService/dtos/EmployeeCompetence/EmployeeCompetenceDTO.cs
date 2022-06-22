using MockService.Models;

namespace MockService.Dtos;

public class EmployeeCompetenceDTO
{
    public Guid ContractId { get; set; }
    public List<Competence> Competences { get; set; } = new List<Competence>();
}