


static int ExplorationEngine(int CurrentTile)
{

    int[] movementEast = new int[] { 1, 1, 0, 3 };
    string[] locationName = new string[] { "Jungle", "Marsh", "East of House", "Mysterious House" };
    int[] movementWest = new int[] { 2, 0, 2, 3 };
    string[] locationDesc = new string[] {

    "In the jungle, you trudge for what seems like hours before arriving at a familiar crossroads. It seems as though you are lost. Which direction will you go in?",
    "You arrive at the edge of a jungle. In front of you is a vast swamp.",
    "You stand to the east of a house that seems familiar to you. Surrounding the house is a lush, green jungle.",

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
            if (JungleRNG.Next(1, 10) == 5) //and you roll a 5, you can move
            {
                if (Input.Contains("east") || Input.Contains("west") == true)
                {
                    length = 3;
                }
                else
                {
                    length = 4;
                }
                movementDirection = Input.Substring(length);
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
                    //CurrentTile = movementNorth[CurrentTile];  (TODO: ADD MOVEMENT SOUTH AND NORTH)
                }
                else if (movementDirection == "south")
                {
                    //CurrentTile = movementNorth[CurrentTile]; (TODO: SEE ABOVE)
                }
                else
                {
                    Console.WriteLine("Invalid Direction.");
                }
            }

        }
        else //if you are not in the jungle
        {
            if (Input.Contains("east") || Input.Contains("west") == true)
            {
                length = 3;
            }
            else
            {
                length = 4;
            }
            movementDirection = Input.Substring(length);
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
                //CurrentTile = movementNorth[CurrentTile];  (TODO: ADD MOVEMENT SOUTH AND NORTH)
            }
            else if (movementDirection == "south")
            {
                //CurrentTile = movementNorth[CurrentTile]; (TODO: SEE ABOVE)
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
            "Example: help help");
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
Console.WriteLine("Textblocks Version Dev-02082022-01");
ExplorationEngine(2);


