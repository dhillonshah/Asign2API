using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBA.Models
{
    public class NBAModel : DbContext
    {
        public NBAModel(DbContextOptions<NBAModel>options): base(options)
        {

        }

        public DbSet<Team> Teams { get; set; }
    }
}
