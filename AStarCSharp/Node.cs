namespace AStarCSharp
{
    public class Node
    {
        public Node(int xPos, int yPos)
        {
            this.XPos = xPos;
            this.YPos = yPos;
        }

        public int HCost { get; set; }

        public int GCost { get; set; }

        public int FCost { get; set; }

        public int XPos { get; set; }

        public int YPos { get; set; }

        public bool IsWalkable { get; set; } = true;

        public Node? ParentNode { get; set; } = null;

        public List<Node> Neighbours { get; set; } = new List<Node>();
    }

    public static class NodeExtensions
    {
        public static List<Node> GetNeighbourNodes(this Node node, List<Node> allNodes)
        {
            if (node.Neighbours.Any())
            {
                return node.Neighbours;
            }

            var neighbourNodes = new List<Node>();

            foreach (var nodeFromAll in allNodes)
            {
                if (!node.IsWalkable)
                {
                    continue;
                }

                if (nodeFromAll.XPos == node.XPos - 1 && nodeFromAll.YPos == node.YPos)
                {
                    neighbourNodes.Add(nodeFromAll);
                }
                else if (nodeFromAll.XPos == node.XPos - 1 && nodeFromAll.YPos == node.YPos - 1)
                {
                    neighbourNodes.Add(nodeFromAll);
                }
                else if (nodeFromAll.XPos == node.XPos - 1 && nodeFromAll.YPos == node.YPos + 1)
                {
                    neighbourNodes.Add(nodeFromAll);
                }
                else if (nodeFromAll.XPos == node.XPos + 1 && nodeFromAll.YPos == node.YPos)
                {
                    neighbourNodes.Add(nodeFromAll);
                }
                else if (nodeFromAll.XPos == node.XPos + 1 && nodeFromAll.YPos == node.YPos - 1)
                {
                    neighbourNodes.Add(nodeFromAll);
                }
                else if (nodeFromAll.XPos == node.XPos + 1 && nodeFromAll.YPos == node.YPos + 1)
                {
                    neighbourNodes.Add(nodeFromAll);
                }
                else if (nodeFromAll.XPos == node.XPos && nodeFromAll.YPos == node.YPos - 1)
                {
                    neighbourNodes.Add(nodeFromAll);
                }
                else if (nodeFromAll.XPos == node.XPos && nodeFromAll.YPos == node.YPos + 1)
                {
                    neighbourNodes.Add(nodeFromAll);
                }
            }

            node.Neighbours = neighbourNodes;
            return neighbourNodes;
        }
    }
}
