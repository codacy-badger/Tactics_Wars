using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

class GridManager : MonoBehaviour
{
    
    [Header("Grid Settings")]
    [SerializeField]
    private Transform _bottomLeft;
    [SerializeField]
    private Transform _topRight;
    [SerializeField]
    private int _cellSize;
    
    private int _width;
    private int _height;

    [Header("Tilemaps Settings")]
    [SerializeField]
    private Tilemap _wallsTilemap;
    [SerializeField]
    private Tilemap _resourcesTilemap;

    [Header("Resource Types")]
    [SerializeField]
    private ResourceType _goldResource;
    [SerializeField]
    private ResourceType _foodResource;

    [Header("Game Events")]
    [SerializeField]
    private VoidEvent _onGridInitialized;

    private void Start()
    {
        InitializeGrid();
        InitializeNodes();
        _onGridInitialized.Raise();
    }

    private void InitializeGrid()
    {
        _width = (int)Mathf.Abs(_bottomLeft.position.x - _topRight.position.x);
        _height = (int)Mathf.Abs(_bottomLeft.position.y - _topRight.position.y);

        Grid.Instance = new Grid(_width, _height, _cellSize, _bottomLeft.position);
    }

    private void InitializeNodes()
    {
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                Vector3Int tilePosition = Grid.Instance.GetNodeWorldIntPosition(x, y);
                TileBase wallTile = _wallsTilemap.GetTile(tilePosition);
                TileBase resourceTile = _resourcesTilemap.GetTile(tilePosition);

                Node node = Grid.Instance.GetNode(x, y);

                if (wallTile != null)
                    node.IsWall = true;
                else if (resourceTile != null)
                {
                    if (resourceTile.Equals(_goldResource.ResourceTile))
                        node.Resource = _goldResource;
                    else if (resourceTile.Equals(_foodResource.ResourceTile))
                        node.Resource = _foodResource;
                }

                Grid.Instance.SetNodesNeighbours();
            }
        }
    }
}
