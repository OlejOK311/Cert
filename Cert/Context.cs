using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cert
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=smev.db");

        public DbSet<Uchastniki_SMEV> Uchastniki_SMEV { get; set; }
    }
}
