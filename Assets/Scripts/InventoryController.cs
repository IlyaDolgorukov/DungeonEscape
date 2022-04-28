using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private List<GameObject> keys;

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
}
