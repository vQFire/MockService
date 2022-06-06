namespace MockService.Dtos;

public class CreateScheduleGroupDTO
{
    public IEnumerable<Guid> OrganizationalUnitIDs { get; set; } = new List<Guid>();
    public IEnumerable<Guid> CompetenceScheduleGroupIds { get; set; } = new List<Guid>();
    public String Description { get; set; } = "";
    public Boolean IsValid { get; set; } = true;
    public Boolean IgnoreInCalculations { get; set; } = false;
}