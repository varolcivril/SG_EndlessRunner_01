using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageWallController : MonoBehaviour
{
    static public event Action isPlayerDead;

    // eventi buraya yazýp hem bullet collision hem player collision için çalýþtýrabiliriz
    
    [SerializeField] private TextMeshProUGUI _text;

    private int[] _wallHealthRange = { 3,4,5,7,9,10,10,20,30,50 };
    //private int[] _wallHealthMultiplierRange = { 1, 1, 2, 3 };
    private int _wallHealthIndex;
    //private int _wallHealthMultiplierIndex;
    private int _wallHealth;
    //private int _wallHealthTemp;

    private void OnEnable()
    {
        BulletController.onBulletHit += Damage;
        //GameManager.onLevelGeneration += EnableMultiplier;
    }

    private void Start()
    {
        _wallHealthIndex = UnityEngine.Random.Range(0, 10);
        _wallHealth = _wallHealthRange[_wallHealthIndex]; //* _wallHealthMultiplierRange[_wallHealthMultiplierIndex];
        _text.text = _wallHealth.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerDead?.Invoke();
        }
    }
    private void Damage(GameObject collided, int damage)
    {
        if (collided != this.gameObject)
        {
            return;
        }
        //_wallHealthTemp = _wallHealth;

        _wallHealth -= damage;
        _text.text = _wallHealth.ToString();

        if (_wallHealth <= 0)
        {
            this.gameObject.SetActive(false);
            //_wallHealth = _wallHealthTemp;
        }
    }

    private void EnableMultiplier()
    {
        //_wallHealthMultiplierIndex = UnityEngine.Random.Range(0, 4);
        //_wallHealth = _wallHealthRange[_wallHealthIndex] * _wallHealthMultiplierRange[_wallHealthMultiplierIndex];
    }

    private void OnDisable()
    {
        BulletController.onBulletHit -= Damage;
        //GameManager.onLevelGeneration -= EnableMultiplier;

    }
}
