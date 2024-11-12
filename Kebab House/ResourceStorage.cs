using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kebab_House
{
    internal class ResourceStorage
    {
        public Dictionary<string, int> availableResources;

        public ResourceStorage()
        {
            this.availableResources = new Dictionary<string, int>();
        }

        public void refillStock(Resource receivedResource)
        {
            availableResources.TryAdd(receivedResource.name, 0);   
            availableResources[receivedResource.name] = availableResources.GetValueOrDefault(receivedResource.name, 0) + receivedResource.amount;
        }

        public bool consumeStock(List<Resource> requiredResources)
        {
            // validate consume request

            foreach (Resource resource in requiredResources)
            {
                if (!availableResources.ContainsKey(resource.name)) return false;
                if (availableResources[resource.name] < resource.amount) return false;
            }

            // perform request

            foreach (Resource resource in requiredResources)
            {
                availableResources[resource.name] -= resource.amount;
            }

            return true;
        }

        public void writeoutStorage()
        {
            // lambdas, noice
            
            availableResources.ToList().ForEach(resource =>
            {
                Console.WriteLine($"{resource.Key} - {resource.Value}");
            });
        }
    }
}
