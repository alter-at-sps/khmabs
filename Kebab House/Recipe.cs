using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kebab_House
{
    internal class Recipe
    {
        public string name;
        public List<Resource> requestedResources;

        public Recipe(string name, List<Resource> requiredResources)
        {
            this.name = name;
            this.requestedResources = requiredResources;
        }

        public bool makeKebab(ResourceStorage resourceStorage)
        {
            return resourceStorage.consumeStock(requestedResources);
        }

        public void writeoutDescription()
        {
            Console.Write($"{name} - ");

            for (int i = 0; i < requestedResources.Count - 1; i++)
            {
                Console.Write($"{requestedResources[i].name} {requestedResources[i].amount}x, ");
            }

            Console.WriteLine($"{requestedResources[requestedResources.Count - 1].name} {requestedResources[requestedResources.Count - 1].amount}x");
        }
    }
}
