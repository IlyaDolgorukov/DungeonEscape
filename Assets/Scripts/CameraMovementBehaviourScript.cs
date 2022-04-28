using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementBehaviourScript : MonoBehaviour
{
    [SerializeField] Transform Playerbody;
    [SerializeField] float MouseSensetivity = 1;

    float y = 0;

    // Update is called once per frame
    void Update()
    {
        var xRot = Input.GetAxis("Mouse X");
        var yRot = Input.GetAxis("Mouse Y");

        y += yRot;
        Playerbody.Rotate(new Vector3(0, xRot * MouseSensetivity, 0));
        transform.localRotation = Quaternion.Euler(y * MouseSensetivity, 0, 0);
    }
}
