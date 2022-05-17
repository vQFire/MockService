namespace MockService.Models;

public class EmployeeContractCompetence
{
    public Guid Id { get; set; }
    public EmployeeContract EmployeeContract { get; set; }
    public Competence Competence { get; set; }
    public DateTime validFrom { get; set; }
    public DateTime validTo { get; set; }
}