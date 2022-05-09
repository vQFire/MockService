namespace MockService.Models;

public class EmployeeContractCompetence
{
    public Guid Id { get; set; }
    public EmployeeContract EmployeeContract { get; set; }
    public Competence Competence { get; set; }
    public DateOnly validFrom { get; set; }
    public DateOnly validTo { get; set; }
}