public class GameState
{
    public Stack<int> VisitedRooms { get; set; } = new Stack<int>();
    public Stack<string> Treasures { get; set; } = new Stack<string>();
    public Dictionary<int, Challenge> RoomChallenges { get; set; } = new Dictionary<int, Challenge>();
}