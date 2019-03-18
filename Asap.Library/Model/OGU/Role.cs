using Asap.Library.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asap.Library.Model.OGU
{
   

    [Serializable]
    public class ROLEQueryCondition
    {
        #region Properties

        /// <summary>
        /// 应用标识
        /// </summary>
       
        public string APP_ID { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
       
        public string Name { get; set; }

        /// <summary>
        /// 英文标识
        /// </summary>
      
        public string CODE_Name { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
      
        public int STATUS { get; set; }

     
        public string FunctionType { get; set; }

        #endregion
    }


    /// <summary>
    /// ROLE 扩展表[通常用作查询]
    /// </summary>
    [Serializable]
    public class ROLE
    {
        #region Properties

        /// <summary>
        /// 角色标识
        /// </summary>
       
        public string ROLE_ID { get; set; }

        /// <summary>
        /// 应用标识
        /// </summary>
       
        public string APP_ID { get; set; }

        /// <summary>
        /// 应用名称
        /// </summary>
      
        public string APP_Name { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
       
        public string Name { get; set; }

        /// <summary>
        /// 英文标识
        /// </summary>
      
        public string CODE_Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
       
        public string DESCRIPTION { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
      
        public int SORT_ID { get; set; }

        /// <summary>
        /// 是否允许继承
        /// </summary>
      
        public string INHERITED { get; set; }

        /// <summary>
        /// 是否允许委托
        /// </summary>
       
        public string ALLOW_DELEGATE { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
       
        public int STATUS { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
     
        public string CREATOR_ID { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
       
        public string MODIFY_ID { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
      
        public DateTime MODIFY_TIME { get; set; }


        #endregion
    }

    [Serializable]
    public sealed class ROLECollection : EditableDataObjectCollectionBase<ROLE>
    {
    }

 
}
