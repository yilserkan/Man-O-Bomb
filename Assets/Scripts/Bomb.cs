using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    [SerializeField] float timeToExplode = 3f;
    [SerializeField] ParticleSystem explodeVFX;

    Tile tile;
    Pathfinding dictionary;
    int explodeDistance;

    Vector3[] directions = { Vector3.forward, Vector3.back, Vector3.left, Vector3.right }; 


    private void Start() 
    {
        explodeDistance = GetComponentInParent<BombExplosionLength>().explodeDistance;
        tile = FindObjectOfType<Tile>();
        dictionary = FindObjectOfType<Pathfinding>();
    }

    private void OnEnable() 
    {
        if(GetComponentInParent<BombExplosionLength>()) 
            explodeDistance = GetComponentInParent<BombExplosionLength>().explodeDistance;
        GetComponent<SphereCollider>().enabled = false;        
    }

    void Update() 
    {
        EnableCollision();    
    }

    void EnableCollision()
    {
        Transform player = GetComponentInParent<BombExplosionLength>().player.transform;
        if( Vector3.Magnitude(player.position - transform.position) >= 6f)
            GetComponent<SphereCollider>().enabled = true;
    }

    public void CallExplode()
    {
        StartCoroutine(Explode());
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(timeToExplode);
        ParticleSystem vfx;
        vfx = Instantiate(explodeVFX, transform.position, Quaternion.LookRotation(Vector3.up));
        vfx.Play();
        foreach(Vector3 direction in directions)
        {
            for (int i = 1; i <= explodeDistance; i++)
            {
                Vector2Int coordinates = new Vector2Int();
                coordinates.x = Mathf.RoundToInt((transform.position.x + (direction.x * i *10)) / tile.UnityGridSize);
                coordinates.y = Mathf.RoundToInt((transform.position.z + (direction.z * i *10)) / tile.UnityGridSize);
                
                if(dictionary.Dictionary.ContainsKey(coordinates))
                {
                    if(!dictionary.Dictionary[coordinates].hasObsatacle)
                    {
                        Vector3 explodePosition = transform.position + (direction * i * 10);
                        vfx = Instantiate(explodeVFX, explodePosition, Quaternion.LookRotation(Vector3.up));
                        vfx.Play();
                    }
                    else
                    {
                        if(dictionary.Dictionary[coordinates].isObstacleDestructable)
                        {
                            Vector3 explodePosition = transform.position + (direction * i * 10);
                            vfx = Instantiate(explodeVFX, explodePosition, Quaternion.LookRotation(Vector3.up));
                            vfx.Play();
                        }
                        break;
                    }
                }

            }
        }
        gameObject.SetActive(false);
    }
}
