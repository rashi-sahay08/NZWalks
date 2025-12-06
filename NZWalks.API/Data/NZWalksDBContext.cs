using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDBContext: DbContext
    {
        public NZWalksDBContext(DbContextOptions<NZWalksDBContext> dbContextOptions) : base(dbContextOptions)
        {
        }
            public DbSet<Difficulty> Difficulties { get; set; }
            public DbSet<Region> Regions { get; set; }
            public DbSet<Walk> Walks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("3f1ce202-63a0-4b54-9a68-902de8f5c114"),
                    Name = "Easy"
                },

                new Difficulty()
                {
                    Id = Guid.Parse("8ba38484-45e2-42fc-af12-d1ff4c6c2c0a"),
                    Name = "Medium"
                },

                new Difficulty()
                {
                    Id = Guid.Parse("7bc44a10-9aee-477c-82cf-b4143d77167c"),
                    Name = "Hard"
                }

            };
            //Seeding data for difficulty
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            var regions = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.Parse("fc7daa23-8422-4ff1-8e76-19b9f5a2f8cf"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImgUrl = "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },

                new Region()
                {
                    Id = Guid.Parse("4f3d9c70-f896-4ce4-945a-79a9d8078579"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImgUrl = null

                },

                new Region()
                {
                    Id = Guid.Parse("2e89a795-5ac1-4336-bba7-ca31ad330065"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImgUrl = null

                }
            };
            //Seeding data for region
            modelBuilder.Entity<Region>().HasData(regions);

        }

    }
}

