class Program
{
    static void Main()
    {
        var hero = new Hero(6, 7, 8);
        var map = new Map();
        map.Generate();

        var tree = new ChallengeTree();
        Utils.GenerateSampleChallenges(tree);

        Utils.Play(hero, map, tree);
    }
}