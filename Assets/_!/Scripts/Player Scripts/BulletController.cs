using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public static event Action<GameObject, int> onBulletHit;

    private int _bulletDamage = 1;

    private void OnEnable()
    {
        BuffWallController.onDamageBuffPickup += IncreaseBulletDamage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            onBulletHit?.Invoke(other.gameObject, _bulletDamage);
            this.gameObject.SetActive(false);
        }
    }

    private void IncreaseBulletDamage(int buffAmount)
    {
        _bulletDamage += buffAmount;
    }

    private void OnDisable()
    {
        BuffWallController.onDamageBuffPickup -= IncreaseBulletDamage;
    }

}


