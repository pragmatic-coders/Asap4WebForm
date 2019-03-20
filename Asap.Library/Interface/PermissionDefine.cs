using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asap.Library.Interface
{
    #region IPermissionObject

    /// <summary>
    /// 授权对象接口的公共基类
    /// </summary>
    public interface IPermissionObject
    {
        /// <summary>
        /// 对象的ID
        /// </summary>
        string ID { get; }

        /// <summary>
        /// 对象的名称
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 对象的英文标识
        /// </summary>
        string CodeName { get; }

        /// <summary>
        /// 对象的描述
        /// </summary>
        string Description { get; }
    }
    #endregion

    #region IApplication

    /// <summary>
    /// 应用的接口定义
    /// </summary>
    public interface IApplication : IPermissionObject
    {
        /// <summary>
        /// 应用中的角色
        /// </summary>
        RoleCollection Roles { get; }

        /// <summary>
        /// 应用中的功能
        /// </summary>
        PermissionCollection Permissions { get; }
    }
    #endregion

    #region IApplicationObject

    /// <summary>
    /// 应用中所包含的对象的接口定义
    /// </summary>
    public interface IApplicationObject : IPermissionObject
    {
        /// <summary>
        /// 对象所属的应用程序
        /// </summary>
        IApplication Application { get; }
    }
    #endregion

    #region IPermission

    /// <summary>
    /// 功能的接口定义
    /// </summary>
    public interface IPermission : IApplicationObject
    {
        /// <summary>
        /// 允许此功能访问的URL集合
        /// </summary>
        string[] PermissionUrls { get; }
    }
    #endregion

    #region IRole

    /// <summary>
    /// 角色的接口定义
    /// </summary>
    public interface IRole : IApplicationObject
    {
        /// <summary>
        /// 角色中的功能
        /// </summary>
        PermissionCollection Permissions { get; }
    }
    #endregion

    #region IModule

    /// <summary>
    /// 页面模块的接口定义
    /// </summary>
    public interface IModule
    {
        /// <summary>
        /// 对象的ID
        /// </summary>
        string ID { get; }

        /// <summary>
        /// 对象的名称
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 默认URL
        /// </summary>
        string DefaultUrl { get; }

        /// <summary>
        /// 对象所属的应用程序
        /// </summary>
        IApplication Application { get; }

        /// <summary>
        /// 对象的功能权限
        /// </summary>
        IPermission Permission { get; }
    }
    #endregion

    #region IOguFactory

    /// <summary>
    /// 机构人员的操作接口
    /// </summary>
    public interface IOguFactory
    {
        /// <summary>
        /// 用户认证，通常是判断用户的用户名和口令是否正确
        /// </summary>
        /// <param name="identity">用户的登录名、口令和域</param>
        /// <returns>是否认证成功</returns>
        bool AuthenticateUser(LogOnIdentity identity);

        /// <summary>
        /// 清除所有Cache
        /// </summary>
        void RemoveAllCache();
    }

    #endregion
}
