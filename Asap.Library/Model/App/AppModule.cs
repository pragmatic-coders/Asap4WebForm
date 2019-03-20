using System;

namespace Asap.Library.Model
{
    [Serializable]
    public class AppModule
    {
        #region Properties

        public string AppModuleID { get; set; }

      
        public string AppID { get; set; }


        public string AppModuleName { get; set; }


        public string AliasName { get; set; }

        
        public string ParentID { get; set; }


        public int SortID { get; set; }

  
        public int Status { get; set; }


        #endregion

        public static int CompareAppModule(AppModule model, AppModule other)
        {
            return model.SortID - other.SortID;
        }
    }

  

}
