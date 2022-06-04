using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class Tile : MonoBehaviour
{
    [SerializeField] bool hasObstacle = false;
    [SerializeField] int unityGridSize = 10;
    public int UnityGridSize { get { return unityGridSize; } }
    
    Pathfinding dictionary;
    TextMeshPro label;
    Vector2Int coordinates;

   
    void Start()
    {
        dictionary = FindObjectOfType<Pathfinding>();
        label = GetComponentInChildren<TextMeshPro>();
        label.enabled = false;
        SetHasObsatcle();
    }

    void Update()
    {
        if(!Application.isPlaying)
        {
            label.enabled = false;
            UpdateLabel(); 
        }
    }

    void UpdateLabel()
    {
        coordinates.x = Mathf.RoundToInt(transform.position.x / unityGridSize);
        coordinates.y = Mathf.RoundToInt(transform.position.z / unityGridSize);

        label.text = coordinates.x + "," + coordinates.y;
    }

    void SetHasObsatcle()
    {
        if(hasObstacle && dictionary.Dictionary.ContainsKey(coordinates))
        {
            dictionary.Dictionary[coordinates].hasObsatacle = true;
        }
    }

}
