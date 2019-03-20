using Asap.Library.Interface;
using Asap.Library.Model;
using System;

namespace Asap.Library.Model
{

    [Serializable]
    public class AppMenu : IModule
    {
        #region Properties

        public string ID { get; set; }

    
        public string APP_ID { get; set; }

 
        public string FUN_ID { get; set; }

     
        public string Name { get; set; }


        public string PARENT_ID { get; set; }


        public string DESCRIPTION { get; set; }


        public int IS_LEAF { get; set; }

    
        public int SORT_ID { get; set; }


        public int STATUS { get; set; }

       
        public string DefaultUrl { get; set; }


        public string CREATOR_ID { get; set; }

      
        public string MODIFIER_ID { get; set; }

    
        public DateTime MODIFY_TIME { get; set; }

    
        public IApplication Application { get; private set; }

   
        public IPermission Permission { get; private set; }


        #endregion


        #region Constructors

        public AppMenu()
        { }

        public AppMenu(IPermission permission, string requestUrl)
        {
            InitProperties(permission, requestUrl);
        }

        #endregion


        #region Private Methods

        private void InitProperties(IPermission permission, string requestUrl)
        {
            if (permission != null)
            {
                string appID = permission.Application.ID;
                AppMenu md = ModuleAdapter.Instance.GetCollection(m => m.APP_ID == appID
                    && m.DefaultUrl.Equals(requestUrl, StringComparison.CurrentCultureIgnoreCase)
                    ).FirstOrDefault();
                if (md != null)
                {
                    this.ID = md.ID;
                    this.Name = md.Name;
                }
                this.DefaultUrl = requestUrl;
                this.Permission = permission;
                this.Application = permission.Application;
            }
        }

        #endregion
        public static int CompareRule(AppMenu model, AppMenu other)
        {
            return model.SORT_ID - other.SORT_ID;
        }
    }

  
}
