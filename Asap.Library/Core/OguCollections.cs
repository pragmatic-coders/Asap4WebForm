using Asap.Library.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asap.Library.Core
{
    [Serializable]
    public sealed class OguObjectCollection<T> : ReadOnlyCollection<T> where T : IOguObject
    {
        /// <summary>
        /// 初始化类的新实例
        /// </summary>
        /// <param name="list"></param>
        public OguObjectCollection(IList<T> list)
            : base(list)
        {
        }
        /// <summary>
        /// 初始化类的新实例。
        /// </summary>
        /// <param name="objs">机构、人员和组的对象数组。</param>
        public OguObjectCollection(params T[] objs)
            : base(new List<T>())
        {
            foreach (T obj in objs)
                Items.Add(obj);
        }
        /// <summary>
        /// 索引器。
        /// </summary>
        /// <param name="index">索引。</param>
        /// <returns>集合中与指定索引匹配的对象。</returns>
        public new T this[int index]
        {
            get
            {
                return base[index];
            }
        }
    }
}
