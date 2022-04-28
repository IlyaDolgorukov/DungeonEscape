using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockBehaviourScript : MonoBehaviour
{
    [SerializeField] GameObject LinkedKey;
    [SerializeField] GameObject LinkedDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            InventoryController playerInventory = other.gameObject.GetComponent<InventoryController>();
            if (playerInventory.HasKey(LinkedKey))
            {
                DoorController doorController = LinkedDoor.GetComponent<DoorController>();
                if (doorController.Overcome())
                {
                    Debug.Log("Открылась какая-то дверь");
                }
            }
            else
            {
                Debug.Log("У вас нет нужного ключа");
            }
        }
    }
}
