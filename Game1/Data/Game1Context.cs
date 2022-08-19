using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Game1.Models;

namespace Game1.Data
{
    public class Game1Context : DbContext
    {
        public Game1Context (DbContextOptions<Game1Context> options)
            : base(options)
        {
        }

        public DbSet<Game1.Models.GameThingy1> GameThingy1 { get; set; } = default!;
    }
}
