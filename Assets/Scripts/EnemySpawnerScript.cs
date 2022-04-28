using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    [SerializeField] GameObject enemyObject;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemyObject, transform);
    }
}
