using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternSingleton
{
    /// <summary>
    /// Klasse, um Singleton-Pattern auszuprobieren.
    /// Vorsicht: Ohne Thread-Synchronisation!
    /// </summary>
    class UserContext
    {
        //// Version 1: early initialization
        //static UserContext instance = new UserContext();  // 
        //private UserContext() { }

        //public static UserContext Instance
        //{
        //    get
        //    {
        //        return instance;
        //    }
        //}

        // Version 2: lazy initialization
        static UserContext instance;

        public int UserId { get; private set; }
        public int UserName { get; private set; }

        private UserContext() { }

        public void Load()
        {
            // load some data
        }
        public static UserContext Instance
        {
            get
            {
                if (instance == null)
                    instance = new UserContext();
                return instance;
            }
        }
    }
}
