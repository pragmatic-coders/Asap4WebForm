using System;

namespace Asap.Library.Model
{
    [Serializable]
    public class AppLink
    {
        #region Properties

        public string AppLinkID { get; set; }


        public string AppID { get; set; }


        public string AppModuleID { get; set; }


        public int LinkID { get; set; }


        public string LinkName { get; set; }


        public int SortID { get; set; }


        public string LinkUrl { get; set; }


        public string FunID { get; set; }

        public int Status { get; set; }


        #endregion
    }

    [Serializable]
    public sealed class AppLinksCollection : EditableDataObjectCollectionBase<AppLink>
    {
    }
}
