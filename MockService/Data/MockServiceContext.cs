#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MockService.Models;

namespace MockService.Data
{
    public class MockServiceContext : DbContext
    {
        public MockServiceContext (DbContextOptions<MockServiceContext> options)
            : base(options)
        {
        }
        
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Competence> Competences { get; set; }
        public DbSet<EmployeeContractCompetence> EmployeeContractCompetences { get; set; }
        public DbSet<EmployeeContract> EmployeeContracts { get; set; }
        public DbSet<OrganizationalUnit> OrganizationalUnits { get; set; }
        public DbSet<EmployeeContractExtension> EmployeeContractExtensions { get; set; }
        public DbSet<ScheduleGroup> ScheduleGroup { get; set; }
        public DbSet<ScheduleGroupSchedule> ScheduleGroupSchedule { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
    }
}
