﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Asap.Library.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Asap.Library.Properties.Resource", typeof(Resource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 参数{0}不允许为空（Null Or Empty）。.
        /// </summary>
        internal static string ArgumentNotNull {
            get {
                return ResourceManager.GetString("ArgumentNotNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 不能找到数据库连接名称为{0}的配置信息，请检查connectionManager配置节.
        /// </summary>
        internal static string CanNotFindConnectionName {
            get {
                return ResourceManager.GetString("CanNotFindConnectionName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 不能找到名称为{0}的配置集合元素.
        /// </summary>
        internal static string CanNotFindNamedConfigElement {
            get {
                return ResourceManager.GetString("CanNotFindNamedConfigElement", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 不能找到数据库连接信息为&quot;{0}&quot;所对应的dataProvider:&quot;{1}&quot;，请检查connectionManager配置节的dataProviders配置项.
        /// </summary>
        internal static string CanNotFindProviderName {
            get {
                return ResourceManager.GetString("CanNotFindProviderName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 不能在Xml节点{0}下找到{1}.
        /// </summary>
        internal static string CanNotFindXmlNode {
            get {
                return ResourceManager.GetString("CanNotFindXmlNode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 不能在配置文件中找到配置节&quot;{0}&quot;.
        /// </summary>
        internal static string CanNotFoundConfigSection {
            get {
                return ResourceManager.GetString("CanNotFoundConfigSection", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 不能在配置文件中找到配置节&quot;{0}&quot;的详细定义部分.
        /// </summary>
        internal static string CanNotFoundConfigSectionElement {
            get {
                return ResourceManager.GetString("CanNotFoundConfigSectionElement", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 集合类是只读的，不能执行该操作.
        /// </summary>
        internal static string CollectionIsReadOnly {
            get {
                return ResourceManager.GetString("CollectionIsReadOnly", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Field which named &apos;{0}&apos; can not convert to &apos;{1}&apos;..
        /// </summary>
        internal static string ConvertDataFieldToPropertyError {
            get {
                return ResourceManager.GetString("ConvertDataFieldToPropertyError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Xml节点{0}转换到属性{1}出错，{2}.
        /// </summary>
        internal static string ConvertXmlNodeToPropertyError {
            get {
                return ResourceManager.GetString("ConvertXmlNodeToPropertyError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} 配置的事件参数类型有误.
        /// </summary>
        internal static string DbEventTypeIsNotValidException {
            get {
                return ResourceManager.GetString("DbEventTypeIsNotValidException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Timestamp: {timestamp}
        ///Title: {title}
        ///EventID: {eventid}
        ///Message: {message}
        ///Priority: {priority}
        ///EventType: {eventtype}
        ///StackTrace: {newline}{stacktrace}
        ///Machine: {machine}
        ///Extended Properties: {newline}{dictionary({key} - {value}{newline})}.
        /// </summary>
        internal static string DefaultTextFormat {
            get {
                return ResourceManager.GetString("DefaultTextFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cache项{0}失效了，失效的依赖条件类型是{1}.
        /// </summary>
        internal static string DependencyChanged {
            get {
                return ResourceManager.GetString("DependencyChanged", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 在集合中添加对象类型{0}时，Key属性值&quot;{1}&quot;重复.
        /// </summary>
        internal static string DuplicateDescriptorKey {
            get {
                return ResourceManager.GetString("DuplicateDescriptorKey", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 在集合中添加对象类型{0}时，Key属性值&quot;{1}&quot;重复.
        /// </summary>
        internal static string DuplicateDescriptorKey1 {
            get {
                return ResourceManager.GetString("DuplicateDescriptorKey1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 已添加了具有相同键的项: {0}.
        /// </summary>
        internal static string DuplicateKey {
            get {
                return ResourceManager.GetString("DuplicateKey", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 应用&apos;{0}&apos; 定义了相互冲突的路径&apos;{1}&apos; 和  &apos;{2}&apos;.
        /// </summary>
        internal static string ExceptionConflictPathDefinition {
            get {
                return ResourceManager.GetString("ExceptionConflictPathDefinition", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 当前记录更新时异常.
        /// </summary>
        internal static string ExceptionMessageUpdateDataSetRowFailure {
            get {
                return ResourceManager.GetString("ExceptionMessageUpdateDataSetRowFailure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value can not be null or an empty string..
        /// </summary>
        internal static string ExceptionNullOrEmptyString {
            get {
                return ResourceManager.GetString("ExceptionNullOrEmptyString", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The formatter type &apos;{0}&apos; of &apos;{1}&apos;  is invalid..
        /// </summary>
        internal static string ExceptionSerializationFormatterType {
            get {
                return ResourceManager.GetString("ExceptionSerializationFormatterType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Execute Scalar() 方法不支持TableDirect模式.
        /// </summary>
        internal static string ExecuteScalarNotSupportTableDirectException {
            get {
                return ResourceManager.GetString("ExecuteScalarNotSupportTableDirectException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 文件&quot;{0}&quot;不存在.
        /// </summary>
        internal static string FileNotFound {
            get {
                return ResourceManager.GetString("FileNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Meta中配置的全局配置文件&quot;{0}&quot;不存在.
        /// </summary>
        internal static string GlobalFileNotFound {
            get {
                return ResourceManager.GetString("GlobalFileNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 初始化类属性失败。错误信息：{0}.
        /// </summary>
        internal static string InitialPropertyError {
            get {
                return ResourceManager.GetString("InitialPropertyError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 成员{0}，对象映射时不支持的成员类型{1}.
        /// </summary>
        internal static string InvalidMemberInfoType {
            get {
                return ResourceManager.GetString("InvalidMemberInfoType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 成员{0}，对象映射时不支持的成员类型{1}.
        /// </summary>
        internal static string InvalidMemberInfoType1 {
            get {
                return ResourceManager.GetString("InvalidMemberInfoType1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Meta文件&quot;{0}&quot;不存在.
        /// </summary>
        internal static string MetaFileNotFound {
            get {
                return ResourceManager.GetString("MetaFileNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Oracle DB 中SQL语句多Table输出性能表现较差，故不支持输出多个TableName方法,如果需要查询返回多个DataTable请将其写成存储过程.
        /// </summary>
        internal static string OracleMultiTablesError {
            get {
                return ResourceManager.GetString("OracleMultiTablesError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;Error: property {0} not found&gt;.
        /// </summary>
        internal static string ReflectedPropertyTokenNotFound {
            get {
                return ResourceManager.GetString("ReflectedPropertyTokenNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 字符串参数{0}不能为Null或空串.
        /// </summary>
        internal static string StringParamCanNotBeNullOrEmpty {
            get {
                return ResourceManager.GetString("StringParamCanNotBeNullOrEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 不能加载类型{0}.
        /// </summary>
        internal static string TypeLoadException {
            get {
                return ResourceManager.GetString("TypeLoadException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 类型{0}必须是枚举类型.
        /// </summary>
        internal static string TypeMustBeEnum {
            get {
                return ResourceManager.GetString("TypeMustBeEnum", resourceCulture);
            }
        }
    }
}
