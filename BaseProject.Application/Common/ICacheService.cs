using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Application.Common
{
    public interface ICacheService
    {
        Task<T> Get<T>(string key);
        Task Set<T>(string key, T value, TimeSpan? expiry = null);
        Task Remove(string key);
    }
}
