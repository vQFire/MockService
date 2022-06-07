using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Query;
using Newtonsoft.Json;

namespace MockService.Models;

public class Competence
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    [NotMapped]
    [JsonIgnore]
    public virtual IEnumerable<ScheduleGroup>? ScheduleGroups { get; set; }
}