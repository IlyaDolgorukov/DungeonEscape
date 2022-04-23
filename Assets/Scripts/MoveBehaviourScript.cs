using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBehaviourScript : MonoBehaviour
{
    [SerializeField] float speed = 1;
    Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        movement.Set(horizontal, 0f, vertical);
        movement.Normalize();

        transform.Translate(movement * Time.deltaTime * speed);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 100, ForceMode.Impulse);
        }
    }
}
