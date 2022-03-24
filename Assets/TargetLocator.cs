using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] Transform currentTarget;

    private void Start()
    {
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
        if(currentTarget == null)
        {
            foreach(EnemyHealth enemy in FindObjectsOfType<EnemyHealth>())
            {
                if(enemy.isAlive())
                {
                    currentTarget = enemy.gameObject.transform;
                    AimWeapon();
                }
            }
        }
    }
    void AimWeapon()
    {
        weapon.LookAt(currentTarget);
    }
}
