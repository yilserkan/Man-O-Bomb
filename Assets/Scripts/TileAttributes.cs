using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileAttributes
{
    public Vector2Int coordinates;
    public bool hasObsatacle;
    public bool isObstacleDestructable;

    public TileAttributes(Vector2Int coordinates, bool hasObsatacle, bool isObstacleDestructable)
    {
        this.coordinates = coordinates;
        this.hasObsatacle = hasObsatacle;
        this.isObstacleDestructable = isObstacleDestructable;
    }
}
