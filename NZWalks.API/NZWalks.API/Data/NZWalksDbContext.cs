using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext :DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        DbSet<Region> Regions { get; set; }
        DbSet<WalkDifficulty> WalkDifficulty { get; set; }
        DbSet<Walk> Walks { get; set; } 

    }
}
