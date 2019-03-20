using Asap.Library.Interface;
using System;
using System.Collections.Generic;

namespace Asap.Library.Model
{


    /// <summary>
    /// Permission
    /// </summary>
    [Serializable]
    [ORTableMapping("[FUNCTION]")]
    public class Permission : IPermission
    {
        #region Properties

        /// <summary>
        /// FUN_ID
        /// </summary>
        [ORFieldMapping("FUN_ID", PrimaryKey = true)]
        public string ID { get; set; }

        /// <summary>
        /// 功能名称
        /// </summary>
        [ORFieldMapping("NAME")]
        public string Name { get; set; }

        /// <summary>
        /// 功能英文名称
        /// </summary>
        [ORFieldMapping("CODE_NAME")]
        public string CodeName { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [ORFieldMapping("DESCRIPTION")]
        public string Description { get; set; }

        /// <summary>
        /// 应用标识
        /// </summary>
        [ORFieldMapping("APP_ID")]
        public string AppID { get; set; }

        /// <summary>
        /// 模块标识
        /// </summary>
        [ORFieldMapping("APP_MODULE_ID")]
        public string AppModuleID { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        [ORFieldMapping("SORT_ID")]
        public int SortID { get; set; }

        /// <summary>
        /// 是否允许继承
        /// </summary>
        [ORFieldMapping("INHERITED")]
        public string Inherited { get; set; }

        /// <summary>
        /// 修改者标识
        /// </summary>
        [ORFieldMapping("MODIFIER_ID")]
        public string ModifierID { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [ORFieldMapping("MODIFY_TIME")]
        public DateTime ModifyTime { get; set; }

        /// <summary>
        /// STATUS
        /// </summary>
        [ORFieldMapping("STATUS")]
        public int Status { get; set; }

        /// <summary>
        /// 对象所属的应用程序
        /// </summary>
        [NoMapping]
        public IApplication Application
        {
            get
            {
                return ApplicationAdapter.Instance.GetCollection(a => a.ID == this.AppID).FirstOrDefault();
            }
        }

        /// <summary>
        /// 允许此功能访问的URL集合
        /// </summary>
        [NoMapping]
        public string[] PermissionUrls
        {
            get
            {
                return ModuleAdapter.Instance.GetFunctionModuleUrls(this.ID);
            }
        }

        #endregion

        public static int CompareRule(Permission model, Permission other)
        {
            return model.SortID - other.SortID;
        }
    }

    [Serializable]
    public sealed class PermissionCollection : EditableDataObjectCollectionBase<Permission>
    {
        public PermissionCollection() { }

        public PermissionCollection(List<IPermission> permissions)
        {
            Permission model = null;
            permissions.ForEach(p =>
            {
                model = new Permission();
                model.ID = p.ID;
                model.Name = p.Name;
                model.CodeName = p.CodeName;
                model.Description = p.Description;
                this.Add(model);
            });
        }
    }

}
