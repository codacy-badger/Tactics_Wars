using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Node
{
    #region Variables
    private Vector3 _position;
    private int _gridX;
    private int _gridY;
    private int _distanceCost;
    private Node _nodeParent;
    private bool _isWall;
    private Stack<Entity> _nodeEntities;
    private ResourceType _resource;
    #endregion

    #region Getters Setters
    public Vector3 Position { get { return _position; } set { _position = value; } }
    public int GridX { get { return _gridX; } set { _gridX = Mathf.Max(0, value); } }
    public int GridY { get { return _gridY; } set { _gridY = Mathf.Max(0, value); } }
    public int DistanceCost { get { return _distanceCost; } set { _distanceCost = value; } }
    public Node NodeParent { get { return _nodeParent; } set { _nodeParent = value; } }
    public bool IsWall { get { return _isWall; } set { _isWall = value; } }
    public ResourceType Resource { get { return _resource; } set { _resource = value; } }
    #endregion

    public Node(Vector3 position, int gridX, int gridY)
    {
        _position = position;
        _gridX = gridX;
        _gridY = gridY;
        _nodeEntities = new Stack<Entity>();
    }

    public Entity GetTopEntity()
    {
        if (_nodeEntities.Count > 0)
            return _nodeEntities.Peek();
        else
            return null;
    }

    public Entity RemoveTopEntity()
    {
        if (_nodeEntities.Count > 0)
            return _nodeEntities.Pop();
        else
            return null;
    }

    public void AddEntity(Entity entity)
    {
        if (_nodeEntities.Count < 2)
            _nodeEntities.Push(entity);
        else
            Debug.LogError("Into de añadir más de dos entidades al nodo (" + GridX + ", " + GridY + ")");
    }

    public string GetInfo()
    {
        string info = "(" + GridX + ", " + GridY + ").";
        if (IsWall)
            info += " Es pared.";
        else
            info += " No es pared.";

        if (Resource != null)
            info += " Recurso del tipo: " + Resource.ResourceName + ".";
        else
            info += " No hay recurso.";

        if (_nodeEntities.Count > 0)
        {
            Entity entity = _nodeEntities.Peek();
            if (entity is Unit)
                info += " Hay una unidad: " + entity.Name;
            else if (entity is Building)
                info += " Hay un edificio: " + entity.Name;
        }
        else
            info += " No hay unidades.";

        return info;
    }
}
