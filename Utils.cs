public static class Utils
{
    public static string TryFindTreasure(Random rand)
    {
        int roll = rand.Next(1, 101);
        if (roll <= 10)
        {
            string[] loot = { "Gold", "Gem", "Magic Ring" };
            return loot[rand.Next(loot.Length)];
        }
        return null;
    }

    public static bool ResolveChallenge(Hero hero, Challenge challenge)
    {
        int stat = 0;
        string itemNeeded = "";

        switch (challenge.Type)
        {
            case "Combat": stat = hero.Strength; itemNeeded = "Sword"; break;
            case "Trap": stat = hero.Agility; itemNeeded = "Smoke Bomb"; break;
            case "Puzzle": stat = hero.Intelligence; itemNeeded = "Hint Scroll"; break;
        }

        if (stat >= challenge.Difficulty || hero.Inventory.Contains(itemNeeded))
        {
            Console.WriteLine("Challenge passed!");
            return true;
        }
        else
        {
            int damage = Math.Abs(stat - challenge.Difficulty);
            hero.Health -= damage;
            Console.WriteLine($"Challenge failed! Lost {damage} health. Remaining: {hero.Health}");
            return false;
        }
    }

    public static void GenerateSampleChallenges(ChallengeTree tree)
    {
        string[] types = { "Combat", "Trap", "Puzzle" };
        Random rand = new Random();
        for (int i = 0; i < 15; i++)
        {
            int difficulty = rand.Next(1, 21);
            string type = types[rand.Next(types.Length)];
            tree.Insert(new Challenge(difficulty, type));
        }
    }

    public static void Play(Hero hero, Map map, ChallengeTree tree)
    {
        GameState game = new GameState();
        Random rand = new Random();
        int currentRoom = 1;

        while (hero.Health > 0 && currentRoom != map.ExitRoom)
        {
            Console.WriteLine($"\nEntered Room {currentRoom}");
            game.VisitedRooms.Push(currentRoom);

            var challenge = tree.FindClosest(currentRoom);
            if (challenge != null)
            {
                Console.WriteLine($"Facing a {challenge.Type} (Difficulty {challenge.Difficulty})");
                bool success = ResolveChallenge(hero, challenge);
                if (!success && hero.Health <= 0) break;
                tree.Remove(challenge.Difficulty);
            }

            string treasure = TryFindTreasure(rand);
            if (treasure != null)
            {
                game.Treasures.Push(treasure);
                Console.WriteLine($"Found treasure: {treasure}");
            }

            Console.WriteLine("Connected rooms: " + string.Join(", ", map.AdjacencyList[currentRoom]));
            Console.Write("Enter next room ID: ");
            if (!int.TryParse(Console.ReadLine(), out int nextRoom) || !map.AdjacencyList[currentRoom].Contains(nextRoom))
            {
                Console.WriteLine("Invalid path. Try again.");
                continue;
            }

            currentRoom = nextRoom;
        }

        if (hero.Health > 0 && currentRoom == map.ExitRoom)
        {
            Console.WriteLine("\nYou reached the Exit and won the game!");
        }
        else
        {
            Console.WriteLine("\nGame Over. You died.");
            Console.WriteLine("Path taken:");
            while (game.VisitedRooms.Count > 0)
                Console.WriteLine("Room " + game.VisitedRooms.Pop());
        }
    }
}
