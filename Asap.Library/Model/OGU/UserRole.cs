using Asap.Library.Model;
using System;

namespace Asap.Library.Model
{

    [Serializable]
    public class UserRoleQueryCondition
    {
    }


    /// <summary>
    /// USER_ROLES 扩展表[通常用作查询]
    /// </summary>
    [Serializable]
    public class UserRole
    {
        #region Properties


        public string URID { get; set; }


        public string UserID { get; set; }


        public string RoleID { get; set; }


        public DateTime ValidFrom { get; set; }

        public DateTime ValidTill { get; set; }


        public DateTime CreateTime { get; set; }


        public string CreatorID { get; set; }

        public int Status { get; set; }


        #endregion
    }

    [Serializable]
    public sealed class UserRoleCollection : EditableDataObjectCollectionBase<UserRole>
    {
    }
}
