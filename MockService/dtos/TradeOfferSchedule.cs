namespace MockService.Dtos;

public class ScheduleDTO {
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public IEnumerable<Guid>? Competences { get; set; }
    public String? EmployeeName { get; set; }
}