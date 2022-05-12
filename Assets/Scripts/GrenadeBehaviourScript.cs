using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBehaviourScript : MonoBehaviour
{
    private bool isDropped = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isDropped)
        {
            InventoryController playerInventory = other.gameObject.GetComponent<InventoryController>();
            var grenade = playerInventory.GetGrenade();
            if (grenade == null)
            {
                playerInventory.AddGrenade(gameObject);
                gameObject.SetActive(false);
                Debug.Log("Чтобы бросить гранату, нажмите 'f'");
            }
        }
        else if (other.gameObject.CompareTag("Wall") && isDropped)
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Floor") && isDropped)
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Roof") && isDropped)
        {
            Destroy(gameObject);
        }
    }

    public void DropGrenade(Vector3 direction)
    {
        isDropped = true;
        this.gameObject.SetActive(true);
        this.gameObject.GetComponent<Rigidbody>().AddForce(direction, ForceMode.Impulse);
    }
}
