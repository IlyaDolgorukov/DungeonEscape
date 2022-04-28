using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    protected bool overcomed = false;

    public virtual bool Overcome()
    {
        if (!overcomed)
        {
            float x = transform.position.x;
            float y = transform.position.y + 50;
            float z = transform.position.z;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(x, y, z), 50 * Time.deltaTime);
            overcomed = true;

            return true;
        }

        return false;
    }
}
