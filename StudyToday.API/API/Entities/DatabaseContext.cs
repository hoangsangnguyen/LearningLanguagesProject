using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class DatabaseContext : IdentityDbContext<UserEntity, RoleEntity, Guid>
    {
        public DatabaseContext(DbContextOptions options)
            : base(options) { }

        public DbSet<AccessiblePageEntity> AccessiblePages { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<CardType> CardTypes { get; set; }

        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Card> Cards{ get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

        }

     
    }
}
