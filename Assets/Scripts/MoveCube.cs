using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OVRInput;

public class MoveCube : MonoBehaviour
{
    [SerializeField] private float speed = 1.05f;

    private Vector2 axis;

    // Update is called once per frame
    void Update()
    {
        axis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        transform.Translate(new Vector3(axis.x,0, axis.y)* speed * Time.deltaTime);

        if(OVRInput.Get(OVRInput.Button.One)) transform.Translate(Vector3.up * speed * Time.deltaTime);
        if(OVRInput.Get(OVRInput.Button.Two)) transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
