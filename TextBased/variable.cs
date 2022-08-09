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
    static public int StringToIntAdder()
    {
        
        StringToInt stringToInt = new StringToInt();
        stringToInt.stringToInt.Add("0", 0);
        stringToInt.stringToInt.Add("1", 1);
        stringToInt.stringToInt.Add("2", 2);
        stringToInt.stringToInt.Add("3", 3);
        stringToInt.stringToInt.Add("4", 4);
        stringToInt.stringToInt.Add("5", 5);
        stringToInt.stringToInt.Add("6", 6);
        stringToInt.stringToInt.Add("7", 7);
        stringToInt.stringToInt.Add("8", 8);
        stringToInt.stringToInt.Add("9", 9);
        stringToInt.stringToInt.Add("10", 10);
        stringToInt.stringToInt.Add("11", 11);
        stringToInt.stringToInt.Add("12", 12);
        stringToInt.stringToInt.Add("13", 13);
        stringToInt.stringToInt.Add("14", 14);
        stringToInt.stringToInt.Add("15", 15);
        stringToInt.stringToInt.Add("16", 16);
        stringToInt.stringToInt.Add("17", 17);
        stringToInt.stringToInt.Add("18", 18);
        stringToInt.stringToInt.Add("19", 19);
        stringToInt.stringToInt.Add("20", 20);
        stringToInt.stringToInt.Add("21", 21);
        stringToInt.stringToInt.Add("22", 22);
        stringToInt.stringToInt.Add("23", 23);
        stringToInt.stringToInt.Add("24", 24);
        stringToInt.stringToInt.Add("25", 25);
        stringToInt.stringToInt.Add("26", 26);
        stringToInt.stringToInt.Add("27", 27);
        stringToInt.stringToInt.Add("28", 28);
        stringToInt.stringToInt.Add("29", 29);
        stringToInt.stringToInt.Add("30", 30);
        stringToInt.stringToInt.Add("31", 31);
        stringToInt.stringToInt.Add("32", 32);
        stringToInt.stringToInt.Add("33", 33);
        stringToInt.stringToInt.Add("34", 34);
        stringToInt.stringToInt.Add("35", 35);
        stringToInt.stringToInt.Add("36", 36);
        stringToInt.stringToInt.Add("37", 37);
        stringToInt.stringToInt.Add("38", 38);
        stringToInt.stringToInt.Add("39", 39);
        stringToInt.stringToInt.Add("40", 40);
        stringToInt.stringToInt.Add("41", 41);
        stringToInt.stringToInt.Add("42", 42);
        stringToInt.stringToInt.Add("43", 43);
        stringToInt.stringToInt.Add("44", 44);
        stringToInt.stringToInt.Add("45", 45);
        stringToInt.stringToInt.Add("46", 46);
        stringToInt.stringToInt.Add("47", 47);
        stringToInt.stringToInt.Add("48", 48);
        stringToInt.stringToInt.Add("49", 49);
        stringToInt.stringToInt.Add("50", 50);
        stringToInt.stringToInt.Add("51", 51);
        stringToInt.stringToInt.Add("52", 52);
        stringToInt.stringToInt.Add("53", 53);
        stringToInt.stringToInt.Add("54", 54);
        stringToInt.stringToInt.Add("55", 55);
        stringToInt.stringToInt.Add("56", 56);
        stringToInt.stringToInt.Add("57", 57);
        stringToInt.stringToInt.Add("58", 58);
        stringToInt.stringToInt.Add("59", 59);
        stringToInt.stringToInt.Add("60", 60);
        stringToInt.stringToInt.Add("61", 61);
        stringToInt.stringToInt.Add("62", 62);
        stringToInt.stringToInt.Add("63", 63);
        stringToInt.stringToInt.Add("64", 64);
        stringToInt.stringToInt.Add("65", 65);
        stringToInt.stringToInt.Add("66", 66);
        stringToInt.stringToInt.Add("67", 67);
        stringToInt.stringToInt.Add("68", 68);
        stringToInt.stringToInt.Add("69", 69);
        stringToInt.stringToInt.Add("70", 70);
        stringToInt.stringToInt.Add("71", 71);
        stringToInt.stringToInt.Add("72", 72);
        stringToInt.stringToInt.Add("73", 73);
        stringToInt.stringToInt.Add("74", 74);
        stringToInt.stringToInt.Add("75", 75);
        stringToInt.stringToInt.Add("76", 76);
        stringToInt.stringToInt.Add("77", 77);
        stringToInt.stringToInt.Add("78", 78);
        stringToInt.stringToInt.Add("79", 79);
        stringToInt.stringToInt.Add("80", 80);
        stringToInt.stringToInt.Add("81", 81);
        stringToInt.stringToInt.Add("82", 82);
        stringToInt.stringToInt.Add("83", 83);
        stringToInt.stringToInt.Add("84", 84);
        stringToInt.stringToInt.Add("85", 85);
        stringToInt.stringToInt.Add("86", 86);
        stringToInt.stringToInt.Add("87", 87);
        stringToInt.stringToInt.Add("88", 88);
        stringToInt.stringToInt.Add("89", 89);
        stringToInt.stringToInt.Add("90", 90);
        stringToInt.stringToInt.Add("91", 91);
        stringToInt.stringToInt.Add("92", 92);
        stringToInt.stringToInt.Add("93", 93);
        stringToInt.stringToInt.Add("94", 94);
        stringToInt.stringToInt.Add("95", 95);
        stringToInt.stringToInt.Add("96", 96);
        stringToInt.stringToInt.Add("97", 97);
        stringToInt.stringToInt.Add("98", 98);
        stringToInt.stringToInt.Add("99", 99);
        return (69);
    }
}
