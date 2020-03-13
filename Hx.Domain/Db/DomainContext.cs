using Microsoft.EntityFrameworkCore;
using Hx.Core.Models;
using Hx.Core.Models.ModelBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hx.Domain.Db
{
    public class DomainContext : DbContext
    {
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DomainContext(DbContextOptions<DomainContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            UserBuilder.Build(builder);
            UserRolesBuilder.Build(builder);
        }
    }
}
