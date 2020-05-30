using DataLogger.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogger.Models
{
    class ApplicationDbContext : DbContext
    {
        public DbSet<OldData> OldDatas { get; set; }
        public DbSet<Chanel> Chanels { get; set; }
    }
}
