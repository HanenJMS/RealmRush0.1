using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health = 5;
    [SerializeField] int currentHealthPoints = 0;
    private void Start()
    {
        currentHealthPoints = health;
    }
    private void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        TakeDamage();
    }

    private void TakeDamage()
    {
        currentHealthPoints--;
        if (currentHealthPoints <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
