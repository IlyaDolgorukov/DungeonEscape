using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]

public class BulletController : MonoBehaviour
{
    [SerializeField] private float BulletSpeed = 1;
    [SerializeField] float Damage;

    public void Fire(Vector3 direction)
    {
        GetComponent<Rigidbody>().AddForce(direction * BulletSpeed, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HealthController trappedHealthController = other.gameObject.GetComponent<HealthController>();
            trappedHealthController.AddDamage(Damage);
            Debug.Log(trappedHealthController.CurrentHealth);
            Destroy(gameObject);
        } 
        else if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Roof"))
        {
            Destroy(gameObject);
        }
    }
}
