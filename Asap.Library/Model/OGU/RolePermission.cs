using Asap.Library.Model;
using System;

namespace Asap.Library.Model
{

    [Serializable]
    public class RolePermissionsQueryCondition
    {
        #region Properties

        public string RF_ID { get; set; }

        public string ROLE_ID { get; set; }


        public string FUNC_ID { get; set; }

        public string INHERITED { get; set; }


        #endregion
    }



    [Serializable]
    public class RolePermission
    {
        #region Properties


        public string RF_ID { get; set; }

        public string ROLE_ID { get; set; }

        public string Perm_ID { get; set; }
        public string INHERITED { get; set; }


        #endregion
    }

    [Serializable]
    public sealed class RolePermissionsExtCollection : EditableDataObjectCollectionBase<RolePermission>
    {
    }
}
