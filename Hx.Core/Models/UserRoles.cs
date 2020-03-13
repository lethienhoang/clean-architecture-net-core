using Framework.Domain;
using System;
using System.Collections.Generic;

namespace Hx.Core.Models
{
    public class UserRoles : ValueObjectBase
    {
        protected UserRoles()
        {

        }

        public UserRoles(Guid roleId, Guid userId)
        {
            RoleId = roleId;
            UserId = userId;
        }


        public Guid RoleId { get; private set; }

        public Role Role { get; private set; }

        public Guid UserId { get; private set; }

        public User User { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return RoleId;
            yield return UserId;
        }
    }
}
