using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysBehaviourScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            InventoryController playerInventory = other.gameObject.GetComponent<InventoryController>();
            playerInventory.AddKey(gameObject);
            gameObject.SetActive(false);
        }
    }
}
