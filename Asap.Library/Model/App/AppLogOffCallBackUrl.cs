using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asap.Library.Model
{
    public class AppLogOffCallBackUrl
    {
        /// <summary>
        /// 应用ID
        /// </summary>
        public string AppID { get; set; }

        /// <summary>
        /// 应用注销回调的Url
        /// </summary>
        public string LogOffCallBackUrl { get; set; }
    }
}
