namespace FantasticBattle
{
    public class Singleton<T> where T : class, new()
    {
        private static T instance = null;
        private static readonly object padlock = new object();

        public Singleton()
        {
        }

        public static T Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new T();
                    }
                    return instance;
                }
            }
        }
    }
}
