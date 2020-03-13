using Microsoft.AspNetCore.Identity;
using Framework.Domain;
using Framework.Types;
using System;

namespace Hx.Core.Models
{
    public class RefreshToken : IIdentifiable
    {
        protected RefreshToken()
        {

        }

        public RefreshToken(User user, IPasswordHasher<User> passwordHasher)
        {
            UserId = user.Id;
            Token = CreateToken(user, passwordHasher);
        }

        public Guid UserId { get; private set; }

        public string Token { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime? RevokedAt { get; private set; }

        public bool Revoked => RevokedAt.HasValue;

        public Guid Id { get; private set; }

        public void Revoke()
        {
            if (Revoked)
            {
                throw new DomainException(CoreConstants.RefreshTokenAlreadyRevoked,
                    $"Refresh token: '{Id}' was already revoked at '{RevokedAt}'.");
            }

            RevokedAt = DateTimeHelper.GenerateTodayUTC();
        }

        private static string CreateToken(User user, IPasswordHasher<User> passwordHasher)
            => passwordHasher.HashPassword(user, Guid.NewGuid().ToString("N"))
                .Replace("=", string.Empty)
                .Replace("+", string.Empty)
                .Replace("/", string.Empty);
    }
}
