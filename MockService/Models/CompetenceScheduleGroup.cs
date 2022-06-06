namespace MockService.Models;

public class CompetenceScheduleGroup
{
    public CompetenceScheduleGroup() {}
    public CompetenceScheduleGroup(Competence competence)
    {
        Competence = competence;
    }
    public Guid Id { get; set; }
    public Competence Competence { get; set; }
    public Guid CompetenceId { get; set; }
}