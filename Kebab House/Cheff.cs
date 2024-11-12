using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kebab_House
{
    class Cheff
    {
        public Cheff(List<StockGuy> available_stockers) {
            this.available_stockers = available_stockers;
        }

        public bool cookRecipe(Recipe recipe)
        {
            requests_complete++;

            foreach (StockGuy sguy in available_stockers)
            {
                if (sguy.fetchStock(recipe.requestedResources))
                {
                    recipes_cooked++;
                    return true;
                }
            }

            return false;
        }

        public int GetRecipesCooked() { return recipes_cooked; }
        public int GetRequestsComplete() { return requests_complete; }

        List<StockGuy> available_stockers;

        private int recipes_cooked = 0;
        private int requests_complete = 0;
    }
}
