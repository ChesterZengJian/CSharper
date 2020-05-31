using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncCounter.Serivces
{
    public class CounterSerivce
    {
        private int _count;

        public int GetLatestCounter()
        {
            return _count++;
        }
    }
}
