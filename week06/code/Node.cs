public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // Check if value is LESS than the current node's data
        if (value < Data)
        {
            // If there's no node to the left, add it here
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value); // Keep going left recursively
        }
        // If value is GREATER than the current node's data
        else if (value > Data)
        {
            // If there's no node to the right, add it here
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value); // Keep going right recursively
        }
        // If value is EQUAL to current node, do nothing (this avoids duplicates)
        else
        {
            // No need to insert duplicates, so we skip it
            return;
        }
    }

    public bool Contains(int value)
    {
        // Check if the current node holds the value
        if (value == Data)
        {
            return true; // Found the value
        }
        // If value is less, we should go left
        else if (value < Data)
        {
            // If there's no left child, value is not here
            if (Left is null)
                return false;

            // Otherwise, keep searching in the left subtree
            return Left.Contains(value);
        }
        // If value is greater, we go right
        else
        {
            // If there's no right child, value is not here
            if (Right is null)
                return false;

            // Otherwise, keep searching in the right subtree
            return Right.Contains(value);
        }
    }

    public int GetHeight()
    {
        // If there's no left or right child, both are considered height 0
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;

        // The height of this node is 1 + the taller subtree
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}