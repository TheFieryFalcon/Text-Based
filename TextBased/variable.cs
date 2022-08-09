public class Variable
{

    public string[] Inventory = new string[1];
    public string[] inventory
    {
        get { return Inventory; }
        set { Inventory = value; }
    }
    public int GetItem(string ITEM)
    {
        if (Inventory.Contains(ITEM) == false)
        {
            Array.Resize(ref Inventory, Inventory.Length + 1);
            Inventory[Inventory.Length - 1] = ITEM;
            return (0);
        }
        else
        {
            Console.WriteLine("You already have that item!");
            return (1);
        }
    }

}