using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asap.Library.Core
{
    public class SupportedLanguage
    {
        /// <summary>
        /// 语言编码，如en，zh-cn等
        /// </summary>
        public string LanguageCode { get; set; }
        /// <summary>
        /// 语言名称
        /// </summary>
        public string LanguageName { get; set; }
        /// <summary>
        /// 是否默认
        /// </summary>
        public bool IsDefault { get; set; }
    }
}
