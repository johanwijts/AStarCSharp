namespace AStarCSharp;

public static class AStarAlgo
{
    public static List<Node> GetRoute(Node startingNode, Node targetNode, List<Node> allNodes)
    {
        var openSetOfNodes = new List<Node>();
        var closedSetOfNodes = new List<Node>();

        openSetOfNodes.Add(startingNode);

        while (true)
        {
            var lowestFCost = openSetOfNodes.Min(node => node.CalculateFCost());
            var currentNode = openSetOfNodes.First(node => node.CalculateFCost() == lowestFCost);

            openSetOfNodes.Remove(currentNode);
            closedSetOfNodes.Add(currentNode);

            if(currentNode.XPos == targetNode.XPos && currentNode.YPos == targetNode.YPos)
            {
                return GetFinalPath(closedSetOfNodes.Last());
            }

            foreach(var neighbourNode in currentNode.GetNeighbourNodes(allNodes))
            {
                if(closedSetOfNodes.Exists(node => node.XPos == neighbourNode.XPos && node.YPos == neighbourNode.YPos))
                {
                    continue;
                }

                var gCost = CalculateGCost(neighbourNode, currentNode);
                var hCost = CalculateHCost(neighbourNode, targetNode);

                if(gCost < neighbourNode.GCost ||
                    !openSetOfNodes.Exists(node => node.XPos == neighbourNode.XPos && node.YPos == neighbourNode.YPos))
                {
                    neighbourNode.GCost = gCost;
                    neighbourNode.HCost = hCost;
                    neighbourNode.ParentNode = currentNode;

                    if(!openSetOfNodes.Exists(node => node.XPos == neighbourNode.XPos && node.YPos == neighbourNode.YPos))
                    {
                        openSetOfNodes.Add(neighbourNode);
                    }
                }
            }
        }
    }

    private static int CalculateGCost(Node neighbourNode, Node targetNode)
    {
        if (neighbourNode.XPos == targetNode.XPos || neighbourNode.YPos == targetNode.YPos)
        {
            return 10;
        }

        else
        {
            return 14;
        }
    }

    private static int CalculateHCost(Node neighbourNode, Node targetNode)
    {
        int distanceX = Math.Abs(neighbourNode.XPos - targetNode.XPos);
        int distanceY = Math.Abs(neighbourNode.YPos - targetNode.YPos);

        if (distanceX > distanceY)
        {
            return 14 * distanceY + 10 * (distanceX - distanceY);
        }

        else
        {
            return 14 * distanceX + 10 * (distanceY - distanceX);
        }
    }

    private static int CalculateFCost(this Node node)
    {
        node.FCost = node.GCost + node.HCost;
        return node.FCost;
    }

    private static List<Node> GetFinalPath(Node targetNode)
    {
        var finalPath = new List<Node>();
        var currentNode = targetNode;

        while (currentNode != null)
        {
            finalPath.Add(currentNode);
            currentNode = currentNode.ParentNode;
        }

        finalPath.Reverse();
        return finalPath;
    }
}   


