using System;

namespace Asap.Library.Core
{
    [AttributeUsageAttribute(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false, AllowMultiple = false)]
    public class XElementSerializableAttribute : Attribute
    {
    }
}
