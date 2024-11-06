namespace Kebab_House
{
    

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Kebab-House-Managment-And-Bookeeping software");

            ResourceStorage local_storage = new ResourceStorage();
            List<Recipe> known_recipes = new List<Recipe>();

            known_recipes.Add(new Recipe("Kebab Classic", [new Resource("meat", 1)]));
            known_recipes.Add(new Recipe("Kebab Spicy", [new Resource("meat", 1), new Resource("spice", 12873981)]));

            while (true)
            {
                Console.Write("> ");
                string? input = Console.ReadLine();

                if (input == null) continue;
                if (input == "") continue;
                
                // command table

                if (input == "help")
                {
                    Console.WriteLine("Available commands:\n");

                    Console.WriteLine("help - this command list");
                    Console.WriteLine("status - print the current state of the local storage");
                    Console.WriteLine("recipes - manage known recipes\n");

                    Console.WriteLine("refill - add resources to storage");
                    Console.WriteLine("make - make kebab with a recipe (remove resources from storage)\n");
                } 
                else if (input == "status")
                {
                    Console.WriteLine("The local storage contains:\n");
                    local_storage.writeoutStorage();

                    Console.WriteLine("\nKnown recipes:\n");
                    foreach (Recipe recipe in known_recipes)
                    {
                        recipe.writeoutDescription();
                    }

                    Console.Write('\n');
                } 
                else if (input == "refill")
                {
                    Console.Write("What resource is being refilled: ");
                }
                else if (input == "make")
                {
                    Console.WriteLine("Select recipe to make:\n");
                    for (int i = 0; i < known_recipes.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}) {known_recipes[i].name}");
                    }
                }
                else
                {
                    Console.WriteLine("Unknown command\n");
                }
            }
        }
    }
}
