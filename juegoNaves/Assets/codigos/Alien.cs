using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {   
        if(collision.gameObject.CompareTag("Nave"))
            Destroy(this.gameObject);

        if(collision.gameObject.CompareTag("Proyectil"))
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
