using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    static public event Action<int> onCoinPickup;

    private void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, 50 * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            onCoinPickup?.Invoke(5);
            Destroy(this.gameObject);
        }
    }
}
