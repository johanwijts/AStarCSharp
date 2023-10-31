using AStarCSharp;

var result = AStarAlgo.GetRoute(new Node(1, 1), new Node(1, 6), Routes.Route1());

foreach (var node in result)
{
    Console.WriteLine($"X: {node.XPos}, Y: {node.YPos}");
}

Console.ReadLine();