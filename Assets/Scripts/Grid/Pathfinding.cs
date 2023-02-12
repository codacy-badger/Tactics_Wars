using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public static class Pathfinding
{
    private static HashSet<Node> _nodesToReset = new HashSet<Node>();
    private static Node _initialNode;

    public static List<Vector3> GetMovementArea(Vector3 initialPos, int moveCost, int maxDistance)
    {
        HashSet<Vector3> walkableArea = new HashSet<Vector3>();
        ResetVisitedNodes();
        _initialNode = Grid.Instance.GetNode(initialPos);

        if (_initialNode.GetTopEntity() == null)
            return new List<Vector3>();
        if (_initialNode.GetTopEntity() is not Unit)
            return new List<Vector3>();

        TeamEnum unitTeam = _initialNode.GetTopEntity().Team;
        _nodesToReset.Add(_initialNode);

        HashSet<Node> neighbours = GetNodeNeighbours(_initialNode);
        HashSet<Node> tempNeighbours = new HashSet<Node>();

        while (neighbours.Count > 0)
        {
            foreach (Node node in neighbours)
            {
                int parentCost = node.NodeParent.DistanceCost;
                int nodeCost = node.DistanceCost;

                node.DistanceCost = parentCost + moveCost;
                if (node.GetTopEntity() is not Unit) // GetNodeNeighbours checks the team is the same
                    walkableArea.Add(node.Position);
                if (node.DistanceCost < maxDistance)
                {
                    tempNeighbours.UnionWith(GetNodeNeighbours(node));
                }
            }
            neighbours = tempNeighbours;
            tempNeighbours = new HashSet<Node>();
        }

        return walkableArea.ToList();
    }

    public static List<Vector3> CalculatePositionsPath(Vector3 finalPosition)
    {
        List<Vector3> positionsPath = new List<Vector3>();

        List<Node> nodePath = CalculateNodePath(finalPosition);
        foreach (Node node in nodePath)
        {
            positionsPath.Add(node.Position);
        }

        return positionsPath;
    }

    private static List<Node> CalculateNodePath(Vector3 finalPosition)
    {
        Node node = Grid.Instance.GetNode(finalPosition);
        return CalculateNodePath(node);
    }

    private static List<Node> CalculateNodePath(Node node)
    {
        if (node.NodeParent == null)
        {
            return new List<Node>() { node };
        }
        else
        {
            List<Node> path = new List<Node>();
            path.AddRange(CalculateNodePath(node.NodeParent));
            path.Add(node);
            return path;
        }
    }

    private static HashSet<Node> GetNodeNeighbours(Node currentNode)
    {
        HashSet<Node> neighbours = new HashSet<Node>();

        Entity entity = _initialNode.GetTopEntity();
        foreach (Node node in currentNode.Neighbours)
        {
            if (node.GetTopEntity() != null && entity != null)
            {
                if (node.GetTopEntity().Team != entity.Team)
                    continue;
            }
            
            if (!node.Equals(_initialNode) && !_nodesToReset.Contains(node))
            {
                node.NodeParent = currentNode;
                neighbours.Add(node);
                _nodesToReset.Add(node);
            }
        }

        return neighbours;
    }

    private static void ResetVisitedNodes()
    {
        foreach (Node node in _nodesToReset)
        {
            node.NodeParent = null;
            node.DistanceCost = 0;
        }

        _nodesToReset = new HashSet<Node>();
    }
}
