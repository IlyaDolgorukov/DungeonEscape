using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : DoorController
{
    [SerializeField] Transform Joint;
    [SerializeField] Transform AmmoHead;
    [SerializeField] GameObject Bullet;
    [SerializeField] float RotationSpeed = 1;
    [SerializeField] float CooldownTime = 10;

    private Transform playerPosition;
    private float currentTime = 0;

    // Update is called once per frame
    void Update()
    {
        if (!overcomed && playerPosition != null)
        {
            currentTime += Time.deltaTime;
            var rotDirection = playerPosition.position - Joint.position;
            var targetRotation = Quaternion.LookRotation(rotDirection.normalized);
            Joint.rotation = Quaternion.Lerp(Joint.rotation, targetRotation, RotationSpeed * Time.deltaTime);
        }
        else
        {
            currentTime = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerPosition = other.gameObject.transform;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (currentTime >= CooldownTime)
        {
            var ray = new Ray(AmmoHead.position, AmmoHead.forward);
            if (Physics.Raycast(ray, out var hit, 100f))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    var bullet = Instantiate(Bullet, AmmoHead.position, Quaternion.identity);
                    bullet.GetComponent<BulletController>().Fire(playerPosition.position - bullet.transform.position);
                }
            }

            currentTime = 0;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerPosition = null;
        }
    }

    public override bool Overcome()
    {
        if (!overcomed)
        {
            Joint.position = new Vector3(34.5f, 0.1f, 10f);
            Joint.rotation = Quaternion.Euler(8f, 35f, 162f);
            overcomed = true;

            return true;
        }

        return false;
    }
}
