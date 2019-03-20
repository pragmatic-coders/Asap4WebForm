using System;
using System.ComponentModel.DataAnnotations;

namespace Asap.Library.Model
{
    [Serializable]
    public abstract class TopBasePoco
    {
        private Guid _id;
        [Key]
        public Guid ID
        {
            get
            {
                if (_id == Guid.Empty)
                {
                    _id = Guid.NewGuid();
                }
                return _id;
            }
            set
            {
                _id = value;
            }
        }



    }
}
