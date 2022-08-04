


static int ExplorationEngine(int CurrentTile)
{

    int[] movementEast = new int[] { 1, 1, 0, 3, 4, 5/*placeholder*/, 6/*placeholder*/, 7 };
    string[] locationName = new string[] { "Jungle", "Marsh", "East of House", "Mysterious House", "Plains", "Mesa", "Lake", "Island" };
    int[] movementWest = new int[] { 2, 0, 2, 3, 4/*placeholder*/, 5/*placeholder*/, 6/*placeholder*/, 7 };
    int[] movementSouth = new int[] {4, 1/*placeholder*/, 2, 3, 5, 6, 6/*placeholder*/, 7};
    int[] movementNorth = new int[] { 0/*placeholder*/, 1/*placeholder*/, 2, 3, 0, 4, 5, 7};
    Dictionary<int, string> ItemsInLocation = new Dictionary<int, string>();
    Dictionary<int, string> ItemUsages = new Dictionary<int, string>();
    ItemsInLocation.Add(0, "Axe");
    string[] inventory = new string[0];
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
    int error = 1;  //useless
    Input = Console.ReadLine();
    string movementDirection;
    int length;
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
            "inventory \n" +
            "Usage: inventory \n" +
            "Example: inventory \n");
    }
    else if (Input.StartsWith("get")) //get command
    {
        if (ItemsInLocation.TryGetValue(CurrentTile, out var item))
        {
            if (inventory.Contains(item) == false && Input.Contains(item) == true)
            {
                Array.Resize(ref inventory, inventory.Length + 1);
                inventory[inventory.Length - 1] = item;
                
                Console.WriteLine("You have obtained " + item + ". You now have " + inventory.Length + " items.");
            }
            else
            {
                Console.WriteLine("That item is not here.");
            }
        }
        
    }
    else if (Input.StartsWith("inventory"))
    {
        if (inventory.Length == 0)
        {
            Console.WriteLine("You have no items in your inventory.");
        }
        for (int i = 0; i < inventory.Length; i++)
        {
            Console.WriteLine(inventory[i]);
        }
    }
    else
    {
        Console.WriteLine("Invalid Command or Invalid Version.");
    }
    
    Console.WriteLine(locationDesc[CurrentTile]);
    ExplorationEngine(CurrentTile);
    return (error);
}
Console.WriteLine("Build Successful. Starting Game...");
Console.WriteLine("Textblocks Version Dev-03082022-01");
ExplorationEngine(2);


