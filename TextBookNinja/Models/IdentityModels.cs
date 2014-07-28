using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineBookWebsite.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentitySample.Models
{
    public enum AccountStatus
    {
        Pending, Active, Deleted, Inactive, Banned, TimeOut, Other
    }

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public AccountStatus? AccountStatus { get; set; }

        public DateTime LastLogin { get; set; }

        public DateTime CreateDate { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<UsersBook> UsersBooks { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        static ApplicationDbContext()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }
        public DbSet<BuyerBookHistory> BuyerBooksHistory { get; set; }
        public DbSet<BuyerRating> BuyerRatings { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<SellerRating> SellerRatings { get; set; }
        public DbSet<SellerBookHistory> SellerBooksHistory { get; set; }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionBuyer> TransactionBuyers { get; set; }
        public DbSet<TransactionSeller> TransactionSellers { get; set; }

        public DbSet<UsersBook> UsersBooks { get; set; }

        public DbSet<BookAuthor> BookAuthors { get; set; }

        public DbSet<CategoryBook> CategoryBooks { get; set; }
    }
}