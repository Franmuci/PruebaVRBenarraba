using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using UnityEngine;

public class Basketball : MonoBehaviour
{


    public void Salto()
    {
        Invoke(nameof(Movimiento), 0.001f);
        print("RELEASE");

    }

    private void Movimiento()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 2, ForceMode.Impulse);

    }
}
