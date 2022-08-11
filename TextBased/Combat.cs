
public class Combat
{
    
    static int[] CombatLoop(string enemy, int Health, int Attack, int Defense, int Speed, int Level)
    {
        //EnemyStats ID 0 = Health, 1 = Attack, 2 = Defense, 3 = Enemy ID, 4 = Speed, 5 = Level
        Dictionary<string, int[]> EnemyStats = new Dictionary<string, int[]>();
        EnemyStats.Add("Vulture", new int[] { 10, 2, 0, 0, 4, 1 });
        if (EnemyStats.ContainsKey(enemy))
        {
            Console.WriteLine($"You face a(n) {enemy}.");
            int xpAmount = (int)(Math.Pow(((Double)(EnemyStats[enemy][5] / Level) * 100), ((Double)(250 - Level) / 250) * 3));
            bool isYourTurn = Speed > EnemyStats[enemy][4];
            while (EnemyStats["Vulture"][0] != 0 && Health > 0)
            {
                if (isYourTurn)
                {
                    Console.WriteLine($"{enemy}\nHP: {EnemyStats[enemy][0]} \nYou \nHP: {Health}");
                    Console.WriteLine("What would you like to do?");
                    string Input = Console.ReadLine();
                    switch (Input)
                    {
                        case "Attack":
                            Random HitOrMiss = new Random();
                            if (HitOrMiss.Next(11) > EnemyStats[enemy][5] / Level)
                            {
                                EnemyStats[enemy][0] -= (int)(Attack * 2m / (EnemyStats[enemy][2] * 1.2m + 1m));
                                Console.WriteLine($"The attack hit the {enemy} for {(int)(Attack * 2m / (EnemyStats[enemy][2] * 1.2m + 1m))} damage.");
                                isYourTurn = false;
                            }
                            else
                            {
                                Console.WriteLine("Your attack missed.");
                                isYourTurn = false;
                            }
                            break;
                        case "Run":
                            Random RunSuccess = new Random();
                            if (RunSuccess.Next(11) > EnemyStats[enemy][5] / Level || RunSuccess.Next(11) == 10)
                            {
                                Console.WriteLine("You successfully run from the enemy.");
                                return (new int[] {1, Health}); //Dialogue: Run Successfully. You are at (amount of health) health.
                            }
                            else
                            {
                                Console.WriteLine($"The {enemy} prevents you from leaving!");
                                isYourTurn = false;
                                break;
                            }
                        default:
                            Console.WriteLine("Invalid Command.");
                            break;
                    }


                }
                else
                {
                    Random HitOrMiss = new Random();
                    if (HitOrMiss.Next(11) > Level / EnemyStats[enemy][5])
                    {
                        Health -= (int)(EnemyStats[enemy][1] * 2m / (Defense * 1.2m + 1m));
                        Console.WriteLine($"The attack hit you for {(int)(EnemyStats[enemy][1] * 2m / (Defense * 1.2m + 1m))} damage.");
                        isYourTurn = true;
                    }
                    else
                    {
                        Console.WriteLine("The enemy's attack missed.");
                        isYourTurn = true;
                    }
                }
                
            }
            if(Health > 0)
            {
                Console.WriteLine($"You won! You gain {xpAmount} EXP.");
                return (new int[] { 2, Health, EnemyStats[enemy][3] });
            }
            else
            {
                Console.WriteLine("You died!");
                //implement death system here
                return (new int[] { });
            }
        }
        else
        {
            return (new int[] {0, Health}); //Dialogue: Enemy not found.
        }

    }
}