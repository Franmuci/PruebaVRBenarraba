using Oculus.Interaction.HandGrab;
using UnityEngine;

public class UseGrabShotgun : MonoBehaviour, IHandGrabUseDelegate
{
    public void BeginUse()
    {
        print("Begin");
    }

    public float ComputeUseStrength(float strength)
    {
        print("Strength: "+ strength);
        return 2f;
    }

    public void EndUse()
    {
        print("End");

    }
}
