using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorAliens : MonoBehaviour
{
    public Transform[] puntosPivotes;
    public GameObject alienObj;
    public float tiempoCreacion;
    private float tiempoTranscurrido;
    private int indicePivote;

    void Update()
    {
        if(tiempoTranscurrido>tiempoCreacion)
        {
            indicePivote = Random.Range(0,puntosPivotes.Length);
            GameObject obj = Instantiate(alienObj,puntosPivotes[indicePivote].position,puntosPivotes[indicePivote].rotation);
            obj.name = "Alien";
            obj.GetComponent<Rigidbody>().AddForce(-Vector3.up * 20f,ForceMode.Impulse);
            tiempoTranscurrido = 0;
        }else{
            tiempoTranscurrido+=Time.deltaTime;
        }
    }
}
