namespace AStar
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