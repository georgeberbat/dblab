using Microsoft.EntityFrameworkCore;
using PhoneApp.Models;

namespace PhoneApp.Data
{
    public class HRContext : DbContext
    {
        public HRContext(DbContextOptions<HRContext> options) : base(options) { }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ContactTag> ContactTags { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseMySQL("Server=localhost;Port=3306;Database=mockdb;Uid=user;Pwd=passw;CharSet=utf8;");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactTag>()
           .HasKey(t => new { t.ContactId, t.TagId });

            modelBuilder.Entity<ContactTag>()
                .HasOne(pt => pt.Contact)
                .WithMany(p => p.ContactTag)
                .HasForeignKey(pt => pt.ContactId);
            modelBuilder.Entity<ContactTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(p => p.ContactTag)
                .HasForeignKey(pt => pt.TagId);
        }
    }
}
