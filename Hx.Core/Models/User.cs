using Microsoft.AspNetCore.Identity;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Hx.Core.Models
{
    public class User : EntityBase
    {
        private static readonly Regex EmailRegex = new Regex(
            @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
            RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);

        protected User(Guid id, string email, string firstName, string lastName, IList<Guid> roleIds = null) : base(id)
        {
            if (!EmailRegex.IsMatch(email))
            {
                throw new DomainException(CoreConstants.InvalidEmail,
                    $"Invalid email: '{email}'.");
            }

            Email = email.ToLowerInvariant();
            FirstName = firstName;
            LastName = lastName;

            SetRoles(roleIds);
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public ICollection<UserRoles> UserRoles { get; private set; }

        public string PasswordHash { get; private set; }

        public void SetPassword(string password, IPasswordHasher<User> passwordHasher)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new DomainException(CoreConstants.InvalidPassword,
                    "Password can not be empty.");
            }

            PasswordHash = passwordHasher.HashPassword(this, password);
        }

        public void SetRoles(IList<Guid> roleIds)
        {
            if (roleIds != null)
            {
                foreach(var roleId in roleIds)
                {
                    UserRoles.Add(new UserRoles(roleId, Id));
                }
            }
        }

        public bool ValidatePassword(string password, IPasswordHasher<User> passwordHasher)
            => passwordHasher.VerifyHashedPassword(this, PasswordHash, password) != Microsoft.AspNetCore.Identity.PasswordVerificationResult.Failed;
    }
}
