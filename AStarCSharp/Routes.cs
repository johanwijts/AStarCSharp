namespace AStarCSharp
{
    public static class Routes
    {
        public static List<Node> Route1()
        {
            return CreateNodeGrid(
                6,
                6,
                new List<int>() { 1, 2, 3, 4 },
                new List<int> { 3 });
        }

        private static List<Node> CreateNodeGrid(
            int height,
            int width,
            List<int> blockedXList,
            List<int> blockedYList)
        {
            int currentHeight = 0;
            int currentWidth = 0;

            var nodes = new List<Node>();

            while (currentHeight <= height)
            {
                while (currentWidth <= width)
                {
                    if (blockedXList.Contains(currentWidth) && blockedYList.Contains(currentHeight))
                    {
                        nodes.Add(new Node(currentWidth, currentHeight) { IsWalkable = false });
                        currentWidth++;
                        continue;
                    }
                    nodes.Add(new Node(currentWidth, currentHeight));
                    currentWidth++;
                }

                currentWidth = 0;
                currentHeight++;
            }

            return nodes;
        }
    }
}
