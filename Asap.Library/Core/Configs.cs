using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace Asap.Library.Core
{
    public static class Configs
    {
        private static CommonConfig _commonConfig;
        /// <summary>
        /// 从Config文件获取配置信息
        /// </summary>
        private static CommonConfig CommonConfig
        {
            get
            {
                if (_commonConfig == null)
                {
                    _commonConfig = (CommonConfig)System.Configuration.ConfigurationManager.GetSection("WalkingTecMVVM/Common");
                }
                return _commonConfig;
            }
        }

        #region 监控服务
        private static bool? _enableServiceMonitor;
        /// <summary>
        /// 启用服务监控任务
        /// </summary>
        public static bool EnableServiceMonitor
        {
            get
            {
                if (_enableServiceMonitor == null)
                {
                    _enableServiceMonitor = CommonConfig?.EnableServiceMonitor ?? false;
                }
                return _enableServiceMonitor.Value;
            }
        }
        #endregion

        #region 分页
        private static int? _rpp;
        /// <summary>
        /// 列表分页默认每页行数
        /// </summary>
        public static int RPP
        {
            get
            {
                if (_rpp == null)
                {
                    _rpp = CommonConfig?.RPP ?? 20;
                }
                return _rpp.Value;
            }
        }
        #endregion

        #region 加密密钥
        private static string _encryptKey;
        /// <summary>
        /// 加密密钥
        /// </summary>
        public static string EncryptKey
        {
            get
            {
                if (_encryptKey == null)
                {
                    _encryptKey = CommonConfig?.EncryptKey ?? "";
                }
                return _encryptKey;
            }
        }
        #endregion

        #region 站点前缀
        private static string _webSitePrefix;
        /// <summary>
        /// 站点前缀
        /// </summary>
        public static string WebSitePrefix
        {
            get
            {
                if (_webSitePrefix == null)
                {
                    _webSitePrefix = CommonConfig?.WebSitePrefix ?? "";
                    if (!string.IsNullOrEmpty(_webSitePrefix))
                    {
                        _webSitePrefix.TrimStart('/');
                        _webSitePrefix.TrimEnd('/');
                        _webSitePrefix = _webSitePrefix + "/";
                    }
                }
                return _webSitePrefix;
            }
        }
        #endregion

        #region 虚拟目录
        private static string _virtualDir;
        /// <summary>
        /// 虚拟目录
        /// </summary>
        public static string VirtualDir
        {
            get
            {
                if (_virtualDir == null)
                {
                    _virtualDir = CommonConfig?.VirtualDir ?? "";
                    if (!string.IsNullOrEmpty(_virtualDir))
                    {
                        if (_virtualDir.StartsWith("/") == false)
                        {
                            _virtualDir = "/" + _virtualDir;
                        }
                    }
                }
                return _virtualDir;
            }
        }
        #endregion

        #region 系统包含的所有dll文件
        private static List<Assembly> _allAssembly;
        /// <summary>
        /// 系统包含的所有dll文件
        /// </summary>
        public static List<Assembly> AllAssembly
        {
            get
            {
                if (_allAssembly == null)
                {
                    _allAssembly = new List<Assembly>();
                    string path = Assembly.GetExecutingAssembly().Location;
                    DirectoryInfo dir = new DirectoryInfo(Path.GetDirectoryName(path));
                    //本地调试时dll并不放在一个目录下
                    if (string.IsNullOrEmpty(Configs.VirtualDir) == false && path.ToLower().Contains("temporary asp.net files\\" + Configs.VirtualDir.ToLower().Replace("/", "")))
                    {
                        dir = dir.Parent.Parent;
                    }
                    else if (path.ToLower().Contains("temporary asp.net files\\root"))
                    {
                        dir = dir.Parent.Parent;
                    }
                    else if (path.ToLower().Contains("temporary asp.net files\\vs"))
                    {
                        dir = dir.Parent.Parent;
                    }
                    foreach (var dll in dir.GetFiles("*.dll", SearchOption.AllDirectories))
                    {
                        var ass = Assembly.LoadFile(dll.FullName);
                        _allAssembly.Add(ass);
                    }
                }
                return _allAssembly;
            }
        }
        #endregion

        #region 数据库连接字符串
        private static List<ConnectionStringSettings> _connectStrings;
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public static List<ConnectionStringSettings> ConnectStrings
        {
            get
            {
                if (_connectStrings == null)
                {
                    _connectStrings = new List<ConnectionStringSettings>();

                    foreach (ConnectionStringSettings cs in ConfigurationManager.ConnectionStrings)
                    {
                        _connectStrings.Add(cs);
                    }
                }
                return _connectStrings;
            }
        }
        #endregion

        #region 框架版本
        private static string _frameworkVersion;
        /// <summary>
        /// 获取框架版本
        /// </summary>
        public static string FrameworkVersion
        {
            get
            {
                if (string.IsNullOrEmpty(_frameworkVersion))
                {
                    Assembly asm = Assembly.GetExecutingAssembly();
                    _frameworkVersion = asm.GetName().Version.ToString();
                }
                return _frameworkVersion;
            }
        }
        #endregion

        #region CookiePre
        private static string _cookiePre;
        /// <summary>
        /// 获取Cookie前缀
        /// </summary>
        public static string CookiePre
        {
            get
            {
                if (_cookiePre == null)
                {
                    _cookiePre = CommonConfig?.CookiePrefix ?? "";
                }
                return _cookiePre;
            }
        }
        #endregion



        #region 主域
        private static string _mainDomain;
        /// <summary>
        /// 主域
        /// </summary>
        public static string MainDomain
        {
            get
            {
                if (_mainDomain == null)
                {
                    _mainDomain = CommonConfig?.MainDomain ?? "";
                }
                return _mainDomain;
            }
        }
        #endregion

        #region 主机
        private static bool? _mainMachine;
        /// <summary>
        /// 主机，在负载均衡的境况下，只有设定为主机才可能开启系统轮询
        /// </summary>
        public static bool MainMachine
        {
            get
            {
                if (_mainMachine == null)
                {
                    _mainMachine = CommonConfig?.MainMachine ?? false;
                }
                return _mainMachine.Value;
            }
        }
        #endregion


        #region 更新数据库
        private static bool? _syncDb;
        /// <summary>
        /// 是否更新数据库
        /// </summary>
        public static bool SyncDb
        {
            get
            {
                if (_syncDb == null)
                {
                    _syncDb = CommonConfig?.SyncDb ?? false;
                }
                return _syncDb.Value;
            }
        }
        #endregion



        #region 是否是调试模式
        private static bool? _isQuickDebug;
        /// <summary>
        /// 是否启动调试模式
        /// </summary>
        public static bool IsQuickDebug
        {
            get
            {
                if (_isQuickDebug == null)
                {
                    _isQuickDebug = CommonConfig?.QuickDebug ?? false;
                }
                return _isQuickDebug.Value;
            }
        }

        #endregion

        #region 是否记录日志
        private static bool? _enableLog;
        /// <summary>
        /// 是否记录日志
        /// </summary>
        public static bool EnableLog
        {
            get
            {
                if (_enableLog == null)
                {
                    _enableLog = CommonConfig?.EnableLog ?? false;
                }
                return _enableLog.Value;
            }
        }

        #endregion


    }
}
