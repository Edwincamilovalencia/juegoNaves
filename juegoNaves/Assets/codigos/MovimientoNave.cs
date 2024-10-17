using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoNave : MonoBehaviour
{
    public float velocidad = 10f;
    public float velocidadMaxima = 15f;

    public float frecuenciaDisparo=1f;
    public float ultimoDisparo=0f;
    public Transform pivoteProyectil;
    public GameObject proyectilObj;
    private Rigidbody cuerpoRigido;

    void Start()
    {
        cuerpoRigido = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moverX = Input.GetAxis("Horizontal");
        float moverY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moverX, moverY, 0f) * velocidad;

        if (cuerpoRigido.velocity.magnitude < velocidadMaxima)
        {
            cuerpoRigido.AddForce(movement, ForceMode.Acceleration);
        }
    }
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Space) && Time.time > frecuenciaDisparo + ultimoDisparo)
        {
            GameObject obj = Instantiate(proyectilObj,pivoteProyectil.position,pivoteProyectil.rotation);
            obj.GetComponent<Rigidbody>().AddForce(Vector3.up * 50f,ForceMode.Impulse);
            ultimoDisparo = Time.time;
            Destroy(obj,4);
        }
        cuerpoRigido.velocity = Vector3.ClampMagnitude(cuerpoRigido.velocity, velocidad);
    }
}
