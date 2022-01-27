using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//  a DBcontext class to setup connection beetween DB and this program

namespace DateMe.Models
{
    public class MovieDbContext : DbContext
    {
      public MovieDbContext (DbContextOptions<MovieDbContext> options) : base (options)
        {
            //Leave blank for now 
        }

        public DbSet<ApplicationResponse> Responses { get; set; }
 
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<ApplicationResponse>().HasData(
                // seeding the DB with my three farovite movies: 

                new ApplicationResponse
                {
                    MovieId = 1, 
                    Category = "Comedy",
                    Title = "Love Actually",
                    Year = 2003,
                    DirectorFirstName = "Richard",
                    DirectorLastName = "Curtis",
                    Rating = "R",
                    Edited = true,
                    LentTo = "",
                    Notes = "Merry Christmas!"
                },

                new ApplicationResponse
                {
                    MovieId = 2,
                    Category = "War/Drama",
                    Title = "Kingdom of Heaven",
                    Year = 2005,
                    DirectorFirstName = "Ridley",
                    DirectorLastName = "Scott",
                    Rating = "R",
                    Edited = false,
                    LentTo = "",
                    Notes = "MUST: Director's Cut"
                },

                new ApplicationResponse
                {
                    MovieId = 3,
                    Category = "Thriller/Crime",
                    Title = "New World",
                    Year = 2013,
                    DirectorFirstName = "Hoon-jung",
                    DirectorLastName = "Park",
                    Rating = "R",
                    Edited = false,
                    LentTo = "",
                    Notes = "BEST EVER"
                }
             );
        }
    }
}
