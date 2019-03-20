using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Asap.Library.Core
{
    public static class DataClass
    {
        #region 默认DataContext的构造函数
        private static Dictionary<string, ConstructorInfo> _dataContextCI;
        /// <summary>
        /// 获取默认DataContext的构造函数
        /// </summary>
        public static Dictionary<string, ConstructorInfo> DataContextCI
        {
            get
            {
                if (_dataContextCI == null)
                {
                    _dataContextCI = new Dictionary<string, ConstructorInfo>();
                    var ass = Configs.AllAssembly;
                    foreach (var a in ass)
                    {
                        var tps = a.GetExportedTypes().Where(x => typeof(DbContext).IsAssignableFrom(x) && x.Name != "FrameworkContext" && x.Name != "DbContext").ToList();
                        foreach (var t in tps)
                        {
                            var con = t.GetConstructor(new Type[] { typeof(string) });
                            if (con != null)
                            {
                                _dataContextCI.Add(t.Name, con);
                            }
                        }
                    }
                }
                return _dataContextCI;
            }
        }
        #endregion

    }
}
