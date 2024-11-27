using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Haptics;

public class ShootController : MonoBehaviour
{
    public GameObject Bullet;
    public float shootForce;
    public Transform shootPoint;

    public HapticClip clip1;
    private HapticClipPlayer player;
    public AudioSource bangSound;

    void Awake()
    {
        player = new HapticClipPlayer(clip1);
    }

    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        {
            if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {
                Instantiate(Bullet, shootPoint.position,shootPoint.rotation).GetComponent<Rigidbody>().AddForce(shootPoint.forward * shootForce);
                StartCoroutine(VibrateForSeconds(0.5f, 1f, 0.3f, OVRInput.Controller.RTouch));
            
            }
        }
    }


    IEnumerator VibrateForSeconds(float duration, float frequency, float amplitude,OVRInput.Controller controller)
    {
        //OVRInput.SetControllerVibration(frequency, amplitude, controller);
        PlayHapticClip1();
        bangSound.Play();
        yield return new WaitForSeconds(duration);
        //OVRInput.SetControllerVibration(0, 0, controller);
        StopHaptics();
    }

    public void PlayHapticClip1()
    {
        player.Play(Controller.Right);
    }

    public void StopHaptics()
    {
        player.Stop();
    }

}
