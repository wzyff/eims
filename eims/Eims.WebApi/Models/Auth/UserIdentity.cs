using System;
using System.Security.Principal;

namespace Eims.WebApi.Models.Auth
{
    public class UserIdentity : IIdentity
    {
        public UserIdentity(int id, int roleId)
        {
            this.Id = id;
            this.RoleId = roleId;
        }

        public int Id { get; set; }

        public int RoleId { get; set; }

        public string Name { get; }

        public string AuthenticationType { get; }

        public bool IsAuthenticated { get; }
    }

    public class ApplicationUser : IPrincipal
    {
        public IIdentity Identity { get; }

        public ApplicationUser(int id, int roleId)
        {
            Identity = new UserIdentity(id, roleId);
        }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }
    }
}