using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redo_Undo
{
    class Singleton
    {
        private static Singleton instance;
        public int BehaviorIndex;

        protected Singleton()
        {
            this.BehaviorIndex = 0;
        }

        public static Singleton Instance()
        {
            if (instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }
    }
}
