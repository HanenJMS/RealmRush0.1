using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health = 5;
    [SerializeField] int currentHealthPoints = 0;
    private void OnEnable()
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
            gameObject.SetActive(false);
        }
    }
    public bool isAlive()
    {
        return currentHealthPoints > 0;
    }
}
