using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] Transform target;

    private void Start()
    {
        target = FindObjectOfType<EnemyMover>().transform;
        foreach(Transform t in GetComponentInChildren<Transform>())
        {
            if(t.name.Equals("BallistaTopMesh"))
            {
                weapon = t;
            }
        }
    }

    private void Update()
    {
        AimWeapon();
    }
    void AimWeapon()
    {
        weapon.LookAt(target);
    }
}
