using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPosition : MonoBehaviour
{

    private void Update()
    {
        Vector3 velocidadControlador =
OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);

        Quaternion rotacionControlador =
OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);
        Vector3 posicionControlador =
        OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
        float velocidad = velocidadControlador.magnitude;
        if (velocidad > 1)
        {
            Debug.Log(velocidadControlador);
            Debug.Log(velocidad);
            Debug.Log(rotacionControlador);
            Debug.Log(posicionControlador.x);
            Debug.Log("*****************");
        }
    }

}
