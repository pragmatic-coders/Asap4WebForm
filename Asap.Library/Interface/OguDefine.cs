using Asap.Library.Core;
using Asap.Library.Model;
using System.Collections;

namespace Asap.Library.Interface
{
    #region IOguObject

    /// <summary>
    /// 人员和部门接口的基类
    /// </summary>
    public interface IOguObject
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
        /// 对象的显示名称
        /// </summary>
        string DisplayName { get; }

        /// <summary>
        /// 判断当前对象是否是机构对象的子孙对象
        /// </summary>
        /// <param name="parent">某个机构对象</param>
        /// <returns>是否属于某机构</returns>
        bool IsChildrenOf(IOrganization parent);

        /// <summary>
        /// 属性集合
        /// </summary>
        IDictionary Properties { get; }

    }
    #endregion

    #region IOrganization

    /// <summary>
    /// 组织机构的接口
    /// </summary>
    public interface IOrganization : IOguObject
    {
        /// <summary>
        /// 代码
        /// </summary>
        string CustomsCode { get; }

        /// <summary>
        /// 该部门是否是顶级部门
        /// </summary>
        bool IsTopOU { get; }

        /// <summary>
        /// 该部门的下一级子对象
        /// </summary>
        OguObjectCollection<IOguObject> Children { get; }

        /// <summary>
        /// 得到所有的子对象（所有级别深度）
        /// </summary>
        /// <typeparam name="T">期望的类型</typeparam>
        /// <param name="includeSideLine">是否包含兼职的人员</param>
        /// <returns>得到所有的子对象（所有级别深度）</returns>
        OguObjectCollection<T> GetAllChildren<T>(bool includeSideLine) where T : IOguObject;

    }

    #endregion

    #region IUser

    /// <summary>
    /// 用户的接口
    /// </summary>
    public interface IUser : IOguObject
    {
        /// <summary>
        /// 登录名称
        /// </summary>
        string LogOnName { get; }

        /// <summary>
        /// 用户的邮件地址
        /// </summary>
        string Email { get; }

        /// <summary>
        /// 当前委托待办的用户名
        /// </summary>
        string DelegateLogOnName { get; }

        /// <summary>
        /// 是否管理员
        /// </summary>
        bool IsAdmin { get; }

        /// <summary>
        /// 用户的角色集合（本应用）
        /// </summary>
        IUserRoleCollection Roles { get; }

        /// <summary>
        /// 用户的权限
        /// </summary>
        IUserPermissionCollection Permissions { get; }

        /// <summary>
        /// 是否拥有某个角色（全局）
        /// </summary>
        /// <param name="codeNames">角色codeName数组</param>
        /// <returns></returns>
        bool IsInRole(params string[] codeNames);
    }
    #endregion

    #region IUserRoleCollection

    public interface IUserRoleCollection
    {
        /// <summary>
        /// 得到某应用下某角色
        /// </summary>
        IRole this[string appCodeName, string roleCodeName] { get; }

        /// <summary>
        /// 得到某应用下角色集合
        /// </summary>
        RoleCollection this[string appCodeName] { get; }

        /// <summary>
        /// 
        /// </summary>
        bool ContainsApp(string appCodeName);
    }

    #endregion

    #region IUserPermissionCollection

    public interface IUserPermissionCollection
    {
        /// <summary>
        /// 得到某应用下某功能
        /// </summary>
        IPermission this[string appCodeName, string permissionCodeName] { get; }

        /// <summary>
        /// 得到某应用下功能集合
        /// </summary>
        PermissionCollection this[string appCodeName] { get; }

        /// <summary>
        /// 请求的链接是否合法
        /// </summary>
        bool IsValidRequestUrl();

        /// <summary>
        /// 当前功能模块
        /// </summary>
        IModule CurrentModule { get; }

        /// <summary>
        /// 是否检查请求的URL
        /// </summary>
        bool CheckRequestUrl { get; }
    }

    #endregion
}
