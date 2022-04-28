using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] float MaxHealth = 100;
    private float health;

    public float CurrentHealth { get => health; }

    // Start is called before the first frame update
    void Start()
    {
        health = MaxHealth;
    }

    public void AddDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Debug.Log("GAME OVER");
        }
    }
}
