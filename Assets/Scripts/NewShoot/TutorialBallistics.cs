using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBallistics : MonoBehaviour
{

    //Drags
    public Transform targetObj;
    public Transform gunObj;

    //The bullet's initial speed in m/s
    //Sniper rifle
    //public static float bulletSpeed = 850f;
    //Test
    public static float bulletSpeed = 850f;



    //Easier to change integration method once in this method
    public static void CurrentIntegrationMethod(
        float h,
        Vector3 currentPosition,
        Vector3 currentVelocity,
        out Vector3 newPosition,
        out Vector3 newVelocity)
    {
        //IntegrationMethods.EulerForward(h, currentPosition, currentVelocity, out newPosition, out newVelocity);
        //IntegrationMethods.Heuns(h, currentPosition, currentVelocity, out newPosition, out newVelocity);
        IntegrationMethods.BackwardEuler(h, currentPosition, currentVelocity, out newPosition, out newVelocity);
    }
}
