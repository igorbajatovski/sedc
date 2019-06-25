using Microsoft.EntityFrameworkCore;

namespace PremierLeague.Models
{
    public class PremierLeagueDbContext : DbContext
    {
        public PremierLeagueDbContext(DbContextOptions<PremierLeagueDbContext> options)
            : base(options)
        {
        }

        public DbSet<Match> Matches { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Trainer> Trainers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
               .HasKey(x => new { x.HomeTeamId, x.AwayTeamId });
            modelBuilder.Entity<Match>()
                .HasOne(ht => ht.HomeTeam)
                .WithMany(m => m.HomeMatches)
                .HasForeignKey(ht => ht.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Match>()
                .HasOne(at => at.AwayTeam)
                .WithMany(m => m.AwayMatches)
                .HasForeignKey(at => at.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Trainer>()
                .HasOne(x => x.Team)
                .WithOne(k => k.Trainer)
                .HasForeignKey<Team>(t => t.TrainerId);

            modelBuilder.Entity<Team>()
                .HasOne(x => x.Trainer)
                .WithOne(t => t.Team)
                .HasForeignKey<Trainer>(t => t.TeamId);

            modelBuilder.Entity<Team>()
                .HasMany(p => p.Players)
                .WithOne(t => t.Team)
                .HasForeignKey(x => x.TeamId);

            //Seed
            //var teams = new List<Team>
            //{
            //    new Allergen("milk"){Id = 1},
            //    new Allergen("seed"){Id = 2}
            //};

            //var ingredients = new List<Ingredient>
            //{
            //    new Ingredient("Cheese") {Id = 1},
            //    new Ingredient("Ham"){Id = 2},
            //    new Ingredient("Tomato sauce"){Id = 3},
            //    new Ingredient("Mushrooms"){Id = 4}
            //};

            //var ingredientAllergens = new List<IngredientAllergen>
            //{
            //    new IngredientAllergen {IngredientId = 1, AllergenId = 1},
            //    new IngredientAllergen {IngredientId = 3, AllergenId = 2}
            //};

            //modelBuilder.Entity<Allergen>().HasData(allergens);
            //modelBuilder.Entity<Ingredient>().HasData(ingredients);
            //modelBuilder.Entity<IngredientAllergen>().HasData(ingredientAllergens);
        }
    }
}
