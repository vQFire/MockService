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

        public DbSet<MockService.Models.Employee> Employees { get; set; }
    }
}
