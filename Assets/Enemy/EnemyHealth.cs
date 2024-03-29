using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health = 5;
    [SerializeField] int currentHealthPoints = 0;
    Enemy enemy;
    private void OnEnable()
    {
        currentHealthPoints = health;
    }
    private void Start()
    {
        enemy = GetComponent<Enemy>();
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
            IsDying();
            gameObject.SetActive(false);
        }
    }
    void IsDying()
    {
        enemy.GoldReward();
    }
}
