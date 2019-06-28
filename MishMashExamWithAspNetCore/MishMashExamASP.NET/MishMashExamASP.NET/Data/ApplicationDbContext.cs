using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MishMashExamASP.NET.Data.Models;

namespace MishMashExamASP.NET.Data
{
    public class ApplicationDbContext : IdentityDbContext<MishMashUser>
    {
        private readonly IConfiguration configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
            : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<Channel> Channels { get; set; }

        public DbSet<UserChannel> UserChannels { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<ChannelTag> ChannelTags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ChannelTag>()
                .HasKey(x => new { x.ChannelId, x.TagId });

            builder.Entity<ChannelTag>()
                .HasOne(x => x.Channel)
                .WithMany(c => c.ChannelTags)
                .HasForeignKey(x => x.ChannelId);

            builder.Entity<UserChannel>()
                .HasKey(x => new { x.ChannelId, x.MishMashUserId });
        }
    }
}
