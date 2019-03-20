using System.Configuration;

namespace Asap.Library.Core
{
    public class CommonConfig : ConfigurationSection
    {
        /// <summary>
        /// 加密密钥
        /// </summary>
        [ConfigurationProperty("EncryptKey", DefaultValue = "")]
        public string EncryptKey
        {
            get
            {
                return (string)this["EncryptKey"];
            }
            set
            {
                this["EncryptKey"] = value;
            }
        }

        /// <summary>
        /// 分页默认的每页行数
        /// </summary>
        [ConfigurationProperty("RPP", DefaultValue = 20)]
        public int RPP
        {
            get
            {
                return (int)this["RPP"];
            }
            set
            {
                this["RPP"] = value;
            }
        }

        /// <summary>
        /// 启用服务监控
        /// </summary>
        [ConfigurationProperty("EnableServiceMonitor", DefaultValue = false)]
        public bool EnableServiceMonitor
        {
            get
            {
                return (bool)this["EnableServiceMonitor"];
            }
            set
            {
                this["EnableServiceMonitor"] = value;
            }
        }

        /// <summary>
        /// 是否调试模式
        /// </summary>
        [ConfigurationProperty("QuickDebug", DefaultValue = false)]
        public bool QuickDebug
        {
            get
            {
                return (bool)this["QuickDebug"];
            }
            set
            {
                this["QuickDebug"] = value;
            }
        }

        /// <summary>
        /// 站点前缀
        /// </summary>
        [ConfigurationProperty("WebSitePrefix", DefaultValue = "")]
        public string WebSitePrefix
        {
            get
            {
                return (string)this["WebSitePrefix"];
            }
            set
            {
                this["WebSitePrefix"] = value;
            }
        }

        /// <summary>
        /// 是否启用日志
        /// </summary>
        [ConfigurationProperty("EnableLog", DefaultValue = false)]
        public bool EnableLog
        {
            get
            {
                return (bool)this["EnableLog"];
            }
            set
            {
                this["EnableLog"] = value;
            }
        }

        /// <summary>
        /// Cookie前缀，如果同一机器部署多个站点，应该设置不同的Cookie前缀
        /// </summary>
        [ConfigurationProperty("CookiePrefix", DefaultValue = "CodeArt")]
        public string CookiePrefix
        {
            get
            {
                return (string)this["CookiePrefix"];
            }
            set
            {
                this["CookiePrefix"] = value;
            }
        }

        /// <summary>
        /// 主域
        /// </summary>
        [ConfigurationProperty("MainDomain", DefaultValue = "")]
        public string MainDomain
        {
            get
            {
                return (string)this["MainDomain"];
            }
            set
            {
                this["MainDomain"] = value;
            }
        }

        /// <summary>
        /// 是否为主机，只有主机会运行系统轮询
        /// </summary>
        [ConfigurationProperty("MainMachine", DefaultValue = false)]
        public bool MainMachine
        {
            get
            {
                return (bool)this["MainMachine"];
            }
            set
            {
                this["MainMachine"] = value;
            }
        }

        /// <summary>
        /// 虚拟目录
        /// </summary>
        [ConfigurationProperty("VirtualDir", DefaultValue = "")]
        public string VirtualDir
        {
            get
            {
                return (string)this["VirtualDir"];
            }
            set
            {
                this["VirtualDir"] = value;
            }
        }

        /// <summary>
        /// 代理，用于代码中访问外部网站
        /// </summary>
        [ConfigurationProperty("Proxy", DefaultValue = "")]
        public string Proxy
        {
            get
            {
                return (string)this["Proxy"];
            }
            set
            {
                this["Proxy"] = value;
            }
        }

        /// <summary>
        /// 是否同步数据库
        /// </summary>
        [ConfigurationProperty("SyncDb", DefaultValue = false)]
        public bool SyncDb
        {
            get
            {
                return (bool)this["SyncDb"];
            }
            set
            {
                this["SyncDb"] = value;
            }
        }


    }
}
