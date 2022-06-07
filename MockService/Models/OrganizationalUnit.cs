using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace MockService.Models;

public class OrganizationalUnit
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    [NotMapped]
    [JsonIgnore]
    public virtual IEnumerable<ScheduleGroup>? ScheduleGroups { get; set; }
}