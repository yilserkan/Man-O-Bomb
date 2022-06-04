using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    [SerializeField] Items item;

    private void OnTriggerEnter(Collider other) 
    {
        if(item == Items.addBomb)
        {
            AddBomb(other);
        }   

        else if(item == Items.increaseExplosionLength)
        {
            IncreaseExplosionLength(other);
        }
    }

    void AddBomb(Collider other)
    {
        other.GetComponent<PlaceBomb>().bombPlaceCount++;
        Destroy(gameObject);
    }

    private void IncreaseExplosionLength(Collider other)
    {
        Transform parent = other.GetComponent<PlaceBomb>().Parent;
        parent.GetComponent<BombExplosionLength>().explodeDistance++;
        Destroy(gameObject);
    }

}
