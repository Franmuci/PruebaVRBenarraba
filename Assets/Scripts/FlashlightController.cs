using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{

    public Light touchLight;
    bool onLight = false;


    private void Start()
    {
        touchLight.enabled = onLight;
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            onLight = !onLight;
            touchLight.enabled = onLight;
        }
    }
}
