using Oculus.Haptics;
using Oculus.Interaction.HandGrab;
using System.Collections;
using UnityEngine;


public class FireBullets : MonoBehaviour, IHandGrabUseDelegate
{
    public GameObject bulletObj;
    public Transform bulletSpawn;


    [Header("Prefab Refrences")]
    public GameObject muzzleFlashPrefab;

    public HapticClip clip1;
    private HapticClipPlayer player;
    public AudioSource bangSound;

    public GameObject casingPrefab;
    [SerializeField] private Transform casingExitLocation;

    private bool _canFire = true;

    [Header("Settings")]
    [Tooltip("Specify time to destory the casing object")][SerializeField] private float destroyTimer = 2f;
    [Tooltip("Casing Ejection Speed")][SerializeField] private float ejectPower = 150f;


    private void Start()
    {
        player ??= new HapticClipPlayer(clip1);
    }

    public void FireBullet()
    {

        if (muzzleFlashPrefab)
        {
            //Create the muzzle flash
            GameObject tempFlash;
            tempFlash = Instantiate(muzzleFlashPrefab, bulletSpawn.position, bulletSpawn.rotation);

            //Destroy the muzzle flash effect
            Destroy(tempFlash, destroyTimer);
        }

        //Create a new bullet
        GameObject newBullet = Instantiate(bulletObj, bulletSpawn.position, bulletSpawn.rotation) as GameObject;

            //Add velocity to the non-physics bullet
            newBullet.GetComponent<ShootImprovement>().currentVelocity = TutorialBallistics.bulletSpeed * transform.forward;
    }

    IEnumerator VibrateForSeconds(float duration)
    {
        bangSound.Stop();
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

    public void BeginUse()
    {
       
    }

    public void EndUse()
    {
        
    }

    public float ComputeUseStrength(float strength)
    {
        print(strength);
        if(strength > 0.6f && _canFire)
        {
            FireBullet();
            CasingRelease();
            StartCoroutine(VibrateForSeconds(0.5f));
            _canFire = false;
        }
        else if (strength < 0.6f && !_canFire)
        {
            _canFire = true;
        }
        
        return strength;
    }
}
