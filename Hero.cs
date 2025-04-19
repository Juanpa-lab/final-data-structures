public class Hero
{
    public int Strength { get; set; }
    public int Agility { get; set; }
    public int Intelligence { get; set; }
    public int Health { get; set; } = 20;
    public Queue<string> Inventory { get; private set; } = new Queue<string>();

    public Hero(int strength, int agility, int intelligence)
    {
        Strength = strength;
        Agility = agility;
        Intelligence = intelligence;
        Inventory.Enqueue("Sword");
        Inventory.Enqueue("Health Potion");
    }

    public void AddItem(string item)
    {
        if (Inventory.Count >= 5)
        {
            Inventory.Dequeue();
        }
        Inventory.Enqueue(item);
    }
}