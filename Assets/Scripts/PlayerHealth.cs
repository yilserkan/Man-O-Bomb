using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Animator animator;

    private void OnParticleCollision(GameObject other) 
    {
        animator.SetTrigger("die");
        GetComponent<DeathHandler>().HandleDeath(); 
    }
}
