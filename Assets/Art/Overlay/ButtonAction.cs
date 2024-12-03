using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAction : MonoBehaviour
{
    public void OnButtonDown(string name)
    {

        SceneLoaderProfe.instance.LoadScene(name);

    }

}