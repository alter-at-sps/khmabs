using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kebab_House
{
    internal class StockGuy
    {
        public StockGuy(ResourceStorage designated_storage) {
            this.designated_storage = designated_storage;
        }

        public bool fetchStock(List<Resource> requiredResources)
        {
            requests_complete++;
            return designated_storage.consumeStock(requiredResources);
        }
        
        public int GetRequestsComplete() { return requests_complete; }

        private ResourceStorage designated_storage;
        private int requests_complete = 0;
    }
}
