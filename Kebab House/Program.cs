namespace Kebab_House
{
    

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Kebab-House-Managment-And-Bookeeping-Software");

            ResourceStorage local_storage = new ResourceStorage();
            List<Recipe> known_recipes = new List<Recipe>();

            known_recipes.Add(new Recipe("Kebab Classic", [new Resource("meat", 1)]));
            known_recipes.Add(new Recipe("Kebab Spicy", [new Resource("meat", 1), new Resource("spice", 120)]));

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
                    // Console.WriteLine("recipes - manage known recipes\n");

                    Console.WriteLine("refill - add resources to storage");
                    Console.WriteLine("cook - make kebab with a recipe (remove resources from storage)\n");
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
                    input = Console.ReadLine();

                    if (input == null) continue;
                    if (input == "") continue;

                    string res_name = input;

                    Console.Write("What volume is being refilled: ");
                    input = Console.ReadLine();

                    if (input == null) continue;
                    if (input == "") continue;

                    int res_amount = Int32.Parse(input);

                    local_storage.refillStock(new Resource(res_name, res_amount));

                    Console.WriteLine($"\nRefilled {res_name}, current stock is {local_storage.availableResources[res_name]}\n");
                }
                else if (input == "cook")
                {
                    Console.WriteLine("Known recipes:");
                    for (int i = 0; i < known_recipes.Count; i++)
                    {
                        Console.WriteLine($"({i + 1}) {known_recipes[i].name}");
                    }

                    Console.Write("\nSelect recipe to cook (write its number): ");
                    input = Console.ReadLine();

                    if (input == null) continue;
                    if (input == "") continue;

                    int recipe_index = Int32.Parse(input);

                    if (recipe_index < 1 || recipe_index > known_recipes.Count)
                    {
                        Console.WriteLine("Unknown recipe");
                        continue;
                    }

                    recipe_index--;

                    if (!known_recipes[recipe_index].makeKebab(local_storage))
                    {
                        Console.WriteLine("Not enough resources in stock!");
                        continue;
                    }

                    Console.WriteLine($"Made kebab using recipe '{known_recipes[recipe_index].name}'!");
                }
                else
                {
                    Console.WriteLine("Unknown command\n");
                }
            }
        }
    }
}
