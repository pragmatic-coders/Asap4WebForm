using Asap.Library.Interface;
using System.Collections;

namespace Asap.Library.Model
{
    public class LogonUser : IUser
    {
        public string ID { get; set; }


        public string Name { get; set; }


        public string DisplayName { get; set; }

        public string Description { get; set; }


        public IDictionary Properties { get; set; }


        public string LogOnName { get; set; }


        public string DelegateLogOnName { get; set; }


        public string Email { get; set; }

        public string Function { get; set; }


        public bool IsAdmin
        {
            get
            {
                bool result = false;
                if (this.Roles != null)
                    result = this.Roles["APP_Role1", "APP_ADMIN"] != null;
                return result;
            }
        }


        public IUserRoleCollection Roles { get; set; }


        public IUserPermissionCollection Permissions { get; set; }

        public string Domain { get; set; }

        public bool IsChildrenOf(IOrganization parent)
        {
            return false;
        }
        public bool IsInRole(params string[] codeNames)
        {
            bool result = false;

            return result;
        }

    }
}
