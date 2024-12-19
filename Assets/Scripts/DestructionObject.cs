using UnityEngine;

public class DestructionObject : MonoBehaviour
{
    public GameObject destroyedVersion;
    
    private void OnMouseDown()
    {
       
        Instantiate (destroyedVersion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
