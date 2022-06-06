namespace MockService.Dtos;

public class CreateEmployeeContractDTO 
{
    public Guid EmployeeId { get; set; }
    public String? ScheduleCompetence { get; set; }
    public DateTime? TrialPeriodEnd { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime ValidTo { get; set; }
}