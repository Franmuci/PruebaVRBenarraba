using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lanzamiento : MonoBehaviour
{
     [SerializeField] private GameObject balaPrefab;
     [SerializeField] private Transform shootPoint;
     [SerializeField] private float umbralLanzamiento = 1.5f;
     [SerializeField] private float fuerza = 2f;
     [SerializeField] private float latencia = 0.5f;
     private float ultimoLanzamiento;
     void Update()
     {
         if (Time.time < (ultimoLanzamiento + latencia))
         {
             Debug.Log(ultimoLanzamiento + latencia);
             return;
         }
         else
         {
             Vector3 velocidadControlador =
             OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
             Quaternion rotacionControlador =
     
             OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);
     
             // magnitude devuelve la longitud del vector que es la raíz cuadrada de (x*x+y*y+z*z).
             float velocidad = velocidadControlador.magnitude;
             //Primero, normalizamos el vector velocidad con normalized dándole una magnitud de 1 y
             //después usamos el método Dot para realizar el producto escalar de los dos vectores.
             // Para vectores normalizados, Dot devuelve 1 si apuntan exactamente en la misma dirección, -1
             //si apuntan en direcciones completamente opuestas.
     
             bool esLanzando = Vector3.Dot(velocidadControlador.normalized, rotacionControlador *
             Vector3.forward) > 0;
     
             if (velocidad > umbralLanzamiento && esLanzando)
             {
                 Vector3 posicionControlador =
     
                 OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
     
                 LanzarBala(posicionControlador, rotacionControlador, velocidadControlador);
                 ultimoLanzamiento = Time.time;
             }
         }
     }
     private void LanzarBala(Vector3 posicionControlador, Quaternion rotacionControlador,
     Vector3 velocidadControlador)
     {
         GameObject bala = Instantiate(balaPrefab, shootPoint.position, shootPoint.rotation);
         Rigidbody rb = bala.GetComponent<Rigidbody>();
         rb.AddForce(shootPoint.rotation * Vector3.forward * velocidadControlador.magnitude *
         fuerza, ForceMode.VelocityChange);
         //Destroy(bala, 3f);
     }
}
