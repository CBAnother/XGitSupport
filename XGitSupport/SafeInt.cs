using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XGitSupport
{
    class SafeInt
    {
        private int _val;
        private object _lock = new object();

        public SafeInt(int val)
        {
            _val = val;
        }
        public int Add(int val)
        {
            lock (_lock)
            {
                _val += val;
                return _val;
            }
        }

        public int GetVal()
        {
            lock (_lock)
            {
                return _val;
            }
        }
    }
}
