using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private List<GameObject> keys;
    private GameObject grenade = null;

    // Start is called before the first frame update
    void Start()
    {
        keys = new List<GameObject>();
    }

    public void AddKey(GameObject key)
    {
        keys.Add(key);
    }

    public bool HasKey(GameObject key)
    {
        return keys.Contains(key);
    }

    public void AddGrenade(GameObject grenade)
    {
        this.grenade = grenade;
    }

    public void DropGrenade()
    {
        grenade.SetActive(true);
        grenade = null;
    }

    public GameObject GetGrenade()
    {
        return grenade != null ? Instantiate(grenade, transform.position, Quaternion.identity) : null;
    }
}
