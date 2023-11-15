using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APathfinding
{
    internal class Singleton<T> where T : class, new()
    {
        private static T instacne;
        public static T Instance
        {
            get
            {
                if (instacne == null)
                    instacne = new T();
                return instacne;
            }
        }
    }
}