using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBomb : MonoBehaviour
{
    [SerializeField] GameObject bombPrefab;
    [SerializeField] int poolSize = 10;
    [SerializeField] public int bombPlaceCount = 1;
    [SerializeField] Transform parent;
    public Transform Parent { get { return parent; } }

    GameObject[] pool;

    void Start() 
    {
        PopulatePool();
    }

    private void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            pool[i] = Instantiate(bombPrefab);
            pool[i].SetActive(false);
            pool[i].transform.parent = parent;
        }
    }

    public GameObject EnableObjectsInPool(Vector3 position)
    {
        for(int i = 0; i < bombPlaceCount ; i++)
        {
            if(!pool[i].activeInHierarchy)
            {
                pool[i].transform.position = position;
                pool[i].transform.rotation = Quaternion.Euler( new Vector3(0f, 180f, 0f));
                pool[i].SetActive(true);
                pool[i].GetComponent<Bomb>().CallExplode();
                return pool[i];
            }
        }
        return null;
    }

    
}
