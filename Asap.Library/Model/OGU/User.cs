using Asap.Library.Model.Base;
using System;

namespace Asap.Library.Model.OGU
{
    [Serializable]
    public class USERQueryCondition
    {
        public string FIRST_Name { get; set; }
        public string LAST_Name { get; set; }
        public string LOGON_ID { get; set; }
        public string Function_Type { get; set; }
    }
    
    /// <summary>
    /// USER 扩展表[通常用作查询]
    /// </summary>
    [Serializable]
    public class USER
    {
        public string USER_ID { get; set; }


        public string FIRST_Name { get; set; }


        public string LAST_Name { get; set; }


        public string DISPLAY_NAME { get; set; }


        public string LOGON_ID { get; set; }


        public string USER_PWD { get; set; }


        public string EMAIL { get; set; }


        public DateTime CREATE_TIME { get; set; }


        public string MODIFIER_ID { get; set; }


        public DateTime MODIFY_TIME { get; set; }

        public int IN_AD { get; set; }

        
    }

    [Serializable]
    public sealed class USERCollection : EditableDataObjectCollectionBase<USER>
    {
    }
}
