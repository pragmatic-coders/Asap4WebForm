using Asap.Library.Model;
using System;

namespace Asap.Library.Model
{
    

    /// <summary>
    /// USER 扩展表[通常用作查询]
    /// </summary>
    [Serializable]
    public class User
    {
        public string UserID { get; set; }


        public string FirstName { get; set; }


        public string LastName { get; set; }


        public string DisplayName { get; set; }


        public string Login_ID { get; set; }


        public string Password { get; set; }


        public string Email { get; set; }


        public DateTime CreateTime { get; set; }


        public string ModifierID { get; set; }


        public DateTime ModifyTime { get; set; }

        public bool IsADAccount { get; set; }


    }

    [Serializable]
    public sealed class UserCollection : EditableDataObjectCollectionBase<User>
    {
    }
}
