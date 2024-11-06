using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kebab_House
{
    internal struct Resource
    {
        public string name;
        public int amount;

        public Resource(string name, int amount)
        {
            this.name = name;
            this.amount = amount;
        }
    }
}
