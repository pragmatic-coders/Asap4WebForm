using System;

namespace Asap.Library.Extension
{
    public static class SystemExtension
    {
        public static string ToNoSplitString(this Guid self)
        {
            return self.ToString().Replace("-", string.Empty);
        }
    }
}
