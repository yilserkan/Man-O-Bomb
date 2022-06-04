using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Obstacle : MonoBehaviour
{

    [SerializeField] bool isDestroyable = false;
    [SerializeField] GameObject addBombPrefab;
    [SerializeField] GameObject increaseBombLengthPrefab;

    Pathfinding dictionary;


    void Start() 
    {
        dictionary = FindObjectOfType<Pathfinding>();
        if(isDestroyable)
        {
            dictionary.SetHasObstacle(transform.position, true, true);  
        }
        else
        {
            dictionary.SetHasObstacle(transform.position, true, false);  
        }
          
    }

    void OnParticleCollision(GameObject other) 
    {
        if(isDestroyable && dictionary.ConvertPositionToCoordinates(other.transform.position) == dictionary.ConvertPositionToCoordinates(transform.position))
        {   
            dictionary.SetHasObstacle(transform.position, false, false);
            CreateItem();    
            Destroy(gameObject);
        }    
    }

    private void CreateItem()
    {
        int dropRate = Random.Range(0,100);
        if(dropRate < 50)
        {
            int item = Random.Range(0,2);
                if(item < 1)
                {
                    Instantiate(addBombPrefab,transform.position,Quaternion.identity);
                }
                else
                {
                    Instantiate(increaseBombLengthPrefab,transform.position,Quaternion.identity);
                }
        }
    }
}
