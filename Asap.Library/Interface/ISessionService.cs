using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asap.Library.Interface
{
    public interface ISessionService
    {
        T Get<T>(string key);
        void Set<T>(string key, T val);
        string SessionId { get; }
    }
}
