


using Employee.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Domain.Data
{
    public class ApiDbContext : DbContext
    {
        internal readonly object Staff;

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }
        public DbSet<Staff> Employees { get; set; }
        

    }
}
