namespace MockService.Dtos;

public class CreateEmployeeCompetenceDTO 
{
    public Guid EmployeeContractID { get; set; }
    public Guid CompetenceID { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime ValidTo { get; set; }
}