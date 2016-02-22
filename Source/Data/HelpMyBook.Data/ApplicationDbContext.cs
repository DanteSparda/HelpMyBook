namespace HelpMyBook.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Common.Models;
    using HelpMyBook.Data.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        public IDbSet<Joke> Jokes { get; set; }

        public IDbSet<JokeCategory> JokesCategories { get; set; }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<BookFile> BookFiles { get; set; }
        
        public IDbSet<Donation> Donations { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            try
            {
                return base.SaveChanges();
            }
            catch (Exception ex)
            {
                var exa = ex; 
                throw;
            }
        }



        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
