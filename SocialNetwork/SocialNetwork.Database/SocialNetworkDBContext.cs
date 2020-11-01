using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Models;
using System;
using System.Reflection;

namespace SocialNetwork.Database
{
    public class SocialNetworkDBContext : IdentityDbContext<User, Role, Guid>
    {
        public SocialNetworkDBContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<ImagePost> ImagePosts { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<TextPost> TextPosts { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<VideoPost> VideoPosts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.Seed();
        }
    }
}
