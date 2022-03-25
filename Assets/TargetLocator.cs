using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileSystem;
    [SerializeField] float range = 15f;
    [SerializeField] Transform currentTarget;

    private void Start()
    {
        AttachWeapon();
    }
    private void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }
    private void AttachWeapon()
    {
        foreach (Transform t in GetComponentInChildren<Transform>())
        {
            if (t.name.Equals("BallistaTopMesh"))
            {
                weapon = t;
            }
        }
        //projectileSystem = GetComponentInChildren<ParticleSystem>();
    }
    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;
        foreach(Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(this.transform.position, enemy.transform.position);
            if (targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }
        currentTarget = closestTarget;
    }
    void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, currentTarget.position);
        weapon.LookAt(currentTarget);
        if(targetDistance < range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }
    void Attack(bool isActive)
    {
        var emissionModule = projectileSystem.emission;
        emissionModule.enabled = isActive;
    }
}
