using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public GameController gameController;
    void OnCollisionEnter(Collision obj)
    {
        Debug.Log("Derribado"); gameController.TargetHit(obj.gameObject);
    }
}
