using Framework.Domain;
using System;
using System.Collections.Generic;

namespace Hx.Core.Models
{
    public class Role : EntityBase
    {
        public Role(Guid id, string code, string roleName) : base(id)
        {
            Code = code;
            RoleName = roleName;
        }


        public string Code { get; private set; }

        public string RoleName { get; private set; }

        public ICollection<UserRole> UserRoles { get; private set; }
    }
}
