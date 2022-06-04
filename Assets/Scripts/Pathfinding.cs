using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    Dictionary<Vector2Int, TileAttributes> dictionary = new Dictionary<Vector2Int, TileAttributes>();
    public Dictionary<Vector2Int, TileAttributes> Dictionary { get { return dictionary; } }

    [SerializeField] int width;
    [SerializeField] int height;

    Tile tile;

    void Start() 
    {
        tile = FindObjectOfType<Tile>();
        FillDictionary();    
    }

    void FillDictionary()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Vector2Int coordinates = new Vector2Int(i, j);
                dictionary.Add(coordinates, new TileAttributes(coordinates, false, false));
            }
        }
    }

    public Vector2Int ConvertPositionToCoordinates(Vector3 position)
    {
        Vector2Int coordinates = new Vector2Int();

        coordinates.x = Mathf.RoundToInt(position.x / tile.UnityGridSize);
        coordinates.y = Mathf.RoundToInt(position.z / tile.UnityGridSize);

        return coordinates;
    }

    public void SetHasObstacle(Vector3 position, bool hasObstacle, bool isObstacleDestructable)
    {
       Vector2Int coordinates = ConvertPositionToCoordinates(position);
       dictionary[coordinates].hasObsatacle = hasObstacle;
       dictionary[coordinates].isObstacleDestructable = isObstacleDestructable;
    }
}
