using System;

namespace Asap.Library.Model
{
    #region SCOPE


    [Serializable]

    public class Scope
    {
        #region Properties


        public string ScopeID { get; set; }


        public string AppID { get; set; }

        public string Name { get; set; }


        public string CodeName { get; set; }


        public string Expression { get; set; }


        public string Description { get; set; }


        public int SortID { get; set; }


        public string Inherited { get; set; }


        public DateTime ModifyTime { get; set; }


        #endregion
    }

    [Serializable]
    public sealed class ScopeCollection : EditableDataObjectCollectionBase<Scope>
    {
    }

    #endregion





    [Serializable]
    public class ScopeQueryCondition
    {

    }



}
