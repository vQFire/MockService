namespace MockService.Dtos;

public class TradeOfferScheduleDTO 
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public IEnumerable<Guid>? Competences { get; set; }
    public Guid EmployeeId { get; set; }
    public String? EmployeeName { get; set; }
}