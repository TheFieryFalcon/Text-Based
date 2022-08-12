#pragma warning disable IDE0057, CS8600, CS8602

Variable variable = new Variable();
int Level = 1;
int SwordLevel = 0;
int Attack = 1;
int Defense = 0;
int Speed = 0;
int Health = 20;
int XPUntilNextLevel = 100;
void ExplorationEngine(int CurrentTile)
{

    Attack = Attack * SwordLevel;
    int[] movementEast = new int[] { 1, 1, 0, 3, 4, 5/*placeholder*/, 6/*placeholder*/, 7, 8/*placeholder*/};
    string[] locationName = new string[] { "Jungle", "Marsh", "East of House", "Mysterious House", "Plains", "Mesa", "Lake", "Island", "Marsh Island" };
    int[] movementWest = new int[] { 2, 0, 2, 3, 4/*placeholder*/, 5/*placeholder*/, 6/*placeholder*/, 7, 1};
    int[] movementSouth = new int[] { 4, 1/*placeholder*/, 2, 3, 5, 6, 6/*placeholder*/, 7, 8/*placeholder*/ };
    int[] movementNorth = new int[] { 0/*placeholder*/, 1/*placeholder*/, 2, 3, 0, 4, 5, 7, 8/*placeholder*/ };
    Dictionary<int, string> ItemsInLocation = new Dictionary<int, string>();
    Dictionary<int, string[]> ItemUsages = new Dictionary<int, string[]>();
    Dictionary<int, string> EnemiesInLocation = new Dictionary<int, string>();
    ItemsInLocation.Add(0, "Axe");
    ItemsInLocation.Add(4, "Crafting Kit");
    EnemiesInLocation.Add(5, "Vulture");
    Dictionary<string, string> CraftingResults = new Dictionary<string, string>();
    Dictionary<int, string> InvestigationResults = new Dictionary<int, string>();
    
    InvestigationResults.Add(0, "You see an axe lying on the floor of the jungle.");
    InvestigationResults.Add(4, "You see an open box to the left of your gaze. It appears to hold hammers, nails, and other miscellaneous items.");
    InvestigationResults.Add(8, "You lean in for a closer look at the door and you see what appears to be a weaker part of the door. Perhaps you could break in somehow...");
    CraftingResults.Add("Planks", "Boat");
    ItemUsages.Add(0, new string[] { "Axe", "You heave the (quite heavy) axe at a tree again and again until it falls. Then, you chop the wood up until it becomes planks.", "You gain: Planks", "Planks", "Obtain Item" });
    ItemUsages.Add(1, new string[] { "Boat", "You take your makeshift raft into the swamp and paddle it with a plank of wood. Eventually, you find some land.", "", "8", "Go To" });
    ItemUsages.Add(8, new string[] { "Axe", "You take the axe and slam it into the door of the house over and over again. You then step into the house and find a rusty sword sitting there.", "You gain: Sword", "Sword", "Obtain Item"});
    string[] locationDesc = new string[] {
    "In the jungle, you trudge for what seems like hours before arriving at a familiar crossroads. It seems as though you are lost. Which direction will you go in?",
    "You arrive at the edge of a jungle. In front of you is a vast swamp.",
    "You stand to the east of a house that seems familiar to you. Surrounding the house is a lush, green jungle.",
    "Placeholder",
    "You arrive in a breathtaking expanse of grass, stretching all the way to the horizon as far as you can see.",
    "You are in a martian-like expanse of red sand. Off in the distance, you see a few vultures circling high above.",
    "In front of you is a vast lake, at the center of which you can vaguely make out an island shrouded by mist.",
    "Placeholder",
    "You take your makeshift raft into the swamp and paddle it with a plank of wood. Eventually, you find some land. It is a muddy island, and on the island appears to be a small wooden hut. You try to open it, but the door is locked."

        };
    


    //This function handles exploration: movement based on your current location
    Console.WriteLine("YOU ARE IN: " + locationName[CurrentTile]);
    string Input;

    Input = Console.ReadLine();
    string movementDirection;

    var JungleRNG = new Random(); //you can only proceed if you roll a 5 on a d10
    if (Input.StartsWith("go") && Input.Length > 3) //go command
    {
        int tileToMoveTo = CurrentTile;
        if (CurrentTile == 0) //if you are in a jungle
        {
            if (/*JungleRNG.Next(1, 6) == 5*/true) //and you roll a 5, you can move
            {

                movementDirection = Input.Substring(3);
                if (movementDirection == "east")
                {
                    tileToMoveTo = movementEast[CurrentTile];

                }
                else if (movementDirection == "west")
                {
                    tileToMoveTo = movementWest[CurrentTile];
                }
                else if (movementDirection == "north")
                {
                    tileToMoveTo = movementNorth[CurrentTile];
                }
                else if (movementDirection == "south")
                {
                    tileToMoveTo = movementSouth[CurrentTile];
                }
                else
                {
                    Console.WriteLine("Invalid Direction.");
                }
            }
            else
            {
                Console.WriteLine("You stumble around the jungle, and eventually found yourself back in the exact same spot you were before.");

            }

        }
        else //if you are not in the jungle
        {

            movementDirection = Input.Substring(3);
            if (movementDirection == "east")
            {
                tileToMoveTo = movementEast[CurrentTile];

            }
            else if (movementDirection == "west")
            {
                tileToMoveTo = movementWest[CurrentTile];
            }
            else if (movementDirection == "north")
            {
                tileToMoveTo = movementNorth[CurrentTile];
            }
            else if (movementDirection == "south")
            {
                tileToMoveTo = movementSouth[CurrentTile];
            }
            else
            {
                Console.WriteLine("Invalid Direction.");

            }

        }
        CurrentTile = tileToMoveTo;
        Console.WriteLine(locationDesc[CurrentTile]);

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

                Console.WriteLine("You have obtained " + item + ". You now have " + (variable.inventory.Length - 1) + " items.");
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
        if (Input.StartsWith("use craft") && variable.inventory.Contains("Crafting Kit"))
        {
            if (variable.inventory.Contains(Input.Substring(10)))
            {
                if (CraftingResults.ContainsKey(Input.Substring(10)))
                {
                    Console.WriteLine("You use your crafting kit, banging together some " + Input.Substring(10) + ", and you manage to create a makeshift " + CraftingResults[Input.Substring(10)] + ".");
                    variable.GetItem(CraftingResults[Input.Substring(10)]);
                    Console.WriteLine("You have crafted: " + CraftingResults[Input.Substring(10)]);
                }
                else
                {
                    Console.WriteLine("You try, but you simply cannot imagine what you could make with a(n) " + Input.Substring(10) + ".");
                }
            }
            else
            {
                Console.WriteLine("You do not have that item.");
            }
        }
        else if (!variable.inventory.Contains("Crafting Kit") && Input.StartsWith("use craft"))
        {
            if (variable.inventory.Contains(Input.Substring(10)))
            {
                Console.WriteLine("You do your best, trying to somehow make an item, but it is futile. Perhaps you need some special equipment to craft.");

            }
            else
            {
                Console.WriteLine("You do not have that item.");
            }

        }
        else
        {


            if (variable.inventory.Contains(ItemUsages[CurrentTile][0]) && Input.Substring(4) == ItemUsages[CurrentTile][0])

            {
                switch (ItemUsages[CurrentTile][4])
                {
                    case "Obtain Item":
                        string item = ItemUsages[CurrentTile][3];
                        var isPresentInInventory = variable.GetItem(item);
                        if (isPresentInInventory == 0)
                        {
                            Console.WriteLine(ItemUsages[CurrentTile][1]);
                            Console.WriteLine(ItemUsages[CurrentTile][2]);
                        }

                        break;
                    case "Go To":
                        CurrentTile = Int32.Parse(ItemUsages[CurrentTile][3]);
                        Console.WriteLine(locationDesc[CurrentTile]);
                        break;
                }


            }
            else if (!variable.inventory.Contains(ItemUsages[CurrentTile][0]) && Input.Substring(4) == ItemUsages[CurrentTile][0])
            {
                Console.WriteLine("You do not have that item.");
            }



        }



    }
    else if (Input.StartsWith("investigate"))
    {
        ItemsInLocation.TryGetValue(CurrentTile, out string itemInLocation);
        if (!variable.Inventory.Contains(itemInLocation))
        {
            Console.WriteLine(InvestigationResults[CurrentTile]);
        }
        else if (itemInLocation == null)
        {
            Console.WriteLine("You look around; however, you spot nothing out of the ordinary.");
        }
        else
        {
            Console.WriteLine("You see nothing except the item you already picked up.");
        }
    }
    else if (Input.StartsWith("fight"))
    {
        if (EnemiesInLocation[CurrentTile] == Input.Substring(6))
        {
            int[] CombatResults = Combat.CombatLoop(Input.Substring(6), Health, Attack, Defense, Speed, Level);
            switch (CombatResults[0])
            {
                case 0:
                    Console.WriteLine("Enemy not found. Error Code C0.");
                    break;
                case 1:
                    break;
                case 2:
                    Console.WriteLine($"You have gained {CombatResults[2]} EXP.");
                    if (XPUntilNextLevel <= CombatResults[2] && Level < 99)
                    {
                        int LevelFirstDigit;
                        int LevelSecondDigit = int.Parse(Level.ToString().Substring(1));
                        if (Level < 10)
                        {
                            LevelFirstDigit = 0;
                        }
                        else
                        {
                            LevelFirstDigit = int.Parse(Level.ToString().Remove(1));
                        }

                        Level++;
                        XPUntilNextLevel = (((LevelFirstDigit * 2) + LevelSecondDigit + 1) * 100);
                        Console.WriteLine($"Congratulations! You are now level {Level}! {XPUntilNextLevel} until level {Level + 1}.");
                    }
                    else if (Level == 99)
                    {
                        Console.WriteLine("You have reached the maximum level.");
                    }
                    else
                    {
                        XPUntilNextLevel -= CombatResults[2];
                        Console.WriteLine($"{XPUntilNextLevel} until level {Level + 1}.");
                    }
                    string[] Drops = Combat.RollLootDrops(CombatResults[3]);
                    foreach (string ItemDropped in Drops)
                    {
                        variable.GetItem(ItemDropped);
                        Console.WriteLine($"From the monster, you gained {ItemDropped}.");
                    }
                    break;
            }
        }
    }
    else
    {
        Console.WriteLine("Invalid Command or Invalid Version.");
    }

    if (variable.Inventory.Contains("Sword"))
    {
        SwordLevel = 1;
    }
    ExplorationEngine(CurrentTile);

}

Console.WriteLine("Build Successful. Starting Game...");
Console.WriteLine("Textblocks Version Dev-10082022-01"); //UPDATE EVERY DAY
ExplorationEngine(2);






