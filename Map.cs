public class Map
{
    public Dictionary<int, List<int>> AdjacencyList { get; private set; } = new Dictionary<int, List<int>>();
    public int ExitRoom { get; private set; }

    public void Generate()
    {
        Random rand = new Random();

        for (int i = 1; i <= 15; i++)
        {
            AdjacencyList[i] = new List<int>();
        }

        for (int i = 1; i < 10; i++)
        {
            AdjacencyList[i].Add(i + 1);
            AdjacencyList[i + 1].Add(i); 
        }

        for (int i = 1; i <= 15; i++)
        {
            int a = rand.Next(1, 16);
            int b = rand.Next(1, 16);
            if (a != b && !AdjacencyList[a].Contains(b))
            {
                AdjacencyList[a].Add(b);
                AdjacencyList[b].Add(a);
            }
        }

        ExitRoom = 10;
    }
}
