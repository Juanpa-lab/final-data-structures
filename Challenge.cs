public class Challenge
{
    public int Difficulty { get; set; }
    public string Type { get; set; }

    public Challenge(int difficulty, string type)
    {
        Difficulty = difficulty;
        Type = type;
    }
}

public class ChallengeNode
{
    public Challenge Data;
    public ChallengeNode Left, Right;
    public ChallengeNode(Challenge challenge)
    {
        Data = challenge;
    }
}

public class ChallengeTree
{
    public ChallengeNode Root;

    public void Insert(Challenge challenge)
    {
        Root = Insert(Root, challenge);
    }

    private ChallengeNode Insert(ChallengeNode node, Challenge challenge)
    {
        if (node == null) return new ChallengeNode(challenge);
        if (challenge.Difficulty < node.Data.Difficulty)
            node.Left = Insert(node.Left, challenge);
        else
            node.Right = Insert(node.Right, challenge);
        return node;
    }

    public Challenge FindClosest(int value)
    {
        return FindClosest(Root, value, null);
    }

    private Challenge FindClosest(ChallengeNode node, int value, Challenge closest)
    {
        if (node == null) return closest;
        if (closest == null || Math.Abs(node.Data.Difficulty - value) < Math.Abs(closest.Difficulty - value))
            closest = node.Data;
        if (value < node.Data.Difficulty)
            return FindClosest(node.Left, value, closest);
        else
            return FindClosest(node.Right, value, closest);
    }

    public void Remove(int difficulty)
    {
        Root = Remove(Root, difficulty);
    }

    private ChallengeNode Remove(ChallengeNode root, int key)
    {
        if (root == null) return null;
        if (key < root.Data.Difficulty) root.Left = Remove(root.Left, key);
        else if (key > root.Data.Difficulty) root.Right = Remove(root.Right, key);
        else
        {
            if (root.Left == null) return root.Right;
            if (root.Right == null) return root.Left;

            ChallengeNode minLargerNode = FindMin(root.Right);
            root.Data = minLargerNode.Data;
            root.Right = Remove(root.Right, minLargerNode.Data.Difficulty);
        }
        return root;
    }

    private ChallengeNode FindMin(ChallengeNode node)
    {
        while (node.Left != null) node = node.Left;
        return node;
    }
}