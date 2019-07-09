using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OraCore.Models
{
    public class OraDbContext:DbContext
    {
        public OraDbContext(DbContextOptions<OraDbContext> options) : base(options)
        { }

        public DbSet<OracleObject> Objects { get; set; }
    }
}
