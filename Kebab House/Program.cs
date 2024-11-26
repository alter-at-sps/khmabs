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
                    Console.WriteLine("add-recipe - add a recipe to known recipes\n");

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
                else if (input == "add-recipe")
                {
                    Console.Write("Name of the new recipe: ");
                    input = Console.ReadLine();

                    if (input == null) continue;
                    if (input == "") continue;

                    string rec_name = input;

                    foreach (Recipe recipe in known_recipes)
                    {
                        if (recipe.name == rec_name) {
                            Console.WriteLine("Recipe name is already taken!");
                            continue;
                        }
                    }

                    Console.Write("\nAdd required resources to recipe, enter empty to finish recipe\n");

                    Recipe new_recipe = new Recipe(rec_name, new List<Resource>());

                    while (true)
                    {
                        Console.Write("New required resource: ");
                        input = Console.ReadLine();

                        if (input == null) break;
                        if (input == "") break;

                        string res_name = input;

                        Console.Write("What amount is required: ");
                        input = Console.ReadLine();

                        if (input == null) continue;
                        if (input == "") continue;

                        int res_amount = Int32.Parse(input);

                        new_recipe.requestedResources.Add(new Resource(res_name, res_amount));

                        Console.WriteLine("\nCurrent recipe resources:");
                        new_recipe.writeoutDescription();
                    }

                    known_recipes.Add(new_recipe);
                    Console.WriteLine("New recipe added!\n");
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
