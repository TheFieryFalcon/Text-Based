Variable variable = new Variable();
void ExplorationEngine(int CurrentTile)
{
    

    int[] movementEast = new int[] { 1, 1, 0, 3, 4, 5/*placeholder*/, 6/*placeholder*/, 7 };
    string[] locationName = new string[] { "Jungle", "Marsh", "East of House", "Mysterious House", "Plains", "Mesa", "Lake", "Island" };
    int[] movementWest = new int[] { 2, 0, 2, 3, 4/*placeholder*/, 5/*placeholder*/, 6/*placeholder*/, 7 };
    int[] movementSouth = new int[] { 4, 1/*placeholder*/, 2, 3, 5, 6, 6/*placeholder*/, 7 };
    int[] movementNorth = new int[] { 0/*placeholder*/, 1/*placeholder*/, 2, 3, 0, 4, 5, 7 };
    Dictionary<int, string> ItemsInLocation = new Dictionary<int, string>();
    string[,,] ItemUsages = new string[,,] { { { "Axe", "You heave the (quite heavy) axe and somehow manage to chop down a tree. Then, you clumsily cut the log in half multiple times until you have several planks.", "You gain: Planks", "Planks", "Obtain Item" }, {"", "", "", "", ""} } };
    ItemsInLocation.Add(0, "Axe");
    
    
    string[] locationDesc = new string[] {
    "In the jungle, you trudge for what seems like hours before arriving at a familiar crossroads. It seems as though you are lost. Which direction will you go in?",
    "You arrive at the edge of a jungle. In front of you is a vast swamp.",
    "You stand to the east of a house that seems familiar to you. Surrounding the house is a lush, green jungle.",
    "Placeholder",
    "You arrive in a breathtaking expanse of grass, stretching all the way to the horizon as far as you can see.",
    "You are in a martian-like expanse of red sand. Off in the distance, you see a few vultures circling high above.",
    "In front of you is a vast lake, at the center of which you can vaguely make out an island shrouded by mist.",
    "Placeholder"

        };

    

    //This function handles exploration: movement based on your current location
    Console.WriteLine("YOU ARE IN: " + locationName[CurrentTile]);
    string Input;
    
    Input = Console.ReadLine();
    string movementDirection;
    
    var JungleRNG = new Random(); //you can only proceed if you roll a 5 on a d10
    if (Input.StartsWith("go") && Input.Length > 3) //go command
    {
        if (CurrentTile == 0) //if you are in a jungle
        {
            if (JungleRNG.Next(1, 6) == 5) //and you roll a 5, you can move
            {

                movementDirection = Input.Substring(3);
                if (movementDirection == "east")
                {
                    CurrentTile = movementEast[CurrentTile];

                }
                else if (movementDirection == "west")
                {
                    CurrentTile = movementWest[CurrentTile];
                }
                else if (movementDirection == "north")
                {
                    CurrentTile = movementNorth[CurrentTile];
                }
                else if (movementDirection == "south")
                {
                    CurrentTile = movementSouth[CurrentTile];
                }
                else
                {
                    Console.WriteLine("Invalid Direction.");
                }
            }

        }
        else //if you are not in the jungle
        {

            movementDirection = Input.Substring(3);
            if (movementDirection == "east")
            {
                CurrentTile = movementEast[CurrentTile];

            }
            else if (movementDirection == "west")
            {
                CurrentTile = movementWest[CurrentTile];
            }
            else if (movementDirection == "north")
            {
                CurrentTile = movementNorth[CurrentTile];
            }
            else if (movementDirection == "south")
            {
                CurrentTile = movementSouth[CurrentTile];
            }
            else
            {
                Console.WriteLine("Invalid Direction.");
            }
        }

    }
    else if (Input.StartsWith("help")) //help command
    {
        Console.WriteLine("Note: ALL COMMANDS ARE LOWERCASE ONLY, C# IS CASE SENSITIVE \n" +
            "Command List: \n" +
            "go \n" +
            "Usage: go [direction] \n" +
            "Example: go east \n" +
            "help \n" +
            "Usage: help (command) \n" +
            "Example: help help \n" +
            "get \n" +
            "Usage: get [item] \n" +
            "Example: get Axe \n" +
            "variable.inventory \n" +
            "Usage: variable.inventory \n" +
            "Example: variable.inventory \n");
    }
    else if (Input.StartsWith("get")) //get command
    {
        if (ItemsInLocation.TryGetValue(CurrentTile, out var item))
        {
            if (variable.inventory.Contains(item) == false && Input.Contains(item) == true)
            {
                variable.GetItem(item);

                Console.WriteLine("You have obtained " + item + ". You now have " + (variable.inventory.Length-1) + " items.");
            }
            else
            {
                Console.WriteLine("That item is not here.");
            }
        }
        else
        {
            Console.WriteLine("That item is not here.");
        }

    }
    else if (Input.StartsWith("inventory")) //inventory command
    {
        if (variable.inventory.Length == 0)
        {
            Console.WriteLine("You have no items in your inventory.");
        }
        for (int i = 0; i < variable.inventory.Length; i++)
        {
            Console.WriteLine(variable.inventory[i]);
        }
    }
    else if (Input.StartsWith("use")) //use command
    {
        
        for (int i = 0; i < 2; i++)
        {

            if (variable.inventory.Contains(ItemUsages[CurrentTile, i, 0]) && Input.Substring(4) == ItemUsages[CurrentTile, i, 0])

            {
                switch (ItemUsages[CurrentTile, i, 4])
                {
                    case "Obtain Item":
                        string item = ItemUsages[CurrentTile, i, 3];
                       var isPresentInInventory = variable.GetItem(item);
                        if (isPresentInInventory == 0)
                        {
                            Console.WriteLine(ItemUsages[CurrentTile, i, 1]);
                        }
                        
                        break;

                }

            }
            else if (!variable.inventory.Contains(ItemUsages[CurrentTile, i, 0]) && Input.Substring(4) == ItemUsages[CurrentTile, i, 0])
            {
                Console.WriteLine("You do not have that item.");
            }


        }

    }
    else
    {
        Console.WriteLine("Invalid Command or Invalid Version.");
    }

    Console.WriteLine(locationDesc[CurrentTile]);
    ExplorationEngine(CurrentTile);

}

Console.WriteLine("Build Successful. Starting Game...");
Console.WriteLine("Textblocks Version Dev-06082022-01"); //UPDATE EVERY DAY
ExplorationEngine(2);





