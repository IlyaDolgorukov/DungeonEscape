using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearTrapBehaviourScript : MonoBehaviour
{
    [SerializeField] float Damage;
    [SerializeField] float DamagePerSecond;

    private HealthController trappedHealthController;

    private float stayTime = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            trappedHealthController = other.gameObject.GetComponent<HealthController>();
            trappedHealthController.AddDamage(Damage);
            SpearsMove(true);
            Debug.Log(trappedHealthController.CurrentHealth);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (trappedHealthController != null && stayTime >= 1)
        {
            trappedHealthController.AddDamage(DamagePerSecond);
            Debug.Log(trappedHealthController.CurrentHealth);
            stayTime = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            trappedHealthController = null;
            stayTime = 0;
            SpearsMove(false);
        }
    }

    private void SpearsMove(bool up)
    {
        float way = up ? 10 : -10;

        foreach (Transform child in transform)
        {
            float x = child.position.x;
            float y = child.position.y + way;
            float z = child.position.z;
            child.position = Vector3.MoveTowards(child.position, new Vector3(x, y, z), 30 * Time.deltaTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        stayTime += Time.deltaTime;
    }
}
