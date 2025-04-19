public class Room
{
    public int Id { get; set; }
    public string Requirement { get; set; }
    public Room(int id, string requirement = "")
    {
        Id = id;
        Requirement = requirement;
    }
}