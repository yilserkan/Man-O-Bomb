using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas mainMenu;

    void Start() 
    {
        mainMenu.enabled = false;    
    }

    public void HandleDeath()
    {
        mainMenu.enabled = true;
        gameObject.GetComponent<PlayerMovement>().enabled = false;   
    }

}
