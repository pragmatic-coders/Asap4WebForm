using Asap.Library.Interface;
using Asap.Library.Model;
using System;

namespace Asap.Library.Model
{


    [Serializable]
    public class ROLEQueryCondition
    {

    }



    [Serializable]
    public class Role : IRole
    {
        #region Properties


        public string RoleID { get; set; }


        public string AppID { get; set; }



        public string AppName { get; set; }

        public string Name { get; set; }



        public string CodeName { get; set; }


        public string Description { get; set; }

        /// <summary>
        /// 序号
        /// </summary>

        public int SortID { get; set; }

        /// <summary>
        /// 是否允许继承
        /// </summary>

        public string Inherited { get; set; }

        /// <summary>
        /// 是否允许委托
        /// </summary>

        public string AllowDelegate { get; set; }

        /// <summary>
        /// 状态
        /// </summary>

        public int Status { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>

        public string CreatorID { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>

        public string ModifierID { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>

        public DateTime ModifyTime { get; set; }

        public PermissionCollection Permissions => throw new NotImplementedException();

        public IApplication Application => throw new NotImplementedException();

        public string ID => throw new NotImplementedException();


        #endregion
    }

    [Serializable]
    public sealed class RoleCollection : EditableDataObjectCollectionBase<Role>
    {
    }


}
