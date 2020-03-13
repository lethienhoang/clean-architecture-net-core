using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hx.Core.Models.ModelBuilders
{
    public static class UserRolesBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<UserRoles>();

            entity.HasOne(s => s.User)
                .WithMany(s => s.UserRoles)
                .HasForeignKey(s => s.UserId);

            entity.HasOne(s => s.Role)
                .WithMany(s => s.UserRoles);
        }
    }
}
