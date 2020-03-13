using Microsoft.EntityFrameworkCore;

namespace Hx.Core.Models.ModelBuilders
{
    public static class UserBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<User>();

            entity.HasKey(s => s.Id);

            entity.HasIndex(s => new { s.Email, s.FirstName, s.LastName });

            entity.Property(s => s.Email)
                .HasMaxLength(30)
                .IsRequired();

            entity.Property(s => s.Created);

            entity.Property(s => s.FirstName)
                .HasMaxLength(20)
                .IsRequired();

            entity.Property(s => s.LastName)
                .HasMaxLength(20)
                .IsRequired();

            entity.Property(s => s.PasswordHash)
                .HasMaxLength(200);

            entity.HasMany(s => s.UserRoles)
                .WithOne(s => s.User)
                .OnDelete(DeleteBehavior.Cascade);

            entity.Property(s => s.Created)
                .ValueGeneratedOnAdd();

            entity.Property(s => s.Updated)
                .ValueGeneratedOnUpdate();

        }
    }
}
