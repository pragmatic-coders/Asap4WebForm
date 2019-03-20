using Asap.Library.Interface;
using System;
using System.Collections.Generic;

namespace Asap.Library.Model
{
    [Serializable]

    public class Application
    {
        #region Properties

        public string ID { get; set; }


        public string Name { get; set; }


        public string CodeName { get; set; }


        public string Description { get; set; }


        public string ApplicationPath { get; set; }


        public int SortID { get; set; }


        public string UseScope { get; set; }


        public DateTime ModifyTime { get; set; }


        private RoleCollection roles = null;

        public RoleCollection Roles
        {
            get
            {
                if (this.roles == null)
                {
                    List<IRole> roleList = new List<IRole>();
                    this.roles = RoleAdapter.Instance.GetCollection(r => r.AppID == this.ID);
                }
                return this.roles;
            }
        }

        private PermissionCollection permissions = null;

        public PermissionCollection Permissions
        {
            get
            {
                if (this.permissions == null)
                {
                    List<IPermission> permissionList = new List<IPermission>();
                    this.permissions = PermissionAdapter.Instance.GetCollection(f => f.AppID == this.ID);
                }
                return this.permissions;
            }
        }

        #endregion

        #region Constructors

        public Application()
        {
        }

        public Application(string codeName)
        {
            InitProperties(codeName);
        }

        #endregion

        #region Private Methods

        private void InitProperties(string codeName)
        {
            Application application = ApplicationCache.Instance.GetCollection()
                .Find(app => app.CodeName.Equals(codeName, StringComparison.CurrentCultureIgnoreCase));
            if (application != null)
            {
                this.ID = application.ID;
                this.Name = application.Name;
                this.CodeName = application.CodeName;
                this.Description = application.Description;
            }
        }

        #endregion


        public static int CompareRule(Application model, Application other)
        {
            return model.SortID - other.SortID;
        }
    }


}
