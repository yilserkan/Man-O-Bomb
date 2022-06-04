using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = .2f;
    [SerializeField] GameObject bombPrefab;
    [SerializeField] Animator animator;

    public CharacterController controller;

    Tile tile;
    PlaceBomb placeBomb;

    Vector3 movement;

    [SerializeField] string horizontal = "Horizontal";
    [SerializeField] string vertical = "Vertical";
    [SerializeField] string jump = "Jump";


    void Start() 
    {
        placeBomb = GetComponent<PlaceBomb>();
        tile = FindObjectOfType<Tile>();
    }

    private void Update()
    {
        movement.x = Input.GetAxis(horizontal);
        movement.z = Input.GetAxis(vertical);

        controller.Move(movement * Time.deltaTime * moveSpeed);
        if(movement.magnitude != 0)
            transform.rotation = Quaternion.LookRotation(movement.normalized);


        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        //we use space for placing bombs
        if(Input.GetButtonDown(jump))
        {
            InstansiateBomb();
        }

    }

    private void InstansiateBomb()
    {
        Vector2Int coordinates = new Vector2Int();

        coordinates.x = Mathf.RoundToInt(transform.position.x / tile.UnityGridSize);
        coordinates.y = Mathf.RoundToInt(transform.position.z / tile.UnityGridSize);

        Vector3 placementPosition = new Vector3(coordinates.x * tile.UnityGridSize, transform.position.y, coordinates.y * tile.UnityGridSize);

        placeBomb.EnableObjectsInPool(placementPosition);
    }
    
}
