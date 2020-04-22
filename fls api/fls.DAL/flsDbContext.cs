using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fls.Models;
using System.Data.Entity;

namespace fls.DAL
{
    public class flsDbContext:DbContext
    {
        public DbSet<Custom> Customs { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<InvCode> InvCodes { get; set; }

        public DbSet<Studio> Studios { get; set; }

        public flsDbContext():base("DefaultConnection")
        {
        }
    }
}
