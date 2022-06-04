using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyVFX : MonoBehaviour
{
    void Start()
    {
        Invoke("DestroyVF", 1f);
    }

    void DestroyVF()
    {
        Destroy(gameObject);
    }
}
