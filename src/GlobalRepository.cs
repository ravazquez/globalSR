using System.Collections.Generic;

namespace GlobalSR
{
    public class GlobalRepository<T>
    {
        public static Dictionary<string, List<T>> entries = new Dictionary<string, List<T>>();
        public static Dictionary<string, int> subscriptions = new Dictionary<string, int>();
    }
}
