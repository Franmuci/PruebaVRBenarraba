using Oculus.Haptics;
using System.Collections;
using UnityEngine;


public class FireBullets : MonoBehaviour
{
    public GameObject bulletObj;
    public Transform bulletSpawn;


    [Header("Prefab Refrences")]
    public GameObject muzzleFlashPrefab;

    public HapticClip clip1;
    private HapticClipPlayer player;
    public AudioSource bangSound;


    private void Start()
    {
        player ??= new HapticClipPlayer(clip1);
    }

    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        {
            if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {
                FireBullet();
                StartCoroutine(VibrateForSeconds(0.5f));
            }
        }
    }

    public void FireBullet()
    {
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

}
