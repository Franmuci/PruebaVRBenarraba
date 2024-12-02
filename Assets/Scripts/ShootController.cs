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


    public GameObject casingPrefab;
    [SerializeField] private Transform casingExitLocation;

    [Header("Settings")]
    [Tooltip("Specify time to destory the casing object")][SerializeField] private float destroyTimer = 2f;
    [Tooltip("Casing Ejection Speed")][SerializeField] private float ejectPower = 150f;


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
                CasingRelease();
                StartCoroutine(VibrateForSeconds(0.5f, OVRInput.Controller.RTouch));
            
            }
        }
    }


    IEnumerator VibrateForSeconds(float duration,OVRInput.Controller controller)
    {
        PlayHapticClip1();
        bangSound.Play();
        yield return new WaitForSeconds(duration);
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

    //This function creates a casing at the ejection slot
    void CasingRelease()
    {
        //Cancels function if ejection slot hasn't been set or there's no casing
        if (!casingExitLocation || !casingPrefab)
        { return; }

        //Create the casing
        GameObject tempCasing;
        tempCasing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        //Add force on casing to push it out
        tempCasing.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower), (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        //Add torque to make casing spin in random direction
        tempCasing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);

        //Destroy casing after X seconds
        Destroy(tempCasing, destroyTimer);
    }


}
